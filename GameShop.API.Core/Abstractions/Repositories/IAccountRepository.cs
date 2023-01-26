using GameShop.API.Core.Abstractions.Repositories.Common;
using GameShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Abstractions.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        public Task<Account> GetByEmailAndPassword(string email, string password);
    }
}
