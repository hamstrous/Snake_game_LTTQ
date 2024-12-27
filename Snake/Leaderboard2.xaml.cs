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
            await GetLeaderBoards("topScores.txt", "topUser.txt");
            LoadLeaderboard(0);
        }

        private async Task GetLeaderBoards(string filePath, string filePath2)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting leaderboard data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async Task LoadLeaderboard(int mode)
        {
            try
            {
                if (mode < 0 || mode >= leaderboardData.Count || leaderboardData[mode] == null)
                {
                    MessageBox.Show("Không có dữ liệu cho chế độ chơi này.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var scores = leaderboardData[mode];

                for (int i = 0; i < 5; i++)
                {
                    TextBlock sttBlock = (TextBlock)FindName($"stt{i + 1}");
                    TextBlock scoreBlock = (TextBlock)FindName($"score{i + 1}");
                    TextBlock nameBlock = (TextBlock)FindName($"name{i + 1}");

                    if (i < scores.Count)
                    {
                        //if (sttBlock != null)
                        {
                            sttBlock.Text = (i + 1).ToString() + ".";
                            sttBlock.Visibility = Visibility.Visible;
                        }

                        //if (scoreBlock != null)
                        {
                            scoreBlock.Text = $"{scores[i].Item1}"; // Hiển thị cả điểm và tên người chơi
                            scoreBlock.Visibility = Visibility.Visible;
                        }

                        //if (nameBlock != null)
                        {
                            nameBlock.Text = $"{scores[i].Item2}";
                            nameBlock.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        if (sttBlock != null) sttBlock.Visibility = Visibility.Collapsed;
                        if (scoreBlock != null) scoreBlock.Visibility = Visibility.Collapsed;
                        if (nameBlock != null) nameBlock.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaderboard: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Back_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            mode = (mode - 1 + 4) % 5;
            GameMode GAMEMODE = (GameMode)mode;
            gamemode.Text = GAMEMODE.ToString().ToUpper();
            LoadLeaderboard(mode);
        }

        private async void Next_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            mode = (mode + 1) % 5;
            GameMode GAMEMODE = (GameMode)mode;
            gamemode.Text = GAMEMODE.ToString().ToUpper();
            LoadLeaderboard(mode);
        }


        private void Return_click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }
    }
}
