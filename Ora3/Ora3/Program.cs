

namespace Ora3
{
    internal class Program
    {
        static string[] Card = new string[52];
        static void Main(string[] args)
        {
            //Feladat1();
            //Feladat2();
            //Feladat3();
            //Feladat5();
            Feladat6();
        }

        private static void Feladat6()
        {
            Console.Write("Add meg mekkora legyen a tomb egyik dimenzioja: ");
            int dim1 = int.Parse(Console.ReadLine());
            Console.Write("Add meg mekkora legyen a tomb masik dimenzioja: ");
            int dim2 = int.Parse(Console.ReadLine());
            int[,] numbers = new int[dim1, dim2];
            int val = 1;
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    numbers[i, j] = val++;
                }
            }
            //Eredeti Matrix
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    Console.Write(numbers[i, j] + " ");
                }
                Console.WriteLine();
            }

            //Tukrozott Matrix
            if (dim1 != dim2)
            {
                int[,] tran = new int[dim2, dim1];
                for (int i = 0; i < dim1; i++)
                {
                    for (int j = 0; j < dim2; j++)
                    {
                        tran[j, i] = numbers[i, j];
                    }
                }
                Console.WriteLine("----Tukorzott-----");
                for (int i = 0; i < dim2; i++)
                {
                    for (int j = 0; j < dim1; j++)
                    {
                        Console.Write(tran[i, j] + "  ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < dim1; i++)
                {
                    for (int j = 1; j < dim2; j++)
                    {
                        (numbers[i, j], numbers[j, i]) = (numbers[j, i], numbers[i, j]);
                    }
                }
                Console.WriteLine("----Tukorzott-----");
                for (int i = 0; i < dim1; i++)
                {
                    for (int j = 0; j < dim2; j++)
                    {
                        Console.Write(numbers[i, j] + "  ");
                    }
                    Console.WriteLine();
                }

            }
        }

        private static void Feladat5()
        {
            List<string> Name = new List<string>();
            List<int> Age = new List<int>();
            List<bool> HasE = new List<bool>();
            while (true)
            {
                Console.Write("Adj meg egy neve: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                Console.Write("Adj meg egy kort: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Add meg van a tapasztalata: ");
                string hase = Console.ReadLine();
                Name.Add(name);
                Age.Add(age);
                HasE.Add(hase == "van" ? true : false);
            }
            double avgAge = 0;
            foreach (int a in Age)
            {
                avgAge += a;
            }
            double avgNoE = 0;
            int has = 0;
            int index = 0;
            int ag = int.MinValue;
            int agIn = 0;
            foreach (int a in Age)
            {
                if (HasE[index] == true)
                {
                    if (Age[index] > ag)
                    {
                        ag = Age[index];
                        agIn = index;
                    }
                    avgNoE += a;
                    index++;
                    has++;
                }
                else
                {
                    index++;
                }
            }
            Console.WriteLine($"Az atlag eletkor: {avgAge / Age.Count}");
            Console.WriteLine($"Az atlag eletkor programozas tapasztalat nelkul: {avgNoE / has}");
            Console.WriteLine($"A legidosebb programozas tudassal rendelkezo szemely: {Age[agIn]} eves es {Name[agIn]} a neve");
        }

        private static void Feladat3()
        {
            //Nem vagom itt mire gondolt a kolto;
            Console.Write("Irj be egy mondatot: ");
            string[] Mondat = Console.ReadLine().Trim().Split(" ");
            Console.Write("Irj be egy szot: ");
            string szo = Console.ReadLine();
            bool van = Mondat.Contains(szo);
            Console.WriteLine(van ? "Benne van" : "Nincs benne");
            if (van)
            {
                int i = 0;
                while (i < Mondat.Length && Mondat[i] != szo)
                {
                    i++;
                }
                Console.WriteLine($"A szo {i}.indexen talalhato");
            }
        }

        private static void Feladat2()
        {
            Random rnd = new Random();
            for (int i = 1; i < Card.Length; i++)
            {
                int random = rnd.Next(i, 52);
                (Card[random], Card[i - 1]) = (Card[i - 1], Card[random]);
            }
        }

        private static void Feladat1()
        {
            string[] Cards = new string[52];
            string[] Colors = ["Kor", "Karo", "Treff", "Pikk"];
            string[] Nums = ["Jumbo", "Dama", "Kiraly", "Asz"];

            int index = 0;
            for (int i = 0; i < Colors.Length; i++)
            {
                for (int j = 2; j <= 10; j++) 
                {
                    Cards[index++] = $"{Colors[i]} {j}";
                }
                for (int j = 0; j < Nums.Length; j++)
                {
                    Cards[index++] = $"{Colors[i]} {Nums[j]}";
                }
            }
            Card = Cards;
        }
    }
}
