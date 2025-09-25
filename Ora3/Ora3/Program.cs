

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
            //Feladat6();
            //Feladat8();
            //Feladat9();
            //Feladat10();
            //Feladat11();
;
        }

        private static void Feladat11()
        {
            Console.WriteLine("Add meg a matrix egyik meretet: ");
            int dim1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Add meg a matrix masik meretet: ");
            int dim2 = int.Parse(Console.ReadLine());
            int[,] Matrix = new int[dim1, dim2];
            int index = 1;
            //Eredeti
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    Matrix[i, j] = index++;
                }
            }
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    Console.Write("{0,3}",Matrix[i,j]);
                }
                Console.WriteLine();
            }
            //Rotated
            Console.Write("Add meg hányszor legyen elforgatva a mátrix: ");
            int rotate = int.Parse(Console.ReadLine()) % 4;
            Console.WriteLine("---Rotated---");
            //csak ha n * n mert bena vagyok
            int[,] Rotated = new int[dim2, dim1];
            for(int k = 1; k <= rotate; k++)
            {
                for (int i = 0; i < dim2; i++)
                {
                    for (int j = 0; j < dim1; j++)
                    {
                        Rotated[j, dim1 - 1 - i] = Matrix[i, j];
                    }
                }
                Matrix = Rotated;
                Rotated = new int[dim2, dim1];
            }
            for (int i = 0; i < dim2; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    Console.Write("{0,3}", Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Feladat10()
        {
            List<int> Numbers = new List<int>();
            List<int> Other = new List<int>();
            Console.WriteLine("Add meg milyen hosszu legyen a lista: ");
            int len = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                Numbers.Add(rnd.Next(1, 100));
            }
            for (int i = 0; i < Numbers.Count; i += 2)
            {
                Other.Add(Numbers[i]);
            }
            foreach (int i in Other)
            {
                Console.Write("{0,4}",i);
            }
            Console.WriteLine();
            for (int i = 0; i < Other.Count / 2; i++)
            {
                (Other[i], Other[Other.Count - i - 1]) = (Other[Other.Count - i - 1], Other[i]);
            }
            Console.WriteLine();
            foreach (int i in Other)
            {
                Console.Write("{0,4}", i);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int[,] Matrix;
            int k = 1;
            while (k * k < Other.Count)
            {
                k++;
            }
            Matrix = new int[k, k];
            int index = 0;
            for (int i = 0; i < k; i++ )
            {
                for (int j = 0; j < k; j++)
                {
                    if (index < Other.Count)
                    {
                        Matrix[i, j] = Other[index++];
                    }
                    else
                    {
                        Matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write("{0,4}", Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Feladat9()
        {
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < x.Length / 2; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i - 1] = tmp;
            }

            foreach (var i in x)
            {
                Console.WriteLine(i);
            }
        }

        private static void Feladat8()
        {
            List<int> Numbers = new List<int>();
            Console.WriteLine("Adjon meg egy egesz szamot: ");
            int num = int.Parse(Console.ReadLine());
            Numbers.Add(num);
            while(num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                    Numbers.Add(num);
                }
                else
                {
                    num = num * 3 + 1;
                    Numbers.Add(num);
                }
            }
            foreach(var n in Numbers)
            {
                Console.Write(n + " | ");
            }
        }

        private static void Feladat6()
        {
            Console.Write("Add meg mekkora legyen a tomb egyik merete: ");
            int dim1 = int.Parse(Console.ReadLine());
            Console.Write("Add meg mekkora legyen a tomb masik merete: ");
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
                    Console.Write("{0,3}",numbers[i, j]);
                }
                Console.WriteLine();
            }

            //Transformalt Matrix
            int[,] tran;
            tran = new int[dim2, dim1];
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    tran[j, i] = numbers[i, j];
                }
            }

            Console.WriteLine("------Transformalt------");
            for (int i = 0; i < tran.GetLength(0); i++)
            {
                for (int j = 0; j < tran.GetLength(1); j++)
                {
                    Console.Write("{0,3}",tran[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Feladat5()
        {
            List<string> Name = new List<string>();
            List<int> Age = new List<int>();
            List<bool> HasE = new List<bool>();
            bool inp = true;
            while (inp)
            {
                Console.Write("Adj meg egy neve: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    inp = false;
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
