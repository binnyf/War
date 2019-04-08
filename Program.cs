
using GameNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            string option = null;
            do
            {
                Console.WriteLine("Do you want to play the game?");
                option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "YES":
                        try
                        {
                            playGame();
                        }
                        catch (Exception what)
                        {
                            Console.WriteLine(what.Message);
                        }
                        //TO DO
                        break;
                    case "NO":
                        break;
                    default:
                        Console.WriteLine("Wrong Choice!!");
                        break;
                }
            } while (option != "YES" && option != "NO");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void playGame()
        {
            Player me = new Player { Name = "Player 1" };
            Player you = new Player { Name = "Player 2" };
            Game game = new Game(me,you);
            game.start();
        }
    }
}