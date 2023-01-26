using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Implementations
{
    public class AccountService : IAcccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IBaseResponse<Account>> Login(string email, string password)
        {
            var account = await _accountRepository.GetByEmailAndPassword(email, password);
            if(account  == null)
                return new BaseResponse<Account> { StatusCode = HttpStatusCode.NotFound, Description = "Account not found" };
            return new BaseResponse<Account> { Data = account, StatusCode = HttpStatusCode.OK };
        }

        public async Task<IBaseResponse<Account>> Register(Account account)
        {
            var result = await _accountRepository.GetByEmailAndPassword(account.Email, account.Password);
            if (result != null)
                return new BaseResponse<Account> { StatusCode = HttpStatusCode.BadRequest, Description = "Account already exist" };
            await _accountRepository.Insert(account);
            var response = await _accountRepository.GetByEmailAndPassword(account.Email, account.Password);
            return new BaseResponse<Account> { StatusCode = HttpStatusCode.Created, Data = response };
        }
    }
}
