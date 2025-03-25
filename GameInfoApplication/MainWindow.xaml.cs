using GameInfoApplication.Models;
using GameInfoApplication.Services;
using System.Collections.Generic;
using System.Linq;
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
    private List<GameWithStoreNames> _allGames;
    private IEnumerable<StoreDetails> _allStores;
    private string selectedStore = "All Stores";

    public MainWindow()
    {
        InitializeComponent();
        _gameService = new GameService(_httpClient);
        LoadAllGames();  // Load all games at startup
    }

    private async void LoadAllGames()
    {
        var storedGamesResponse = await _gameService.GetAllGamesAsync();
        if (selectedStore == "All Stores")
        {
            _allGames = storedGamesResponse.Games.ToList();
        }
        else
        {
            _allGames = storedGamesResponse.Games.Where(game => game.StoreNames != null && game.StoreNames.Any(gs => gs == selectedStore)).ToList();
        }

        GamesListBox.ItemsSource = _allGames;

        // Load the stores
        _allStores = await _gameService.GetAllStoresAsync();
        StoreComboBox.Items.Add(new ComboBoxItem { Content = "All Stores" });
        foreach (var store in _allStores)
        {
            StoreComboBox.Items.Add(new ComboBoxItem { Content = store.Name });
        }

        // Set the selected store to its current value
        StoreComboBox.SelectedItem = StoreComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedStore);
    }

    private async void LoadPopularGames_Click(object sender, RoutedEventArgs e)
    {
        var games = await _gameService.GetPopularGamesAsync();
        if (selectedStore == "All Stores")
        {
            _allGames = games.ToList();
        }
        else
        {
            _allGames = games.Where(game => game.StoreNames != null && game.StoreNames.Any(gs => gs == selectedStore)).ToList();
        }

        GamesListBox.ItemsSource = _allGames;
    }

    private async void LoadAllGames_Click(object sender, RoutedEventArgs e)
    {
        LoadAllGames();
    }

    private async void GamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (GamesListBox.SelectedItem is GameWithStoreNames selectedGame)
        {
            var gameDetails = await _gameService.GetGameDetailsAsync(selectedGame.Name);

            // Update game banner & text
            GameNameTextBlock.Text = gameDetails.Name;
            GameBanner.Source = new BitmapImage(new Uri(gameDetails.BackgroundImage));

            // Update details
            RatingTextBlock.Text = gameDetails.Rating.ToString();
            ReleasedTextBlock.Text = gameDetails.Released;
            MetacriticTextBlock.Text = gameDetails.Metacritic.ToString();
            EsrbTextBlock.Text = gameDetails.EsrbRating.Name;

            // Display stores with logos
            StoreListPanel.Children.Clear();
            foreach (var gameStore in gameDetails.GameStores.Values)
            {
                var storeLogo = GetStoreLogo(gameStore.Store.Name);
                var imageUri = new Uri($"pack://application:,,,/Images/{storeLogo}", UriKind.Absolute);
                var image = new Image
                {
                    Source = new BitmapImage(imageUri),
                    Width = 50,  // Ensure logos are visible and appropriately sized
                    Height = 50,
                    Margin = new Thickness(5)
                };
                StoreListPanel.Children.Add(image);
            }
        }
    }

    private void StoreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedStore = (StoreComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

        if (string.IsNullOrEmpty(selectedStore) || selectedStore == "All Stores")
        {
            GamesListBox.ItemsSource = _allGames;
        }
        else
        {
            var filteredGames = _allGames.Where(game =>
                game.StoreNames != null && game.StoreNames.Any(gs => gs == selectedStore)).ToList();
            GamesListBox.ItemsSource = filteredGames;
        }
    }

    private string GetStoreLogo(string storeName)
    {
        var storeLogos = new Dictionary<string, string>
    {
        { "Steam", "steam-logo.png" },
        { "PlayStation Store", "playstation-logo.png" },
        { "Epic Games", "epicgames-logo.png" },
        { "Xbox Store", "xboxstore-logo.png" },
        { "Xbox 360 Store", "xbox360-logo.png" },
        { "App Store", "appstore-logo.png" },
        { "Google Play", "googleplay-logo.png" },
        { "GOG", "gog-logo.png" },
        { "Nintendo Store", "nintendostore-logo.png" }
    };

        return storeLogos.TryGetValue(storeName, out var logo) ? logo : "Images/defaultstore-logo.png";
    }
}
