using BlazorApp1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Application.Contracts
{
    public interface IFightService
    {
        Task<Game> CreateGame(Game game);
        Game GetLastGame();
        List<Player> GetPlayersLastGame(Game game);
        Task AddPlayer(Player player, Game game);
        Task SelectWarrior(Player player, Warrior warrior);

        Task<Warrior> Attack(Warrior attacker, Warrior target);
        Task<Warrior> CastSpell(Warrior attacker, Warrior target);

        Task<Warrior> AddWarrior(Warrior warrior);
        Task<List<Warrior>> GetAllWarriors();
        Task<List<Warrior>> GetNonSelectedWarriors(Warrior warriorToExclude);

        Task RestoreDefense();
    }
}
