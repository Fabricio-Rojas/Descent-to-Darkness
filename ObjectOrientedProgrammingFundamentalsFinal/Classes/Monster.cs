using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    internal class Monster
    {
        public List<string> Faces = new List<string>
        {
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace1.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace2.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace3.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace4.txt"),
            File.ReadAllText(@"D:\Visual Studio Projects\ObjectOrientedProgrammingFundamentalsFinal\ObjectOrientedProgrammingFundamentalsFinal\Graphics\MonsterFace5.txt"),
        };
        public string Name;
        public int Level;
        public int Exp;
        public int Gold;
        public int Strength;
        public int Defence;
        public int OriginalHealth;
        public int CurrentHealth;
        private Random random = new Random();
        public Monster()
        {

        }
    }
}
