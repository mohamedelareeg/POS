using POS.ViewModels;
using System.Windows;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for POSWindow.xaml
    /// </summary>
    public partial class POSWindow : Window
    {
        private POSViewModel viewModel;

        public POSWindow()
        {
            viewModel = new POSViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
