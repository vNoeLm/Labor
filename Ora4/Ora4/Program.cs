


namespace Ora4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Feladat2();
            //Feladat3();
            Feladat6();
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
            Console.Write("Adjon meg egy rendszamot: ");
            string plate = Console.ReadLine().Trim().Replace("-", "").Replace(" ", "").ToUpper();
            Console.WriteLine($"{plate[..2]} {plate[2..4]}-{plate[4..]}");
        }

        private static void Feladat2()
        {
            Console.Write("Adj meg egy szoveget: ");
            string text1 = Console.ReadLine().ToLower().Trim().Replace(" ", "");
            string text2 = "";
            for (int i = 0;i < text1.Length;i++)
            {
                text2 += text1[text1.Length - 1 - i];
            }
            if (text1 == text2)
            {
                Console.WriteLine("A megadott szoveg palindrom!");
            }
            else
            {
                Console.WriteLine("A megadott szoveg NEM palindrom!");
            }
        }
    }
}
