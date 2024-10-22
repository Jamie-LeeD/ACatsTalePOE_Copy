using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q2.2 Tiles class
    public abstract class Tile
    {
        //Fields
        private Position pos;//position

        //Constructor
        public Tile(Position p)
        {
            pos = p;
        }

        //Accessor Methods
        public int getX()
        {
            return pos.getX();
        }
        public int getY()
        {
            return pos.getY();
        }
        public Position GetPosition()
        { return pos; }

        //Mutator Methods
        public void setPosition(Position p)
        {
            pos = p;
        }
        //Abstract Accessor method
        public abstract char Display { get; }
    }
}
