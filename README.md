# Serilog for ASP.NET Core 3.x

[Serilog](https://serilog.net/)

[Setting up Serilog in ASP.NET Core 3](https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/)

[Serilog Tutorial](https://blog.datalust.co/serilog-tutorial/)

## Installation

Tilføj følgende NuGet-pakke:

```
Install-package Serilog.AspNetCore
```

Konfiguration laves i Program-klassen og kan f.eks. se således ud i ASP.NET Core 3.1:
```c#
public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()

            .WriteTo.Console(
                LogEventLevel.Verbose,
                "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
            .WriteTo.File("Logs/log.txt", LogEventLevel.Error)
            .CreateLogger();

        try
        {
            Log.Information("Starting up");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

&nbsp;

### Cleaning up
i appSettings.json kan man nu fjerne Microsoft konfigurationen for den indbyggede logger:
```json
{
  "AllowedHosts": "*"
}
```

&nbsp;

### Skriv egne log events
Hvis man f.eks. ønsker at logge noget fra en PageModel, skal logger-servicen injectes
og derefter har man adgang til at skrive ud i de forskellige kanaler, såsom *Information* eller *Error*:

```c#
public ListModel(IRestaurantService restaurantService, ILogger<ListModel> logger)
{
    this.logger = logger;
    _restaurantService = restaurantService;
}

public void OnGet()
{
    logger.LogError("****************************** Simulering af en Error ************************");
    Restaurants = _restaurantService.GetRestaurantsByName(SearchTerm).ToList();
}
```

Bemærk at ILogger er generic og skal types til den aktuelle PageModel (her hedder den `ListModel`).






