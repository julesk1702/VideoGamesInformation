using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public class StoreDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PK_ID { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Domain { get; set; }

    public string Slug { get; set; }

    [JsonPropertyName("games_count")]
    public int GamesCount { get; set; }

    [JsonPropertyName("image_background")]
    public string? ImageBackground { get; set; }

    public string? Description { get; set; }

    // Navigatieproperty: Welke games zijn in deze winkel beschikbaar?
    public ICollection<GameStore> GameStores { get; set; } = new List<GameStore>();
}

