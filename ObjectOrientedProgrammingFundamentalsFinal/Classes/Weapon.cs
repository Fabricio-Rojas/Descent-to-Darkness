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
            "Excalibur, the Blade of Kings",
            "Stormbreaker, the Thunderstrike",
            "Reaper's Scythe, the Soul Harvester",
            "Oblivion's Edge, the Voidblade",
            "Seraph's Grace, the Angelic Saber",
            "Bloodmoon, the Crimson Cleaver",
            "Dragonfang, the Firebrand",
            "Leviathan, the Ocean's Wrath",
            "Celestial Spear, the Starforged Pike",
            "Mjolnir, the Hammer of Legends"
        };

        private Random random = new Random();
        public string Name;
        public int Power;
        public Weapon(int level)
        {
            if (level <= 5)
            {
                Name = _weakWeaponNames[random.Next(_weakWeaponNames.Count)];
                Power = random.Next(3, 7) * level;
            }
            else if (level <= 10)
            {
                Name = _averageWeaponNames[random.Next(_averageWeaponNames.Count)];
                Power = random.Next(7, 15) * level;
            }
            else if (level > 10)
            {
                Name = _strongWeaponNames[random.Next(_strongWeaponNames.Count)];
                Power = random.Next(15, 20) * level;
            }
        }
        public Weapon(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
