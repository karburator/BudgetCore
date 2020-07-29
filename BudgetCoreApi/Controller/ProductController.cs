using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetCoreApi.Controller
{
    [Route("product")]
    public class ProductController
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using (var context = new BudgetContext())
            {
                var receipts = await context.Products.ToListAsync();
                return receipts;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Product> GetProduct(int id)
        {
            using (var context = new BudgetContext())
            {
                var receipt = await context.Products
                    .FirstOrDefaultAsync(el => el.Id == id);
                return receipt;
            }
        }
    }
}