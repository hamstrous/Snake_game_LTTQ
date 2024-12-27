using System;
using System.Configuration;
using Npgsql;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Controls;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Collections.Concurrent;
using System.Windows.Controls.Primitives;

namespace Snake
{
    public class SaveScore
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SupabaseConnection"]?.ConnectionString;

        public static async Task SavePlayerScore(string username, int score, int mode)
        {
            string privateConnectionString = ConnectionString + ";Timeout=30";
            if (string.IsNullOrEmpty(privateConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(privateConnectionString))
                {
                    await conn.OpenAsync();

                    // Lấy điểm thấp nhất và số lượng điểm hiện tại của chế độ chơi
                    string getModeStatsQuery = @"
                SELECT MIN(""Score"") AS MinScore, COUNT(*) AS TotalCount
                FROM ""PlayerScores""
                WHERE ""Mode"" = @Mode;
            ";

                    int? minScore = null;
                    int totalCount = 0;

                    using (var cmd = new NpgsqlCommand(getModeStatsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Mode", mode);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                minScore = reader["MinScore"] as int?;
                                totalCount = Convert.ToInt32(reader["TotalCount"]);
                            }
                        }
                    }

                    // Kiểm tra nếu điểm mới đủ điều kiện để thêm vào top 5
                    if (minScore == null || totalCount < 5 || score > minScore)
                    {
                        // Thêm điểm mới vào bảng
                        string insertScoreQuery = @"
                    INSERT INTO ""PlayerScores"" (""Username"", ""Score"", ""Mode"", ""Timestamp"")
                    VALUES (@Username, @Score, @Mode, NOW());
                ";

                        using (var cmd = new NpgsqlCommand(insertScoreQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("Username", username);
                            cmd.Parameters.AddWithValue("Score", score);
                            cmd.Parameters.AddWithValue("Mode", mode);

                            await cmd.ExecuteNonQueryAsync();
                        }

                        // Loại bỏ điểm thấp hơn top 5 trong chế độ chơi hiện tại
                        string deleteLowScoresQuery = @"
                    WITH RankedScores AS (
                        SELECT ""Id"", ROW_NUMBER() OVER (PARTITION BY ""Mode"" ORDER BY ""Score"" DESC) AS rn
                        FROM ""PlayerScores""
                        WHERE ""Mode"" = @Mode
                    )
                    DELETE FROM ""PlayerScores""
                    WHERE ""Id"" IN (
                        SELECT ""Id""
                        FROM RankedScores
                        WHERE rn > 5
                    );
                ";

                        using (var cmd = new NpgsqlCommand(deleteLowScoresQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("Mode", mode);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi xảy ra khi lưu điểm: " + ex.Message);
            }
        }






        public static async Task GetTopPlayersAsync(string filePath, string filePath2)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return;
            }

            try
            {
                // Xử lý file điểm
                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty); // Xoá nội dung nếu file tồn tại
                }
                else
                {
                    using (File.Create(filePath)) { } // Tạo file mới
                }

                // Xử lý file tên người dùng
                if (File.Exists(filePath2))
                {
                    File.WriteAllText(filePath2, string.Empty); // Xoá nội dung nếu file tồn tại
                }
                else
                {
                    using (File.Create(filePath2)) { } // Tạo file mới
                }

                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    // Truy vấn lấy top 5 điểm theo chế độ chơi
                    string query = "SELECT \"Mode\", \"Score\", \"Username\" FROM \"PlayerScores\" ORDER BY \"Mode\", \"Score\" DESC;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        // Khởi tạo Dictionary để lưu kết quả
                        var modeScores = new Dictionary<int, List<int>>();
                        var modeUsernames = new Dictionary<int, List<string>>();

                        while (await reader.ReadAsync())
                        {
                            int mode = Convert.ToInt32(reader["Mode"]);
                            int score = Convert.ToInt32(reader["Score"]);
                            string username = reader["Username"].ToString();

                            if (!modeScores.ContainsKey(mode))
                            {
                                modeScores[mode] = new List<int>();
                                modeUsernames[mode] = new List<string>();
                            }

                            // Chỉ lưu tối đa 5 giá trị cho mỗi mode
                            if (modeScores[mode].Count < 5)
                            {
                                modeScores[mode].Add(score);
                                modeUsernames[mode].Add(username);
                            }
                        }

                        conn.Close();

                        // Ghi dữ liệu ra file .txt cho điểm
                        using (var writer = new StreamWriter(filePath, false)) // Ghi đè nội dung
                        {
                            for (int mode = 0; mode < 5; mode++) // Giả định có 5 chế độ chơi (0-4)
                            {
                                if (modeScores.ContainsKey(mode))
                                {
                                    string line = string.Join(" ", modeScores[mode]);
                                    writer.WriteLine(line);
                                }
                                else
                                {
                                    writer.WriteLine();
                                }
                            }
                        }

                        // Ghi dữ liệu ra file .txt cho tên người dùng
                        using (var writer2 = new StreamWriter(filePath2, false)) // Ghi đè nội dung
                        {
                            for (int mode = 0; mode < 5; mode++) // Giả định có 5 chế độ chơi (0-4)
                            {
                                if (modeUsernames.ContainsKey(mode))
                                {
                                    string line = string.Join(" ", modeUsernames[mode]);
                                    writer2.WriteLine(line);
                                }
                                else
                                {
                                    writer2.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi xảy ra khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

