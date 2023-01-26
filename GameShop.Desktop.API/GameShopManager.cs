using GameShop.Desktop.API.Abstractions;
using GameShop.Desktop.API.Abstractions.Services;
using GameShop.Desktop.API.Implementations.Services;
using GameShop.Domain.Response;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API
{
    public class GameShopManager : IGameShopManager
    {
        private readonly IServiceProvider _provider;

        public GameShopManager(IServiceCollection services, string hostName)
        {
            services.AddSingleton(services =>
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(hostName);
                return client;
            });
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IOrderService, OrderService>();
            _provider = services.BuildServiceProvider();
        }

        public IAccountService Account => _provider.GetRequiredService<IAccountService>();

        public IGameService Game => _provider.GetRequiredService<IGameService>();

        public IOrderService Order => _provider.GetRequiredService<IOrderService>();
    }
}
