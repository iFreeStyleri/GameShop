using GameShop.Desktop.API.Abstractions.Services;
using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API.Implementations.Services
{
    public class AccountService : IAccountService
    {
        public Account Account { get; private set; }
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Account> Login(LoginDTO @params)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account/login", @params);
            var result = JsonConvert.DeserializeObject<BaseResponse<Account>>(await response.Content.ReadAsStringAsync());
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    Account = result.Data;
                    return result.Data;
                case HttpStatusCode.NotFound:
                    throw new HttpRequestException("NotFound");
                default:
                    throw new HttpRequestException("BadRequest");
            }
        }

        public async Task<Account> Register(RegisterDTO @params)
        {
            var response = await _httpClient.PostAsJsonAsync("api/account/register", @params);
            var result = JsonConvert.DeserializeObject<BaseResponse<Account>>(await response.Content.ReadAsStringAsync());
            switch (result.StatusCode)
            {
                case HttpStatusCode.Created:
                    Account = result.Data;
                    return result.Data;
                case HttpStatusCode.NotFound:
                    throw new HttpRequestException("NotFound");
                default:
                    throw new HttpRequestException("BadRequest");
            }
        }
    }
}
