using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Products
{
    public class QuotedProduct : BaseEntity
    {
        public int Id { get; set; }

        private int? _productId;
        public int? ProductId
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
        [ForeignKey(nameof(ReadyProduct))]
        public int? ReadyProductId { get; set; }
        public ReadyProduct? ReadyProduct { get; set; }

        private Product? _product;
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product
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

        [ForeignKey(nameof(PriceQuotation))]
        public int? PriceQuotationId { get; set; }
        public PriceQuotation? PriceQuotation { get; set; }

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

        private double _salePrice;
        public double SalePrice
        {
            get => _salePrice;
            set
            {
                if (_salePrice != value)
                {
                    _salePrice = value;
                    NotifyPropertyChanged(nameof(SalePrice));
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
