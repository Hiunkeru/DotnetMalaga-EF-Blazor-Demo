using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DataAccess.Entities;

namespace BlazorApp1.DataAccess.Repositories
{
    public class WarriorRepository : IWarriorRepository
    {
        public readonly DemoContext _context;
        public WarriorRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task<Warrior> Add(Warrior warrior)
        {
            _context.Warrior.Add(warrior);
            await _context.SaveChangesAsync();

            return warrior;
        }

        public async Task<List<Warrior>> GetAll()
        {
            return _context.Warrior.ToList();
        }

        public Warrior GetWarriorByName(string warriorName)
        {
            return _context.Warrior.FirstOrDefault(w => w.Name == warriorName);
        }

        public async Task GetDamage(Warrior target)
        {
            _context.Warrior.Update(target);
            await _context.SaveChangesAsync();
        }

        public async Task RestoreAllDefense()
        {
            var warriors = _context.Warrior.ToList();

            foreach (var warrior in warriors)
            {
                warrior.Defense = 10;
            }

            _context.Warrior.UpdateRange(warriors);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Warrior>> GetNonSelectedWarriors(Warrior warriorToExclude)
        {
            if (warriorToExclude == null)
            {
                return await GetAll();
            }

            var warrior = GetWarriorByName(warriorToExclude.Name);

            var warriors = _context.Warrior.Where(w => w.Id != warrior.Id);

            return warriors.ToList();
        }

    }
}
