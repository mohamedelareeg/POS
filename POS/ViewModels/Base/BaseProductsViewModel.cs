using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POS.Domain.Models;
using POS.Domain.Models.Products;
using POS.Persistence.Context;
using POS.Persistence.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace POS.ViewModels.Base
{
    public class BaseProductsViewModel : INotifyPropertyChanged
    {
        #region CartList Events
        public ICommand CartList_CurrentCellChangedCommand { get; set; }
        public ICommand CartList_SelectionChangedCommand { get; set; }
        public ICommand CartList_MouseDownCommand { get; set; }
        public ICommand CartList_MouseDoubleClickCommand { get; set; }
        public ICommand CartList_DataContextChangedCommand { get; set; }
        public ICommand CartList_SelectedCellsChangedCommand { get; set; }
        #endregion
        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                if (_subTotal != value)
                {
                    _subTotal = value;
                    OnPropertyChanged(nameof(SubTotal));
                }
            }
        }
        private double _discount;
        public double Discount
        {
            get => _discount;
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged(nameof(Discount));
                }
            }
        }

        private double _tax;
        public double Tax
        {
            get => _tax;
            set
            {

                if (_tax != value)
                {

                    _tax = value;
                    OnPropertyChanged(nameof(Tax));
                }
            }
        }


        #region ReadyProduct Section
        private ObservableCollection<ReadyProduct> readyProductsList;
        public ObservableCollection<ReadyProduct> ReadyProductsList
        {
            get { return readyProductsList; }
            set
            {
                readyProductsList = value;
                OnPropertyChanged(nameof(ReadyProductsList));
            }
        }


        private ReadyProduct selectedReadyProduct;
        public ReadyProduct SelectedReadyProduct
        {
            get { return selectedReadyProduct; }
            set
            {
                selectedReadyProduct = value;
                OnPropertyChanged(nameof(SelectedReadyProduct));
            }
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private decimal _productSalePrice;
        public decimal ProductSalePrice
        {
            get => _productSalePrice;
            set
            {
                _productSalePrice = value;
                OnPropertyChanged(nameof(ProductSalePrice));
            }
        }
        #endregion
        private ObservableCollection<ApplicationUser> _employees;
        public ObservableCollection<ApplicationUser> Employees
        {
            get { return _employees; }
            set { _employees = value; OnPropertyChanged(nameof(Employees)); }
        }

        private ApplicationUser _selectedEmployee;
        public ApplicationUser SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged(nameof(SelectedEmployee)); }
        }
        private ObservableCollection<Supplier> _suppliers;
        public ObservableCollection<Supplier> Suppliers
        {
            get { return _suppliers; }
            set { _suppliers = value; OnPropertyChanged(nameof(Suppliers)); }
        }

        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; OnPropertyChanged(nameof(SelectedSupplier)); }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        // Properties for warehouses
        private ObservableCollection<Warehouse> _warehouses;
        public ObservableCollection<Warehouse> Warehouses
        {
            get { return _warehouses; }
            set { _warehouses = value; OnPropertyChanged(nameof(Warehouses)); }
        }
        private Warehouse _productWarehouse;
        public Warehouse ProductWarehouse
        {
            get { return _productWarehouse; }
            set
            {
                _productWarehouse = value;

                OnPropertyChanged(nameof(ProductWarehouse));
            }
        }
        private Warehouse _selectedWarehouse;
        public Warehouse SelectedWarehouse
        {
            get { return _selectedWarehouse; }
            set
            {
                _selectedWarehouse = value;
                LoadCategoriesWithProducts();
                SelectedProduct = null;
                //SelectedCategory = CategoryList.FirstOrDefault(category => category.Name == selectedCartItem.Category);

                ItemName = "برجاء اختيار منتج";
                ItemBarcode = "0";
                Quantity = 0;
                SalePrice = 0;
                Notes = string.Empty;
                SelectedReadyProduct = null;
                RemainingQuantity = 0;
                ProductWarehouse = null;
                OnPropertyChanged(nameof(SelectedWarehouse));
            }
        }

        private Warehouse _selectedWarehouseToTransferTo;
        public Warehouse SelectedWarehouseToTransferTo
        {
            get { return _selectedWarehouseToTransferTo; }
            set { _selectedWarehouseToTransferTo = value; OnPropertyChanged(nameof(SelectedWarehouseToTransferTo)); }
        }


        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;

                    OnPropertyChanged(nameof(SelectedCategory));

                    //ProductList = SampleData.GenerateProducts(10, _selectedCategory);
                    if (_selectedCategory != null)
                    {
                        // Clear and filter ProductList for selected category's products
                        ProductList.Clear();
                        foreach (var product in _selectedCategory.Products)
                        {
                            ProductList.Add(product);
                        }
                        OnPropertyChanged(nameof(ProductList));
                    }
                    else
                    {
                        // Handle case where no category is selected (clear or set default)
                        ProductList.Clear(); // Or set some default value if needed
                        OnPropertyChanged(nameof(ProductList));
                    }
                    //ProductList = new ObservableCollection<Product>(_selectedCategory?.Products.ToList());
                }
            }
        }


        private ObservableCollection<Category> _categoryList;
        public ObservableCollection<Category> CategoryList
        {
            get { return _categoryList; }
            set
            {
                if (_categoryList != value)
                {
                    _categoryList = value;
                    OnPropertyChanged(nameof(CategoryList));
                }
            }
        }
        private ObservableCollection<Product> _productList;

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                if (_productList != value)
                {
                    _productList = value;
                    OnPropertyChanged(nameof(ProductList));
                }
            }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;

                    if (_selectedProduct != null)
                    {
                        ItemName = _selectedProduct.Name;
                        ItemBarcode = _selectedProduct.Barcode;
                        Quantity = 1;
                        SalePrice = _selectedProduct.SalePrice;
                        ProductWarehouse = SelectedWarehouse;
                        //if (_selectedProduct != null && SelectedWarehouse != null && SelectedWarehouse.Id != null)
                        //{
                        //    double? RQuantity = _selectedProduct.Quantity(ProductWarehouse.Id);
                        //    RemainingQuantity = RQuantity ?? 0;


                        //}

                        // Set color for RemainingQuantity
                        //RemainingQuantityColor = RemainingQuantity >= 0 ? Brushes.Blue : Brushes.Red;
                    }
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        private string _textSearchGoods;
        public string TextSearchGoods
        {
            get { return _textSearchGoods; }
            set
            {
                if (_textSearchGoods != value)
                {
                    _textSearchGoods = value;
                    OnPropertyChanged(nameof(TextSearchGoods));

                    // Update ProductList based on the search
                    if (SelectedCategory != null)
                    {
                        var filteredProducts = ProductList
                            .Where(product => product.Name.Contains(TextSearchGoods));

                        UpdateCurrentList(filteredProducts);
                    }
                }
            }
        }

        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                if (_textSearch != value)
                {
                    _textSearch = value;
                    OnPropertyChanged(nameof(TextSearch));

                    // Update CategoryList based on the search
                    var filteredCategories = CategoryList
                        .Where(category => category.Name.Contains(TextSearch));

                    UpdateCurrentList(filteredCategories);
                }
            }
        }

        private void UpdateCurrentList<T>(IEnumerable<T> filteredItems)
        {
            if (typeof(T) == typeof(Product))
            {
                ProductList = new ObservableCollection<Product>((IEnumerable<Product>)filteredItems);
            }
            else if (typeof(T) == typeof(Category))
            {
                CategoryList = new ObservableCollection<Category>((IEnumerable<Category>)filteredItems);
            }
        }
        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    OnPropertyChanged(nameof(Barcode));
                }
            }
        }

        private bool _maxGoodsChecked;
        public bool MaxGoodsChecked
        {
            get { return _maxGoodsChecked; }
            set
            {
                if (_maxGoodsChecked != value)
                {
                    _maxGoodsChecked = value;
                    OnPropertyChanged(nameof(MaxGoodsChecked));
                }
            }
        }

        private bool _smallGoodsChecked;
        public bool SmallGoodsChecked
        {
            get { return _smallGoodsChecked; }
            set
            {
                if (_smallGoodsChecked != value)
                {
                    _smallGoodsChecked = value;
                    OnPropertyChanged(nameof(SmallGoodsChecked));
                }
            }
        }
        private double _totalQuantity;
        public double TotalQuantity
        {
            get => _totalQuantity;
            set
            {
                if (_totalQuantity != value)
                {
                    _totalQuantity = value;
                    OnPropertyChanged(nameof(TotalQuantity));
                }
            }
        }

        private double _totalAmount;
        private double _earnings;



        public double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }

        public double Earnings
        {
            get { return _earnings; }
            set
            {
                if (_earnings != value)
                {
                    _earnings = value;
                    OnPropertyChanged(nameof(Earnings));
                }
            }
        }


        private string _itemName;
        private double _quantity;
        private double _salePrice;
        private string _notes;
        private string _safetyIndicator;
        private double _remainingQuantity;
        private bool _isDeleteButtonVisible;

        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }
        private string _itemBarcode;

        public string ItemBarcode
        {
            get { return _itemBarcode; }
            set
            {
                if (_itemBarcode != value)
                {
                    _itemBarcode = value;
                    OnPropertyChanged(nameof(ItemBarcode));
                }
            }
        }

        private bool _isSale = false;

        public bool IsSale
        {
            get { return _isSale; }
            set
            {
                if (_isSale != value)
                {
                    _isSale = value;
                    OnPropertyChanged(nameof(IsSale));


                }
            }
        }
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    if (SelectedProduct != null)
                    {
                        var productQuantity = SelectedProduct.Quantity(SelectedWarehouse.Id);
                        if (IsSale) // Check if it's a sale
                        {

                            if (productQuantity < 0)
                            {
                                // Quantity entered is not valid, show alert and set to minimum (1 in this case)
                                MessageBox.Show("الكمية المدخلة غير صالحة. تم تعيين الكمية إلى الحد الأدنى.");
                                value = 1; // Set to minimum valid value
                            }
                            else if (value > productQuantity)
                            {
                                // Quantity entered is greater than available, show alert and set to max
                                MessageBox.Show("الكمية المدخلة تتجاوز الكمية المتاحة. تم تعيين الكمية إلى الحد الأقصى.");

                                value = productQuantity;
                            }
                        }

                        _quantity = value;
                        OnPropertyChanged(nameof(Quantity));

                        SalePrice = Quantity * UnitPrice;
                        PurchasePrice = Quantity * UnitPrice;
                        RemainingQuantity = productQuantity;//- Quantity

                        // Set color for RemainingQuantity
                        RemainingQuantityColor = RemainingQuantity >= 0 ? Brushes.Blue : Brushes.Red;
                    }
                }
            }
        }


        private double _purchasePrice;

        public double PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                if (_purchasePrice != value)
                {
                    _purchasePrice = value;
                    OnPropertyChanged(nameof(PurchasePrice));
                }
            }
        }
        public double SalePrice
        {
            get { return _salePrice; }
            set
            {
                if (_salePrice != value)
                {
                    _salePrice = value;
                    OnPropertyChanged(nameof(SalePrice));


                    //double profitLoss = (double)((Quantity * SalePrice) - (Quantity * SelectedProduct.GetLastPurchasePrice()));

                    //if (profitLoss >= 0)
                    //{
                    //    SafetyIndicator = "مكسب";
                    //    SafetyIndicatorColor = Brushes.Blue;
                    //}
                    //else
                    //{
                    //    SafetyIndicator = "خسارة";
                    //    SafetyIndicatorColor = Brushes.Red;
                    //}
                }
            }
        }
        private double _unitPrice;
        public double UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    SalePrice = Quantity * UnitPrice;
                    PurchasePrice = Quantity * UnitPrice;
                    OnPropertyChanged(nameof(UnitPrice));


                    //double profitLoss = (double)((Quantity * SalePrice) - (Quantity * SelectedProduct.GetLastPurchasePrice()));

                    //if (profitLoss >= 0)
                    //{
                    //    SafetyIndicator = "مكسب";
                    //    SafetyIndicatorColor = Brushes.Blue;
                    //}
                    //else
                    //{
                    //    SafetyIndicator = "خسارة";
                    //    SafetyIndicatorColor = Brushes.Red;
                    //}
                }
            }
        }

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

        public string SafetyIndicator
        {
            get { return _safetyIndicator; }
            set
            {
                if (_safetyIndicator != value)
                {
                    _safetyIndicator = value;
                    OnPropertyChanged(nameof(SafetyIndicator));
                }
            }
        }
        private Brush _safetyIndicatorColor;

        public Brush SafetyIndicatorColor
        {
            get { return _safetyIndicatorColor; }
            set
            {
                if (_safetyIndicatorColor != value)
                {
                    _safetyIndicatorColor = value;
                    OnPropertyChanged(nameof(SafetyIndicatorColor));
                }
            }
        }


        public double RemainingQuantity
        {
            get { return _remainingQuantity; }
            set
            {
                if (_remainingQuantity != value)
                {
                    _remainingQuantity = value;
                    OnPropertyChanged(nameof(RemainingQuantity));
                }
            }
        }
        private Brush _remainingQuantityColor;

        public Brush RemainingQuantityColor
        {
            get { return _remainingQuantityColor; }
            set
            {
                if (_remainingQuantityColor != value)
                {
                    _remainingQuantityColor = value;
                    OnPropertyChanged(nameof(RemainingQuantityColor));
                }
            }
        }


        public bool IsDeleteButtonVisible
        {
            get { return _isDeleteButtonVisible; }
            set
            {
                if (_isDeleteButtonVisible != value)
                {
                    _isDeleteButtonVisible = value;
                    OnPropertyChanged(nameof(IsDeleteButtonVisible));
                }
            }
        }


        public ICommand CloseCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand CellCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand EndSaleCommand { get; }

        public ICommand EndSaleWithoutInternetCommand { get; }
        public ICommand ViewPendingBillsCommand { get; }

        public AppDbContext _dbContext; // Add a reference to your DbContext

        public BaseProductsViewModel()
        {
            // Initialize DbContext
            _dbContext = new AppDbContext();
            MaxGoodsChecked = true;
            CategoryList = new ObservableCollection<Category>();
            ProductList = new ObservableCollection<Product>();

            ReadyProductsList = new ObservableCollection<ReadyProduct>();

            //CategoryList = SampleData.GenerateCategories();
            Employees = new ObservableCollection<ApplicationUser>();

            Suppliers = new ObservableCollection<Supplier>();
            Warehouses = new ObservableCollection<Warehouse>();
            //SelectedCategory = CategoryList?.FirstOrDefault();
            //ProductList = new ObservableCollection<Product>();
            CloseCommand = new RelayCommand(ExecuteCloseCommand);
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand);
            CellCommand = new RelayCommand(ExecuteCellCommand);
            NewCommand = new RelayCommand(ExecuteNewCommand);
            EndSaleCommand = new RelayCommand(ExecuteEndSaleCommand);

            EndSaleWithoutInternetCommand = new RelayCommand(ExecuteEndSaleWithoutInternetCommand);
            ViewPendingBillsCommand = new RelayCommand(ExecuteViewPendingBillsCommand);




            LoadEmployees();
            LoadWarehouses();
            LoadSuppliers();
            LoadCustomers();
            LoadCategoriesWithProducts();
        }
        private void LoadWarehouses()
        {
            IQueryable<Warehouse> query = _dbContext.Warehouses; // Initial query

            ObservableCollection<Warehouse> warehouses = new ObservableCollection<Warehouse>(query.ToList());

            Warehouses = warehouses;
            if (Warehouses != null && Warehouses.Count > 0)
            {
                SelectedWarehouse = Warehouses.FirstOrDefault();
            }
        }
        private void LoadSuppliers()
        {
            IQueryable<Supplier> query = _dbContext.Suppliers; // Initial query

            ObservableCollection<Supplier> suppliers = new ObservableCollection<Supplier>(query.ToList());

            Suppliers = suppliers;
        }
        private void LoadCustomers()
        {
            IQueryable<Customer> query = _dbContext.Customers; // Initial query

            ObservableCollection<Customer> customers = new ObservableCollection<Customer>(query.ToList());

            Customers = customers;
        }
        private void LoadCategoriesWithProducts()
        {
            // Clear the existing categories and products
            CategoryList.Clear();
            ProductList.Clear();

            // Load categories with their associated products for the selected warehouse
            var categoriesWithProducts = _dbContext.Categories
               .Include(c => c.Products)
                   .ThenInclude(p => p.SaleProducts)
               .Include(c => c.Products)
                   .ThenInclude(p => p.PurchaseProducts)
               .Select(c => new
               {
                   Category = c,
                   Products = c.Products.Select(p => new
                   {
                       Product = p,
                       SaleQuantity = SelectedWarehouse != null ? p.SaleProducts.Where(sp => sp.WarehouseId == SelectedWarehouse.Id).Sum(sp => sp.Quantity) : 0,
                       PurchaseQuantity = SelectedWarehouse != null ? p.PurchaseProducts.Where(pp => pp.WarehouseId == SelectedWarehouse.Id).Sum(pp => pp.Quantity) : 0
                   })
               })
               .ToList();


            foreach (var item in categoriesWithProducts)
            {
                // Add the category to the CategoryList
                CategoryList.Add(item.Category);

                // Add products of the category to the ProductList
                foreach (var product in item.Products)
                {
                    product.Product.ImagePath = Path.Combine(Environment.CurrentDirectory, "images", "products", product.Product.ImagePath);
                    ProductList.Add(product.Product);
                }
            }
        }


        private async Task LoadEmployees()
        {
            var authenticationService = App.ServiceProvider.GetRequiredService<AuthenticationService>();
            Employees = await authenticationService.LoadEmployeesAsync();
        }

        private void ExecuteCloseCommand(object parameter)
        {
            // Handle logic for Close command
        }

        private void ExecuteRefreshCommand(object parameter)
        {
            // Handle logic for Refresh command
        }

        private void ExecuteCellCommand(object parameter)
        {
            // Handle logic for Cell command
        }

        private void ExecuteNewCommand(object parameter)
        {
            // Handle logic for New command
        }
        private void ExecuteEndSaleCommand(object parameter)
        {
            // Handle logic for ending sale
        }

        private void ExecuteEndSaleWithoutInternetCommand(object parameter)
        {
            // Handle logic for ending sale without internet
        }

        private void ExecuteViewPendingBillsCommand(object parameter)
        {
            // Handle logic for viewing pending bills
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
