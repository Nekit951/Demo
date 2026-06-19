using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _role;
        private int _userId;
        public MainWindow(string role, int userId = 0)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
        }

        private void TovarButton_Click(object sender, RoutedEventArgs e)
        {
            TovarWindow tovarWindow = new TovarWindow(_role, _userId);
            tovarWindow.Show();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(_role, _userId);
            categoryWindow.Show();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(_role, _userId);
            userWindow.Show();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(_role, _userId);
            orderWindow.Show();
        }
    }
}