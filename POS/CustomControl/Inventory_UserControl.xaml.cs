using POS.ViewModels;
using System.Windows.Controls;
using System.Windows.Data;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Inventory_UserControl.xaml
    /// </summary>
    public partial class Inventory_UserControl : UserControl
    {
        private InventoryViewModel viewModel;

        public Inventory_UserControl()
        {
            InitializeComponent();
            viewModel = new InventoryViewModel();
            DataContext = viewModel;
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty).UpdateSource();
            }
        }

        private void ProductsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
