using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes
{
    internal class Randomizer
    {
        private static readonly Random random = new Random();
        private static readonly int minDice = 1;
        private static readonly int maxDice = 6;

        public static uint[] TossDice(uint rollCount)
        {
            var result = new uint[rollCount];
            
            for (var i = 0;i < rollCount; i++)
            {
                result[i] = (uint)random.Next(minDice, maxDice + 1);
            }
            return result;
        }
        public static uint getRandomValueInDiapason(uint[] valuesDiapason)
        {
            return (uint)random.Next((int)valuesDiapason.Min(), (int)valuesDiapason.Max() + 1);
        }
    }
}