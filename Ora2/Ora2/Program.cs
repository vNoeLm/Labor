using System.Drawing;

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
            //Feladat5E();
            //Feladat6();
            //Feladat7();
            //Feladat8E();
            //Feladat9();
            //Feladat10E();
            //Feladat11();
            //Feladat13E();
        }

        private static void Feladat13E()
        {
            Console.Write("Adja meg a kezdo arfolyamot: ");
            double Pt = double.Parse(Console.ReadLine());

            Console.WriteLine("Add meg az R-t: ");
            double R = double.Parse(Console.ReadLine());

            Random rnd = new Random();
            Console.Write("Adja meg hany orat szeretne szimulalni: ");
            int time = int.Parse(Console.ReadLine());
            for (int i = 0; i <= time; i++)
            {
                int a1 = rnd.Next(-100, -1);
                int a2 = rnd.Next(1, 100);
                int Et = rnd.Next(a1, a2);
                Pt = R * Pt + Et;
                Console.WriteLine(Pt);
            }
        }

        private static void Feladat10E()
        {
            Console.Write("Adjon meg egy szamot: ");
            uint number = uint.Parse(Console.ReadLine());
            string ket = "";
            string temp = "";
            while (number >= 1)
            {
                ket += number % 2;
                number = number / 2;
            }
            for (int i = 1; i <= ket.Length; i++)
            {
                temp += ket[ket.Length - i];
            }
            ket = Convert.ToString(temp).PadLeft(32, '0');
            for (int i = 0; i < ket.Length; i++)
            {
                if (i % 8 == 0 && i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(ket[i]);
            }
        }

        private static void Feladat9()
        {
            Console.Write("Adjon meg valamennyi masodpercet: ");
            int sec = int.Parse(Console.ReadLine());
            while (sec > 0)
            {
                Console.Clear();
                Console.WriteLine($"{sec / 60} perc {sec % 60} masodperc");
                sec--;
                Thread.Sleep(1000);
            }
        }

        private static void Feladat8E()
        {
            int number = 9;
            Console.Write("   ");
            for (int i = 1; i <= number; i++)
            {
                Console.Write($"{i,2} "); 
            }
            Console.WriteLine();

            for (int i = 1; i <= number; i++)
            {
                Console.Write($"{i,2} ");
                for (int j = 1; j <= number; j++)
                {
                    Console.Write($"{i * j,2} ");
                }
                Console.WriteLine();
            }

        }

        private static void Feladat7()
        {
            Console.Write("Adj meg egy számot: ");
            int number = int.Parse(Console.ReadLine());
            int sum = number;
            for (int i = 1; i < number; i++)
            {
                sum = sum * (number - i);
            }
            Console.WriteLine(sum);
        }

        private static void Feladat5E()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            Console.Write("Gondoltam egy számra 1 és 100 között. Találd ki!: ");
            int guess = int.Parse(Console.ReadLine());
            while (guess != number)
            {
                if (guess < number)
                {
                    Console.Write("Nagyobb számra gondoltam: ");
                }
                else
                {
                    Console.Write("Kisebb számra gondoltam: ");
                }
                guess = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Eltaláltad a számot!");
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
            Random rnd = new Random();
            int guess = rnd.Next(1, 1001);
            int guessCount = 0;
            while (guess  != number)
            {
                guessCount++;
                guess = rnd.Next(1, 1001);
            }
            Console.WriteLine($"A szám {number} volt.A gép {guessCount} próbálkozásból találta el.");
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
