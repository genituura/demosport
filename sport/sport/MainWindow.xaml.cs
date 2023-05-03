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

namespace sport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            MainWin win = new MainWin();
            win.Show();
            this.Close();
        }

        private void Empty_Click(object sender, RoutedEventArgs e)
        {
            using SportikContext sport = new SportikContext();
            if (sport.Users.Any(i => i.UserLogin == Login.Text && i.UserPassword == Password.Text && i.RoleId == 1))
            {
                MessageBox.Show("Успешная авторизация клиента");
                MainWin win = new MainWin();
                win.Show();
                this.Close();
            }
            if (sport.Users.Any(i => i.UserLogin == Login.Text && i.UserPassword == Password.Text && i.RoleId == 2))
            {
                MessageBox.Show("Успешная авторизация администратора");
            }

            if (sport.Users.Any(i => i.UserLogin == Login.Text && i.UserPassword == Password.Text && i.RoleId == 3))
            {
                MessageBox.Show("Успешная авторизация менеджера");
            }

        }
  

        private void Catalog_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Catalog_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
