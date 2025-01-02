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
    /// Interaction logic for SettingExit2.xaml
    /// </summary>
    public partial class SettingExit2 : UserControl
    {
        public SettingExit2()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            SoundEffect.PauseBGM();
            SoundEffect.CanPlayBGM = false;
            SignIn signIn = new SignIn();
            signIn.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is not SignIn)
                {
                    window.Close();
                }
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            Application.Current.Shutdown();
        }

    }
}
