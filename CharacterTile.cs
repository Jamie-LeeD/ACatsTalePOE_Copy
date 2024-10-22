using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q4.1
    public abstract class CharacterTile : Tile
    {
        //Fields
        private int hP; //hit points
        private int maxHP;//max hit points
        private int aP;//attack points
        private Tile[] vision;
        public CharacterTile(Position pos, int h, int a) : base(pos)
        {
            hP = h;
            maxHP = h;
            aP = a;

            vision = new Tile[4];
        }

        //2Q3.3
        //Accessors
        public int getHitPoint()
        { return hP; }
        public int getMaxHP()
        { return maxHP; }

        //1Q4.1
        public void UpdateVision(Level lvl)
        {
            int x = getX();
            int y = getY();

            vision[0] = lvl.Map[x, y - 1];
            vision[1] = lvl.Map[x + 1, y];
            vision[2] = lvl.Map[x, y + 1];
            vision[3] = lvl.Map[x - 1, y];
        }

        public void takeDamage(int d)
        {
            if (hP >= 0)
            {
                hP = hP - d;
            }
        }

        public void Attack(CharacterTile c)
        {
            c.takeDamage(aP);
        }

        public bool isDead()
        {
            bool dead;
            if (hP > 0)
            {
                dead = false;
            }
            else
            {
                dead = true;
            }
            return dead;
        }

        //1Q4.3
        public Tile[] getVision()
        {
            return vision;
        }

        //2Q4.2
        public void Heal(int reHP)//Method will add hit points characterTile
        {
            hP = hP + reHP;//add the amount
            if (hP > maxHP)//makes sure does not go over max health
            {
                hP = maxHP;
            }
        }
    }
}
