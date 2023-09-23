using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes.Helpers
{
    internal class Randomizer
    {
        private static readonly Random random = new Random();
        private static readonly int minDice = 1;
        private static readonly int maxDice = 6;

        public static List<int> TossDice(int rollCount)
        {
            var result = new List<int>();

            for (var i = 0; i < rollCount; i++)
            {
                result.Add((int)(random.Next(minDice, maxDice + 1)));
            }
            return result;
        }
        public static int getRandomValueInDiapason(int[] valuesDiapason)
        {
            return (int)random.Next((int)valuesDiapason.Min(), (int)valuesDiapason.Max() + 1);
        }
    }
}