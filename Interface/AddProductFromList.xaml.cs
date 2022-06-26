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
using DbCalculatorСalorie.Models;
using Search;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для AddProductFromList.xaml
    /// </summary>
    public partial class AddProductFromList : Window
    {
        public bool IsClose = false;
        public List<Product> list = new List<Product>();
        public AddProductFromList()
        {
            InitializeComponent();
        }

        private void Button_AddProductForDayClick(object sender, RoutedEventArgs e)
        {
            if(Weight.Text.Trim() != "")
            {
                IsClose = true;
                this.Close();
            }
            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchProduct searchProduct = new SearchProduct();
            List<Product> product = searchProduct.Search(searchTextBox.Text);
            list = product;
            listProducts.ItemsSource = list;
        }
    }
}
