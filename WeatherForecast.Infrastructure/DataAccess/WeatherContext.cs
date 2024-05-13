using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.DataAccess
{
    public class WeatherContext : DbContext, IWeatherContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }
        public DbSet<HourlyWeather> HourlyWeathers { get; set; }

        public async Task<int> ExecuteSqlCommandAsync(string sql)
        {
            return await Database.ExecuteSqlRawAsync(sql);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }

        
    }
}
