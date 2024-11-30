using System;
using System.Configuration;
using System.Windows;
using Npgsql;

namespace Snake
{
    public static class Database
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SupabaseConnection"].ConnectionString;

        public static bool RegisterUser(string username, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string checkUserQuery = "SELECT COUNT(*) FROM \"User\" WHERE Username = @Username";
                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkUserQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);

                    int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (userCount > 0)
                    {
                        return false;
                    }
                }

                string insertUserQuery = "INSERT INTO \"User\" (Id, Username, \"Password\") " +
                                         "VALUES (gen_random_uuid(), @Username, @Password)";
                using (NpgsqlCommand command = new NpgsqlCommand(insertUserQuery, connection))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show("Đã có lỗi trong quá trình đăng ký: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT \"Password\" FROM \"User\" WHERE Username = @Username";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    string storedHash = command.ExecuteScalar()?.ToString();
                    if (storedHash == null)
                    {
                        MessageBox.Show("Người dùng không tồn tại!");
                        return false;
                    }

                    bool isValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

                    if (!isValid)
                    {
                        MessageBox.Show("Mật khẩu không đúng!");
                    }

                    return isValid;
                }
            }
        }
    }
}
