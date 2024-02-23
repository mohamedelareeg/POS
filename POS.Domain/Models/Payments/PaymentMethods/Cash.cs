using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Payments.PaymentMethods
{
    public class Cash : BaseEntity
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }
        private string _cashName;
        public string CashName
        {
            get => _cashName;
            set
            {
                if (_cashName != value)
                {
                    _cashName = value;
                    NotifyPropertyChanged(nameof(CashName));
                }
            }
        }
        private decimal _amount;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyPropertyChanged(nameof(Amount));
                }
            }
        }

        private TransactionType _type;
        public TransactionType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    NotifyPropertyChanged(nameof(Type));
                }
            }
        }
        private CurrencyType _currency = CurrencyType.EGP;
        public CurrencyType Currency
        {
            get => _currency;
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                    NotifyPropertyChanged(nameof(Currency));
                }
            }
        }
        public ICollection<InvoicePayment>? InvoicePayments { get; set; }
        public ICollection<PurchasePayment>? PurchasePayments { get; set; }


    }
    public enum TransactionType
    {
        Income,
        Outcome
    }

    public enum CurrencyType
    {
        USD, // دولار أمريكي
        EGP, // جنيه مصري
        SAR, // ريال سعودي
        AED, // درهم إماراتي
        JOD, // دينار أردني
        QAR, // ريال قطري
        KWD, // دينار كويتي
        OMR, // ريال عماني
        BHD, // دينار بحريني
        LBP, // ليرة لبنانية
        IQD, // دينار عراقي
        SYP, // ليرة سورية
        LYD, // دينار ليبي
        YER, // ريال يمني
        TND, // دينار تونسي
        DZD, // دينار جزائري
        MAD, // درهم مغربي
        SDG, // جنيه سوداني
        JPY, // ين ياباني
        EUR, // يورو
        GBP, // جنيه إسترليني
        CHF, // فرنك سويسري
        CAD, // دولار كندي
        AUD, // دولار أسترالي
        NZD, // دولار نيوزيلندي
        CNY, // يوان صيني
        INR, // روبية هندية
        PKR, // روبية باكستانية
        TRY, // ليرة تركية
        IRR, // ريال إيراني
        AFA, // أفغاني
        KZT, // تينغ كازاخستاني
        UZS, // سوم أوزبكي
        TJS, // سوموني طاجيكستاني
        KGS, // سوم قيرغستاني
        AFN, // أفغاني
        UAH, // هريفنيا أوكرانية
        BYN, // روبل بيلاروسي
        RUB, // روبل روسي
        AMD, // درام أرميني
        AZN, // مانات أذربيجاني
        GEL, // لاري جورجي
        MDL, // ليو مولدوفي
        TMT, // منات تركمنستان
    }

}
