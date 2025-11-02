using System;
using System.Collections.Generic;
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

        public Game()
        {
            this.Player = new Player(0, 0);
            this.Exited = false;
            this.Items = new List<GameItem>();
        }

        private void RenderSingleSprite(ConsoleSprite sprite, Position pos)
        {
            if (pos.PosX < 0 ||
                pos.PosY < 0 ||
                pos.PosX >= Console.WindowWidth || 
                pos.PosY >= Console.WindowHeight)
            {
                return;
            }
            Console.BackgroundColor = sprite.Background;
            Console.ForegroundColor = sprite.ForeGround;
            Console.SetCursorPosition(pos.PosX, pos.PosY);
            Console.WriteLine(sprite.Symbol);
        }

        private void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            for (int i = 0; i < this.Items.Count; i++)
            {
                RenderSingleSprite(this.Items[i].ItemSprite, this.Items[i].ItemPos);
            }
            RenderSingleSprite(this.Player.Sprite, this.Player.Pos);
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
                        List<GameItem> nearbyItems = GetGameItemsWithinDistance(this.Player.Pos, 0.0);
                        foreach (var item in nearbyItems)
                        {
                            item.Interact();
                        }
                        break;
                }

                if (newX >= 0 && newX < Console.WindowWidth &&
                    newY >= 0 && newY < Console.WindowHeight - 1)
                {
                    Move(this.Player, new Position(newX, newY));
                }
            }
        }

        private void CleanUpGameItems()
        {
            List<GameItem> itemsToRemove = new List<GameItem>();
            foreach (var item in this.Items)
            {
                if (!item.Avalaible)
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (var item in itemsToRemove)
            {
                this.Items.Remove(item);
            }
        }

        private List<GameItem> GetGameItemsWithinDistance(Position Pos, double distance)
        {
            List<GameItem> nearbyItems = new List<GameItem>();
            foreach (var item in this.Items)
            {
                double dist = Position.Distance(Pos, item.ItemPos);
                if (dist <= distance)
                {
                    nearbyItems.Add(item);
                }
            }

            return nearbyItems;
        }

        private double GetTotalFillingRatio(Position Pos)
        {
            List<GameItem> items = GetGameItemsWithinDistance(Pos, 0.0);
            double totalFillingRatio = 0.0;
            foreach (var item in items)
            {
                totalFillingRatio += item.FillingRation;
            }
            return totalFillingRatio;
        }

        private void Move(Player player, Position MoveToPos)
        {
            double totalFillingRatio = GetTotalFillingRatio(MoveToPos);
            if (totalFillingRatio + player.FillingRatio <= 1.0)
            {
                player.Pos = MoveToPos;
            }
        }

        private void RenderUI()
        {
            int uiRow = Console.WindowHeight - 1; // UI at bottom of screen
            
            // Save current cursor position and colors
            var originalBg = Console.BackgroundColor;
            var originalFg = Console.ForegroundColor;
            
            // Render HP
            Console.SetCursorPosition(0, uiRow);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP: {Player.HitPoint} ");
            
            // Render Ammo
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"AMMO: {Player.Ammo} ");
            
            // Render BFG Cells if needed
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"BFG: {Player.BFGCells}");
            
            // Restore original colors
            Console.BackgroundColor = originalBg;
            Console.ForegroundColor = originalFg;
        }

        public void Run()
        {
            while (!this.Exited)
            {
                RenderGame();
                RenderUI();
                UserAction();
                CleanUpGameItems();
                Thread.Sleep(25);
            }
        }


    }
}   
