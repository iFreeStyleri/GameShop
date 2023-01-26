using GameShop.Desktop.API;
using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.ViewModels;
using GameShop.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameShop.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider _provider;

        public static IServiceProvider Provider => _provider;
        public App()
        {
            var services = new ServiceCollection();
            Configure(services);
            _provider = services.BuildServiceProvider();
        }
        private void Configure(IServiceCollection services)
        {
            services.AddSingleton<IGameShopManager, GameShopManager>(provider => new GameShopManager(services, "http://localhost:5223/"));
            services.AddSingleton<MenuWindowViewModel>();
            services.AddSingleton<CatalogViewModel>();
            services.AddTransient<MenuWindow>();
            services.AddTransient<AuthWindow>();
            services.AddTransient<RegWindow>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _provider.GetRequiredService<AuthWindow>().Show();
        }
    }
}
