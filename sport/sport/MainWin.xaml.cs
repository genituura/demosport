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
using System.Windows.Shapes;

namespace sport
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.ToList();
            }
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ProductGrid_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
