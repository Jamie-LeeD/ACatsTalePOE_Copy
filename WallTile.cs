using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q3.1
    // WallTile class inherits from the Tile class and represents a wall tile in the game
    public class WallTile : Tile
    {
        // Constructor for the WallTile, taking a Position object and passing it to the base class 
        public WallTile(Position pos) : base(pos)
        {
        }

        // Override the Display property to return the specific character representing a wall
        public override char Display
        {
            get { return '█'; }
        }
    }
}
