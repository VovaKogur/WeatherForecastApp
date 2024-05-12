using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.Entities
{
    public class HourlyWeather
    {
        public Guid Id { get; set; }
        [Range(0, 23)]
        public int Hour { get; set; }
        public double TemperatureC { get; set; }
        public string Summary { get; set; }
        public Guid WeatherId { get; set; }
        public Weather Weather { get; set; }
    }
}
