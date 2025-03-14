using GameInfoApplication.Models;
using GameInfoApplication.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameInfoApplication;

public partial class MainWindow : Window
{
    private readonly GameService _gameService;
    private readonly HttpClient _httpClient = new();
    public MainWindow()
    {
        InitializeComponent();
        _gameService = new GameService(_httpClient);
        LoadAllGames();  // Load all games at startup
    }

    private async void LoadAllGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        GamesListBox.ItemsSource = games;
    }

    private async void LoadPopularGames_Click(object sender, RoutedEventArgs e)
    {
        var games = await _gameService.GetPopularGamesAsync();
        GamesListBox.ItemsSource = games;
    }

    private async void LoadAllGames_Click(object sender, RoutedEventArgs e)
    {
        LoadAllGames();
    }

    private async void GamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (GamesListBox.SelectedItem is Game selectedGame)
        {
            var gameDetails = await _gameService.GetGameDetailsAsync(selectedGame.Name);
            GameNameTextBlock.Text = gameDetails.Name;
            GameImage.Source = new BitmapImage(new Uri(gameDetails.BackgroundImage));
            GameDetailsTextBlock.Text = $"⭐ Rating: {gameDetails.Rating}\n📅 Released: {gameDetails.Released}\n🎮 Metacritic: {gameDetails.Metacritic}\n🔞 ESRB: {gameDetails.EsrbRating}";
        }
    }
}
