using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.DAL.Context;
using GameShop.API.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.DAL
{
    public static class DataInitor
    {
        public static IServiceCollection DataInit(this IServiceCollection services)
        {
            services.AddDbContext<GameDbContext>(
                opt => opt.UseSqlServer("Data Source = USER-PC\\SQLEXPRESS; Initial Catalog = GamesDB; Integrated Security = True; TrustServerCertificate = true")
                );
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
