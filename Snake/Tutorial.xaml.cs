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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : UserControl
    {

        public event Action EventRightButton;
        public event Action EventExitButton;
        public Tutorial()
        {
            InitializeComponent();
        }

        

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            EventRightButton?.Invoke();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            SoundEffect.PlayOnOffSound();
            this.Visibility = Visibility.Collapsed;
            EventExitButton?.Invoke();
        }
    }
}
