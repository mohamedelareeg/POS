using Microsoft.Extensions.DependencyInjection;
using POS.Persistence.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class UserMangmentViewModel : INotifyPropertyChanged
    {


        public AuthenticationService authenticationService = App.ServiceProvider.GetRequiredService<AuthenticationService>();

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
                }
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        private SecureString _password;
        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private ObservableCollection<string> _roles;
        public ObservableCollection<string> Roles
        {
            get { return _roles; }
            set { _roles = value; OnPropertyChanged(nameof(Roles)); }
        }

        private string _selectedRole;
        public string SelectedRole
        {
            get { return _selectedRole; }
            set { _selectedRole = value; OnPropertyChanged(nameof(SelectedRole)); }
        }

        private ObservableCollection<ApplicationUser> _itemList;
        public ObservableCollection<ApplicationUser> ItemList
        {
            get { return _itemList; }
            set { _itemList = value; OnPropertyChanged(nameof(ItemList)); }
        }


        private ApplicationUser _selectedItem;
        public ApplicationUser SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    UserName = _selectedItem.UserName;
                    Email = _selectedItem.Email;
                    FirstName = _selectedItem.FirstName;
                    LastName = _selectedItem.LastName;
                    PhoneNumber = _selectedItem.PhoneNumber;
                    SelectedRole = _selectedItem.DefaultRole != null ? _selectedItem.DefaultRole : authenticationService.GetSelectedRoleForUserAsync(_selectedItem.UserName).Result; // You need to implement this method
                                                                                                                                                                                     // Update the current state to Modify when an item is selected
                    CurrentState = DialogState.Modify;
                }
                else
                {
                    // Clear the properties when no item is selected
                    UserName = string.Empty;
                    Email = string.Empty;
                    FirstName = string.Empty;
                    LastName = string.Empty;
                    PhoneNumber = string.Empty;
                    SelectedRole = null;
                    Password = new SecureString();
                    // Update the current state to Add when no item is selected
                    CurrentState = DialogState.Add;
                }
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand EditItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }
        public ICommand FinishCommand { get; private set; }

        public ICommand CancelCommand { get; set; }

        public UserMangmentViewModel()
        {
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            EditItemCommand = new RelayCommand(EditItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            FinishCommand = new RelayCommand(Finish);
            CancelCommand = new RelayCommand(Cancel);
            // Initialize Roles and Permissions
            InitializeDataAsync();

        }
        private void Cancel(object parameter)
        {
            SelectedItem = null;
            //UserName = string.Empty;
            //Email = string.Empty;
            //FirstName = string.Empty;
            //LastName = string.Empty;
            //PhoneNumber = string.Empty;
            //SelectedRole = null;
            //Password = new SecureString();
            //// Update the current state to Add when no item is selected
            //CurrentState = DialogState.Add;
        }
        private async Task InitializeDataAsync()
        {
            Roles = await authenticationService.LoadRolesAsync();
            // Load all users from the service
            var users = await authenticationService.GetAllUsersAsync();

            // Populate the ItemList with the loaded users
            ItemList = new ObservableCollection<ApplicationUser>(users);
        }
        private async Task<bool> UserExistsAsync(string userName)
        {
            // Check if a user with the given username exists
            var user = await authenticationService.GetUserByNameAsync(userName);

            // If the user is not null, it means the user exists
            return user != null;
        }

        private async void Add(object parameter)
        {
            CurrentState = DialogState.Add;

            if (string.IsNullOrWhiteSpace(UserName))
            {
                MessageBox.Show("يرجى توفير اسم المستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedRole))
            {
                MessageBox.Show("يرجى تحديد دور للمستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if the user already exists
            if (await UserExistsAsync(UserName))
            {
                MessageBox.Show("اسم المستخدم موجود بالفعل.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string _password = ConvertToUnsecureString(Password);
            // Add the new user
            var result = await authenticationService.AddUserAsync(UserName, Email, _password, FirstName, LastName, PhoneNumber, SelectedRole);

            if (result.Succeeded)
            {
                // Assign the selected role to the user
                var roleResult = await authenticationService.AddUserToRoleAsync(UserName, SelectedRole);
                if (roleResult.Succeeded)
                {
                    // Notify the user about successful user creation
                    MessageBox.Show("تمت إضافة المستخدم بنجاح وتعيين الدور.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Reload user list
                    InitializeDataAsync();
                }
                else
                {
                    // Notify the user about role assignment failure
                    MessageBox.Show("فشل تعيين الدور للمستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Notify the user about user creation failure
                MessageBox.Show("فشلت عملية إضافة المستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Clear the input fields
            UserName = string.Empty;
            Email = string.Empty;
            Password = new SecureString();
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
        }

        private async void Edit(object parameter)
        {
            if (SelectedItem != null)
            {
                // Check if the selected item is the admin account
                if (SelectedItem.UserName == "admin@arp.com")
                {
                    MessageBox.Show("لا يمكن تعديل حساب المسؤول.", "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(UserName))
                {
                    MessageBox.Show("يرجى توفير اسم المستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(SelectedRole))
                {
                    MessageBox.Show("يرجى تحديد دور للمستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                // Edit the user
                var result = await authenticationService.EditUserAsync(SelectedItem.Id, UserName, Email, FirstName, LastName, PhoneNumber, SelectedRole);

                if (result.Succeeded)
                {
                    // Assign the selected role to the user
                    var roleResult = await authenticationService.AddUserToRoleAsync(SelectedItem.UserName, SelectedRole);
                    if (roleResult.Succeeded)
                    {
                        // Notify the user about successful user edit
                        MessageBox.Show("تم تعديل بيانات المستخدم بنجاح وتعيين الدور.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Reload user list
                        InitializeDataAsync();
                    }
                    else
                    {
                        // Notify the user about role assignment failure
                        MessageBox.Show("فشل تعيين الدور للمستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Notify the user about user edit failure
                    MessageBox.Show("فشلت عملية تعديل بيانات المستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private async void DeleteItem(object parameter)
        {
            if (SelectedItem != null)
            {
                // Check if the selected item is the admin account
                if (SelectedItem.UserName == "admin@arp.com")
                {
                    MessageBox.Show("لا يمكن حذف حساب المسؤول.", "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("هل أنت متأكد من رغبتك في حذف المستخدم؟", "تأكيد الحذف", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    // Delete the user
                    var deleteResult = await authenticationService.DeleteUserAsync(SelectedItem.UserName);

                    if (deleteResult.Succeeded)
                    {
                        // Notify the user about successful user deletion
                        MessageBox.Show("تم حذف المستخدم بنجاح.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Remove the deleted user from the ItemList
                        ItemList.Remove(SelectedItem);
                    }
                    else
                    {
                        // Notify the user about user deletion failure
                        MessageBox.Show("فشلت عملية حذف المستخدم.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


        private void EditItem(object parameter)
        {
            if (SelectedItem != null)
            {
                // Set the dialog state to modify
                CurrentState = DialogState.Modify;

                // Populate the input fields with the details of the selected user
                UserName = SelectedItem.UserName;
                Email = SelectedItem.Email;
                FirstName = SelectedItem.FirstName;
                LastName = SelectedItem.LastName;
                PhoneNumber = SelectedItem.PhoneNumber;
                SelectedRole = _selectedItem.DefaultRole != null ? _selectedItem.DefaultRole : authenticationService.GetSelectedRoleForUserAsync(_selectedItem.UserName).Result; // You need to implement this method

            }
        }



        private void Finish(object parameter)
        {
            //Result = true;
            System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)?.Close();


        }

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                return string.Empty;

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Helper method for property change notification
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }





}
