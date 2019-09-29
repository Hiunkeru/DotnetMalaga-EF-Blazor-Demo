using System.Collections.Generic;

namespace BlazorApp1.DataAccess.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public List<Player> Players { get; set; }
    }
}
