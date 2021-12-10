namespace war_game_server.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Card>? Cards { get; set; }

        public Player() { }
    }
}
