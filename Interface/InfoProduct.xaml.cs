using Controller;
using DbCalculatorСalorie.Models;
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

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для InfoProduct.xaml
    /// </summary>
    public partial class InfoProduct : Window
    {
        Product product;
        public InfoProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
        }

        private void editProduck(object sender, RoutedEventArgs e)
        {
            EditProduct editProduct = new EditProduct();
            editProduct.Editing(product, int.Parse(Protein.Text), int.Parse(Carbohydrates.Text), int.Parse(Fats.Text));
            this.Close();
            
        }
    }
}
