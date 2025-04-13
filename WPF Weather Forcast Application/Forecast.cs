using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WPF_Weather_Forcast_Application
{
    internal class Forecast
    {
        private double[] highTemp = new double[14];
        private double[] lowTemp = new double[14];
        private string[] iconCode = new string[14];


        public double[] HighTemp { get { return highTemp; } set { value = highTemp; } }
        public double[] LowTemp { get { return lowTemp; } set { value = lowTemp; } }
        public string[] IconCode { get { return iconCode; } set { iconCode = value; } }


        public async Task FetchWeatherForecast(string lat, string lon, string unit)
        {

            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast/daily?lat={lat}&lon={lon}&cnt=14&appid=83feabd1f836fa21111dbcec35f198cf&units={unit}";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(apiUrl);

                var forecastList = JObject.Parse(json)["list"];

                int count = forecastList.Count();
                for (int i = 0; i < Math.Min(count, 14); i++)
                {
                    var dayData = forecastList[i];

                    double maxTemp = (double)dayData["temp"]["max"];
                    double minTemp = (double)dayData["temp"]["min"];
                    string icon = dayData["weather"][0]["icon"].ToString();

                    HighTemp[i] = Math.Round(maxTemp, 0);
                    LowTemp[i] = Math.Round(minTemp, 0);
                    IconCode[i] = icon;
                }
            }
        }
    }
}