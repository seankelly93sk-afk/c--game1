using System;
using static System.Environment;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Game1
{
    public class MainMenu
    {
        public static void ShowWelcomeMessage(Player player1)
        {
            Console.WriteLine("Welcome to the game!" + NewLine);
            Console.WriteLine("Please enter your name: " + NewLine);
            player1.Name = Console.ReadLine();
        }

        public static bool ShowMainMenu(Player player1)
        {
            Console.Clear();
            Console.WriteLine("============");
            Console.WriteLine("    MENU    ");
            Console.WriteLine("   >start<  ");
            Console.WriteLine("    >end<   ");
            Console.WriteLine("============" + NewLine);
            Console.WriteLine("Enter your selection, " + player1.Name + ":");

            var mainmenuSelection = Console.ReadLine();

            switch (mainmenuSelection?.ToLower().Trim())
            {
                case "start":
                case "s":
                    Console.WriteLine("Starting game...");
                    Thread.Sleep(2000);
                    return true;

                case "end":
                case "e":
                case "exit":
                    Console.WriteLine("Exiting game...");
                    Thread.Sleep(1000);
                    Exit(0);
                    return false;

                default:
                    Console.WriteLine("Please enter a valid option! Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return ShowMainMenu(player1);

            }
        }
        
    }
}