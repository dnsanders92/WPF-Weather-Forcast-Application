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
        private string unit = "metric";
        private string unitIcon = "°C";
        string city = "London";
        public static string Lat { get { return lat; } set { lat = value; } }
        public static string Lon { get { return lon; } set { lon = value; } }

        public MainWindow()
        {
            InitializeComponent();

            var capitalCities = new List<(string City, double Latitude, double Longitude)>
            {
                ("London", 51.5074, -0.1278),
                ("Paris", 48.8566, 2.3522),
                ("Berlin", 52.5200, 13.4050),
                ("Madrid", 40.4168, -3.7038),
                ("Rome", 41.9028, 12.4964)
            };

            CurrentWeather();
            Combo_Units.SelectionChanged += Combo_Units_SelectionChanged;
            Forecast();

        }
        private async void CurrentWeather()
        {
            CurrentWeather CurrentWeather = new CurrentWeather();
            await CurrentWeather.FetchCurrentWeather(lat, lon, unit);

            LBL_City.Content = city;
            LBL_CurrentTemp.Content = CurrentWeather.CurrentTemperature + unitIcon;
            LBL_FeelsLike.Content = "Feels Like: " + CurrentWeather.FeelsLikeTemperature + unitIcon;
            LBL_CurrentHumidity.Content = "Humidity: " + CurrentWeather.CurrentHumidity + "%";
            LBL_CurrentPressure.Content = "Air Pressure: " + CurrentWeather.CurrentPressure + " hpa";


            string iconUrl = $"http://openweathermap.org/img/w/{CurrentWeather.WeatherICON}.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(iconUrl, UriKind.Absolute);
            bitmap.EndInit();
            IMG_CurrentConditions.Source = bitmap;
        }

        private async void Forecast()
        {
            Forecast forecast = new Forecast();
            await forecast.FetchWeatherForecast(lat, lon, unit);

            {
                UpdateWeatherLabel(LBL_HighTemp1, LBL_LowTemp1, IMG_Icon_Day_1, forecast.HighTemp[0], forecast.LowTemp[0], forecast.IconCode[0], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp2, LBL_LowTemp2, IMG_Icon_Day_2, forecast.HighTemp[1], forecast.LowTemp[1], forecast.IconCode[1], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp3, LBL_LowTemp3, IMG_Icon_Day_3, forecast.HighTemp[2], forecast.LowTemp[2], forecast.IconCode[2], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp4, LBL_LowTemp4, IMG_Icon_Day_4, forecast.HighTemp[3], forecast.LowTemp[3], forecast.IconCode[3], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp5, LBL_LowTemp5, IMG_Icon_Day_5, forecast.HighTemp[4], forecast.LowTemp[4], forecast.IconCode[4], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp6, LBL_LowTemp6, IMG_Icon_Day_6, forecast.HighTemp[5], forecast.LowTemp[5], forecast.IconCode[5], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp7, LBL_LowTemp7, IMG_Icon_Day_7, forecast.HighTemp[6], forecast.LowTemp[6], forecast.IconCode[6], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp8, LBL_LowTemp8, IMG_Icon_Day_8, forecast.HighTemp[7], forecast.LowTemp[7], forecast.IconCode[7], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp9, LBL_LowTemp9, IMG_Icon_Day_9, forecast.HighTemp[8], forecast.LowTemp[8], forecast.IconCode[8], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp10, LBL_LowTemp10, IMG_Icon_Day_10, forecast.HighTemp[9], forecast.LowTemp[9], forecast.IconCode[9], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp11, LBL_LowTemp11, IMG_Icon_Day_11, forecast.HighTemp[10], forecast.LowTemp[10], forecast.IconCode[10], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp12, LBL_LowTemp12, IMG_Icon_Day_12, forecast.HighTemp[11], forecast.LowTemp[11], forecast.IconCode[11], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp13, LBL_LowTemp13, IMG_Icon_Day_13, forecast.HighTemp[12], forecast.LowTemp[12], forecast.IconCode[12], unitIcon);
                UpdateWeatherLabel(LBL_HighTemp14, LBL_LowTemp14, IMG_Icon_Day_14, forecast.HighTemp[13], forecast.LowTemp[13], forecast.IconCode[13], unitIcon);
            }
            ;
        }


        private void UpdateWeatherLabel(Label highTempLabel, Label lowTempLabel, Image iconImage, double highTemp, double lowTemp, string iconCode, string unitIcon)
        {
            highTempLabel.Content = $"High {highTemp}{unitIcon}";
            lowTempLabel.Content = $"/        Low {lowTemp}{unitIcon}";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($"http://openweathermap.org/img/w/{iconCode}.png", UriKind.Absolute);
            bitmap.EndInit();

            iconImage.Source = bitmap;
        }
        private void ChangeUnit()
        {

        }

        private void Combo_Units_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedItem is ComboBoxItem selectedItem)
            {
                // Update the unit string based on the selected item's Name
                unit = selectedItem.Name;

                // Update the unit icon
                unitIcon = unit switch
                {
                    "metric" => "°C",
                    "imperial" => "°F",
                    "kelvin" => "K",
                    _ => "°"
                };

                // Refresh the weather forecast
                CurrentWeather();
                Forecast();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}