using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.Models
{
    public class Item
    {
        public string ItemName { get; set; }

        public Item(string name)
        {
            ItemName = name;
        }

        public Item()
        {

        }
    }
}
