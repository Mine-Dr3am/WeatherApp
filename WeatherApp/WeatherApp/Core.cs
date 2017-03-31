using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "7fecffff83edb60a46a1aafef9dd8f17";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q="
                + zipCode + "&units=metric&lang=fr&appid=" + key;
            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = ((double)results["main"]["temp"]) + " °C";
                weather.Wind = (double)results["wind"]["speed"] + " Km/h";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["description"];
                weather.Visibility = char.ToUpper(weather.Visibility[0]) + weather.Visibility.Substring(1);
                weather.Country = (string)results["sys"]["country"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Weather> GetStartWeather()
        {
            string key = "7fecffff83edb60a46a1aafef9dd8f17";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=Grenoble&units=metric&lang=fr&appid=" + key;
            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //string polutionKey = "QfxTry6YjuZ3Wx9YJ";
            //var lat = results["coord"]["lat"];
            //var lon = results["coord"]["lon"];

            //string queryStringPolution = "http://api.airvisual.com/v2/nearest_city?lat=45&lon=5&rad=Value&key=" + polutionKey;
            //var polutionResults = await DataService.getDataFromService(queryStringPolution).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = ((double)results["main"]["temp"]) + " °C";
                weather.Wind = (double)results["wind"]["speed"] + " Km/h";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["description"];
                weather.Visibility = char.ToUpper(weather.Visibility[0]) + weather.Visibility.Substring(1);
                weather.Country = (string)results["sys"]["country"];
                //weather.Pollution = (string)polutionResults["data"]["current"]["pollution"]["aqius"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}