using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace BudgetFIleListner.Parse.Json
{
    public class JsonParser
    {
        public JsonParser()
        {
            JsConfig.DateHandler = DateHandler.UnixTime;
        }

//        public ReceiptModel ParseFile(string filePath)
//        {
//            using(FileStream fileStream = new FileStream(filePath, FileMode.Open))
//            {
//                using(StreamReader reader = new StreamReader(fileStream))
//                {
//                    string json = reader.ReadToEnd();
//                    ReceiptModel model = GetReceiptModel<ReceiptModel>($"{{{json}}}");
//                    return model;
//                }
//            }
//        }
        
        public ReceiptModel[] ParseArrayFile(string filePath)
        {
            using(FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(fileStream))
                {
                    string json = reader.ReadToEnd();
                    var model = GetReceiptModel(json);;
//                    var model = GetReceiptModel($"{{{json}}}");;
                    return model.ToArray();
                }
            }
        }
        
        public ReceiptModel[] ParseDocumentArrayFile(string filePath)
        {
            using(FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(fileStream))
                {
                    string json = reader.ReadToEnd();
                    var model = GetReceiptModelByDocuments(json);;
//                    var model = GetReceiptModel($"{{{json}}}");;
                    return model.ToArray();
                }
            }
        }

//        public T GetReceiptModel<T>(string json)
//        {
//            try
//            {
//                T receipt = JsonSerializer.DeserializeFromString<T>(json);
//                return receipt;
//            }
//            catch(Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

        public IEnumerable<ReceiptModel> GetReceiptModel(string json)
        {
            try
            {
                var receipt = JsonSerializer.DeserializeFromString<List<ReceiptModel>>(json);
                return receipt;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public IEnumerable<ReceiptModel> GetReceiptModelByDocuments(string json)
        {
            try
            {
                var documentModels = JsonSerializer.DeserializeFromString<List<RootDocumentModel>>(json);
                return documentModels
                    .Where(el => el.Document?.Receipt != null)
                    .Select(el => el.Document.Receipt);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
