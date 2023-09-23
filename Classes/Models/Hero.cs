using GamersAndMonsters.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersAndMonsters.Classes.Models
{
    internal class Hero : Creature
    {
        private int healCount;
        public int HealCount { get { return healCount; } }
        private static readonly double healCoefficient = 0.3;
        private static readonly int maxHealCount = 4;
        public static int MaxHealCount {  get { return maxHealCount; } }
         public Hero(
            string Name,
            int Health,
            int[] DamageDiapason,
            int Attack,
            int Defense,
            GameLogger logger
            ) : base(Name,
                Health,
                DamageDiapason,
                Attack,
                Defense,
                logger
                )
        {
            healCount = 0;
        }
        public void Heal()
        {
            if (!isDead())
            {
                if (Health < MaxHealth)
                {
                    var currentHealth = _health;
                    if (isHealChargesEnought())
                    {
                        HealOperation();
                        if (isHealOverMaxHealth())
                        {
                            _health = _maxHealth;
                        }
                        healCount++;
                        _logger.LogHeroHealThemself(this, _health - currentHealth);
                    }
                    else { _logger.LogErrorHeroTryToHealWithoutCharges(this); }
                }
                else { _logger.LogErrorHeroTryToHealWithMaximumHealth(this); }
                
            }
            else { _logger.LogErrorDeadHeroTryToHeal(this); }
            
        }

        private bool isHealOverMaxHealth()
        {
            return _health > _maxHealth;
        }

        private int healingAmount()
        {
            return (int)(_maxHealth * healCoefficient);
        }
        private void HealOperation()
        {
            _health += healingAmount();
        }
        private bool isHealChargesEnought() { return healCount < maxHealCount; }
    }
}
