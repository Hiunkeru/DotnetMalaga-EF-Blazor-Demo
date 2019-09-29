namespace BlazorApp1.DataAccess.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        public int? WarriorId { get; set; }
        public Warrior Warrior { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
