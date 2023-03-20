using CityLifeProj.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CityLifeProj.Models.Job;

namespace CityLifeProj.ViewModels
{
    internal partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string cityWeather;
        [ObservableProperty]
        string cityWeatherUrl;
        [ObservableProperty]
        string playerName;
        [ObservableProperty]
        string playerCash;
        [ObservableProperty]
        string playerEnergy;
        [ObservableProperty]
        string playerEnergyDetail;
        [ObservableProperty]
        string playerImage;


        internal async void UpdateViewPlayer()
        {
            while (Player.GetInstance.GetName() == null) await Task.Delay(1000);
            PlayerName = Player.GetInstance.GetName();
            PlayerCash = Player.GetInstance.GetCash().ToString("0.00") + "$";
            PlayerEnergy = Player.GetInstance.GetEnergyPoints().ToString();
            PlayerEnergyDetail = PlayerEnergy + "/" + Player.GetInstance.GetMaxEnergy().ToString();
            PlayerImage = Player.GetInstance.GetImage();
        }
        internal async void UpdateCityViewWeather()
        {
            while (OpenWeather.CurrentWeather == null) await Task.Delay(1000);
            CityWeather = OpenWeather.CurrentWeather.weather[0].description;
            CityWeatherUrl = OpenWeather.CurrentWeather.weather[0].IconUrl;
        }
        internal static async void BuyItem(Item item, double price)
        {
            if (!(Player.GetInstance.GetCash() >= price))
            {
                await Application.Current.MainPage.DisplayAlert("Insufficient Funds", $"You Couldnt afford {item.ItemName} for {price}$!", "OK");
                return;
            }
            Player.GetInstance.DeductCash(price);
            Player.GetInstance.AddItem(item);
            await Application.Current.MainPage.DisplayAlert("Bought Item", $"You bought {item.ItemName} for {price}$.", "OK");
        }
        internal static async void WorkShift(CityJobType job, int energyCost)
        {
            Task<int> taskEnergyCost = EnergyCostMultiplier(energyCost);
            
            if (Player.GetInstance.GetJob() != job)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Dont Work Here!", "OK");
                return;
            }
            await taskEnergyCost;
            if (Player.GetInstance.GetEnergyPoints() < taskEnergyCost.Result)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Dont Have Enough Energy!", "OK");
                return;
            }
            Player.GetInstance.UseEnergyPoints(taskEnergyCost.Result);
            Player.GetInstance.AddCash(Convert.ToDouble((int)job));
            await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Worked A Shift And Earned {((int)job)}$ While Using {taskEnergyCost.Result} Energy.", "OK");
        }

        private static async Task<int> EnergyCostMultiplier(int energyCost)
        {
            if (OpenWeather.CurrentWeather is null) return energyCost;
            switch (OpenWeather.CurrentWeather.weather[0].main)
            {
                case "Clear":
                    break;
                case "Clouds":
                    energyCost += 2;
                    break;
                case "snow":
                    energyCost += 3;
                    break;
                case "Drizzle":
                    energyCost += 5;
                    break;
                case "Rain":
                    energyCost += 8;
                    break;
                case "Thunderstorm":
                    energyCost += 12;
                    break;
                default:
                    energyCost += 10;
                    break;
            }
            return energyCost;
        }

        internal static async void ApplyForJob(CityJobType job)
        {
            if (Player.GetInstance.GetJob() == job)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Already Work Here!", "OK");
                return;
            }
            else if (Player.GetInstance.GetJob() != CityJobType.NoJob)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Already Have A Job Elsewhere!", "OK");
                return;
            }
            Player.GetInstance.SetJob(job);
            await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Have A New Job!", "Thanks");
        }
        internal static async void QuitJob(CityJobType job)
        {
            if (Player.GetInstance.GetJob() == CityJobType.NoJob)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Dont Have A Job.", "OK");
                return;
            }
            else if (Player.GetInstance.GetJob() != job)
            {
                await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Dont Work Here!", "OK");
                return;
            }
            Player.GetInstance.SetJob(CityJobType.NoJob);
            await Application.Current.MainPage.DisplayAlert(job.ToString(), $"You Have Quit Your Job!", "OK");
        }

        internal static async Task<Item> GetItemContains(List<Item> inventory, string contains)
        {
            Item selectedItem = null;
            await Task.Run(() =>
            {
                foreach (Item item in inventory)
                    if (item.ItemName.Contains(contains))
                        selectedItem = item;
            });
            return selectedItem;
        }

        internal static async void EatFood(Item food)
        {
            Player.GetInstance.RemoveItem(food);
            await Application.Current.MainPage.DisplayAlert("Food", $"You Have Eaten {food.ItemName}.", "OK");
        }

        internal static async void DrinkDrink(Item drink, int drinkEnergy)
        {
            int oldEnergy = Player.GetInstance.GetEnergyPoints();
            Player.GetInstance.RemoveItem(drink);
            Player.GetInstance.AddEnergyPoints(drinkEnergy);
            await Application.Current.MainPage.DisplayAlert("Energy Drink", $"You Have Gained {Player.GetInstance.GetEnergyPoints() - oldEnergy} Energy From Drinking {drink.ItemName}.", "OK");
        }
    }
}
