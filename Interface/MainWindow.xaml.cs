using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DbCalculatorСalorie.Models;
using Products.Search;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SearchCategory searchCategory = new SearchCategory();
        SearchProduct SearchProduct = new SearchProduct();
        public MainWindow()
        {
            InitializeComponent();
            categoriesList.ItemsSource = searchCategory.Search();
            listBoxProducts.ItemsSource = SearchProduct.Search("",0);


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
            AddProductFromList window_AddProductFromList = new AddProductFromList();
            //window_AddProductFromList.list = list;
            window_AddProductFromList.listProducts.ItemsSource = listBoxProducts.ItemsSource;
            window_AddProductFromList.ShowDialog();


            //Task.Run(() =>
            //{
            //    bool Is = false;
            //    DietForTheDay productDay = new DietForTheDay();
            //    while (Is == false)
            //    {
            //        this.Dispatcher.Invoke(() =>
            //        {
            //            try
            //            {
            //                if (window_AddProductFromList.IsClose == true)
            //                {
            //                    productDay.Name = ((Product)window_AddProductFromList.listProducts.SelectedItem).Name;
            //                    productDay.Weight = Convert.ToInt32(window_AddProductFromList.Weight.Text);
            //                    Is = true;
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //                Is = true;
            //            }

            //        });
            //    }
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (productDay.Name == list[i].Name)
            //        {
            //            productDay.Protein = list[i].Protein;
            //            productDay.Fats = list[i].Fats;
            //            productDay.Carbohydrates = list[i].Carbohydrates;
            //            productDay.Calories = list[i].Calories;
            //            this.Dispatcher.Invoke(() => { listBoxProductsForOneDay.Items.Add(productDay); });
            //        }
            //    }
            //});
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
               listBoxProducts.ItemsSource = SearchProduct.Search(searchTextBox.Text,(categoriesList.SelectedItem as Category).id);
        }
    }
}
