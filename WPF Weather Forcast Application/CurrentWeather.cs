using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WPF_Weather_Forcast_Application
{
    class CurrentWeather
    {
        private double currentTemperature, feelsLikeTemperature, currentHumidity, currentPressure;
        private string weatherConditions;
        private string weatherICON;
        public double CurrentTemperature { get { return currentTemperature; } set { currentTemperature = value; } }
        public double FeelsLikeTemperature { get { return feelsLikeTemperature; } set { feelsLikeTemperature = value; } }
        public double CurrentHumidity { get { return currentHumidity; } set { currentHumidity = value; } }
        public double CurrentPressure { get { return currentPressure; } set { currentPressure = value; } }
        public string WeatherConditions { get { return weatherConditions; } set { weatherConditions = value; } }
        public string WeatherICON { get { return weatherICON; } set { weatherICON = value; } }

        public async Task FetchCurrentWeather(string lat, string lon)
        {

            string apiKey = "236908b3196ed5091106391e27eca5c9";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&cnt={5}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string json = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(json);

                // Current Weather & Conditions //
                currentTemperature = Math.Round((double)weatherData["main"]["temp"],1);
                feelsLikeTemperature = Math.Round((double)weatherData["main"]["feels_like"],1);
                currentHumidity = (double)weatherData["main"]["humidity"];
                currentPressure = (double)weatherData["main"]["pressure"];
                weatherConditions = (string)weatherData["weather"][0]["description"];
                weatherICON = (string)weatherData["weather"][0]["icon"];
            }
        }
    }
}
