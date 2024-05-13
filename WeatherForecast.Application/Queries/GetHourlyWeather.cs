using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Core;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Queries
{
    public class GetHourlyWeather : IRequest<List<HourlyWeatherDTO>>
    {
        public Guid WeatherId { get; set; }

        public GetHourlyWeather(Guid weatherId)
        {
            WeatherId = weatherId;
        }
    }

    public class GetHourlyWeatherQueryHandler : IRequestHandler<GetHourlyWeather, List<HourlyWeatherDTO>>
    {
        private readonly IWeatherContext _context;
        private readonly IMapper _mapper;

        public GetHourlyWeatherQueryHandler(IWeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HourlyWeatherDTO>> Handle(GetHourlyWeather request, CancellationToken cancellationToken)
        {
            var hourlyWeathers = await _context.HourlyWeathers
                .Where(hw => hw.WeatherId == request.WeatherId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<HourlyWeatherDTO>>(hourlyWeathers);
        }
    }

}
