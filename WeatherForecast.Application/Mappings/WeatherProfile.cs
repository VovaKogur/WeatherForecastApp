using AutoMapper;
using WeatherForecast.Domain.Entities;
using WeatherForecast.DTO;

namespace WeatherForecast.Application.Mappings
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDTO, Weather>()
                .ForMember(dest => dest.HourlyWeathers, opt => opt.Ignore());

            CreateMap<HourlyWeatherDTO, HourlyWeather>()
                .ForMember(dest => dest.Weather, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Weather, WeatherDTO>()
            .ForMember(dest => dest.HourlyWeathers, opt => opt.MapFrom(src => src.HourlyWeathers));

            CreateMap<Weather, GetWeatherDTO>().ReverseMap();
            CreateMap<HourlyWeather, HourlyWeatherDTO>().ReverseMap();
        }
    }
}
