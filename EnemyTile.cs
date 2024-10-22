using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //2Q2.1
    public abstract class EnemyTile : CharacterTile
    {
        //Constructor
        public EnemyTile(Position pos, int h, int a) : base(pos, h, a)
        {
        }

        //2Q2.1
        //This will check if the enemy can move to the tile and give the tile
        public abstract bool getMove(out Tile tile);
        //2Q2.1
        //This will see what targets are in the enemy vision 
        public abstract CharacterTile[] GetTarget();

    }
}
