using Authorization.Users;
using DbCalculatorСalorie.Models;
using System;
using System.Windows;

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
            User user = AuthorizationUser.PasswordCheckAsync(userLogin.Text, userPassword.Password.ToString());
            if (user != null)
            {
                MainWindow window = new MainWindow(user);
                // Добавление информации в основное окно
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный пароль или логин", "Ошибка");
            }


        }
    }
}

