



namespace Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            Test4();
        }

        private static void Test4()
        {
            Game game = new Game();

            game.LoadMapFromPlainText("pmp_arena.txt");

            game.Run();
        }

        private static void Test3()
        {
            Player player = new Player(10, 2);
            Console.BackgroundColor = player.Sprite.Background;
            Console.ForegroundColor = player.Sprite.ForeGround;
            Console.SetCursorPosition(player.Pos.PosX, player.Pos.PosY);
            Console.WriteLine(player.Sprite.Symbol);
        }

        private static void Test2()
        {
            ConsoleSprite sprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.Cyan, '@');
            Console.BackgroundColor = sprite.Background;
            Console.ForegroundColor = sprite.ForeGround;
            Console.WriteLine(sprite.Symbol);
        }

        private static void Test1()
        {
            Position pos1 = new Position(3, 4);
            Position pos2 = new Position(6, 8);

            Position value = Position.Add(pos1, pos2);
            double distance = Position.Distance(pos1, pos2);
            Console.WriteLine($"Added Position: ({value.PosX}, {value.PosY})");
            Console.WriteLine($"Distance: {distance}");
        }
    }
}
