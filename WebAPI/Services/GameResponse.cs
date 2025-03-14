using WebAPI.Models;

namespace WebAPI.Services;

public class GameResponse
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<Game> Results { get; set; }
}
