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
        private SoundPlayer loseTune;
        private SoundPlayer loseJingle;

        public GameSound()
        {
            titleTheme = new SoundPlayer();
            swoosh = new SoundPlayer();
            victory = new SoundPlayer();
            loseTune = new SoundPlayer();
            loseJingle = new SoundPlayer();
            titleTheme.SoundLocation = "TitleTheme.wav";
            swoosh.SoundLocation = "swoosh.wav";
            victory.SoundLocation = "congrats.wav";
            loseTune.SoundLocation = "loseTune.wav";
            loseJingle.SoundLocation = "loseJingle.wav";
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

        public void playLoseTune()
        {
            loseTune.Play();
        }

        public void stopTitleTheme()
        {
            titleTheme.Stop();
        }
    }
}
