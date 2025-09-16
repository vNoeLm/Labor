namespace Ora2
{
    internal class Program
    {
        static int number;
        static void Main(string[] args)
        {
            //Feladat1();
            //Feladat2();
            //Feladat3E();
            //Feladat4();
            //Feladat6();
            Feladat11();
        }

        private static void Feladat11()
        {
            Console.CursorVisible = false;
            var rnd = new Random();
            int credit = 100;
            int bet = 1;

            while (true)
            {
                if (bet < 1)
                {
                    bet = 1;
                }
                if (bet > credit)
                {
                    bet = credit;
                }
                Console.Clear();
                Console.WriteLine("Félkarú Rabló!");
                Console.WriteLine("____________________");
                Console.WriteLine($"Kredit {credit}");
                Console.WriteLine($"Tét {bet}");
                Console.WriteLine();
                Console.WriteLine("[Up / Down] tét állitása, [Space] pörgetés, [Esc] kilépés");
                if (credit <= 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over");
                    Console.ResetColor();
                }

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (credit > 0)
                    {
                        bet++;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (bet > 0)
                    {
                        bet--;
                    }
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (bet > credit)
                    {
                        continue;
                    }
                    credit -= bet;
                    int a = rnd.Next(10);
                    int b = rnd.Next(10);
                    int c = rnd.Next(10);

                    int win = 0;
                    if (a == b || b == c || a == c)
                    {
                        win = bet * 10;
                    }
                    else if (a == b && b == c)
                    {
                        win = bet * 50;
                    }

                    credit += win;
                    Console.Clear();
                    Console.WriteLine($"Pörgetés: {a} {b} {c}");
                    Console.WriteLine("Félkarú Rabló!");
                    Console.WriteLine("____________________");
                    Console.WriteLine($"Kredit {credit}");
                    Console.WriteLine($"Tét {bet}");
                    Console.WriteLine($"Nyeremény: {win}");

                    Console.ReadKey();
                }
            }   
        }

        private static void Feladat6()
        {
            Console.WriteLine("Adj meg egy szamot: ");
            int num = int.Parse(Console.ReadLine());
            bool even = num % 2 == 0;
            int oszt = 0;

            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0)
                {
                    oszt++;
                }
            }
            bool ossze = oszt > 0;
            Console.WriteLine("A megadott szám {0} is {1} number. \nAz osztok száma {2}És ez egy {3}", num, even ? "Páros" : "Páratlan", oszt, ossze ? "Igen" : "Nem");
        }

        private static void Feladat4()
        {
            Console.Write("Hány játékos van?: ");
            int players = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int starter = int.MinValue;
            while (starter == int.MinValue)
            {
                for (int i = 1; i <= players; i++)
                {
                    Console.WriteLine($"Játékos {i} nyomj egy enter-t a dobáshoz!");
                    Console.ReadLine();

                    int dob = rnd.Next(1,7);
                    Console.WriteLine($"Játékos {i} dobása {dob}");
                    if (dob == 6)
                    {
                        starter = i;
                        break;
                    }
                }
            }
            Console.WriteLine($"A kezdo jatekos {starter}");
        }

        private static void Feladat3E()
        {
            Console.WriteLine($"asd{number}");
        }

        private static void Feladat2()
        {
            string pass = "Password";
            string passIn = "";
            int prob = 0;
            do
            {
                Console.WriteLine("Add meg a jelszót: ");
                passIn = Console.ReadLine();
                prob++;
            }
            while (passIn != pass && prob < 3);
            if (prob == 3)
            {
                Console.WriteLine("tul sok hibas probalkozas");
            }
            else
            {
                Console.WriteLine("Helyes jelszo");
            }

        }

        private static void Feladat1()
        {
            Console.Write("Adj meg egy számot: ");
            int num = int.Parse(Console.ReadLine());
            number = num;
            for (int i = 0; i < num; i += 2)
            {
                    Console.WriteLine(i);
            }
        }
    }
}
