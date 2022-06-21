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

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public Product()
        {
            this.Name = "";
            this.Calories = 0;
        }
        public Product(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        //public override string ToString()
        //{
        //    return Name + " " + Calories + " ккал";
        //}
    }

    public class ProductDay : Product
    {
        public int Weight { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Product> list = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();

            list = new List<Product>()
            {
                new Product("Tomato",300),
                new Product("Potato",20),
            };
            listBoxProducts.ItemsSource = list;
        }
        private void Button_AddProduct(object sender, RoutedEventArgs e) // Добавление продукта в общий список
        {
            AddProduct window_AddProduct = new AddProduct();
            window_AddProduct.ShowDialog();
        }

        private void AddProductForDay(object sender, MouseButtonEventArgs e) // Добавление продукта в дневной рацион
        {
            AddProductFromList window_AddProductFromList = new AddProductFromList();
            window_AddProductFromList.listProducts.ItemsSource = listBoxProducts.ItemsSource;
            window_AddProductFromList.ShowDialog();


            Task.Run(() =>
            {
                bool Is = false;
                ProductDay productDay = new ProductDay();
                while (Is == false)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            if (window_AddProductFromList.IsClose == true)
                            {
                                productDay.Name = ((Product)window_AddProductFromList.listProducts.SelectedItem).Name;
                                productDay.Weight = Convert.ToInt32(window_AddProductFromList.Weight.Text);
                                Is = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Is = true;
                        }
                        
                    });
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (productDay.Name == list[i].Name)
                    {
                        productDay.Protein = list[i].Protein;
                        productDay.Fats = list[i].Fats;
                        productDay.Carbohydrates = list[i].Carbohydrates;
                        productDay.Calories = list[i].Calories;
                        this.Dispatcher.Invoke(() => { listBoxProductsForOneDay.Items.Add(productDay); });
                    }
                }
            });
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
    }
}
