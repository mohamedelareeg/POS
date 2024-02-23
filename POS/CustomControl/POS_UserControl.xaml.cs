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

        private void ImageListBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void ImageListBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void ImageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ImageListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
