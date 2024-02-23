using POS.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for POS_UserControl.xaml
    /// </summary>
    public partial class SalesHistory_UserControl : UserControl
    {
        private SalesHistoryViewModel viewModel;

        public SalesHistory_UserControl()
        {
            viewModel = new SalesHistoryViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.EditCommand.Execute(null);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteCommand.Execute(null);
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ViewCommand.Execute(null);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PrintCommand.Execute(null);
        }

        private void CartList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.ViewCommand.Execute(null);
        }
    }
}
