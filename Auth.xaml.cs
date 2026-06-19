using System;
using System.Collections.Generic;
using System.Net;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = InputName.Text.Trim();
            string pass = InputPass.Text.Trim();
            string role = (InputName.Text == "admin" && InputPass.Text == "123") ? "admin" : "klient";
            

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            if (role == "admin")
            {
                MainWindow mainWindow = new MainWindow(role, 1);
                mainWindow.Show();
                this.Close();
                return;
            }

            MyContext myContext = new MyContext();
            var currentUser = myContext.Users.FirstOrDefault(u => u.name == name && u.pass == pass);
            if (currentUser != null)
            { 
                // ИСПРАВЛЕНИЕ: Передаем роль И реальный id из базы данных (currentUser.id)
                MainWindow mainWindow = new MainWindow(role, currentUser.id);

                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void RegLabel(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }

    }
}
