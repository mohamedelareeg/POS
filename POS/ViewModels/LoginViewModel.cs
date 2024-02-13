using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;


        //Properties
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

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

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        //Constructor

        public LoginViewModel()
        {

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
            NavigateToRegisterCommand = new ViewModelCommand(NavigateToRegister);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }


        private async void ExecuteLoginCommand(object obj)
        {

            string _password = ConvertToUnsecureString(Password);
            var authenticationService = App.ServiceProvider.GetRequiredService<AuthenticationService>();

            // var result = await _signInManager.PasswordSignInAsync(Username, _password, isPersistent: false, lockoutOnFailure: false);
            var result = await authenticationService.SignInAsync(Username, _password, true);

            if (result)
            {
                var roles = await authenticationService.GetUserRolesAsync();
                IsViewVisible = false;
                RaiseEventToNavigateToMainWindow(true);
            }
            else
            {
                ErrorMessage = "* اسم المستخدم أو كلمة المرور غير صالحة";

            }
        }
        public Action<bool> NavigateToRegisterWindow { get; set; }

        // Action to navigate to MainWindow
        public Action<bool> NavigateToMainWindow { get; set; }

        // Method to raise event to navigate to RegisterWindow
        private void NavigateToRegister(object obj)
        {
            NavigateToRegisterWindow?.Invoke(true);
        }

        // Method to raise event to navigate to MainWindow
        private void RaiseEventToNavigateToMainWindow(object obj)
        {
            NavigateToMainWindow?.Invoke(true);
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
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
