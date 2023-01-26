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
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Game>> GetAll()
        {
            return (await _httpClient.GetFromJsonAsync<BaseResponse<List<Game>>>("api/game/get-all")).Data;
        }

        public async Task<List<Game>> GetByGenre(Genre genre)
        {
            var response = await _httpClient.PostAsJsonAsync<GetByGenreDTO>("api/game/get-by-genre", new GetByGenreDTO { Genre = genre});
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException("BadRequest");
            var games = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
            return games;
        }
    }
}
