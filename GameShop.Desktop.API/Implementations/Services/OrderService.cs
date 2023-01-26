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
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Order>> GetAccountOrders(GetAccountOrdersDTO @params)
        {
            var response = await _httpClient.PostAsJsonAsync("api/order/account-orders", @params);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException("Error get account orders");
            var responseMessage = JsonConvert
                .DeserializeObject<BaseResponse<List<Order>>>(await response.Content.ReadAsStringAsync());
            return responseMessage.Data;
        }

        public async Task PlaceOrder(PlaceOrderDTO @params)
        {
            var response = await _httpClient.PostAsJsonAsync("api/order/place-order", @params);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException("Error place order");
        }
    }
}
