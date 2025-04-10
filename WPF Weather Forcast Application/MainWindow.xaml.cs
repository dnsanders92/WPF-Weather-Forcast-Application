using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace WPF_Weather_Forcast_Application
{
    public partial class MainWindow : Window
    {

        private static string lat = "51.509865";
        private static string lon = "-0.118092";
        string city = "London";
        public static string Lat { get { return lat; } set { lat = value; } }
        public static string Lon { get { return lon; } set { lon = value; } }

        public MainWindow()
        {
            InitializeComponent();
            CurrentWeather();
            Forcast();
        }
        private async void CurrentWeather()
        {
            CurrentWeather CurrentWeather = new CurrentWeather();
            await CurrentWeather.FetchCurrentWeather(lat, lon);

            LBL_City.Content = city;
            LBL_CurrentTemp.Content = CurrentWeather.CurrentTemperature + "°C";
            LBL_CurrentHumidity.Content = "Humidity: " + CurrentWeather.CurrentHumidity + "%";
            LBL_CurrentPressure.Content = "Air Pressure: " + CurrentWeather.CurrentPressure + " hpa";
            LBL_WeatherConditions.Content = CurrentWeather.WeatherConditions;

            string iconUrl = $"http://openweathermap.org/img/w/{CurrentWeather.WeatherICON}.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(iconUrl, UriKind.Absolute);
            bitmap.EndInit();
            IMG_CurrentConditions.Source = bitmap;
        }
        private async void Forcast()
        {
            Forecast forcast = new Forecast();
            await forcast.FetchWeatherForcast(lat, lon);

            UpdateWeatherLabel(LBL_HighTemp1, LBL_LowTemp1, IMG_Icon_Day_1, forcast.HighTemp[0], forcast.LowTemp[0], forcast.IconCode[0]);
            UpdateWeatherLabel(LBL_HighTemp2, LBL_LowTemp2, IMG_Icon_Day_2, forcast.HighTemp[1], forcast.LowTemp[1], forcast.IconCode[1]);
            UpdateWeatherLabel(LBL_HighTemp3, LBL_LowTemp3, IMG_Icon_Day_3, forcast.HighTemp[2], forcast.LowTemp[2], forcast.IconCode[2]);
            UpdateWeatherLabel(LBL_HighTemp4, LBL_LowTemp4, IMG_Icon_Day_4, forcast.HighTemp[3], forcast.LowTemp[3], forcast.IconCode[3]);
            UpdateWeatherLabel(LBL_HighTemp5, LBL_LowTemp5, IMG_Icon_Day_5, forcast.HighTemp[4], forcast.LowTemp[4], forcast.IconCode[4]);
        }

        private void UpdateWeatherLabel(Label highTempLabel, Label lowTempLabel, Image iconImage, double highTemp, double lowTemp, string iconCode)
        {
            highTempLabel.Content = $"High {highTemp}°C";
            lowTempLabel.Content = $"/        Low {lowTemp}°C";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($"http://openweathermap.org/img/w/{iconCode}.png", UriKind.Absolute);
            bitmap.EndInit();

            iconImage.Source = bitmap;
        }
        private void ChangeUnit()
        { 
           
        }

    }
}