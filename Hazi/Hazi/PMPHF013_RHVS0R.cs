namespace Hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Numbers = new int[3];
            Numbers[0] = int.Parse(Console.ReadLine());
            Numbers[1] = int.Parse(Console.ReadLine());
            Numbers[2] = int.Parse(Console.ReadLine());
            int res = int.MinValue;
            int abs = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                int absCurrent = Math.Abs(Numbers[i]);
                if (absCurrent > abs || absCurrent == abs && Numbers[i] > res)
                {
                    abs = absCurrent;
                    res = Numbers[i];
                }
            }
            Console.WriteLine(res);
        }
    }
}
