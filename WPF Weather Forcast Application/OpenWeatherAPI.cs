using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace WPF_Weather_Forcast_Application
{
    class OpenWeatherAPI
    {
        private double currentTemperature;
        public double CurrentTemperature { get { return currentTemperature; } set { currentTemperature = value; } }

        public async Task FetchCurrentWeather()
        {
            string city = "Derry";
            string apiKey = "236908b3196ed5091106391e27eca5c9";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string json = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(json);

                currentTemperature = (double)weatherData["main"]["temp"];
            }
        }
    }
}
