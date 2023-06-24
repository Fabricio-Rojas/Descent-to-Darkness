using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Game
    {
        private Hero _hero;
        private Shop _shop;
        private Fight _fight;
        private int _fightCount = 0;
        private int _winCount = 0;
        private int _loseCount = 0;
        public Game()
        {

        }
        public void Start()
        {
            Console.Write("What is your name hero?: ");
            string? playerName = Console.ReadLine();
            while (string.IsNullOrEmpty(playerName) || !Regex.IsMatch(playerName, @"^[A-Za-z\s]+$"))
            {
                Console.Clear();
                Console.Write("Please tell me your name: ");
                playerName = Console.ReadLine();
            }
            _hero = new Hero(playerName);
            _shop = new Shop(_hero);
            PrintLore();
            DisplayMainMenu();
        }
        public void Restart()
        {

        }
        private void PrintLore()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"I'm sorry, {_hero.Name}, but you have been played for a fool, there is no princess at this castle, ");
            Console.WriteLine("no treasure to be found, or glory to be gained, you have not been called here to deal justice, ");
            Console.WriteLine("although you have been called");
            Console.WriteLine("Were you setup?, betrayed?, or maybe something else?, that no longer matters, ");
            Console.WriteLine("for there is no escape for you anymore");
            Console.WriteLine("How long will you last among the creatures that crawl in the dark before you become a prisoner of your own mind?");
            Console.WriteLine();
            Console.WriteLine("(Press any key to continue)");
            Console.ReadKey(intercept: true);
        }
        private void DisplayMainMenu()
        {
            string title = File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\TitleBanner.txt");
            Console.Clear();
            Console.WriteLine("How deep will you go in your \n");
            Console.WriteLine(title);
            Console.WriteLine("Press the number corresponding to the option \n");
            Console.WriteLine("1. Proceed to next Fight");
            Console.WriteLine("2. Open Shop");
            Console.WriteLine("3. Display Equipment");
            Console.WriteLine("4. Display Statistics");
            ConsoleKey menuKey = Console.ReadKey(intercept: true).Key;
            MenuKeyPress(menuKey);
        }
        private void MenuKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    StartNewFight();
                    DisplayMainMenu();
                    break;

                case ConsoleKey.D2:
                    _shop.DisplayShopMenu();
                    DisplayMainMenu();
                    break;

                case ConsoleKey.D3:
                    _hero.DisplayEquipment();
                    DisplayMainMenu();
                    break;

                case ConsoleKey.D4:
                    DisplayStatistics();
                    DisplayMainMenu();
                    break;

                //case ConsoleKey.Escape:
                //    Environment.Exit(0);
                //    break;

                default:
                    DisplayMainMenu();
                    break;
            }
        }
        private void StartNewFight()
        {
            _fight = new Fight(_hero);
            _fight.ShowFightMenu();
        }
        private void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("Showing statistics \n");
            Console.WriteLine($"Total Encounters: {_fightCount}, Monsters Conquered: {_winCount}, Souls Lost {_loseCount}\n");
            _hero.GetStats();
            Console.WriteLine("(Press any key to go back)");
            Console.ReadKey(intercept: true);
        }
    }
}
