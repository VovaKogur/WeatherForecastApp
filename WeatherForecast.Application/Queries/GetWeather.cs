using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Queries
{
    public class GetWeather : IRequest<GetWeatherDTO>
    {
        public Guid Id { get; set; }

        public GetWeather(Guid id)
        {
            Id = id;
        }
    }

    public class GetWeatherQueryHandler : IRequestHandler<GetWeather, GetWeatherDTO>
    {
        private readonly IWeatherContext _context;
        private readonly IMapper _mapper;

        public GetWeatherQueryHandler(IWeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetWeatherDTO> Handle(GetWeather request, CancellationToken cancellationToken)
        {
            var weather = await _context.Weathers
                .FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

            if (weather == null)
                throw new KeyNotFoundException("Weather not found with the provided ID.");

            return _mapper.Map<GetWeatherDTO>(weather);
        }
    }

}
