using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class Player
    {
        public Position Pos { get; set; }
        public ConsoleSprite Sprite { get; set; }
        public double FillingRatio { get; set; }
        public static int Ammo { get; set; }
        public static int HitPoint { get; set; }
        public static int BFGCells { get; set; }

        public Player(int PosX, int PosY)
        {
            this.Pos = new Position(PosX, PosY);
            this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            this.FillingRatio = 0.4;
            Player.Ammo = 10;
            Player.HitPoint = 100;
            Player.BFGCells = 2;
        }
    }
}
