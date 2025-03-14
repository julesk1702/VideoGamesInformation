using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using System.Text.Json.Serialization;

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

        public async Task<IEnumerable<Game>> GetPopularGamesAsync()
        {
            // Return the top 10 popular games from the database based on the rating
            return await _context.Games.OrderByDescending(g => g.Rating).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetStoredGamesAsync()
        {
            return await _context.Games.Include(g => g.Platforms).ThenInclude(p => p.Requirements).ToListAsync();
        }

        public async Task<GameDetails> GetGameDetailsAsync(string name)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == name);
            if (game == null)
            {
                return null;
            }

            var gameDetails = await _context.GameDetails.FirstOrDefaultAsync(gd => gd.Id == game.Id);
            return gameDetails;
        }
    }
}
