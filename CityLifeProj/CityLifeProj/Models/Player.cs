using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CityLifeProj.Models.Job;
using static CityLifeProj.Models.Perks;

namespace CityLifeProj.Models
{
    internal class Player
    {
        private static string Name { get; set; }
        private static double Cash { get; set; }
        private static int EnergyPoints { get; set; }
        private static int MaxEnergy { get; set; }
        private static string Image { get; set; }
        private static HashSet<PerkType> PlayerPerks { get; set; }
        private static CityJobType PlayerJob { get; set; }
        private static Education Education { get; set; }
        private static List<Item> Inventory { get; set; }


        private static readonly object InstanceLock = new object();
        private static Player instance = null;

        public static Player GetInstance
        {
            get
            {
                if (instance is null)
                {
                    lock (InstanceLock)
                    {
                        if (instance is null)
                        {
                            instance = new Player();
                        }
                    }
                }
                return instance;
            }
        }

        private Player()
        {
            Cash = 100;
            MaxEnergy = 100;
            EnergyPoints = 100;
            Inventory = new List<Item>();
            PlayerPerks = new HashSet<PerkType>();
        }

        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetImage(string image)
        {
            Image = image;
        }
        public string GetImage()
        {
            return Image;
        }
        public double GetCash()
        {
            return Cash;
        }
        public void AddCash(double cash)
        {
            Cash += cash;
        }
        public void DeductCash(double cash)
        {
            Cash -= cash;
        }
        public int GetEnergyPoints()
        {
            return EnergyPoints;
        }
        public void AddEnergyPoints(int energy)
        {
            EnergyPoints += energy;
            if (EnergyPoints > MaxEnergy) EnergyPoints = MaxEnergy;
        }
        public void FillEnergyPoints()
        {
            EnergyPoints = MaxEnergy;
        }
        public void UseEnergyPoints(int energy)
        {
            EnergyPoints -= energy;
        }
        public int GetMaxEnergy()
        {
            return MaxEnergy;
        }
        public void AddMaxEnergy()
        {
            MaxEnergy++;
        }
        public void AddPerk(PerkType perk)
        {
            PlayerPerks.Add(perk);
        }
        public void RemovePerk(PerkType perk)
        {
            PlayerPerks.Remove(perk);
        }
        public bool GetPerk(PerkType perk)
        {
            return PlayerPerks.Contains(perk);
        }
        public HashSet<PerkType> GetPerks()
        {
            return PlayerPerks;
        }
        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }
        public List<Item> GetInventory()
        {
            return Inventory;
        }
        public CityJobType GetJob()
        {
            return PlayerJob;
        }
        public void SetJob(CityJobType job)
        {
            PlayerJob = job;
        }
        public Education GetEducation()
        {
            return Education;
        }
        public void NewEducation()
        {
            Education = new Education();
        }
    }
}
