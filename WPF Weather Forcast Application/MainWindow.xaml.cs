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

namespace WPF_Weather_Forcast_Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateWeather();
        }
        private async void UpdateWeather()
        {
            OpenWeatherAPI openWeatherAPI = new OpenWeatherAPI();
            await openWeatherAPI.FetchCurrentWeather();
            LBL_City.Content = openWeatherAPI.City;
            LBL_CurrentTemp.Content = openWeatherAPI.CurrentTemperature + "°C";
            LBL_CurrentHumidity.Content = "Humidity: " + openWeatherAPI.CurrentHumidity + "%";
            LBL_CurrentPressure.Content = "Air Pressure: " + openWeatherAPI.CurrentPressure + " hpa";
            LBL_WeatherConditions.Content = openWeatherAPI.WeatherConditions;

        }
    }
}