using DbCalculatorСalorie.Models;
using Products.Search;
using System.Windows;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            SearchCategory serch = new SearchCategory();
            categories.ItemsSource = serch.Search();
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            Product addProducts = new Product();
            if (categories.ItemsSource != null)
            {
                addProducts.AddProduct(productName.Text, int.Parse(productProtein.Text), int.Parse(productCarb.Text), int.Parse(productFats.Text), (categories.SelectedItem as Category).id,null);
            }
            this.Close();
        }
    }
}
