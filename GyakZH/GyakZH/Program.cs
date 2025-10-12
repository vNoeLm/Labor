

namespace GyakZH
{
    internal class Program
    {
        static List<string> genreList = new List<string>();
        static List<Games> games = new List<Games>();
        static void Main(string[] args)
        { 
            LoadGenre();
            LoadGames();
            GetGamesByPub();
            getCountPerGenre();
            GetBySameRelease();
        }

        private static void GetBySameRelease()
        {
            List<Games> game = new List<Games>();
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].platfromDate == games[i].originalReleaseDate)
                {
                    game.Add(games[i]);
                }
            }
            Console.WriteLine("---A megjelenés napjától elérhető játékok---");
            for (int i = 0;i < game.Count; i++)
            {
                Console.WriteLine($"A játék címe: {game[i].title} A műfaja: {game[i].genre} és a megjelenési éve: {game[i].originalReleaseDate}");
            }
        }

        private static void getCountPerGenre()
        {
            List<int> count = new List<int>();
            for (int i = 0; i < genreList.Count; i++)
            {
                int c = 0;
                for (int j = 0; j < games.Count; j++)
                {
                    if (genreList[i] == games[j].genre)
                    {
                        c++;
                    }
                }
                count.Add(c);
            }
            for (int i = 0;i < count.Count; i++)
            {
                Console.WriteLine($"A {genreList[i]}-műfajban {count[i]}-db játék van!");
            }
        }

        private static void GetGamesByPub()
        {
            Console.Write("Adj meg egy Kiadót: ");
            string pub = Console.ReadLine().ToLower();
            int db = 0;
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].publiser.ToLower() == pub)
                {
                    db++;
                }
            }
            Console.WriteLine($"A kiadó által kiadott játékok száma: {db}");
        }

        private static void LoadGames()
        {
            FileStream fs = new FileStream("games_dataset.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string firstLine = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] db = line.Split(";");
                string genre = genreList[Convert.ToInt32(db[1])];
                Games g = new Games(db[0], genre, db[2], db[3], db[4]);
                games.Add(g);
            }
            sr.Close();
            fs.Close();
        }

        private static void LoadGenre()
        {
            string lines = File.ReadAllText("genre.txt");
            string[] genres = lines.Split(',');
            foreach (var genre in genres)
            {
                genreList.Add(genre.Split("=")[0]);
            }
        }
    }
}
