using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    public partial class Moving_Products_UserControl : UserControl
    {
        private MovingProductsViewModel viewModel;

        public Moving_Products_UserControl()
        {
            viewModel = new MovingProductsViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
