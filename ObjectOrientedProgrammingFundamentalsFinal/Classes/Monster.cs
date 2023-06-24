﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Monster
    {
        private List<string> _monsterNames = new List<string>
        {
            "Viscerath, Flesh Devourer",
            "Morbidos, Rotting Abomination",
            "Skulldrake, Bone Collector",
            "Slithermaw, Slime Serpent",
            "Blightspawn, Pustulent Horror",
            "Gorefist, Blood Golem",
            "Scorchbane, Fiery Daemon",
            "Wretchclaw, Vile Ripper",
            "Vilespine, Corpse Stitcher",
            "Grotescamorph, Shapeless Terror",
            "Plaguefiend, Festering Monstrosity",
            "Nightgaunt, Soul Harvester",
            "Abyssthor, Abyssal Behemoth",
            "Rotscale, Diseased Dragon",
            "Crawlbone, Crawling Skeleton",
            "Veilstalker, Shrouded Nightmare",
            "Blightwraith, Putrid Specter",
            "Pestilentia, Pestilent Queen",
            "Mirefiend, Swamp Dweller",
            "Mutilox, Limb Mangler",
            "Shriekwing, Eerie Banshee",
            "Dreadhorn, Horned Beast",
            "Tormentia, Tormentor of Souls",
            "Skincrawler, Dermis Crawler",
            "Vomitcore, Visceral Eater",
            "Filthspawn, Filth Infested Spawn",
            "Abomination, Unholy Aberration",
            "Infestus, Parasitic Menace",
            "Scaldron, Melting Fiend",
            "Skulkscale, Bone-Crushing Leviathan"
        };
        private List<string> _faces = new List<string>
        {
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace1.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace2.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace3.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace4.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace5.txt"),
        };
        public string Name;
        public string Face;
        public int Level;
        public int Exp;
        public int Gold;
        public int Strength;
        public int Defence;
        public int OriginalHealth;
        public int CurrentHealth;
        private Random random = new Random();
        public Monster(Hero hero)
        {
            Name = _monsterNames[random.Next(_monsterNames.Count)];
            Face = _faces[random.Next(_faces.Count)];
            Level = random.Next(1, hero.Level + 3 + 1);
            Exp = 20 + (random.Next(0, 25 + 1) * Level);
            Gold = 5 + (random.Next(0, 10 + 1) * Level);
            Strength = 15 + (random.Next(0, 5 + 1) * Level);
            Defence = 3 + (random.Next(0, 2 + 1) * Level);
            OriginalHealth = 100 + (random.Next(0, 20 + 1) * Level);
            CurrentHealth = OriginalHealth;
        }
    }
}
