using Newtonsoft.Json;
using System.Net;
using WeatherAPI.Models;
using WeatherAPI.Models.CurrentForecast;
using WeatherAPI.Models.DailyForecast;

namespace WeatherAPI.Services
{
    public class OpenWeatherHttpClientService
    {
        private IConfiguration _configuration;

        public OpenWeatherHttpClientService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(CurrentWeather, Error)> GetCurrentWeather(string city)
        {
            string currentWeatherURL = string.Format(
                _configuration.GetConnectionString(
                    APIs.CurrentWeatherAPI.ToString()), 
                city);

            var (currentWeather,error) = await Get<CurrentWeather>(currentWeatherURL, new Error());
            return (currentWeather, error);
        }

        public async Task<(WeatherForecast, Error)> GetWeatherForecast(string city)
        {
            string coordURL = string.Format(
                _configuration.GetConnectionString(
                    APIs.CurrentWeatherAPI.ToString()),
                city);

            var (coord, errorCoord) = await Get<Coord>(coordURL, new Error());

            if (!string.IsNullOrEmpty(errorCoord.Code))
                return (new WeatherForecast(), errorCoord);

            string forecastURL = string.Format(
                _configuration.GetConnectionString(
                    APIs.WeatherForecastAPI.ToString()),
                coord.Latitude, coord.Longitude);

            var (weatherForecast, errorForecast) = await Get<WeatherForecast>(forecastURL, new Error());
            weatherForecast.WeatherForecasts = weatherForecast.WeatherForecasts.Take(5).ToList();

            return (weatherForecast, errorForecast);
        }

        private async Task<(T, Error)> Get<T>(string url, Error error) where T : new()
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string response = await streamReader.ReadToEndAsync();
                    return (JsonConvert.DeserializeObject<T>(response), new Error());
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse errorResponse)
                {
                    error.Message = ex.Message;
                    error.Code = ((int)errorResponse.StatusCode).ToString();
                }
                return (new T(), error);
            }
            catch (Exception ex)
            {
                return (new T(), error);
            }
        }
    }
}
