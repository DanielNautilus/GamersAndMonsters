using GamersAndMonsters.Classes.Helpers;

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
