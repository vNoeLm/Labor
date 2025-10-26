using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora8
{


    internal class Player
    {
        public enum Position
        {
            Goalkeeper,
            Forward,
            Winger,
            Defender
        }
        public string Name { get; }
        public Position Pos { get; }

        public Player(string name, Position pos)
        {
            Name = name;
            Pos = pos;
        }

        public override string ToString()
        {
            return $"{Name} - {Pos}";
        }
    }
}
