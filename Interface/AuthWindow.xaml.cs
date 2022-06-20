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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Registr_Click(object sender, RoutedEventArgs e) // Переход на окно регистрации
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            this.Close();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            // Добавление информации в основное окно

            window.Show();
            this.Close();
        }
    }
}
