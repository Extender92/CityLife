using CityLifeProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class GroceryStoreViewModel : BaseViewModel
    {
        internal async Task GroceryBuyFood()
        {
            string itemName = "Unprepared Food";
            double itemPrice = 6.1;

            BuyItem(new Item(itemName), itemPrice);
        }

        internal async Task GroceryBuyEnergyDrink()
        {
            string itemName = "Energy Drink";
            double itemPrice = 2.3;

            BuyItem(new Item(itemName), itemPrice);
        }

        internal async Task GroceryBuyVegitables()
        {
            string itemName = "Vegitables";
            double itemPrice = 8.0;

            BuyItem(new Item(itemName), itemPrice);
        }
    }
}
