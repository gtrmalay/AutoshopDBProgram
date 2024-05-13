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
    /// Логика взаимодействия для NewProductWindow.xaml
    /// </summary>
    public partial class NewProductWindow : Window
    {
        private Product _currentProduct = new Product();
        
        public NewProductWindow()
        {
            InitializeComponent();

            DataContext = _currentProduct;

        }

        private void BackToProducts_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Products products = new Products();
            products.Show();
        }

        private void NewProductAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                autoshopEntities.GetContext().Product.Add(_currentProduct);
                autoshopEntities.GetContext().SaveChanges();

                MessageBox.Show("Продукт успешно добавлен.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка при добавлении продукта: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении продукта: {ex.Message}");
                }
            }
        }

    }
}
