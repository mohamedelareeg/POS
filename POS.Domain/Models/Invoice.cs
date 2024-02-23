using POS.Domain.Models.Payments;
using POS.Domain.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models
{
    public class Invoice : BaseEntity
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

        private ICollection<SaleProduct>? _saleProducts;
        public ICollection<SaleProduct>? SaleProducts
        {
            get => _saleProducts;
            set
            {
                if (_saleProducts != value)
                {
                    _saleProducts = value;
                    NotifyPropertyChanged(nameof(SaleProducts));
                }
            }
        }

        private ICollection<InvoicePayment>? _invoicePayments;
        public ICollection<InvoicePayment>? InvoicePayments
        {
            get => _invoicePayments;
            set
            {
                if (_invoicePayments != value)
                {
                    _invoicePayments = value;
                    NotifyPropertyChanged(nameof(InvoicePayments));
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

        private int? _warehouseId;
        public int? WarehouseId
        {
            get => _warehouseId;
            set
            {
                if (_warehouseId != value)
                {
                    _warehouseId = value;
                    NotifyPropertyChanged(nameof(WarehouseId));
                }
            }
        }

        private Warehouse? _warehouse;
        public Warehouse? Warehouse
        {
            get => _warehouse;
            set
            {
                if (_warehouse != value)
                {
                    _warehouse = value;
                    NotifyPropertyChanged(nameof(Warehouse));
                }
            }
        }

        private int? _areaId;
        public int? AreaId
        {
            get => _areaId;
            set
            {
                if (_areaId != value)
                {
                    _areaId = value;
                    NotifyPropertyChanged(nameof(AreaId));
                }
            }
        }

        private Area? _area;
        public Area? Area
        {
            get => _area;
            set
            {
                if (_area != value)
                {
                    _area = value;
                    NotifyPropertyChanged(nameof(Area));
                }
            }
        }

        private InvoiceType _type = InvoiceType.Valid;
        public InvoiceType Type
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
        // New property for shipping cost
        private decimal? _shippingCost;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ShippingCost
        {
            get => _shippingCost;
            set
            {
                if (_shippingCost != value)
                {
                    _shippingCost = value;
                    NotifyPropertyChanged(nameof(ShippingCost));
                }
            }
        }

        // Foreign key for Shipping
        private int? _shippingId;
        public int? ShippingId
        {
            get => _shippingId;
            set
            {
                if (_shippingId != value)
                {
                    _shippingId = value;
                    NotifyPropertyChanged(nameof(ShippingId));
                }
            }
        }

        // Navigation property for Shipping
        private Shipping? _shipping;
        public Shipping? Shipping
        {
            get => _shipping;
            set
            {
                if (_shipping != value)
                {
                    _shipping = value;
                    NotifyPropertyChanged(nameof(Shipping));
                }
            }
        }


    }
    public enum InvoiceType
    {
        Valid, // صالحة
        Cancelled, // ملغية
        Suspended // معلقة
    }
}
