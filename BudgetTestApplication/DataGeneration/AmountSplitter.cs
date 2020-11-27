using System;

namespace BudgetTestApplication.DataGeneration
{
    public class AmountSplitter
    {
        public AmountSplitter(int totalAmount, int totalQuantity)
        {
            TotalAmount = totalAmount;
            LeftAmount = totalAmount;
            TotalQuantity = totalQuantity;
            LeftQuantity = totalQuantity;
        }

        public int Get(int quantity)
        {
            if (quantity > LeftQuantity)
            {
                throw new ArgumentException($"Can't split amount for [{quantity}], left is [{LeftQuantity}].");
            }

            if (quantity < 0)
            {
                throw new InvalidOperationException($"Left amount is less or equals 0.");
            }
            
            if (quantity == LeftQuantity)
            {
                return LeftAmount;
            }

            var result = TotalAmount / TotalQuantity * quantity;
            LeftAmount -= result;
            LeftQuantity -= quantity;

            return result;
        }

        public int TotalQuantity { get; }
        public int TotalAmount { get; }
        public int LeftAmount { get; private set; }
        public int LeftQuantity { get; private set; }
    }
}