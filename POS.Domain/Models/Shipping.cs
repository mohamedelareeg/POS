namespace POS.Domain.Models
{
    public enum ShippingType
    {
        Standard,
        Express,
        NextDay,
        SameDay,
        // Add more shipping types as needed
    }
    public class Shipping : BaseEntity
    {
        private int _id;
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

        private ShippingType _type;
        public ShippingType Type
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

        private string? _driverDetails;
        public string? DriverDetails
        {
            get => _driverDetails;
            set
            {
                if (_driverDetails != value)
                {
                    _driverDetails = value;
                    NotifyPropertyChanged(nameof(DriverDetails));
                }
            }
        }

        // Navigation property for Invoice
        public ICollection<Invoice> Invoices { get; set; }
    }
}
