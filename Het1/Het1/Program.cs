namespace het1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Feladat2();
            //Feladat1();
            //Feladat3();
            //feladat4();
            //feladat5();
            //feladat6();
            //feladat78();
            //Feladat9();
            //Feladat10();
            Feladat13();
        }

        private static void Feladat13()
        {
            int V = 100;
            int R1 = 100;
            int R2 = 100;
            double T = 2.5;
            double tel = (R1 + R2) * T;
            Console.WriteLine($"A tartály {tel / V * 100}%-ban lesz tele.");
        }

        private static void Feladat10()
        {

            string[] Szamok = ["Nulla", "Egy", "Kettő", "Három", "Négy", "Öt", "Hat", "Hét", "Nyolc", "Kilenc"];
            Console.Write("Adj meg egy számot 0-9 között: ");
            int szam = int.Parse(Console.ReadLine());
            if (szam >= 0 && szam <= 9)
            {
                Console.WriteLine($"Az általad megadott szám: {Szamok[szam]}");
            }
        }

        private static void Feladat9()
        {
            Console.Write("Add meg az első számot: ");
            int szam1 = int.Parse(Console.ReadLine());
            Console.Write("Add meg a második számot: ");
            int szam2 = int.Parse(Console.ReadLine());
            Console.Write("Add meg a műveletet: ");
            string muv = Console.ReadLine();

            double eredmeny = 0;
            switch (muv)
            {
                case "+":
                    eredmeny = szam1 + szam2;
                    break;
                case "-":
                    eredmeny = szam1 - szam2;
                    break;
                case "/":
                    eredmeny = szam1 / szam2;
                    break;
                case "*":
                    eredmeny = szam1 * szam2;
                    break;
            }
            Console.WriteLine($"{szam1} {muv} {szam2} = {eredmeny}");
        }

        private static void feladat78()
        {
            Console.Write("Add meg a jelszavad: ");
            string jel = Console.ReadLine();
            Console.Write("Add meg a jelszavat mégegyszer: ");
            string jel2 = Console.ReadLine();
            while (jel != jel2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HIBA, A jelszavak nem egyeznek!");
                Console.Write("Add meg a jelszavad: ");
                jel = Console.ReadLine();
                Console.Write("Add meg a jelszavat mégegyszer: ");
                jel2 = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Helyes jelszó!");
        }

        private static void feladat6()
        {
            Console.Write("Adj meg valamennyi másodpercet: ");
            int masod = int.Parse(Console.ReadLine());
            Console.WriteLine($"Formazva: {masod / 60}:{masod % 60:00}");
        }

        private static void feladat5()
        {
            Console.Write("Add meg a magassagod METER-ben: ");
            double magasssag = double.Parse(Console.ReadLine());
            Console.WriteLine("Add meg a sulyod KG-ban: ");
            double suly = double.Parse(Console.ReadLine());
            double BMI = suly / Math.Pow(2, magasssag);
            Console.WriteLine($"A te BMI-d: {BMI:0.00}");
        }

        private static void feladat4()
        {
            Console.Write("Add meg a születési éved: ");
            int szul = int.Parse(Console.ReadLine());
            int kor = DateTime.Now.Year - szul;
            Console.WriteLine($"Te {kor} éves vagy és jövőre {kor + 1} éves leszel");
        }

        private static void Feladat3()
        {
            Console.Write("Add meg a neved: ");
            string nev = Console.ReadLine();
            Console.WriteLine($"Szia {nev}!");
        }

        private static void Feladat2()
        {
            Console.WindowHeight = 900;
            Console.WindowWidth = 900;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        private static void Feladat1()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
