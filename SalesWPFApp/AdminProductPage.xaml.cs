using BusinessObject.Models;
using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for AdminProductPage.xaml
    /// </summary>
    public partial class AdminProductPage : Page
    {
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        public AdminProductPage(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.memberRepository = memberRepository;
            this.orderRepository = orderRepository;
            InitializeComponent();
            Load_data();
        }
        public void Load_data()
        {
            ListView.ItemsSource = productRepository.GetAllProducts();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadProduct(object sender, RoutedEventArgs e)
        {
            Load_data();
        }

        private void InsertProduct(object sender, RoutedEventArgs e)
        {
            AdminProductCreateWindow adminProductCreate = new AdminProductCreateWindow(this, null, productRepository);
            adminProductCreate.Show();
            //Product p = new Product()
            //{
            //    ProductName = txtName.Text,
            //    CategoryId = int.Parse(txtCategory.Text),
            //    Weight = txtWeight.Text,
            //    UnitPrice = int.Parse(txtPrice.Text),
            //    UnitsInStock = int.Parse(txtUnit.Text)
            //};
            //productRepository.AddProduct(p);
            //MessageBox.Show("Add product success!");
            //Load_data();
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            int count = ListView.SelectedItems.Count;
            if (count > 0)
            {
                List<Product> products = ListView.SelectedItems.Cast<Product>().ToList();
                products.ForEach(product =>
                {
                    AdminProductCreateWindow productCreate = new AdminProductCreateWindow(this, product, productRepository);
                    productCreate.Show();
                });
            }
            else
            {
                MessageBox.Show("Plase select product");
            }
            //// get by id
            //Product prdFound = productRepository.GetProductById(int.Parse(txtId.Text));
            //if (prdFound != null)
            //{
            //    // update and save 
            //    prdFound.ProductName = txtName.Text;
            //    prdFound.UnitPrice = decimal.Parse(txtPrice.Text);
            //    prdFound.UnitsInStock = int.Parse(txtUnit.Text);
            //    prdFound.CategoryId = int.Parse(txtCategory.Text);
            //    productRepository.UpdateProduct(prdFound);
            //    MessageBox.Show("Update product success!");
            //    // load data
            //    Load_data();
            //}
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            Product prdFound = productRepository.GetProductById(int.Parse(txtId.Text));
            if (prdFound != null)
            {
                productRepository.DeleteProduct(prdFound);
                Load_data();
                MessageBox.Show("Delete product success!");
            }
        }

        private void ClearProduct(object sender, RoutedEventArgs e)
        {

        }

        private void SearchById(object sender, RoutedEventArgs e)
        {
            Product prdFound = productRepository.GetProductById(int.Parse(txtId.Text));
            if (prdFound != null)
            {
                ListView.ItemsSource = new List<Product> { prdFound };
            }
            else
            {
                MessageBox.Show("No product with such Id!");
                Load_data();
            }
        }

        private void SearchByPrice(object sender, RoutedEventArgs e)
        {
            List<Product> listPrd = productRepository.GetProductsByPrice(decimal.Parse(txtPrice.Text)).ToList();
            if (listPrd != null)
            {
                ListView.ItemsSource = listPrd;
            }
            else
            {
                MessageBox.Show("No product with such price!");
            }


        }

        private void SearchByUnit(object sender, RoutedEventArgs e)
        {

        }

        private void SearchProduct (object sender, RoutedEventArgs e)
        {
            int? id = !String.IsNullOrEmpty(txtId.Text) ? int.Parse(txtId.Text) : null;
            string? name = txtName.Text;
            decimal? unitPrice = !String.IsNullOrEmpty(txtPrice.Text) ? decimal.Parse(txtPrice.Text) : null;
            int? unitsInStock = !String.IsNullOrEmpty(txtUnit.Text) ? int.Parse(txtUnit.Text) : null;
            int? categoryId = !String.IsNullOrEmpty(txtCategory.Text) ? int.Parse(txtCategory.Text) : null;

            ProductFilter productFilter = new ProductFilter();
            productFilter.ProductId = id;
            productFilter.ProductName = name;
            productFilter.UnitPrice = unitPrice;
            productFilter.UnitsInStock = unitsInStock;
            productFilter.CategoryId = categoryId;

            ListView.ItemsSource = productRepository.GetProductsByFilter(productFilter);
        }
    }
}
