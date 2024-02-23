using Microsoft.EntityFrameworkCore;
using POS.Domain.Models;
using POS.Domain.Models.Products;
using POS.Persistence.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class ViewEditInvoiceViewModel
    {
        private int _invoiceId;
        public int InvoiceId
        {
            get { return _invoiceId; }
            set
            {
                _invoiceId = value;
                LoadInvoice();
                NotifyPropertyChanged(nameof(InvoiceId));
            }
        }
        private ObservableCollection<SaleProduct> _productList;
        public ObservableCollection<SaleProduct> ProductList
        {
            get { return _productList; }
            set
            {
                if (_productList != null)
                {
                    _productList.CollectionChanged -= ProductList_CollectionChanged;
                    foreach (var item in _productList)
                    {
                        item.PropertyChanged -= SaleProduct_PropertyChanged;
                    }
                }

                _productList = value;

                if (_productList != null)
                {
                    _productList.CollectionChanged += ProductList_CollectionChanged;
                    foreach (var item in _productList)
                    {
                        item.PropertyChanged += SaleProduct_PropertyChanged;
                    }
                }

                NotifyPropertyChanged(nameof(ProductList));
            }
        }


        private string _totalQuantity;
        public string TotalQuantity
        {
            get { return _totalQuantity; }
            set { _totalQuantity = value; NotifyPropertyChanged(nameof(TotalQuantity)); }
        }

        private string _subTotal;
        public string SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; NotifyPropertyChanged(nameof(SubTotal)); }
        }

        private string _taxPercentage;
        public string TaxPercentage
        {
            get { return _taxPercentage; }
            set
            {
                _taxPercentage = value;

                NotifyPropertyChanged(nameof(TaxPercentage));
                UpdateTotalValues();
            }
        }

        private string _discountPercentage;
        public string DiscountPercentage
        {
            get { return _discountPercentage; }
            set
            {
                _discountPercentage = value; NotifyPropertyChanged(nameof(DiscountPercentage));
                UpdateTotalValues();
            }
        }

        private string _total;
        public string Total
        {
            get { return _total; }
            set { _total = value; NotifyPropertyChanged(nameof(Total)); }
        }

        private ObservableCollection<string> _paymentMethods;
        public ObservableCollection<string> PaymentMethods
        {
            get { return _paymentMethods; }
            set { _paymentMethods = value; NotifyPropertyChanged(nameof(PaymentMethods)); }
        }

        private string _selectedPaymentMethod;
        public string SelectedPaymentMethod
        {
            get { return _selectedPaymentMethod; }
            set { _selectedPaymentMethod = value; NotifyPropertyChanged(nameof(SelectedPaymentMethod)); }
        }

        private bool _isAccountPaymentMode;
        public bool IsAccountPaymentMode
        {
            get { return _isAccountPaymentMode; }
            set { _isAccountPaymentMode = value; NotifyPropertyChanged(nameof(IsAccountPaymentMode)); }
        }

        private ObservableCollection<string> _customerAccounts;
        public ObservableCollection<string> CustomerAccounts
        {
            get { return _customerAccounts; }
            set { _customerAccounts = value; NotifyPropertyChanged(nameof(CustomerAccounts)); }
        }

        private string _selectedCustomerAccount;
        public string SelectedCustomerAccount
        {
            get { return _selectedCustomerAccount; }
            set { _selectedCustomerAccount = value; NotifyPropertyChanged(nameof(SelectedCustomerAccount)); }
        }
        // Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public AppDbContext _dbContext; // Add a reference to your DbContext

        public ViewEditInvoiceViewModel()
        {
            _dbContext = new AppDbContext();
            // Initialize properties and commands
            ProductList = new ObservableCollection<SaleProduct>();
            ProductList.CollectionChanged += ProductList_CollectionChanged;
            PaymentMethods = new ObservableCollection<string>();
            CustomerAccounts = new ObservableCollection<string>();

            // Initialize commands
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }
        private void ProductList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateTotalValues();
        }

        private void SaleProduct_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateTotalValues();
        }

        private void UpdateTotalValues()
        {
            TotalQuantity = ProductList.Sum(sp => sp.Quantity).ToString();
            NotifyPropertyChanged(nameof(TotalQuantity));
            SubTotal = ProductList.Sum(sp => sp.Quantity * sp.SalePrice).ToString();
            NotifyPropertyChanged(nameof(SubTotal));
            // Handle null values for TaxPercentage and DiscountPercentage
            decimal taxPercentageValue = decimal.TryParse(TaxPercentage, out decimal taxPercent) ? taxPercent : 0;
            decimal discountPercentageValue = decimal.TryParse(DiscountPercentage, out decimal discountPercent) ? discountPercent : 0;

            // Calculate tax and total based on parsed values
            var tax = (decimal.Parse(SubTotal) * (taxPercentageValue / 100)).ToString(); // Assuming tax is a percentage of SubTotal
            Total = (decimal.Parse(SubTotal) + decimal.Parse(tax) - (decimal.Parse(SubTotal) * (discountPercentageValue / 100))).ToString();

            // Notify property changed for each of the updated properties


            NotifyPropertyChanged(nameof(TaxPercentage));
            NotifyPropertyChanged(nameof(DiscountPercentage));
            NotifyPropertyChanged(nameof(Total));
        }

        private void LoadInvoice()
        {
            // Load and map the invoice data to the view model properties
            if (InvoiceId > 0)
            {

                // Load the invoice including its related SaleProducts
                var Invoice = _dbContext.Invoices
                    .Include(i => i.SaleProducts).ThenInclude(a => a.Product)
                    .FirstOrDefault(i => i.Id == InvoiceId);

                // Update view model properties based on the loaded invoice
                if (Invoice != null)
                {
                    TotalQuantity = Invoice.SaleProducts.Sum(sp => sp.Quantity).ToString();
                    SubTotal = Invoice.Subtotal.ToString();
                    TaxPercentage = Invoice.Tax.ToString();
                    DiscountPercentage = Invoice.Discount.ToString();
                    Total = Invoice.TotalPrice.ToString();
                    //SelectedPaymentMethod = Invoice.SelectedPaymentMethod;
                    //IsAccountPaymentMode = Invoice.IsAccountPaymentMode;
                    //SelectedCustomerAccount = Invoice.SelectedCustomerAccount;

                    // Update the ProductList with SaleProducts
                    ProductList = new ObservableCollection<SaleProduct>(
                        Invoice.SaleProducts.ToList());
                }

            }
        }
        // Method to save changes
        private void Save(object obj)
        {
            // Implement save logic here
        }

        // Method to cancel editing
        private void Cancel(object obj)
        {
            // Implement cancel logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
