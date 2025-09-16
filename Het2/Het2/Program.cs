

namespace Het2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
        }

        private static void Feladat2()
        {
            string jel = "Jelszó";
            int proba = 1;
            Console.Write("Add meg a jelszavad: ");
            string pass = Console.ReadLine();
            while (pass != jel)
            {
                if (proba == 3)
                {
                    Console.WriteLine("Tul sok Hibás próbálkozás!");
                    break;
                }
                else
                {
                    Console.WriteLine("Hibas jelszo");
                    Console.Write("Add meg a jelszavad: ");
                    pass = Console.ReadLine();
                    proba++;
                }
            }
            
        }

        private static void Feladat1()
        {
            Console.Write("Adj meg egy számot: ");
            int szam = int.Parse(Console.ReadLine());
            for (int i = 0; i < szam; i += 2)
            {
                    Console.WriteLine(i);
            }
        }
    }
}
