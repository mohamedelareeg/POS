using POS.Domain.Models.Payments;
using POS.Domain.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models
{
    public class Purchase : BaseEntity
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

        public ICollection<PurchaseProduct>? PurchaseProducts { get; set; }
        public ICollection<PurchasePayment>? PurchasePayments { get; set; }

        private int? _supplierId;
        public int? SupplierId
        {
            get => _supplierId;
            set
            {
                if (_supplierId != value)
                {
                    _supplierId = value;
                    NotifyPropertyChanged(nameof(SupplierId));
                }
            }
        }

        private Supplier? _supplier;
        public Supplier? Supplier
        {
            get => _supplier;
            set
            {
                if (_supplier != value)
                {
                    _supplier = value;
                    NotifyPropertyChanged(nameof(Supplier));
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
}
