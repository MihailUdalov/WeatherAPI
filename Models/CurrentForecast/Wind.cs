using Newtonsoft.Json;

namespace WeatherAPI.Models.CurrentForecast
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
