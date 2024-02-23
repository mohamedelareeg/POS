namespace POS.Domain.Models
{
    public class Customer : BaseEntity
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(nameof(Id)); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        private string? _contactName;
        public string? ContactName
        {
            get { return _contactName; }
            set { _contactName = value; NotifyPropertyChanged(nameof(ContactName)); }
        }

        private string? _email;
        public string? Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged(nameof(Email)); }
        }

        private string? _phone;
        public string? Phone
        {
            get { return _phone; }
            set { _phone = value; NotifyPropertyChanged(nameof(Phone)); }
        }

        private string? _address;
        public string? Address
        {
            get { return _address; }
            set { _address = value; NotifyPropertyChanged(nameof(Address)); }
        }

        private string? _city;
        public string? City
        {
            get { return _city; }
            set { _city = value; NotifyPropertyChanged(nameof(City)); }
        }

        private string? _country;
        public string? Country
        {
            get { return _country; }
            set { _country = value; NotifyPropertyChanged(nameof(Country)); }
        }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; NotifyPropertyChanged(nameof(CreatedAt)); }
        }

        private string? _postalCode;
        public string? PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; NotifyPropertyChanged(nameof(PostalCode)); }
        }

        private string? _website;
        public string? Website
        {
            get { return _website; }
            set { _website = value; NotifyPropertyChanged(nameof(Website)); }
        }

        private string? _notes;
        public string? Notes
        {
            get { return _notes; }
            set { _notes = value; NotifyPropertyChanged(nameof(Notes)); }
        }

        private string? _commercialRegister;
        public string? CommercialRegister
        {
            get { return _commercialRegister; }
            set { _commercialRegister = value; NotifyPropertyChanged(nameof(CommercialRegister)); }
        }

        private string? _taxCard;
        public string? TaxCard
        {
            get { return _taxCard; }
            set { _taxCard = value; NotifyPropertyChanged(nameof(TaxCard)); }
        }

        private string? _image; // Nullable byte array for Image
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

        private double _previousBalance;
        public double PreviousBalance
        {
            get => _previousBalance;
            set
            {
                if (_previousBalance != value)
                {
                    _previousBalance = value;
                    NotifyPropertyChanged(nameof(PreviousBalance));
                }
            }
        }

    }
}
