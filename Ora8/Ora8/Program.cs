using static Ora8.Player;

namespace Ora8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team myTeam = new Team();
            while (!myTeam.IsFull())
            {
                Console.Clear();
                Player[] avaPlayers = RandomPlayers(10);
                int index = 1;
                foreach (var player in avaPlayers)
                {
                    Console.WriteLine($"{player.ToString()} {index}");
                    index++;
                }
                Console.WriteLine();
                Console.WriteLine($"Jelenlegi csapat:");
                foreach (var p in myTeam.players)
                {
                    if (p != null)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Valassz egy jatekost a csapatba: ");
                int choice = int.Parse(Console.ReadLine());
                Player selectedPlayer = avaPlayers[choice - 1];
                myTeam.Include(selectedPlayer);
            }
        }

        static Player[] RandomPlayers(int amount)
        {
            Random rnd = new Random();
            string[] names = { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Jana" };
            Position[] positions = (Position[])Enum.GetValues(typeof(Position));
            Player[] genPlayers = new Player[amount];
            for (int i = 0; i < amount; i++)
            {
                string name = names[rnd.Next(names.Length)];
                Position pos = positions[rnd.Next(positions.Length)];
                genPlayers[i] = new Player(name, pos);
            }
            return genPlayers;
        }
    }
}
