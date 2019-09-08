using System.Collections.Generic;

namespace BudgetCoreDAO
{
    public class Good
    {
        public Good()
        {
            Modifiers = new List<Modifier>();
            Properties = new List<ReceiptProperty>();
        }
        
        public int Id { get; set; }

        /// <summary>Наименование товара.</summary>
        public string Name { get; set; }
        /// <summary>Штриховой код EAN13,</summary>
        public string Barcode { get; set; }
        /// <summary>Цена за единицу.</summary>
        public int Price { get; set; }
        /// <summary>Количество.</summary>
        public decimal Quantity { get; set; }
        /// <summary>Скидка/надбавка.</summary>
        public List<Modifier> Modifiers { get; set; }
        /// <summary>НДС итога чека со ставкой 18%, в копейках.</summary>
        public int Nds18 { get; set; }
        /// <summary>НДС итога чека со ставкой 10%, в копейках.</summary>
        public int Nds10 { get; set; }
        /// <summary>НДС итога чека со ставкой 0%, в копейках.</summary>
        public int Nds0 { get; set; }
        /// <summary>НДС не облагается.</summary>
        public int NdsNo { get; set; }
        /// <summary>НДС итога чека с рассчитанной ставкой 18%, в копейках.</summary>
        public int NdsCalculated18 { get; set; }
        /// <summary>НДС итога чека с рассчитанной ставкой 10%, в копейках.</summary>
        public int NdsCalculated10 { get; set; }
        /// <summary>Общая стоимость позиции с учетом скидок и наценок.</summary>
        public int Sum { get; set; }
        /// <summary>Дополнительный реквизит.</summary>
        public List<ReceiptProperty> Properties { get; set; }
    }
}