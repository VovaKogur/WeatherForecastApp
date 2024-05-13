using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.Entities
{
    public class HourlyWeather : EntityBase
    {
        public Guid Id { get; private set; }
        [Range(0, 23)]
        public int Hour { get; private set; }
        public double TemperatureC { get; private set; }
        public string Summary { get; private set; }
        public Guid WeatherId { get; private set; }
        public Weather Weather { get; private set; }
        public HourlyWeather(Guid id, int hour, double temperatureC, string summary, Guid weatherId, Weather weather)
        {
            Id = id;
            Hour = hour;
            TemperatureC = temperatureC;
            Summary = summary;
            WeatherId = weatherId;
            Weather = weather;
        }

        public void Update(int hour, double temperatureC, string summary, Guid weatherId, Weather weather)
        {
            Hour = hour;
            TemperatureC = temperatureC;
            Summary = summary;
            WeatherId = weatherId;
            Weather = weather;
        }


    }
}
