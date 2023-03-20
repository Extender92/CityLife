using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class CityViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool hasMasters;

        internal async void UpdatePlayerMasters()
        {
            if (!(Player.GetInstance.GetEducation() is null))
                HasMasters = Player.GetInstance.GetEducation().GetMasters();
        }
        internal async void ApiOpenWeather()
        {
            await Task.Run(() => OpenWeather.UpdateWeather());

            DateTime savedTime = DateTime.Now;
            while (true)
            {
                UpdateCityViewWeather();
                await Task.Delay(60000);
                if (DateTime.Now > savedTime.AddMinutes(60))
                {
                    savedTime = DateTime.Now;
                    await Task.Run(() => OpenWeather.UpdateWeather());
                }
            }
        }
    }
}
