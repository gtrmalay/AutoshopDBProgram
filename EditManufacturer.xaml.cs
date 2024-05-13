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
    /// Логика взаимодействия для EditManufacturer.xaml
    /// </summary>
    public partial class EditManufacturer : Window
    {
        private Manufacturer _currentManufacturer = new Manufacturer();
        autoshopEntities bd = new autoshopEntities();
        public EditManufacturer(Manufacturer selectManufacturer)
        {
            InitializeComponent();
            if (selectManufacturer == null) return;
            _currentManufacturer = selectManufacturer;
            DataContext = _currentManufacturer;

        }

        private void BackToManufacturers_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manufacturers manufacturers = new Manufacturers();
            manufacturers.Show();
        }

        private void EditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                autoshopEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменение прошло успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Изменение прошло неудачно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
