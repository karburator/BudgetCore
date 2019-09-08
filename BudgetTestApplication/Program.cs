using System;
using System.IO;
using BudgetCoreDAO.Context;
using BudgetFIleListner.Parse.Json;

namespace BudgetTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new JsonParser();
            var path = @"..\..\..\..\..\Resources\JsonData\28_07_2019_03_07_065945492267877694613.json";
            var model = parser.ParseFile(path);

            using (var context = new BudgetContext())
            {
                var receipt = ReceiptWtapper.Create(model);

                var current = context.GetReceipt(model.FiscalDriveNumber, model.FiscalDocumentNumber, model.FiscalSign,
                    model.DateTime, model.TotalSum);

                if (current == null)
                {
                    context.Receipts.Add(receipt);
                    context.SaveChanges();
                }
                
            }
        }
    }
}