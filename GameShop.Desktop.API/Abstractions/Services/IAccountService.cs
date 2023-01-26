using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API.Abstractions.Services
{
    public interface IAccountService
    {
        public Account Account { get; }
        public Task<Account> Login(LoginDTO @params);
        public Task<Account> Register(RegisterDTO @params);
    }
}
