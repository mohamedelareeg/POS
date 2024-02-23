using Microsoft.EntityFrameworkCore;
using POS.Dialogs;
using POS.Domain.Models;
using POS.Persistence.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class SalesHistoryViewModel : INotifyPropertyChanged
    {

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        private ObservableCollection<Warehouse> _warehouses;
        public ObservableCollection<Warehouse> Warehouses
        {
            get { return _warehouses; }
            set
            {
                if (_warehouses != value)
                {
                    _warehouses = value;
                    OnPropertyChanged(nameof(Warehouses));
                }
            }
        }


        private Warehouse _selectedWarehouse;
        public Warehouse SelectedWarehouse
        {
            get { return _selectedWarehouse; }
            set
            {
                if (_selectedWarehouse != value)
                {
                    _selectedWarehouse = value;
                    OnPropertyChanged(nameof(SelectedWarehouse));
                }
            }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (_customers != value)
                {
                    _customers = value;
                    OnPropertyChanged(nameof(Customers));
                }
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
        }

        private ObservableCollection<PaymentStatus> _paymentStatusOptions;
        public ObservableCollection<PaymentStatus> PaymentStatusOptions
        {
            get { return _paymentStatusOptions; }
            set
            {
                if (_paymentStatusOptions != value)
                {
                    _paymentStatusOptions = value;
                    OnPropertyChanged(nameof(PaymentStatusOptions));
                }
            }
        }

        private string _selectedPaymentStatus;
        public string SelectedPaymentStatus
        {
            get { return _selectedPaymentStatus; }
            set
            {
                if (_selectedPaymentStatus != value)
                {
                    _selectedPaymentStatus = value;
                    OnPropertyChanged(nameof(SelectedPaymentStatus));
                }
            }
        }

        private ObservableCollection<string> _salespersons;
        public ObservableCollection<string> Salespersons
        {
            get { return _salespersons; }
            set
            {
                if (_salespersons != value)
                {
                    _salespersons = value;
                    OnPropertyChanged(nameof(Salespersons));
                }
            }
        }

        private string _selectedSalesperson;
        public string SelectedSalesperson
        {
            get { return _selectedSalesperson; }
            set
            {
                if (_selectedSalesperson != value)
                {
                    _selectedSalesperson = value;
                    OnPropertyChanged(nameof(SelectedSalesperson));
                }
            }
        }

        private ObservableCollection<DeliveryStatus> _deliveryStatusOptions;
        public ObservableCollection<DeliveryStatus> DeliveryStatusOptions
        {
            get { return _deliveryStatusOptions; }
            set
            {
                if (_deliveryStatusOptions != value)
                {
                    _deliveryStatusOptions = value;
                    OnPropertyChanged(nameof(DeliveryStatusOptions));
                }
            }
        }

        private string _selectedDeliveryStatus;
        public string SelectedDeliveryStatus
        {
            get { return _selectedDeliveryStatus; }
            set
            {
                if (_selectedDeliveryStatus != value)
                {
                    _selectedDeliveryStatus = value;
                    OnPropertyChanged(nameof(SelectedDeliveryStatus));
                }
            }
        }

        private ObservableCollection<PaymentMethod> _paymentMethodOptions;
        public ObservableCollection<PaymentMethod> PaymentMethodOptions
        {
            get { return _paymentMethodOptions; }
            set
            {
                if (_paymentMethodOptions != value)
                {
                    _paymentMethodOptions = value;
                    OnPropertyChanged(nameof(PaymentMethodOptions));
                }
            }
        }

        private PaymentMethod _selectedPaymentMethod;
        public PaymentMethod SelectedPaymentMethod
        {
            get { return _selectedPaymentMethod; }
            set
            {
                if (_selectedPaymentMethod != value)
                {
                    _selectedPaymentMethod = value;
                    OnPropertyChanged(nameof(SelectedPaymentMethod));
                }
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        private int _page;
        public int Page
        {
            get { return _page; }
            set
            {
                if (_page != value)
                {
                    _page = value;
                    OnPropertyChanged(nameof(Page));
                }
            }
        }

        private ObservableCollection<int> _pageSizeOptions;
        public ObservableCollection<int> PageSizeOptions
        {
            get { return _pageSizeOptions; }
            set
            {
                if (_pageSizeOptions != value)
                {
                    _pageSizeOptions = value;
                    LoadData();
                    OnPropertyChanged(nameof(PageSizeOptions));
                }
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    OnPropertyChanged(nameof(PageSize));
                }
            }
        }
        private ObservableCollection<Invoice> _itemList;
        public ObservableCollection<Invoice> ItemList
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


        private Invoice _selectedItem;
        public Invoice SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private int _totalItems;
        public int TotalItems
        {
            get { return _totalItems; }
            set
            {
                if (_totalItems != value)
                {
                    _totalItems = value;
                    OnPropertyChanged(nameof(TotalItems));
                }
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand PrevPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }



        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ViewCommand { get; }
        public ICommand PrintCommand { get; }

        public AppDbContext _dbContext; // Add a reference to your DbContext

        public SalesHistoryViewModel()
        {
            // Initialize DbContext
            _dbContext = new AppDbContext();

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Warehouses = new ObservableCollection<Warehouse>();
            Customers = new ObservableCollection<Customer>();

            Salespersons = new ObservableCollection<string>();
            PaymentStatusOptions = new ObservableCollection<PaymentStatus>(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>());
            DeliveryStatusOptions = new ObservableCollection<DeliveryStatus>(Enum.GetValues(typeof(DeliveryStatus)).Cast<DeliveryStatus>());
            PaymentMethodOptions = new ObservableCollection<PaymentMethod>(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>());
            SearchText = string.Empty;
            Page = 1;
            PageSizeOptions = new ObservableCollection<int> { 10, 20, 50, 100, 200 };
            PageSize = 10;
            ItemList = new ObservableCollection<Invoice>();

            // Initialize commands
            RefreshCommand = new RelayCommand(Refresh);
            SearchCommand = new RelayCommand(Search);
            PrevPageCommand = new RelayCommand(PrevPage);
            NextPageCommand = new RelayCommand(NextPage);
            LoadWarehouses();
            LoadCustomers();
            LoadData();

            CanEdit = true;
            CanDelete = true;
            CanView = true;
            CanPrint = true;

            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            ViewCommand = new RelayCommand(View);
            PrintCommand = new RelayCommand(Print);
        }
        private void Delete(object parameter)
        {

            if (SelectedItem != null)
            {
                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العنصر؟", "تأكيد", MessageBoxButton.YesNo, MessageBoxImage.Question);

                // Check the user's response
                if (result == MessageBoxResult.Yes)
                {


                }
            }
        }
        private void Print(object parameter)
        {

            if (SelectedItem != null)
            {
                // Print the selected item
                // Example: PrintDialog printDialog = new PrintDialog();
                // Show print dialog and proceed with printing
            }
        }

        private void Edit(object parameter)
        {

            if (SelectedItem != null)
            {
                ViewEditInvoiceDialog dialog = new ViewEditInvoiceDialog();
                dialog.viewModel.InvoiceId = SelectedItem.Id;
                // Show the dialog as a modal window
                bool? resultDialog = dialog.ShowDialog();

                // Check the result of the dialog
                if (resultDialog.HasValue)
                {


                }
            }
        }

        private void View(object parameter)
        {

            if (SelectedItem != null)
            {
                ViewEditInvoiceDialog dialog = new ViewEditInvoiceDialog();
                dialog.viewModel.InvoiceId = SelectedItem.Id;
                // Show the dialog as a modal window
                bool? resultDialog = dialog.ShowDialog();

                // Check the result of the dialog
                if (resultDialog.HasValue)
                {


                }
            }
        }

        private bool _canEdit;
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                if (_canEdit != value)
                {
                    _canEdit = value;
                    OnPropertyChanged(nameof(CanEdit));
                }
            }
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    OnPropertyChanged(nameof(CanDelete));
                }
            }
        }

        private bool _canView;
        public bool CanView
        {
            get { return _canView; }
            set
            {
                if (_canView != value)
                {
                    _canView = value;
                    OnPropertyChanged(nameof(CanView));
                }
            }
        }

        private bool _canPrint;
        public bool CanPrint
        {
            get { return _canPrint; }
            set
            {
                if (_canPrint != value)
                {
                    _canPrint = value;
                    OnPropertyChanged(nameof(CanPrint));
                }
            }
        }

        // Method to load data
        private void LoadData()
        {
            IQueryable<Invoice> query = _dbContext.Invoices.Include(a => a.Customer).Include(a => a.Warehouse);

            // Apply filters based on selected options
            if (SelectedWarehouse != null)
            {
                query = query.Where(i => i.WarehouseId == SelectedWarehouse.Id);
            }
            if (SelectedCustomer != null)
            {
                query = query.Where(i => i.CustomerId == SelectedCustomer.Id);
            }
            //if (!string.IsNullOrEmpty(SelectedPaymentStatus))
            //{
            //    var paymentStatus = Enum.Parse<PaymentStatus>(SelectedPaymentStatus);
            //    query = query.Where(i => i.PaymentStatus == paymentStatus);
            //}
            //if (!string.IsNullOrEmpty(SelectedSalesperson))
            //{
            //    query = query.Where(i => i.Salesperson == SelectedSalesperson);
            //}
            //if (!string.IsNullOrEmpty(SelectedDeliveryStatus))
            //{
            //    var deliveryStatus = Enum.Parse<DeliveryStatus>(SelectedDeliveryStatus);
            //    query = query.Where(i => i.DeliveryStatus == deliveryStatus);
            //}
            //if (SelectedPaymentMethod != null)
            //{
            //    query = query.Where(i => i.PaymentMethod == SelectedPaymentMethod);
            //}
            if (!string.IsNullOrEmpty(SearchText))
            {
                query = query.Where(i => i.Number.Contains(SearchText)); // Adjust as per your search criteria
            }
            if (!string.IsNullOrEmpty(StartDate.ToString()) && !string.IsNullOrEmpty(EndDate.ToString()))
            {

                // Apply the date filter
                query = query.Where(i => i.Date >= StartDate && i.Date <= EndDate);
            }
            // Get the total count of items
            TotalItems = query.Count();

            // Apply pagination
            query = query.Skip((Page - 1) * PageSize).Take(PageSize);

            // Execute the query and update the ItemList
            ItemList = new ObservableCollection<Invoice>(query.ToList());
        }

        private void LoadWarehouses()
        {
            IQueryable<Warehouse> query = _dbContext.Warehouses; // Initial query

            ObservableCollection<Warehouse> warehouses = new ObservableCollection<Warehouse>(query.ToList());

            Warehouses = warehouses;
            //if (Warehouses != null && Warehouses.Count > 0)
            //{
            //    SelectedWarehouse = Warehouses.FirstOrDefault();
            //}
        }
        private void LoadCustomers()
        {
            IQueryable<Customer> query = _dbContext.Customers; // Initial query

            ObservableCollection<Customer> customers = new ObservableCollection<Customer>(query.ToList());

            Customers = customers;
        }
        // Command methods
        private void Refresh(object parameter)
        {
            LoadData();
        }

        private void Search(object parameter)
        {
            LoadData();
        }

        private void NextPage(object parameter)
        {
            if (Page < TotalPages)
            {
                Page++;
                LoadData();
            }
        }

        private void PrevPage(object parameter)
        {
            if (Page > 1)
            {
                Page--;
                LoadData();
            }
        }

        private int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Overdue
    }

    public enum DeliveryStatus
    {
        Pending,
        Shipped,
        Delivered
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        BankTransfer
    }

}
