using Newtonsoft.Json;

namespace WeatherAPI.Models.CurrentForecast
{
    public class CurrentTemperature
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}
