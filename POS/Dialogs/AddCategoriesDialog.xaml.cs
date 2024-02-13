using POS.Dialogs.ViewModels;
using System.Windows;

namespace POS.Dialogs
{
    /// <summary>
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class AddCategoriesDialog : Window
    {
        public AddCategoriesDialogViewModel viewModel;

        public AddCategoriesDialog()
        {
            InitializeComponent();
            viewModel = new AddCategoriesDialogViewModel();
            DataContext = viewModel;
        }
    }
}
