using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetCoreApi.Model;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BudgetCoreApi.Controller
{
    [Route("product")]
    [EnableCors("MyPolicy")]
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

        [HttpGet("ProductChart/{id:int}")]
        public async Task<List<ChartPoint>> GetProductChart(int id)
        {
            var chartType = "max";
            switch (chartType)
            {
                case "max":
                    using (var context = new BudgetContext())
                    {
                        var points = context.Goods
                            .Where(el => el.Product.Id == id)
                            .Join(context.Receipts.SelectMany(r => r.Items
                                    .Select(i => new
                                    {
                                        Date = r.Date,
                                        GoodId = i.Id
                                    })),
                                g => g.Id,
                                r => r.GoodId,
                                (g, r) => new ChartPoint() {Date = r.Date, Price = g.Price})
                            .GroupBy(el => el.Date)
                            .Select(el => new ChartPoint()
                            {
                                Date = el.Key.Date,
                                Price = el.Max(p => p.Price)
                            })
                            .ToListAsync();

                        return await points;
                    }
                    break;
                default:
                    return new List<ChartPoint>();
            }
        }
    }
}