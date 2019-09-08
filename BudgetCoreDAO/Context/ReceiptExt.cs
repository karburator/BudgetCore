using System;
using System.Linq;

namespace BudgetCoreDAO.Context
{
    public static class ReceiptExt
    {
        public static Receipt GetReceipt(this BudgetContext context, string fiscalDriveNumber,
            int fiscalDocumentNumber, int fiscalSign, DateTime date, int totalSum)
        {
            var result = context.Receipts.FirstOrDefault(el=>el.FiscalDocumentNumber == fiscalDocumentNumber
                                                        && el.FiscalDriveNumber.Equals(fiscalDriveNumber)
                                                        && el.FiscalSign == fiscalSign
                                                        && el.Date == date
                                                        && el.TotalSum == totalSum);
            return result;
        }
    }
}