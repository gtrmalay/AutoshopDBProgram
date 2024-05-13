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
    /// Логика взаимодействия для Manufacturers.xaml
    /// </summary>
    public partial class Manufacturers : Window
    {
        public Manufacturers()
        {
            InitializeComponent();
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Manufacturer.ToList();
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Manufacturer.OrderBy(x => x.Manufacturer_ID).ToList();
        }

        private void NewManufacturer_Click(object sender, RoutedEventArgs e)
        {
            NewManufacturerWindow newManufacturerWindow = new NewManufacturerWindow();
            newManufacturerWindow.Show();
            this.Hide();
        }

        private void EditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAutoshop.SelectedItem != null)
            {
                var item = (Manufacturer)DataGridAutoshop.SelectedItem;
                new EditManufacturer(item).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteManufacturer_Click(object sender, RoutedEventArgs e)
        {
            var manufacturerRemoving = DataGridAutoshop.SelectedItems.Cast<Manufacturer>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить эту запись?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
            MessageBoxResult.Yes) return;

            autoshopEntities.GetContext().Manufacturer.RemoveRange(manufacturerRemoving);
            autoshopEntities.GetContext().SaveChanges();

            MessageBox.Show("Удаление завершено успешно.");
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Manufacturer.OrderBy(x => x.Manufacturer_ID).ToList();
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
    }
}
