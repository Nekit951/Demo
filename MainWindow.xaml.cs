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
        public MainWindow(string role)
        {
            InitializeComponent();
            _role = role;
        }

        private void TovarButton_Click(object sender, RoutedEventArgs e)
        {
            TovarWindow tovarWindow = new TovarWindow(_role);
            tovarWindow.Show();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(_role);
            categoryWindow.Show();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(_role);
            userWindow.Show();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(_role);
            orderWindow.Show();
        }
    }
}