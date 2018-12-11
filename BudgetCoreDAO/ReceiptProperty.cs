namespace BudgetCoreDAO
{
    public class ReceiptProperty
    {
        public int Id { get; set; }

        /// <summary>Наименование дополнительного реквизита.</summary>
        public string Key { get; set; }
        /// <summary>Значение дополнительного реквизита.</summary>
        public string Value { get; set; }
    }
}