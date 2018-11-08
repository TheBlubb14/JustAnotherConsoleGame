using JustAnotherConsoleGame.Input;
using JustAnotherConsoleGame.Map;
using JustAnotherConsoleGame.Map.Texture;
using System;
using System.Drawing;
using System.Text;

namespace JustAnotherConsoleGame
{
    class Program
    {
        private static InputManager inputManager = new InputManager();
        private static Player player;
        private static ITexturePack texturePack = new DoubleTexturePack();
        private static MapGenerator mapGenerator = new MapGenerator(new Point(30, 5), 20, 10, texturePack);

        static void Main(string[] args)
        {
            Console.CancelKeyPress += (s, e) => Environment.Exit(0);
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            mapGenerator.Draw();
            player = new Player(texturePack.Player, mapGenerator.SpawnPoint, mapGenerator);

            inputManager
                .Bind(player.MooveLeft, ConsoleKey.LeftArrow, ConsoleKey.A)
                .Bind(player.MooveRight, ConsoleKey.RightArrow, ConsoleKey.D)
                .Bind(player.MooveUp, ConsoleKey.UpArrow, ConsoleKey.W)
                .Bind(player.MooveDown, ConsoleKey.DownArrow, ConsoleKey.S);

            inputManager.Run();
            Console.WriteLine("stopped");
            Console.ReadLine();
        }
    }
}
