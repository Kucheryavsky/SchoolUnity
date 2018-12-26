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
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        DataSet1 ds = new DataSet1();
        MarkManagementTableAdapter mmta = new MarkManagementTableAdapter();
        UserTableAdapter uta = new UserTableAdapter();
        SubjectTableAdapter subta = new SubjectTableAdapter();
        DataTable1TableAdapter dtdt = new DataTable1TableAdapter();
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
            string login = Login.Text;
            string pas = ComputeHash(OldPas.Text, new SHA256CryptoServiceProvider());
            string pasnew = ComputeHash(NewPas.Text, new SHA256CryptoServiceProvider());
            string repeatpas = ComputeHash(Repeat.Text, new SHA256CryptoServiceProvider());

            var registrationcheck = uta.LoginFill(ds.User, login, pas);
           if (registrationcheck == 1)//Проверяем наличие идентичного логина в БД
            {
                if (pasnew == repeatpas)
                {
                    uta.NewPassword(login, pasnew, login, pas);
                    MessageBox.Show("Вы успешно изменили пароль!");
                }
                else
                {
                    MessageBox.Show("Новый пароль не совпадает с повторным!");
                }
            }
           else
            {
                MessageBox.Show("НЕ ПРАВИЛЬНО! ШИРОКАЯ НА ШИРОКУЮ!");
            }
        }
    }
}
