using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Consumable
    {
        private Random random = new Random();
        private int _type;
        public string Name;
        public int Price;
        public bool IsBought;
        public Consumable(int type)
        {
            IsBought = false;
            _type = type;
            if (type < 1)
            {
                Name = "Healing Potion";
            }
            else if (type == 1)
            {
                Name = "Strength Potion";
            }
            else if (type > 1)
            {
                Name = "Acid Flask";
            }
            Price = random.Next(25, 100);
        }
        public string? BeConsumed(Hero hero)
        {
            switch (_type)
            {
                case 0:
                    // message: healed hero for 20% of total health
                    int healthHealed = (int)(hero.OriginalHealth * 0.2);
                    hero.CurrentHealth += healthHealed;
                    return $"Healed {hero.Name} for 20% of total health ({healthHealed})";

                case 1:
                    // next attack should deal 1.5 damage
                    hero.IsStrengthBuffed = true;
                    return $"{hero.Name} has been strengthned, dealing 50% more damage on next attack";

                case 2:
                    // reduced monsters defense by 20% percent
                    return $"The ";

                default: 
                    return default;
            }
            if (hero.ConsumableList.Contains(this))
            {
                hero.ConsumableList.Remove(this);
            }
        }
    }
}
