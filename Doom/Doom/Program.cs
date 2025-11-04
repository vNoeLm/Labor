



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

            GameItem door = new GameItem(new Position(5, 5),ItemType.Door);
            game.Items.Add(door);
            GameItem levelExit = new GameItem(new Position(2,2), ItemType.LevelExit);
            game.Items.Add(levelExit);

            GameItem ammo = new GameItem(new Position(6,6), ItemType.Ammo);
            game.Items.Add(ammo);

            GameItem Hp = new GameItem(new Position(7,7), ItemType.Medkit);
            game.Items.Add(Hp);

            GameItem waste = new GameItem(new Position(8,8), ItemType.ToxicWaste);
            game.Items.Add(waste);

            GameItem bf = new GameItem(new Position(3, 5), ItemType.BFGCell);
            game.Items.Add(bf);
            Demon demon = new Demon(8,8, DemonType.Imp);
            game.Demons.Add(demon);

            GameItem wall = new GameItem(new Position(6,5), ItemType.Wall);
            game.Items.Add(wall);

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
