using System.Linq;
using BudgetCoreDAO;
using BudgetFIleListner.Parse.Json;

namespace BudgetTestApplication
{
    public class ReceiptWtapper
    {
        public static Receipt Create(ReceiptModel model)
        {
            var receipt = new Receipt()
            {
                Date = model.DateTime,
                Nds0 = model.Nds0,
                Nds10 = model.Nds10,
                Nds18 = model.Nds18,
                Operator = model.Operator,
                User = model.User,
                UserInn =  model.UserInn,
                FiscalSign = model.FiscalSign,
                NdsCalculated10 = model.NdsCalculated10,
                NdsCalculated18 = model.NdsCalculated18,
                NdsNo = model.NdsNo,
                RequestNumber = model.RequestNumber,
                ShiftNumber = model.ShiftNumber,
                TaxationType = model.TaxationType,
                TotalSum = model.TotalSum,
                CashTotalSum = model.CashTotalSum,
                EcashTotalSum = model.EcashTotalSum,
                FiscalDocumentNumber = model.FiscalDocumentNumber,
                FiscalDriveNumber = model.FiscalDriveNumber,
                KktRegId = model.KktRegId,
                RetailPlaceAddress = model.RetailPlaceAddress,
                Modifiers = model.Modifiers?.Select(el=>new Modifier
                {
                    Discount = el.Discount,
                    Markup = el.Markup,
                    DiscountName = el.DiscountName,
                    DiscountSum = el.DiscountSum,
                    MarkupName = el.MarkupName,
                    MarkupSum = el.MarkupSum
                }).ToList(),
                OperationType = new OperationType()
                {
//                    Id =model.OperationType,
                    Description = model.OperationType.ToString()
                },
                Items = model.Items?.Select(el=>new Good()
                {
                    Barcode = el.Barcode,
                    Name = el.Name,
                    Nds0 = el.Nds0,
                    Nds10 = el.Nds10,
                    Nds18 = el.Nds18,
                    Price = el.Price,
                    Quantity = el.Quantity,
                    Sum = el.Sum,
                    NdsCalculated10 = el.NdsCalculated10,
                    NdsCalculated18 = el.NdsCalculated18,
                    NdsNo = el.NdsNo,
                    Modifiers = el.Modifiers?.Select(m=>new Modifier()
                        {
                            Discount = m.Discount,
                            DiscountName = m.DiscountName,
                            DiscountSum = m.DiscountSum,
                            MarkupName = m.MarkupName,
                            MarkupSum = m.MarkupSum
                        }).ToList(),
                    Properties = el.Properties?.Select(p=>new ReceiptProperty()
                        {
                            Key = p.Key,
                            Value = p.Value
                        }).ToList()
                }).ToList(),
                StornoItems =model.StornoItems?.Select(el=>new Good()
                {
                    Barcode = el.Barcode,
                    Name = el.Name,
                    Nds0 = el.Nds0,
                    Nds10 = el.Nds10,
                    Nds18 = el.Nds18,
                    Price = el.Price,
                    Quantity = el.Quantity,
                    Sum = el.Sum,
                    NdsCalculated10 = el.NdsCalculated10,
                    NdsCalculated18 = el.NdsCalculated18,
                    NdsNo = el.NdsNo,
                    Modifiers = el.Modifiers?.Select(m=>new Modifier()
                    {
                        Discount = m.Discount,
                        DiscountName = m.DiscountName,
                        DiscountSum = m.DiscountSum,
                        MarkupName = m.MarkupName,
                        MarkupSum = m.MarkupSum
                    }).ToList(),
                    Properties = el.Properties?.Select(p=>new ReceiptProperty()
                    {
                        Key = p.Key,
                        Value = p.Value
                    }).ToList()
                })?.ToList(), 
            };

            return receipt;
        }
    }
}