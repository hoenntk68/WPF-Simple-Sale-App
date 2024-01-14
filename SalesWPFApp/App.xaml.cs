﻿using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<WindowLogin>();
            services.AddSingleton<WindowMembers>();
            services.AddSingleton<WindowOrders>();
            services.AddSingleton<WindowProducts>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var login = _serviceProvider.GetService<WindowLogin>();
            login.Show();
        }
    }
}
