using BlazorApp1.Application.Contracts;
using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Application
{
    public class FightService : IFightService
    {
        private readonly IWarriorRepository _warriorRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;

        public FightService(IWarriorRepository warriorRepository, IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _warriorRepository = warriorRepository;
        }

        public async Task<Game> CreateGame(Game game)
        {
            await _gameRepository.CreateGame(game);

            var lastGame = GetLastGame();
            return lastGame;
        }

        public Game GetLastGame()
        {
            var createdGame = _gameRepository.GetLastGame();
            return createdGame;
        }

        public List<Player> GetPlayersLastGame(Game game)
        {
            var players = _gameRepository.GetPlayers(game.Id);
            return players;
        }

        public async Task AddPlayer(Player player, Game game)
        {
            await _playerRepository.AddPlayers(player, game);
        }

        public async Task SelectWarrior(Player player, Warrior warrior)
        {
            await _playerRepository.SelectWarrior(player, warrior);
        }

        public async Task<Warrior> AddWarrior(Warrior warrior)
        {
            return await _warriorRepository.Add(warrior);
        }

        public async Task<List<Warrior>> GetAllWarriors()
        {
            return await _warriorRepository.GetAll();
        }

        public async Task<List<Warrior>> GetNonSelectedWarriors(Warrior warriorToExclude)
        {
            return await _warriorRepository.GetNonSelectedWarriors(warriorToExclude);
        }

        public async Task<Warrior> Attack(Warrior attacker, Warrior target)
        {
            Random random = new Random();
            var maxDamage = CalculateMaxDamage(attacker.Strength);
            var damage = random.Next(1, maxDamage);

            return await InflictDamage(target, damage);
        }

        public async Task<Warrior> CastSpell(Warrior attacker, Warrior target)
        {
            Random random = new Random();
            var maxDamage = CalculateMaxDamage(attacker.Magic);
            var damage = random.Next(1, maxDamage);

            return await InflictDamage(target, damage);
        }

        private int CalculateMaxDamage(int attackStat)
        {
            var maxDamage = attackStat < 0 ? 1 : attackStat;
            return maxDamage;
        }

        private async Task<Warrior> InflictDamage(Warrior target, int damage)
        {
            var newDefense = target.Defense - damage;

            if (newDefense < 0)
            {
                newDefense = 0;
            }

            target.Defense = newDefense;
            await _warriorRepository.GetDamage(target);
            return target;
        }

        public async Task RestoreDefense()
        {
            await _warriorRepository.RestoreAllDefense();
        }
    }
}
