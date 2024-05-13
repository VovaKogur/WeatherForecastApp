using AutoMapper;
using MediatR;
using WeatherForecast.Domain.Entities;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Commands
{
    public class CreateWeather : IRequest<WeatherDTO>
    {
        public WeatherDTO Weather { get; set; }
        public CreateWeather(WeatherDTO weather)
        {
            Weather = weather;
        }
    }
    public class CreateWeatherCommandHandler : IRequestHandler<CreateWeather,WeatherDTO>
    {
        private readonly IWeatherDomainService _weatherDomainService;
        private readonly IMapper _mapper;


        public CreateWeatherCommandHandler(IWeatherDomainService weatherDomainService, IMapper mapper)
        {
            _weatherDomainService = weatherDomainService;
            _mapper = mapper;
        }

        public async Task<WeatherDTO> Handle(CreateWeather request, CancellationToken cancellationToken)
        {
            var weather = _mapper.Map<Weather>(request.Weather);

            foreach (var hourlyDto in request.Weather.HourlyWeathers)
            {
                var hourlyWeather = _mapper.Map<HourlyWeather>(hourlyDto);
                weather.HourlyWeathers.Add(hourlyWeather);
            }

            return _mapper.Map<WeatherDTO>(await _weatherDomainService.CreateWeatherAsync(weather));

        }
    }
}
