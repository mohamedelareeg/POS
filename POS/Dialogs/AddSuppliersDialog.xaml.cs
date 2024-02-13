using POS.ViewModels;
using System.Windows;

namespace POS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCustomersDialog.xaml
    /// </summary>
    public partial class AddSuppliersDialog : Window
    {
        public AddSuppliersDialogViewModel viewModel;

        public AddSuppliersDialog()
        {
            InitializeComponent();
            viewModel = new AddSuppliersDialogViewModel();
            DataContext = viewModel;
        }
    }
}
