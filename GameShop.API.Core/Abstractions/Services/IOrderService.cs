using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Abstractions.Services
{
    public interface IOrderService
    {
        Task<IBaseResponse<List<Order>>> GetAccountOrders(Account accoutn);
        public Task<IBaseResponse<Order>> PlaceOrder(Account account, Game game);

    }
}
