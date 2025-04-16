# OpenWeatherAPI WPF

Overview: This Windows Presentation Foundation (WPF) application uses OpenWeatherAPI to retrieve and display weather data for any city. The app currently focuses on temperature displays for current, hourly (5 hours), and daily (5 days) weather forecasts.


## Features:

Weather Data Integration: Fetch and display temperature data for current, hourly, and daily forecasts.

Geocoding Support: Utilizes OpenWeather’s Geocoding API to determine latitude and longitude for user-selected locations.

Search Functionality: Includes a dedicated search box, allowing users to easily find weather data for any city.

Hourly Forecasts: Displays temperature data for the next 5 hours.

Daily Forecasts: Summarizes temperature data for the next 5 days.

## API Details:

APIs Used:

- Geocoding API

- Current Weather Data

- Hourly Forecast 4 Days

- Daily Forecast 16 Days

## Subscription Requirements:

Geocoding API and Current Weather Data can be accessed with a free subscription.

Hourly Forecast 4 Days and Daily Forecast 16 Days can be accessed with an appropriate paid subscription or a student account.

## Setup Instructions: To get the application working:

Obtain an API key from OpenWeather.

Paste your API key in the string weather_API_Key located in MainWindow.xaml.cs.
>         String weather_API_Key = "";

## Limitations:

The current version only displays temperature data.

The interface is for testing purposes only and does not reflect the final design.

Status: This project is in the testing phase. Both the interface design and additional features are actively under development.
