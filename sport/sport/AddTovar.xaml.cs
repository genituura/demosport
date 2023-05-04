using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для AddTovar.xaml
    /// </summary>
    public partial class AddTovar : Window
    {
        SportikContext _context = new SportikContext();
        Product _product = new Product();

        public AddTovar()
        {
            _context = new SportikContext();
            
            InitializeComponent();
            UnitTovar.ItemsSource = _context.UnitTypes.ToList();
            ManufacturerTovar.ItemsSource = _context.ProductManufacturers.ToList();
            CategoryTovar.ItemsSource = _context.ProductCategories.ToList();
            



            using (var db = new SportikContext())
            {
                AddGrid.ItemsSource = db.Products.ToList();
            }

            AddGrid.Columns[0].Width = 140;
            AddGrid.Columns[4].Width = 200;
        }

        private void EditTov_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = { QuantityTovar, MaxDiscountTovar, CostTovar, DescriptionTovar, DiscountTovar, NameTovar, ArticleTovar };
            string cost = CostTovar.Text.Replace(".", ",");
            using (var sport = new SportikContext())
                if (_product != null)
                {
                    _product.ProductName = NameTovar.Text;
                    _product.ProductArticleNumber = ArticleTovar.Text;
                    _product.ProductCost = Convert.ToDecimal(cost);
                    _product.ProductDescription = DescriptionTovar.Text;
                    _product.ProductDiscountAmount = Convert.ToByte(DiscountTovar.Text);
                    _product.ProductQuantityInStock = Convert.ToByte(QuantityTovar.Text);
                    _product.ProductMaxDiscountAmount = Convert.ToByte(MaxDiscountTovar.Text);
                    _product.ProductSupplierId = Convert.ToInt32(SupplierTovar.Text);
                    _product.UnitTypeId = 1;
                    _product.ProductCategoryId = ((ProductCategory)(CategoryTovar.SelectedItem)).ProductCategoryId;
                    _product.ProductManufacturerId = ((ProductManufacturer)(ManufacturerTovar.SelectedItem)).ProductManufacturerId;
                    _product.ProductPhoto = string.Empty;

                };
            _context.SaveChanges();
            MessageBox.Show("Товар изменен!");
            AddGrid.ItemsSource = _context.Products.ToList();
            foreach (var textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        private void DeleteTov_Click(object sender, RoutedEventArgs e)
        {
            _context.Products.Remove(_product);
            _context.SaveChanges();
            MessageBox.Show("Товар удален");
            AddGrid.ItemsSource = _context.Products.ToList();
        }

        private void AddTov_Click(object sender, RoutedEventArgs e)
        {
            using (var sport = new SportikContext())
            {
                TextBox[] textBoxes = { CostTovar, DescriptionTovar, DiscountTovar, NameTovar, ArticleTovar, MaxDiscountTovar, SupplierTovar, QuantityTovar };

                foreach (var textBox in textBoxes)
                {
                    if (String.IsNullOrEmpty(textBox.Text))
                    {
                        MessageBox.Show("Введите текст");
                        return;
                    }
                }
                if (Convert.ToInt32(CostTovar.Text) < 0 || Convert.ToInt32(MaxDiscountTovar.Text) < 0 || Convert.ToInt32(QuantityTovar.Text) < 0)
                {
                    MessageBox.Show("Поле не может быть отрицательным!");
                    return;
                }
                if (Convert.ToInt16(DiscountTovar.Text) > Convert.ToInt16(MaxDiscountTovar.Text))
                {
                    MessageBox.Show("Скидка должна быть меньше максимальной!");
                    return;
                }
                var manufacturer = sport.ProductManufacturers.Where(m => m.ProductManufacturerName == ManufacturerTovar.Text).FirstOrDefault();
                var supplier = sport.ProductSuppliers.Where(s => s.ProductSupplierName == SupplierTovar.Text).FirstOrDefault();
                var unit = sport.UnitTypes.Where(m => m.UnitTypeName == UnitTovar.Text).FirstOrDefault();
                var category = sport.ProductCategories.Where(s => s.ProductCategoryName == CategoryTovar.Text).FirstOrDefault();

                _product = new Product
                {
                    ProductArticleNumber = ArticleTovar.Text,
                    ProductCost = Convert.ToDecimal(CostTovar.Text),
                    ProductDiscountAmount = Convert.ToByte(DiscountTovar.Text),
                    ProductQuantityInStock = Convert.ToByte(QuantityTovar.Text),
                    ProductPhoto = string.Empty,
                    ProductName = NameTovar.Text,
                    ProductMaxDiscountAmount = Convert.ToByte(MaxDiscountTovar.Text),
                    UnitTypeId = ((UnitType)(UnitTovar.SelectedItem)).UnitTypeId,
                    ProductManufacturerId = ((ProductManufacturer)(ManufacturerTovar.SelectedItem))
                        .ProductManufacturerId,
                    ProductCategoryId = ((ProductCategory)(CategoryTovar.SelectedItem)).ProductCategoryId,
                    ProductDescription = NameTovar.Text,
                    ProductSupplierId = 1
                };

                if (_product != null)
                    _context.Products.Add(_product);
                MessageBox.Show("Товар добавлен в таблицу!");
                _context.SaveChanges();
            }

           

        }


        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
        }

        private void AddGrid_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
