namespace WeatherForecast.DTO
{
    public class GetWeatherDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double AverageTemperature { get; set; }
        public string Summary { get; set; }
    }
}
