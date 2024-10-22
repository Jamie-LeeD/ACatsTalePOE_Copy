using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACatsTalePOE
{
    // 1Q2.4 Creating level class
    public class Level
    {
        //Fields
        private Tile[,] map;
        private int width;
        private int height;
        //1Q4.2
        private HeroTile heroTile;
        //1Q5.1
        private ExitTile exitTile;
        //2Q2.3
        private EnemyTile[] enemyTiles;
        //2Q4.3
        private PickupTile[] pickupTiles;

        //Constructor 
        public Level(int w, int h, int noOfEnemy, int noOfPickup, HeroTile ht = null)
        {
            width = w; // constructor accepting int parameters for width
            height = h; //constructor accepting int parameters for height
            map = new Tile[width, height]; // Array for map dimensions 
            InitialiseTiles();//Used to fill the array

            //2Q2.3
            enemyTiles = new EnemyTile[noOfEnemy];//Array of enemies
            //2Q2.4
            pickupTiles = new PickupTile[noOfEnemy];//Array of pickups

            //1Q4.2
            Position pos;
            pos = getRandomEmptyPosition(); //Getting a random empty position on map
            //Check if the hero tile (ht) is null - this means the hero has not been placed as yet
            if (ht == null)
            {
                CreateTile(TileType.Hero, pos); //New tile of type Hero at the random position
                heroTile = new HeroTile(pos);// New hero tile and random position
            }
            else
            {
                heroTile = ht;//uses stats from previous level
                heroTile.setPosition(pos);//put the tile at a new random position
            }

            map[pos.getX(), pos.getY()] = heroTile; // Placed the hero tile on the map at the given x and y coordinates

            //1Q5.1
            pos = getRandomEmptyPosition(); //Finding a random empty position on the map to exit
            exitTile = new ExitTile(pos); // New ExitTile at the random position
            CreateTile(TileType.Exit, pos); //new tile of type exit at the same position

            //2Q2.3
            for (int i = 0; i < noOfEnemy; i++)//Creates the number of Enemies specified
            {
                pos = getRandomEmptyPosition();//Finding a random empty position on the map for enemies
                enemyTiles[i] = new GruntTile(pos);// New Grunt at the random position
                CreateTile(TileType.Enemy, pos);//new tile of type grunt at the same position
            }


            //2Q4.3
            for (int i = 0; i < noOfPickup; i++)//Creates the number of pickups specified
            {
                pos = getRandomEmptyPosition();//Finding a random empty position on the map for pickups
                CreateTile(TileType.Pickup, pos);// new tile of type healthat the same position
                pickupTiles[i] = new HealthPickupTile(pos);// New Health at the random position
            }
        }
        //Accessor Methods
        public int Width
        {
            get { return width; } // returns object width
        }
        public int Height
        {
            get { return height; } // returns objects height
        }

        //1Q4.1
        //Accessor Method
        public Tile[,] Map //Property to access the map 2D array of Tile objects
        { get { return map; } } //returns entire map grid


        public HeroTile GetHeroTile() // Method to get hero tile on the map
        { return heroTile; } //returns current hero tile object

        //1Q5.1
        //Accessor Method to get the exit tile on the map
        public ExitTile GetExitTile()
        { return exitTile; } //returns current ExitTile object

        //2Q2.3
        //Accessor Method to get the EnemyTiles on the map
        public EnemyTile[] GetEnemyTiles()//Method to get EnemyTile array
        { return enemyTiles; }//returns EnemyTile Array

        //2Q4.3
        //Accessor Method to get the Pickup Tiles on the map
        public PickupTile[] GetPickupTiles() //Method to get PickupTile array
        { return pickupTiles; }//returns PickupTile Array

        public enum TileType //Enumeration to represent the different types of tiles on the map // (Stack Overflow, 2024)
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy,
            Pickup
        }

        // Method to make a tile based on the TileType and put it at the specified position
        private Tile CreateTile(TileType type, Position pos)
        {
            Tile tempTile = null; // Temporary variable to hold new tile
            // Determine tile type and create the appropriate tile object
            switch (type)
            {
                case TileType.Empty:
                    tempTile = new EmptyTile(pos); //Creates an EmptyTile
                    break;
                case TileType.Wall:
                    tempTile = new WallTile(pos); //Creates a WallTile
                    break;
                case TileType.Hero:
                    tempTile = new HeroTile(pos, 40, 5);  //Creates a HeroTile with health and attack power
                    break;
                case TileType.Exit:
                    tempTile = new ExitTile(pos); //Creates an ExitTile
                    break;
                case TileType.Enemy:
                    tempTile = new GruntTile(pos, 10, 1); //Creates an GruntTile,
                    break;
                case TileType.Pickup:
                    tempTile = new HealthPickupTile(pos);//Creates a HealthPickupTile
                    break;
            }

            // If a valid tile was created, put it on the map at the specified position
            if (tempTile != null)
            {
                map[pos.getX(), pos.getY()] = tempTile; //assigning tile to grid map
            }
            return tempTile;
        }

        //Overloaded method
        private Tile CreateTile(TileType type, int x, int y)
        {
            Position pos = new Position(x, y);
            Tile tempTile = null; // Temporary variable to hold new tile
            // Determine tile type and create the appropriate tile object
            switch (type)
            {
                case TileType.Empty:
                    tempTile = new EmptyTile(pos); //Creates an EmptyTile
                    break;
                case TileType.Wall:
                    tempTile = new WallTile(pos); //Creates a WallTile
                    break;
                case TileType.Hero:
                    tempTile = new HeroTile(pos, 40, 5);  //Creates a HeroTile with health and attack power
                    break;
                case TileType.Exit:
                    tempTile = new ExitTile(pos); //Creates an ExitTile
                    break;
                case TileType.Enemy:
                    tempTile = new GruntTile(pos, 10, 1); //Creates an GruntTile,
                    break;
                case TileType.Pickup:
                    tempTile = new HealthPickupTile(pos);//Creates a HealthPickupTile
                    break;
            }

            // If a valid tile was created, put it on the map at the specified position
            if (tempTile != null)
            {
                map[pos.getX(), pos.getY()] = tempTile; //assigning tile to grid map
            }
            return tempTile;
        }

        private void InitialiseTiles()
        {
            //1Q3.2
            //Loop making vertical walls on the left and right sides of the grid
            for (int i = 0; i < height; i++)
            {
                Position pos = new Position(0, i); //Creating a wall tile at the left edge of each vertical position
                CreateTile(TileType.Wall, pos);
                pos = new Position(width - 1, i); //Making a wall tile at the right edge of each vertical position
                CreateTile(TileType.Wall, pos);
            }
            //Loop making horizontal walls on top and bottom sides of grid
            for (int i = 0; i < width; i++)
            {
                Position pos = new Position(i, 0); //Generating a wall tile at the top edge at each horizontal position
                CreateTile(TileType.Wall, pos);
                pos = new Position(i, height - 1); //Generating a wall tile at the bottom edge at each horizontal position
                CreateTile(TileType.Wall, pos);
            }
            //Loop filling interior of the grid with empty tiles - excluding the borders
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    Position pos = new Position(x, y); // Generating an empty tile at each interior position - excluding the walls
                    CreateTile(TileType.Empty, pos);
                }
            }
        }

        // Method returning a random empty position on map
        //1Q4.2
        private Position getRandomEmptyPosition()
        {
            Random random = new Random();//New instance of Random for generating random numbers
            //Initializing xPos and yPos with starting values, though they will be updated in the loop
            int xPos = 1;
            int yPos = 1;
            char c = '█'; //Variable storing the current tile's display character, initialized as a wall character

            // Loop until a random empty tile is found
            while (c != '.')
            {
                // Generating random x and y positions within map boundaries
                xPos = random.Next(0, width - 1);
                yPos = random.Next(0, height - 1);

                c = map[xPos, yPos].Display; //Placing display character at the randomly selected position
            }

            //Once an empty tile is found, create and return a position object with the coordinates
            Position position = new Position(xPos, yPos);
            return position;
        }

        //1Q4.3
        public void SwopTiles(Tile tile1, Tile tile2)
        {
            Position posT1;//To keep the position of the first tile
            Position posT2;//To keep the position of the second tile

            //geting positions
            posT1 = tile1.GetPosition();
            posT2 = tile2.GetPosition();

            //swaping positions
            tile1.setPosition(posT2);
            tile2.setPosition(posT1);

            //Placing tiles
            map[tile1.getX(), tile1.getY()] = tile1;
            map[tile2.getX(), tile2.getY()] = tile2;
        }

        //Method for pickup tiles to replace them with empty tiles when used
        public void makeEmpty(Tile tile)
        {
            Position position;
            position = tile.GetPosition();//get the tiles position
            EmptyTile emptyTile = new EmptyTile(position);//creates a new empty tile
            CreateTile(TileType.Empty, position);//creates an empty tile
        }

        //2Q2.3
        public void UpdateVision()//To update the hero and all the enemies vision
        {
            heroTile.UpdateVision(this);//will update the hero's vision
            for (int i = 0; i < enemyTiles.Length; i++)//Cycles through all the enemies
            {
                enemyTiles[i].UpdateVision(this);//will update the enemies vision
            }
        }

        //1Q4.3
        //Override ToString to provide visual representation of the level
        public override String ToString()
        {

            String temp = ""; //Temporary String that will hold the visual of the level
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    temp = temp + map[x, y].Display; //Saves the the character in each positions into the string
                }
                temp = temp + "\n"; //Adding a new line
            }
            return temp; //Return the level's complete string representation
        }
    }
}

