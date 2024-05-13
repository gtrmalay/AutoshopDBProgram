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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoshopDBProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Productsshow_click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void Manufacturersshow_click(object sender, RoutedEventArgs e)
        {
            Manufacturers manufacturers = new Manufacturers();
            manufacturers.Show();
            this.Hide();
        }

        private void Employeersshow_click(object sender, RoutedEventArgs e)
        {

        }

        private void Clientsshow_click(object sender, RoutedEventArgs e)
        {

        }

        private void Ordersshow_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
