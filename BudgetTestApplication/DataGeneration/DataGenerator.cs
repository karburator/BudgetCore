using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetTestApplication.DataGeneration
{
    public class DataGenerator
    {
        public void CreateData()
        {
            var days = 30;
            var from = DateTime.Today.AddDays(-1*days);
            var to = DateTime.Today.AddDays(days);

            var receiptGenerator = new ReceiptGenerator();
            var goodGenerator = new GoodGenerator();
            var shopGenerator = new ShopGenerator();
            
            var receipts = new List<Receipt>();
            
            var context = new BudgetContext();
            
            for (DateTime currentDate = from; currentDate < to; currentDate = currentDate.AddDays(1))
            {
                var baseTime = DateTime.Today.TimeOfDay.Ticks;
                var receiptPerDay = RandomUtils.Number(1, 11);
                var deltaTime = TimeSpan.TicksPerDay / receiptPerDay;
                for (int i = 0; i < receiptPerDay; i++)
                {
                    var dayTicks = baseTime + i * deltaTime;
                    var date = currentDate.AddTicks(dayTicks);

                    var receipt = receiptGenerator.GetReceipt();
                    receipt.Date = date;
                    receipt.Items = Enumerable.Range(1, RandomUtils.Number(2,5))
                        .Select(el => goodGenerator.GetGood(context))
                        .ToList();
                    receipt.Shop = shopGenerator.GetShop(context);
                    receipt.TotalSum = receipt.Items.Sum(el => el.Sum);
                    receipt.Nds18 = receipt.Items.Sum(el => el.Nds18);
                    receipt.Nds10 = receipt.Items.Sum(el => el.Nds10);
                    receipt.Nds0 = receipt.Items.Sum(el => el.Nds0);
                    receipt.NdsCalculated18 = receipt.Items.Sum(el => el.NdsCalculated18);
                    receipt.NdsCalculated10 = receipt.Items.Sum(el => el.NdsCalculated10);
                    receipt.NdsNo = receipt.Items.Sum(el => el.NdsNo);

                    var totalQuantity = 100;
                    var splitter = new AmountSplitter(receipt.TotalSum, totalQuantity);
                    var cashPercents = RandomUtils.PositiveNumber(totalQuantity);
                    receipt.CashTotalSum = splitter.Get(cashPercents);
                    receipt.EcashTotalSum = splitter.Get(totalQuantity - cashPercents);
                    
                    receipts.Add(receipt);
                }   
            }
            
            
            
            // using (var context = new BudgetContext())
            // {
            //     context.Products.AsNoTracking();
            //     context.Shops.AsNoTracking();
            context.Receipts.AddRange(receipts);
            context.SaveChanges();
            // }
        }
    }
}