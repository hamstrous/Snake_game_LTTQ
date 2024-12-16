using System;
using System.CodeDom;
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
        // Dictionaries to track selected buttons for each enum group
        private readonly Dictionary<Type, Button> _selectedGameModeButtons = new();
        private GameInit gameInit = new GameInit();
        public ChooseScreen()
        {
            InitializeComponent();
            ClassicButton.Background = Brushes.LightBlue;
            _selectedGameModeButtons[typeof(GameMode)] = ClassicButton;
            MediumSpeedButton.Background = Brushes.LightBlue;
            _selectedGameModeButtons[typeof(GameSpeed)] = MediumSpeedButton;
            MediumSizeButton.Background = Brushes.LightBlue;
            _selectedGameModeButtons[typeof(GameSize)] = MediumSizeButton;
            RedFoodButton.Background = Brushes.LightBlue;
            _selectedGameModeButtons[typeof(FoodColor)] = RedFoodButton;
            gameInit.GameMode = GameMode.Classic;
            gameInit.GameSpeed = GameSpeed.Medium;
            gameInit.GameSize = GameSize.Medium;
            gameInit.FoodColor = FoodColor.Red;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            // Parse the group and value from the Tag property
            string[] tagParts = clickedButton.Tag.ToString().Split(',');
            string groupName = tagParts[0];
            string enumValue = tagParts[1];

            // Handle each group independently
            if (groupName == nameof(GameMode))
            {
                HandleButtonSelection<GameMode>(clickedButton, _selectedGameModeButtons, enumValue);
            }else if (groupName == nameof(GameSpeed))
            {
                HandleButtonSelection<GameSpeed>(clickedButton, _selectedGameModeButtons, enumValue);
            }else if(groupName == nameof(GameSize))
            {
                HandleButtonSelection<GameSize>(clickedButton, _selectedGameModeButtons, enumValue);
            }else if(groupName == nameof(FoodColor))
            {
                HandleButtonSelection<FoodColor>(clickedButton, _selectedGameModeButtons, enumValue);
            }
        }

        private void HandleButtonSelection<TEnum>(Button clickedButton, Dictionary<Type, Button> selectedButtons, string enumValue)
        {
            // Parse the enum value
            TEnum selectedEnumValue = (TEnum)System.Enum.Parse(typeof(TEnum), enumValue);
            Type enumType = selectedEnumValue.GetType();
            if(enumType == typeof(GameMode))
                gameInit.GameMode = (GameMode)(object)selectedEnumValue;
            else if(enumType == typeof(GameSpeed))
                gameInit.GameSpeed = (GameSpeed)(object)selectedEnumValue;
            else if(enumType == typeof(GameSize))
                gameInit.GameSize = (GameSize)(object)selectedEnumValue;
            else if(enumType == typeof(FoodColor))
                gameInit.FoodColor = (FoodColor)(object)selectedEnumValue;

            // Deselect the currently selected button for this group (if any)
            if (selectedButtons.ContainsKey(enumType))
            {
                Button previousButton = selectedButtons[enumType];
                previousButton.Background = Brushes.LightGray; // Reset color
                selectedButtons.Remove(enumType); // Remove old selection
            }

            // Select the new button
            clickedButton.Background = Brushes.LightBlue; // Set selected color
            selectedButtons[enumType] = clickedButton;

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
            MainWindow mainWindow = new MainWindow(gameInit);
            mainWindow.Show();
            this.Close();
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
