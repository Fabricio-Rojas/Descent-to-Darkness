﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Armour
    {
        private List<string> _weakArmourNames = new List<string>
        {
            "Tattered Rags",
            "Worn Leather Vest",
            "Frayed Cloth Robe",
            "Threadbare Tunic",
            "Patched Chainmail",
            "Rusty Iron Bracers",
            "Faded Linen Cowl",
            "Thin Padded Pants",
            "Cracked Leather Boots",
            "Dented Iron Helmet"
        };
        private List<string> _averageArmourNames = new List<string>
        {
            "Sturdy Plate Gauntlets",
            "Reliable Chain Coif",
            "Polished Steel Breastplate",
            "Leather Greaves",
            "Tempered Iron Pauldrons",
            "Balanced Hardened Helm",
            "Durable Mail Leggings",
            "Fortified Kite Shield",
            "Silver Vambraces"
        };
        private List<string> _strongArmourNames = new List<string>
        {
            "Titansteel Warplate",
            "Shadowweave Shroud",
            "Dragonbone Chestplate",
            "Seraphic Wingspan",
            "Infernal Demonplate",
            "Bloodforged Harness",
            "Celestial Embrace",
            "Stormguard Defender",
            "Radiant Soulmail",
            "Eternal Vanguard's Plate"
        };
        private Random random = new Random();
        public string Name;
        public int Power, Price;
        public Armour(int level)
        {
            if (level <= 5)
            {
                Name = _weakArmourNames[random.Next(_weakArmourNames.Count)];
                Power = random.Next(1, 3) * level;
                Price = random.Next(1, 10);
            }
            else if (level <= 10)
            {
                Name = _averageArmourNames[random.Next(_averageArmourNames.Count)];
                Power = random.Next(3, 7) * level;
                Price = random.Next(10, 25);
            }
            else if (level > 10)
            {
                Name = _strongArmourNames[random.Next(_strongArmourNames.Count)];
                Power = random.Next(7, 15) * level;
                Price = random.Next(25, 75);
            }
        }
        public Armour(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
