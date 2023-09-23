using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamersAndMonsters.Classes.Models;

namespace GamersAndMonsters.Classes.Helpers
{

    internal class GameLogger
    {
        private void Log(string message)
        {
            Console.WriteLine($"[Game Log] {message}");
        }
        public void LogError(string message)
        {
            Log($"[Error] {message}");
        }
        public void LogCreatureCreation(Creature creation)
        {
            Log($"Character '{creation.GetType().Name}' created with properties: \n" +
                $"Name - {creation.Name}\n" +
                $"Health - {creation.Health}\n" +
                $"Attack - {creation.Attack}\n" +
                $"Damage Diapason: {creation.DamageDiapason[0]} - {creation.DamageDiapason[1]}\n" +
                $"Defense - {creation.Defense} \n");
        }

        public void LogAttack(Creature assulter, Creature defender, int damage)
        {
            Log($"{assulter.Name} attacked {defender.Name} for {damage} damage.");
        }

        public void LogAttackMissed(Creature assulter, Creature defender)
        {
            Log($"{assulter.Name} attacked {defender.Name} and attack missed.");
        }

        public void LogCannotAttackDead(Creature assulter, Creature defender)
        {
            Log($"{assulter.Name} try to attack dead character {defender.Name}.");
        }
        public void LogHeroHealThemself(Hero hero, int healedHealth)
        {
            Log($"{hero.Name} heal them self on {healedHealth}, current hp: {hero.Health}/{hero.MaxHealth}, charges used {hero.HealCount} of {Hero.MaxHealCount}");
        }
        public void LogCreatureDead(Creature creature)
        {
            Log($"{creature.Name} is dead");
        }
        public void LogErrorDeadCreatureTryToAttack(Creature creature)
        {
            LogError($"{creature.GetType().Name} can't attack cuz he is dead : {creature.Name}");
        }
        public void LogErrorDeadHeroTryToHeal(Hero hero)
        {
            LogError($"{hero.GetType().Name} can't heal cuz he is dead : {hero.Name}");
        }
        public void LogErrorHeroTryToHealWithoutCharges(Hero hero)
        {
            LogError($"{hero.GetType().Name} can't heal cuz he use all of chargers: {hero.HealCount}/{Hero.MaxHealCount} : {hero.Name}");
        }
        public void LogErrorHeroTryToHealWithMaximumHealth(Hero hero)
        {
            LogError($"{hero.GetType().Name} can't heal cuz he actual have maximum hp: {hero.Health}/{hero.MaxHealth} : {hero.Name}");
        }
    }

}
