using POS.Domain.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models
{
    public class PriceQuotation : BaseEntity
    {
        public int Id { get; set; }

        private string _number;
        [Required]
        public string Number
        {
            get => _number;
            set
            {
                if (_number != value)
                {
                    _number = value;
                    NotifyPropertyChanged(nameof(Number));
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

        private DateTime? _dueDate;
        public DateTime? DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    NotifyPropertyChanged(nameof(DueDate));
                }
            }
        }
        private decimal? _tax;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Tax
        {
            get => _tax;
            set
            {
                if (_tax != value)
                {
                    _tax = value;
                    NotifyPropertyChanged(nameof(Tax));
                }
            }
        }

        private decimal? _discount;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount
        {
            get => _discount;
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    NotifyPropertyChanged(nameof(Discount));
                }
            }
        }

        private decimal _totalPrice;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    NotifyPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private decimal _subtotal;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal
        {
            get => _subtotal;
            set
            {
                if (_subtotal != value)
                {
                    _subtotal = value;
                    NotifyPropertyChanged(nameof(Subtotal));
                }
            }
        }

        private int? _customerId;
        public int? CustomerId
        {
            get => _customerId;
            set
            {
                if (_customerId != value)
                {
                    _customerId = value;
                    NotifyPropertyChanged(nameof(CustomerId));
                }
            }
        }

        private Customer? _customer;
        public Customer? Customer
        {
            get => _customer;
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    NotifyPropertyChanged(nameof(Customer));
                }
            }
        }

        private ICollection<QuotedProduct>? _quotedProducts;
        public ICollection<QuotedProduct>? QuotedProducts
        {
            get => _quotedProducts;
            set
            {
                if (_quotedProducts != value)
                {
                    _quotedProducts = value;
                    NotifyPropertyChanged(nameof(QuotedProducts));
                }
            }
        }


    }
}
