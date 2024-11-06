using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    //1Q4.3
    //Enum representing possible movement directions for the hero 
    public enum Direction // (Worachote, 2024)
    {
        Up,
        Right,
        Down,
        Left,
        None
    }

    //1Q5.2
    //Enum representing the current state of the game
    public enum GameState //(DuMez, 2024)
    {
        InProgress,
        Complete,
        GameOver
    }
    public class GameEngine
    {
        private Level currentLvl; //Represents the current level in the game
        private int noOfLvl; //Stores the total number of game's levels
        private Random ranNo; //Generating random numbers for level dimensions
        //Defining minimum and maximum sizes for level dimensions
        public const int MIN_SIZE = 10;
        public const int MAX_SIZE = 20;

        private int noOfCurrentLvl = 1;//Keeps track of the level the player is on
        //1Q5.2
        public GameState gameState = GameState.InProgress; //what state the player is in

        //2Q2.4
        private int noOfGameMove = 0;//To keep track of how many successful moves the player has made

        //2Q3.3
        private String heroStat;//To help retrieve the hero's stats

        //Constructor
        public GameEngine(int l)
        {
            noOfLvl = l;//Sets how many levels the player will play
            ranNo = new Random(); //Random object created to generate random numbers
            int width; // variable storing level's width
            int height; // variable storing level's height
            width = ranNo.Next(MIN_SIZE, MAX_SIZE + 1); //Creating a random width for the level between MIN_SIZE and MAX_SIZE including them
            height = ranNo.Next(MIN_SIZE, MAX_SIZE + 1); //Creating a random height for the level between MIN_SIZE and MAX_SIZE including them
            currentLvl = new Level(width, height, noOfCurrentLvl, 1); //Generating  new Level object with the randomly chosen width and height
        }

        //1Q4.3
        private bool MoveHero(Direction direction) // Method to move hero in the given direction
        {
            bool clearPath = false; //Boolean tracking if the path is clear for movement
            HeroTile hT = currentLvl.GetHeroTile();//Get the HeroTile object from current level
            //hT.UpdateVision(currentLvl);//Updating hero's vision to detect nearby tiles
            currentLvl.UpdateVision();
            Tile[] vis = hT.getVision(); //Getting the array of tiles in hero's vision
            Tile targetTile = null;//Declaring Tile object to store the target tile based on the movement direction

            //Switch statement determining target tile based on the direction
            switch (direction)
            {
                case Direction.Up:
                    targetTile = vis[0]; // Tile above the hero
                    break;
                case Direction.Right:
                    targetTile = vis[1]; // Tile to the right of the hero
                    break;
                case Direction.Down:
                    targetTile = vis[2]; // Tile below the hero
                    break;
                case Direction.Left:
                    targetTile = vis[3]; // Tile to the left of the hero
                    break;
            }
            if (targetTile is PickupTile)//This is to check if the player on a pickup tile
            {
                PickupTile pickupTile = (PickupTile)targetTile;
                clearPath = true;//for return 
                pickupTile.ApplyEffect(hT);//Apply the effect of the tile on the hero
                currentLvl.SwopTiles(hT, pickupTile);//Visually makes the character move along
                currentLvl.makeEmpty(pickupTile);//Mehtod to replace pickup tile with an empty tile
                currentLvl.UpdateVision();//Updates character tiles' visions
                noOfGameMove++; //adds a successful move
            }
            if (targetTile is EmptyTile)// This makes sure the character moves when the path is clear
            {
                clearPath = true;//for the retrun
                currentLvl.SwopTiles(hT, targetTile);//Visually makes the character move along
                currentLvl.UpdateVision();//Update dates the character tiles' visions
                noOfGameMove++;//adds a successful move
            }
            else
            {
                //1Q5.2
                if (targetTile is ExitTile)//For the appropriate action when a character enteracts with the exit
                {
                    //3Q4.3
                    ExitTile exitTile = currentLvl.GetExitTile();
                    if(exitTile.DoorLocked == false)
                    {
                        //1Q5.2
                        if (noOfCurrentLvl != noOfLvl)//makes sure to create a new level if there is still Levels to go
                        {
                            clearPath = true;//for return
                            NextLevel();//Sets up the new map
                        }
                        else
                        {
                            if (noOfCurrentLvl == noOfLvl)//If the character has finished all the levels
                            {
                                clearPath = false;//for return
                                gameState = GameState.Complete;//changes game state
                            }
                        }
                    }
                    
                }
            }

            return clearPath; //Return whether the path is clear
        }

        //1Q4.3
        //Method triggering the hero's movement in a specific direction
        public void TriggerMovement(Direction direction)
        {
            //2Q3.3
            //Guard cluase to make sure game is still in progress
            if (gameState == GameState.InProgress)
            {
                MoveHero(direction); //Call MoveHero to process the movement based on the direction
                if (noOfGameMove > 1)//moves the enemies every second successful move
                {
                    noOfGameMove = 0;
                    MoveEnemies();
                }
            }
        }

        //1Q5.2
        public void NextLevel()//Sets the up a new level
        {
            noOfCurrentLvl++;//To keep track how many levels the end user has completed

            HeroTile heroTile = currentLvl.GetHeroTile();//To get the hero's stats

            ranNo = new Random(); //Random object created to generate random numbers
            int width; // variable storing level's width
            int height; // variable storing level's height
            width = ranNo.Next(MIN_SIZE, MAX_SIZE + 1); //Creating a random width for the level between MIN_SIZE and MAX_SIZE including them
            height = ranNo.Next(MIN_SIZE, MAX_SIZE + 1); //Creating a random height for the level between MIN_SIZE and MAX_SIZE including them
            currentLvl = new Level(width, height, noOfCurrentLvl, 1, heroTile); //Generating  new Level object with the randomly chosen width and height

        }

        //2Q2.4
        private void MoveEnemies() //Moves Enemies
        {
            EnemyTile[] enemyTile = currentLvl.GetEnemyTiles();//gets the array of enemy tiles
            Tile nextTile;//the tile the enemy moves to
            for (int i = 0; i < enemyTile.Length; i++)//repeats dor the length of array
            {
                if (!enemyTile[i].isDead())//checks if the enemy is dead so that it want move if dead
                {
                    if (enemyTile[i].getMove(out nextTile))//chechks the character can move to next Tile
                    {
                        currentLvl.SwopTiles(enemyTile[i], nextTile);//Visually shows move  ment
                        currentLvl.UpdateVision();//Updates the character tiles' visions
                    }
                }
            }
        }

        //2Q3.1
        private bool HeroAttack(Direction direction)//Method to allow the hero to attack enemy tiles
        {
            bool attackTarget = false;//For return if attack was successful
            HeroTile hT = currentLvl.GetHeroTile();//Retrieves the hero tile
            Tile[] vis = hT.getVision();//get the tiles around the hero
            Tile targetTile = null;

            switch (direction)
            {
                case Direction.Up:
                    targetTile = vis[0]; // Tile above the hero
                    break;
                case Direction.Right:
                    targetTile = vis[1]; // Tile to the right of the hero
                    break;
                case Direction.Down:
                    targetTile = vis[2]; // Tile below the hero
                    break;
                case Direction.Left:
                    targetTile = vis[3]; // Tile to the left of the hero
                    break;
            }

            if (targetTile is CharacterTile)//checks if tile is character tile
            {
                hT.Attack((CharacterTile)targetTile);//attacks charactertile
                attackTarget = true;//for return
            }
            currentLvl.UpdateVision();//updates the character tiles' vision
            return attackTarget;
        }
        //2Q3.1
        public void TriggerAttack(Direction direction)//Method for hero attacks
        {
            //2Q3.3
            //Guard cluase to make sure game is still in progress
            if (gameState == GameState.InProgress)
            {
                //2Q3.3
                HeroTile heroTile = currentLvl.GetHeroTile();//Retrieves the hero's info
                //2Q3.2
                if (HeroAttack(direction))//gets the direction the hero is attacking
                {
                    EnemiesAttack();//Enemy attacks back
                    //3Q4.3
                    currentLvl.UpdateExit();
                    //2Q3.3
                    if (heroTile.isDead())//checks if hero is dead
                    {
                        gameState = GameState.GameOver;//To change state to game over
                    }
                }
            }
        }

        //2Q3.2
        //This method might not work the way it is supposed to
        public void EnemiesAttack()//Method for enemy to retaliate
        {
            EnemyTile[] enemyTiles = currentLvl.GetEnemyTiles();//gets array of enemies
            CharacterTile[] characterTile;
            for (int i = 0; i < noOfCurrentLvl; i++) //will repeat for how many enemies there are
            {
                if (!enemyTiles[i].isDead())//checks if the enemy tile is not dead
                {
                    characterTile = enemyTiles[i].GetTarget();
                    for(int j = 0; j < characterTile.Length; j++) 
                    {
                        if (characterTile[j] is CharacterTile)
                        {
                            enemyTiles[i].Attack(characterTile[j]);//Enemy attacks charactertile
                        }
                    }
                    

                }
            }
        }

        //A method to display what Level the player is on
        public String getLevel()
        {
            String temp = "";
            temp = temp + "Level: ";
            temp = temp + noOfCurrentLvl;
            return temp;
        }

        //2Q3.3
        public String getHeroStats()
        {
            String temp = "";
            HeroTile heroTile;
            int hP;
            int maxHP;

            heroTile = currentLvl.GetHeroTile();
            hP = heroTile.getHitPoint();
            maxHP = heroTile.getMaxHP();
            if (hP <=0)
            {
                hP = 0;
            }
            temp = temp + "STATS:\n";
            temp = temp + hP + "/";
            temp = temp + maxHP;

            return temp;
        }

        //Tostring to show what the map looks like for the end user
        public String toString()
        {
            String temp = "";
            temp = temp + currentLvl.ToString();
            //1Q5.2
            //If loop to send a message telling the end user about their game state
            if (gameState == GameState.Complete)// to congradulate the end user
            {
                temp = "Game has been completed.\nWell Done";
            }
            if (gameState == GameState.GameOver)//If the end user failed
            {
                temp = "GAME OVER\nYou Died";
            }
            return temp;
        }
    }
}
