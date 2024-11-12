using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    public class GameSound
    {
        private SoundPlayer titleTheme;
        private SoundPlayer swoosh;
        private SoundPlayer victory;
        private SoundPlayer lose;

        public GameSound()
        {
            titleTheme = new SoundPlayer();
            swoosh = new SoundPlayer();
            victory = new SoundPlayer();
            lose = new SoundPlayer();
            titleTheme.SoundLocation = "TitleTheme.wav";
            swoosh.SoundLocation = "swoosh.wav";
            victory.SoundLocation = "congrats.wav";
            lose.SoundLocation = "lose.wav";
        }

        public void playTitleTheme()
        {
            titleTheme.PlayLooping();
        }
        public void playSwoosh() 
        {
            swoosh.Play();
        }

        public void playVictory() 
        {
            victory.Play();
        }
        
        public void playLose()
        {
            lose.Play();
        }

        public void stopTitleTheme()
        {
            titleTheme.Stop();
        }
    }
}
