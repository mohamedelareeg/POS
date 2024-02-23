using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static POS.Dialogs.ViewModels.AddCategoriesDialogViewModel;


namespace POS.Validations
{
    public class StateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (DialogState)value;
            return state == DialogState.Modify ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
