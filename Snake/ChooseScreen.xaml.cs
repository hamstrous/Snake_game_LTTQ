using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ChooseScreen.xaml
    /// </summary>
    public partial class ChooseScreen : Window
    {
        public ObservableCollection<string> Row1Items { get; set; }
        public ICommand SelectCommand { get; set; }
        public ChooseScreen()
        {
            InitializeComponent();
            Row1Items = new ObservableCollection<string> { "🍎", "🍌", "🍍", "🍇", "🥕", "🌽", "1", "2", "3", "4", "5" };

            // Command for selecting items
            SelectCommand = new RelayCommand(SelectItem);

            DataContext = this;
        }

        private void SelectItem(object obj)
        {
            MessageBox.Show($"Selected: {obj}");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Back Button Clicked!");
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Game Started!");
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Items Shuffled!");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Settings Reset!");
        }
    }

    // RelayCommand Implementation for Button Command
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);
        public event EventHandler CanExecuteChanged;
    }
}
