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

        // Random seed for the game.
        private Random random;

        public Monopoly()
        {
            random = new Random();
            BoardSize = 40;

        }

    }
}
