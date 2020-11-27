using BudgetCoreDAO;
using BudgetCoreDAO.Context;

namespace BudgetTestApplication.DataGeneration
{
    public class GoodGenerator
    {
        public Good GetGood(BudgetContext context)
        {
            var productGenerator = new ProductsGenerator();
            var price = RandomUtils.PositiveNumber(1000);
            var quantity = RandomUtils.PositiveNumber(5);
            return new Good()
            {
                Product = productGenerator.GetProduct(context),
                Price = price,
                Quantity = quantity,
                Sum = price * quantity,
                Nds18 = (price * quantity + 117) / 118 * 18
            };
        }
    }
}