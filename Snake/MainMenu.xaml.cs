using System.Windows;

namespace Snake
{
    public partial class MainMenu : Window
    {

        private Setting settingControl;
        public MainMenu()
        {
            InitializeComponent();
            SoundEffect.PlayBGM();


        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            /*
                        ChooseScreen chooseScreen = new ChooseScreen();
                        chooseScreen.Show();

                        this.Close();*/
            ChooseMode.Visibility = Visibility.Visible;
        }

        private void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            MessageBox.Show("Click");
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {

            SoundEffect.PlayButtonSound();
            Setting.Visibility = Visibility.Visible;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            SoundEffect.PlayButtonSound();
            MessageBox.Show("Click");
        }
    }
}
