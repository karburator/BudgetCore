using BudgetCoreDAO;

namespace BudgetCoreApi.Model.Mapper
{
    public class ReceiptMapper
    {
        public static ReceiptModel GetReceiptModel(Receipt item)
        {
            var result = new ReceiptModel()
            {
                Id = item.Id,
                Date = item.Date,
                TotalSum = Currency.AmountToRub(item.TotalSum),
                CashTotalSum = Currency.AmountToRub(item.CashTotalSum),
                EcashTotalSum = Currency.AmountToRub(item.EcashTotalSum)
            };

            if (item.Shop != null)
            {
                result.UserId = item.Shop.Id;
                result.User = item.Shop.User;
                result.UserInn = item.Shop.UserInn;
            }

            return result;
        }
    }
}