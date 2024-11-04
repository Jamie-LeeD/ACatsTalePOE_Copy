using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //2Q2.2
    public class GruntTile : EnemyTile
    {
        //Constructor
        public GruntTile(Position pos, int h = 10, int a = 1, Level l) : base(pos, h, a, l)
        {

        }

        //2Q2.2
        // Override the Display property to return the specific character representing a grunt
        public override char Display
        {
            get
            {
                if (isDead())
                {
                    return 'X';//if the grunt is killed this will represent them
                }
                return 'Ϫ';
            }
        }

        //2Q2.2
        //To check the if the grunt can move to that tile
        public override bool getMove(out Tile tile)
        {
            bool clearPath = false;//To return a boolean if the tile is clear to move
            Tile[] vision = getVision();//This will get the vision of tiles around the character
            tile = null;//To get the tile that want to move to
            Random rand = new Random();//random tile for enemy to go to
            int moveTile = rand.Next(0, 4);//random number
            //for loop to check if there are any empty tiles in vision
            for (int i = 0; i < 4; i++)
            {
                if (vision[moveTile] is EmptyTile)//Do only if it has and empty tile
                {
                    clearPath = true;//Return true that path is clear
                    tile = vision[moveTile];//out of tile to move to
                }
            }
            return clearPath;
        }

        //2Q2.2
        //Get array of targets in vision of grunt
        public override CharacterTile[] GetTarget()
        {
            int size = 0;
            Tile[] vision = getVision();//get the vision of the grunt
            CharacterTile[] characterTiles = new CharacterTile[4];//new array to store the characters around grunt
            for (int i = 0; i < 4; i++)
            {
                if (vision[i] is HeroTile)
                {
                    characterTiles[size] = (HeroTile)vision[i];//saves characters in array
                    size++;
                }

            }
            return characterTiles;
        }

    }
}
