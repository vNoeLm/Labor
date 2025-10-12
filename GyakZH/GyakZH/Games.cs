using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakZH
{
    internal class Games
    {
        public string title;
        public string genre;
        public string publiser;
        public string platfromDate;
        public string originalReleaseDate;

        public Games(string title, string genre, string publiser, string platfromDate, string originalReleaseDate)
        {
            this.title = title;
            this.genre = genre;
            this.publiser = publiser;
            this.platfromDate = platfromDate;
            this.originalReleaseDate = originalReleaseDate;
        }
    }
}
