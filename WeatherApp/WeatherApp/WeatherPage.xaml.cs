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
            this.BindingContext = weather;
        }
        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Rechercher";
                }
            }
            else
            {
                Weather weather = await Core.GetStartWeather();
            }
        }
    }
}