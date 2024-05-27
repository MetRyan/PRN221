using BussinessObject.DataAccess;
using DataAccess.Repository;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace SalesWPFAPP
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Window
    {

        public ProductManagement( )
        {
            InitializeComponent();

        }
        IProductRepository _productRepository;
        public ProductManagement(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;

        }
        //getProductObject
        private Product getProductObject(){
            Product product = null;
            try {
                product = new Product
                {
                    ProductId = int.Parse(tbProductId.Text),
                    CategoryId = int.Parse(tbCategoryId.Text),
                    ProductName = tbProductName.Text,
                    Weight = tbWeight.Text,
                    UnitPrice = int.Parse(tbUnitPrice.Text),
                    UnitsInstoke = int.Parse(tbUnitPrice.Text),

                };

                
            
            } catch (Exception ex) {
            throw new Exception(ex.Message);
            }
            return product;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void tbProductId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            lvProduct.Items.Clear();
            lvProduct.ItemsSource = _productRepository.getList();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Product getProduct = getProductObject();
          //  _productRepository.
        }
    }
}
/*Text = "{Binding Path=ProductId, Mode=OneWay}" DataContext = "{Binding ElementName=lvProduct, Path=SelectedItem}}*/