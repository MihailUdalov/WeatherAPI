using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherAPI.Models;
using WeatherAPI.Models.CurrentForecast;
using WeatherAPI.Models.DailyForecast;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        OpenWeatherHttpClientService _openWeatherAPIManager;

        public WeatherController(IConfiguration config)
        {
            _openWeatherAPIManager = new OpenWeatherHttpClientService(config);
        }

        /// <summary>
        /// Get weather in specific city.
        /// </summary>
        [HttpGet("GetCurrentWeather")]
        public async Task<ActionResult<CurrentWeather>> GetCurrentWeather(string city)
        {
            var (currentWeather, error) = await _openWeatherAPIManager.GetCurrentWeather(city);

            return ResponseHandling(currentWeather, error);
        }

        /// <summary>
        /// Get forecast for specific city.
        /// </summary>
        [HttpGet("GetForecast")]
        public async Task<ActionResult<WeatherForecast>> GetForecast(string city)
        {
            var (forecast, error) = await _openWeatherAPIManager.GetWeatherForecast(city);

            return ResponseHandling(forecast, error);
        }

        private ActionResult<T> ResponseHandling<T>(T response, Error error)
        {
            switch (error.Code)
            {
                case "400":
                    return BadRequest(error);
                case "401":
                    return Unauthorized(error);
                case "404":
                    return NotFound(error);
                case "429":
                    return StatusCode((int)HttpStatusCode.TooManyRequests, error);
                case "5xx":
                    return StatusCode((int)HttpStatusCode.InternalServerError, error);
                default:
                    return Ok(response);
            }
        }
    }
}