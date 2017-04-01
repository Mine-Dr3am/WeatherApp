namespace WeatherApp
{
    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Country { get; set; }
        public string Pollution { get; set; }
        public string PollutionIndex { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        

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
            this.PollutionIndex = " ";
        }

        public void ChangePollutionIndex()
        {
            if (int.Parse(this.Pollution) > 50)
            {
                this.PollutionIndex = "Bien";
            }
            if (int.Parse(this.Pollution) <= 50 || int.Parse(this.Pollution) > 100)
            {
                this.PollutionIndex = "Modéré";
            }
            if (int.Parse(this.Pollution) <= 100 || int.Parse(this.Pollution) > 150)
            {
                this.PollutionIndex = "Mauvais pour la santé pour les personnes sensibles";
            }
            if (int.Parse(this.Pollution) <= 150 || int.Parse(this.Pollution) > 200)
            {
                this.PollutionIndex = "Mauvais pour la santé";
            }
            if (int.Parse(this.Pollution) <= 200 || int.Parse(this.Pollution) > 300)
            {
                this.PollutionIndex = "Très mauvais pour la santé";
            }
            if (int.Parse(this.Pollution) <= 300)
            {
                this.PollutionIndex = "Dangereux";
            }
        }
    }
}