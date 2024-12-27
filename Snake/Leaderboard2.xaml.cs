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
using System.IO;

namespace Snake
{
    /// <summary>
    /// Interaction logic for Leaderboard2.xaml
    /// </summary>
    public partial class Leaderboard2 : UserControl
    {
        int mode = 0;
        private List<List<Tuple<int, string>>> leaderboardData;

        public Leaderboard2()
        {
            InitializeComponent();
            startGet();
        }

        private async Task startGet()
        {
            mode = 0;
            GameMode GAMEMODE = (GameMode)mode;
            gamemode.Text = GAMEMODE.ToString().ToUpper();

            if (await GetLeaderBoards("topScores.txt", "topUser.txt") == false)
            {
                 this.Visibility = Visibility.Collapsed;
            }
            await LoadLeaderboard(mode);
        }

        private async Task<bool> GetLeaderBoards(string filePath, string filePath2)
        {
            try
            {
                await SaveScore.GetTopPlayersAsync(filePath, filePath2);

                leaderboardData = new List<List<Tuple<int, string>>>();

                // Đọc dữ liệu từ cả hai file
                var scoresLines = File.ReadAllLines(filePath); 
                var usersLines = File.ReadAllLines(filePath2);

                for (int i = 0; i < scoresLines.Length; i++)
                {
                    var scores = scoresLines[i].Split(' ') // Tách các số nguyên cách nhau bằng dấu cách
                                               .Where(x => int.TryParse(x, out _)) // Lọc các giá trị hợp lệ
                                               .Select(int.Parse) // Chuyển đổi thành số nguyên
                                               .ToList();

                    var usernames = usersLines[i].Split(' ').ToList(); // Tách tên người chơi

                    var modeData = new List<Tuple<int, string>>();

                    for (int j = 0; j < scores.Count; j++)
                    {
                        modeData.Add(new Tuple<int, string>(scores[j], usernames[j]));
                    }

                    leaderboardData.Add(modeData);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private async Task<bool> LoadLeaderboard(int mode)
        {
            try
            {
                if (mode < 0 || mode >= leaderboardData.Count || leaderboardData[mode] == null)
                {
                    //MessageBox.Show("Không có dữ liệu cho chế độ chơi này.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                var scores = leaderboardData[mode];

                for (int i = 0; i < 5; i++)
                {
                    TextBlock sttBlock = (TextBlock)FindName($"stt{i + 1}");
                    TextBlock scoreBlock = (TextBlock)FindName($"score{i + 1}");
                    TextBlock nameBlock = (TextBlock)FindName($"name{i + 1}");

                    if (i < scores.Count)
                    {
                        sttBlock.Text = (i + 1).ToString() + ".";
                        sttBlock.Visibility = Visibility.Visible;

                        scoreBlock.Text = $"{scores[i].Item1}";
                        scoreBlock.Visibility = Visibility.Visible;

                        nameBlock.Text = $"{scores[i].Item2}";
                        nameBlock.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (sttBlock != null) sttBlock.Visibility = Visibility.Collapsed;
                        if (scoreBlock != null) scoreBlock.Visibility = Visibility.Collapsed;
                        if (nameBlock != null) nameBlock.Visibility = Visibility.Collapsed;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                this.Visibility = Visibility.Collapsed;
                return false;
            }
        }



        private async void Back_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            mode = (mode - 1 + 5) % 5;
            GameMode GAMEMODE = (GameMode)mode;
            string ModeImageSource = GAMEMODE switch
            {
                GameMode.Classic => "LeaderBoard/Classic.png",
                GameMode.Box => "LeaderBoard/Box.png",
                GameMode.Reverse => "LeaderBoard/Reverse.png",
                GameMode.Wall => "LeaderBoard/Wall.png",
                GameMode.Direction => "LeaderBoard/Direction.png",
            };
            Mode.Source = new BitmapImage(new Uri(ModeImageSource, UriKind.RelativeOrAbsolute));
            gamemode.Text = GAMEMODE.ToString().ToUpper();
            if (await LoadLeaderboard(mode) == false)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }

        private async void Next_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            mode = (mode + 1) % 5;
            GameMode GAMEMODE = (GameMode)mode;
            string ModeImageSource = GAMEMODE switch
            {
                GameMode.Classic => "LeaderBoard/Classic.png",
                GameMode.Box => "LeaderBoard/Box.png",
                GameMode.Reverse => "LeaderBoard/Reverse.png",
                GameMode.Wall => "LeaderBoard/Wall.png",
                GameMode.Direction => "LeaderBoard/Direction.png",
            };
            Mode.Source = new BitmapImage(new Uri(ModeImageSource, UriKind.RelativeOrAbsolute));
            gamemode.Text = GAMEMODE.ToString().ToUpper();
            if (await LoadLeaderboard(mode) == false)
            {
                this.Visibility = Visibility.Collapsed;
            }
        }


        private void Return_click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }

        public async Task RefreshDataAsync()
        {
            try
            {
                await startGet();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Có lỗi xảy ra khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
