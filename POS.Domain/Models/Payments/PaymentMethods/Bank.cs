using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Payments.PaymentMethods
{
    public class Bank : BaseEntity
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
        private string? _bankName;
        public string? BankName
        {
            get => _bankName;
            set
            {
                if (_bankName != value)
                {
                    _bankName = value;
                    NotifyPropertyChanged(nameof(BankName));
                }
            }
        }

        private string? _personName;
        public string? PersonName
        {
            get => _personName;
            set
            {
                if (_personName != value)
                {
                    _personName = value;
                    NotifyPropertyChanged(nameof(PersonName));
                }
            }
        }
        private string? _accountNumber;
        public string? AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (_accountNumber != value)
                {
                    _accountNumber = value;
                    NotifyPropertyChanged(nameof(AccountNumber));
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

}
