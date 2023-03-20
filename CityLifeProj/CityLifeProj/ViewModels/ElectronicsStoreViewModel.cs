using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class ElectronicsStoreViewModel : BaseViewModel
    {

        internal async Task ElectronicBuy()
        {
            string itemName = "Electronic Tools";
            double itemPrice = 10.7;

            BuyItem(new Item(itemName), itemPrice);
        }

        internal async Task ElectronicWork()
        {
            int energyCost = 80;
            WorkShift(Job.CityJobType.JobAtElectronicStore, energyCost);
        }

        internal async void ElectronicApply()
        {
            ApplyForJob(Job.CityJobType.JobAtElectronicStore);
        }

        internal async void ElectronicQuit()
        {
            QuitJob(Job.CityJobType.JobAtElectronicStore);
        }
    }
}
