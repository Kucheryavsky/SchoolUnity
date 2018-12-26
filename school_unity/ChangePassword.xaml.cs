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
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(OldPas==)
            string pas = ComputeHash(Password.Text, new SHA256CryptoServiceProvider());
            




            var registrationcheck = uta.Catch(ds.User, log);
            if (registrationcheck == 1)//Проверяем наличие идентичного логина в БД
            {
                MessageBox.Show("К сожалению, пользователь с таким же именем уже зарегистрирован! Пожалуйста измените логин.");
                return;
            }
        }
    }
}
