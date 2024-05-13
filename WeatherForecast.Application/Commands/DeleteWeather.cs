using MediatR;

namespace WeatherForecast.Application.Commands
{
    public class DeleteWeather : IRequest
    {
        public Guid Id { get; set; }  

        public DeleteWeather(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteWeatherCommandHandler : IRequestHandler<DeleteWeather>
    {
        private readonly IWeatherDomainService _weatherDomainService;

        public DeleteWeatherCommandHandler(IWeatherDomainService weatherDomainService)
        {
            _weatherDomainService = weatherDomainService;
        }

        public async Task Handle(DeleteWeather request, CancellationToken cancellationToken)
        {
            await _weatherDomainService.DeleteWeatherAsync(request.Id);
        }
    }
}
