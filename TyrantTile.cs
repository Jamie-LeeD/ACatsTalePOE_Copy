using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //3Q2.3
    public class TyrantTile : EnemyTile
    {
        public TyrantTile(Position pos, Level l) : base(pos, 15, 5, l) 
        {
        }

        //3Q2.3
        // Override the Display property to return the specific character representing a tyrant
        public override char Display
        {
            get
            {
                if (isDead())
                {
                    return 'X';//if the tyrant is killed this will represent them
                }
                else return '§';
            }
        }

        //This needs alot of work
        public override bool getMove(out Tile tile)
        {
            bool temp = true;
            Tile [,] map = level.Map;
            HeroTile heroTile = level.GetHeroTile();
            int tyrantX, tyrantY, heroX, heroY;
            tyrantX = getX();
            tyrantY = getY();
            heroX = heroTile.getX();
            heroY = heroTile.getY();
            tile = null;
            
            if (heroX < tyrantX && map[tyrantX - 1, tyrantY] is EmptyTile)
            {
                tile = map[tyrantX - 1, tyrantY];
            }
            else
            {
                if (heroX > tyrantX && map[tyrantX + 1, tyrantY] is EmptyTile)
                {
                    tile = map[tyrantX + 1, tyrantY];
                }
                else
                {
                    if(heroY < tyrantY && map[tyrantX, tyrantY - 1] is EmptyTile)
                    {
                        tile = map[tyrantX, tyrantY - 1];
                    }
                    else 
                    {
                        if(heroY > tyrantY && map[tyrantX, tyrantY + 1] is EmptyTile)
                        {
                            tile = map[tyrantX, tyrantY + 1];
                        }
                        else
                        {
                            temp = false;
                        }
                    }
                }
            }
            return temp;
        }

        public override CharacterTile[] GetTarget()
        {
            Tile[,] map = level.Map;

            int width, height, x, y;
            x = getX();
            y = getY();
            width = level.Width;
            height = level.Height;
            List<Tile> tiles = new List<Tile>();

            for (int i = 0; i < width; i++)
            {
                if (map[i, y] is CharacterTile)
                {
                    tiles.Add(map[i, y]);
                }
            }
            tiles.Remove(map[x,y]);
            for (int i = 0; i < height; i++)
            {
                if (map[x, i] is CharacterTile)
                {
                    tiles.Add(map[x, i]);
                }
            }
            tiles.Remove(map[x, y]);

            int size = tiles.Count;
            Tile[] tiles1 = new Tile[size];
            CharacterTile[] characterTile = new CharacterTile[size];
            for (int i = 0;i < size;i++)
            {
                characterTile[i] = (CharacterTile) tiles1[i];
            }
            return characterTile;
        }
    }
}
