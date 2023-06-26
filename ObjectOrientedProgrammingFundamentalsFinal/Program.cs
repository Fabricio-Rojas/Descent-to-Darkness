using ObjectOrientedProgrammingFundamentalsFinal.Classes;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// a level up system that boosts stats when leveling up [done]
// also add consumables (healing potion, potion of strength, acid flask) [done]
// each shop has randomly generated items, with random names [done]
// create .txt files with ASCII art of the monsters [done]
// monsters also scale with levels and have random stats and names that scale with level [done]
// add gold granted by killing monsters, add options to buy weapons and armour in between fights [done]
// when restarting the game, create a new Hero and ask for a new Name [done]
// (optional after main game has finished) add monster AI and different actions [done]
// (optional after main game has finished) add skills, abilities and magic to the game

Game game = new Game();
game.Start();