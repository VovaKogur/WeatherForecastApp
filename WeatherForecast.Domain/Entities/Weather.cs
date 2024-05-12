using WeatherForecast.Domain.Entities;

public class Weather
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }  
    public double AverageTemperature { get; set; }  
    public string Summary { get; set; }  

    public List<HourlyWeather> HourlyWeathers { get; set; } = new List<HourlyWeather>();
}