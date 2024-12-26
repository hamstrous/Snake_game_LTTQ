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
    /// Interaction logic for SettingGameOver.xaml
    /// </summary>
    public partial class SettingGameOver : UserControl
    {
        private TaskCompletionSource<bool> _tcs;
        public SettingGameOver()
        {
            InitializeComponent();
        }

        public Task<bool> ShowDialogAsync()
        {
            _tcs = new TaskCompletionSource<bool>();
            this.Visibility = Visibility.Visible;
            return _tcs.Task;
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            _tcs.SetResult(false);
            this.Visibility = Visibility.Collapsed;
        }

        private void Retry_click(object sender, RoutedEventArgs e)
        {
            _tcs.SetResult(true);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
