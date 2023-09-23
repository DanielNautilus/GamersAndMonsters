using GamersAndMonsters.Classes.Helpers;
using GamersAndMonsters.Classes.Models;

var logger = new GameLogger();

var hero1 = new Hero("Hero1",33,new int[] { 1,2 }, 10, 10, logger);
var monster1 = new Monster("Monster1", 33, new int[] { 1, 2 }, 15, 10, logger);

//while(!monster1.isDead()) hero1.Hit(monster1);
hero1.Hit(monster1);

for (int i = 0; i < 25; i++) monster1.Hit(hero1);
hero1.Heal();
hero1.Heal();
hero1.Heal();
for (int i = 0; i < 15; i++) monster1.Hit(hero1);
hero1.Heal();
hero1.Heal();