using System.Linq;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using BudgetFIleListner.Parse.Json;

namespace BudgetTestApplication
{
    public class ReceiptWtapper
    {
        public static Receipt Create(ReceiptModel model, BudgetContext context)
        {
            var receipt = new Receipt()
            {
                Date = model.DateTime,
                Nds0 = model.Nds0,
                Nds10 = model.Nds10,
                Nds18 = model.Nds18,
                Operator = model.Operator,
                Shop = GetShop(model.UserInn, model.User, context),
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
                OperationType = GetOperationType(model.OperationType.ToString(), context),
                Items = model.Items?.Select(el=>new Good()
                {
                    Barcode = el.Barcode,
                    Product = GetProduct(el.Name, context),
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
                    Product = GetProduct(el.Name, context),
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

        private static Product GetProduct(string name, BudgetContext context)
        {
            var product = context.Products.FirstOrDefault(el => el.Name == name)
                ?? context.Products.Local.FirstOrDefault(el => el.Name == name);
            if (product == null)
            {
                var newProduct = new Product() {Name = name};
                var entityEntry = context.Products.Attach(newProduct);
                product = entityEntry.Entity;
            }

            return product;
        }
        
        private static Shop GetShop(string userInn, string user, BudgetContext context)
        {
            var shop = context.Shops.FirstOrDefault(el => el.UserInn == userInn)
                          ?? context.Shops.Local.FirstOrDefault(el => el.UserInn == userInn);
            if (shop == null)
            {
                var newShop = new Shop()
                {
                    UserInn = userInn,
                    User = user
                };
                var entityEntry = context.Shops.Attach(newShop);
                shop = entityEntry.Entity;
            }

            return shop;
        }

        private static OperationType GetOperationType(string description, BudgetContext context)
        {
            var operationType = context.OperationTypes.FirstOrDefault(el => el.Description == description)
                       ?? context.OperationTypes.Local.FirstOrDefault(el => el.Description == description);
            if (operationType == null)
            {
                var newOperationType = new OperationType()
                {
                    Description = description
                };
                var entityEntry = context.OperationTypes.Attach(newOperationType);
                operationType = entityEntry.Entity;
            }

            return operationType;
        }
    }
}