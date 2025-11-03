



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
            GameItem ammo = new GameItem(new Position(5, 5), ItemType.Ammo);
            game.Items.Add(ammo);
            GameItem medkit = new GameItem(new Position(10, 10), ItemType.Medkit);
            game.Items.Add(medkit);
            GameItem wall = new GameItem(new Position(5, 15), ItemType.Wall);
            game.Items.Add(wall);
            GameItem wall2 = new GameItem(new Position(7, 15), ItemType.Wall);
            game.Items.Add(wall2);
            GameItem door = new GameItem(new Position(6, 15), ItemType.Door);
            game.Items.Add(door);

            Demon demon1 = new Demon(20, 5, DemonType.Imp);
            game.Demons.Add(demon1);
            Demon demon2 = new Demon(25, 10, DemonType.ZombieMan);
            game.Demons.Add(demon2);
            Demon demon3 = new Demon(30, 15, DemonType.Mancubus);
            game.Demons.Add(demon3);
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
