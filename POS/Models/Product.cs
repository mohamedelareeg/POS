using System.ComponentModel;

namespace POS.Models
{
    public class Product : INotifyPropertyChanged
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
        private string datex;
        private string datee;
        private string _details;
        private string imagePath;

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

        public string Datex
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

        public string Datee
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

        public Category Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    NotifyPropertyChanged(nameof(Category));
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
