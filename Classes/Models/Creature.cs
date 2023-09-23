using GamersAndMonsters.Classes.Helpers;

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
        private static readonly int DamageDiapasonLength = 2;
        
        private static List<String> creaturesNames = new List<string>();
        
        protected readonly GameLogger _logger;

        protected internal string Name { get; }
        protected internal int Attack { get; protected set; }

        protected internal int Defence { get; protected set; }

        protected internal int[] DamageDiapason { get;protected set; }

        protected internal int Health { get; protected set; }

        protected internal int MaxHealth { get; protected set; }

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
            FieldsValidator.Initialize(logger);
            ValidateName(name);
            Name = name;
            ValidateHealth(health);
            Health = health;
            MaxHealth = health;
            ValidateDamageDiapason(damageDiapason);
            DamageDiapason = new int[]
            {
                damageDiapason.Min(),
                damageDiapason.Max()
            };
            ValidateAttack(attack);
            Attack = attack;
            ValidateDefence(defence);
            Defence = defence;
            creaturesNames.Add(name);
            _logger.LogCreatureCreation(this);
        }

        protected internal void Hit(Creature defender)
        {
            if (!IsValidHit(defender)) return;
            if (!IsSuccessefulHit(defender))  return;

            var dealedDamage = DealDamage(defender);
            _logger.LogAttack(this, defender, dealedDamage);

            if (defender.isDead()) { _logger.LogCreatureDead(defender); }
            
        }

        private bool IsValidHit(Creature defender)
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
        
        private int CalculateAttackModificator(int defenderDefense) => Attack > defenderDefense ? Attack - defenderDefense + 1 : 1;

        private int CalculatedDamageDeal() => Randomizer.getRandomValueInDiapason(DamageDiapason);

        private bool isAvailiableToAttack(List<int> tossDiceResults)
        {
            foreach(var tosseDice  in tossDiceResults)
            {
                if (tosseDice > minTossToSuccessAttack) return true;
            }
            return false;
        }

        public bool isDead() => Health <= 0 ? true : false;

        private int DealDamage(Creature defender)
        {
            var currentDefenderHealth = defender.Health;
            var calculatedDamage = CalculatedDamageDeal();
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
        
        private void ValidateName(String name)
        {
            FieldsValidator.ValidateName(name, creaturesNames);
        }

        private void ValidateHealth(int health)
        {
            FieldsValidator.ValidateRange(health, minHealth, maxHealth, nameof(health));
        }

        private void ValidateDamageDiapason(int[] damageDiapason)
        {
            FieldsValidator.ValidateDiapason(damageDiapason, DamageDiapasonLength, minDamageDiapasonValue, maxDamageDiapasonValue, nameof(damageDiapason));
        }

        private void ValidateAttack(int attack)
        {
            FieldsValidator.ValidateRange(attack, minAttack, maxAttack, nameof(attack));
        }
        private void ValidateDefence(int defence)
        {
            FieldsValidator.ValidateRange(defence, minDefence, maxDefence, nameof(defence));
        }

    }
}
