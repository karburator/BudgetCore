using System;

namespace BudgetCoreApi.Model
{
    public class ReceiptModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalSum { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public string UserInn { get; set; }
        public decimal CashTotalSum { get; set; }
        public decimal EcashTotalSum { get; set; }
    }
}