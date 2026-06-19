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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private string _role;
        public OrderWindow(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            LoadOrder();
            aaa();
        }

        void aaa()
        {
            if(_role == "admin")
            {
                InputTovar.Visibility = Visibility.Visible;
                InputQuantity.Visibility = Visibility.Visible;
                InputSumma.Visibility = Visibility.Visible;
                InputUser.Visibility = Visibility.Visible;
                InputAddress.Visibility = Visibility.Visible;
                Tovar.Visibility = Visibility.Visible;
                Quantity.Visibility = Visibility.Visible;
                Summa.Visibility = Visibility.Visible;
                User.Visibility = Visibility.Visible;
                Address.Visibility = Visibility.Visible;
                AddOrder.Visibility = Visibility.Visible;
                DelOrder.Visibility = Visibility.Visible;
            }
            else
            {
                InputTovar.Visibility = Visibility.Collapsed;
                InputQuantity.Visibility = Visibility.Collapsed;
                InputSumma.Visibility = Visibility.Collapsed;
                InputUser.Visibility = Visibility.Collapsed;
                InputAddress.Visibility = Visibility.Collapsed;
                Tovar.Visibility = Visibility.Collapsed;
                Quantity.Visibility = Visibility.Collapsed;
                Summa.Visibility = Visibility.Collapsed;
                User.Visibility = Visibility.Collapsed;
                Address.Visibility = Visibility.Collapsed;
                AddOrder.Visibility = Visibility.Collapsed;
                DelOrder.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadOrder()
        {
            MyContext myContext = new MyContext();
            dataGrid.ItemsSource = myContext.Orders.ToList();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                Order order = new Order();
                order.tovar = Convert.ToInt32(InputTovar.Text);
                order.quantity = Convert.ToInt32(InputQuantity.Text);
                order.summa = Convert.ToInt32(InputSumma.Text);
                order.user = Convert.ToInt32(InputUser.Text);
                order.address = InputAddress.Text;
                myContext.Add(order);
                myContext.SaveChanges();
                LoadOrder();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                myContext.Orders.Remove(dataGrid.SelectedItem as Order);
                myContext.SaveChanges();
                LoadOrder();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
