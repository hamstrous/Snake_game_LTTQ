using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Snake
{
    public class Database
    {
        private string connStr = @"Server=PHUONGNAM;Database=QLTK;User ID=TaiKhoan;Password=123456;";
        public SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;
        private string sqlStr = "Select * from [User]";

        public Database()
        {
            conn = new SqlConnection(connStr);
            myAdapter = new SqlDataAdapter(sqlStr, conn);

            ds = new DataSet();
            myAdapter.Fill(ds, "[User]");

            dt = ds.Tables["[User]"];
        }

            public bool checkLogin(string inputUser, string inputPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", inputUser);
                        cmd.Parameters.AddWithValue("@Password", inputPassword);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error to connect to your account!: {ex.Message}");
                return false;
            }
        }


        public void add(string inputUser, string inputPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", inputUser);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists!");
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", inputUser);
                        cmd.Parameters.AddWithValue("@Password", inputPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your sign-up was successful");
                        }
                        else
                        {
                            MessageBox.Show("Your sign-up was unsuccessful");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error system: {ex.Message}");
            }
        }
    }
}
