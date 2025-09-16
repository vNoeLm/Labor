using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat12();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat9();
            Feladat11();
            Feladat120();
            Feladat13();
        }

        private static void Feladat13()
        {
            int V = 10000;
            int R1 = 100;
            int R2 = 100;
            double T3 = 2.5;
            double Amount = (R1 + R2) * T3;
            if (Amount <= V)
            {
                Console.WriteLine($"A tartály {Amount / V * 100}%ban lesz tele");
            }
            else
            {
                Console.WriteLine($"A tartály {Amount - V}m3-rel lesz túltöltve!");
            }
        }

        private static void Feladat120()
        {
            string[] magan = ["a","á","e","é","o","ó","ö","ő","ü","ű","u","ú"];
            Console.Write($"Adj meg egy betűt: ");
            string bet = Console.ReadLine().ToLower();
            if (magan.Contains(bet))
            {
                Console.WriteLine($"A felhasználó magánhangzót adott meg!");
            }
            else
            {
                Console.WriteLine($"A felhasználó mássalhangzót adott meg!");
            }
        }

        private static void Feladat11()
        {
            String[] Numbers = ["Nulla", "Egy", "Kettő", "Három", "Négy", "Öt", "Hat", "Hét", "Nyolc", "Kilenc"];
            Console.Write("Adj meg egy számot 0-9 között: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"A te számod a: {Numbers[num]}");
        }

        private static void Feladat9()
        {
            Console.Write("Add meg az első számot: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Add meg a második számot: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Add meg a muveletet: ");
            string op = Console.ReadLine();
            double ered = 0;
            switch (op)
            {
                case "+":
                    ered = num1 + num2;
                    break;
                case "-":
                    ered = num1 - num2;
                    break;
                case "/":
                    ered = num1 / num2;
                    break;
                case "*":
                    ered = num1 * num2;
                    break;
            }
            Console.WriteLine($"{num1} {op} {num2} = {ered}");
        }

        private static void Feladat7()
        {
            Console.Write($"Add meg a jelszavad: ");
            string pass = Console.ReadLine();
            Console.Write("Add meg a jelszót mégegyszer: ");
            string pass2 = Console.ReadLine();
            while (pass != pass2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Hiba Probald ujra");
                Console.ResetColor();
                Console.Write($"Add meg a jelszavad: ");
                pass = Console.ReadLine();
                Console.Write("Add meg a jelszót mégegyszer: ");
                pass2 = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Helyes jelszo");
            Console.ResetColor();
        }

        private static void Feladat6()
        {
            Console.Write("Adj meg valamennyi másodpercet: ");
            int sec = int.Parse(Console.ReadLine());
            Console.WriteLine($"Az időtartam formázva: {sec / 60}:{sec % 60:00}");
        }

        private static void Feladat5()
        {
            Console.Write("Add meg a magasságodat méterben: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Add meg a sulyodat kg ban: ");
            double weight = double.Parse(Console.ReadLine());
            double BMI = weight / Math.Pow(2, height);
            Console.WriteLine($"A te BMI-d {BMI}");
        }

        private static void Feladat4()
        {
            Console.Write("Add meg születési éved: ");
            int birth = int.Parse(Console.ReadLine());
            int age = DateTime.Now.Year - birth;
            Console.WriteLine($"Te most {age} éves vagy és jövőre {age + 1} éves leszel!");

        }

        private static void Feladat3()
        {
            Console.Write("Add meg a neved: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Szia {name}");
        }

        private static void Feladat12()
        {
            Console.WindowHeight = 1000;
            Console.WindowWidth = 1000;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello, World!");
            Console.ResetColor();
        }
    }
}
