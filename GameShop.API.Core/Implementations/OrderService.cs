using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.DTO;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IAccountRepository _accountRepository;
        public OrderService(IOrderRepository orderRepository, IGameRepository gameRepository, IAccountRepository accountRepository)
        {
            _orderRepository = orderRepository;
            _gameRepository = gameRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IBaseResponse<List<Order>>> GetAccountOrders(Account account)
        {
            if(account == null)
                return new BaseResponse<List<Order>> { StatusCode = HttpStatusCode.BadRequest, Description = "Account is null" };
            var result = await _orderRepository.GetAccountOrders(account.Id);
            if(result == null)
                return new BaseResponse<List<Order>> { StatusCode = HttpStatusCode.NotFound, Description = "Orders not found" };
            return new BaseResponse<List<Order>> { StatusCode = HttpStatusCode.OK, Data = result };
        }

        public async Task<IBaseResponse<Order>> PlaceOrder(Account account, Game game)
        {
            var accountResult = await _accountRepository.GetById(account.Id);
            var gameResult = await _gameRepository.GetById(game.Id);
            if(accountResult == null || gameResult == null)
                return new BaseResponse<Order> { Description = "Game or Account is null", StatusCode = HttpStatusCode.BadRequest };
            await _orderRepository.Insert(new Order { Account = accountResult, Game = gameResult, State = OrderState.Active});
            return new BaseResponse<Order> { StatusCode = HttpStatusCode.OK };
        }
    }
}
