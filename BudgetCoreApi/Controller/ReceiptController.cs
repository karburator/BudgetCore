using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetCoreApi.Controller
{
    [Route("reciept")]
    public class ReceiptController
    {
        [HttpGet]
        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Receipts.ToListAsync();
                return receipts;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Receipt> GetReceipt(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Receipts
                    .Include(el => el.Items)
                    .Include(el => el.Modifiers)
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }
    }
}