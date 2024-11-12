using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACatsTalePOE
{
    public partial class StartUp : Form
    {
        private GameSound sound = new GameSound();
        private Timer hover;
        private int hoverDirection = 1;
        private int hoverSpeed = 2;
        public StartUp()
        {
            InitializeComponent();
            sound.playTitleTheme();
            hover = new Timer();
            hover.Interval = 100;
            hover.Tick += new EventHandler(HoverTimer_Tick);
            hover.Start();
        }

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            // Move label up and down
            lblTitle.Top += hoverDirection * hoverSpeed;

            // Reverse direction if the label reaches certain boundaries
            if (lblTitle.Top <= 5 || lblTitle.Top >= 23) // Adjust as needed
            {
                hoverDirection *= -1; // Reverse direction
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            sound.stopTitleTheme();
            this.Hide();
            fCatTale fCatTale = new fCatTale(false);
            fCatTale.Closed += (s, args) => this.Close();
            fCatTale.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
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

                    info.Owner = bg;
                    info.ShowDialog();

                    bg.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                bg.Dispose();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fileStream = new FileStream("GameSaveData.sav", FileMode.Open)) 
                { }
                sound.stopTitleTheme();
                this.Hide();
                fCatTale fCatTale = new fCatTale(true);
                fCatTale.Closed += (s, args) => this.Close();
                fCatTale.Show();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("You have not started a game yet, please slecet start new game.", "Load Game");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load game: {ex.Message}", "Load Error");
            }
        }
    }
}
