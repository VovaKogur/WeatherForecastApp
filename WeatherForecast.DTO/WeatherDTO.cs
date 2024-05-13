using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.DTO
{
    public class WeatherDTO
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public double AverageTemperature { get; set; }
        public string Summary { get; set; }
        [Required]
        public List<HourlyWeatherDTO> HourlyWeathers { get; set; }
    }
}
