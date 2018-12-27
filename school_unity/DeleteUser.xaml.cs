using school_unity.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Page
    {

        DataSet1 ds = new DataSet1();
        UserTableAdapter uta = new UserTableAdapter();

        public DeleteUser()
        {
            InitializeComponent();
        }

        private void Marks_Loaded(object sender, RoutedEventArgs e)
        {
            uta.DeleteUserFill(ds.User); 
            Users.ItemsSource = ds.User;

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();

        }
       

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var UserID = (int)(Users.SelectedItem as DataRowView)["UserID"];
            var Login = (Users.SelectedItem as DataRowView)["Login"];
            var Password = (Users.SelectedItem as DataRowView)["Password"];
            var roleID = (Users.SelectedItem as DataRowView)["RoleID"];
          

            uta.Delete(UserID, Login.ToString(), Password.ToString(), roleID.ToString());
            uta.DeleteUserFill(ds.User);
            Users.ItemsSource = ds.User;
        }
    }
}
