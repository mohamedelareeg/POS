using POS.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _storeName;
        public string StoreName
        {
            get { return _storeName; }
            set
            {
                if (_storeName != value)
                {
                    _storeName = value;
                    OnPropertyChanged(nameof(StoreName));
                }
            }
        }

        public ICommand SettingsCommand { get; }
        public ICommand PurchaseCommand { get; }
        public ICommand CustomersCommand { get; }
        public ICommand SellsCommand { get; }
        public ICommand BankCommand { get; }
        public ICommand InventoryCommand { get; }
        public ICommand POSCommand { get; }

        public MainViewModel()
        {
            StoreName = "ARP-POS";
            SettingsCommand = new RelayCommand(ExecuteSettingsCommand);
            PurchaseCommand = new RelayCommand(ExecutePurchaseCommand);
            CustomersCommand = new RelayCommand(ExecuteCustomersCommand);
            SellsCommand = new RelayCommand(ExecuteSellsCommand);
            BankCommand = new RelayCommand(ExecuteBankCommand);
            InventoryCommand = new RelayCommand(ExecuteInventoryCommand);
            POSCommand = new RelayCommand(ExecutePOSCommand);
        }

        private void ExecuteSettingsCommand(object parameter)
        {
            // Open Settings Window
            OpenWindow(new SettingsWindow());
        }

        private void ExecutePurchaseCommand(object parameter)
        {
            // Open Purchase Window
            OpenWindow(new PurchaseWindow());
        }

        private void ExecuteCustomersCommand(object parameter)
        {
            // Open Customers Window
            OpenWindow(new CustomersWindow());
        }

        private void ExecuteSellsCommand(object parameter)
        {
            // Open Sells Window
            OpenWindow(new SellsWindow());
        }

        private void ExecuteBankCommand(object parameter)
        {
            // Open Bank Window
            OpenWindow(new BankWindow());
        }

        private void ExecuteInventoryCommand(object parameter)
        {
            // Open Inventory Window
            OpenWindow(new InventoryWindow());
        }

        private void ExecutePOSCommand(object parameter)
        {
            // Open POS Window
            OpenWindow(new POSWindow());
        }

        private void OpenWindow(Window window)
        {
            window.Owner = App.Current.MainWindow;
            window.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);
    }
}
