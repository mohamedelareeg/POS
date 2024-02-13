using POS.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private InventoryViewModel viewModel;

        public InventoryWindow()
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
