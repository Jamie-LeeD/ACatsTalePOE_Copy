using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACatsTalePOE
{
    //handles the game display and user input
    public partial class fCatTale : Form
    {
        private GameEngine gameEngine; //Game engine instance responsible for game logic

        //Constructor for the form
        public fCatTale()
        {
            gameEngine = new GameEngine(10);  //Initializing the game engine with a size of 10
            InitializeComponent(); //Initializing the form components (UI elements)
            UpdateDisplay(); //// Updating the display with the current game state
            this.KeyPreview = true;//To focus of key input and not the button
        }

        public void UpdateDisplay() //Method updating the display with the current game state
        {
            String temp;   //Get the current game state 
            temp = gameEngine.toString();
            lblDisplay.Text = temp; // Updating the label's text to show the current game state
            lblLevel.Text = gameEngine.getLevel();//Update what Level the player is on
            lblHeroStats.Text = gameEngine.getHeroStats();//Updates what HP the player has
        }

        //1Q4.3 
        // Method to capture user input via keyboard and trigger movement in the game
        private void fCatTale_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)  // Check which key is pressed and trigger the corresponding movement
            {
                //To use the WASD Keys
                case Keys.W: // Move up
                    gameEngine.TriggerMovement(Direction.Up); UpdateDisplay();// Update the display after movement
                    break;
                case Keys.D: // Move right
                    gameEngine.TriggerMovement(Direction.Right); UpdateDisplay();
                    break;
                case Keys.S: // Move down
                    gameEngine.TriggerMovement(Direction.Down); UpdateDisplay();
                    break;
                case Keys.A: // Move left
                    gameEngine.TriggerMovement(Direction.Left); UpdateDisplay();
                    break;
                //Q3.1
                // Attack
                case Keys.I: // Attack up
                    gameEngine.TriggerAttack(Direction.Up); UpdateDisplay();
                    break;
                case Keys.L: // Attack right
                    gameEngine.TriggerAttack(Direction.Right); UpdateDisplay();
                    break;
                case Keys.K: // Attack down
                    gameEngine.TriggerAttack(Direction.Down); UpdateDisplay();
                    break;
                case Keys.J: // Attack left
                    gameEngine.TriggerAttack(Direction.Left); UpdateDisplay();
                    break;
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //to make lower oppacity of the back ground
            Form bg = new Form();
            try
            {
                using (Info info = new Info())
                {
                    bg.StartPosition = FormStartPosition.Manual;
                    bg.FormBorderStyle = FormBorderStyle.None;
                    bg.Opacity = .70d;
                    bg.BackColor = Color.Black;
                    bg.WindowState = FormWindowState.Maximized;
                    bg.TopMost = true;
                    bg.Location = this.Location;
                    bg.ShowInTaskbar = false;
                    bg.Show();

                    //to show info form on game
                    info.Owner = bg;
                    info.ShowDialog();

                    bg.Dispose();
                }
            }
            catch (Exception ex)
            {
                //if error occurs will show a message
                MessageBox.Show(ex.Message);
            }

            finally
            {
                //will remove backgroung when info form closed
                bg.Dispose();
            }
        }
    }
}

//References
//Ayala, A.E. 2018. Paw Print Background. 31 August 2018. [Online] Available at: https://za.pinterest.com/pin/824792119232696345/ [Accessed 1 October 2024].
//Etsy .2024. Cat Playing Video Games Vinyl Sticker. 20 August 2024. [Online] Available at: https://za.pinterest.com/pin/155303888140886629/ [Accessed 1 October 2024].
//Fransen, J. 2022. Blue and white cat or dog seamless pattern. Meow and cat paws background vector illustration. Cute cartoon pastel character for nursery boy baby. 21 December 2022. [Online]. Available at: https://za.pinterest.com/pin/289989663519555594/ [Accessed 5 September 2024].
//Freepik. 2023. Free Vector | Cute Cat Face Logo Cartoon Vector Icon Illustration Animal Nature Icon Concept Isolated Flat Vector. [Online]. Available at: https://www.freepik.com/free-vector/cute-cat-face-logo-cartoon-vector-icon-illustration-animal-nature-icon-concept-isolated-flat-vector_65096435.htm?epik=dj0yJnU9RDVUbWl6dVBPS1RBdUwzYXpJVEtTZU11RE5NaERYb3cmcD0wJm49VThiQXJHUjNWZDJvOThvelU5bWxiUSZ0PUFBQUFBR2JXNXRr [Accessed 3 September 2024].

//Bibliography
//C# - Pop up Form with Fade Background in Windows Forms Application.2020. YouTube Video, added by C# Ui Academy. [Online]. Available at: https://www.youtube.com/watch?v=jB8q__utFwA [Accessed 1 October 2024].
//DuMez, K. 2024. TypeScript enums. [Online]. Available at: https://graphite.dev/guides/typescript-enums [Accessed 1 September 2024].
//Stack Overflow. 2024. Keep enum-to - object mapping with enum class?, 12 January 2024. [Online]. Available at: https://stackoverflow.com/questions/10307459/keep-enum-to-object-mapping-with-enum-class [Accessed 1 September 2024].
//Worachote, M. 2024. Mastering TypeScript: Exploring Enums in 2024. [Online]. Available at: https://www.amity.co/tutorials/typescript-enums [Accessed 1 September 2024].

