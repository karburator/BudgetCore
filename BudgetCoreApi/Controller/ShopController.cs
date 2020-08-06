using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetCoreApi.Controller
{
    [Route("shop")]
    [EnableCors("MyPolicy")]
    public class ShopController
    {
        [HttpGet]
        public async Task<IEnumerable<Shop>> GetAllShops()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Shops.ToListAsync();
                return receipts;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Shop> GetShop(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Shops
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }
    }
}