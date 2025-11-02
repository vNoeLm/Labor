using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class ConsoleSprite
    {
        public ConsoleColor Background { get; set; }
        public ConsoleColor ForeGround { get; set; }
        public char Symbol { get; set; }

        public ConsoleSprite(ConsoleColor Background, ConsoleColor ForeGround, char Symbol)
        {
            this.Background = Background;
            this.ForeGround = ForeGround;
            this.Symbol = Symbol;
        }
    }
}
