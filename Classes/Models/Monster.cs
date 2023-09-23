using GamersAndMonsters.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes.Models
{
    internal class Monster : Creature
    {
        public Monster(string Name, int Health, int[] DamageDiapason, int Attack, int Defense, GameLogger logger) : base(Name, Health, DamageDiapason, Attack, Defense, logger)
        {
        }
    }
}
