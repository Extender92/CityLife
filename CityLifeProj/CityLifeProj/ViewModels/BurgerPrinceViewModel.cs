using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    partial class BurgerPrinceViewModel : BaseViewModel
    {
        internal static async Task BurgerFood()
        {
            string itemName = "Hamburger Meal";
            double itemPrice = 8.5;

            BuyItem(new Item(itemName), itemPrice);
        }

        internal static async Task BurgerWork()
        {
            int energyCost = 70;
            WorkShift(Job.CityJobType.JobAtBurgerPrince, energyCost);
        }

        internal static async void BurgerApply()
        {
            ApplyForJob(Job.CityJobType.JobAtBurgerPrince);
        }

        internal static async void BurgerQuit()
        {
            QuitJob(Job.CityJobType.JobAtBurgerPrince);
        }
    }
}
