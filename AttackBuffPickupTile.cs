﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    [Serializable]
    public class AttackBuffPickupTile : PickupTile
    {
        //3Q3.2
        //Constructor
        public AttackBuffPickupTile(Position pos) : base(pos)
        { }

        //Overrides the apply affect to attack buff to HeroTile
        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.setDoubleDamage(3);
        }

        //Overrides display to show the tile for a Atttack buff pickup
        public override char Display
        {
            get { return '*'; }
        }
    }
}
