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
        Database dtb;
        public Window1()
        {
            InitializeComponent();
            dtb = new Database();
        }

        private void btnLogin_Click (object sender, RoutedEventArgs e)
        {
            string inputUser = txtusername.Text.Trim();
            string inputPassword = txtpassword.Password.Trim();
            if (dtb.checkLogin(inputUser, inputPassword))
            {
                //Nhảy tới màn hình chọn trò chơi
            } else
            {
                MessageBox.Show("Invalid username or password!!");
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
