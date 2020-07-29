using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BudgetCoreApi.Controller
{
    [Route("good")]
    public class GoodController
    {
        [HttpGet]
        public async Task<IEnumerable<Good>> GetAllGoods()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Goods.ToListAsync();
                return receipts;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Good> GetGood(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Goods
                    .Include(el => el.Product)
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }
    }
}