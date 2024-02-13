using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models
{
    public class Product : BaseEntity
    {
        private int id;
        private string name;
        private Category category;
        private double quantity;
        private double cost;
        private double price;
        private string type;
        private string barcode;
        private double earned;
        private string? datex; // Nullable string for datex
        private string? datee; // Nullable string for datee
        private string _details;
        private string imagePath;
        private string? color; // Nullable string for color
        private double? width; // Nullable double for width
        private double? height; // Nullable double for height
        private double? length; // Nullable double for length
        private double? weight; // Nullable double for weight

        public Product()
        {
        }

        public Product(int id, Category category, string imagePath)
        {
            this.id = id;
            this.category = category;
            this.imagePath = imagePath;
        }

        public Product(int id, string name, Category category, double quantity, double cost, double price, string type, string barcode, double earned, string datex, string datee, string imagePath)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.quantity = quantity;
            this.cost = cost;
            this.price = price;
            this.type = type;
            this.barcode = barcode;
            this.earned = earned;
            this.datex = datex;
            this.datee = datee;
            this.imagePath = imagePath;
        }

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

        public double Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    NotifyPropertyChanged(nameof(Quantity));
                    NotifyPropertyChanged(nameof(PriceBrush));
                }
            }
        }

        public double Cost
        {
            get => cost;
            set
            {
                if (cost != value)
                {
                    cost = value;
                    NotifyPropertyChanged(nameof(Cost));
                }
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    NotifyPropertyChanged(nameof(Price));
                    NotifyPropertyChanged(nameof(PriceBrush));
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

        public double Earned
        {
            get => earned;
            set
            {
                if (earned != value)
                {
                    earned = value;
                    NotifyPropertyChanged(nameof(Earned));
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

        public string PriceBrush
        {
            get
            {
                if (Quantity == 0)
                {
                    return "Red";
                }
                else
                {
                    return "Blue";
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


        private int categoryId;
        [ForeignKey(nameof(Category))]
        public int CategoryId
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
        public virtual Category Category
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


    }
}
