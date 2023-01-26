using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.DAL.Context;
using GameShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.API.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _gameContext;
        public GameRepository(GameDbContext gameContext)
        {
            _gameContext = gameContext;
        }
        public async Task Delete(Game model)
        {
            _gameContext.Remove(model);
            await _gameContext.SaveChangesAsync();
        }

        public async Task<List<Game>> GetAll()
            => await _gameContext.Games.ToListAsync();

        public async Task<List<Game>> GetAllByGenre(Genre genre)
            => await _gameContext.Games.Where(w => w.Genre == genre).ToListAsync();

        public async Task<Game> GetById(int id)
            => await _gameContext.Games.FirstOrDefaultAsync(f => f.Id == id);

        public async Task Insert(Game model)
        {
            _gameContext.Games.Add(model);
            await _gameContext.SaveChangesAsync();
        }
    }
}
