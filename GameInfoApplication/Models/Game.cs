using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace GameInfoApplication.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Rating { get; set; }

    [JsonPropertyName("background_image")]
    public string BackgroundImage { get; set; }
    public string Released { get; set; }
    public bool Tba { get; set; }
    public int? Metacritic { get; set; }
    public string EsrbRating { get; set; }
    public List<Platform> Platforms { get; set; }
}

public class Platform
{
    public int PlatformId { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("released_at")]
    public string ReleasedAt { get; set; }
    public Requirements Requirements { get; set; }
}

public class Requirements
{
    public int RequirementsId { get; set; }
    public string Minimum { get; set; }
    public string Recommended { get; set; }
}
