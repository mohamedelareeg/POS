using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using POS.Dialogs;
using POS.Domain.Models;
using POS.Persistence.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        private bool _isItemSelected;

        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set
            {
                if (_isItemSelected != value)
                {

                    _isItemSelected = value;
                    OnPropertyChanged(nameof(IsItemSelected));

                }
            }
        }
        #region Warhouses
        private ObservableCollection<Warehouse> _warehouses;
        private Warehouse _selectedWarehouse;
        private bool _isManageWarehouseCommandEnabled;

        public ObservableCollection<Warehouse> Warehouses
        {
            get => _warehouses;
            set
            {
                _warehouses = value;
                OnPropertyChanged(nameof(Warehouses));
            }
        }

        public Warehouse SelectedWarehouse
        {
            get => _selectedWarehouse;
            set
            {
                _selectedWarehouse = value;
                OnPropertyChanged(nameof(SelectedWarehouse));
            }
        }

        public bool IsManageWarehouseCommandEnabled
        {
            get => _isManageWarehouseCommandEnabled;
            set
            {
                _isManageWarehouseCommandEnabled = value;
                OnPropertyChanged(nameof(IsManageWarehouseCommandEnabled));
            }
        }
        public ICommand ManageWarehouseCommand { get; }

        private void ManageWarehouse(object obj)
        {
            // Create and show the payment dialog
            AddWarhousesDialog dialog = new AddWarhousesDialog();
            //dialog.viewModel.Total = 100.ToString();
            //dialog.viewModel.TotalQuantity = 100.ToString();
            // Show the dialog as a modal window
            bool? result = dialog.ShowDialog();

            // Check the result of the dialog
            if (result.HasValue)
            {
                // Payment dialog was closed, handle the result
                if (dialog.viewModel.Result == true)
                {
                    //// Payment was confirmed
                    //MessageBox.Show("تم بنجاح ", " تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    //// Payment was canceled
                    //MessageBox.Show("تم إلغاء ", " تم إلغاء", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void LoadWarehouses()
        {
            // Load warehouses from data source or initialize them
        }
        #endregion
        #region Product Variables 

        private ObservableCollection<Product> _productsList;
        public ObservableCollection<Product> ProductsList
        {
            get { return _productsList; }
            set
            {
                _productsList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

                UpdateUIWithSelectedProduct(_selectedProduct);

                if (_selectedProduct != null)
                {
                    SaveAndEditVisibility = Visibility.Visible;
                    EditVisibility = Visibility.Visible;
                    DeleteVisibility = Visibility.Visible;
                    // AddVisibility = Visibility.Collapsed;
                    SaveAndAddVisibility = Visibility.Collapsed;
                }
                else
                {
                    SaveAndEditVisibility = Visibility.Collapsed;
                    EditVisibility = Visibility.Collapsed;
                    DeleteVisibility = Visibility.Collapsed;
                    //AddVisibility = Visibility.Visible;
                    SaveAndAddVisibility = Visibility.Visible;
                }
            }
        }

        private void UpdateUIWithSelectedProduct(Product selectedProduct)
        {
            if (selectedProduct != null)
            {
                // Update UI elements with the values of the selected product
                ProductName = selectedProduct.Name;
                SelectedProductCategory = selectedProduct.Category; // Assuming Category has a Name property
                Barcode = selectedProduct.Barcode;
                ProductDescription = selectedProduct.Details;

                // Check if the image path is not null or empty
                if (!string.IsNullOrEmpty(selectedProduct.ImagePath))
                {
                    try
                    {
                        string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "products");
                        ProductImageSource = Path.Combine(directoryPath, selectedProduct.ImagePath);
                        // ProductImageSource = selectedProduct.ImagePath;
                    }
                    catch (UriFormatException ex)
                    {
                        // Handle the exception (e.g., log it, show an error message)
                        // For now, setting the ProductImageSource to null
                        ProductImageSource = null;
                    }
                }
                else
                {
                    // If the image path is null or empty, set the ProductImageSource to null
                    ProductImageSource = null;
                }

                SelectedColor = selectedProduct.Color;
                Weight = (double)selectedProduct.Weight;
                Length = (double)selectedProduct.Length;
                Width = (double)selectedProduct.Width;
                Height = (double)selectedProduct.Height;
                Quantity = (int)selectedProduct.Quantity;
                // Assuming selectedProduct is of type Product
                DateTime datexDate;
                if (DateTime.TryParse(selectedProduct.Datex, out datexDate))
                {
                    ExpiryDate = datexDate;
                }


                DateTime dateeDate;
                if (DateTime.TryParse(selectedProduct.Datee, out dateeDate))
                {
                    ProductionDate = dateeDate;
                }


            }
            else
            {
                ClearProductDetails();
            }
        }
        public void ClearProductDetails()
        {
            ProductName = string.Empty;
            //SelectedProductCategory = string.Empty;
            Barcode = string.Empty;
            ProductDescription = string.Empty;
            ProductImageSource = null;
            // Clear other properties accordingly...
            SelectedColor = string.Empty;
            Weight = 0;
            Length = 0;
            Width = 0;
            Height = 0;
            Quantity = 0;
            ProductionDate = DateTime.Today;
            ExpiryDate = DateTime.Today;
        }



        #region IsEnables Variables
        public void EnableInputs()
        {
            IsItemSelected = true;
            IsProductNameInputEnabled = true;
            IsColorsInputEnabled = true;
            IsWeightInputEnabled = true;
            IsLengthInputEnabled = true;
            IsHeightInputEnabled = true;
            IsWidthInputEnabled = true;
            IsQuantityInputEnabled = true;
            IsProductCategoriesEnabled = true;
            IsManageCategoryCommandEnabled = true;
            IsUnitsInputEnabled = true;
            IsGenerateBarcodeButtonEnabled = true;
            IsBarcodeInputEnabled = true;
            IsProductDescriptionEnabled = true;
            IsNewQuantityInputEnabled = true;
            IsNewPriceInputEnabled = true;
            IsImageSelectionEnabled = true;
            IsWholesalePriceInputEnabled = true;
            IsRetailPriceInputEnabled = true;
        }

        public void DisableInputs()
        {
            IsItemSelected = false;
            IsProductNameInputEnabled = false;
            IsColorsInputEnabled = false;
            IsWeightInputEnabled = false;
            IsLengthInputEnabled = false;
            IsHeightInputEnabled = false;
            IsWidthInputEnabled = false;
            IsQuantityInputEnabled = false;
            IsProductCategoriesEnabled = false;
            IsManageCategoryCommandEnabled = false;
            IsUnitsInputEnabled = false;
            IsGenerateBarcodeButtonEnabled = false;
            IsBarcodeInputEnabled = false;
            IsProductDescriptionEnabled = false;
            IsNewQuantityInputEnabled = false;
            IsNewPriceInputEnabled = false;
            IsImageSelectionEnabled = false;
            IsWholesalePriceInputEnabled = false;
            IsRetailPriceInputEnabled = false;
        }

        private bool _isProductNameInputEnabled;
        public bool IsProductNameInputEnabled
        {
            get { return _isProductNameInputEnabled; }
            set
            {
                _isProductNameInputEnabled = value;
                OnPropertyChanged(nameof(IsProductNameInputEnabled));
            }
        }

        private bool _isColorsInputEnabled;
        public bool IsColorsInputEnabled
        {
            get { return _isColorsInputEnabled; }
            set
            {
                _isColorsInputEnabled = value;
                OnPropertyChanged(nameof(IsColorsInputEnabled));
            }
        }

        private bool _isWeightInputEnabled;
        public bool IsWeightInputEnabled
        {
            get { return _isWeightInputEnabled; }
            set
            {
                _isWeightInputEnabled = value;
                OnPropertyChanged(nameof(IsWeightInputEnabled));
            }
        }

        private bool _isLengthInputEnabled;
        public bool IsLengthInputEnabled
        {
            get { return _isLengthInputEnabled; }
            set
            {
                _isLengthInputEnabled = value;
                OnPropertyChanged(nameof(IsLengthInputEnabled));
            }
        }

        private bool _isWidthInputEnabled;
        public bool IsWidthInputEnabled
        {
            get { return _isWidthInputEnabled; }
            set
            {
                _isWidthInputEnabled = value;
                OnPropertyChanged(nameof(IsWidthInputEnabled));
            }
        }

        private bool _isHeightInputEnabled;
        public bool IsHeightInputEnabled
        {
            get { return _isHeightInputEnabled; }
            set
            {
                _isHeightInputEnabled = value;
                OnPropertyChanged(nameof(IsHeightInputEnabled));
            }
        }

        private bool _isQuantityInputEnabled;
        public bool IsQuantityInputEnabled
        {
            get { return _isQuantityInputEnabled; }
            set
            {
                _isQuantityInputEnabled = value;
                OnPropertyChanged(nameof(IsQuantityInputEnabled));
            }
        }
        private bool _isProductCategoriesEnabled;
        public bool IsProductCategoriesEnabled
        {
            get { return _isProductCategoriesEnabled; }
            set
            {
                _isProductCategoriesEnabled = value;
                OnPropertyChanged(nameof(IsProductCategoriesEnabled));
            }
        }

        private bool _isManageCategoryCommandEnabled;
        public bool IsManageCategoryCommandEnabled
        {
            get { return _isManageCategoryCommandEnabled; }
            set
            {
                _isManageCategoryCommandEnabled = value;
                OnPropertyChanged(nameof(IsManageCategoryCommandEnabled));
            }
        }

        private bool _isUnitsInputEnabled;
        public bool IsUnitsInputEnabled
        {
            get { return _isUnitsInputEnabled; }
            set
            {
                _isUnitsInputEnabled = value;
                OnPropertyChanged(nameof(IsUnitsInputEnabled));
            }
        }

        private bool _isGenerateBarcodeButtonEnabled;
        public bool IsGenerateBarcodeButtonEnabled
        {
            get { return _isGenerateBarcodeButtonEnabled; }
            set
            {
                _isGenerateBarcodeButtonEnabled = value;
                OnPropertyChanged(nameof(IsGenerateBarcodeButtonEnabled));
            }
        }
        private bool _isBarcodeInputEnabled;

        public bool IsBarcodeInputEnabled
        {
            get { return _isBarcodeInputEnabled; }
            set
            {
                if (_isBarcodeInputEnabled != value)
                {
                    _isBarcodeInputEnabled = value;
                    OnPropertyChanged(nameof(IsBarcodeInputEnabled));
                }
            }
        }
        private bool _isProductDescriptionEnabled;
        public bool IsProductDescriptionEnabled
        {
            get { return _isProductDescriptionEnabled; }
            set
            {
                _isProductDescriptionEnabled = value;
                OnPropertyChanged(nameof(IsProductDescriptionEnabled));
            }
        }

        private bool _isNewQuantityInputEnabled;
        public bool IsNewQuantityInputEnabled
        {
            get { return _isNewQuantityInputEnabled; }
            set
            {
                _isNewQuantityInputEnabled = value;
                OnPropertyChanged(nameof(IsNewQuantityInputEnabled));
            }
        }

        private bool _isNewPriceInputEnabled;
        public bool IsNewPriceInputEnabled
        {
            get { return _isNewPriceInputEnabled; }
            set
            {
                _isNewPriceInputEnabled = value;
                OnPropertyChanged(nameof(IsNewPriceInputEnabled));
            }
        }

        private bool _isImageSelectionEnabled;
        public bool IsImageSelectionEnabled
        {
            get { return _isImageSelectionEnabled; }
            set
            {
                _isImageSelectionEnabled = value;
                OnPropertyChanged(nameof(IsImageSelectionEnabled));
            }
        }


        private bool _isWholesalePriceInputEnabled;
        public bool IsWholesalePriceInputEnabled
        {
            get { return _isWholesalePriceInputEnabled; }
            set
            {
                _isWholesalePriceInputEnabled = value;
                OnPropertyChanged(nameof(IsWholesalePriceInputEnabled));
            }
        }

        private bool _isRetailPriceInputEnabled;
        public bool IsRetailPriceInputEnabled
        {
            get { return _isRetailPriceInputEnabled; }
            set
            {
                _isRetailPriceInputEnabled = value;
                OnPropertyChanged(nameof(IsRetailPriceInputEnabled));
            }
        }

        #endregion
        #region Values Variables
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private ObservableCollection<Category> _productCategories;
        public ObservableCollection<Category> ProductCategories
        {
            get { return _productCategories; }
            set
            {
                _productCategories = value;
                OnPropertyChanged(nameof(ProductCategories));
            }
        }

        private Category _selectedProductCategory;
        public Category SelectedProductCategory
        {
            get { return _selectedProductCategory; }
            set
            {
                _selectedProductCategory = value;
                OnPropertyChanged(nameof(SelectedProductCategory));
            }
        }

        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }
        private DateTime productionDate = DateTime.Today;
        private DateTime expiryDate = DateTime.Today;

        public DateTime ProductionDate
        {
            get => productionDate;
            set
            {
                if (productionDate != value)
                {
                    productionDate = value;
                    OnPropertyChanged(nameof(ProductionDate));
                }
            }
        }

        public DateTime ExpiryDate
        {
            get => expiryDate;
            set
            {
                if (expiryDate != value)
                {
                    expiryDate = value;
                    OnPropertyChanged(nameof(ExpiryDate));
                }
            }
        }


        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                _productDescription = value;
                OnPropertyChanged(nameof(ProductDescription));
            }
        }

        private string _productImageSource;
        public string ProductImageSource
        {
            get { return _productImageSource; }
            set
            {
                _productImageSource = value;
                OnPropertyChanged(nameof(ProductImageSource));
            }
        }

        private ObservableCollection<string> _colors;
        public ObservableCollection<string> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }

        private double _wholesalePrice;
        public double WholesalePrice
        {
            get { return _wholesalePrice; }
            set
            {
                _wholesalePrice = value;
                OnPropertyChanged(nameof(WholesalePrice));
            }
        }

        private double _retailPrice;
        public double RetailPrice
        {
            get { return _retailPrice; }
            set
            {
                _retailPrice = value;
                OnPropertyChanged(nameof(RetailPrice));
            }
        }

        private double _profit;
        public double Profit
        {
            get { return _profit; }
            set
            {
                _profit = value;
                OnPropertyChanged(nameof(Profit));
            }
        }

        private string _selectedColor;
        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private double _length;
        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }
        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }


        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private ObservableCollection<string> _units;
        public ObservableCollection<string> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                OnPropertyChanged(nameof(Units));
            }
        }

        private string _selectedUnit;
        public string SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                _selectedUnit = value;
                OnPropertyChanged(nameof(SelectedUnit));
            }
        }
        #endregion
        #region Buttons
        public ICommand ManageCategoryCommand { get; }
        private void ExecuteManageCategoryCommand(object parameter)
        {
            // Create and show the payment dialog
            AddCategoriesDialog dialog = new AddCategoriesDialog();
            //dialog.viewModel.Total = 100.ToString();
            //dialog.viewModel.TotalQuantity = 100.ToString();
            // Show the dialog as a modal window
            bool? result = dialog.ShowDialog();

            // Check the result of the dialog
            if (result.HasValue)
            {
                // Payment dialog was closed, handle the result
                if (dialog.viewModel.Result == true)
                {
                    //// Payment was confirmed
                    //MessageBox.Show("تم بنجاح ", " تم بنجاح", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    //// Payment was canceled
                    //MessageBox.Show("تم إلغاء ", " تم إلغاء", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }
        public ICommand GenerateRandomBarcodeCommand { get; }
        private void GenerateRandomBarcode(object parameter)
        {
            // Implement logic to generate random barcode
            Barcode = Guid.NewGuid().ToString();
        }
        public ICommand ChooseImageCommand { get; }
        private void ChooseImage(object parameter)
        {
            // Create a file dialog to select an image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Get the selected file path
                    string imagePath = openFileDialog.FileName;

                    // Update the ProductImageSource with the selected image path
                    ProductImageSource = imagePath;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during file selection
                    // You can log the error or show an alert message to the user
                    Console.WriteLine("Error selecting image: " + ex.Message);
                }
            }
        }


        #endregion
        #endregion
        #region Filter Options
        // Properties for Tab 1: Search by Barcode
        private string _barcodeSearchText;
        public string BarcodeSearchText
        {
            get { return _barcodeSearchText; }
            set
            {
                _barcodeSearchText = value;
                OnPropertyChanged(nameof(BarcodeSearchText));
            }
        }

        private bool _isBarcodeExactMatch = true;
        public bool IsBarcodeExactMatch
        {
            get { return _isBarcodeExactMatch; }
            set
            {
                _isBarcodeExactMatch = value;
                OnPropertyChanged(nameof(IsBarcodeExactMatch));
            }
        }

        private bool _isBarcodeContains;
        public bool IsBarcodeContains
        {
            get { return _isBarcodeContains; }
            set
            {
                _isBarcodeContains = value;
                OnPropertyChanged(nameof(IsBarcodeContains));
            }
        }
        public ICommand SearchByBarcodeCommand { get; }

        // Properties for Tab 2: Search by Item Name
        private string _itemNameSearchText;
        public string ItemNameSearchText
        {
            get { return _itemNameSearchText; }
            set
            {
                _itemNameSearchText = value;
                OnPropertyChanged(nameof(ItemNameSearchText));
            }
        }

        private bool _isItemNameExactMatch = true;
        public bool IsItemNameExactMatch
        {
            get { return _isItemNameExactMatch; }
            set
            {
                _isItemNameExactMatch = value;
                OnPropertyChanged(nameof(IsItemNameExactMatch));
            }
        }

        private bool _isItemNameContains;
        public bool IsItemNameContains
        {
            get { return _isItemNameContains; }
            set
            {
                _isItemNameContains = value;
                OnPropertyChanged(nameof(IsItemNameContains));
            }
        }
        public ICommand SearchByItemNameCommand { get; }

        // Properties for Tab 3: Search by Date Added
        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private bool _isAscending = true;
        public bool IsAscending
        {
            get { return _isAscending; }
            set
            {
                _isAscending = value;
                OnPropertyChanged(nameof(IsAscending));
            }
        }

        private bool _isDescending;
        public bool IsDescending
        {
            get { return _isDescending; }
            set
            {
                _isDescending = value;
                OnPropertyChanged(nameof(IsDescending));
            }
        }
        public ICommand SearchByDateAddedCommand { get; }


        // Properties for Tab 4: Search by Category
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public ICommand SearchByCategoryCommand { get; }



        // Properties for Tab 5: Sort Expired Items
        public ICommand SortByQuantityCommand { get; }


        // Properties for Tab 6: Sort by Expiry Date
        private DateTime _expiryStartDate = DateTime.Now;
        public DateTime ExpiryStartDate
        {
            get { return _expiryStartDate; }
            set
            {
                _expiryStartDate = value;
                OnPropertyChanged(nameof(ExpiryStartDate));
            }
        }

        private DateTime _expiryEndDate = DateTime.Now;
        public DateTime ExpiryEndDate
        {
            get { return _expiryEndDate; }
            set
            {
                _expiryEndDate = value;
                OnPropertyChanged(nameof(ExpiryEndDate));
            }
        }

        private bool _isExpiryAscending = true;
        public bool IsExpiryAscending
        {
            get { return _isExpiryAscending; }
            set
            {
                _isExpiryAscending = value;
                OnPropertyChanged(nameof(IsExpiryAscending));
            }
        }

        private bool _isExpiryDescending;
        public bool IsExpiryDescending
        {
            get { return _isExpiryDescending; }
            set
            {
                _isExpiryDescending = value;
                OnPropertyChanged(nameof(IsExpiryDescending));
            }
        }
        public ICommand SearchByExpiryDateCommand { get; }

        #endregion
        private void SearchByBarcode()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(BarcodeSearchText))
            {
                if (IsBarcodeExactMatch)
                {
                    query = query.Where(p => p.Barcode == BarcodeSearchText);
                }
                else if (IsBarcodeContains)
                {
                    query = query.Where(p => p.Barcode.Contains(BarcodeSearchText));
                }
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void SearchByItemName()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(ItemNameSearchText))
            {
                if (IsItemNameExactMatch)
                {
                    query = query.Where(p => p.Name == ItemNameSearchText);
                }
                else if (IsItemNameContains)
                {
                    query = query.Where(p => p.Name.Contains(ItemNameSearchText));
                }
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void SearchByDateAdded()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (StartDate != DateTime.MinValue && EndDate != DateTime.MinValue)
            {
                query = query.Where(p => p.CreatedDate >= StartDate && p.CreatedDate <= EndDate);
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void SearchByCategory()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                query = query.Where(p => p.Category.Name == SelectedCategory);
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void SortByQuantity()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (IsAscending)
            {
                query = query.OrderBy(p => p.Quantity);
            }
            else if (IsDescending)
            {
                query = query.OrderByDescending(p => p.Quantity);
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void SearchByExpiryDate()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category);

            if (ExpiryStartDate != DateTime.MinValue && ExpiryEndDate != DateTime.MinValue)
            {
                if (IsExpiryAscending)
                {
                    query = query.OrderBy(p => p.Datex); // Assuming there's an ExpiryDate property in Product class
                }
                else if (IsExpiryDescending)
                {
                    query = query.OrderByDescending(p => p.Datex); // Assuming there's an ExpiryDate property in Product class
                }
            }

            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }

        private void LoadProductsFromDatabase()
        {
            IQueryable<Product> query = _dbContext.Products.Include(p => p.Category); // Initial query

            //// Apply filters based on selected options if they are provided
            //if (!string.IsNullOrEmpty(BarcodeSearchText))
            //{
            //    if (IsBarcodeExactMatch)
            //    {
            //        query = query.Where(p => p.Barcode == BarcodeSearchText);
            //    }
            //    else if (IsBarcodeContains)
            //    {
            //        query = query.Where(p => p.Barcode.Contains(BarcodeSearchText));
            //    }
            //}

            //if (!string.IsNullOrEmpty(ItemNameSearchText))
            //{
            //    if (IsItemNameExactMatch)
            //    {
            //        query = query.Where(p => p.Name == ItemNameSearchText);
            //    }
            //    else if (IsItemNameContains)
            //    {
            //        query = query.Where(p => p.Name.Contains(ItemNameSearchText));
            //    }
            //}

            //// Apply the date range filter if dates are provided
            //if (StartDate != DateTime.MinValue && EndDate != DateTime.MinValue)
            //{
            //    query = query.Where(p => p.CreatedDate >= StartDate && p.CreatedDate <= EndDate);
            //}

            //if (!string.IsNullOrEmpty(SelectedCategory))
            //{
            //    query = query.Where(p => p.Category.Name == SelectedCategory);
            //}

            //// Apply sorting based on selected options
            //if (IsAscending)
            //{
            //    query = query.OrderBy(p => p.Quantity);
            //}
            //else if (IsDescending)
            //{
            //    query = query.OrderByDescending(p => p.Quantity);
            //}

            //// Apply sorting for expired items
            //if (SortByQuantityCommand != null && SortByQuantityCommand.CanExecute(null))
            //{
            //    SortByQuantityCommand.Execute(null);
            //}

            //// Apply expiry date filter
            //if (ExpiryStartDate != DateTime.MinValue && ExpiryEndDate != DateTime.MinValue)
            //{
            //    if (IsExpiryAscending)
            //    {
            //        query = query.OrderBy(p => p.Datex); // Assuming there's an ExpiryDate property in Product class
            //    }
            //    else if (IsExpiryDescending)
            //    {
            //        query = query.OrderByDescending(p => p.Datex); // Assuming there's an ExpiryDate property in Product class
            //    }
            //}
            // Execute the query to retrieve products
            ObservableCollection<Product> products = new ObservableCollection<Product>(query.ToList());

            ProductsList = products;
        }
        private void LoadCategoriesFromDatabase()
        {
            IQueryable<Category> query = _dbContext.Categories; // Initial query

            // Execute the query to retrieve categories
            ObservableCollection<Category> categories = new ObservableCollection<Category>(query.ToList());

            ProductCategories = categories;
        }


        #region Bottom Buttons
        #region Visibility


        private Visibility _saveAndAddVisibility = Visibility.Visible;
        public Visibility SaveAndAddVisibility
        {
            get { return _saveAndAddVisibility; }
            set
            {
                _saveAndAddVisibility = value;
                OnPropertyChanged(nameof(SaveAndAddVisibility));
            }
        }

        private Visibility _saveAndEditVisibility = Visibility.Visible;
        public Visibility SaveAndEditVisibility
        {
            get { return _saveAndEditVisibility; }
            set
            {
                _saveAndEditVisibility = value;
                OnPropertyChanged(nameof(SaveAndEditVisibility));
            }
        }

        private Visibility _cancelVisibility = Visibility.Visible;
        public Visibility CancelVisibility
        {
            get { return _cancelVisibility; }
            set
            {
                _cancelVisibility = value;
                OnPropertyChanged(nameof(CancelVisibility));
            }
        }

        private Visibility _addVisibility = Visibility.Visible;
        public Visibility AddVisibility
        {
            get { return _addVisibility; }
            set
            {
                _addVisibility = value;
                OnPropertyChanged(nameof(AddVisibility));
            }
        }

        private Visibility _editVisibility = Visibility.Collapsed;
        public Visibility EditVisibility
        {
            get { return _editVisibility; }
            set
            {
                _editVisibility = value;
                OnPropertyChanged(nameof(EditVisibility));
            }
        }

        private Visibility _deleteVisibility = Visibility.Collapsed;
        public Visibility DeleteVisibility
        {
            get { return _deleteVisibility; }
            set
            {
                _deleteVisibility = value;
                OnPropertyChanged(nameof(DeleteVisibility));
            }
        }

        private Visibility _printVisibility = Visibility.Collapsed;
        public Visibility PrintVisibility
        {
            get { return _printVisibility; }
            set
            {
                _printVisibility = value;
                OnPropertyChanged(nameof(PrintVisibility));
            }
        }

        private Visibility _closeVisibility = Visibility.Visible;
        public Visibility CloseVisibility
        {
            get { return _closeVisibility; }
            set
            {
                _closeVisibility = value;
                OnPropertyChanged(nameof(CloseVisibility));
            }
        }
        #endregion
        public ICommand SaveAndAddCommand { get; }
        public ICommand SaveAndEditCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand PrintCommand { get; }
        public ICommand CloseCommand { get; }

        private bool ValidateInputs()
        {
            string missingFields = "";

            if (string.IsNullOrEmpty(ProductName))
            {
                missingFields += "اسم المنتج، ";
            }

            if (ProductCategories == null)
            {
                missingFields += "فئة المنتج، ";
            }

            if (Quantity <= 0)
            {
                missingFields += "الكمية المتوفرة لديك، ";
            }

            if (WholesalePrice <= 0)
            {
                missingFields += "سعر الجملة، ";
            }

            if (RetailPrice <= 0)
            {
                missingFields += "سعر البيع، ";
            }

            if (string.IsNullOrEmpty(SelectedUnit))
            {
                missingFields += "الفئة او الوحدة، ";
            }

            if (string.IsNullOrEmpty(Barcode))
            {
                missingFields += "رقم الباركود، ";
            }

            if (Profit < 0)
            {
                missingFields += "الربح، ";
            }

            //if (string.IsNullOrEmpty(ProductionDate.ToString()))
            //{
            //    missingFields += "تاريخ الانتاج، ";
            //}

            //if (string.IsNullOrEmpty(ExpiryDate.ToString()))
            //{
            //    missingFields += "تاريخ انتهاء الصلاحية، ";
            //}

            if (!string.IsNullOrEmpty(missingFields))
            {
                missingFields = missingFields.TrimEnd('،', ' ');
                MessageBox.Show($"يرجى ملء الحقول الإلزامية التالية: {missingFields}.");
                return false;
            }

            return true;
        }

        #region uploadImage
        public string SaveImage()
        {
            if (string.IsNullOrEmpty(ProductImageSource))
            {
                // Return empty string
                return string.Empty;
            }
            string uniqueFileName = null;
            try
            {
                uniqueFileName = $"{Guid.NewGuid()}.jpeg";
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images", "products");
                string imagePath = Path.Combine(directoryPath, uniqueFileName);

                // Create the directory if it does not exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var stream = File.OpenRead(ProductImageSource))
                {
                    using (var image = Image.FromStream(stream))
                    {
                        // Convert the image to Bitmap
                        Bitmap bitmap = new Bitmap(image);

                        // Compress the image and save it to the specified path
                        bitmap.Save(imagePath, ImageFormat.Jpeg);

                        // Return the unique filename
                        return uniqueFileName;
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


        private Product MapInputsToProduct()
        {
            // Validate input fields
            if (string.IsNullOrEmpty(ProductName))
            {
                MessageBox.Show("يجب إدخال اسم المنتج.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (string.IsNullOrEmpty(SelectedProductCategory.Name))
            {
                MessageBox.Show("يجب تحديد فئة المنتج.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            // Regular expression pattern for numeric values
            string numericPattern = @"^\d*\.?\d*$";

            if (!Regex.IsMatch(Weight.ToString(), numericPattern))
            {
                MessageBox.Show("الوزن يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(Length.ToString(), numericPattern))
            {
                MessageBox.Show("الطول يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(Width.ToString(), numericPattern))
            {
                MessageBox.Show("العرض يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(Height.ToString(), numericPattern))
            {
                MessageBox.Show("الارتفاع يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(Quantity.ToString(), numericPattern))
            {
                MessageBox.Show("الكمية يجب أن تكون قيمة عددية صحيحة.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(RetailPrice.ToString(), numericPattern))
            {
                MessageBox.Show("سعر البيع يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            if (!Regex.IsMatch(WholesalePrice.ToString(), numericPattern))
            {
                MessageBox.Show("سعر الجملة يجب أن يكون قيمة عددية.", "خطأ في الإدخال", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            Product newProduct = new Product
            {
                Name = ProductName,
                CategoryId = SelectedProductCategory.Id,
                Barcode = Barcode,
                Details = ProductDescription,
                Color = SelectedColor,
                Weight = Weight,
                Length = Length,
                Width = Width,
                Height = Height,
                Quantity = Quantity,
                Price = (double)RetailPrice,
                Cost = (double)WholesalePrice,
                Earned = Profit,
                Type = SelectedUnit,
                Datee = ProductionDate.ToString(),
                Datex = ExpiryDate.ToString()
            };

            // Check if the image path is null, indicating failure to save the image
            string imagePath = SaveImage();
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBoxResult result = MessageBox.Show("لم يتم حفظ صورة المنتج. هل تريد المتابعة أم تحاول مرة أخرى؟", "خطأ في حفظ الصورة", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    // Proceed without the image
                    newProduct.ImagePath = null; // Set ImagePath to null
                }
                else
                {
                    // Try again
                    return MapInputsToProduct();
                }
            }

            // If SelectedProduct is not null, it means we are updating an existing product
            if (SelectedProduct != null)
            {
                // Update existing product
                SelectedProduct.Name = newProduct.Name;
                SelectedProduct.Category = newProduct.Category;
                SelectedProduct.Barcode = newProduct.Barcode;
                SelectedProduct.Details = newProduct.Details;
                SelectedProduct.ImagePath = imagePath; // Update ImagePath with new path
                SelectedProduct.Color = newProduct.Color;
                SelectedProduct.Weight = newProduct.Weight;
                SelectedProduct.Length = newProduct.Length;
                SelectedProduct.Width = newProduct.Width;
                SelectedProduct.Height = newProduct.Height;
                SelectedProduct.Quantity = newProduct.Quantity;
                SelectedProduct.Price = newProduct.Price;
                SelectedProduct.Cost = newProduct.Cost;
                SelectedProduct.Earned = newProduct.Earned;
                SelectedProduct.Type = newProduct.Type;

                // Save changes to database
                _dbContext.SaveChanges();

                return SelectedProduct;
            }
            else
            {
                // Add new product to database
                newProduct.ImagePath = imagePath; // Set ImagePath with new path
                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();

                return newProduct;
            }


        }



        #endregion
        private void ExecuteSaveAndAddCommand(object parameter)
        {
            if (ValidateInputs())
            {
                // Map input values to a new product object
                Product newProduct = MapInputsToProduct();

                // Add the new product to the ProductsList
                ProductsList.Add(newProduct);

                // Disable inputs after saving
                DisableInputs();
                SelectedProduct = null;
                ClearProductDetails();
                MessageBox.Show("تم إضافة المنتج بنجاح!");
            }
        }


        private void ExecuteSaveAndEditCommand(object parameter)
        {
            if (ValidateInputs())
            {
                if (SelectedProduct != null)
                {
                    SelectedProduct = MapInputsToProduct();
                }

                // Disable inputs after saving
                DisableInputs();

                MessageBox.Show("تم تعديل المنتج بنجاح!");
            }
        }

        private void ExecuteCancelCommand(object parameter)
        {
            // Enable inputs to add a new product
            SelectedProduct = null;
            DisableInputs();
        }

        private void ExecuteAddCommand(object parameter)
        {
            // Enable inputs to add a new product
            SelectedProduct = null;
            EnableInputs();
        }

        private void ExecuteEditCommand(object parameter)
        {
            if (SelectedProduct == null)
            {
                // Show an alert message in Arabic indicating that no product is selected
                MessageBox.Show("لم يتم تحديد منتج. يرجى تحديد منتج قبل التعديل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Enable inputs to edit the selected product
                EnableInputs();
            }
        }


        private void ExecuteDeleteCommand(object parameter)
        {
            if (SelectedProduct == null)
            {
                // Show an alert message in Arabic indicating that no product is selected
                MessageBox.Show("لم يتم تحديد منتج. يرجى تحديد منتج قبل الحذف.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Remove the selected product from the ProductsList
                ProductsList.Remove(SelectedProduct);
            }
        }

        private void ExecutePrintCommand(object parameter)
        {
            // Logic for printing
        }

        private void ExecuteCloseCommand(object parameter)
        {
            // Logic for closing
        }

        private void SaveProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        private void UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        private void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
        #endregion
        private readonly AppDbContext _dbContext;

        public InventoryViewModel()
        {
            _dbContext = new AppDbContext();
            SaveAndAddCommand = new RelayCommand(ExecuteSaveAndAddCommand);
            SaveAndEditCommand = new RelayCommand(ExecuteSaveAndEditCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
            AddCommand = new RelayCommand(ExecuteAddCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);
            PrintCommand = new RelayCommand(ExecutePrintCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);

            SearchByBarcodeCommand = new RelayCommand(param => SearchByBarcode());
            SearchByItemNameCommand = new RelayCommand(param => SearchByItemName());
            SearchByDateAddedCommand = new RelayCommand(param => SearchByDateAdded());
            SearchByCategoryCommand = new RelayCommand(param => SearchByCategory());
            SortByQuantityCommand = new RelayCommand(param => SortByQuantity());
            SearchByExpiryDateCommand = new RelayCommand(param => SearchByExpiryDate());

            //Variables
            ManageCategoryCommand = new RelayCommand(ExecuteManageCategoryCommand);
            GenerateRandomBarcodeCommand = new RelayCommand(GenerateRandomBarcode);
            ChooseImageCommand = new RelayCommand(ChooseImage);

            //Warhouses
            // Initialize commands
            ManageWarehouseCommand = new RelayCommand(ManageWarehouse);

            // Initialize properties
            Warehouses = new ObservableCollection<Warehouse>();
            LoadWarehouses(); // Load warehouses from data source or initialize them


            ProductCategories = new ObservableCollection<Category>();
            Units = new ObservableCollection<string>();
            Colors = new ObservableCollection<string>();

            ProductsList = new ObservableCollection<Product>();
            LoadCategoriesFromDatabase();
            LoadProductsFromDatabase();

            InitializeList();
            //GenerateDummyProducts();

        }
        private void InitializeList()
        {


            Units = new ObservableCollection<string>
    {
        "قطعة",
        "متر",
        "لتر",
        "كيلوغرام",
        "جرام",
        "باقة",
        "كرتون",
        "طقم",
        "حبة",
        "عبوة",
        "لفة",
        "صندوق",
        "لحمة",
        "طن",
    };

            Colors = new ObservableCollection<string>
    {
        "أحمر",
        "أزرق",
        "أخضر",
        "أصفر",
        "أسود",
        "أبيض",
        "برتقالي",
        "أرجواني",
        "بني",
        "رمادي",
        "وردي",
        "ذهبي",
        "فضي",
        "بيج",
    };

        }

        private void GenerateDummyProducts()
        {
            ObservableCollection<Product> dummyProducts = new ObservableCollection<Product>();

            DateTime today = DateTime.Today; // Get today's date

            // Set Datex to tomorrow's date
            DateTime nextDay = today.AddDays(1);
            // Set Datee to the day after tomorrow's date
            DateTime dayAfterNext = today.AddDays(2);

            for (int i = 1; i <= 3; i++)
            {
                // Create a dummy product with some sample values
                Product product = new Product
                {
                    Id = i,
                    Name = "Product " + i,
                    Category = new Category { Name = "Category " + (i % 5 + 1) }, // Assuming there are 5 categories
                    Quantity = i * 2.5, // Some dummy quantity
                    Cost = i * 1.5,     // Some dummy cost
                    Price = i * 2,      // Some dummy price
                    Type = "Type " + (i % 3 + 1), // Assuming there are 3 types
                    Barcode = "Barcode " + i,
                    Earned = i * 0.75, // Some dummy earned amount
                    Datex = nextDay.ToShortDateString(), // Set Datex to tomorrow's date
                    Datee = dayAfterNext.ToShortDateString(), // Set Datee to the day after tomorrow's date
                    Details = "Details " + i,
                    Color = "Color " + (i % 4 + 1), // Assuming there are 4 colors
                    Width = i * 0.2,    // Some dummy width
                    Height = i * 0.3,   // Some dummy height
                    Length = i * 0.4,   // Some dummy length
                    Weight = i * 0.5,   // Some dummy weight
                    ImagePath = "Path to image " + i // Replace with the actual path or URI of an image
                };

                dummyProducts.Add(product);
            }

            ProductsList = dummyProducts;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
