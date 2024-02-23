using Microsoft.Win32;
using POS.Domain.Models;
using POS.Persistence.Context;
using POS.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace POS.Dialogs.ViewModels
{
    public class AddWarehousesDialogViewModel : INotifyPropertyChanged
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

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(nameof(Location));
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

        private ObservableCollection<Warehouse> _ItemList;
        public ObservableCollection<Warehouse> ItemList
        {
            get { return _ItemList; }
            set
            {
                if (_ItemList != value)
                {
                    _ItemList = value;
                    OnPropertyChanged(nameof(ItemList));
                }
            }
        }

        private Warehouse _SelectedItem;
        public Warehouse SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));

                    if (_SelectedItem != null)
                    {
                        ImageSource = SelectedItem.Image;
                        Name = SelectedItem.Name;
                        Location = SelectedItem.Location;
                        // Update the current state to Modify when an item is selected
                        CurrentState = DialogState.Modify;
                    }
                    else
                    {
                        // Clear the properties when no item is selected
                        ImageSource = string.Empty;
                        Name = string.Empty;
                        Location = string.Empty;
                        // Update the current state to Add when no item is selected
                        CurrentState = DialogState.Add;
                    }
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

        private AppDbContext _dbContext;

        public AddWarehousesDialogViewModel()
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
            ItemList = new ObservableCollection<Warehouse>();
            LoadWarehouses();
        }

        private void LoadWarehouses()
        {
            // Retrieve warehouses from the DbContext
            var warehouses = _dbContext.Warehouses.ToList();

            // Populate the ItemList
            foreach (var warehouse in warehouses)
            {
                ItemList.Add(warehouse);
            }
        }

        // Command methods
        private void Add(object parameter)
        {
            CurrentState = DialogState.Add;

            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("يرجى توفير اسم المستودع.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ItemList.Any(w => w.Name == Name))
            {
                MessageBox.Show("اسم المستودع موجود بالفعل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new warehouse instance
            Warehouse newWarehouse = new Warehouse
            {
                Name = Name,
                Location = Location,
                Image = SaveImage(ImageSource)
            };

            // Add the new warehouse to the DbContext
            _dbContext.Warehouses.Add(newWarehouse);

            // Save changes to the database
            _dbContext.SaveChanges();

            // Add the new warehouse to the ObservableCollection
            ItemList.Add(newWarehouse);

            // Clear the input fields
            Name = string.Empty;
            Location = string.Empty;
            ImageSource = null;
        }

        private void Edit(object parameter)
        {
            if (SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    MessageBox.Show("يرجى توفير اسم المستودع.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (ItemList.Any(w => w.Name == Name && w != SelectedItem))
                {
                    MessageBox.Show("اسم المستودع موجود بالفعل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Find the selected warehouse in the DbContext
                Warehouse warehouseToUpdate = _dbContext.Warehouses.Find(SelectedItem.Id);

                // Update the warehouse properties
                warehouseToUpdate.Name = Name;
                warehouseToUpdate.Location = Location;
                warehouseToUpdate.Image = SaveImage(ImageSource);

                // Save changes to the database
                _dbContext.SaveChanges();

                // Update the ObservableCollection
                SelectedItem.Name = Name;
                SelectedItem.Location = Location;
                //SelectedItem.Image = ImageSource;
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
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "Warhouses");
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


        private void DeleteItem(object parameter)
        {
            if (SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("هل أنت متأكد من رغبتك في الحذف ؟", "تأكيد الحذف", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    // Find the selected warehouse in the DbContext
                    Warehouse warehouseToDelete = _dbContext.Warehouses.Find(SelectedItem.Id);

                    // Remove the warehouse from the DbContext
                    _dbContext.Warehouses.Remove(warehouseToDelete);

                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Remove the warehouse from the ObservableCollection
                    ItemList.Remove(SelectedItem);

                    // Clear the input fields
                    Name = string.Empty;
                    Location = string.Empty;
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
                Location = SelectedItem.Location;
            }
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

                    // Check if a warehouse is selected
                    if (SelectedItem != null)
                    {
                        // Update the image path of the selected warehouse
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
