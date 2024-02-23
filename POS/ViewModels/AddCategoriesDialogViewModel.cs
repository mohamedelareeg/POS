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
    public class AddCategoriesDialogViewModel : INotifyPropertyChanged
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

        private ObservableCollection<Category> _itemList;
        public ObservableCollection<Category> ItemList
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

        private Category _selectedItem;
        public Category SelectedItem
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
                        ImageSource = SelectedItem.Image;
                        Name = SelectedItem.Name;
                        // Update the current state to Modify when an item is selected
                        CurrentState = DialogState.Modify;
                    }
                    else
                    {
                        // Clear the properties when no item is selected
                        ImageSource = string.Empty;
                        Name = string.Empty;
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

        public AddCategoriesDialogViewModel()
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
            ItemList = new ObservableCollection<Category>();
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Retrieve categories from the DbContext
            var categories = _dbContext.Categories.ToList();

            // Populate the ItemList
            foreach (var category in categories)
            {
                ItemList.Add(category);
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

            // Create a new category instance
            Category newCategory = new Category
            {
                Name = Name,
                Image = SaveImage(ImageSource)
            };

            // Add the new category to the DbContext
            _dbContext.Categories.Add(newCategory);

            // Save changes to the database
            _dbContext.SaveChanges();

            // Add the new category to the ObservableCollection
            ItemList.Add(newCategory);

            // Clear the input fields
            Name = string.Empty;
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

                // Find the selected category in the DbContext
                Category categoryToUpdate = _dbContext.Categories.Find(SelectedItem.Id);

                // Update the category properties
                categoryToUpdate.Name = Name;
                categoryToUpdate.Image = ImageSource;

                // Save changes to the database
                _dbContext.SaveChanges();

                // Update the ObservableCollection
                SelectedItem.Name = Name;
                SelectedItem.Image = SaveImage(ImageSource);
            }
        }

        private void DeleteItem(object parameter)
        {
            if (SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("هل أنت متأكد من رغبتك في الحذف ؟", "تأكيد الحذف", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    // Find the selected category in the DbContext
                    Category categoryToDelete = _dbContext.Categories.Find(SelectedItem.Id);

                    // Remove the category from the DbContext
                    _dbContext.Categories.Remove(categoryToDelete);

                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Remove the category from the ObservableCollection
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

                    // Check if a category is selected
                    if (SelectedItem != null)
                    {
                        // Update the image path of the selected category
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
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "categories");
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
