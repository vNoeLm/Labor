using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class Game
    {
        public Player Player { get; }
        public bool Exited { get; set; }

        public List<GameItem> Items { get; set; }
        public List<Demon> Demons { get; set; }

        public ConsoleRenderer Renderer { get; set; }
        public GameLogic Logic { get; set; }

        public Stopwatch StopWatchLogic { get; set; }
        public Stopwatch StopWatchRenderer { get; set; }

        public Game()
        {
            this.Player = new Player(0, 0);
            this.Exited = false;
            this.Items = new List<GameItem>();
            this.Demons = new List<Demon>();
            this.Renderer = new ConsoleRenderer(this);
            this.Logic = new GameLogic(this);
            this.StopWatchLogic = new Stopwatch();
            this.StopWatchRenderer = new Stopwatch();
        }

        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int newX = this.Player.Pos.PosX;
                int newY = this.Player.Pos.PosY;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        this.Exited = true;
                        break;
                    case ConsoleKey.W:
                        newY -= 1;
                        break;
                    case ConsoleKey.S:
                        newY += 1;
                        break;
                    case ConsoleKey.A:
                        newX -= 1;
                        break;
                    case ConsoleKey.D:
                        newX += 1;
                        break;
                    case ConsoleKey.E:
                        Logic.PlayerDirectInteractionLogic(Player.Pos);
                        break;
                    case ConsoleKey.F:
                        Logic.PlayerAttackLogic();
                        break;
                }

                if (newX >= 0 && newX < Console.WindowWidth &&
                    newY >= 0 && newY < Console.WindowHeight - 1)
                {
                    Logic.Move(this.Player, new Position(newX, newY));
                    Logic.PlayerIndirectInteractionLogic(Player.Pos);
                }
            }
            
        }


        private void RenderUI()
        {
            int uiRow = Console.WindowHeight - 1;
            
            Console.SetCursorPosition(0, uiRow);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP: {Player.HitPoint} ");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"AMMO: {Player.Ammo} ");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"BFG: {Player.BfgCell}");
            
        }

        public void Run()
        {
            while (!this.Exited && this.Player.Alive)
            {
                StopWatchLogic.Start();
                StopWatchRenderer.Start();
                if (StopWatchLogic.ElapsedMilliseconds > 500)
                {
                    Logic.UpdateGameState();
                    StopWatchLogic.Restart();
                }
                if (StopWatchRenderer.ElapsedMilliseconds > 25)
                {
                    Renderer.RenderGame();
                    RenderUI();
                    UserAction();
                    StopWatchRenderer.Restart();
                }
            }
        }


    }
}   
