using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace POS.CustomControl
{
    /// <summary>
    /// Interaction logic for Customer_Add_UserControl.xaml
    /// </summary>
    public partial class Backup_UserControl : UserControl
    {
        private readonly string _dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "pos.db");

        public Backup_UserControl()
        {
            InitializeComponent();

        }
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "SQLite Database (*.db)|*.db";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.Copy(_dbFilePath, saveFileDialog.FileName, true);
                    MessageBox.Show("تم حفظ نسخة احتياطية بنجاح.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ نسخة الاحتياطية: {ex.Message}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "SQLite Database (*.db)|*.db";
                if (openFileDialog.ShowDialog() == true)
                {
                    File.Copy(openFileDialog.FileName, _dbFilePath, true);
                    MessageBox.Show("تم استعادة نسخة احتياطية بنجاح.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء استعادة نسخة الاحتياطية: {ex.Message}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
