using Newtonsoft.Json;

namespace WeatherAPI.Models.CurrentForecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int Cloudiness { get; set; }
    }
}
