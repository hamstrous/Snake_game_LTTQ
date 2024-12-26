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
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
            txtErrorMessage.Visibility = Visibility.Collapsed;
            this.Close();
        }

        private async void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtErrorMessage.Text = "Please enter all the required information.";
                txtErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            bool isValidUser = await Database.RegisterUserAsync(username, password);
            if (isValidUser)
            {
                txtErrorMessage.Text = "Registration Successful!!";
                txtErrorMessage.Visibility = Visibility.Visible;
                SignIn signin = new SignIn();
                signin.Show();
                this.Close();
            }
            else
            {
                txtErrorMessage.Text = "Account already exists.";
                txtErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
