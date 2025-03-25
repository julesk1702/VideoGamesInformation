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

    public EsrbRating? EsrbRating { get; set; }

    public List<Platform>? Platforms { get; set; } // Nullable to handle missing data
    [JsonPropertyName("GameStores")]
    public GameStoresWrapper? GameStores { get; set; }
}

public class EsrbRating
{
    public int Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
}

public class GameStoresWrapper
{
    [JsonPropertyName("$values")]
    public List<GameStore>? Values { get; set; }
}

public class GameStore
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int StoreId { get; set; }

    [JsonPropertyName("StoreUrl")]
    public string StoreUrl { get; set; }

    [JsonPropertyName("Store")]
    public StoreDetails Store { get; set; }
}

public class StoreDetails
{
    public int PK_ID { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Slug { get; set; }

    [JsonPropertyName("games_count")]
    public int GamesCount { get; set; }

    [JsonPropertyName("image_background")]
    public string? ImageBackground { get; set; }

    public string? Description { get; set; }
}

public class Platform
{
    [JsonPropertyName("platform")]
    public PlatformDetails PlatformInfo { get; set; }

    [JsonPropertyName("released_at")]
    public string? ReleasedAt { get; set; }

    public Requirements? Requirements { get; set; }
}

public class PlatformDetails
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Requirements
{
    public int RequirementsId { get; set; }
    public string? Minimum { get; set; }
    public string? Recommended { get; set; }
}

public class GameWithStoreNames
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Rating { get; set; }

    [JsonPropertyName("background_image")]
    public string BackgroundImage { get; set; }

    public string Released { get; set; }
    public bool Tba { get; set; }
    public int? Metacritic { get; set; }

    [JsonPropertyName("esrb_rating")]
    public string? EsrbRating { get; set; }

    public List<Platform>? Platforms { get; set; } // Keep platforms as they are

    [JsonPropertyName("stores")]
    public List<string>? StoreNames { get; set; } // List of store names only
}
