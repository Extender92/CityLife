using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class UniversityViewModel : BaseViewModel
    {
        internal async void UniversityMasters()
        {
            if (Player.GetInstance.GetEducation() == null)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Have Not Applied For An Education.", "OK");
                return;
            }
            else if (Player.GetInstance.GetEducation().GetMasters())
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Already Have A Masters.", "OK");
                return;
            }
            else if (Player.GetInstance.GetEducation().GetExperience() < 100)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Dont Have Enough Experience For A Masters.", "OK");
                return;
            }
            Player.GetInstance.GetEducation().SetMasters();
            await Application.Current.MainPage.DisplayAlert("Education", $"You Now Have A Masters Degree!", "OK");
        }

        internal async Task UniversityStudy(int energyCost = 10)
        {
            if (Player.GetInstance.GetEducation() == null)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Have Not Applied For An Education.", "OK");
                return;
            }
            else if (Player.GetInstance.GetEducation().GetMasters())
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Already Have A Masters.", "OK");
                return;
            }
            else if (Player.GetInstance.GetEducation().GetExperience() >= 100)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Already Have Enough Experience For A Masters!", "OK");
                return;
            }
            else if (Player.GetInstance.GetEnergyPoints() < energyCost)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Dont Have Enough Energy!", "OK");
                return;
            }
            Player.GetInstance.UseEnergyPoints(energyCost);
            Player.GetInstance.GetEducation().AddExperience();
            await Application.Current.MainPage.DisplayAlert("Education", $"You Got One Experience Point Towards A Masters Degree For Using {energyCost} Energy, You have {Player.GetInstance.GetEducation().GetExperience()} In Total", "OK");
        }

        internal async Task UniversityApply(double tuitionFee = 2500)
        {
            if (Player.GetInstance.GetEducation() != null)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Cant Apply To A Second Education.", "OK");
                return;
            }
            else if (Player.GetInstance.GetCash() < tuitionFee)
            {
                await Application.Current.MainPage.DisplayAlert("Education", $"You Cant Afford The Tuition Fee.", "OK");
                return;
            }
            Player.GetInstance.DeductCash(tuitionFee);
            Player.GetInstance.NewEducation();
            await Application.Current.MainPage.DisplayAlert("Education", $"You Are Now Studying To A Masters Degree.", "OK");
        }
    }
}
