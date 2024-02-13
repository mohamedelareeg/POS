using POS.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterViewModel viewModel;
        public RegisterWindow()
        {
            viewModel = new RegisterViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.NavigateToLoginWindow += NavigateToLoginWindow;
            viewModel.NavigateToMainWindow += NavigateToMainWindow;
        }
        private void NavigateToLoginWindow(bool obj)
        {
            var loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
        private void NavigateToMainWindow(bool parameter)
        {
            var mainWindow = new HomeWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Implement any login logic here if needed
        }
    }
}
