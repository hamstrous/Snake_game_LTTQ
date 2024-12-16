using System;
using System.Configuration;
using Npgsql;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Controls;

namespace Snake
{
    public class SaveScore
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SupabaseConnection"]?.ConnectionString;

        public static async Task<Guid?> GetUserIdAsync(string username)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return null;
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string query = "SELECT \"id\" FROM \"User\" WHERE Username = @Username";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        var result = await command.ExecuteScalarAsync();
                        if (result != null)
                        {
                            return (Guid)result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message);
                    return null;
                }
            }
        }

        
        public static async Task SavePlayerScore(Guid userId, int score, int mode)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    await conn.OpenAsync(); 

                    string insertScoreQuery = "INSERT INTO \"PlayerScores\" (\"UserId\", \"Score\", \"Mode\", \"Timestamp\") VALUES(@UserId, @Score, @Mode, NOW());";

                    using (var cmd = new NpgsqlCommand(insertScoreQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("UserId", userId);
                        cmd.Parameters.AddWithValue("Score", score);
                        cmd.Parameters.AddWithValue("Mode", mode);

                        await cmd.ExecuteNonQueryAsync(); 
                    }
                }
                
            }
            catch (Exception ex)
            {
                
            }
        }




        public static async Task<List<LeaderboardEntry>> GetTopPlayersAsync(int mode)
        {
            var topPlayers = new List<LeaderboardEntry>();

            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return topPlayers;
            }

            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    // Mở kết nối bất đồng bộ
                    await conn.OpenAsync();

                    string getTopPlayersQuery = "SELECT * FROM get_top_players() WHERE \"mode\" = @Mode ORDER BY \"score\" DESC;";

                    using (var cmd = new NpgsqlCommand(getTopPlayersQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Mode", mode);

                        // Thực hiện truy vấn bất đồng bộ
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync()) // Đọc kết quả bất đồng bộ
                            {
                                topPlayers.Add(new LeaderboardEntry
                                {
                                    Name = reader["Username"].ToString(),
                                    Score = Convert.ToInt32(reader["Score"]),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy top điểm: " + ex.Message);
            }

            return topPlayers;
        }

    }
}
