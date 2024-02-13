using POS.ViewModels;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for POS_UserControl.xaml
    /// </summary>
    public partial class POS_UserControl : UserControl
    {
        private POSViewModel viewModel;

        public POS_UserControl()
        {
            viewModel = new POSViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
