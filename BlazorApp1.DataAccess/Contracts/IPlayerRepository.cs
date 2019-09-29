using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.DataAccess.Entities;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface IPlayerRepository
    {
        Task AddPlayers(Player player, Game game);
        Task SelectWarrior(Player player, Warrior warrior);
    }
}
