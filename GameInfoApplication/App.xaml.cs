using GameInfoApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace GameInfoApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<GameService>();
        // Ensure that the MainWindow is registered as a transient or singleton
        services.AddSingleton<MainWindow>();
    }
}
