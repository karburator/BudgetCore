using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetCoreApi.Model;
using BudgetCoreApi.Model.Mapper;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetCoreApi.Controller
{
    [Route("reciept")]
    [EnableCors("MyPolicy")]
    public class ReceiptController
    {
        [HttpGet]
        public async Task<IEnumerable<ReceiptModel>> GetAllReceipts()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Receipts
                    .Include(el => el.Shop)
                    .ToListAsync();

                var receiptModels = receipts
                    .Select(ReceiptMapper.GetReceiptModel)
                    .ToList();
                return receiptModels;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Receipt> GetReceipt(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Receipts
                    .Include(el => el.Items)
                    .Include(el => el.Shop)
                    .Include(el => el.Modifiers)
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }
    }
}