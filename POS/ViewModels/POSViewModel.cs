using POS.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace POS.ViewModels
{
    public class POSViewModel : INotifyPropertyChanged
    {

        #region CartList Events
        public ICommand CartList_CurrentCellChangedCommand { get; }
        public ICommand CartList_SelectionChangedCommand { get; }
        public ICommand CartList_MouseDownCommand { get; }
        public ICommand CartList_MouseDoubleClickCommand { get; }
        public ICommand CartList_DataContextChangedCommand { get; }
        public ICommand CartList_SelectedCellsChangedCommand { get; }
        #endregion

        private ObservableCollection<CartItem> _cartItemsList;

        public ObservableCollection<CartItem> CartItemsList
        {
            get { return _cartItemsList; }
            set
            {
                if (_cartItemsList != value)
                {
                    _cartItemsList = value;
                    OnPropertyChanged(nameof(CartItemsList));

                }
            }
        }

        private CartItem _selectedCartItem;

        public CartItem SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                if (_selectedCartItem != value)
                {
                    _selectedCartItem = value;
                    OnPropertyChanged(nameof(SelectedCartItem));
                    SetSelectedItemValues(SelectedCartItem);
                }
            }
        }
        private void RecalculateTotalAmount()
        {
            TotalAmount = CartItemsList.Sum(item => item.Price);
        }
        public void SetSelectedItemValues(CartItem selectedCartItem)
        {
            if (selectedCartItem != null)
            {
                SelectedProduct = ProductList.FirstOrDefault(product => product.Id == selectedCartItem.Id);
                SelectedCategory = CategoryList.FirstOrDefault(category => category.Name == selectedCartItem.Category);

                ItemName = selectedCartItem.Name;
                ItemBarcode = selectedCartItem.Barcode;
                Quantity = selectedCartItem.Quantity;
                SalePrice = selectedCartItem.Price;
                Notes = selectedCartItem.Details;
            }
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

                    ProductList = SampleData.GenerateProducts(10, _selectedCategory);
                    //ProductList = new ObservableCollection<Product>(_selectedCategory?.Products.ToList());
                    OnPropertyChanged(nameof(ProductList));
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
                    OnPropertyChanged(nameof(SelectedProduct));
                    if (_selectedProduct != null)
                    {
                        ItemName = _selectedProduct.Name;
                        ItemBarcode = _selectedProduct.Barcode;
                        Quantity = 1;
                        SalePrice = _selectedProduct.Price;
                    }
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
                        var filteredProducts = SampleData.GenerateProducts(10, SelectedCategory)
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
                    var filteredCategories = SampleData.GenerateCategories()
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
        private int _billNumber;
        private double _totalAmount;
        private double _earnings;

        public int BillNumber
        {
            get { return _billNumber; }
            set
            {
                if (_billNumber != value)
                {
                    _billNumber = value;
                    OnPropertyChanged(nameof(BillNumber));
                }
            }
        }

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


        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    if (SelectedProduct != null)
                    {
                        if (value > SelectedProduct.Quantity)
                        {
                            // Quantity entered is greater than available, show alert and set to max
                            MessageBox.Show("الكمية المدخلة تتجاوز الكمية المتاحة. تم تعيين الكمية إلى الحد الأقصى.");

                            value = SelectedProduct.Quantity;
                        }

                        _quantity = value;
                        OnPropertyChanged(nameof(Quantity));

                        SalePrice = Quantity * SelectedProduct.Price;


                        RemainingQuantity = SelectedProduct.Quantity - Quantity;

                        // Set color for RemainingQuantity
                        RemainingQuantityColor = RemainingQuantity >= 0 ? Brushes.Blue : Brushes.Red;
                    }
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


                    double profitLoss = (Quantity * SalePrice) - (Quantity * SelectedProduct.Cost);

                    if (profitLoss >= 0)
                    {
                        SafetyIndicator = "مكسب";
                        SafetyIndicatorColor = Brushes.Blue;
                    }
                    else
                    {
                        SafetyIndicator = "خسارة";
                        SafetyIndicatorColor = Brushes.Red;
                    }
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
        public ICommand SuspendBillCommand { get; }
        public ICommand EndSaleWithoutInternetCommand { get; }
        public ICommand ViewPendingBillsCommand { get; }

        public ICommand AddCommand { get; }
        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DeleteCommand { get; }




        public POSViewModel()
        {
            MaxGoodsChecked = true;
            CartItemsList = new ObservableCollection<CartItem>();
            CategoryList = new ObservableCollection<Category>();
            ProductList = new ObservableCollection<Product>();

            CategoryList = SampleData.GenerateCategories();
            //SelectedCategory = CategoryList?.FirstOrDefault();
            //ProductList = new ObservableCollection<Product>();


            CloseCommand = new RelayCommand(ExecuteCloseCommand);
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand);
            CellCommand = new RelayCommand(ExecuteCellCommand);
            NewCommand = new RelayCommand(ExecuteNewCommand);
            EndSaleCommand = new RelayCommand(ExecuteEndSaleCommand);
            SuspendBillCommand = new RelayCommand(ExecuteSuspendBillCommand);
            EndSaleWithoutInternetCommand = new RelayCommand(ExecuteEndSaleWithoutInternetCommand);
            ViewPendingBillsCommand = new RelayCommand(ExecuteViewPendingBillsCommand);

            AddCommand = new RelayCommand(ExecuteAddCommand);
            AcceptCommand = new RelayCommand(ExecuteAcceptCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);

            #region CartListEvents
            CartList_CurrentCellChangedCommand = new RelayCommand(ExecuteCartList_CurrentCellChangedCommand);
            CartList_SelectionChangedCommand = new RelayCommand(ExecuteCartList_SelectionChangedCommand);
            CartList_MouseDownCommand = new RelayCommand(ExecuteCartList_MouseDownCommand);
            CartList_MouseDoubleClickCommand = new RelayCommand(ExecuteCartList_MouseDoubleClickCommand);
            CartList_DataContextChangedCommand = new RelayCommand(ExecuteCartList_DataContextChangedCommand);
            CartList_SelectedCellsChangedCommand = new RelayCommand(ExecuteCartList_SelectedCellsChangedCommand);
            #endregion
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

        private void ExecuteSuspendBillCommand(object parameter)
        {
            // Handle logic for suspending bill
        }

        private void ExecuteEndSaleWithoutInternetCommand(object parameter)
        {
            // Handle logic for ending sale without internet
        }

        private void ExecuteViewPendingBillsCommand(object parameter)
        {
            // Handle logic for viewing pending bills
        }

        private void ExecuteAddCommand(object parameter)
        {
            if (SelectedProduct != null)
            {
                Quantity++;
            }
        }

        private void ExecuteAcceptCommand(object parameter)
        {
            if (SelectedProduct != null && Quantity > 0 && SalePrice > 0)
            {
                // Check if the item already exists in the cart
                CartItem existingCartItem = CartItemsList.FirstOrDefault(item => item.Id == SelectedProduct.Id);

                if (existingCartItem != null)
                {
                    if (existingCartItem.Quantity + Quantity <= SelectedProduct.Quantity)
                    {
                        existingCartItem.Quantity += Quantity;
                    }
                    else
                    {
                        // The sum exceeds the maximum quantity, set the quantity to the maximum
                        MessageBox.Show("الكمية المدخلة تتجاوز الكمية المتاحة. تم تعيين الكمية إلى الحد الأقصى.");
                        existingCartItem.Quantity = SelectedProduct.Quantity;
                    }
                    existingCartItem.Earned = existingCartItem.Price - (existingCartItem.Cost * existingCartItem.Quantity);
                }
                else
                {
                    CartItemsList.Add(new CartItem
                    {
                        Id = SelectedProduct.Id,
                        Name = SelectedProduct.Name,
                        Category = SelectedProduct.Category.Name,
                        Quantity = Quantity,
                        Cost = SelectedProduct.Cost,
                        Price = SalePrice,
                        Type = SelectedProduct.Type,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                        Datex = DateTime.Now.ToString("yyyy-MM-dd"),
                        Barcode = SelectedProduct.Barcode,
                        Earned = SalePrice - (SelectedProduct.Cost * Quantity),
                        Details = Notes
                    });
                }
                RecalculateTotalAmount();

                //Quantity = 1;
                //SalePrice = SelectedProduct.Price; // You may need to adjust this based on your requirements

            }

        }


        private void ExecuteCancelCommand(object parameter)
        {
            // Add logic for CancelCommand
        }

        private void ExecuteDeleteCommand(object parameter)
        {
            // Add logic for DeleteCommand
        }

        #region CartListEvents
        private void ExecuteCartList_CurrentCellChangedCommand(object parameter)
        {
            // Handle CartList_CurrentCellChangedCommand logic here
        }

        private void ExecuteCartList_SelectionChangedCommand(object parameter)
        {
            // Handle CartList_SelectionChangedCommand logic here
        }

        private void ExecuteCartList_MouseDownCommand(object parameter)
        {
            // Handle CartList_MouseDownCommand logic here
        }

        private void ExecuteCartList_MouseDoubleClickCommand(object parameter)
        {
            // Handle CartList_MouseDoubleClickCommand logic here
        }

        private void ExecuteCartList_DataContextChangedCommand(object parameter)
        {
            // Handle CartList_DataContextChangedCommand logic here
        }

        private void ExecuteCartList_SelectedCellsChangedCommand(object parameter)
        {
            // Handle CartList_SelectedCellsChangedCommand logic here
        }


        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
