using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BudgetCoreApi.Controller
{
    [Route("good")]
    [EnableCors("MyPolicy")]
    public class GoodController
    {
        [HttpGet]
        public async Task<IEnumerable<Good>> GetAllGoods()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Goods
                    .Include(el => el.Product)
                    .ToListAsync();
                return receipts;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Good> GetGood(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Goods
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }

        [HttpGet("product/{productId:int}")]
        public async Task<IEnumerable<Good>> GetGoodsByProductId(int productId)
        {
            using (var context = new BudgetContext())
            {
                var goods = await context.Goods
                    .Include(el => el.Product)
                    .Where(el => el.Product.Id == productId)
                    .ToListAsync();
                return goods;
            }
        }
        
        [HttpGet("receipt/{receiptId:int}")]
        public async Task<IEnumerable<Good>> GetGoodsByReceiptId(int receiptId)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Receipts
                    .Include(el => el.Items)
                    .ThenInclude(el => el.Product)
                    .FirstOrDefaultAsync(el => el.Id == receiptId);
                return receipt.Items ?? Enumerable.Empty<Good>();
            }
        }
    }
}