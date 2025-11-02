using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Position(int PosX,int posY)
        {
            this.PosX = PosX;
            this.PosY = posY;
        }

        public static Position Add(Position First, Position Second)
        {
            return new Position(First.PosX + Second.PosX, First.PosY + Second.PosY);
        }

        public static double Distance(Position First, Position Second)
        {
            return Math.Sqrt(Math.Pow(First.PosX - Second.PosX, 2) + Math.Pow(First.PosY - Second.PosY, 2));
        }
    }
}
