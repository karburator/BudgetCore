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
//            var path = @"..\..\..\..\..\Resources\JsonData\28_07_2019_03_07_065945492267877694613.json";
            var path = @"..\..\..\..\..\Resources\JsonData\array.json";
            var model = parser.ParseArrayFile(path);

            using (var context = new BudgetContext())
            {
                foreach (var receiptModel in model)
                {
                    var receipt = ReceiptWtapper.Create(receiptModel);

                    var current = context.GetReceipt(receiptModel.FiscalDriveNumber, receiptModel.FiscalDocumentNumber,
                        receiptModel.FiscalSign,
                        receiptModel.DateTime, receiptModel.TotalSum);

                    if (current == null)
                    {
                        context.Receipts.Add(receipt);
                        context.SaveChanges();
                    }
                }

            }
        }
    }
}