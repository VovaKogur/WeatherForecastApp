public interface IWeatherDomainService
{
    Task<Weather> CreateWeatherAsync(Weather weather);
    Task<Weather> UpdateWeatherAsync(Weather weather);
    Task DeleteWeatherAsync(Guid weatherId);
}