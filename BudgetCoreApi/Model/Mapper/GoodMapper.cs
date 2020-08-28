using BudgetCoreDAO;

namespace BudgetCoreApi.Model.Mapper
{
    public class GoodMapper
    {
        public static GoodChardModel GetGoodChard(Receipt receipt, Good item)
        {
            var result = new GoodChardModel()
            {
                GoodId = item.Id,
                Date = receipt.Date,
                Price = item.Price
            };

            return result;
        }
    }
}