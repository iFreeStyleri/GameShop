using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameShop.API.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("get-by-genre")]
        public async Task<IActionResult> GetByGenre(GetByGenreDTO dto)
        {
            var response = await _gameService.GetByGenre(dto.Genre);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                default:
                    return BadRequest();
            }
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _gameService.GetAll();
            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                default:
                    return BadRequest();
            }
        }
    }
}
