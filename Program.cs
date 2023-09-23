

using GamersAndMonsters.Classes.Helpers;
using GamersAndMonsters.Classes.Models;

var logger = new GameLogger();

var hero1 = new Hero("Hero1", 33, new int[] { 1, 8 }, 12, 10, logger);
var monster1 = new Monster("Monster1", 33, new int[] { 1, 6 }, 8, 10, logger);

//while(!monster1.isDead()) hero1.Hit(monster1);
hero1.Hit(monster1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
monster1.Hit(hero1);
hero1.Heal();