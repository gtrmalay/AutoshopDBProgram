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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoshopDBProgram
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
       
        public Products()
        {
            InitializeComponent();
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Product.ToList();
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Product.OrderBy(x => x.Product_ID).ToList();

        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProductWindow newProductWindow = new NewProductWindow();
            newProductWindow.Show();
            this.Hide();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var productRemoving = DataGridAutoshop.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить эту запись?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
           MessageBoxResult.Yes) return;

            autoshopEntities.GetContext().Product.RemoveRange(productRemoving);
            autoshopEntities.GetContext().SaveChanges();

            MessageBox.Show("Удаление завершено успешно.");
            DataGridAutoshop.ItemsSource = autoshopEntities.GetContext().Product.OrderBy(x => x.Product_ID).ToList();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAutoshop.SelectedItem != null)
            {
                var item = (Product)DataGridAutoshop.SelectedItem;
                new EditProduct(item).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
