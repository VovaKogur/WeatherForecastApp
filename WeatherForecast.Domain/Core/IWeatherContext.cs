using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Core
{
    public interface IWeatherContext
    {
        DbSet<Weather> Weathers { get; set; }
        DbSet<HourlyWeather> HourlyWeathers { get; set; }

        Task<int> SaveChangesAsync();
        Task<int> ExecuteSqlCommandAsync(string sql);
    }
}
