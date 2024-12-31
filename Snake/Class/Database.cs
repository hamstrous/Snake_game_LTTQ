using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

namespace Snake
{
    public static class Database
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SupabaseConnection"]?.ConnectionString;

        private static bool ValidateConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return false;
            }
            return true;
        }

        public static async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (!ValidateConnectionString()) return false;

            await using var connection = new NpgsqlConnection(ConnectionString);
            try
            {
                await connection.OpenAsync();

                string checkUserQuery = "SELECT 1 FROM \"User\" WHERE Username = @Username LIMIT 1;";
                await using var checkCommand = new NpgsqlCommand(checkUserQuery, connection);
                checkCommand.Parameters.AddWithValue("@Username", username);

                var result = await checkCommand.ExecuteScalarAsync();
                if (result != null) return false;

                string insertUserQuery = "INSERT INTO \"User\" (Id, Username, \"Password\") VALUES (gen_random_uuid(), @Username, @Password);";
                await using var insertCommand = new NpgsqlCommand(insertUserQuery, connection);

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                insertCommand.Parameters.AddWithValue("@Username", username);
                insertCommand.Parameters.AddWithValue("@Password", hashedPassword);

                await insertCommand.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> ValidateUserAsync(string username, string password)
        {
            if (!ValidateConnectionString()) return false;

            await using var connection = new NpgsqlConnection(ConnectionString);
            try
            {
                await connection.OpenAsync();

                string query = "SELECT \"Password\" FROM \"User\" WHERE Username = @Username";
                await using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                string storedHash = (await command.ExecuteScalarAsync())?.ToString();
                if (string.IsNullOrEmpty(storedHash)) return false;

                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
