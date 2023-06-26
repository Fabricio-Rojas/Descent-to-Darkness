using System;
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
        private int _currentHealth;
        public string Name;
        public string Face;
        public int Level;
        public int Exp;
        public int Gold;
        public int Strength;
        public int Defence;
        public int OriginalHealth;
        public bool IsBlocking, IsFocused;
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                if (value > OriginalHealth)
                {
                    _currentHealth = OriginalHealth;
                }
                if (value < 0)
                {
                    _currentHealth = 0;
                }
                _currentHealth = value;
            }
        }
        private Random random = new Random();
        public Monster(Hero hero)
        {
            Name = _monsterNames[random.Next(_monsterNames.Count)];
            Face = _faces[random.Next(_faces.Count)];
            Level = random.Next(1, hero.Level + 1 + 1);
            Exp = 20 + (random.Next(0, 25 + 1) * Level);
            Gold = 5 + (random.Next(0, 10 + 1) * Level);
            Strength = 15 + (random.Next(0, 5 + 1) * Level);
            Defence = 3 + (random.Next(0, 1 + 1) * Level);
            OriginalHealth = 100 + (random.Next(0, 20 + 1) * Level);
            CurrentHealth = OriginalHealth;
        }
        public string DoMonsterAction(Hero hero, out int monsterDamage)
        {
            int randNum = random.Next(1, 100 + 1);
            monsterDamage = 0;

            if (hero.IsFocused)
            {
                if (randNum <= 50)
                {
                    return Strike(hero, out monsterDamage);
                }
            }
            if (hero.IsBlocking)
            {
                if (randNum >= 51)
                {
                    return Focus();
                }
            }

            if (randNum <= 25)
            {
                return Strike(hero, out monsterDamage);
            }
            else if (randNum <= 50)
            {
                return Focus();
            }
            else
            {
                return Block();
            }
        }
        public string Strike(Hero hero, out int monsterDamage)
        {
            monsterDamage = Strength - (hero.BaseDefense + hero.EquippedArmour.Power);
            return $"The monster tries to lash out at {hero.Name} to deal {monsterDamage} damage";
        }
        public string Block()
        {
            IsBlocking = true;
            return $"The monster hardens their body to block and ignore all damage";
        }
        public string Focus()
        {
            IsFocused = true;
            return $"The monster prepares a soul-crushing attack to hero's defenses";
        }
    }
}
