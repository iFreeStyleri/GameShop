using GameShop.Domain.Entities;
using GameShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Desktop.API.Abstractions.Services
{
    public interface IGameService
    {
        public Task <List<Game>> GetAll();
        public Task<List<Game>> GetByGenre(Genre genre);
    }
}
