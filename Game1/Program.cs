using System;
using static System.Environment;
using System.Threading.Tasks;

namespace Game1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var gameState = true;
            var player1 = new Player();
            var enemy1 = new Enemy
            {
                Name = "Bloog the Booper",
                Health = 3
            };
            
            MainMenu.ShowWelcomeMessage(player1);
            MainMenu.ShowMainMenu(player1);
            Console.Clear();

            Console.WriteLine($"An Enemy called {enemy1.Name} has appeared!");
            await Task.Delay(1000);
            while (gameState && player1.Alive && enemy1.Alive)
            {
                //player turn
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("==============");
                Console.WriteLine("   >attack<   ");
                Console.WriteLine(">roll defense<");
                Console.WriteLine("==============" + NewLine);
                
                //player combat menu switch
                var combatmenuSelection = Console.ReadLine();
                switch (combatmenuSelection?.ToLower().Trim())
                {
                    case "attack":
                    case "att":
                    case "a":
                    {
                        Console.Clear();
                        Console.WriteLine("Guess a number between 0 and 10 to attack!");
                        if (int.TryParse(Console.ReadLine(), out var attackInput) && attackInput >= 0 &&
                            attackInput <= 10)
                        {
                            Console.Clear();
                            await Task.Delay(500);
                            player1.Attack(enemy1, attackInput);
                            await Task.Delay(1000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input! Please enter 0-10.");
                            Console.Clear();
                            continue;
                        }
                        break;
                    }
                    case "roll defense":
                    case "roll":
                    case "r":
                    {
                        Console.Clear();
                        Console.WriteLine("Rolling new defense!");
                        Console.WriteLine(".");
                        await Task.Delay(500);
                        Console.WriteLine(".");
                        await Task.Delay(500);
                        Console.WriteLine(".");
                        await Task.Delay(500);
                        player1.RollNewDefense();
                        Console.WriteLine("Your defense has been rolled!" + NewLine);
                        await Task.Delay(500);
                        Console.WriteLine($"Your defense is {player1.Defense}");
                        await Task.Delay(1000);
                        Console.Clear();
                        break;
                    }
                    default:
                        Console.WriteLine("Invalid input! Please enter a valid option!");
                        await Task.Delay(1000);
                        Console.Clear();
                        continue;
                }
                
                if (!enemy1.Alive) break;
                
                //enemy turn
                Console.WriteLine($"It's {enemy1.Name}'s turn!");
                await Task.Delay(1000);
                
                if (enemy1.Damaged)
                {
                    Console.Clear();
                    enemy1.RollNewDefense();
                    Console.WriteLine($"{enemy1.Name} rolled a new defense!");
                    enemy1.Damaged = false;
                    await Task.Delay(1000);
                    Console.Clear();
                    continue;
                }
                
                if (!enemy1.Damaged)
                {
                    Console.Clear();
                    int enemyGuess = new Random().Next(0, 10);
                    enemy1.Attack(player1, enemyGuess);
                    await Task.Delay(1000);
                    Console.Clear();
                }

                if (!player1.Alive) gameState = false;
                if (!gameState) MainMenu.ShowMainMenu(player1);
            }      
            Console.WriteLine(player1.Alive ? "You win!" : "Game Over!");
            MainMenu.ShowMainMenu(player1);
        }
    }
}