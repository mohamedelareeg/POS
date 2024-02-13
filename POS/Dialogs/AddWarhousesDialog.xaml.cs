using POS.Dialogs.ViewModels;
using System.Windows;

namespace POS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddWarhousesDialog.xaml
    /// </summary>
    public partial class AddWarhousesDialog : Window
    {
        public AddWarehousesDialogViewModel viewModel;

        public AddWarhousesDialog()
        {
            InitializeComponent();
            viewModel = new AddWarehousesDialogViewModel();
            DataContext = viewModel;
        }
    }
}
