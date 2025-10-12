


namespace Ora4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Feladat2();
            //Feladat3();
            //Feladat6();
            Feladat8();
        }

        private static void Feladat8()
        {
            string s = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";
            int col = 0;
            int row = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString() == ";")
                {
                    col++;
                }
                else if (s[i].ToString() == "\n")
                 {
                    row++;
                }
            }
            string[,] table = new string[col / row, row + 1];
            string[] db = s.Split(';','\n');
            int index = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = db[index];
                    index++;
                }
            }
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write("{0,12}", table[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void Feladat6()
        {
            Random rnd = new Random();
            char[] chars = new char[6];
            string neptun = "";
            int index = 1;
            while (neptun != "rhvs0r")
            {
                neptun = "";
                for (int i = 0; i < chars.Length; i++)
                {
                    if (i == 0)
                    {
                        chars[i] = (char)rnd.Next('a', 'z' + 1);
                    }
                    else if (rnd.Next(0, 11) < 6)
                    {
                        chars[i] = (char)rnd.Next('a', 'z' + 1);
                    }
                    else
                    {
                        chars[i] = (char)rnd.Next('0', '9' + 1);
                    }
                }
                foreach (char c in chars)
                {
                    neptun += c;
                }
                index++;
            }
            Console.WriteLine(neptun.ToUpper());
            Console.WriteLine(index);
        }

        private static void Feladat3()
        {
            string[] Plates = { "aabc 123","a a BC123","a a B c 1 2 3" ,"AABc-123"};
            for (int i = 0; i < Plates.Length; i++)
            {
                string plate = Plates[i].Trim().Replace("-", "").Replace(" ", "").ToUpper();
                Console.WriteLine($"{plate[..2]} {plate[2..4]}-{plate[4..]}");
            }
        }

        private static void Feladat2()
        {
            Console.Write("Adj meg egy szoveget: ");
            string text1 = Console.ReadLine().ToLower().Trim().Replace(" ", "").Replace(".", "");
            string text2 = "";
            for (int i = 0;i < text1.Length;i++)
            {
                text2 += text1[text1.Length - 1 - i];
            }
            Console.WriteLine(text1 == text2 ? "A megadott szoveg palindrom!" : "A megadott szoveg NEM palindrom!");
        }
    }
}
