using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class Error
    {
        [JsonProperty("cod")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public Error()
        {
            Code = string.Empty;
            Message = string.Empty;
        }
    }
}
