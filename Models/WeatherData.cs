using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class WeatherData
    {
        private long _date;
        
        [JsonProperty("dt")]
        public string Date
        {
            get { return DateTimeOffset.FromUnixTimeSeconds(_date).DateTime.ToString(); }
            set { _date = long.Parse(value); }
        }
    }
}
