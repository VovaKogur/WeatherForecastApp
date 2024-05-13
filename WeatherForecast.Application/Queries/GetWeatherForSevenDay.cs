using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Queries
{
    public class GetWeatherForSevenDays : IRequest<List<GetWeatherDTO>>
    {
        public DateTime StartDate { get; set; }

        public GetWeatherForSevenDays(DateTime startDate)
        {
            StartDate = startDate;
        }
    }

    public class GetWeatherForSevenDaysQueryHandler : IRequestHandler<GetWeatherForSevenDays, List<GetWeatherDTO>>
    {
        private readonly IWeatherContext _context;
        private readonly IMapper _mapper;

        public GetWeatherForSevenDaysQueryHandler(IWeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetWeatherDTO>> Handle(GetWeatherForSevenDays request, CancellationToken cancellationToken)
        {
            var weathers = await _context.Weathers
                .Where(w => w.Date >= request.StartDate && w.Date < request.StartDate.AddDays(7))
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<GetWeatherDTO>>(weathers);
        }
    }


}
