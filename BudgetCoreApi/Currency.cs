namespace BudgetCoreApi
{
    public class Currency
    {
        public static decimal AmountToRub(int copeck)
        {
            return copeck / 100m;
        }
    }
}