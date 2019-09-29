using BlazorApp1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface IWarriorRepository
    {
        Task<Warrior> Add(Warrior warrior);
        Task<List<Warrior>> GetAll();
        Warrior GetWarriorByName(string warriorName);
        Task GetDamage(Warrior warrior);

        Task RestoreAllDefense();
        Task<List<Warrior>> GetNonSelectedWarriors(Warrior warriorToExclude);
    }
}
