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
        private int _heroDamage = 0;
        private int _monsterDamage = 0;
        public Fight(Hero hero)
        {
            _hero = hero;
            _monster = new Monster(_hero);
        }
        public void RenderFace()
        {
            Console.Clear();
            Console.WriteLine($"You encounter {_monster.Name} (Level {_monster.Level}, {_monster.CurrentHealth}/{_monster.OriginalHealth} HP, {_monster.Strength} Strength, {_monster.Defence} Defense)\n");
            Console.WriteLine($"{_monster.Face}");
        }
        public bool ShowFightMenu()
        {
            while (_hero.CurrentHealth > 0 && _monster.CurrentHealth > 0)
            {
                Console.Clear();
                Console.WriteLine($"You encounter {_monster.Name} (Level {_monster.Level}, {_monster.CurrentHealth}/{_monster.OriginalHealth} HP, {_monster.Strength} Strength, {_monster.Defence} Defense)\n");
                Console.WriteLine($"{_monster.Face}"); 
                HeroTurn();
                WriteSideLine("");
                WriteSideLine("(Press any key to continue)\n");
                Console.ReadKey(intercept: true);
                MonsterTurn();
                ResolveTurns();
            }
            return FightFinish();
        }
        public void HeroTurn()
        {
            Console.CursorTop = 2;
            WriteSideLine($"The hero {_hero.Name}'s turn\n");
            WriteSideLine($"WEAPON: {_hero.EquippedWeapon.Name}, {_hero.EquippedWeapon.Power} Power; ARMOUR: {_hero.EquippedArmour.Name}, {_hero.EquippedArmour.Power} Power");
            WriteSideLine($"(Level {_hero.Level}, {_hero.CurrentHealth}/{_hero.OriginalHealth} HP, {_hero.BaseStrength} Strength, {_hero.BaseDefense} Defense)\n");
            WriteSideLine("What will you do?\n");
            WriteSideLine("1. Strike");
            WriteSideLine("2. Block");
            WriteSideLine("3. Focus yourself");
            WriteSideLine("4. Use Consumables\n");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    WriteSideLine(_hero.Strike(_monster, out _heroDamage));
                    break;

                case ConsoleKey.D2:
                    WriteSideLine(_hero.Block());
                    break;

                case ConsoleKey.D3:
                    WriteSideLine(_hero.Focus());
                    break;

                case ConsoleKey.D4:
                    ConsumeMenu();
                    RenderFace();
                    HeroTurn();
                    break;

                default:
                    HeroTurn();
                    break;
            }
        }
        public void MonsterTurn()
        {
            WriteSideLine(_monster.DoMonsterAction(_hero, out _monsterDamage));
            WriteSideLine("");
            WriteSideLine("(Press any key to continue)\n");
            Console.ReadKey(intercept: true);
        }
        public void ResolveTurns()
        {
            if (_heroDamage > 0)
            {
                if (_monster.IsBlocking && _hero.IsFocused)
                {
                    _heroDamage *= 2;
                }
                else if (_monster.IsBlocking)
                {
                    _heroDamage = 0;
                }
                _monster.CurrentHealth -= _heroDamage;
                _hero.IsFocused = false;
            }
            if (_monster.CurrentHealth <= 0)
            {
                _hero.IsBlocking = false;
                _monster.IsBlocking = false;
                return;
            }
            if (_monsterDamage > 0)
            {
                if (_hero.IsBlocking && _monster.IsFocused)
                {
                    _monsterDamage *= 9 / 4; // 2.25
                }
                else if (_hero.IsBlocking)
                {
                    _monsterDamage = 0;
                }
                _hero.CurrentHealth -= _monsterDamage;
                _monster.IsFocused = false;
            }
            _heroDamage = 0;
            _monsterDamage = 0;
            _hero.IsBlocking = false;
            _monster.IsBlocking = false;
        }
        public bool FightFinish()
        {
            bool result = true;
            if (_hero.CurrentHealth <= 0) result = Lose();
            if (_monster.CurrentHealth <= 0) result = Win();
            WriteSideLine("(Press any key to continue)");
            Console.ReadKey(intercept: true);
            return result;
        }
        public bool Win()
        {
            _hero.Exp += _monster.Exp;
            _hero.Gold += _monster.Gold;
            WriteSideLine($"{_hero.Name} felled the monster, and gains another chance to live");
            WriteSideLine($"Gained: {_monster.Exp} Exp & {_monster.Gold} Gold\n");
            return true;
        }
        public bool Lose()
        {
            WriteSideLine($"{_hero.Name}'s body is devoured the monster");
            WriteSideLine($"You never reached the true depths\n");
            return false;
        }
        private void ConsumeMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose item to consume\n");
            for (int i = 0; i < _hero.ConsumableList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_hero.ConsumableList[i].Name}, {_hero.ConsumableList[i].Price} Gold");
            }
            Console.WriteLine("\n(Press esc to return)\n");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (char.IsDigit(key.KeyChar) && int.Parse(key.KeyChar.ToString()) > 0 && int.Parse(key.KeyChar.ToString()) <= _hero.ConsumableList.Count)
            {
                Console.WriteLine(_hero.Consume(_hero.ConsumableList[int.Parse(key.KeyChar.ToString()) - 1], _monster));
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
        private void WriteSideLine(string? text)
        {
            Console.CursorLeft = 53;
            Console.WriteLine(text);
        }
    }
}
