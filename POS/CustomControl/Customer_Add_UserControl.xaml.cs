using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class Customer_Add_UserControl : UserControl
    {
        public AddCustomersDialogViewModel viewModel;

        public Customer_Add_UserControl()
        {
            InitializeComponent();
            viewModel = new AddCustomersDialogViewModel();
            DataContext = viewModel;
        }
    }
}
