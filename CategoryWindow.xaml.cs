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
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private string _role;
        public CategoryWindow(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            LoadCategory();
            aaa();
        }

        void aaa()
        {
            if(_role == "admin")
            {
                InputCategory.Visibility = Visibility.Visible;
                AddCategory.Visibility = Visibility.Visible;
                DelCategory.Visibility = Visibility.Visible;
            }
            else
            {
                InputCategory.Visibility = Visibility.Collapsed;
                AddCategory.Visibility = Visibility.Collapsed;
                DelCategory.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadCategory()
        {
            MyContext myContext = new MyContext();
            dataGrid.ItemsSource = myContext.Categories.ToList();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                Category category = new Category();
                category.categoryName = InputCategory.Text;
                myContext.Add(category);
                myContext.SaveChanges();
                LoadCategory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyContext myContext = new MyContext();
                myContext.Categories.Remove(dataGrid.SelectedItem as Category);
                myContext.SaveChanges();
                LoadCategory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
