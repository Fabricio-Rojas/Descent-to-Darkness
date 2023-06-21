using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Hero
    {
        private int _currentHealth;

        public string Name;
        public int Level;
        public int Gold;
        public int BaseStrength;
        public int BaseDefense;
        public int OriginalHealth;
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
        public Weapon EquippedWeapon;
        public Armour EquippedArmour;
        public List<Weapon> WeaponList;
        public List<Armour> ArmourList;
        // public List<Consumable> ConsumableList;
        Random rand = new Random();

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Gold = 0;
            BaseStrength = (int)Math.Round(20 * rand.NextDouble()) + 5;
            BaseDefense = (int)Math.Round(10 * rand.NextDouble()) + 3;
            OriginalHealth = 100;
            CurrentHealth = 100;
            EquipWeapon(new Weapon("Bloodied Fist", 0));
            EquipArmour(new Armour("Familiar Rags", 0));        }
        public void LevelUp()
        {
            Level++;
            BaseStrength = (int)(2 + BaseStrength * 1.15);
            BaseDefense = (int)(1 + BaseDefense * 1.10);
            int OldHealth = OriginalHealth;
            OriginalHealth = (int)(OriginalHealth * 1.2);
            CurrentHealth += OriginalHealth - OldHealth;
        }
        public void GetStats()
        {
            Console.WriteLine($"Name: {Name}\nLevel: {Level}\nGold: {Gold}\nBase Strenght: {BaseStrength}\nBase Defense: {BaseDefense}");
            Console.WriteLine($"Max Health: {OriginalHealth}hp\nCurrent Health: {CurrentHealth}hp\n");
        }
        public void GetInventory()
        {
            Console.WriteLine($"Equipped Weapon: {EquippedWeapon.Name}, {EquippedWeapon.Power} Power; Equipped Armour: {EquippedArmour.Name}, {EquippedArmour.Power} Power\n");
            Console.WriteLine("1. Change Equipped Weapon");
            Console.WriteLine("2. Change Equipped Armour");
            Console.WriteLine("3. Show Full Inventory");
            ConsoleKey key = Console.ReadKey(intercept: true).Key;
            InventoryKeyPress(key);
        }
        private void InventoryKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    // print list of weapons, press respective key to equip selected weapon
                    break;

                case ConsoleKey.D2:
                    // print list of armours, press respective key to equip selected armour
                    break;

                case ConsoleKey.D3:
                    // print all three lists of items side by side, this should be done with 
                    // a for loop that goes over the biggest length between the three lists
                    // if an item exists in the index, print its name and power
                    break;

                default:
                    GetInventory();
                    break;
            }
        }
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }
        public void EquipArmour(Armour armor)
        {
            EquippedArmour = armor;
        }
    }
}
