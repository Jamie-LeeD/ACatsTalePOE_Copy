using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q5.1 
    // ExitTile class inherits from the Tile class and represents an exit tile in the game
    public class ExitTile : Tile
    {
        //Field
        private bool doorLocked;
        // Constructor for the ExitTile, taking a Position object and passing it to the base class 
        public ExitTile(Position pos) : base(pos)
        {
        }

        // Override the Display property to return the specific character representing an exit
        public override char Display
        {
            get 
            { 
                if (doorLocked)
                {
                    return '▓';
                }
                else return '░'; 
            }
        }
    }
}
