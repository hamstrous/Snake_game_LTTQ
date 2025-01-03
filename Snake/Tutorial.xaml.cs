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
        public Tutorial()
        {
            InitializeComponent();
            Tutorial2.IsVisibleChanged += Tutorial2_IsVisibleChanged;
            
        }

        

        private void Next_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            Tutorial2.Visibility = Visibility.Visible;
        }

        private void Tutorial2_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Tutorial2.Visibility == Visibility.Collapsed)
            {
                // Khi Tutorial2 ẩn, ẩn cả Tutorial
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
