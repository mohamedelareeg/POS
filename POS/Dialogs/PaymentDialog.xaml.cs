using POS.ViewModels;
using System.Windows;

namespace POS
{
    /// <summary>
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class PaymentDialog : Window
    {
        public PaymentDialogViewModel viewModel;

        public PaymentDialog()
        {
            InitializeComponent();
            viewModel = new PaymentDialogViewModel();
            DataContext = viewModel;
        }
    }
}
