using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DataAccess.Entities;
using System.Linq;

namespace BlazorApp1.DataAccess.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DemoContext _context;

        public GameRepository(DemoContext context)
        {
            _context = context;
        }

        public Game GetGame(int gameId)
        {
            return _context.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public async Task CreateGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public List<Game> GetAllRepository()
        {
            return _context.Games.ToList();
        }

        public Game GetLastGame()
        {
            var result = _context.Games.OrderByDescending(g => g.Id).FirstOrDefault();
            return result;
        }

        public List<Player> GetPlayers(int gameId)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);

            if (game == null)
            {
                return null;
            }
            return game.Players;
        }
    }
}
