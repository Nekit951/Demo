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
    /// Логика взаимодействия для TovarWindow.xaml
    /// </summary>
    public partial class TovarWindow : Window
    {
        private string _role;
        private int _userId;
        public TovarWindow(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            LoadTovar();
            aaa();
        }

        void aaa()
        {
            if(_role == "admin")
            {
                InputName.Visibility = Visibility.Visible;
                InputCategory.Visibility = Visibility.Visible;
                InputPrice.Visibility = Visibility.Visible;
                InputQuantity.Visibility = Visibility.Visible;
                Name.Visibility = Visibility.Visible;
                Category.Visibility = Visibility.Visible;
                Price.Visibility = Visibility.Visible;
                Quantity.Visibility = Visibility.Visible;
                AddTovar.Visibility = Visibility.Visible;
                DelTovar.Visibility = Visibility.Visible;
                Buy.Visibility = Visibility.Collapsed;
            }
            else
            {
                InputName.Visibility = Visibility.Collapsed;
                InputCategory.Visibility = Visibility.Collapsed;
                InputPrice.Visibility = Visibility.Collapsed;
                InputQuantity.Visibility = Visibility.Collapsed;
                Name.Visibility = Visibility.Collapsed;
                Category.Visibility = Visibility.Collapsed;
                Price.Visibility = Visibility.Collapsed;
                Quantity.Visibility = Visibility.Collapsed;
                AddTovar.Visibility = Visibility.Collapsed;
                DelTovar.Visibility = Visibility.Collapsed;
                Buy.Visibility = Visibility.Visible;
            }
        }

        private void LoadTovar()
        {
            MyContext myContext = new MyContext();
            dataGrid.ItemsSource = myContext.Tovars.ToList();
        }

        private void AddTovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                Tovar tovar = new Tovar();
                tovar.name = InputName.Text;
                tovar.category = Convert.ToInt32(InputCategory.Text);
                tovar.price = Convert.ToInt32(InputPrice.Text);
                tovar.quantity = Convert.ToInt32(InputQuantity.Text);
                myContext.Add(tovar);
                myContext.SaveChanges();
                LoadTovar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelTovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                myContext.Tovars.Remove(dataGrid.SelectedItem as Tovar);
                myContext.SaveChanges();
                LoadTovar();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dataGrid.SelectedItem as Tovar;
            if (selectedItem == null) 
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            MyContext myContext = new MyContext();
            try
            {
                var tovarDb = myContext.Tovars.FirstOrDefault(x => x.id == selectedItem.id);

                if (tovarDb != null)
                {
                    tovarDb.quantity -= 1;
                    decimal total = Convert.ToDecimal(tovarDb.price) * 1;
                    Order newOrder = new Order 
                    {
                        tovar = tovarDb.id,
                        quantity = 1,
                        summa = total,
                        user = _userId,
                        address = "Самовывоз"
                    };
                    myContext.Orders.Add(newOrder);
                    myContext.SaveChanges();
                    LoadTovar();
                }
            }
            catch (Exception ex) 
            {
                string innerMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Ошибка БД: {innerMessage}");
            }
        }
    }
}
