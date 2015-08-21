using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCSharp
{
    public class Property
    {
        public int PropertyID { get; private set; }
        public string PropertyName { get; private set; }

        public Property(int id, string name)
        {
            PropertyID = id;
            PropertyName = name;
        }
    }
}
