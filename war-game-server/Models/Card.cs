using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace war_game_server.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(2, 14)]
        public int Value { get; set; }
        public int? Position { get; set; } = null;
        public string PhotoPath { get; set; }
        public int PlayerId { get; set; }

        [JsonIgnore]
        public virtual Player? Player { get; set; }

        public Card() { }

    }
}
