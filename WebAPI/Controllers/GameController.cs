using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("popular")]
    public async Task<ActionResult<List<Game>>> GetPopularGames()
    {
        var games = await _gameService.GetPopularGamesAsync();
        return Ok(games);
    }

    [HttpGet("stored")]
    public async Task<ActionResult<IEnumerable<Game>>> GetStoredGames()
    {
        var games = await _gameService.GetStoredGamesAsync();
        return Ok(games);
    }

    [HttpGet("details/{name}")]
    public async Task<ActionResult<GameDetails>> GetGameDetails(string name)
    {
        var gameDetails = await _gameService.GetGameDetailsAsync(name);
        if (gameDetails == null)
        {
            return NotFound();
        }
        return Ok(gameDetails);
    }
}
