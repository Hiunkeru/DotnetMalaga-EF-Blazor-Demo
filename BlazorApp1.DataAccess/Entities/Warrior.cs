using System.Collections.Generic;

namespace BlazorApp1.DataAccess.Entities
{
    public class Warrior
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }

        public string ImageUrl { get; set; }

        public List<Player> Players { get; set; }
    }
}
