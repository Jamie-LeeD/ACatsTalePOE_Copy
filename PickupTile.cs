using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    [Serializable]
    //2Q4.1
    public abstract class PickupTile : Tile
    {
        //Constructor
        public PickupTile(Position pos) : base(pos)
        { }
        //Method used to apply the affect of the pickup tile
        public abstract void ApplyEffect(CharacterTile characterTile);
    }
}
