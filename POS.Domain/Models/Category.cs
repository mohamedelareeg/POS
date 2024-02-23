using POS.Domain.Models.Products;

namespace POS.Domain.Models
{
    public class Category : BaseEntity
    {
        private int _id;
        private string _name;
        private string? _type; // Nullable string for Type
        private string? _image; // Nullable byte array for Image
        private ICollection<Product> _products;

        public Category()
        {
            _products = new List<Product>();
        }

        public Category(int id, string name, string? type)
        {
            Id = id;
            Name = name;
            Type = type;
            _products = new List<Product>();
        }

        public Category(int id, string name, string? type, string? image)
        {
            Id = id;
            Name = name;
            Type = type;
            Image = image;
            _products = new List<Product>();
        }

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

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public string? Type // Nullable string for Type
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

        public string? Image // Nullable byte array for Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    NotifyPropertyChanged(nameof(Image));
                }
            }
        }

        // Define the collection navigation property for products
        public virtual ICollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyPropertyChanged(nameof(Products));
            }
        }

    }
}
