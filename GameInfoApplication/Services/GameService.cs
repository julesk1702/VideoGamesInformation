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

    public async Task<IEnumerable<GameWithStoreNames>> GetPopularGamesAsync()
    {
        var url = $"{BaseUrl}/games/popular";
        var response = await _httpClient.GetStringAsync(url);
        var result = JsonSerializer.Deserialize<IEnumerable<GameWithStoreNames>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result;
    }

    public async Task<StoredGamesResponse> GetAllGamesAsync()
    {
        var url = $"{BaseUrl}/games/stored";
        var response = await _httpClient.GetStringAsync(url);
        var storedGamesResponse = JsonSerializer.Deserialize<StoredGamesResponse>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return storedGamesResponse;
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

    public async Task<IEnumerable<StoreDetails>> GetAllStoresAsync()
    {
        var url = $"{BaseUrl}/games/stores";
        var response = await _httpClient.GetStringAsync(url);
        var result = JsonSerializer.Deserialize<IEnumerable<StoreDetails>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
}

public class StoredGamesResponse
{
    public List<GameWithStoreNames> Games { get; set; }
    public List<StoreDetails> Stores { get; set; }
}
