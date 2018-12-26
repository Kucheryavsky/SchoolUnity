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
    /// Логика взаимодействия для EditMarks.xaml
    /// </summary>
    public partial class EditMarks : Page
    {

        DataSet1 ds = new DataSet1();
        MarkManagementTableAdapter mmta = new MarkManagementTableAdapter();
        StudentTableAdapter sta = new StudentTableAdapter();
        SubjectTableAdapter subta = new SubjectTableAdapter();
        DataTable1TableAdapter dtdt = new DataTable1TableAdapter();
        
        public EditMarks()
        {
            InitializeComponent();
        }

        private void Marks_Loaded(object sender, RoutedEventArgs e)
        {
            dtdt.Fill(ds.DataTable1); //Заполняем datagrid
            Marks.ItemsSource = ds.DataTable1;
            
        }  

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.GoBack();

        }
    }
}
