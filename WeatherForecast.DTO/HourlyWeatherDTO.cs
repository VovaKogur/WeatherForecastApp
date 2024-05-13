using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.DTO
{
    public class HourlyWeatherDTO
    {
        public Guid Id { get; set; }
        [Range(0, 23)]
        [Required]
        public int Hour { get; set; }
        [Required]  
        public double TemperatureC { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public Guid WeatherId { get; set; }
    }
}
