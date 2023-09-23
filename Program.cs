using GamersAndMonsters.Classes.Helpers;
using GamersAndMonsters.Classes.Models;

var logger = new GameLogger();
//Cases - empty or invalid any of fields
//var hero1 = new Hero("", 42, new int[] { 1, 2 }, 10, 10, logger);
//var hero1 = new Hero("Hero1", 0, new int[] { 1, 2 }, 10, 10, logger);
//var hero1 = new Hero("Hero1", 42, new int[] { 0, 2 }, 10, 10, logger);
//var hero1 = new Hero("Hero1", 42, new int[] { 1, 2,3 }, 10, 10, logger);
//var hero1 = new Hero("Hero1", 42, new int[] { 1, 2 }, 0, 10, logger);
//var hero1 = new Hero("Hero1", 42, new int[] { 1, 2 }, 10, 0, logger);

//Cases - heal dead
//var hero1 = new Hero("Hero1", 33, new int[] { 1, 2 }, 10, 10, logger);
//var monster1 = new Monster("Monster1", 33, new int[] { 1, 2 }, 15, 10, logger);
//while(!hero1.isDead()) monster1.Hit(hero1);
//hero1.Heal();

//Cases - attack dead
//var hero1 = new Hero("Hero1", 33, new int[] { 1, 2 }, 10, 10, logger);
//var monster1 = new Monster("Monster1", 33, new int[] { 1, 2 }, 15, 10, logger);
//while (!hero1.isDead()) monster1.Hit(hero1);
//monster1.Hit(hero1);


//Cases - only 4 charges to heal
var hero2 = new Hero("Hero2", 333, new int[] { 1, 2 }, 10, 10, logger);
var monster2 = new Monster("Monster2", 33, new int[] { 1, 2 }, 15, 10, logger);
for (int i = 0; i < 225; i++) monster2.Hit(hero2);
hero2.Heal();
hero2.Heal();
hero2.Heal();
for (int i = 0; i < 215; i++) monster2.Hit(hero2);
hero2.Heal();
hero2.Heal();