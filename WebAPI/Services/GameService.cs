using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Services
{
    public class GameService
    {
        //private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        private const string BaseUrl = "https://api.rawg.io/api";
        private const string ApiKey = "a8f117850e3b4372a873e9b7e7cbc6a1";

        public GameService(ApplicationDbContext context)
        {
            //_httpClient = httpClient;
            _context = context;
        }

        public async Task<IEnumerable<GameWithStoreNamesDto>> GetPopularGamesAsync()
        {
            return await _context.Games
                .Include(g => g.Platforms)
                    .ThenInclude(p => p.Requirements)
                .Include(g => g.GameStores)
                    .ThenInclude(gs => gs.Store)
                .OrderByDescending(g => g.Rating)
                .Take(10)
                .Select(g => new GameWithStoreNamesDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Rating = g.Rating,
                    BackgroundImage = g.BackgroundImage,
                    Released = g.Released,
                    Tba = g.Tba,
                    Metacritic = g.Metacritic,
                    EsrbRating = g.EsrbRating,
                    Platforms = g.Platforms.Select(p => new Platform
                    {
                        PlatformId = p.PlatformId,
                        Name = p.Name,
                        ReleasedAt = p.ReleasedAt,
                        Requirements = p.Requirements != null ? new Requirements
                        {
                            Minimum = p.Requirements.Minimum,
                            Recommended = p.Requirements.Recommended
                        } : null
                    }).ToList(),
                    StoreNames = g.GameStores.Select(gs => gs.Store.Name).ToList() // Only store names
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<GameWithStoreNamesDto>> GetStoredGamesAsync()
        {
            return await _context.Games
                .Include(g => g.Platforms)
                    .ThenInclude(p => p.Requirements)
                .Include(g => g.GameStores)
                    .ThenInclude(gs => gs.Store)
                .Select(g => new GameWithStoreNamesDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Rating = g.Rating,
                    BackgroundImage = g.BackgroundImage,
                    Released = g.Released,
                    Tba = g.Tba,
                    Metacritic = g.Metacritic,
                    EsrbRating = g.EsrbRating,
                    Platforms = g.Platforms.Select(p => new Platform
                    {
                        PlatformId = p.PlatformId,
                        Name = p.Name,
                        ReleasedAt = p.ReleasedAt,
                        Requirements = p.Requirements != null ? new Requirements
                        {
                            Minimum = p.Requirements.Minimum,
                            Recommended = p.Requirements.Recommended
                        } : null
                    }).ToList(),
                    StoreNames = g.GameStores.Select(gs => gs.Store.Name).ToList() // Only store names
                })
                .ToListAsync();
        }

        public async Task<GameDetails> GetGameDetailsAsync(string name)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == name);
            if (game == null)
            {
                return null;
            }

            var gameDetails = await _context.GameDetails.
                Include(gd => gd.EsrbRating)
                .FirstOrDefaultAsync(gd => gd.Id == game.Id);
            return gameDetails;
        }

        public async Task<IEnumerable<StoreDetails>> GetAllStoresAsync()
        {
            return await _context.StoreDetails.ToListAsync();
        }
    }
}
