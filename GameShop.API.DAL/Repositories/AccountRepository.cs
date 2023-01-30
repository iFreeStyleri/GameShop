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
    public class AccountRepository : IAccountRepository
    {
        private readonly GameDbContext _gameContext;
        public AccountRepository(GameDbContext gameContext)
        {
            _gameContext = gameContext;
        }
        public async Task Delete(Account model)
        {
            _gameContext.Accounts.Remove(model);
            await _gameContext.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAll()
            => await _gameContext.Accounts.ToListAsync();

        public async Task<Account> GetByEmailAndPassword(string email, string password)
            => await _gameContext.Accounts
            .FirstOrDefaultAsync(f => f.Email == email && f.Password == password);

        public async Task<Account> GetById(int id)
            => await _gameContext.Accounts
            .FirstOrDefaultAsync(f => f.Id == id);

        public async Task Insert(Account model)
        {
            _gameContext.Accounts.Add(model);
            await _gameContext.SaveChangesAsync();
        }
    }
}
