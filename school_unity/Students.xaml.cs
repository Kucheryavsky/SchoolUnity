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
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();
        }

        private void Students_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet1 ds = new DataSet1();
            StudentTableAdapter sta = new StudentTableAdapter();

            sta.Fill(ds.Student); //Заполняем datagrid
            Students1.ItemsSource = ds.Student;
        }
    }
}
