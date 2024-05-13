using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherForecast.Domain.Core;

public class DailyDatabaseCleanupService : BackgroundService
{
    private readonly ILogger<DailyDatabaseCleanupService> _logger;
    private readonly IWeatherContext _context;

    public DailyDatabaseCleanupService(ILogger<DailyDatabaseCleanupService> logger, IWeatherContext context)
    {
        _logger = logger;
        _context = context;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Running daily data cleanup at: {time}", DateTimeOffset.Now);

            try
            {
                await CleanUpOldDataAsync();
                _logger.LogInformation("Data cleanup completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing data cleanup.");
            }

            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }

    private async Task CleanUpOldDataAsync()
    {
        var commandText = "EXEC DeleteOldWeatherData";
        var result = await _context.ExecuteSqlCommandAsync(commandText);
        _logger.LogInformation($"Deleted old data. Rows affected: {result}");
    }
}
