using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public WindowLogin(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.memberRepository = memberRepository;
            this.orderRepository = orderRepository;
            InitializeComponent();
        }

        public void resetFormLogin()
        {
            txtEmail.Text = null;
            txtPassword.Password = null;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            var admin = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("admin");

            if (email != null && password != null)
            {
                if (email.Equals(admin["email"]) && password.Equals(admin["password"]))
                {
                    AdminWindow adminWindow = new AdminWindow(productRepository, memberRepository, orderRepository, this);
                    adminWindow.Show();
                    //WindowProducts windowProducts = new WindowProducts(productRepository, memberRepository, orderRepository);
                    //windowProducts.Show();
                    this.Hide();
                }
                else
                {
                    Member member = memberRepository.GetMemberByEmail(email, password);
                    if (member != null)
                    {
                        Session.Username = email;
                        Hide();
                        HomeWindow homeWindow = new HomeWindow(this, productRepository, orderRepository, memberRepository);
                        homeWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Email or Password");
                    }
                }
                resetFormLogin();
            }
            else
            {
                MessageBox.Show("Empty Email or Password");
            }
        }
    }
}
