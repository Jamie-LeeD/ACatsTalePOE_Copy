using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //Ques 2.1 Position Class
    public class Position
    {
        //Fields
        private int xPos;//X position
        private int yPos;//Y position

        //Constructor
        public Position(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        //Accesor Methods
        public int getX() //Exposes the X coordinate
        { return xPos; }
        public int getY() //Exposes the y coordinate
        { return yPos;}

        //Mutator Methods
        public void setX(int x) //Changes the x coordinate
        {  xPos = x; }
        public void setY(int y) //Changes thr y coordinate
        {  yPos = y; }
    }
}
