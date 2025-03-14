using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public class GameDetails
{
    [Key]
    public int Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
    public string? NameOriginal { get; set; }
    public string? Description { get; set; }
    public int? Metacritic { get; set; }
    public List<MetacriticPlatform>? MetacriticPlatforms { get; set; }
    public string? Released { get; set; }
    public bool? Tba { get; set; }
    public string? Updated { get; set; }

    [JsonPropertyName("background_image")]
    public string? BackgroundImage { get; set; }

    [JsonPropertyName("background_image_additional")]
    public string? BackgroundImageAdditional { get; set; }
    public string? Website { get; set; }
    public double Rating { get; set; }
    public int RatingTop { get; set; }
    //public List<Ratings> Ratings { get; set; }
    [NotMapped]
    public Dictionary<string, int>? Reactions { get; set; }
    public int Added { get; set; }
    [NotMapped]
    public Dictionary<string, int>? AddedByStatus { get; set; }
    public int Playtime { get; set; }
    public int ScreenshotsCount { get; set; }
    public int MoviesCount { get; set; }
    public int CreatorsCount { get; set; }

    [JsonPropertyName("achievements_count")]
    public int AchievementsCount { get; set; }
    public string? ParentAchievementsCount { get; set; }
    public string? RedditUrl { get; set; }
    public string? RedditName { get; set; }
    public string? RedditDescription { get; set; }
    public string? RedditLogo { get; set; }
    public int? RedditCount { get; set; }
    public string? TwitchCount { get; set; }
    public string? YoutubeCount { get; set; }
    public string? ReviewsTextCount { get; set; }
    public int? RatingsCount { get; set; }
    public int? SuggestionsCount { get; set; }
    public List<string>? AlternativeNames { get; set; }
    public string? MetacriticUrl { get; set; }
    public int? ParentsCount { get; set; }
    public int? AdditionsCount { get; set; }
    public int? GameSeriesCount { get; set; }
    public EsrbRating? EsrbRating { get; set; }
    public List<PlatformDetails>? Platforms { get; set; }
}

public class MetacriticPlatform
{
    [Key]
    public int Id { get; set; }
    public int? Metascore { get; set; }
    public string? Url { get; set; }
}

public class EsrbRating
{
    [Key]
    public int Id { get; set; }
    public string? Slug { get; set; }
    public string? Name { get; set; }
}

public class PlatformDetails
{
    [Key]
    public int Id { get; set; }
    public Platform? Platform { get; set; }
    public string? ReleasedAt { get; set; }
    public Requirements? Requirements { get; set; }
}