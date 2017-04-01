using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "7fecffff83edb60a46a1aafef9dd8f17";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + zipCode + "&units=metric&lang=fr&appid=" + key;
            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            var lat = results["coord"]["lat"];
            var lon = results["coord"]["lon"];


            string polutionKey = "QfxTry6YjuZ3Wx9YJ";
            string queryStringPolution = "http://api.airvisual.com/v2/nearest_city?lat=" + lat +"&lon=" + lon + "&key=" + polutionKey;
            var polutionResults = await DataService.getDataFromService(queryStringPolution).ConfigureAwait(false);

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
                weather.Pollution = (string)polutionResults["data"]["current"]["pollution"]["aqius"] + " AQI (Air Quality Index)";

                weather.Sunrise = (string)results["sys"]["sunrise"];
                weather.Sunset = (string)results["sys"]["sunset"];
                weather.Datetime = (string)results["dt"];


                int datetime = int.Parse(weather.Datetime);
                int sunrise = int.Parse(weather.Sunrise);
                int sunset = int.Parse(weather.Sunset);

                if (datetime < sunset)//Si c'est le jour 
                {
                    weather.Day = "Jour";
                }
                else
                {
                    weather.Day = "Nuit";
                }

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

            string polutionKey = "QfxTry6YjuZ3Wx9YJ";
            string queryStringPolution = "http://api.airvisual.com/v2/nearest_city?lat=45.1666700&lon=5.7166700&key=" + polutionKey;
            var polutionResults = await DataService.getDataFromService(queryStringPolution).ConfigureAwait(false);

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
                weather.Pollution = (string)polutionResults["data"]["current"]["pollution"]["aqius"] + " AQI (Air Quality Index)";

                weather.Sunrise = (string)results["sys"]["sunrise"];
                weather.Sunset =  (string)results["sys"]["sunset"];
                weather.Datetime = (string)results["dt"];


                int datetime = int.Parse(weather.Datetime);
                int sunrise = int.Parse(weather.Sunrise);
                int sunset= int.Parse(weather.Sunset);

                if(datetime > sunrise)//Si c'est le jour 
                {
                    weather.Day = "Jour";
                }
                else
                {
                    weather.Day = "Nuit";
                }
                return weather;
            }
            else
            {   
                return null;
            }
        }

        
           
    }
}