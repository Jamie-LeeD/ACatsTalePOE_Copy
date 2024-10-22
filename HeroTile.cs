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
        public HeroTile(Position pos, int h = 40, int a = 5) : base(pos, h, a)
        {
            //h = 40;
            //a = 5;
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
