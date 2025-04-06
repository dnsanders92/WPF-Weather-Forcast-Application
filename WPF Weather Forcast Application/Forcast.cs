using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WPF_Weather_Forcast_Application
{
    internal class Forcast
    {

        private double[] highTemp = new double[5];
        private double[] lowTemp = new double[5];
        private string[] iconCode = new string[5];


        public double[] HighTemp { get { return highTemp; } set { value = highTemp; } }
        public double[] LowTemp { get { return lowTemp; } set { value = lowTemp; } }
        public string[] IconCode { get { return iconCode; } set { iconCode = value; } }
        public async Task FetchWeatherForcast(string lat, string lon)
        {
            string json = await new HttpClient().GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid=236908b3196ed5091106391e27eca5c9&units=metric");


            for (int i = 0; i < 5; i++)
            {
                DateTime date = DateTime.UtcNow.Date.AddDays(i+1);
                var data = JObject.Parse(json)["list"]
                    .Where(x => DateTime.Parse(x["dt_txt"].ToString()).Date == date);

                highTemp[i] = Math.Round(data.Max(x => (double)x["main"]["temp_max"]),0);
                lowTemp[i] = Math.Round(data.Min(x => (double)x["main"]["temp_min"]),0);
                iconCode[i] = data.First()["weather"].First()["icon"].ToString();
            } 
        }
    }
}
