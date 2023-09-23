using GamersAndMonsters.Classes.Helpers;
namespace GamersAndMonsters.Classes.Models
{
    internal class Hero : Creature
    {
        public int HealCount { get; set; }
        public static int MaxHealCount { get => 4; }
        private static double HealCoefficient { get => 0.3; }

        public Hero(string Name, int Health, int[] DamageDiapason, int Attack, int Defense, GameLogger logger)
    : base(Name, Health, DamageDiapason, Attack, Defense, logger)
        {
            HealCount = 0;
        }

        public void Heal()
        {

            if(!isValidatHeal()) return;

            var currentHealth = Health;
            HealOperation();

            if (isHealOverMaxHealth()) Health = MaxHealth;

            HealCount++;
            _logger.LogHeroHealThemself(this, Health - currentHealth);

        }
        private bool isValidatHeal()
        {
            if (isDead())
            {
                _logger.LogWarningDeadHeroTryToHeal(this);
                return false;
            }

            if (Health == MaxHealth)
            {
                _logger.LogWarningHeroTryToHealWithMaximumHealth(this);
                return false;
            }

            if (!isHealChargesEnought())
            {
                _logger.LogWarningHeroTryToHealWithoutCharges(this);
                return false;
            }
            return true;
        }
        private bool isHealOverMaxHealth() => Health > MaxHealth;

        private int healingAmount() => (int)(MaxHealth * HealCoefficient);

        private void HealOperation() => Health += healingAmount();

        private bool isHealChargesEnought() { return HealCount < MaxHealCount; }
    }
}
