﻿using System;
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

namespace school_unity.UserMenu
{
    /// <summary>
    /// Логика взаимодействия для teacher.xaml
    /// </summary>
    public partial class teacher : Page
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void QuitSession_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Marks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditMarks());
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Students());
        }

        private void Changepas_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassword());
        }
    }
}
