using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora8
{
    internal class Team
    {
        public Player[] players = new Player[5];

        private int NumberOfPlayers = 0;

        public bool IsFull()
        {
            return NumberOfPlayers >= 5;
        }

        private bool IsIncluded(Player player)
        {
            return players.Contains(player);
        }

        private bool IsAvalaible(Player player)
        {
            int SamePos = 0;
            foreach (var p in players)
            {
                if (p != null && p.Pos == player.Pos)
                {
                    SamePos++;
                }
            }
            if (player.Pos == Player.Position.Winger)
            {
                return SamePos < 2;
            }
            else
            {
                return SamePos < 1;
            }
        }

        public void Include(Player player)
        {
            if (IsFull())
            {
                Console.WriteLine("Team is full!");
                return;
            }
            
            if (IsIncluded(player))
            {
                Console.WriteLine("Player is already in the team!");
                return;
            }

            if (!IsAvalaible(player))
            {
                Console.WriteLine("Position is already filled!");
                return;
            }
            players[NumberOfPlayers] = player;
            NumberOfPlayers++;
            Console.WriteLine($"Player {player.Name} has been added to theteam.");
        }
    }
}
