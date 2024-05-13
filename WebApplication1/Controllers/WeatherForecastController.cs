using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Commands;
using WeatherForecast.Application.Queries;
using WeatherForecast.DTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create Weather
        /// </summary>
        /// <param name="weatherDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWeather([FromBody] WeatherDTO weatherDto)
        {
            var result = await _mediator.Send(new CreateWeather(weatherDto));
            return Ok(result);
        }

        /// <summary>
        /// Get Weather by id
        /// </summary>
        /// <param name="id">Id of Weather</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetWeatherDTO>> GetWeather(Guid id)
        {
            var result = await _mediator.Send(new GetWeather(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Get weekly forecast
        /// </summary>
        /// <param name="startDate"> start date of week</param>
        /// <returns></returns>
        [HttpGet("week/{startDate}")]
        public async Task<ActionResult<List<GetWeatherDTO>>> GetWeatherForSevenDays(DateTime startDate)
        {
            var result = await _mediator.Send(new GetWeatherForSevenDays(startDate));
            return Ok(result);
        }

        /// <summary>
        /// Get Hourly forecast
        /// </summary>
        /// <param name="weatherId"></param>
        /// <returns></returns>
        [HttpGet("hourly/{weatherId}")]
        public async Task<ActionResult<List<HourlyWeatherDTO>>> GetHourlyWeather(Guid weatherId)
        {
            var result = await _mediator.Send(new GetHourlyWeather(weatherId));
            return Ok(result);
        }

        /// <summary>
        /// Update weather
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weatherDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeather(int id, [FromBody] WeatherDTO weatherDto)
        {
            var result = await _mediator.Send(new UpdateWeather(weatherDto));
            return Ok(result);
        }

        /// <summary>
        /// Delete weather
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(Guid id)
        {
            await _mediator.Send(new DeleteWeather(id));
            return NoContent();
        }
    }
}
