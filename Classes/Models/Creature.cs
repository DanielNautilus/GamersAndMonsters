using GamersAndMonsters.Classes.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes.Models
{
    abstract internal class Creature
    {
        private readonly string _name;
        protected int _health;
        protected int _maxHealth;
        private int[] _damageDiapason;
        private int _attack;
        private int _defense;
        protected readonly GameLogger _logger;
        private readonly int minTossToSuccessAttack = 5;
        public string Name { get => _name; }

        public int Health { get => _health; }

        public int MaxHealth { get => _maxHealth; }

        public int[] DamageDiapason { get => _damageDiapason; }

        public int Attack { get => _attack; }

        public int Defense { get => _defense; }

        //TODO: what do with asseting with 0? need add epsilon
        protected Creature(
            string Name,
            int Health,
            int[] DamageDiapason,
            int Attack,
            int Defense,
            GameLogger logger
            )
        {
            _logger = logger;
            _name = Name;
            _health = Health > 0
                        ? Health
                        : 1;
            _attack = Attack > 1
                        ? Attack < 30
                            ? Attack
                            : 30
                        : 1;
            _defense = Defense > 1
                        ? Defense < 30
                            ? Defense
                            : 30
                        : 1;
            _maxHealth = _health;
            if (DamageDiapason.Length > 2)
            {
                _logger.LogError("You Can't create Creature with 3th damage diapason");
                throw new Exception();
            }
            _damageDiapason = new int[] { DamageDiapason.Min() > 0 ? DamageDiapason.Min() : 1, DamageDiapason.Max() > 0 ? DamageDiapason.Max() : 1 };
            _logger.LogCreatureCreation(this);
        }

        protected internal void Hit(Creature defender)
        {
            if (!isDead())
            {
                if (!defender.isDead())
                {
                    var attackModificator = CalculateAttackModificator(defender._defense);
                    var tossDiceResults = Randomizer.TossDice(attackModificator);
                    if (isAvailiableToAttack(tossDiceResults))
                    {
                        var dealedDamage = dealDamage(defender);
                        _logger.LogAttack(this, defender, dealedDamage);
                        if (defender.isDead()) { _logger.LogCreatureDead(defender); }
                    }
                    else { _logger.LogAttackMissed(this, defender); }

                }
                else { _logger.LogCannotAttackDead(this, defender); }
            }
            else { _logger.LogErrorDeadCreatureTryToAttack(this); }
        }

        private int CalculateAttackModificator(int defenderDefense)
        {
            if (Attack > defenderDefense) return Attack - defenderDefense + 1;
            else return 1;
        }

        private int getDamageDeal()
        {
            return Randomizer.getRandomValueInDiapason(_damageDiapason);
        }

        private bool isAvailiableToAttack(List<int> tossDiceResults)
        {
            for (int i = 0; i < tossDiceResults.Count; i++)
            {
                if (tossDiceResults[i] > minTossToSuccessAttack)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDead()
        {
            return _health <= 0 ? true : false;
        }

        private int dealDamage(Creature defender)
        {
            var currentDefenderHealth = defender._health;
            var calculatedDamage = getDamageDeal();
            if (calculatedDamage > currentDefenderHealth)
            {
                defender._health = 0;
                return currentDefenderHealth;
            }
            else
            {
                defender._health -= calculatedDamage;
                return calculatedDamage;
            }
        }

    }
}
