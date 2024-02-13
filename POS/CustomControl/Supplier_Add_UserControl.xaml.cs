using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class Supplier_Add_UserControl : UserControl
    {
        public AddSuppliersDialogViewModel viewModel;

        public Supplier_Add_UserControl()
        {
            InitializeComponent();
            viewModel = new AddSuppliersDialogViewModel();
            DataContext = viewModel;
        }
    }
}
