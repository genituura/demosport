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
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.ToList();
            }

            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();
            ProductGrid.Columns[0].Width = 140;
            ProductGrid.Columns[4].Width = 200;
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

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.Where(x => x.ProductDiscountAmount < 10).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.Where(x => x.ProductDiscountAmount > 10 && x.ProductDiscountAmount < 15).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.Where(x => x.ProductDiscountAmount > 15 && x.ProductDiscountAmount < 100).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.OrderBy(x => x.ProductCost).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.OrderByDescending(x => x.ProductCost).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

            using (var db = new SportikContext())
            {
                ProductGrid.ItemsSource = db.Products.Where(x => x.ProductName == Search.Text).ToList();
            }
            count.Content = "Найдено" + ProductGrid.Items.Count.ToString();

        }
    }
}