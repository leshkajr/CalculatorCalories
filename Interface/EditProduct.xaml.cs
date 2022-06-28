using Controller;
using DbCalculatorСalorie.Models;
using System.Windows;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        Product product;
        public EditProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
        }

        private void editProduck(object sender, RoutedEventArgs e)
        {
            EditProducts editProduct = new EditProducts();
            editProduct.Editing(product, int.Parse(Protein.Text), int.Parse(Carbohydrates.Text), int.Parse(Fats.Text));
            this.Close();

        }
    }
}
