using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;

namespace WeatherForecast.Domain.Service
{
    public class WeatherDomainService : IWeatherDomainService
    {
        private readonly IWeatherContext _context;

        public WeatherDomainService(IWeatherContext context)
        {
            _context = context;
        }

        public async Task<Weather> CreateWeatherAsync(Weather weather)
        {
            _context.Weathers.Add(weather);
            await _context.SaveChangesAsync();
            return weather;  
        }

        public async Task<Weather> UpdateWeatherAsync(Weather weather)
        {
            var existingWeather = await _context.Weathers
                .Include(w => w.HourlyWeathers)
                .SingleOrDefaultAsync(w => w.Id == weather.Id);

            if (existingWeather == null)
            {
                throw new ArgumentException("Weather not found.");
            }
            
            existingWeather.Update(weather);

            await _context.SaveChangesAsync();
            return existingWeather; 
        }

        public async Task DeleteWeatherAsync(Guid weatherId)
        {
            var weather = await _context.Weathers.FindAsync(weatherId);
            if (weather == null)
            {
                throw new ArgumentException("Weather not found.");
            }

            _context.Weathers.Remove(weather);
            await _context.SaveChangesAsync();
        }
    }
}
