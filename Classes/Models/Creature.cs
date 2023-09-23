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
        private static readonly int minTossToSuccessAttack = 5;
        private static readonly int minHealth = 1;
        private static readonly int maxHealth = int.MaxValue;
        private static readonly int minAttack = 1;
        private static readonly int maxAttack = 30;
        private static readonly int minDefence = 1;
        private static readonly int maxDefence = 30;

        private static readonly int minDamageDiapasonValue = 1;
        private static readonly int maxDamageDiapasonValue = int.MaxValue;
        private static readonly int maxDamageDiapasonCount = 2;
        
        private static List<String> creaturesNames = new List<string>();
        
        protected readonly GameLogger _logger;

        protected internal string Name { get; }
        protected internal int Attack { get; protected set; }

        protected internal int Defence { get; protected set; }

        protected internal int[] DamageDiapason { get;protected set; }

        protected internal int Health { get; protected set; }

        protected internal int MaxHealth { get; protected set; }

        //TODO: what do with asseting with 0? need add epsilon
        protected Creature(
            string name,
            int health,
            int[] damageDiapason,
            int attack,
            int defence,
            GameLogger logger
            )
        {
            _logger = logger;


            validateName(name);
            Name = name;

            validateHealth(health);
            Health = health;
            MaxHealth = health;

            validateDamageDiapason(damageDiapason);
            DamageDiapason = new int[]
            {   
                damageDiapason.Min(),
                damageDiapason.Max()
            };

            validateAttack(attack);
            Attack = attack;

            validateDefence(defence);
             Defence = defence;

            creaturesNames.Add(name);
            _logger.LogCreatureCreation(this);
        }
        private void validateRange(int value, int min, int max, string paramName) {
            if (value < min || value > max)
            {
                _logger.LogError($"Creature {paramName.ToUpper()} should between {min} - {max}");
                throw new ArgumentOutOfRangeException(paramName, $"Value should be between {min} and {max}.");
            }
        }
        private void validateRange(int[] value, int min, int max, string paramName)
        {
            if (value.Min() < min || value.Max() > max)
            {
                _logger.LogError($"Creature must have {paramName.ToUpper()} between {min} - {max}");
                throw new ArgumentOutOfRangeException(paramName, $"Value should be between {min} and {max}.");
            }
        }

        private void validateName(String name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                _logger.LogError($"You can't create Creature with {name} is contains only spaces or empty");
                throw new ArgumentException("Name cannot be empty or null.");
            }
            if (creaturesNames.Contains(name))
            {
                _logger.LogError($"You can't create Creature with {name} is busy");
                throw new ArgumentException($"Creature {name} is busy");
            }
        }
        private void validateHealth(int health)
        {
            validateRange(health, minHealth, maxHealth, nameof(health));
        }
        private void validateDamageDiapason(int[] damageDiapason)
        {
            if (damageDiapason.Length > 2)
            {
                _logger.LogError($"You can't create Creature with a damage diapason length greater than {maxDamageDiapasonCount}");
                throw new ArgumentException($"Damage diapason length should not be greater than {maxDamageDiapasonCount}");
            }
            validateRange(damageDiapason, minDamageDiapasonValue, maxDamageDiapasonValue, nameof(damageDiapason));
        }

        protected internal void Hit(Creature defender)
        {
            if (!ValidateHit(defender)) return;
            if (!IsSuccessefulHit(defender))  return;

            var dealedDamage = dealDamage(defender);
            _logger.LogAttack(this, defender, dealedDamage);

            if (defender.isDead()) { _logger.LogCreatureDead(defender); }
            
        }
        private bool IsSuccessefulHit(Creature defender)
        {
            var attackModificator = CalculateAttackModificator(defender.Defence);
            var tossDiceResults = Randomizer.TossDice(attackModificator);
            if (!isAvailiableToAttack(tossDiceResults))
            {
                _logger.LogAttackMissed(this, defender);
                return false;
            }
            return true;
        }
        private bool ValidateHit(Creature defender)
        {
            if (this == defender)
            {
                _logger.LogWarningCreatureTryToHitYourself(this);
                return false;
            }

            if (isDead())
            {
                _logger.LogWarningDeadCreatureTryToAttack(this);
                return false;
            }

            if (defender.isDead())
            {
                _logger.LogWarningCannotAttackDead(this, defender);
                return false;
            }
            return true;
        }

        private void validateAttack(int attack)
        {
            validateRange(attack, minAttack, maxAttack, nameof(attack));
        }
        private void validateDefence(int defence)
        {
            validateRange(defence, minDefence, maxDefence, nameof(defence));
        }

        private int CalculateAttackModificator(int defenderDefense) => (Attack > defenderDefense) ? Attack - defenderDefense + 1 : 1;

        private int getDamageDeal() => Randomizer.getRandomValueInDiapason(DamageDiapason);

        private bool isAvailiableToAttack(List<int> tossDiceResults)
        {
            foreach(var tosseDice  in tossDiceResults)
            {
                if (tosseDice > minTossToSuccessAttack) return true;
            }
            return false;
        }

        public bool isDead() => Health <= 0 ? true : false;

        private int dealDamage(Creature defender)
        {
            var currentDefenderHealth = defender.Health;
            var calculatedDamage = getDamageDeal();
            if (calculatedDamage > currentDefenderHealth)
            {
                defender.Health = 0;
                return currentDefenderHealth;
            }
            else
            {
                defender.Health -= calculatedDamage;
                return calculatedDamage;
            }
        }

    }
}
