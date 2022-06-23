using System.Windows;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        public RegistrWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e) // Переход на окно авторизации
        {
            
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void Button_Registr_Click(object sender, RoutedEventArgs e) // Регистрация
        {
            // Переход на окно авторизации
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
