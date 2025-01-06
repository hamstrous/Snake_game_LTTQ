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
using System.IO;

namespace Snake
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public static string currentUserName { get; set; }
        public bool openMainMenu = false;
        public SignIn()
        {
            InitializeComponent();
            openMainMenu = false;
        }

        private async void btnSignIn_Click (object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            string username = txtusername.Text;
            string password = txtpassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtErrorMessage.Text = "Please enter correctlly!!";
                txtErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            bool isValidUser = await Database.ValidateUserAsync(username, password);
            if (isValidUser)
            {
                currentUserName = txtusername.Text;
                txtErrorMessage.Text = "Login successful!!";
                txtErrorMessage.Visibility = Visibility.Visible;
                

                List<int> list = await SaveScore.GetPlayerScoresForAllModes(currentUserName);
                string Scores = string.Join(" ", list.Select(score => score.ToString()).ToArray());
                File.WriteAllText("highscore.txt", Scores);

                if (!openMainMenu)
                {
                    SoundEffect.CanPlayBGM = true;
                    SoundEffect.CanPlaySFX = true;
                    SoundEffect.PlayBGM();
                    MainMenu mainMenu = new MainMenu();
                    openMainMenu = true;
                    mainMenu.Show();
                }
                this.Close();
            }
            else
            {
                txtErrorMessage.Text = "Incorrect username or password!!";
                txtErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            SignUp signInWindow = new SignUp();
            signInWindow.Show();
            txtErrorMessage.Visibility = Visibility.Collapsed;
            this.Close();
        }
    }
}
