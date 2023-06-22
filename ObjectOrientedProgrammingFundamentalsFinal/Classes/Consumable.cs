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
        public Consumable(int type)
        {
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
        public void Consume(Hero hero)
        {
            switch (_type)
            {
                case 0:
                    // message: healed hero for 20% of total health
                    hero.CurrentHealth += (int)(hero.OriginalHealth * 0.2);
                    break;

                case 1:

                    break;

                case 2:
                    // reduced monsters defense by 20% percent
                    break;

                default: 
                    break;
            }
        }
    }
}
