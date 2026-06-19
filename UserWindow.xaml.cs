using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.Contexts;
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private string _role;
        public UserWindow(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            LoadUser();
            aaa();
        }

        void aaa()
        {
            if (_role == "admin")
            {
                InputName.Visibility = Visibility.Visible;
                InputPass.Visibility = Visibility.Visible;
                Name.Visibility = Visibility.Visible;
                Pass.Visibility = Visibility.Visible;
                DelUser.Visibility = Visibility.Visible;
            }
            else
            {
                InputName.Visibility = Visibility.Collapsed;
                InputPass.Visibility = Visibility.Collapsed;
                Name.Visibility = Visibility.Collapsed;
                Pass.Visibility = Visibility.Collapsed;
                DelUser.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadUser()
        {
            MyContext myContext = new MyContext();
            dataGrid.ItemsSource = myContext.Users.ToList();
        }

        private void DelUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                myContext.Users.Remove(dataGrid.SelectedItem as User);
                myContext.SaveChanges();
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
