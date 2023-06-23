using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Shop
    {
        private Hero _hero;
        private List<Weapon> _weaponsList;
        private List<Armour> _armoursList;
        private List<Consumable> _consumablesList;
        private Random random = new Random();
        public Shop(Hero hero)
        {
            _hero = hero;
            _weaponsList = new List<Weapon>(3);
            _armoursList = new List<Armour>(3);
            _consumablesList = new List<Consumable>(3);
            for (int i = 0; i < 3; i++)
            {
                _weaponsList.Add(new Weapon(_hero.Level));
                _armoursList.Add(new Armour(_hero.Level));
                _consumablesList.Add(new Consumable(random.Next(3)));
            }
        }
        public void DisplayShopMenu()
        {
            // show players Gold
            Console.Clear();
            Console.WriteLine("Welcome to the shop\n");
            Console.WriteLine("1. Buy Items");
            Console.WriteLine("2. Sell Items");
            Console.WriteLine("\n(Press esc to return)");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    BuyItems();
                    DisplayShopMenu();
                    break;

                case ConsoleKey.D2:
                    SellItems();
                    DisplayShopMenu();
                    break;

                case ConsoleKey.Escape:
                    return;

                default:
                    DisplayShopMenu();
                    break;
            }
        }
        private void BuyItems()
        {
            Console.Clear();
            Console.WriteLine("What will you buy?\n");
            Console.WriteLine($"Gold: {_hero.Gold}");
            Console.SetCursorPosition(0, 4);
            Console.Write("WEAPONS");
            Console.SetCursorPosition(44, 4);
            Console.Write("ARMOUR");
            Console.SetCursorPosition(92, 4);
            Console.Write("CONSUMABLES");
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(0, i + 6);
                Console.Write($"{i + 1}. {_weaponsList[i].Name}, {_weaponsList[i].Power} power, {_weaponsList[i].Price} Gold");
                Console.SetCursorPosition(44, i + 6);
                Console.Write($"{i + 4}. {_armoursList[i].Name}, {_armoursList[i].Power} power, {_armoursList[i].Price} Gold");
                Console.SetCursorPosition(92, i + 6);
                Console.Write($"{i + 7}. {_consumablesList[i].Name}, {_consumablesList[i].Price} Gold\n");
            }
            Console.WriteLine("\nSelect Item to Buy\n");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (char.IsDigit(key.KeyChar) && int.Parse(key.KeyChar.ToString()) > 0 && int.Parse(key.KeyChar.ToString()) <= 9)
            {
                int keyNum = int.Parse(key.KeyChar.ToString());
                if (keyNum <= 3)
                {
                    if (_weaponsList[keyNum - 1].Price > _hero.Gold)
                    {
                        Console.WriteLine("Not enough gold to buy item");
                        Console.ReadKey(intercept: true);
                        return;
                    }
                    _hero.AddNewWeapon(_weaponsList[keyNum - 1]);
                    _hero.Gold -= _weaponsList[keyNum - 1].Price;
                    Console.WriteLine($"Bought  {_weaponsList[keyNum - 1].Name} for {_weaponsList[keyNum - 1].Price} Gold");
                }
                else if (keyNum <= 6)
                {
                    if (_armoursList[keyNum - 4].Price > _hero.Gold)
                    {
                        Console.WriteLine("Not enough gold to buy item");
                        Console.ReadKey(intercept: true);
                        return;
                    }
                    _hero.AddNewArmor(_armoursList[keyNum - 4]);
                    _hero.Gold -= _armoursList[keyNum - 4].Price;
                    Console.WriteLine($"Bought  {_armoursList[keyNum - 4].Name} for {_armoursList[keyNum - 4].Price} Gold");
                }
                else if (keyNum <= 9)
                {
                    if (_consumablesList[keyNum - 7].Price > _hero.Gold)
                    {
                        Console.WriteLine("Not enough gold to buy item");
                        Console.ReadKey(intercept: true);
                        return;
                    }
                    _hero.AddNewConsumable(_consumablesList[keyNum - 7]);
                    _hero.Gold -= _consumablesList[keyNum - 7].Price;
                    Console.WriteLine($"Bought {_consumablesList[keyNum - 7].Name} for {_consumablesList[keyNum - 7].Price} Gold");
                }
                Console.ReadKey(intercept: true);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                BuyItems();
            }
        }
        private void SellItems()
        {
            // remove bought item in BuyItems()
            Console.Clear();
            Console.WriteLine("What do you want to sell?\n");
            Console.WriteLine("1. Weapons");
            Console.WriteLine("2. Armor");
            Console.WriteLine("3. Consumables");
            Console.WriteLine("\n(Press esc to return)");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1:

                    SellItems();
                    break;

                case ConsoleKey.D2:

                    SellItems();
                    break;

                case ConsoleKey.D3:

                    SellItems();
                    break;

                case ConsoleKey.Escape:
                    return;

                default:
                    SellItems();
                    break;
            }
        }
    }
}
