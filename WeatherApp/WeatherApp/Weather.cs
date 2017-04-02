namespace WeatherApp
{
    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Datetime { get; set; }
        public string Visibility { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Country { get; set; }
        public string Pollution { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Day { get; set; }
        public string color1 { get; set; }
        public string color2 { get; set; }
        public string color3 { get; set; }


        public Weather()
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.Title = " ";
            this.Temperature = " ";
            this.Wind = " ";
            this.Humidity = " ";
            this.Visibility = " ";
            this.Sunrise = " ";
            this.Sunset = " ";
            this.Country = " ";
            this.Pollution = " ";
            this.Lon = " ";
            this.Lat = " ";
            this.Datetime = " ";
            this.Day = " ";
            this.color1 = "#0B29A2";
            this.color2 = "#3387D7";
            this.color3 = "#3DBBEB";
        }

       
    }
}