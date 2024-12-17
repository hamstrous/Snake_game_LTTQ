using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    public partial class Setting : UserControl
    {
        private bool isPressed = false;
        private bool isPressed2 = false;
        private bool isPressed3 = false;


        public Setting()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }

        private void BGM_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            if (isPressed)
            {
                SoundEffect.ResumeBGM();
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-on.png", UriKind.Relative));
            }
            else
            {
                SoundEffect.PauseBGM();
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-off.png", UriKind.Relative));
                
            }
            isPressed = !isPressed;


        }

        private void SFX_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            if (isPressed2)
            {
                SoundEffect.CanPlaySFX = true;
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-on.png", UriKind.Relative));
            }
            else
            {
                SoundEffect.CanPlaySFX = false;
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-off.png", UriKind.Relative));

            }
            isPressed2 = !isPressed2;
        }
        private void Window_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            if (isPressed3)
            {
                Window_image.Source = new BitmapImage(new Uri("/Setting/Sizeup.png", UriKind.Relative));
            }
            else
            {
                Window_image.Source = new BitmapImage(new Uri("/Setting/Sizedown.png", UriKind.Relative));

            }
            isPressed3 = !isPressed3;
        }
    }
}
