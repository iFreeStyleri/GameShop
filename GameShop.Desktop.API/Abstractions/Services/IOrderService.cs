using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API.Abstractions.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAccountOrders(GetAccountOrdersDTO @params);
        public Task PlaceOrder(PlaceOrderDTO @params);
    }
}
