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

//References
//Freesound .2021a. Congrats by Fupicat. 5 November 2021. [Online]. Available at: https://freesound.org/people/Fupicat/sounds/607207/  [Accessed 6 November 2024].
//Freesound 2021b. Freesound - Explode by Fupicat. 5 November 2021. [Online]. Available at: https://freesound.org/people/Fupicat/sounds/607206/  [Accessed 8 November 2024].
//Freesounds .2024. Freesound - 2024-02-16_Background-Sound_Game-music_Remix by kevp888. 17 February 2024. [Online]. Available at: https://freesound.org/people/kevp888/sounds/723909/ [Accessed 5 November 2024].