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
            Forcast Forcast = new Forcast();
            await Forcast.FetchWeatherForcast(lat, lon);

            LBL_HighTemp1.Content = "High " + Forcast.HighTemp[0] + "°C";
            LBL_LowTemp1.Content = "/        Low " + Forcast.LowTemp[0] + "°C";

            LBL_HighTemp2.Content = "High " + Forcast.HighTemp[1] + "°C";
            LBL_LowTemp2.Content = "/        Low " + Forcast.LowTemp[1] + "°C";

            LBL_HighTemp3.Content = "High " + Forcast.HighTemp[2] + "°C";
            LBL_LowTemp3.Content = "/        Low " + Forcast.LowTemp[2] + "°C";

            LBL_HighTemp4.Content = "High " + Forcast.HighTemp[3] + "°C";
            LBL_LowTemp4.Content = "/        Low " + Forcast.LowTemp[3] + "°C";

            LBL_HighTemp5.Content = "High " + Forcast.HighTemp[4] + "°C";
            LBL_LowTemp5.Content = "/        Low " + Forcast.LowTemp[4] + "°C";
        }
    }
}