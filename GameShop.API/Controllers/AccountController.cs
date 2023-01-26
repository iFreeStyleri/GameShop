using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.DTO;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameShop.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAcccountService _accountService;

        public AccountController(IAcccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var response = await _accountService.Login(dto.Email, dto.Password);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                default:
                    return BadRequest();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var account = new Account { Login = dto.Login, Password = dto.Password, Email = dto.Email, Created = DateTime.Now };
            var response = await _accountService.Register(account);
            switch (response.StatusCode)
            {
                case HttpStatusCode.Created:
                    return Ok(response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                default:
                    return BadRequest();
            }
        }
    }
}
