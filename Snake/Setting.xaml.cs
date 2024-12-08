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
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        private bool isPressed = false;
        private bool isPressed2= false;


        public Setting()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void BGM_Click(object sender, RoutedEventArgs e)
        {
            if (isPressed)
            {
                BGM_image.Source = new BitmapImage(new Uri("/Resources/sound-on.png", UriKind.Relative));
            }
            else
            {
                BGM_image.Source = new BitmapImage(new Uri("/Resources/sound-off.png", UriKind.Relative));
                
            }
            isPressed = !isPressed;


        }

        private void SFX_Click(object sender, RoutedEventArgs e)
        {
            if (isPressed2)
            {
                SFX_image.Source = new BitmapImage(new Uri("/Resources/toggle-on.png", UriKind.Relative));
            }
            else
            {
                SFX_image.Source = new BitmapImage(new Uri("/Resources/toggle-off.png", UriKind.Relative));

            }
            isPressed2 = !isPressed2;
        }
        private void Window_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
