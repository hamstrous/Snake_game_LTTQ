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

                    if (minScore == null || totalCount < 5 || score > minScore)
                    {
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

            }
        }


        public static async Task<List<int>> GetPlayerScoresForAllModes(string username)
        {
            string privateConnectionString = ConnectionString + ";Timeout=30";
            if (string.IsNullOrEmpty(privateConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return new List<int> { 0, 0, 0, 0, 0 };
            }

            var scores = new List<int> { 0, 0, 0, 0, 0 };

            try
            {
                using (var conn = new NpgsqlConnection(privateConnectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT ""mode"", ""highscore""FROM ""ownscore""WHERE ""username"" = @Username AND ""mode"" BETWEEN 0 AND 4;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("Username", username);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int mode = Convert.ToInt32(reader["mode"]);
                                int highscore = Convert.ToInt32(reader["highscore"]);

                                if (mode >= 0 && mode <= 4)
                                {
                                    scores[mode] = highscore;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return scores;
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
                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty);
                }
                else
                {
                    using (File.Create(filePath)) { }
                }

                if (File.Exists(filePath2))
                {
                    File.WriteAllText(filePath2, string.Empty);
                }
                else
                {
                    using (File.Create(filePath2)) { }
                }

                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT \"Mode\", \"Score\", \"Username\" FROM \"PlayerScores\" ORDER BY \"Mode\", \"Score\" DESC;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

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

                            if (modeScores[mode].Count < 5)
                            {
                                modeScores[mode].Add(score);
                                modeUsernames[mode].Add(username);
                            }
                        }

                        conn.Close();

                        using (var writer = new StreamWriter(filePath, false))
                        {
                            for (int mode = 0; mode < 5; mode++)
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

                        using (var writer2 = new StreamWriter(filePath2, false))
                        {
                            for (int mode = 0; mode < 5; mode++)
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

            }
        }


        public static async Task SaveOrUpdateHighScore(string username, int mode, int newHighScore)
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

                    string query = @"INSERT INTO ""ownscore"" (""username"", ""mode"", ""highscore"") VALUES (@Username, @Mode, @NewHighScore) ON CONFLICT (""username"", ""mode"")DO UPDATE SET ""highscore"" = GREATEST(""ownscore"".""highscore"", EXCLUDED.""highscore"");";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("Username", username);
                        cmd.Parameters.AddWithValue("Mode", mode);
                        cmd.Parameters.AddWithValue("NewHighScore", newHighScore);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

