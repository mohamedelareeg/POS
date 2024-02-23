using POS.ViewModels;
using System.Windows;

namespace POS.Dialogs
{
    /// <summary>
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class ViewEditInvoiceDialog : Window
    {
        public ViewEditInvoiceViewModel viewModel;

        public ViewEditInvoiceDialog()
        {
            InitializeComponent();
            viewModel = new ViewEditInvoiceViewModel();
            DataContext = viewModel;
        }
    }
}
