using Newtonsoft.Json;

namespace WeatherAPI.Models.DailyForecast
{
    public class DailyTemperature
    {
        [JsonProperty("day")]
        public double DayTemperature { get; set; }
        [JsonProperty("min")]
        public double MinTemperature { get; set; }
        [JsonProperty("max")]
        public double MaxTemperature { get; set; }
    }
}
