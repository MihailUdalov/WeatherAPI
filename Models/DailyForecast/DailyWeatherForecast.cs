using Newtonsoft.Json;

namespace WeatherAPI.Models.DailyForecast
{
    public class DailyWeatherForecast: WeatherData
    {
        [JsonProperty("temp")]
        public DailyTemperature DailyTemperature { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("clouds")]
        public int Cloudiness { get; set; }
    }
}
