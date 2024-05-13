using AutoMapper;
using MediatR;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Commands
{
    public class UpdateWeather : IRequest<WeatherDTO>
    {
        public WeatherDTO Weather { get; set; }

        public UpdateWeather(WeatherDTO weather)
        {
            Weather = weather;
        }
    }

    public class UpdateWeatherCommandHandler : IRequestHandler<UpdateWeather, WeatherDTO>
    {
        private readonly IWeatherDomainService _weatherDomainService;
        private readonly IMapper _mapper;

        public UpdateWeatherCommandHandler(IWeatherDomainService weatherDomainService, IMapper mapper)
        {
            _weatherDomainService = weatherDomainService;
            _mapper = mapper;
        }

        public async Task<WeatherDTO> Handle(UpdateWeather request, CancellationToken cancellationToken)
        {
            var weather = _mapper.Map<Weather>(request.Weather);

            return _mapper.Map<WeatherDTO>(await _weatherDomainService.UpdateWeatherAsync(weather));

        }
    }
}
