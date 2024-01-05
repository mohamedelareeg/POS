using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS.Validations
{
    public class DecimalTextBoxBehavior
    {
        public static readonly DependencyProperty AllowDecimalPointProperty =
            DependencyProperty.RegisterAttached("AllowDecimalPoint", typeof(bool), typeof(DecimalTextBoxBehavior), new PropertyMetadata(false, OnAllowDecimalPointChanged));

        public static bool GetAllowDecimalPoint(TextBox textBox)
        {
            return (bool)textBox.GetValue(AllowDecimalPointProperty);
        }

        public static void SetAllowDecimalPoint(TextBox textBox, bool value)
        {
            textBox.SetValue(AllowDecimalPointProperty, value);
        }

        private static void OnAllowDecimalPointChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += TextBox_PreviewTextInput;
                }
                else
                {
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                }
            }
        }

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                if (((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}
