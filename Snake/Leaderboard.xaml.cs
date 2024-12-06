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
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Back_click (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void Next_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void Return_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click");
        }
        
    }
}
