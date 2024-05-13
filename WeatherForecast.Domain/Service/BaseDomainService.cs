using Microsoft.Extensions.Logging;
using WeatherForecast.Domain.Core;

namespace WeatherForecast.Domain.Service
{
    public abstract class BaseDomainService
    {
        protected readonly ILogger _logger;
        protected readonly IWeatherContext _qualityContext;

        protected BaseDomainService(IWeatherContext qualityContext, ILogger logger)
        {
            _qualityContext = qualityContext;
            _logger = logger;
        }
    }
}
