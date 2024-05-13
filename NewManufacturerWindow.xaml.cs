using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoshopDBProgram
{
    /// <summary>
    /// Логика взаимодействия для NewManufacturerWindow.xaml
    /// </summary>
    public partial class NewManufacturerWindow : Window
    {
        private Manufacturer _currentManufacturer = new Manufacturer();
        public NewManufacturerWindow()
        {
            InitializeComponent();

            DataContext = _currentManufacturer;
        }

        private void BackToManufacturers_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manufacturers manufacturers = new Manufacturers();
            manufacturers.Show();
        }

        private void NewManufacturerAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                autoshopEntities.GetContext().Manufacturer.Add(_currentManufacturer);
                autoshopEntities.GetContext().SaveChanges();

                MessageBox.Show("Производитель успешно добавлен.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка при добавлении производителя: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении производителя: {ex.Message}");
                }
            }
        }
    }
}
