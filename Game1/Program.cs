using System;
using static System.Environment;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Player player1 = new Player();
            Enemy enemy1 = new Enemy();
            enemy1.Name = "Bloog the Booper";
            enemy1.Health = 3;
            bool gameState = true;
            
            MainMenu.ShowWelcomeMessage(player1);
            MainMenu.ShowMainMenu(player1);
            Console.Clear();
            
            Console.WriteLine($"An Enemy called {enemy1.Name} has appeared!");
            
            while (gameState && player1.Alive && enemy1.Alive)
            {
                //player turn
                Console.WriteLine("Guess a number between 0 and 10 to attack!");
                if (int.TryParse(Console.ReadLine(), out int attackInput) && attackInput >= 0 && attackInput <= 10)
                {
                    await Task.Delay(500);
                    player1.Attack(enemy1, attackInput);
                    await Task.Delay(1000);
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 0-10.");
                    continue;
                }

                if (!enemy1.Alive) break;

                // enemy turn
                await Task.Delay(1000);
        
                int enemyGuess = new Random().Next(0, 10);
                enemy1.Attack(player1, enemyGuess);
                await Task.Delay(1000);

                if (!player1.Alive) break;

                // prepare
                enemy1.RollNewDefense();
                Console.WriteLine($"{enemy1.Name} prepares a new defense...");
                await Task.Delay(3000);
                Console.Clear();
                Console.WriteLine("It's your turn!");
                await Task.Delay(1000);
                Console.Clear();
            }

            Console.WriteLine(player1.Alive ? "You win!" : "Game Over!");
        }
    }
}