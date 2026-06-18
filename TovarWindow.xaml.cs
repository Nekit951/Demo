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
        public TovarWindow(string role)
        {
            InitializeComponent();
            _role = role;
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
                tovar.Name = InputName.Text;
                tovar.Category = Convert.ToInt32(InputCategory.Text);
                tovar.Price = Convert.ToInt32(InputPrice.Text);
                tovar.Quantity = Convert.ToInt32(InputQuantity.Text);
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
    }
}
