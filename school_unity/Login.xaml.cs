using school_unity.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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

namespace school_unity
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {


        public Login()
        {
            InitializeComponent();
        }

        DataSet1 ds = new DataSet1();
        UserTableAdapter uta = new UserTableAdapter();

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public string CalculateSHA256Hash()
        {

            SHA256 sha256 = new SHA256CryptoServiceProvider();
            string pass = PasswordTB.Password;
            byte[] checkSum = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }


        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginTB.Text;
            string Password = ComputeHash(PasswordTB.Password, new SHA256CryptoServiceProvider());
            // string Password = CalculateSHA256Hash(); 
            // school_unity.PubLogin = Login; //Запоминаем логин пользователя, для дальнейшего взаимодействия


            var logining = uta.LoginFill(ds.User, Login, Password); // Проверяем наличие в базе данных
            if (logining == 1)
            {
                string UserRole = (string)ds.User[0]["RoleID"]; // Настраиваем переходы в зависимости от роли

                if (UserRole == "1")
                {
                    NavigationService.Navigate(new UserMenu.admin());
                }

                if (UserRole == "2")
                {
                    NavigationService.Navigate(new UserMenu.Headteacher());
                }


                if (UserRole == "4")
                {
                    NavigationService.Navigate(new UserMenu.teacher());
                }


            }
            else //Обрабатываем исключения
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

     


        }

        private void EnterButton2_Click(object sender, RoutedEventArgs e)
        {
           
                    NavigationService.Navigate(new EditMarks());
               



        }


        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
