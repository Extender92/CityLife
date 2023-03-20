using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityLifeProj.Models
{
    internal class OpenWeather
    {
        internal static OpenWeather CurrentWeather { get; set; }
        private const string _BackupLatitude = "58.753296";
        private const string _BackupLongitude = "17.007351";

        internal static async void UpdateWeather()
        {
            Task<List<string>> location = GetGeoLocation();
            string latitude = "";
            string longitude = "";
            await location;
            if (location.Result.Count < 2)
            {
                latitude = _BackupLatitude;
                longitude = _BackupLongitude;
            }
            else
            {
                latitude = location.Result[0];
                longitude = location.Result[1];
            }

            Task<OpenWeather> Weather = OpenWeather.GetCurrentWeather(latitude, longitude);
            await Weather;

            if (Weather != null)
            {
                CurrentWeather = Weather.Result;
            }
        }

        private static async Task<List<string>> GetGeoLocation()
        {
            List<string> locationList = new();
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();
                if (location is null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest { DesiredAccuracy = GeolocationAccuracy.Medium, Timeout = TimeSpan.FromSeconds(30) });
                }
                locationList.Add(location.Latitude.ToString());
                locationList.Add(location.Longitude.ToString());
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.WriteLine(fnsEx);
                //await Application.Current.MainPage.DisplayAlert("GeoLocation", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Debug.WriteLine(fneEx);
                //await Application.Current.MainPage.DisplayAlert("GeoLocation", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                Debug.WriteLine(pEx);
                //await Application.Current.MainPage.DisplayAlert("GeoLocation", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //await Application.Current.MainPage.DisplayAlert("GeoLocation", ex.Message, "OK");
            }
            return locationList;
        }

        private static async Task<OpenWeather> GetCurrentWeather(string lat, string lon)
        {
            const string apiKey = "98c1e0290d0b82d6fee84f142c5bb699";
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/");

            HttpResponseMessage response = await client.GetAsync($"data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<OpenWeather>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Weather Error", "Could not get weather info", "OK");
                return null;
            }
        }

        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }

    public class Rain
    {
        public float _1h { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public DateTime SunriseTime { get { return DateTimeOffset.FromUnixTimeSeconds(sunrise).LocalDateTime; } }
        public DateTime SunsetTime { get { return DateTimeOffset.FromUnixTimeSeconds(sunset).LocalDateTime; } }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string IconUrl { get { return $"https://openweathermap.org/img/wn/{icon}.png"; } }
    }
}
