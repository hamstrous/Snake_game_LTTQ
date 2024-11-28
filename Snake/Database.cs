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
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("User đã tồn tại!!");
                        }
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
                string query = "SELECT COUNT(1) FROM [User] WHERE Username = @Username AND Password = @Password;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
