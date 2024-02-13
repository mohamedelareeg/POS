using POS.ViewModels;
using System.Windows;

namespace POS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCustomersDialog.xaml
    /// </summary>
    public partial class AddCustomersDialog : Window
    {
        public AddCustomersDialogViewModel viewModel;

        public AddCustomersDialog()
        {
            InitializeComponent();
            viewModel = new AddCustomersDialogViewModel();
            DataContext = viewModel;
        }
    }
}
