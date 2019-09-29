using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.DataAccess.Entities;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface IGameRepository
    {
        public Game GetGame(int gameId);
        public List<Game> GetAllRepository();
        public Task CreateGame(Game game);
        public Game GetLastGame();
        public List<Player> GetPlayers(int gameId);
    }
}
