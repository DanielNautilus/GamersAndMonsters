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
        public Monster(
           string name,
           int health,
           int[] damageDiapason,
           int attack,
           int defense,
           GameLogger logger
           )
           : base(
               name,
               health,
               damageDiapason,
               attack,
               defense,
               logger
               )
        {
        }
    }
}
