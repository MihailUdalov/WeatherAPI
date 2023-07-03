using Newtonsoft.Json;

namespace WeatherAPI.Models.CurrentForecast
{
    public class CurrentWeather : WeatherData
    {
        [JsonProperty("main")]
        public CurrentTemperature Temperature { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
    }
}
