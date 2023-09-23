using GamersAndMonsters.Classes.Models;

namespace GamersAndMonsters.Classes.Helpers
{

    internal class GameLogger
    {
        public GameLogger() 
        {
            Log("Game started");
        }
        private void Log(string message)
        {
            Console.WriteLine($"[Game Log] {message}");
        }
        public void LogError(string message)
        {
            Log($"[Error] {message}");
            Log("Game ended");
        }
        public void LogWarning(string message)
        {
            Log($"[Warning] {message}");
        }
        public void LogCreatureCreation(Creature creation)
        {
            Log($"Character '{creation.GetType().Name}' created with properties: \n" +
                $"Name - {creation.Name}\n" +
                $"Health - {creation.Health}\n" +
                $"Attack - {creation.Attack}\n" +
                $"Damage Diapason: {creation.DamageDiapason[0]} - {creation.DamageDiapason[1]}\n" +
                $"Defense - {creation.Defence} \n");
        }

        public void LogAttack(Creature assulter, Creature defender, int damage)
        {
            Log($"{assulter.Name} attacked {defender.Name} for {damage} damage.");
        }

        public void LogAttackMissed(Creature assulter, Creature defender)
        {
            Log($"{assulter.Name} attacked {defender.Name} and attack missed.");
        }

        public void LogHeroHealThemself(Hero hero, int healedHealth)
        {
            Log($"{hero.Name} heal them self on {healedHealth}, current hp: {hero.Health}/{hero.MaxHealth}, charges used {hero.HealCount} of {Hero.MaxHealCount}");
        }

        public void LogCreatureDead(Creature creature)
        {
            Log($"{creature.Name} is dead");
        }

        public void LogWarningCannotAttackDead(Creature assulter, Creature defender)
        {
            LogWarning($"{assulter.GetType().Name}: {assulter.Name} try to attack dead character {defender.GetType().Name}: {defender.Name}.");
        }

        public void LogWarningDeadCreatureTryToAttack(Creature creature)
        {
            LogWarning($"{creature.GetType().Name} can't attack cuz he is dead : {creature.Name}");
        }

        public void LogWarningDeadHeroTryToHeal(Hero hero)
        {
            LogWarning($"{hero.GetType().Name} can't heal cuz he is dead : {hero.Name}");
        }

        public void LogWarningHeroTryToHealWithoutCharges(Hero hero)
        {
            LogWarning($"{hero.GetType().Name} can't heal cuz he use all of charges: {hero.HealCount}/{Hero.MaxHealCount} : {hero.Name}");
        }

        public void LogWarningHeroTryToHealWithMaximumHealth(Hero hero)
        {
            LogWarning($"{hero.GetType().Name} can't heal cuz he actual have maximum hp: {hero.Health}/{hero.MaxHealth} : {hero.Name}");
        }

        public void LogWarningCreatureTryToHitYourself(Creature creature)
        {
            LogWarning($"{creature.GetType().Name} can't hit yourself: {creature.Name}");
        }

    }

}
