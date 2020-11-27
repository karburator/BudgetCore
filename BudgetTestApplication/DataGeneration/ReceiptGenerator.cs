using System.Collections;
using BudgetCoreDAO;

namespace BudgetTestApplication.DataGeneration
{
    public class ReceiptGenerator
    {
        public Receipt GetReceipt()
        {
            return new Receipt()
            {
                FiscalDriveNumber = RandomUtils.NumberedString(16),
                FiscalSign = RandomUtils.Number(100000000, 1000000000)
            };
        }
    }
}