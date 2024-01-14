﻿using DataAccess.Repository;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        //public AdminWindow()
        //{
        //    InitializeComponent();
        //}

        public AdminWindow(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.memberRepository = memberRepository;
            this.orderRepository = orderRepository;
            InitializeComponent();
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {

        }

        private void Goto_AdminProduct(object sender, RoutedEventArgs e)
        {
            AdminProductPage adminProductPage = new AdminProductPage(productRepository, memberRepository, orderRepository);
            frameMain.Content = adminProductPage;
        }

        private void Goto_AdminMember(object sender, RoutedEventArgs e)
        {
            AdminMemberPage adminMemberPage = new AdminMemberPage(memberRepository);
            frameMain.Content = adminMemberPage;
        }

        private void Goto_AdminOrder(object sender, RoutedEventArgs e)
        {
        }
    }
}