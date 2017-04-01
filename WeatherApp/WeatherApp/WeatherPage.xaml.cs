using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            this.Title = "Application Météo";
            GetWeatherStarted();
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            //Set the default binding to a default object for now
           
            this.BindingContext = new Weather();

        }
        private async void GetWeatherStarted()
        {
            Weather weather = await Core.GetStartWeather();
            GetColor(weather);
            this.BindingContext = weather;
        }
        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    GetColor(weather);
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Rechercher";
                }
            }
            else
            {
                Weather weather = await Core.GetStartWeather();
            }
        }
        public void GetColor(Weather weather)
        {
            if(weather.Day == "Nuit")
            {
                weather.color1 = "#0D1F68";
                weather.color2 = "#0D3E6D";
                weather.color3 = "#1D4C5E";
            }
            else
            {
                weather.color1 = "#0B29A2";
                weather.color2 = "#3387D7";
                weather.color3 = "#3DBBEB";
            }
        }
    }
}