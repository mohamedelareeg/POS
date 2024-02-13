using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    public partial class Purchase_Products_UserControl : UserControl
    {
        private PurchaseProductsViewModel viewModel;

        public Purchase_Products_UserControl()
        {
            viewModel = new PurchaseProductsViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
