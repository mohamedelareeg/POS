using Microsoft.Win32;
using POS.Domain.Models;
using POS.Persistence.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class AddCustomersDialogViewModel : INotifyPropertyChanged
    {

        private bool? _result;

        public bool? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _contactName;
        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                    OnPropertyChanged(nameof(ContactName));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

        private string _website;
        public string Website
        {
            get { return _website; }
            set
            {
                if (_website != value)
                {
                    _website = value;
                    OnPropertyChanged(nameof(Website));
                }
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        private string _commercialRegister;
        public string CommercialRegister
        {
            get { return _commercialRegister; }
            set
            {
                if (_commercialRegister != value)
                {
                    _commercialRegister = value;
                    OnPropertyChanged(nameof(CommercialRegister));
                }
            }
        }

        private string _taxCard;
        public string TaxCard
        {
            get { return _taxCard; }
            set
            {
                if (_taxCard != value)
                {
                    _taxCard = value;
                    OnPropertyChanged(nameof(TaxCard));
                }
            }
        }


        private ObservableCollection<Customer> _itemList;
        public ObservableCollection<Customer> ItemList
        {
            get { return _itemList; }
            set
            {
                if (_itemList != value)
                {
                    _itemList = value;
                    OnPropertyChanged(nameof(ItemList));
                }
            }
        }

        private Customer _selectedItem;
        public Customer SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));

                    if (_selectedItem != null)
                    {
                        CurrentState = DialogState.Modify;
                        ImageSource = SelectedItem.Image;
                        Name = SelectedItem.Name;
                        ContactName = SelectedItem.ContactName;
                        Email = SelectedItem.Email;
                        Phone = SelectedItem.Phone;
                        Address = SelectedItem.Address;
                        City = SelectedItem.City;
                        Country = SelectedItem.Country;
                        PostalCode = SelectedItem.PostalCode;
                        Website = SelectedItem.Website;
                        Notes = SelectedItem.Notes;
                        CommercialRegister = SelectedItem.CommercialRegister;
                        TaxCard = SelectedItem.TaxCard;
                        // Update the current state to Modify when an item is selected
                        CurrentState = DialogState.Modify;
                    }
                    else
                    {
                        // Clear the properties when no item is selected
                        Name = string.Empty;
                        ContactName = string.Empty;
                        Email = string.Empty;
                        Phone = string.Empty;
                        Address = string.Empty;
                        City = string.Empty;
                        Country = string.Empty;
                        PostalCode = string.Empty;
                        Website = string.Empty;
                        Notes = string.Empty;
                        CommercialRegister = string.Empty;
                        TaxCard = string.Empty;
                        ImageSource = null;
                        // Update the current state to Add when no item is selected
                        CurrentState = DialogState.Add;
                    }
                }
            }
        }



        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        // Commands
        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand SelectImageCommand { get; private set; }
        public ICommand EditItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }
        public ICommand FinishCommand { get; private set; }

        private AppDbContext _dbContext; // Add a reference to your DbContext

        public AddCustomersDialogViewModel()
        {
            // Initialize DbContext
            _dbContext = new AppDbContext();
            // Initialize commands
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            EditItemCommand = new RelayCommand(EditItem);
            SelectImageCommand = new RelayCommand(SelectImage);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            FinishCommand = new RelayCommand(Finish);

            // Initialize properties
            ItemList = new ObservableCollection<Customer>();
            LoadCustomers();
        }


        private void LoadCustomers()
        {
            // Retrieve customers from the DbContext
            var customers = _dbContext.Customers.ToList();

            // Populate the ItemList
            foreach (var customer in customers)
            {
                // Populate the properties from the database
                Name = customer.Name;
                ContactName = customer.ContactName;
                Email = customer.Email;
                Phone = customer.Phone;
                Address = customer.Address;
                City = customer.City;
                Country = customer.Country;
                PostalCode = customer.PostalCode;
                Website = customer.Website;
                Notes = customer.Notes;
                CommercialRegister = customer.CommercialRegister;
                TaxCard = customer.TaxCard;
                ItemList.Add(customer);
            }
        }
        // Command methods
        private void Add(object parameter)
        {
            CurrentState = DialogState.Add;

            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("يرجى توفير اسم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ItemList.Any(c => c.Name == Name))
            {
                MessageBox.Show("اسم موجود بالفعل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Customer newCustomer = new Customer
            {
                Name = Name,
                ContactName = ContactName,
                Email = Email,
                Phone = Phone,
                Address = Address,
                City = City,
                Country = Country,
                PostalCode = PostalCode,
                Website = Website,
                Notes = Notes,
                CommercialRegister = CommercialRegister,
                TaxCard = TaxCard,
                Image = SaveImage(ImageSource)
            };
            // Add the new Customer to the DbContext
            _dbContext.Customers.Add(newCustomer);

            // Save changes to the database
            _dbContext.SaveChanges();

            // Add the new Customer to the ObservableCollection
            ItemList.Add(newCustomer);

            // Clear the input fields
            Name = string.Empty;
            ContactName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            Website = string.Empty;
            Notes = string.Empty;
            CommercialRegister = string.Empty;
            TaxCard = string.Empty;
            ImageSource = null;
        }

        private void Edit(object parameter)
        {
            if (SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    MessageBox.Show("يرجى توفير اسم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (ItemList.Any(c => c.Name == Name && c != SelectedItem))
                {
                    MessageBox.Show("اسم موجود بالفعل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Find the selected Customer in the DbContext
                Customer CustomerToUpdate = _dbContext.Customers.Find(SelectedItem.Id);

                CustomerToUpdate.Name = Name;
                CustomerToUpdate.ContactName = ContactName;
                CustomerToUpdate.Email = Email;
                CustomerToUpdate.Phone = Phone;
                CustomerToUpdate.Address = Address;
                CustomerToUpdate.City = City;
                CustomerToUpdate.Country = Country;
                CustomerToUpdate.PostalCode = PostalCode;
                CustomerToUpdate.Website = Website;
                CustomerToUpdate.Notes = Notes;
                CustomerToUpdate.CommercialRegister = CommercialRegister;
                CustomerToUpdate.TaxCard = TaxCard;
                CustomerToUpdate.Image = SaveImage(ImageSource);

                // Save changes to the database
                _dbContext.SaveChanges();

                // Update the ObservableCollection
                SelectedItem.Name = Name;
                //SelectedItem.Image = ImageSource;
            }
        }

        private void DeleteItem(object parameter)
        {
            if (SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("هل أنت متأكد من رغبتك في الحذف ؟", "تأكيد الحذف", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    // Find the selected Customer in the DbContext
                    Customer CustomerToDelete = _dbContext.Customers.Find(SelectedItem.Id);

                    // Remove the Customer from the DbContext
                    _dbContext.Customers.Remove(CustomerToDelete);

                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Remove the Customer from the ObservableCollection
                    ItemList.Remove(SelectedItem);

                    // Clear the Name field
                    Name = string.Empty;
                }
            }
        }
        private void EditItem(object parameter)
        {
            if (SelectedItem != null)
            {
                CurrentState = DialogState.Modify;
                ImageSource = SelectedItem.Image;
                Name = SelectedItem.Name;
                ContactName = SelectedItem.ContactName;
                Email = SelectedItem.Email;
                Phone = SelectedItem.Phone;
                Address = SelectedItem.Address;
                City = SelectedItem.City;
                Country = SelectedItem.Country;
                PostalCode = SelectedItem.PostalCode;
                Website = SelectedItem.Website;
                Notes = SelectedItem.Notes;
                CommercialRegister = SelectedItem.CommercialRegister;
                TaxCard = SelectedItem.TaxCard;
            }
        }



        private bool CanAdd(object parameter)
        {
            // Ensure the Name field is not empty
            return !string.IsNullOrWhiteSpace(Name);
        }
        private void SelectImage(object parameter)
        {
            // Open a file dialog to select an image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected image file path
                string imagePath = openFileDialog.FileName;

                try
                {
                    // Set the ImageSource property with the selected image file path
                    ImageSource = imagePath;

                    // Check if a Customer is selected
                    if (SelectedItem != null)
                    {
                        // Update the image path of the selected Customer
                        SelectedItem.Image = imagePath;

                        // Set the current state to modify
                        CurrentState = DialogState.Modify;
                    }
                    else
                    {
                        // Set the current state to add
                        CurrentState = DialogState.Add;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during image loading
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public string SaveImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                // Return empty string
                return string.Empty;
            }

            string uniqueFileName = null;
            try
            {
                uniqueFileName = $"{Guid.NewGuid()}.jpeg";
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "Customers");
                string destinationImagePath = Path.Combine(directoryPath, uniqueFileName);

                // Create the directory if it does not exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var stream = File.OpenRead(imagePath))
                {
                    using (var image = Image.FromStream(stream))
                    {
                        // Convert the image to Bitmap
                        Bitmap bitmap = new Bitmap(image);

                        // Compress the image and save it to the specified path
                        bitmap.Save(destinationImagePath, ImageFormat.Jpeg);

                        // Return the unique filename
                        return destinationImagePath;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during image processing or saving
                Console.WriteLine($"Error: {ex.Message}");
                // Optionally, log the error

                // Return null indicating failure to save the image
                return null;
            }
        }





        private void Finish(object parameter)
        {
            Result = true;
            System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)?.Close();
        }

        public enum DialogState
        {
            Add,
            Modify
        }

        private DialogState _currentState;
        public DialogState CurrentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged(nameof(CurrentState));
                    OnPropertyChanged(nameof(AddButtonContent));
                }
            }
        }

        public string AddButtonContent
        {
            get
            {
                return CurrentState == DialogState.Add ? "إضافة" : "تعديل";
            }
        }

        // Helper method for property change notification
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
