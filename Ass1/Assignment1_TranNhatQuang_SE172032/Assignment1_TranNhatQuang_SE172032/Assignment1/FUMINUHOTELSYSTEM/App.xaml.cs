using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
using FUMiniHotelSystemClassLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace FUMINUHOTELSYSTEM { 
/*
/// <summary>
/// Interaction logic for App.xaml
/// </summary>

public partial class App : Application
{
    private ServiceProvider serviceProvider;

    public App()
    {
        ServiceCollection services = new();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //   services.AddSingleton(typeof(CustomerRepository), typeof(IGenericRepository));

        services.AddSingleton<LoginPage>();
        *//*      services.AddSingleton<CustomerWindow>();
              services.AddSingleton<RoomWindow>();
              services.AddSingleton<BookingDetailWindow>();
              services.AddSingleton<CustomerProfileWindow>();
              services.AddSingleton<BookingHistoryWindow>();*//*
        //})
    }
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        *//*      var serviceCollection = new ServiceCollection();
              ConfigureServices(serviceCollection);
              serviceProvider = serviceCollection.BuildServiceProvider();
              var loginWindows = serviceProvider.GetService<LoginPage>();
              loginWindows!.ShowDialog();*//*
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve LoginPage with IUnitOfWork dependency
        var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        var loginWindow = serviceProvider.GetService<LoginPage>();
        loginWindow.ShowDialog();
    }

}
*/
    public partial class App : Application
{

    private IHost _host;
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<FUMiniHotelManagementContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DB")));

                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                services.AddSingleton<LoginPage>();
                services.AddSingleton<BookingDetailsWindows>();
                services.AddSingleton<RoomWindows>();
                services.AddSingleton<CustomerWindows>();

                /*
                                services.AddSingleton<CustomerWindow>();
                                services.AddSingleton<RoomWindow>();
                                services.AddSingleton<CustomerProfileWindow>();
                                services.AddSingleton<BookingHistoryWindow>();*/
            })
            .ConfigureLogging(logging =>
            {
               /* logging.ClearProviders();
                logging.AddConsole();*/
            })
            .Build();

        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<LoginPage>();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync(TimeSpan.FromSeconds(5));
        _host.Dispose();
        base.OnExit(e);
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {

    }
}
}


