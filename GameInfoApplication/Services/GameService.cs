using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using GameInfoApplication.Models;

namespace GameInfoApplication.Services;

public class GameService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7296/api";

    public GameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Game>> GetPopularGamesAsync()
    {
        var url = $"{BaseUrl}/games/popular";
        var response = await _httpClient.GetStringAsync(url);
        var result = JsonSerializer.Deserialize<IEnumerable<Game>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result;
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        var url = $"{BaseUrl}/games/stored";
        var response = await _httpClient.GetStringAsync(url);
        var result = JsonSerializer.Deserialize<IEnumerable<Game>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }

    public async Task<Game> GetGameDetailsAsync(string name)
    {
        var url = $"{BaseUrl}/games/details/{name}";
        var response = await _httpClient.GetStringAsync(url);
        var gameDetails = JsonSerializer.Deserialize<Game>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return gameDetails;
    }
}
