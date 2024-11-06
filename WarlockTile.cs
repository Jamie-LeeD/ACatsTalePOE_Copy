using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //3Q2.2
    public class WarlockTile : EnemyTile
    {
        public WarlockTile(Position pos, Level l) : base(pos, 10, 5, l)
        { }

        // Override the Display property to return the specific character representing a Warlock
        public override char Display
        {
            get
            {
                if (isDead())
                {
                    return 'X';//if the Warlock is killed this will represent them
                }
                else return 'ᐂ';
            }
        }

        public override bool getMove(out Tile tile)
        {
            tile = null;
            return false;
        }

        public override CharacterTile[] GetTarget()
        {
            Tile[,] map = level.Map;
            List<Tile> tiles = new List<Tile>();
            int xOrig = getX();
            int yOrig = getY();
            int x, y;
            x = xOrig + 1;
            for (int i = 0; i < 3; i++)
            {
                y = yOrig + 1;
                for (int j = 0; j < 3; j++)
                {
                    if (map[x, y] is CharacterTile)
                    {
                        tiles.Add(map[x, y]);
                    }
                    y--;
                }
                x--;
            }
            tiles.Remove(map[xOrig, yOrig]);
            int size;
            size = tiles.Count;

            Tile[] tiles1 = tiles.ToArray();
            CharacterTile[] characterTiles = new CharacterTile[size];
            for (int i = 0; i < size; i++)
            {
                characterTiles[i] = (CharacterTile)tiles[i];
            }
            return characterTiles;
        }
    }
}
