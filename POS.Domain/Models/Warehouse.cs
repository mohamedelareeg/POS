namespace POS.Domain.Models
{
    public class Warehouse : BaseEntity
    {
        private int _id;
        private string _name;
        private string? _location; // Nullable location
        private string? _image; // Nullable byte array for Image

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string? Location // Nullable location
        {
            get => _location;
            set
            {
                _location = value;
                NotifyPropertyChanged(nameof(Location));
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

        // Navigation property for list of purchases associated with this warehouse
        public ICollection<Purchase> Purchases { get; set; }

        // Navigation property for list of invoices associated with this warehouse
        public ICollection<Invoice> Invoices { get; set; }
    }
}
