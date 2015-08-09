using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Monopoly
    {
        public int BoardSize { get; private set; }
        public Queue<Player> PlayerQueue { get; private set; }
        public List<Player> PlayerList { get; private set; }

        // Random seed for the game.
        private Random random;

        public Monopoly()
        {
            random = new Random();
            BoardSize = 40;
        }

        public void CreatePlayers(List<string> players)
        {
            PlayerList = new List<Player>();

            if (players.Count < 2 || players.Count > 8)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (string player in players)
            {
                PlayerList.Add(new Player(this, player));
            }
        }

        public void CreatePlayerOrder()
        {
            PlayerQueue = new Queue<Player>();

            Dictionary<Player, int> playerRolls = new Dictionary<Player, int>();

            foreach(Player player in PlayerList)
            {
                playerRolls.Add(player, RollDice());
            }

            // TODO: Sort players by their roll and put them in a queue in that order.

        }

        public int RollDice()
        {
            return random.Next(1, 13);
        }
    }
}
