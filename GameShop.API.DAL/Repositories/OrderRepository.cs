using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.DAL.Context;
using GameShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GameDbContext _context;

        public OrderRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Order model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAccountOrders(int accountId)
            => await _context.Orders.Include(o => o.Account).Include(g => g.Game).Where(w => w.Account.Id == accountId).ToListAsync();

        public async Task<List<Order>> GetAll()
            => await _context.Orders.ToListAsync();

        public async Task<Order> GetById(int id)
            => await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);

        public async Task Insert(Order model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
