using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q4.2
    public class HeroTile : CharacterTile
    {
        public HeroTile(Position pos) : base(pos, 40, 5)
        {
        }

        public override char Display
        {
            get
            {
                if (isDead())
                {
                    return 'X';
                }
                return '▼';
            }
        }


    }
}
