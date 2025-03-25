using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using WebAPI.Data;
using Azure;
using System.Text.Json.Serialization;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly GameService _gameService;
    private readonly HttpClient _httpClient = new();
    private const string BaseUrl = "https://api.rawg.io/api";
    private const string ApiKey = "a8f117850e3b4372a873e9b7e7cbc6a1";

    public GameController(ApplicationDbContext context, GameService gameService)
    {
        _gameService = gameService;
        _context = context;
    }

    [HttpGet("popular")]
    public async Task<ActionResult<List<GameWithStoreNamesDto>>> GetPopularGames()
    {
        var games = await _gameService.GetPopularGamesAsync();
        return Ok(games);
    }

    [HttpPost("populate")]
    public async Task<IActionResult> PopulateGameStores()
    {
        var games = await _context.Games.ToListAsync(); // Haal alle games op

        foreach (var game in games)
        {
            // ✅ Vraag de stores op voor deze game
            var storeResponse = await _httpClient.GetAsync($"https://api.rawg.io/api/games/{game.Id}/stores?key={ApiKey}");
            if (!storeResponse.IsSuccessStatusCode)
            {
                // Log the error response
                Console.WriteLine($"Failed to fetch stores for game {game.Id}: {storeResponse.ReasonPhrase}");
                continue;
            }

            var storeData = await storeResponse.Content.ReadAsStringAsync();
            var storeResults = JsonSerializer.Deserialize<RawgStoreResponse>(storeData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (storeResults?.Results == null)
            {
                // Log the null result
                Console.WriteLine($"No store results for game {game.Id}");
                continue;
            }

            foreach (var result in storeResults.Results)
            {
                // ✅ Check of de store al bestaat in StoreDetails
                var storeExists = await _context.StoreDetails.FirstOrDefaultAsync(s => s.Id == result.StoreId);
                if (storeExists == null)
                {
                    // Haal store details op
                    var storeDetailResponse = await _httpClient.GetAsync($"https://api.rawg.io/api/stores/{result.StoreId}?key={ApiKey}");
                    if (!storeDetailResponse.IsSuccessStatusCode)
                    {
                        // Log the error response
                        Console.WriteLine($"Failed to fetch store details for store {result.StoreId}: {storeDetailResponse.ReasonPhrase}");
                        continue;
                    }

                    var storeDetailData = await storeDetailResponse.Content.ReadAsStringAsync();
                    var storeDetail = JsonSerializer.Deserialize<StoreDetails>(storeDetailData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (storeDetail == null)
                    {
                        // Log the null store detail
                        Console.WriteLine($"Failed to deserialize store details for store {result.StoreId}");
                        continue;
                    }

                    // Voeg toe aan database
                    _context.StoreDetails.Add(storeDetail);
                    await _context.SaveChangesAsync();

                    // Update storeExists with the newly added store
                    storeExists = storeDetail;
                }

                // ✅ Voeg de relatie toe aan GameStore als die nog niet bestaat
                var existingGameStore = await _context.GameStores.FirstOrDefaultAsync(gs => gs.GameId == game.Id && gs.StoreId == storeExists.PK_ID);
                if (existingGameStore == null)
                {
                    var gameStore = new GameStore
                    {
                        GameId = game.Id,
                        StoreId = storeExists.PK_ID,
                        StoreUrl = result.Url
                    };

                    _context.GameStores.Add(gameStore);
                }
            }
        }

        await _context.SaveChangesAsync();
        return Ok(new { message = "Game stores succesvol bijgewerkt!" });
    }

    private class RawgStoreResponse
    {
        public List<RawgStoreResult> Results { get; set; }
    }

    private class RawgStoreResult
    {
        public int Id { get; set; }
        [JsonPropertyName("store_id")]
        public int StoreId { get; set; }
        public string Url { get; set; }
    }



    [HttpGet("stored")]
    public async Task<ActionResult<IEnumerable<StoredGamesResponse>>> GetStoredGames()
    {
        // Return the StoredGamesResponse with games and stores
        var games = await _gameService.GetStoredGamesAsync();
        var stores = await _context.StoreDetails.ToListAsync();

        return Ok(new StoredGamesResponse
        {
            games = games,
            stores = stores
        });
    }

    [HttpGet("details/{name}")]
    public async Task<ActionResult<GameDetails>> GetGameDetails(string name)
    {
        var gameDetails = await _gameService.GetGameDetailsAsync(name);

        if (gameDetails == null)
        {
            return NotFound();
        }

        // Load the GameStores (eager loading)
        var gameStores = await _context.GameStores
            .Where(gs => gs.Game.Name == name)
            .Include(gs => gs.Store)
            .Select(gs => new GameStore
            {
                StoreId = gs.StoreId,
                StoreUrl = gs.StoreUrl,
                Store = new StoreDetails
                {
                    PK_ID = gs.Store.PK_ID,
                    Name = gs.Store.Name,
                    Domain = gs.Store.Domain,
                    Slug = gs.Store.Slug,
                    GamesCount = gs.Store.GamesCount,
                    ImageBackground = gs.Store.ImageBackground,
                    Description = gs.Store.Description
                }
            })
            .ToListAsync();

        gameDetails.GameStores = gameStores;

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Ok(JsonSerializer.Serialize(gameDetails, options));
    }

    [HttpGet("stores")]
    public async Task<ActionResult<IEnumerable<StoreDetails>>> GetStores()
    {
        var stores = await _context.StoreDetails.ToListAsync();
        return Ok(stores);
    }

}

public class StoredGamesResponse
{
    public IEnumerable<GameWithStoreNamesDto> games { get; set; }
    public IEnumerable<StoreDetails> stores { get; set; }
}