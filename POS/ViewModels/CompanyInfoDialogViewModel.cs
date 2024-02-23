using Microsoft.Win32;
using POS.Domain.Models;
using POS.Persistence.Context;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class CompanyInfoDialogViewModel : INotifyPropertyChanged
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


        public ICommand EditCommand { get; private set; }
        public ICommand SelectImageCommand { get; private set; }
        public ICommand FinishCommand { get; private set; }

        private AppDbContext _dbContext; // Add a reference to your DbContext

        public CompanyInfoDialogViewModel()
        {
            // Initialize DbContext
            _dbContext = new AppDbContext();

            EditCommand = new RelayCommand(Edit);
            SelectImageCommand = new RelayCommand(SelectImage);
            FinishCommand = new RelayCommand(Finish);


            LoadCompanyInfo();
        }


        private void LoadCompanyInfo()
        {
            // Assuming _dbContext is your DbContext instance and CompanyInfo is your DbSet for company information

            // Fetch the first company info item from the database
            var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();

            if (companyInfo != null)
            {
                // Map the properties from the fetched company info item
                Name = companyInfo.Name;
                ContactName = companyInfo.ContactName;
                Email = companyInfo.Email;
                Phone = companyInfo.Phone;
                Address = companyInfo.Address;
                City = companyInfo.City;
                Country = companyInfo.Country;
                PostalCode = companyInfo.PostalCode;
                Website = companyInfo.Website;
                Notes = companyInfo.Notes;
                CommercialRegister = companyInfo.CommercialRegister;
                TaxCard = companyInfo.TaxCard;
                ImageSource = companyInfo.Image;
            }

        }

        private void Edit(object parameter)
        {
            // التأكد من وجود معلومات الشركة لتحريرها
            if (!string.IsNullOrWhiteSpace(Name))
            {
                // جلب معلومات الشركة الموجودة من قاعدة البيانات
                var existingCompanyInfo = _dbContext.CompanyInfo.FirstOrDefault();

                if (existingCompanyInfo != null)
                {
                    // تحديث خصائص معلومات الشركة الموجودة بالقيم الجديدة
                    existingCompanyInfo.Name = Name;
                    existingCompanyInfo.ContactName = ContactName;
                    existingCompanyInfo.Email = Email;
                    existingCompanyInfo.Phone = Phone;
                    existingCompanyInfo.Address = Address;
                    existingCompanyInfo.City = City;
                    existingCompanyInfo.Country = Country;
                    existingCompanyInfo.PostalCode = PostalCode;
                    existingCompanyInfo.Website = Website;
                    existingCompanyInfo.Notes = Notes;
                    existingCompanyInfo.CommercialRegister = CommercialRegister;
                    existingCompanyInfo.TaxCard = TaxCard;
                    existingCompanyInfo.Image = SaveImage(ImageSource);
                }
                else
                {
                    // إنشاء معلومات الشركة إذا لم تكن موجودة
                    var newCompanyInfo = new CompanyInfo
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

                    // إضافة معلومات الشركة الجديدة إلى قاعدة البيانات
                    _dbContext.CompanyInfo.Add(newCompanyInfo);
                }

                // حفظ التغييرات في قاعدة البيانات
                _dbContext.SaveChanges();

                // اختياري: يمكنك تحديث خصائص أخرى مثل ImageSource هنا

                // إخطار المستخدم بنجاح تحديث معلومات الشركة
                MessageBox.Show("تم تحديث معلومات الشركة بنجاح.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // التعامل مع حالة عدم توفر اسم الشركة
                MessageBox.Show("يرجى تقديم اسم الشركة.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
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
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "CompanyInfo");
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
