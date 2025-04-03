using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;


namespace WPF_Weather_Forcast_Application
{
    class OpenWeatherAPI
    {
        private string city = "London";
        private double currentTemperature;
        private double currentHumidity;
        private double currentPressure;
        private string weatherConditions;
        private string weatherConditionsIMG;
        public double CurrentTemperature { get { return currentTemperature; } set { currentTemperature = value; } }
        public double CurrentHumidity {  get { return currentHumidity; } set { currentHumidity = value; } }
        public double CurrentPressure {  get { return currentPressure; } set { currentPressure = value; } }
        public string WeatherConditions { get { return weatherConditions; } set { weatherConditions = value; } }
        public string WeatherConditionsIMG { get { return weatherConditionsIMG; } set { weatherConditionsIMG = value; } }
        public string City { get { return city; } set { city = value; } }
        public async Task FetchCurrentWeather()
        {

            string apiKey = "236908b3196ed5091106391e27eca5c9";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string json = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(json);

                currentTemperature = (double)weatherData["main"]["temp"];
                currentHumidity = (double)weatherData["main"]["humidity"];
                currentPressure = (double)weatherData["main"]["pressure"];
                weatherConditions = (string)weatherData["weather"][0]["description"];
                weatherConditionsIMG = (string)weatherData["weather"][0]["icon"];

            }
        }
    }
}

