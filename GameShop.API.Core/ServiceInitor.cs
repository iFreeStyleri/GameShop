using GameShop.API.Core.Abstractions.Services;
using GameShop.API.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core
{
    public static class ServiceInitor
    {
        public static IServiceCollection ServiceInit(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IAcccountService, AccountService>();
            return services;
        }
    }
}
