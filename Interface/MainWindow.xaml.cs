using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DbCalculatorСalorie.Models;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> list = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();

            SearchCategory searchCategory = new SearchCategory();
            
            listBoxProducts.ItemsSource = list;

            categories.Items.Add("Все");
            categories.Items.Add("Молочные продукты");
        }
        private void Button_AddProduct(object sender, RoutedEventArgs e) // Добавление продукта в категорию
        {
            AddProduct window_AddProduct = new AddProduct();
            window_AddProduct.categories.ItemsSource = categories.Items;

            window_AddProduct.categories.SelectedItem = window_AddProduct.categories.Items[0];
            window_AddProduct.ShowDialog();
        }

        private void Button_AddCategory(object sender, RoutedEventArgs e) // Добавление категории
        {
            AddCategory window_AddCategory = new AddCategory();
            window_AddCategory.ShowDialog();
        }

        private void AddProductForDay(object sender, MouseButtonEventArgs e) // Добавление продукта в дневной рацион
        {
            AddProductFromList window_AddProductFromList = new AddProductFromList();
            window_AddProductFromList.list = list;
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
                infoProduct.Name.Text = list[listBoxProducts.SelectedIndex].Name;
                infoProduct.Calories.Text = list[listBoxProducts.SelectedIndex].Calories.ToString();
                infoProduct.Protein.Text = list[listBoxProducts.SelectedIndex].Protein.ToString();
                infoProduct.Fats.Text = list[listBoxProducts.SelectedIndex].Fats.ToString();
                infoProduct.Carbohydrates.Text = list[listBoxProducts.SelectedIndex].Carbohydrates.ToString();
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
            List<Product> product = searchProduct.Search(searchTextBox.Text);
            list = product;
            listBoxProducts.ItemsSource = list;
            //product.
        }

        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
