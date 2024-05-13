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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private Product _currentProduct = new Product();
        autoshopEntities bd = new autoshopEntities();
        public EditProduct(Product selectProduct)
        {
            InitializeComponent();
            if (selectProduct == null) return;
            _currentProduct = selectProduct;
            DataContext = _currentProduct;

        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
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

        private void BackToProducts_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Products products = new Products();
            products.Show();
        }
    }
}
