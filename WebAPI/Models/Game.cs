using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Rating { get; set; }
        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }
        public string? Released { get; set; }

        public bool Tba { get; set; }
        public int? Metacritic { get; set; }
        public string? EsrbRating { get; set; }

        public List<Platform>? Platforms { get; set; }

        //public List<Ratings> Ratings { get; set; }
    }

    public class Platform
    {
        [Key] // Primary Key for Platform
        public int PlatformId { get; set; }

        public string? Name { get; set; }

        [JsonPropertyName("released_at")]
        public string? ReleasedAt { get; set; }

        // Foreign key to Requirements
        public int? RequirementsId { get; set; }

        public Requirements? Requirements { get; set; }
    }

    public class Requirements
    {
        [Key] // Primary Key for Requirements
        public int RequirementsId { get; set; }

        public string? Minimum { get; set; }
        public string? Recommended { get; set; }
    }
}
