using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class HomeViewModel : BaseViewModel
    {
        internal async Task HomeSleep()
        {
            if (Player.GetInstance.GetEnergyPoints() >= Player.GetInstance.GetMaxEnergy() - 40)
            {
                await Application.Current.MainPage.DisplayAlert("Sleep", $"You Are Not Tired.", "OK");
                return;
            }
            int oldEnergy = Player.GetInstance.GetEnergyPoints();
            Player.GetInstance.FillEnergyPoints();
            await Application.Current.MainPage.DisplayAlert("Sleep", $"zzZZZzzzZZZzzz.\nYou Are Well Rested And Have Gained {Player.GetInstance.GetEnergyPoints() - oldEnergy} Energy To {Player.GetInstance.GetMaxEnergy()} Energy", "OK");
        }

        internal async Task HomeDrink(int drinkEnergy = 1, string itemName = "Energy Drink")
        {
            Item item = await BaseViewModel.GetItemContains(Player.GetInstance.GetInventory(), itemName);
            if (item is null)
            {
                await Application.Current.MainPage.DisplayAlert("Energy Drink", $"You Dont Have Any Energy Drinks.", "OK");
                return;
            }
            DrinkDrink(item, drinkEnergy);
        }

        internal async Task HomeEat(string itemName = "Prepared Food")
        {
            Item item = await BaseViewModel.GetItemContains(Player.GetInstance.GetInventory(), itemName);
            if (item is null)
            {
                await Application.Current.MainPage.DisplayAlert("Food", $"You Dont Have Any Food.", "OK");
                return;
            }
            EatFood(item);
        }

        internal async Task HomePrepareFood()
        {
            var vegitables = BaseViewModel.GetItemContains(Player.GetInstance.GetInventory(), "Vegitables");
            var unpreparedFood = BaseViewModel.GetItemContains(Player.GetInstance.GetInventory(), "Unprepared Food");
            await Task.WhenAll(vegitables, unpreparedFood);
            if (vegitables.Result is null && unpreparedFood.Result is null)
            {
                await Application.Current.MainPage.DisplayAlert("Preparing Food", $"You Dont Have Any Vegitables Or Unprepared Food.", "OK");
                return;
            }
            else if (vegitables.Result is null)
            {
                await Application.Current.MainPage.DisplayAlert("Preparing Food", $"You Dont Have Any Vegitables.", "OK");
                return;
            }
            else if (unpreparedFood.Result is null)
            {
                await Application.Current.MainPage.DisplayAlert("Preparing Food", $"You Dont Have Any Unprepared Food.", "OK");
                return;
            }
            Player.GetInstance.RemoveItem(vegitables.Result);
            Player.GetInstance.RemoveItem(unpreparedFood.Result);
            Player.GetInstance.AddItem(new Item("Prepared Food"));
            await Application.Current.MainPage.DisplayAlert("Preparing Food", $"You Have Prepared Some Food From {vegitables.Result.ItemName} And {unpreparedFood.Result.ItemName}.", "OK");
        }

        internal async void HomeUpgradeHome()
        {
            await Application.Current.MainPage.DisplayAlert("Home Upgrade", $"You Dont Have Enough Materials.", "OK");
        }
    }
}
