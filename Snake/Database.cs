using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace Snake
{
    public static class Database
    {
        private static readonly string ConnectionString =
        ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;

        public static bool RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO [User] (Id, Username, Password) VALUES (NEWID(), @Username, @Password);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Hash mật khẩu bằng bcrypt
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("User đã tồn tại!!");
                        return false;
                    }
                }
            }
        }


        // Hàm kiểm tra đăng nhập
        public static bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Password FROM [User] WHERE Username = @Username;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    // Lấy mật khẩu đã hash từ cơ sở dữ liệu
                    string storedHash = command.ExecuteScalar()?.ToString();
                    if (storedHash == null) return false;

                    // So sánh mật khẩu đã nhập với mật khẩu đã hash
                    return BCrypt.Net.BCrypt.Verify(password, storedHash);
                }
            }
        }
    }
}
