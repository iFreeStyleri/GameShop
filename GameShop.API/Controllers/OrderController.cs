using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameShop.API.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(PlaceOrderDTO dto)
        {
            var response = await _orderService.PlaceOrder(dto.Account, dto.Game );
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.OK:
                    return Ok(response);
                default:
                    return BadRequest();
            }
        }

        [HttpPost("account-orders")]
        public async Task<IActionResult> GetAccountOrders(GetAccountOrdersDTO dto)
        {
            var response = await _orderService.GetAccountOrders(dto.Account);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.OK:
                    return Ok(response);
                default:
                    return BadRequest();
            }
        }
    }
}
