using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    [Serializable]
    //1Q2.3
    public class EmptyTile : Tile//extends from parent class
    {
        //Constructor that passes the position to base class
        public EmptyTile(Position pos) : base(pos)
        {
        }

        //Override the Display property to return "."
        public override char Display
        {
            get { return '.'; }
        }

    }
}
