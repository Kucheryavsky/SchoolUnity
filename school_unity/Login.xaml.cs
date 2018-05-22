using school_unity.DataSet1TableAdapters;
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


     

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginTB.Text;
           // school_unity.PubLogin = Login; //Запоминаем логин пользователя, для дальнейшего взаимодействия
            string Password = PasswordTB.Password;


            var logining = uta.Login(ds.User, Login, Password); // Проверяем наличие в базе данных
            if (logining == 1)
            {
                string UserRole = (string)ds.User[0]["RoleID"]; // Настраиваем переходы в зависимости от роли

                if (UserRole == "1")
                {
                    NavigationService.Navigate(new UserMenu.admin());
                }

                if (UserRole == "2")
                {
                    NavigationService.Navigate(new UserMenu.schoolkid());
                }
                
                if (UserRole == "3")
                {
                    NavigationService.Navigate(new UserMenu.teacher());
                }

                if (UserRole == "4")
                {
                    NavigationService.Navigate(new UserMenu.parent());
                }

            }
            else //Обрабатываем исключения
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
