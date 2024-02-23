using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Products
{
    public enum ProductType
    {
        Stock,
        Service
    }

    public class Product : BaseEntity
    {
        private int id;
        private string name;
        private Category? category;
        private string type;
        private string barcode;
        private string? datex; // Nullable string for datex
        private string? datee; // Nullable string for datee
        private string _details;
        private string imagePath;
        private string? color; // Nullable string for color
        private double? width; // Nullable double for width
        private double? height; // Nullable double for height
        private double? length; // Nullable double for length
        private double? weight; // Nullable double for weight


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
        //public Product()
        //{
        //}

        //public Product(int id, Category category, string imagePath)
        //{
        //    this.id = id;
        //    this.category = category;
        //    this.imagePath = imagePath;
        //}

        //public Product(int id, string name, Category category, double quantity, double cost, double price, string type, string barcode, double earned, string datex, string datee, string imagePath)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.category = category;
        //    this.quantity = quantity;
        //    this.cost = cost;
        //    this.price = price;
        //    this.type = type;
        //    this.barcode = barcode;
        //    this.earned = earned;
        //    this.datex = datex;
        //    this.datee = datee;
        //    this.imagePath = imagePath;
        //}

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }



        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    NotifyPropertyChanged(nameof(Type));
                }
            }
        }

        public string Barcode
        {
            get => barcode;
            set
            {
                if (barcode != value)
                {
                    barcode = value;
                    NotifyPropertyChanged(nameof(Barcode));
                }
            }
        }
        public string? Datex // Nullable string for datex
        {
            get => datex;
            set
            {
                if (datex != value)
                {
                    datex = value;
                    NotifyPropertyChanged(nameof(Datex));
                }
            }
        }

        public string? Datee // Nullable string for datee
        {
            get => datee;
            set
            {
                if (datee != value)
                {
                    datee = value;
                    NotifyPropertyChanged(nameof(Datee));
                }
            }
        }

        public string Details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    NotifyPropertyChanged(nameof(Details));
                }
            }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    NotifyPropertyChanged(nameof(ImagePath));
                }
            }
        }

        public string? Color // Nullable string for color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    NotifyPropertyChanged(nameof(Color));
                }
            }
        }

        public double? Width // Nullable double for width
        {
            get => width;
            set
            {
                if (width != value)
                {
                    width = value;
                    NotifyPropertyChanged(nameof(Width));
                }
            }
        }

        public double? Height // Nullable double for height
        {
            get => height;
            set
            {
                if (height != value)
                {
                    height = value;
                    NotifyPropertyChanged(nameof(Height));
                }
            }
        }

        public double? Length // Nullable double for length
        {
            get => length;
            set
            {
                if (length != value)
                {
                    length = value;
                    NotifyPropertyChanged(nameof(Length));
                }
            }
        }

        public double? Weight // Nullable double for weight
        {
            get => weight;
            set
            {
                if (weight != value)
                {
                    weight = value;
                    NotifyPropertyChanged(nameof(Weight));
                }
            }
        }


        private int? categoryId;
        [ForeignKey(nameof(Category))]
        public int? CategoryId
        {
            get => categoryId;
            set
            {
                if (categoryId != value)
                {
                    categoryId = value;
                    NotifyPropertyChanged(nameof(CategoryId));
                }
            }
        }

        // Navigation property for the related category
        public virtual Category? Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    NotifyPropertyChanged(nameof(Category));
                }
            }
        }

        public ICollection<ReadyProductItem>? ReadyProducts { get; set; }

        public ICollection<SaleProduct>? SaleProducts { get; set; }


        // One-to-many relationship with PurchaseProduct
        public ICollection<PurchaseProduct>? PurchaseProducts { get; set; }

        public ProductType ProductType { get; set; }
        // Calculated quantity based on sales and purchases
        public double Quantity(int? warehouseId = null)
        {
            if (ProductType == ProductType.Service)
                return 0;

            // Filter purchase and sale quantities based on the warehouse if provided
            var purchaseQuantity = PurchaseProducts
                .Where(p => warehouseId == null || p.WarehouseId == warehouseId)
                .Sum(p => p.Quantity);

            var saleQuantity = SaleProducts
                .Where(s => warehouseId == null || s.WarehouseId == warehouseId)
                .Sum(s => s.Quantity);

            return purchaseQuantity - saleQuantity;
        }
        private double? _minSalePrice;
        public double? MinSalePrice
        {
            get => _minSalePrice;
            set
            {
                if (_minSalePrice != value)
                {
                    _minSalePrice = value;
                    NotifyPropertyChanged(nameof(MinSalePrice));
                }
            }
        }

        private double? _profitMargin;
        public double? ProfitMargin
        {
            get => _profitMargin;
            set
            {
                if (_profitMargin != value)
                {
                    _profitMargin = value;
                    NotifyPropertyChanged(nameof(ProfitMargin));
                }
            }
        }
        private double? _minStock;
        public double? MinStock
        {
            get => _minStock;
            set
            {
                if (_minStock != value)
                {
                    _minStock = value;
                    NotifyPropertyChanged(nameof(MinStock));
                }
            }
        }
        public double? GetLastPurchasePrice()
        {
            // Ensure PurchaseProducts is not null
            if (PurchaseProducts != null && PurchaseProducts.Any())
            {
                // Sort purchase products by purchase date descending
                var sortedPurchases = PurchaseProducts.OrderByDescending(p => p.Purchase?.Date);

                // Return the purchase price of the first purchase (latest date)
                return sortedPurchases.FirstOrDefault()?.PurchasePrice;
            }

            // If PurchaseProducts is null or empty, return null
            return 0;
        }


    }
}
