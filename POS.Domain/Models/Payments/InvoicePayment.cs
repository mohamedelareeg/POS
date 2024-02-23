using POS.Domain.Models.Payments.PaymentMethods;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Payments
{
    public class InvoicePayment : BaseEntity
    {
        public int Id { get; set; }

        private int _invoiceId;
        [Required]
        public int InvoiceId
        {
            get => _invoiceId;
            set
            {
                if (_invoiceId != value)
                {
                    _invoiceId = value;
                    NotifyPropertyChanged(nameof(InvoiceId));
                }
            }
        }

        private Invoice _invoice;
        [ForeignKey(nameof(InvoiceId))]
        public Invoice Invoice
        {
            get => _invoice;
            set
            {
                if (_invoice != value)
                {
                    _invoice = value;
                    NotifyPropertyChanged(nameof(Invoice));
                }
            }
        }

        private decimal _amount;
        [Required]
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

        private DateTime _date;
        [Required]
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
            }
        }

        private PaymentType _paymentType;
        [Required]
        public PaymentType PaymentType
        {
            get => _paymentType;
            set
            {
                if (_paymentType != value)
                {
                    _paymentType = value;
                    NotifyPropertyChanged(nameof(PaymentType));
                }
            }
        }
        private int? _cashId;
        public int? CashId
        {
            get => _cashId;
            set
            {
                if (_cashId != value)
                {
                    _cashId = value;
                    NotifyPropertyChanged(nameof(CashId));
                }
            }
        }

        private Cash? _cash;
        public Cash Cash
        {
            get => _cash;
            set
            {
                if (_cash != value)
                {
                    _cash = value;
                    NotifyPropertyChanged(nameof(Cash));
                }
            }
        }

        private int? _bankId;
        public int? BankId
        {
            get => _bankId;
            set
            {
                if (_bankId != value)
                {
                    _bankId = value;
                    NotifyPropertyChanged(nameof(BankId));
                }
            }
        }

        private Bank? _bank;
        public Bank Bank
        {
            get => _bank;
            set
            {
                if (_bank != value)
                {
                    _bank = value;
                    NotifyPropertyChanged(nameof(Bank));
                }
            }
        }

        private int? _chequeId;
        public int? ChequeId
        {
            get => _chequeId;
            set
            {
                if (_chequeId != value)
                {
                    _chequeId = value;
                    NotifyPropertyChanged(nameof(ChequeId));
                }
            }
        }

        private Cheque? _cheque;
        public Cheque Cheque
        {
            get => _cheque;
            set
            {
                if (_cheque != value)
                {
                    _cheque = value;
                    NotifyPropertyChanged(nameof(Cheque));
                }
            }
        }

        private int? _creditCardId;
        public int? CreditCardId
        {
            get => _creditCardId;
            set
            {
                if (_creditCardId != value)
                {
                    _creditCardId = value;
                    NotifyPropertyChanged(nameof(CreditCardId));
                }
            }
        }

        private CreditCard? _creditCard;
        public CreditCard CreditCard
        {
            get => _creditCard;
            set
            {
                if (_creditCard != value)
                {
                    _creditCard = value;
                    NotifyPropertyChanged(nameof(CreditCard));
                }
            }
        }

    }

    public enum PaymentType
    {
        Cash,
        CreditCard,
        BankTransfer,
        Cheque,
        Other,
        OnAccount
    }
}
