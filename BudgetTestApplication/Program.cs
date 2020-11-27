using System;
using System.IO;
using BudgetCoreDAO.Context;
using BudgetFIleListner.Parse.Json;
using BudgetTestApplication.DataGeneration;

namespace BudgetTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // ParsReceiptArray();
            // ParsDocumentArray();
            CreateTestDb();
        }

        private static void CreateTestDb()
        {
            var generator = new DataGenerator();
            generator.CreateData();
        }

        private static void ParsReceiptArray()
        {
            var parser = new JsonParser();
//            var path = @"..\..\..\..\..\Resources\JsonData\28_07_2019_03_07_065945492267877694613.json";
            var path = @"..\..\..\..\..\Resources\JsonData\array.json";
            var model = parser.ParseArrayFile(path);

            using (var context = new BudgetContext())
            {
                foreach (var receiptModel in model)
                {
                    var receipt = ReceiptWtapper.Create(receiptModel, context);

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
        
        private static void ParsDocumentArray()
        {
            var parser = new JsonParser();
//            var path = @"..\..\..\..\..\Resources\JsonData\28_07_2019_03_07_065945492267877694613.json";
            var path = @"..\..\..\..\..\Resources\JsonData\document-array.json";
            // var path = @"..\..\..\..\..\Resources\JsonData\test.json";
            var model = parser.ParseDocumentArrayFile(path);

            using (var context = new BudgetContext())
            {
                foreach (var receiptModel in model)
                {
                    var receipt = ReceiptWtapper.Create(receiptModel, context);

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