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
        private bool isPressed3 = false;

        public Setting()
        {
            InitializeComponent();
            if (SoundEffect.CanPlayBGM)
            {
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-on.png", UriKind.Relative));
            }
            else
            {
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-off.png", UriKind.Relative));
            }

            if (SoundEffect.CanPlaySFX)
            {
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-on.png", UriKind.Relative));
            }
            else
            {
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-off.png", UriKind.Relative));
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }

        private void BGM_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            if (!SoundEffect.CanPlayBGM)
            {
                SoundEffect.ResumeBGM();
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-on.png", UriKind.Relative));
            }
            else
            {
                SoundEffect.PauseBGM();
                BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-off.png", UriKind.Relative));
                
            }

        }

        private void SFX_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            if (!SoundEffect.CanPlaySFX)
            {
                SoundEffect.CanPlaySFX = true;
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-on.png", UriKind.Relative));
            }
            else
            {
                SoundEffect.CanPlaySFX = false;
                SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-off.png", UriKind.Relative));

            }
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
            var parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                if (parentWindow.WindowStyle == WindowStyle.None)
                {
                    parentWindow.WindowState = WindowState.Normal;
                    parentWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                    parentWindow.ResizeMode = ResizeMode.CanResize;
                }
                else
                {
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.WindowStyle = WindowStyle.None;
                    parentWindow.ResizeMode = ResizeMode.NoResize;
                }
            }

        }
    }
}
