using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DbCalculatorСalorie.Models;
using Nutrient.Calculator;
using Products.Search;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SearchCategory searchCategory = new SearchCategory();
        SearchProduct searchProduct = new SearchProduct();
        SerchDiertForTheDay serchDiertForTheDay = new SerchDiertForTheDay();
        CountingCaloriesForTheDay countingCaloriesForTheDay = new CountingCaloriesForTheDay();
        List<Product> productsDiertForTheDay;
        User user;
        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            categoriesList.ItemsSource = searchCategory.Search();
            listBoxProducts.ItemsSource = searchProduct.Search("",0);
            productsDiertForTheDay = serchDiertForTheDay.Search(user);
            if (productsDiertForTheDay != null)
            {
                listBoxProductsForOneDay.ItemsSource = productsDiertForTheDay;
                inputAllNutritionDay(countingCaloriesForTheDay.NutrientCount(productsDiertForTheDay));
            }

        }
        private void Button_AddProduct(object sender, RoutedEventArgs e) // Добавление продукта в категорию
        {
            AddProduct window_AddProduct = new AddProduct();
            //window_AddProduct.categories.ItemsSource = categories.Items;

            window_AddProduct.categories.SelectedItem = window_AddProduct.categories.Items[0];
            window_AddProduct.ShowDialog();
        }

        private void Button_AddCategory(object sender, RoutedEventArgs e) // Добавление категории
        {
            AddCategory window_AddCategory = new AddCategory();
            window_AddCategory.ShowDialog();
            categoriesList.ItemsSource = searchCategory.Search();
            //listBoxProducts.ItemsSource = list;
        }

        private void AddProductForDay(object sender, MouseButtonEventArgs e) // Добавление продукта в дневной рацион
        {
            AddProductFromList window_AddProductFromList = new AddProductFromList(user);
            window_AddProductFromList.listProducts.ItemsSource = listBoxProducts.ItemsSource;
            window_AddProductFromList.ShowDialog();
            productsDiertForTheDay = serchDiertForTheDay.Search(user);
            if (productsDiertForTheDay != null)
            {
                listBoxProductsForOneDay.ItemsSource = productsDiertForTheDay;
                inputAllNutritionDay(countingCaloriesForTheDay.NutrientCount(productsDiertForTheDay));
            }
        }

        private void ResetProductForDay(object sender, MouseButtonEventArgs e) // Удаление всех продуктов из дневного рациона
        {
            listBoxProductsForOneDay.Items.Clear();
        }

        private void Button_ExitClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }


        private void listBoxProducts_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                InfoProduct infoProduct = new InfoProduct();
                infoProduct.Name.Text = (listBoxProducts.SelectedItem as Product).Name;
                infoProduct.Calories.Text = (listBoxProducts.SelectedItem as Product).Calories.ToString();
                infoProduct.Protein.Text = (listBoxProducts.SelectedItem as Product).Protein.ToString();
                infoProduct.Fats.Text = (listBoxProducts.SelectedItem as Product).Fats.ToString();
                infoProduct.Carbohydrates.Text = (listBoxProducts.SelectedItem as Product).Carbohydrates.ToString();
                infoProduct.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchProduct searchProduct = new SearchProduct();
            if (categoriesList.SelectedItem !=null)
            {
                listBoxProducts.ItemsSource = searchProduct.Search(searchTextBox.Text, (categoriesList.SelectedItem as Category).id);
            }
            else
            {
                listBoxProducts.ItemsSource = searchProduct.Search(searchTextBox.Text, 0);
            }
            //list = product;
            //listBoxProducts.ItemsSource = list;
            //product.
        }
        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               listBoxProducts.ItemsSource = searchProduct.Search(searchTextBox.Text,(categoriesList.SelectedItem as Category).id);
        }

        public void inputAllNutritionDay(Product product)
        {
            allProtein.Text = product.Protein.ToString();
            allCarb.Text = product.Carbohydrates.ToString();
            allFats.Text = product.Fats.ToString();
            allCalories.Text = product.Calories.ToString();
            allWeigth.Text = product.Weight.ToString();
        }
    }
}
