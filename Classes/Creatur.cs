using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes
{
    abstract internal class Creatur
    {
        protected uint health;
        protected uint[] damageDiapason;
        protected uint attack;
        protected uint defense;
        //TODO: what do with asseting with 0? need add epsilon
        public Creatur(
            uint Health,
            uint[] DamageDiapason,
            uint Attack,
            uint Defense
            ) 
        {
            health = Health > 0 
                        ? Health 
                        : 1;
            attack = Attack > 1 
                        ? Attack
                        : 1;
            defense = Defense > 1 
                        ? Defense < 30 
                            ? Defense 
                            : 30
                        : 1;

            if(DamageDiapason.Length > 2) {
                throw new Exception();
            }
            damageDiapason = new uint[] { DamageDiapason.Min() > 0 ? DamageDiapason.Min() : 1, DamageDiapason.Max() };
        }
        protected void Hit(Creatur defender) {
            var attackModificator = CalculateAttackModificator(attack, defender.defense);
            var results = Randomizer.TossDice(attackModificator);
        }
        protected uint CalculateAttackModificator(uint assaulterDamage, uint defenderDefense)
        {
            return (uint)Math.Abs(assaulterDamage - defenderDefense) + 1;
        }
        protected uint getDamageDeal(uint[] DamageDiapason)
        {
            return Randomizer.getRandomValueInDiapason(DamageDiapason);
        }
    }
}
