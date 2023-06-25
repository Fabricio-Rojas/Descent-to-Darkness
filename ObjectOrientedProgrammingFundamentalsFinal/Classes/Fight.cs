using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Fight
    {
        private Hero _hero;
        private Monster _monster;
        public Fight(Hero hero)
        {
            _hero = hero;
            _monster = new Monster(_hero);
        }
        public void ShowFightMenu()
        {
            Console.Clear();
            Console.WriteLine($"You encounter {_monster.Name}\n");
            Console.WriteLine($"{_monster.Face}"); 
            Console.SetCursorPosition(53, 2);
            Console.WriteLine($"The hero {_hero.Name}'s turn\n");
            HeroTurn();
        }
        public void HeroTurn()
        {
            // hero.ShowActionMenu();
            WriteSideLine("What will you do?\n");
            WriteSideLine("1. Strike");
            WriteSideLine("2. Block");
            WriteSideLine("3. Focus yourself");
            WriteSideLine("4. Use Consumables");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    _hero.Strike();
                    break;

                case ConsoleKey.D2:
                    _hero.Block();
                    break;

                case ConsoleKey.D3:
                    _hero.Focus();
                    break;

                case ConsoleKey.D4:
                    _hero.Focus();
                    break;

                default:
                    HeroTurn();
                    break;
            }
        }
        public void MonsterTurn()
        {
            // monster.DoMonsterAction();
        }
        public void Win()
        {

        }
        public void Lose()
        {

        }
        private void ConsumeMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose item to consume\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1}. {_hero.ConsumableList[i].Name}, {_hero.ConsumableList[i].Price} Gold");
            }
            Console.WriteLine("\n(Press esc to return)");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (char.IsDigit(key.KeyChar) && int.Parse(key.KeyChar.ToString()) > 0 && int.Parse(key.KeyChar.ToString()) <= _hero.ConsumableList.Count)
            {
                WriteSideLine(_hero.Consume(_hero.ConsumableList[int.Parse(key.KeyChar.ToString()) - 1]));
                Console.ReadKey(intercept: true);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                ConsumeMenu();
            }
        }
        private void WriteSideLine(string text)
        {
            Console.CursorLeft = 53;
            Console.WriteLine(text);
        }
    }
}
