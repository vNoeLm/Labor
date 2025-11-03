using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    enum ItemType { Ammo, BFGCell, Door, LevelExit, Medkit, ToxicWaste, Wall}
    internal class GameItem
    {
        public Position ItemPos { get; set; }
        public ConsoleSprite ItemSprite { get; set; }
        public ItemType Type { get; set; }
        public double FillingRation { get; set; }
        public bool Avalaible { get; set; }

        private void SetInitialProperties()
        {
            switch (this.Type)
            {
                case ItemType.Ammo:
                    this.FillingRation = 0.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Yellow, 'A');
                    break;
                case ItemType.BFGCell:
                    this.FillingRation = 0.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
                    break;
                case ItemType.Door:
                    this.FillingRation = 1.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/'); 
                    break;
                case ItemType.LevelExit:
                    this.FillingRation = 1.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.Black, 'E'); 
                    break;
                case ItemType.Medkit:
                    this.FillingRation = 0.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+'); 
                    break;
                case ItemType.ToxicWaste:
                    this.FillingRation = 0.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.Yellow, ':'); 
                    break;
                case ItemType.Wall:
                    this.FillingRation = 1.0;
                    this.ItemSprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkGray, ' ');
                    break;
            }
        }

        public GameItem(Position itemPos, ItemType type)
        {
            this.ItemPos = itemPos;
            this.Type = type;
            SetInitialProperties();
            this.Avalaible = true;
        }

        public void Interact(Player player)
        {
            switch (this.Type)
            {
                case ItemType.Ammo:
                    this.Avalaible = false;
                    player.Ammo += 5;
                    break;
                case ItemType.BFGCell:
                    this.Avalaible = false;
                    player.BFGCells += 1;
                    break;
                case ItemType.Door:
                    if (FillingRation == 1.0)
                    {
                        this.FillingRation = 0.0;
                        this.ItemSprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkYellow, '|');
                    }
                    else
                    {
                        this.FillingRation = 1.0;
                        this.ItemSprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/');
                    }
                    break;
                case ItemType.Medkit:
                    this.Avalaible = false;
                    player.HitPoint += 10;
                    break;
            }
        }
    }
}
