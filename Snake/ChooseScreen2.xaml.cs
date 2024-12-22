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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private readonly Dictionary<Type, Button> _selectedGameModeButtons = new();
        private GameInit gameInit = new GameInit();
        public UserControl1()
        {
            InitializeComponent();
            ClassicModeButton.Style = (Style)FindResource("ClassicMode2");
            _selectedGameModeButtons[typeof(GameMode)] = ClassicModeButton;
            MediumSizeButton.Style = (Style)FindResource("MediumSize2");
            _selectedGameModeButtons[typeof(GameSize)] = MediumSizeButton;
            MediumSpeedButton.Style = (Style)FindResource("MediumSpeed2");
            _selectedGameModeButtons[typeof(GameSpeed)] = MediumSpeedButton;
            OneFoodButton.Style = (Style)FindResource("One2");
            _selectedGameModeButtons[typeof(FoodAmount)] = OneFoodButton;
            AppleButton.Style = (Style)FindResource("Apple2");
            _selectedGameModeButtons[typeof(FoodType)] = AppleButton;
            BlueButton.Style = (Style)FindResource("Blue2");
            _selectedGameModeButtons[typeof(SnakeColor)] = BlueButton;

            gameInit.GameMode = GameMode.Classic;
            gameInit.GameSpeed = GameSpeed.Medium;
            gameInit.GameSize = GameSize.Medium;
            gameInit.FoodType = FoodType.Apple;
            gameInit.FoodAmount = FoodAmount.One;
        }
        /*string[] link = ClassicModeButton.Tag.ToString().Split("_Dark");
        string groupName = link[0];
        string enumValue = link[1];*/
        /*

        MediumSizeButton.Background = Brushes.LightBlue;

        _selectedGameModeButtons[typeof(FoodColor)] = RedFoodButton;
*/

        private void SwitchStyle(Button button)
        {
            ResourceDictionary resourceDictionary = this.Resources.MergedDictionaries[0];

            // Find the key for the current style
            string styleName = resourceDictionary.Keys
                .OfType<string>()
                .FirstOrDefault(key => resourceDictionary[key] == button.Style);

            if (styleName[styleName.Length - 1] == '1')
            {

                button.Style = (Style)FindResource(styleName.Substring(0, styleName.Length - 1) + "2");
            }
            else
            {
                button.Style = (Style)FindResource(styleName.Substring(0, styleName.Length - 1) + "1");
            }
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
            }
            else if (groupName == nameof(GameSpeed))
            {
                HandleButtonSelection<GameSpeed>(clickedButton, _selectedGameModeButtons, enumValue);
            }
            else if (groupName == nameof(GameSize))
            {
                HandleButtonSelection<GameSize>(clickedButton, _selectedGameModeButtons, enumValue);
            }
            else if (groupName == nameof(FoodType))
            {
                HandleButtonSelection<FoodType>(clickedButton, _selectedGameModeButtons, enumValue);
            }
            else if (groupName == nameof(FoodAmount))
            {
                HandleButtonSelection<FoodAmount>(clickedButton, _selectedGameModeButtons, enumValue);
            }
            else if (groupName == nameof(SnakeColor))
            {
                HandleButtonSelection<SnakeColor>(clickedButton, _selectedGameModeButtons, enumValue);
            }
        }

        private void HandleButtonSelection<TEnum>(Button clickedButton, Dictionary<Type, Button> selectedButtons, string enumValue)
        {
            // Parse the enum value
            TEnum selectedEnumValue = (TEnum)System.Enum.Parse(typeof(TEnum), enumValue);
            Type enumType = selectedEnumValue.GetType();
            if (enumType == typeof(GameMode))
                gameInit.GameMode = (GameMode)(object)selectedEnumValue;
            else if (enumType == typeof(GameSpeed))
                gameInit.GameSpeed = (GameSpeed)(object)selectedEnumValue;
            else if (enumType == typeof(GameSize))
                gameInit.GameSize = (GameSize)(object)selectedEnumValue;
            else if (enumType == typeof(FoodType))
                gameInit.FoodType = (FoodType)(object)selectedEnumValue;
            else if (enumType == typeof(FoodAmount))
                gameInit.FoodAmount = (FoodAmount)(object)selectedEnumValue;
            else if (enumType == typeof(SnakeColor))
                gameInit.SnakeColor = (SnakeColor)(object)selectedEnumValue;

            // Deselect the currently selected button for this group (if any)
            if (selectedButtons.ContainsKey(enumType))
            {
                Button previousButton = selectedButtons[enumType];
                SwitchStyle(previousButton);
                selectedButtons.Remove(enumType); // Remove old selection
            }

            // Select the new button
            SwitchStyle(clickedButton); // Set selected color
            selectedButtons[enumType] = clickedButton;

        }

        private void SelectItem(object obj)
        {
            MessageBox.Show($"Selected: {obj}");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SoundEffect.PlayOnOffSound();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(gameInit);
            mainWindow.Show();
            
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
