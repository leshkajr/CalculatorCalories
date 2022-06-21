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
    public partial class MainWindow : Window
    {
        public class Product
        {
            public string Name { get; set; }
            public int Calories { get; set; }
            public Product(string name, int calories)
            {
                this.Name = name;
                this.Calories = calories;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            List<Product> list = new List<Product>()
            {
                new Product("Tomato",300),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
                new Product("Potato",20),
            };
            listBoxProducts.ItemsSource = list;
        }
    }
}
