using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = InputName.Text.Trim();
            string pass = InputPass.Text.Trim();
            string role = "User";

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            MyContext myContext = new MyContext();
            bool userEx = myContext.Users.Any(u => u.pass == pass);
            if (userEx)
            {
                MessageBox.Show("Такой пароль уже есть");
                return;
            }

            User newUser = new User
            {
                name = name,
                pass = pass
            };
            myContext.Users.Add(newUser);
            myContext.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно");

            MainWindow mainWindow = new MainWindow(role);
            mainWindow.Show();
            this.Close();
        }

        private void AuthLabel(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
