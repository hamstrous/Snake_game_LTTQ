using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Snake
{
    public partial class Leaderboard : Window
    {
        int mode = 0; 

        public Leaderboard()
        {
            InitializeComponent();
            LoadLeaderboard(mode); 
        }

        private async void LoadLeaderboard(int mode)
        {
            try
            {
                // Đợi cho đến khi lấy dữ liệu xong từ cơ sở dữ liệu
                List<LeaderboardEntry> leaderboard = await SaveScore.GetTopPlayersAsync(mode) ?? new List<LeaderboardEntry>();

                // Ẩn các TextBlock
                for (int i = 0; i < 5; i++)
                {
                    TextBlock sttBlock = (TextBlock)FindName($"stt{i + 1}");
                    TextBlock nameBlock = (TextBlock)FindName($"name{i + 1}");
                    TextBlock scoreBlock = (TextBlock)FindName($"score{i + 1}");

                    if (sttBlock != null) sttBlock.Visibility = Visibility.Collapsed;
                    if (nameBlock != null) nameBlock.Visibility = Visibility.Collapsed;
                    if (scoreBlock != null) scoreBlock.Visibility = Visibility.Collapsed;
                }

                // Hiển thị thông tin leaderboard
                for (int i = 0; i < leaderboard.Count && i < 5; i++)
                {
                    TextBlock sttBlock = (TextBlock)FindName($"stt{i + 1}");
                    TextBlock nameBlock = (TextBlock)FindName($"name{i + 1}");
                    TextBlock scoreBlock = (TextBlock)FindName($"score{i + 1}");

                    if (sttBlock != null)
                    {
                        sttBlock.Text = (i + 1).ToString();
                        sttBlock.Visibility = Visibility.Visible;
                    }

                    if (nameBlock != null)
                    {
                        nameBlock.Text = leaderboard[i].Name;
                        nameBlock.Visibility = Visibility.Visible;
                    }

                    if (scoreBlock != null)
                    {
                        scoreBlock.Text = leaderboard[i].Score.ToString();
                        scoreBlock.Visibility = Visibility.Visible;
                    }
                }

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show("Error loading leaderboard: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Back_click(object sender, RoutedEventArgs e)
        {
            mode = (mode - 1 + 6) % 6;
            GameMode gameMode = (GameMode)mode;
            gamemode.Text = gameMode.ToString();

            
            LoadLeaderboard(mode);
        }

        private async void Next_click(object sender, RoutedEventArgs e)
        {
            // Gọi LoadLeaderboard bất đồng bộ và chờ nó hoàn thành
            await LoadLeaderboard(mode);

            // Sau khi dữ liệu đã được tải, cập nhật chế độ chơi
            mode = (mode + 1) % 6;
            GameMode gameMode = (GameMode)mode;
            gamemode.Text = gameMode.ToString();
        }


        private void Return_click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
