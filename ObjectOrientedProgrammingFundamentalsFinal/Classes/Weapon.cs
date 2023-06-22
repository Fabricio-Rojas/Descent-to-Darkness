using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Weapon
    {
        private List<string> _weakWeaponNames = new List<string>
        {
            "Blunt Stick",
            "Rusty Dagger",
            "Wooden Mallet",
            "Bent Sword",
            "Fractured Axe",
            "Chipped Blade",
            "Dull Shiv",
            "Cracked Club",
            "Worn-out Cleaver",
            "Flimsy Lance"
        };
        private List<string> _averageWeaponNames = new List<string>
        {
            "Iron Broadsword",
            "Steel Warhammer",
            "Balanced Katana",
            "Polished Battleaxe",
            "Reinforced Maul",
            "Tempered Scimitar",
            "Reliable Halberd",
            "Sturdy Cutlass",
            "Weighted Flail",
            "Serrated Dagger"
        };
        private List<string> _strongWeaponNames = new List<string>
        {
            "Excalibur, God's Blade",
            "Stormbreaker the Blade",
            "Reapers Harvester",
            "Oblivion's Voidblade",
            "Seraph's Angelic Saber",
            "Bloodmoon, the Cleaver",
            "Dragonfang's Firebrand",
            "Leviathan of Neptune",
            "Celestial Star Spear",
            "Mjolnir, The Hammer"
        };

        private Random random = new Random();
        public string Name;
        public int Power, Price;
        public Weapon(int level)
        {
            if (level <= 5)
            {
                Name = _weakWeaponNames[random.Next(_weakWeaponNames.Count)];
                Power = random.Next(3, 7) * level;
                Price = random.Next(1, 20);
            }
            else if (level <= 10)
            {
                Name = _averageWeaponNames[random.Next(_averageWeaponNames.Count)];
                Power = random.Next(7, 15) * level;
                Price = random.Next(20, 50);
            }
            else if (level > 10)
            {
                Name = _strongWeaponNames[random.Next(_strongWeaponNames.Count)];
                Power = random.Next(15, 20) * level;
                Price = random.Next(50, 100);
            }
        }
        public Weapon(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
