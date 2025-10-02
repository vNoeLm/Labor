using System.Collections.Specialized;

namespace Ora5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Feladat1();
            Feladat2();
        }

        private static void Feladat2()
        {
            DateTime date = DateTime.Now.Date;
            bool On = true;
            while (On)
            {
                Console.Clear();
                int[] Numbers = GenNumbers();
                SaveNumbers(Numbers, date.ToString("yyyy.  MM.  dd."));
                Console.WriteLine($"On {date.ToString("yyyy.  MM.  dd.")} numbers were: {String.Join(",", Numbers)}");
                Console.Write("Another Week?  [y/n] ");
                string input = Console.ReadLine().ToLower();
                while (input != "n" &&  input != "y")
                {
                    Console.Clear();
                    Console.WriteLine("Nem letezo opcio! valasz mast!");
                    Console.Write("Another Week?  [y/n] ");
                    input = Console.ReadLine().ToLower();
                }
                if(input == "n")
                {
                    On = false;
                }
                date = date.AddDays(7);
            }
        }

        private static void SaveNumbers(int[] Numbers, string date)
        {
            StreamWriter sw = new StreamWriter("huzasok.txt", true);
            sw.Write(date + " ");
            foreach (int number in Numbers)
            {
                sw.Write(number + " ");
            }
            sw.WriteLine();
            sw.Close();
        }

        private static int[] GenNumbers()
        {
            int[] Numbers = new int[5];
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int ranNumber = rnd.Next(1, 91);
                do
                {
                    ranNumber = rnd.Next(1, 91);
                }
                while (Numbers.Contains(ranNumber));

                Numbers[i] = ranNumber;
            }

            return Numbers;
        }

        private static void Feladat1()
        {
            StreamReader sr = new StreamReader("szoveg.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string color = line.Split("#")[0];
                var text = line.Split("#");
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                Console.WriteLine(text[1]);
            }
            sr.Close();
        }
    }
}
