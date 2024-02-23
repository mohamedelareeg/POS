using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class Users_UserControl : UserControl
    {
        private UserMangmentViewModel viewModel;

        public Users_UserControl()
        {
            viewModel = new UserMangmentViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }




    }
}
