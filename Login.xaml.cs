using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Snake
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click (object sender, RoutedEventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Password;

            if (Database.ValidateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!!");
            }
        }

        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            Signin signInWindow = new Signin();
            signInWindow.Show();
            this.Close();
        }
    }
}
