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

namespace Snake
{
    /// <summary>
    /// Interaction logic for Signin.xaml
    /// </summary>
    public partial class Signin : Window
    {
        Database dtb;
        public Signin()
        {
            InitializeComponent();
            dtb = new Database();
        }

        private void btnLogin2_Click(object sender, RoutedEventArgs e)
        {
            Window1 login = new Window1();
            login.Show();
            this.Close();
        }

        private void btnSignin2_Click(object sender, RoutedEventArgs e)
        {
            string inputUser = txtUser.Text.Trim();
            string inputPassword = txtPass.Text.Trim();
            dtb.add(inputUser, inputPassword);
        }
    }
}
