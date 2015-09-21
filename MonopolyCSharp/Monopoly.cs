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
        public int RoundsPlayed { get; private set; }

        // Random seed for the game.
        private Random random;

        public Monopoly(Random random)
        {
            this.random = random;
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

            foreach (Player player in PlayerList)
            {
                player.TurnIndex = TurnRoll();
            }

            // LINQ that orders the players within the list by their turn Index.
            PlayerQueue = new Queue<Player>(PlayerList.OrderBy(x => x.TurnIndex));
        }

        public int TurnRoll()
        {
            return random.Next(1, 13);
        }

        public void Play(int maxRounds)
        {
            RoundsPlayed = 0;
            while (RoundsPlayed < maxRounds)
            {
                foreach (Player player in PlayerQueue)
                {
                    player.Move(TurnRoll());
                    player.UpdateTurnsPlayed();
                }
                RoundsPlayed++;
            }
        }
    }
}
