using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //2Q4.2
    public class HealthPickupTile : PickupTile
    {
        //Constructor
        public HealthPickupTile(Position pos) : base(pos)
        {

        }

        //Overrides the apply affect to heal the character tile by 10 hp
        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.Heal(10);//restores 10 hp
        }

        //Overrides display to show the tile for a health pickup
        public override char Display
        {
            get { return '♥'; }
        }
    }
}
