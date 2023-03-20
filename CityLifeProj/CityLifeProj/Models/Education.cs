using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CityLifeProj.Models
{
    internal class Education
    {
        private int Experience { get; set; }
        private bool Masters { get; set; }

        public Education()
        {
            Experience = 0;
            Masters = false;
        }

        public void AddExperience()
        {
            Experience++;
        }
        public int GetExperience()
        {
            return Experience;
        }
        public bool GetMasters()
        {
            return Masters;
        }
        public void SetMasters()
        {
            Masters = true;
        }
    }
}
