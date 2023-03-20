using CityLifeProj.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CityLifeProj.Models.Perks;

namespace CityLifeProj.ViewModels
{
    internal partial class PlayerViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Inventory { get; set;  }
        public ObservableCollection<PerkType> Perks { get; set; }


        internal async void UpdateDetailViewPlayer()
        {
            await Task.Run(() =>
            {
                Inventory = new ObservableCollection<Item>(Player.GetInstance.GetInventory());
                Perks = new ObservableCollection<PerkType>(Player.GetInstance.GetPerks());
            });
        }
    }
}
