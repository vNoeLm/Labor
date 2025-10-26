using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora8
{
    internal class Field
    {

        private int size;

        public int TargetX { 
            get
            {
                return size - 1;
            }
        }
        public int TargetY {
            get
            {
                return size - 1;
            }
        }

        public Field(int size)
        {
            this.size = size;
        }

        public bool AllowedPosition(int PosX, int PosY)
        {
            return PosX >= 0 && PosX < size && PosY >= 0 && PosY < size;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("+");
            for (int k = 0; k < size; k++) Console.Write("----");
            Console.WriteLine("+");

            for (int y = 0; y < size; y++)
            {
                Console.Write("|");

                for (int x = 0; x < size; x++)
                {
                    Console.Write("   |");
                }

                Console.WriteLine();

                Console.Write("+");
                for (int k = 0; k < size; k++) Console.Write("----");
                Console.WriteLine("+");
            }
        }
    }
}
