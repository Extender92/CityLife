using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class HardwareStoreViewModel : BaseViewModel
    {
        internal async Task HardwareBuy()
        {
            string itemName = "Hardware Tools";
            double itemPrice = 8.9;

            BuyItem(new Item(itemName), itemPrice);
        }

        internal async Task HardwareWork()
        {
            int energyCost = 79;
            WorkShift(Job.CityJobType.JobAtHardwareStore, energyCost);
        }

        internal async void HardwareApply()
        {
            ApplyForJob(Job.CityJobType.JobAtHardwareStore);
        }

        internal async void HardwareQuit()
        {
            QuitJob(Job.CityJobType.JobAtHardwareStore);
        }
    }
}
