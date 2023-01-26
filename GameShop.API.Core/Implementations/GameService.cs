using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.Core.Abstractions.Services;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System.Net;

namespace GameShop.API.Core.Implementations
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IBaseResponse<List<Game>>> GetAll()
        {
            var result = await _gameRepository.GetAll();
            return new BaseResponse<List<Game>>() { Data = result, StatusCode = HttpStatusCode.OK };
        }

        public async Task<IBaseResponse<List<Game>>> GetByGenre(Genre genre)
        {
            var result = await _gameRepository.GetAllByGenre(genre);
            if(result == null)
                return new BaseResponse<List<Game>> { StatusCode = HttpStatusCode.NotFound, Description = "Games not found" };
            return new BaseResponse<List<Game>> { StatusCode = HttpStatusCode.OK, Data = result };
        }
    }
}
