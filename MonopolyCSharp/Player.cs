using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Player
    {
        public int turnIndex { get; set; }
        public Property Location { get; set; }
        public string Name { get; private set; }

        public Player(string name, Property startingPlace)
        {
            Name = name;

            Location = startingPlace;
        }

    }
}
