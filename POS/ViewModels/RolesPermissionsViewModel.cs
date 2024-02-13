using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class RolesPermissionsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _roles;
        private string _selectedRole;

        public AuthenticationService authenticationService = App.ServiceProvider.GetRequiredService<AuthenticationService>();
        public ObservableCollection<string> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }
        private ObservableCollection<Permission> _permissions;

        public ObservableCollection<Permission> Permissions
        {
            get => _permissions;
            set
            {
                _permissions = value;
                OnPropertyChanged(nameof(Permissions));
            }
        }
        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                if (_selectedRole != null)
                {
                    // Reset all IsSelected properties to false
                    foreach (var permission in Permissions)
                    {
                        permission.IsSelected = false;
                        OnPropertyChanged(nameof(permission.IsSelected)); // Raise PropertyChanged for IsSelected
                    }

                    // Update IsSelected based on role claims
                    var roleClaims = authenticationService.GetRoleClaimsAsync(value).Result;
                    foreach (var claim in roleClaims)
                    {
                        var permission = Permissions.FirstOrDefault(p => p.Identifier == claim);

                        if (permission != null)
                        {
                            permission.IsSelected = true;
                            OnPropertyChanged(nameof(permission.IsSelected)); // Raise PropertyChanged for IsSelected
                        }
                    }

                }

                OnPropertyChanged(nameof(SelectedRole));
            }
        }


        public ICommand SavePermissionsCommand { get; }
        public RolesPermissionsViewModel()
        {
            // Initialize Roles and Permissions
            InitializeDataAsync();

            // Initialize the command
            SavePermissionsCommand = new RelayCommand(SavePermissions);
        }
        private async void SavePermissions(object obj)
        {
            // Convert the IEnumerable<string> to List<string>
            var selectedPermissions = GetSelectedPermissions().ToList();

            // Call the AuthenticationService to update role permissions
            await authenticationService.UpdateRolePermissionsAsync(SelectedRole, selectedPermissions);
        }

        private IEnumerable<string> GetSelectedPermissions()
        {
            foreach (var permission in Permissions)
            {
                if (permission.IsSelected)
                {
                    yield return permission.Identifier;
                }
            }
        }


        private async Task InitializeDataAsync()
        {
            Roles = await authenticationService.LoadRolesAsync();
            // Simulated data for demonstration purposes
            var permissions = new ObservableCollection<Permission>
    {
        new Permission { Identifier = "salesScreen", Name = "شاشة البيع", IsSelected = false },
        new Permission { Identifier = "salesInvoices", Name = "فواتير البيع", IsSelected = false },
        new Permission { Identifier = "inventory", Name = "المخزن", IsSelected = false },
        new Permission { Identifier = "purchaseGoods", Name = "شراء بضاعة", IsSelected = false },
        new Permission { Identifier = "goodsMovement", Name = "حركة بضاعة", IsSelected = false },
        new Permission { Identifier = "inventoryReport", Name = "تقرير المخزن", IsSelected = false },
        new Permission { Identifier = "purchaseInvoices", Name = "فواتير الشراء", IsSelected = false },
        new Permission { Identifier = "incoming", Name = "الوارد", IsSelected = false },
        new Permission { Identifier = "outgoing", Name = "الصادر", IsSelected = false },
        new Permission { Identifier = "treasuryReport", Name = "تقرير الخزينة", IsSelected = false },
        new Permission { Identifier = "customers", Name = "العملاء", IsSelected = false },
        new Permission { Identifier = "installments", Name = "الاقساط", IsSelected = false },
        new Permission { Identifier = "addCustomer", Name = "اضافة عميل", IsSelected = false },
        new Permission { Identifier = "suppliers", Name = "الموردين", IsSelected = false },
        new Permission { Identifier = "debts", Name = "المديونيات", IsSelected = false },
        new Permission { Identifier = "addSupplier", Name = "اضافة مورد", IsSelected = false },
        new Permission { Identifier = "addExpenses", Name = "اضافة مصاريف", IsSelected = false },
        new Permission { Identifier = "expensesReport", Name = "تقرير بالمصروفات", IsSelected = false },
        new Permission { Identifier = "accountSettings", Name = "اعدادات الحسابات", IsSelected = false },
        new Permission { Identifier = "systemSettings", Name = "اعدادات النظام", IsSelected = false },
        new Permission { Identifier = "backup", Name = "نسخ احتياطي", IsSelected = false }
    };

            Permissions = permissions;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        // Helper method for property change notification
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    // Permission class
    public class Permission : INotifyPropertyChanged
    {
        private bool _isSelected;

        public string Identifier { get; set; }
        public string Name { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
