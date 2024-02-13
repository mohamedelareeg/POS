using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class PaymentDialogViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _totalQuantity;
        private string _subTotal;
        private string _taxPercentage;
        private string _discountPercentage;
        private string _total;
        private ObservableCollection<string> _paymentMethods;
        private string _selectedPaymentMethod;
        private ObservableCollection<string> _customerAccounts;
        private string _selectedCustomerAccount;
        private bool _isAccountPaymentMode;


        private bool? _paymentResult;

        public bool? PaymentResult
        {
            get => _paymentResult;
            set
            {
                _paymentResult = value;
                OnPropertyChanged(nameof(PaymentResult));
            }
        }
        public string TotalQuantity
        {
            get => _totalQuantity;
            set
            {
                _totalQuantity = value;
                OnPropertyChanged(nameof(TotalQuantity));
            }
        }

        public string SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                OnPropertyChanged(nameof(SubTotal));
            }
        }

        public string TaxPercentage
        {
            get => _taxPercentage;
            set
            {
                _taxPercentage = value;
                OnPropertyChanged(nameof(TaxPercentage));
            }
        }

        public string DiscountPercentage
        {
            get => _discountPercentage;
            set
            {
                _discountPercentage = value;
                OnPropertyChanged(nameof(DiscountPercentage));
            }
        }

        public string Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public ObservableCollection<string> PaymentMethods
        {
            get => _paymentMethods;
            set
            {
                _paymentMethods = value;
                OnPropertyChanged(nameof(PaymentMethods));
            }
        }

        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                _selectedPaymentMethod = value;
                OnPropertyChanged(nameof(SelectedPaymentMethod));
                IsAccountPaymentMode = value == "على الحساب";
            }
        }

        public ObservableCollection<string> CustomerAccounts
        {
            get => _customerAccounts;
            set
            {
                _customerAccounts = value;
                OnPropertyChanged(nameof(CustomerAccounts));
            }
        }

        public string SelectedCustomerAccount
        {
            get => _selectedCustomerAccount;
            set
            {
                _selectedCustomerAccount = value;
                OnPropertyChanged(nameof(SelectedCustomerAccount));
            }
        }

        public bool IsAccountPaymentMode
        {
            get => _isAccountPaymentMode;
            set
            {
                _isAccountPaymentMode = value;
                OnPropertyChanged(nameof(IsAccountPaymentMode));
            }
        }

        public ICommand ProceedCommand { get; }
        public ICommand CancelCommand { get; }
        public PaymentDialogViewModel()
        {
            // Initialize commands
            ProceedCommand = new RelayCommand(Proceed);
            CancelCommand = new RelayCommand(Cancel);

            // Initialize properties
            PaymentMethods = new ObservableCollection<string>
            {
                "نقدى",
                "كارت",
                "على الحساب"
            };

            // Initialize other properties as needed
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Proceed(object parameter)
        {
            PaymentResult = true;
            System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)?.Close(); // Close the dialog
        }

        private void Cancel(object parameter)
        {
            PaymentResult = false;
            System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)?.Close(); // Close the dialog
        }

    }
}
