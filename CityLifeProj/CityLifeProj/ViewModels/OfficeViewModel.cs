using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class OfficeViewModel : BaseViewModel
    {
        internal async Task OfficeWork()
        {
            int energyCost = 90;
            WorkShift(Job.CityJobType.JobAtOffice, energyCost);
        }

        internal async void OfficeApply()
        {
            ApplyForJob(Job.CityJobType.JobAtOffice);
        }

        internal async void OfficeQuit()
        {
            QuitJob(Job.CityJobType.JobAtOffice);
        }
    }
}
