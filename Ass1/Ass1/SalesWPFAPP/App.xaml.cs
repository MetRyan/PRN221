﻿using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SalesWPFAPP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton<LoginWindows>();
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton<ProductManagement>();

        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginWindows = serviceProvider.GetService<LoginWindows>();
            loginWindows!.ShowDialog();
            var ProductManagementWindows = serviceProvider.GetService<ProductManagement>();
            ProductManagementWindows!.ShowDialog();
        }

    }

}
