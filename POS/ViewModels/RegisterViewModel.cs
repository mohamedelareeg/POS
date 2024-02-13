using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _username;
        private string _email;
        private SecureString _password;
        private SecureString _confirmPassword;

        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public SecureString ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            NavigateToLoginCommand = new ViewModelCommand(NavigateToLogin, CanNavigateToLogin);
        }

        private bool CanNavigateToLogin(object parameter)
        {
            // Add any conditions to enable/disable the navigation command
            return true; // For simplicity, always allow navigation to login
        }
        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email) ||
                Password == null || Password.Length < 3 ||
                ConfirmPassword == null || ConfirmPassword.Length < 3 || !IsPasswordsMatch())
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private async void ExecuteRegisterCommand(object obj)
        {
            string password = ConvertToUnsecureString(Password);
            string confirmPassword = ConvertToUnsecureString(ConfirmPassword);

            // Validate password and confirm password match
            if (!password.Equals(confirmPassword))
            {
                ErrorMessage = "كلمات المرور غير متطابقة";
                return;
            }

            // Validate username is not empty
            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "الرجاء إدخال اسم مستخدم صحيح";
                return;
            }

            // Validate email is not empty and in correct format
            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email))
            {
                ErrorMessage = "الرجاء إدخال عنوان بريد إلكتروني صحيح";
                return;
            }

            // Validate first name is not empty
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                ErrorMessage = "الرجاء إدخال الاسم الأول";
                return;
            }

            // Validate last name is not empty
            if (string.IsNullOrWhiteSpace(LastName))
            {
                ErrorMessage = "الرجاء إدخال اسم العائلة";
                return;
            }

            // Validate phone number is not empty and in correct format
            if (string.IsNullOrWhiteSpace(PhoneNumber) || !IsValidPhoneNumber(PhoneNumber))
            {
                ErrorMessage = "الرجاء إدخال رقم هاتف صحيح";
                return;
            }

            var userService = App.ServiceProvider.GetRequiredService<AuthenticationService>();

            // Attempt to register the user
            var result = await userService.RegisterUserAsync(Username, Email, password, FirstName, LastName, PhoneNumber);

            if (result.Succeeded)
            {
                NavigateToMain(true);
                // Handle successful registration
            }
            else
            {
                // Concatenate the errors into a single string for display
                ErrorMessage = string.Join(", ", result.Errors.Select(error => error.Description));
            }
        }
        // Helper method to validate phone number format
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Check if the phone number is null or empty
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            // Check if the phone number consists of digits only
            if (!phoneNumber.All(char.IsDigit))
            {
                return false;
            }

            // Check if the phone number has the correct length
            return phoneNumber.Length == 11;
        }


        public Action<bool> NavigateToLoginWindow { get; set; }
        public Action<bool> NavigateToMainWindow { get; set; }

        private void NavigateToLogin(object obj)
        {
            NavigateToLoginWindow?.Invoke(true);
        }

        // Method to navigate to main window
        private void NavigateToMain(object obj)
        {
            NavigateToMainWindow?.Invoke(true);
        }
        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsPasswordsMatch()
        {
            string password = ConvertToUnsecureString(Password);
            string confirmPassword = ConvertToUnsecureString(ConfirmPassword);

            return password.Equals(confirmPassword);
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
    }
}
