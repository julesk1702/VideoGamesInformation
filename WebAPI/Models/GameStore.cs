using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class GameStore
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int GameId { get; set; }  // ID van de game uit jouw database

    [Required]
    public int StoreId { get; set; }  // ID van de winkel

    public string StoreUrl { get; set; }  // Link naar de storepagina voor de game

    // Navigatieproperties
    public Game Game { get; set; }  // Koppeling naar Game model
    public StoreDetails Store { get; set; }  // Koppeling naar StoreDetails model
}

