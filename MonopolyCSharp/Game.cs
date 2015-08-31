using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Game
    {
        private Random random;

        public const int STARTING_LOCATION = 0;
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 8;
        public const int MAX_DICE_ROLL = 12;

        public Dictionary<int, Player> Players { get; private set; }
        public Dictionary<int, Property> GameBoard { get; private set; }
        public List<Player> PlayerOrderList { get; private set; }

        public Game(Random random)
        {
            this.random = random;

            Players = new Dictionary<int, Player>();
            GameBoard = new Dictionary<int, Property>();
            PlayerOrderList = new List<Player>();
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 40; i++)
            {
                GameBoard[i] = new Property(i, $"Space {i}");
            }
        }

        public void CreatePlayer(int playerID, string playerName)
        {
            Players[playerID] = new Player(playerName, GameBoard[STARTING_LOCATION]);
        }

        public void MovePlayer(Player player, int roll)
        {
            int newLocation = player.Location.PropertyID + roll;

            // If the new location is greater than the max board size
            // Subtract the max board size from the location.
            // Otherwise, leave it alone.
            newLocation = newLocation >= GameBoard.Count ? 
                newLocation - GameBoard.Count : newLocation;
            player.Location = GameBoard[newLocation];
        }

        public bool Start()
        {
            if(Players.Count < MIN_PLAYERS || Players.Count > MAX_PLAYERS)
                return false;

            return true;
        }

        public void DeterminePlayerOrder()
        {
            foreach (var player in Players)
            {
                int roll = RollDice();

                player.Value.turnIndex = roll;

                PlayerOrderList.Add(player.Value);
            }

            PlayerOrderList = PlayerOrderList.OrderByDescending(i => i.turnIndex).ToList();
        }

        public int RollDice()
        {
            return random.Next(1, MAX_DICE_ROLL + 1);
        }
    }
}
