using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public WindowProducts(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
            Load_data();
        }
        private void Load_data()
        {
            ListView.ItemsSource = _productRepository.GetAllProducts();
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
            Product p = new Product()
            {
                ProductName = txtName.Text,
                CategoryId = int.Parse(txtCategory.Text),
                Weight = txtWeight.Text,
                UnitPrice = int.Parse(txtPrice.Text),
                UnitsInStock = int.Parse(txtUnit.Text)
            };
            _productRepository.AddProduct(p);
            MessageBox.Show("Add product success!");
            Load_data();
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            // get by id
            Product prdFound = _productRepository.GetProductById(int.Parse(txtId.Text));
            if (prdFound != null)
            {
                // update and save 
                prdFound.ProductName = txtName.Text;
                prdFound.UnitPrice = decimal.Parse(txtPrice.Text);
                prdFound.UnitsInStock = int.Parse(txtUnit.Text);
                prdFound.CategoryId = int.Parse(txtCategory.Text);
                _productRepository.UpdateProduct(prdFound);
                MessageBox.Show("Update product success!");
                // load data
                Load_data();

            }
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            Product prdFound = _productRepository.GetProductById(int.Parse(txtId.Text));
            if (prdFound != null)
            {
                _productRepository.DeleteProduct(prdFound);
                Load_data() ;
                MessageBox.Show("Delete product success!");
            }
        }

        private void ClearProduct(object sender, RoutedEventArgs e)
        {

        }

        private void SearchById(object sender, RoutedEventArgs e)
        {
            Product prdFound = _productRepository.GetProductById(int.Parse(txtId.Text));
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
            List<Product> listPrd = _productRepository.GetProductsByPrice(decimal.Parse(txtPrice.Text)).ToList();
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

        private void ToMemberPage(object sender, RoutedEventArgs e)
        {
            WindowMembers w = new WindowMembers(_productRepository, _memberRepository, _orderRepository);
            w.Show();
            this.Close();
        }

        private void ToOrderPage(object sender, RoutedEventArgs e)
        {

        }
    }
}