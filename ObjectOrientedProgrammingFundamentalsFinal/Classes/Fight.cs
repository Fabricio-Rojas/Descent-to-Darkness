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
            Console.WriteLine($"{_monster.Face}"); // doesnt work, find fix
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
        }
        public void HeroTurn()
        {
            // hero.ShowActionMenu();
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
    }
}
