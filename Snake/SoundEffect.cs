using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
namespace Snake
{
    public static class SoundEffect
    {
        public static SoundPlayer Eat { get; private set; }
        public static SoundPlayer Move { get; private set; }
        public static SoundPlayer GameOver { get; private set; }

        static void Play(string fileName)
        {
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Open(new System.Uri($@"..\..\..\Sounds\{fileName}", UriKind.Relative));
            myPlayer.Play();
        }

        static SoundEffect()
        {
            Eat = new SoundPlayer();
            Move = new SoundPlayer();
            GameOver = new SoundPlayer();

            try
            {
                Eat.Stream = Properties.Resources.food;
                Move.Stream = Properties.Resources.move;
                GameOver.Stream = Properties.Resources.gameover;

                Eat.Load();
                Move.Load();
                GameOver.Load();
            }
            catch (Exception ex)
            {
                // Handle exceptions such as missing resources or loading errors
                Console.WriteLine("Error loading sound effects: " + ex.Message);
            }
        }

        public static void PlayEatSound()
        {
            //Task.Run(() => Eat.Play());
            Play("food.wav");
        }

        public static void PlayMoveSound()
        {
            //Task.Run(() => Move.Play());
            Play("move.wav");
        }

        public static void PlayGameOverSound()
        {
            //Task.Run(() => GameOver.Play());
            Play("gameover.wav");
        }
    }
}