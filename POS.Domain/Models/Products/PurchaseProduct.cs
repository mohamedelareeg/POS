using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Products
{
    public class PurchaseProduct : BaseEntity
    {
        public int Id { get; set; }

        private int _productId;
        public int ProductId
        {
            get => _productId;
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    NotifyPropertyChanged(nameof(ProductId));
                }
            }
        }

        private Product _product;
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product
        {
            get => _product;
            set
            {
                if (_product != value)
                {
                    _product = value;
                    NotifyPropertyChanged(nameof(Product));
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
        private int _purchaseId;
        public int PurchaseId
        {
            get => _purchaseId;
            set
            {
                if (_purchaseId != value)
                {
                    _purchaseId = value;
                    NotifyPropertyChanged(nameof(PurchaseId));
                }
            }
        }

        private Purchase _purchase;
        [ForeignKey(nameof(PurchaseId))]
        public virtual Purchase Purchase
        {
            get => _purchase;
            set
            {
                if (_purchase != value)
                {
                    _purchase = value;
                    NotifyPropertyChanged(nameof(Purchase));
                }
            }
        }

        private double _quantity;
        public double Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    NotifyPropertyChanged(nameof(Quantity));
                }
            }
        }

        private double _purchasePrice;
        public double PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                if (_purchasePrice != value)
                {
                    _purchasePrice = value;
                    NotifyPropertyChanged(nameof(PurchasePrice));
                }
            }
        }

        private string? _details;
        public string? Details
        {
            get => _details;
            set
            {
                if (_details != value)
                {
                    _details = value;
                    NotifyPropertyChanged(nameof(Details));
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

    }
}
