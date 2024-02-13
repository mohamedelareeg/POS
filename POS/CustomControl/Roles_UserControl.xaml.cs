using POS.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class Roles_UserControl : UserControl
    {
        private RolesPermissionsViewModel viewModel;

        public Roles_UserControl()
        {
            viewModel = new RolesPermissionsViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                Permission permission = checkBox.DataContext as Permission;
                if (permission != null)
                {
                    permission.IsSelected = true;


                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                Permission permission = checkBox.DataContext as Permission;
                if (permission != null)
                {
                    permission.IsSelected = false;


                }
            }
        }


    }
}
