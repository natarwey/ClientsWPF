using System;
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
using System.Xml.Linq;

namespace ClientsWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CBRoles.ItemsSource = new List<string>() { "админ", "пользователь" };
        }
        private async void Refresh()
        {
            var users = await NetManager.Get<List<User>>("api/Users/GetAllUsers");
            DGUsers.ItemsSource = users;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private async void BAdd_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            user.Name = TBName.Text;
            user.Age = int.Parse(TBAge.Text);
            user.RoleId = CBRoles.SelectedIndex + 1;
            await NetManager.Post("api/Users/Add", user);
            Refresh();
        }
    } 
}
