using System.Globalization;
using System.Windows.Data;
using static POS.Dialogs.ViewModels.AddCategoriesDialogViewModel;

namespace POS.Validations
{
    public class StateToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (DialogState)value;
            return state != DialogState.Modify;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
