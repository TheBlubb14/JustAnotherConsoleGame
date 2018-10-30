using JustAnotherConsoleGame.Input;
using System;
using System.Text;

namespace JustAnotherConsoleGame
{
    class Program
    {
        private static InputManager inputManager = new InputManager();

        static void Main(string[] args)
        {
            Console.CancelKeyPress += (s, e) => Environment.Exit(0);
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            inputManager
                .Bind(MooveLeft, ConsoleKey.LeftArrow, ConsoleKey.A)
                .Bind(MooveRight, ConsoleKey.RightArrow, ConsoleKey.D)
                .Bind(MooveUp, ConsoleKey.UpArrow, ConsoleKey.W)
                .Bind(MooveDown, ConsoleKey.DownArrow, ConsoleKey.S);


            inputManager.Run();
            Console.WriteLine("stopped");
            Console.ReadLine();
        }

        static void MooveLeft()
        {
            Console.Title = "left";
        }

        static void MooveRight()
        {
            Console.Title = "right";
        }

        static void MooveUp()
        {
            Console.Title = "up";
        }

        static void MooveDown()
        {
            Console.Title = "down";
        }
    }
}
