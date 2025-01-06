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
    /// Interaction logic for SettingGameOver.xaml
    /// </summary>
    public partial class SettingGameOver : UserControl
    {

        public int CurrentScore { get; set; }
        public int HighScore { get; set; }

        private TaskCompletionSource<bool> _tcs;
        public SettingGameOver()
        {
            InitializeComponent();
        }

        public Task<bool> ShowDialogAsync()
        {
            _tcs = new TaskCompletionSource<bool>();
            this.Visibility = Visibility.Visible;
            return _tcs.Task;
        }

        public void UpdateGameOverScreen(int score, int highscore)
        {
            // Hiển thị điểm hiện tại và high score trên UI
            Score.Text = score.ToString();
            Highscore.Text = highscore.ToString();
        }

        public void SetGameMode(GameMode gameMode)
        {
            string modeImageSource = gameMode switch
            {
                GameMode.Classic =>  "/Choose/Classic.png",
                GameMode.Wall => "Choose/Wall.png",
                GameMode.Box => "Choose/Box.png",
                GameMode.Reverse => "Choose/Reverse.png",
                GameMode.Direction => "Choose/Direction_light.png",
            };
            NameMode.Source = new BitmapImage(new Uri(modeImageSource, UriKind.RelativeOrAbsolute));
        }
        public void SetFoodType(FoodType foodType)
        {
            string foodImageSource = foodType switch
            {
                FoodType.Apple => "Choose/apple.png",
                FoodType.Banana => "Choose/banana.png",
                FoodType.Grape => "Choose/grape.png",
                FoodType.Radish => "Choose/raddish.png",
                FoodType.Peach => "Choose/peach.png",
            };
            NameFood.Source = new BitmapImage(new Uri(foodImageSource, UriKind.RelativeOrAbsolute));
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            _tcs.SetResult(false);
            this.Visibility = Visibility.Collapsed;
        }

        private void Retry_click(object sender, RoutedEventArgs e)
        {
            _tcs.SetResult(true);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
