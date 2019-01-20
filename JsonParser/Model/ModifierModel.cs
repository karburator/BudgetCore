﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetFIleListner.Parse.Json
{
    public class ModifierModel
    {
        /// <summary>Наименование скидки.</summary>
        public string DiscountName { get; set; }
        /// <summary>Наименование наценки.</summary>
        public string MarkupName { get; set; }
        /// <summary>Скидка (ставка).</summary>
        public decimal Discount { get; set; }
        /// <summary>Наценка (ставка).</summary>
        public decimal Markup { get; set; }
        /// <summary>Скидка (сумма), в копейках.</summary>
        public decimal DiscountSum { get; set; }
        /// <summary>yНаценка (сумма), в копейках.</summary>
        public decimal MarkupSum { get; set; }
    }
}
