using GameShop.API.Core.Abstractions.Repositories;
using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.Core.Abstractions.Services
{
    public interface IGameService
    {
        Task<IBaseResponse<List<Game>>> GetAll();
        public Task<IBaseResponse<List<Game>>> GetByGenre(Genre genre);
    }
}
