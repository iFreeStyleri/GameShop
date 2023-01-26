using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Abstractions.Services
{
    public interface IAcccountService
    {
        public Task<IBaseResponse<Account>> Login(string email, string password);
        public Task<IBaseResponse<Account>> Register(Account account);
    }
}
