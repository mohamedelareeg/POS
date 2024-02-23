using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class CompanyInfo_UserControl : UserControl
    {
        public CompanyInfoDialogViewModel viewModel;

        public CompanyInfo_UserControl()
        {
            InitializeComponent();
            viewModel = new CompanyInfoDialogViewModel();
            DataContext = viewModel;
        }
    }
}
