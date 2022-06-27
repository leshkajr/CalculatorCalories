using System.Windows;
using System.Windows.Controls;
using Controller;
using DbCalculatorСalorie.Models;
using Products.Search;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для AddProductFromList.xaml
    /// </summary>
    public partial class AddProductFromList : Window
    {
        public bool IsClose = false;
        DietForTheDay dietForTheDay = new DietForTheDay();
        SearchProductFilter searchProduct = new SearchProductFilter();
        User user;
        public AddProductFromList(User user)
        {
            InitializeComponent();
            this.user = user;
            listProducts.ItemsSource = searchProduct.Search(searchTextBox.Text);
        }

        private void Button_AddProductForDayClick(object sender, RoutedEventArgs e)
        {
            Product newProduct=listProducts.SelectedItem as Product;
            newProduct.Weight = int.Parse(Weight.Text);
            AddDietForTheDay addDietForTheDay = new AddDietForTheDay();
            addDietForTheDay.AddProduct("", 0, 0, 0, 0, newProduct, user);
            if(Weight.Text.Trim() != "")
            {
                IsClose = true;
                this.Close();
            }
            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            listProducts.ItemsSource = searchProduct.Search(searchTextBox.Text);
        }
    }
}
