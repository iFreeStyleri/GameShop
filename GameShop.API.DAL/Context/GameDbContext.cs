using GameShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.DAL.Context
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public GameDbContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }
    }
}
