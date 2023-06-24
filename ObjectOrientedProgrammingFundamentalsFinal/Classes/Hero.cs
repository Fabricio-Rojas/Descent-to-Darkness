namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Hero
    {
        private int _currentHealth, _exp, _lvlUpThreshold;

        public string Name;
        public int Level, Gold, BaseStrength, BaseDefense, OriginalHealth;
        public bool IsStrengthBuffed = false;
        public int Exp
        {
            get { return _exp; }
            set
            {
                if (value >= _lvlUpThreshold)
                {
                    LevelUp();
                    _exp = 0;
                }
                _exp = value;
            }
        }
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
        public List<Consumable> ConsumableList;
        Random rand = new Random();

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            _lvlUpThreshold = 100;
            Exp = 0;
            Gold = rand.Next(11);
            BaseStrength = (int)Math.Round(20 * rand.NextDouble()) + 5;
            BaseDefense = (int)Math.Round(10 * rand.NextDouble()) + 3;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
            WeaponList = new List<Weapon>();
            ArmourList = new List<Armour>();
            ConsumableList = new List<Consumable>();
            EquippedWeapon = new Weapon("Bloodied Fist", 0);
            EquippedArmour = new Armour("Tattered Rags", 0);
            AddNewWeapon(EquippedWeapon);
            AddNewArmor(EquippedArmour);
            AddNewConsumable(new Consumable(0));
        }
        public void LevelUp()
        {
            Level++;
            BaseStrength = (int)(2 + BaseStrength * 1.15);
            BaseDefense = (int)(1 + BaseDefense * 1.10);
            int OldHealth = OriginalHealth;
            OriginalHealth = (int)(OriginalHealth * 1.2);
            CurrentHealth += OriginalHealth - OldHealth;
            _lvlUpThreshold = (int)((1 - (1 / ((0.112 * Level) + 1))) * 1000);
        }
        public void GetStats()
        {
            Console.WriteLine($"Name: {Name}\nLevel: {Level}\nGold: {Gold}\nBase Strenght: {BaseStrength}\nBase Defense: {BaseDefense}");
            Console.WriteLine($"Max Health: {OriginalHealth}hp\nCurrent Health: {CurrentHealth}hp\n");
        }
        public void DisplayEquipment()
        {
            Console.Clear();
            Console.WriteLine("Showing Equipment\n");
            Console.WriteLine($"EQUIPPED WEAPON: {EquippedWeapon.Name}, {EquippedWeapon.Power} Power, {EquippedWeapon.Price} Gold; EQUIPPED ARMOUR: {EquippedArmour.Name}, {EquippedArmour.Power} Power, {EquippedArmour.Price} Gold\n");
            Console.WriteLine("1. Change Equipped Weapon");
            Console.WriteLine("2. Change Equipped Armour");
            Console.WriteLine("3. Show Full Inventory\n");
            Console.WriteLine("(Press Esc to return to Main Menu)");
            ConsoleKey key = Console.ReadKey(intercept: true).Key;
            EquipmentKeyPress(key);
        }
        private void EquipmentKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    ShowEquipWeaponMenu();
                    DisplayEquipment();
                    break;

                case ConsoleKey.D2:
                    ShowEquipArmourMenu();
                    DisplayEquipment();
                    break;

                case ConsoleKey.D3:
                    PrintInventory();
                    DisplayEquipment();
                    break;

                case ConsoleKey.Escape:
                    break;

                default:
                    DisplayEquipment();
                    break;
            }
        }
        public void Consume(Consumable consumable)
        {
            consumable.BeConsumed(this);
        }
        public void AddNewWeapon(Weapon weapon)
        {
            if (WeaponList.Count + 1 > 9)
            {
                Console.WriteLine("You can only hold up to 9 weapons at once");
                Console.ReadKey(intercept: true);
                return;
            }
            WeaponList.Add(weapon);
        }
        public void AddNewArmor(Armour armour)
        {
            if (ArmourList.Count + 1 > 9)
            {
                Console.WriteLine("You can only hold up to 9 armours at once");
                Console.ReadKey(intercept: true);
                return;
            }
            ArmourList.Add(armour);
        }
        public void AddNewConsumable(Consumable consumable)
        {
            if (ConsumableList.Count + 1 > 9)
            {
                Console.WriteLine("You can only hold up to 9 consumables at once");
                Console.ReadKey(intercept: true);
                return;
            }
            ConsumableList.Add(consumable);
        }
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
            Console.WriteLine($"\n(Equipped {weapon.Name})");
            Console.ReadKey(intercept: true);
        }
        public void EquipArmour(Armour armour)
        {
            EquippedArmour = armour;
            Console.WriteLine($"\n(Equipped {armour.Name})");
            Console.ReadKey(intercept: true);
        }
        public void ShowEquipWeaponMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose Weapon to equip\n");
            for (int i = 0; i < WeaponList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {WeaponList[i].Name}, {WeaponList[i].Power} power, {WeaponList[i].Price} Gold");
            }
            Console.WriteLine("\n(Press esc to return)");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (char.IsDigit(key.KeyChar) && int.Parse(key.KeyChar.ToString()) > 0 && int.Parse(key.KeyChar.ToString()) <= WeaponList.Count)
            {
                EquipWeapon(WeaponList[int.Parse(key.KeyChar.ToString()) - 1]);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                ShowEquipWeaponMenu();
            }
        }
        public void ShowEquipArmourMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose Armour to equip\n");
            for (int i = 0; i < ArmourList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ArmourList[i].Name}, {ArmourList[i].Power} power, {ArmourList[i].Price} Gold");
            }
            Console.WriteLine("\n(Press esc to return)");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (char.IsDigit(key.KeyChar) && int.Parse(key.KeyChar.ToString()) > 0 && int.Parse(key.KeyChar.ToString()) <= ArmourList.Count)
            {
                EquipArmour(ArmourList[int.Parse(key.KeyChar.ToString()) - 1]);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                ShowEquipArmourMenu();
            }
        }
        private void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine("Showing full inventory\n");
            int biggestLength = Math.Max(Math.Max(WeaponList.Count, ArmourList.Count), ConsumableList.Count);
            if (biggestLength <= 0)
            {
                Console.WriteLine("(No items to show)");
                Console.ReadKey(intercept: true);
                return;
            }
            Console.SetCursorPosition(0, 2);
            Console.Write("WEAPONS");
            Console.SetCursorPosition(44, 2);
            Console.Write("ARMOUR");
            Console.SetCursorPosition(92, 2);
            Console.Write("CONSUMABLES");
            for (int i = 0; i < biggestLength; i++)
            {
                Console.SetCursorPosition(0, i + 4);
                if (i < WeaponList.Count)
                {
                    Console.Write($"{i + 1}. {WeaponList[i].Name}, {WeaponList[i].Power} power, {WeaponList[i].Price} Gold");
                }
                Console.SetCursorPosition(44, i + 4);
                if (i < ArmourList.Count)
                {
                    Console.Write($"{i + 1}. {ArmourList[i].Name}, {ArmourList[i].Power} power, {ArmourList[i].Price} Gold");
                }
                Console.SetCursorPosition(92, i + 4);
                if (i < ConsumableList.Count)
                {
                    Console.Write($"{i + 1}. {ConsumableList[i].Name}, {ConsumableList[i].Price} Gold\n");
                }
            }
            Console.WriteLine();
            Console.WriteLine("(Press any key to go back)");
            Console.ReadKey(intercept: true);
        }
    }
}
