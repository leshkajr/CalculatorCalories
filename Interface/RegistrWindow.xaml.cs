using Registration.Users;
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
            int Gender = 0;
            if(UserGenderMan.IsChecked==true)
            {
                Gender = 1;
            }
            else
            {
                Gender = 0;
            }
            if (userRepeatPassword.Password.ToString()== userPassword.Password.ToString())
            {
                if (RegistrationUser.CreateUser(userName.Text, userLogin.Text, userPassword.Password.ToString(), Gender,int.Parse(userAge.Text), double.Parse(userWeight.Text), double.Parse(userHaight.Text)))
                {
                    AuthWindow authWindow = new AuthWindow();
                    authWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует","Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка");
            }
           
        }
    }
}
