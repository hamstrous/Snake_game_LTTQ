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

        public static async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return false;
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    // Kiểm tra xem user đã tồn tại chưa
                    string checkUserQuery = "SELECT 1 FROM \"User\" WHERE Username = @Username LIMIT 1;";
                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkUserQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);

                        var result = await checkCommand.ExecuteScalarAsync();
                        if (result != null)
                        {
                            return false;
                        }
                    }

                    // Thêm người dùng mới
                    string insertUserQuery = "INSERT INTO \"User\" (Id, Username, \"Password\") VALUES (gen_random_uuid(), @Username, @Password);";
                    using (NpgsqlCommand command = new NpgsqlCommand(insertUserQuery, connection))
                    {
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }

        public static async Task<bool> ValidateUserAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối! Vui lòng kiểm tra file cấu hình.");
                return false;
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string query = "SELECT \"Password\" FROM \"User\" WHERE Username = @Username";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        string storedHash = (await command.ExecuteScalarAsync())?.ToString();
                        if (storedHash == null)
                        {
                            return false;
                        }

                        bool isValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

                        return isValid;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
