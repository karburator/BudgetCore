using System;
using System.Collections.Generic;

namespace BudgetCoreDAO.Interfaces
{
    public interface IReceipt
    {
        int Id { get; set; }

        /// <summary>Наименование пользователя.</summary>
        string User { get; set; }
        /// <summary>ИНН пользователя.</summary>
        string UserInn { get; set; }
        /// <summary>Номер чека за смену.</summary>
        int RequestNumber { get; set; }
        /// <summary>Дата, время.</summary>
        DateTime Date { get; set; }
        /// <summary>Номер смены.</summary>
        int ShiftNumber { get; set; }
        /// <summary>Признак расчета.</summary>
        OperationType OperationType { get; set; }
        /// <summary>Применяемая система налогообложения.</summary>
        int TaxationType { get; set; }
        /// <summary>Кассир.</summary>
        string Operator { get; set; }
        /// <summary>Регистрационный номер ККТ.</summary>
        string KktRegId { get; set; }
        /// <summary>Заводской номер фискального накопителя.</summary>
        string FiscalDriveNumber { get; set; }
        /// <summary>Адрес (место) расчетов.</summary>
        string RetailPlaceAddress { get; set; }

        /// <summary>Наименование товара (реквизиты).</summary>
        List<Good> Items { get; set; }
        /// <summary>Сторно товара (реквизиты).</summary>
        List<Good> StornoItems { get; set; }
        /// <summary>Скидка/наценка.</summary>
        List<Modifier> Modifiers { get; set; }
        /// <summary>НДС итога чека со ставкой 18%, в копейках.</summary>
        decimal Nds18 { get; set; }
        /// <summary>НДС итога чека со ставкой 10%, в копейках.</summary>
        decimal Nds10 { get; set; }
        /// <summary>НДС итога чека со ставкой 0%, в копейках.</summary>
        decimal Nds0 { get; set; }
        /// <summary>НДС не облагается.</summary>
        decimal NdsNo { get; set; }
        /// <summary>НДС итога чека с рассчитанной ставкой 18%, в копейках.</summary>
        decimal NdsCalculated18 { get; set; }
        /// <summary>НДС итога чека с рассчитанной ставкой 10%, в копейках.</summary>
        decimal NdsCalculated10 { get; set; }
        /// <summary>ИТОГ, в копейках.</summary>
        decimal TotalSum { get; set; }
        /// <summary>Сумма уплаченная наличными, в копейках.</summary>
        decimal CashTotalSum { get; set; }
        /// <summary>Сумма уплаченная электронными средствами платежа, в копейках.</summary>
        decimal EcashTotalSum { get; set; }
        /// <summary>Порядковый номер фискального документа.</summary>
        int FiscalDocumentNumber { get; set; }
        /// <summary>Фискальный номер документа.</summary>
        int FiscalSign { get; set; }

        #region Этих парней нет в примерах
        ///// <summary>Адрес покупателя.</summary>
        //string BuyerAddress { get; set; }
        ///// <summary>Адрес отправителя.</summary>
        //string SenderAddress { get; set; }
        ///// <summary>Адрес сайта для проверки ФП.</summary>
        //string AddressToCheckFiscalSign { get; set; }
        ///// <summary>Размер вознаграждения платежного агента (субагента), в копейках.</summary>
        //decimal paymentAgentRemuneration { get; set; }
        ///// <summary>Телефон платежного агента.</summary>
        //string PaymentAgentPhone { get; set; }
        ///// <summary>Телефон платежного субагента.</summary>
        //string AymentSubagentPhone { get; set; }
        ///// <summary>Телефон оператора по приему платежей.</summary>
        //string OperatorPhoneToReceive { get; set; }
        ///// <summary>Телефон оператора по переводу денежных средств.</summary>
        //string OperatorPhoneToTransfer { get; set; }
        ///// <summary>Телефон банковского агента.</summary>
        //string BankAgentPhone { get; set; }
        ///// <summary>Телефон банковского субагента.</summary>
        //string BankSubagentPhone { get; set; }
        ///// <summary>Операция банковского агента.</summary>
        //string BankAgentOperation { get; set; }
        ///// <summary>Операция банковского субагента.</summary>
        //string BankSubagentOperation { get; set; }
        ///// <summary>Размер вознаграждения банковского агента (субагента).</summary>
        //decimal BankAgentRemuneration { get; set; }
        ///// <summary>Наименование оператора по переводу денежных средств.</summary>
        //string OperatorName { get; set; }
        ///// <summary>Адрес оператора по переводу денежных средств.</summary>
        //string OperatorAddress { get; set; }
        ///// <summary>ИНН оператора по переводу денежных средств.</summary>
        //string OperatorInn { get; set; }
        ///// <summary>Дополнительный реквизит.</summary>
        //List<RecieptProperty> Properties { get; set; }
        ///// <summary>Бинарное представление документа в формате протокола ККТ с ФП2.</summary>
        //string RawData { get; set; }
        ///// <summary>Код документа "Кассовый чек" (всегда равен 3).</summary>
        //int ReceiptCode { get; set; }
        ///// <summary>код Документа "БСО" (всегда равен 4).</summary>
        //int BsoCode { get; set; }
        #endregion
    }
}
