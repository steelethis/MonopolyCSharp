using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Player
    {
        // Game object so that Player can get other information from the game.
        private Monopoly game;

        // Location on game board
        public int Location { get; private set; }
        public string Name { get; private set; }

        public Player(Monopoly game, string gamePiece)
        {
            this.game = game;
            Name = gamePiece;
        }

        public void Move(int numberOfSpaces)
        {
            Location += numberOfSpaces;
            if (Location > game.BoardSize)
            {
                Location = Location - game.BoardSize;
            }
        }

        public void UpdateLocation(int newLocation)
        {
            Location = newLocation;
        }
    }
}
