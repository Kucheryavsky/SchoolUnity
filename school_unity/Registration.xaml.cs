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
using System.Security.Cryptography;

namespace school_unity
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        DataSet1 ds = new DataSet1();
        RoleTableAdapter rta = new RoleTableAdapter();
        UserTableAdapter uta = new UserTableAdapter();

        

        
        public Registration()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            rta.Fill(ds.Role); 
            ComboBox.ItemsSource = ds.Role;
            
        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string log = Login.Text;
            string pas = ComputeHash(Password.Text, new SHA256CryptoServiceProvider());
            string role = ComboBox.SelectionBoxItem.ToString();
               
            


            var registrationcheck = uta.Catch(ds.User, log);
            if (registrationcheck == 1)//Проверяем наличие идентичного логина в БД
            {
                MessageBox.Show("К сожалению, пользователь с таким же именем уже зарегистрирован! Пожалуйста измените логин.");
                return;
            }
            else
            { //Если всё верно, то вносим нового пользователя в БД

                uta.Register(log, pas, role);

                var logining = uta.LoginFill(ds.User, log, pas);
                if (logining == 1)//Проверяем появился ли пользователь в БД
                {
                    MessageBox.Show("Вы успешно зарегистрировали пользователя в системе!");

                }
                else
                {
                    MessageBox.Show("Упс, шаловливые бесы не дают вам зарегистрировать пользователя!");
                }

            }
        }
    }

}
