using POS.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginViewModel viewModel;



        public LoginView()
        {
            viewModel = new LoginViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.NavigateToRegisterWindow += NavigateToRegisterWindow;
            viewModel.NavigateToMainWindow += NavigateToMainWindow;
        }
        private void NavigateToRegisterWindow(bool parameter)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        // Method to navigate to MainWindow
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
