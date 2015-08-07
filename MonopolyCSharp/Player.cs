using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Player
    {

        public int Location { get; private set; }

        public Player()
        {
            
        }

        public void Move(int v)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(int newLocation)
        {
            Location = newLocation;
        }
    }
}
