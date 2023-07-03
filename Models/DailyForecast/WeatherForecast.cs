using Newtonsoft.Json;

namespace WeatherAPI.Models.DailyForecast
{
    public class WeatherForecast
    {
        [JsonProperty("daily")]
        public List<DailyWeatherForecast> WeatherForecasts { get; set; }
    }
}
