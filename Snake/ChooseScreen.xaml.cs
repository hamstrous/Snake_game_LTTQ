﻿using System;
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
        private readonly Dictionary<Type, Button> _selectedButtons = new();
        private GameInit gameInit = new GameInit();
        public UserControl1()
        {
            InitializeComponent();
            ClassicModeButton.Style = (Style)FindResource("ClassicMode2");
            _selectedButtons[typeof(GameMode)] = ClassicModeButton;
            MediumSizeButton.Style = (Style)FindResource("MediumSize2");
            _selectedButtons[typeof(GameSize)] = MediumSizeButton;
            MediumSpeedButton.Style = (Style)FindResource("MediumSpeed2");
            _selectedButtons[typeof(GameSpeed)] = MediumSpeedButton;
            OneFoodButton.Style = (Style)FindResource("One2");
            _selectedButtons[typeof(FoodAmount)] = OneFoodButton;
            AppleButton.Style = (Style)FindResource("Apple2");
            _selectedButtons[typeof(FoodType)] = AppleButton;
            BlueButton.Style = (Style)FindResource("Blue2");
            _selectedButtons[typeof(SnakeColor)] = BlueButton;

            gameInit.GameMode = GameMode.Classic;
            gameInit.GameSpeed = GameSpeed.Medium;
            gameInit.GameSize = GameSize.Medium;
            gameInit.FoodType = FoodType.Apple;
            gameInit.FoodAmount = FoodAmount.One;

            var allElements = GetAllElements(this);
            foreach (var element in allElements)
            {
                if (element is UIElement uiElement)
                {
                    uiElement.Focusable = false;
                }
            }
        }
        private List<DependencyObject> GetAllElements(DependencyObject parent)
        {
            var elements = new List<DependencyObject>();
            GetAllElementsRecursive(parent, elements);
            return elements;
        }

        private void GetAllElementsRecursive(DependencyObject parent, List<DependencyObject> elements)
        {
            if (parent == null) return;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                elements.Add(child);
                GetAllElementsRecursive(child, elements);
            }
        }

        private void SwitchStyle(Button button)
        {
            ResourceDictionary resourceDictionary = this.Resources.MergedDictionaries[0];

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
            SoundEffect.PlayOnOffSound();
            string[] tagParts = clickedButton.Tag.ToString().Split(',');
            string groupName = tagParts[0];
            string enumValue = tagParts[1];
            if (groupName == nameof(GameMode))
            {
                HandleButtonSelection<GameMode>(clickedButton, _selectedButtons, enumValue);
            }
            else if (groupName == nameof(GameSpeed))
            {
                HandleButtonSelection<GameSpeed>(clickedButton, _selectedButtons, enumValue);
            }
            else if (groupName == nameof(GameSize))
            {
                HandleButtonSelection<GameSize>(clickedButton, _selectedButtons, enumValue);
            }
            else if (groupName == nameof(FoodType))
            {
                HandleButtonSelection<FoodType>(clickedButton, _selectedButtons, enumValue);
            }
            else if (groupName == nameof(FoodAmount))
            {
                HandleButtonSelection<FoodAmount>(clickedButton, _selectedButtons, enumValue);
            }
            else if (groupName == nameof(SnakeColor))
            {
                HandleButtonSelection<SnakeColor>(clickedButton, _selectedButtons, enumValue);
            }
        }

        private void HandleButtonSelection<TEnum>(Button clickedButton, Dictionary<Type, Button> selectedButtons, string enumValue)
        {
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
            if (selectedButtons.ContainsKey(enumType))
            {
                Button previousButton = selectedButtons[enumType];
                SwitchStyle(previousButton);
                selectedButtons.Remove(enumType); 
            }

            SwitchStyle(clickedButton); 
            selectedButtons[enumType] = clickedButton;

        }

        private void SelectItem(object obj)
        {
            MessageBox.Show($"Selected: {obj}");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ResetButton_Click(sender, e);
            SoundEffect.PlayOnOffSound();
        }

        public PlayScreen playScreen;

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();
            GameInit tmp = new GameInit(gameInit);
            playScreen = new PlayScreen(tmp);
  
            playScreen.Visibility = Visibility.Visible;
            playScreen.IsEnabled = true;
            playScreen.CloseGame += PlayScreen_CloseGame;
            playScreen.GamePause.ExitEvent += PlayScreen_CloseGame;

            MainGrid.Children.Add(playScreen);
            Keyboard.Focus(playScreen);

        }

        private void PlayScreen_CloseGame(object sender, EventArgs e)
        {
            if (playScreen != null)
            {
                MainGrid.Children.Remove(playScreen);
                playScreen = null;
            }
            ResetButton_Click(null, null);
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            SoundEffect.PlayOnOffSound();
            int gameModeIndex = rnd.Next(0, 5);
            switch (gameModeIndex)
            {
                case 0:
                    HandleButtonSelection<GameMode>(ClassicModeButton, _selectedButtons, "Classic");
                    break;
                case 1:
                    HandleButtonSelection<GameMode>(ReverseModeButton, _selectedButtons, "Reverse");
                    break;
                case 2:
                    HandleButtonSelection<GameMode>(WallModeButton, _selectedButtons, "Wall");
                    break;
                case 3:
                    HandleButtonSelection<GameMode>(BoxModeButton, _selectedButtons, "Box");
                    break;
                case 4:
                    HandleButtonSelection<GameMode>(DirectionModeButton, _selectedButtons, "Direction");
                    break;
            }

            int gameSizeIndex = rnd.Next(0, 3);
            switch (gameSizeIndex)
            {
                case 0:
                    HandleButtonSelection<GameSize>(SmallSizeButton, _selectedButtons, "Small");
                    break;
                case 1:
                    HandleButtonSelection<GameSize>(MediumSizeButton, _selectedButtons, "Medium");
                    break;
                case 2:
                    HandleButtonSelection<GameSize>(LargeSizeButton, _selectedButtons, "Large");
                    break;
            }

            int gameSpeedIndex = rnd.Next(0, 3);
            switch (gameSpeedIndex)
            {
                case 0:
                    HandleButtonSelection<GameSpeed>(SlowSpeedButton, _selectedButtons, "Slow");
                    break;
                case 1:
                    HandleButtonSelection<GameSpeed>(MediumSpeedButton, _selectedButtons, "Medium");
                    break;
                case 2:
                    HandleButtonSelection<GameSpeed>(FastSpeedButton, _selectedButtons, "Fast");
                    break;
            }

            int foodAmountIndex = rnd.Next(0, 3);
            switch (foodAmountIndex)
            {
                case 0:
                    HandleButtonSelection<FoodAmount>(OneFoodButton, _selectedButtons, "One");
                    break;
                case 1:
                    HandleButtonSelection<FoodAmount>(ThreeFoodButton, _selectedButtons, "Three");
                    break;
                case 2:
                    HandleButtonSelection<FoodAmount>(FiveFoodButton, _selectedButtons, "Five");
                    break;
            }

            int snakeColorIndex = rnd.Next(0, 6);
            switch (snakeColorIndex)
            {
                case 0:
                    HandleButtonSelection<SnakeColor>(RedButton, _selectedButtons, "Red");
                    break;
                case 1:
                    HandleButtonSelection<SnakeColor>(CyanButton, _selectedButtons, "Cyan");
                    break;
                case 2:
                    HandleButtonSelection<SnakeColor>(BlueButton, _selectedButtons, "Blue");
                    break;
                case 3:
                    HandleButtonSelection<SnakeColor>(PinkButton, _selectedButtons, "Pink");
                    break;
                case 4:
                    HandleButtonSelection<SnakeColor>(PurpleButton, _selectedButtons, "Purple");
                    break;
                case 5:
                    HandleButtonSelection<SnakeColor>(OrangeButton, _selectedButtons, "Orange");
                    break;
            }

            int foodTypeIndex = rnd.Next(0, 5);
            switch (foodTypeIndex)
            {
                case 0:
                    HandleButtonSelection<FoodType>(AppleButton, _selectedButtons, "Apple");
                    break;
                case 1:
                    HandleButtonSelection<FoodType>(RadishButton, _selectedButtons, "Radish");
                    break;
                case 2:
                    HandleButtonSelection<FoodType>(PeachButton, _selectedButtons, "Peach");
                    break;
                case 3:
                    HandleButtonSelection<FoodType>(BananaButton, _selectedButtons, "Banana");
                    break;
                case 4:
                    HandleButtonSelection<FoodType>(GrapeButton, _selectedButtons, "Grape");
                    break;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayOnOffSound();

            SwitchStyle(_selectedButtons[typeof(GameMode)]);
            _selectedButtons.Remove(typeof(GameMode));
            ClassicModeButton.Style = (Style)FindResource("ClassicMode2");
            _selectedButtons[typeof(GameMode)] = ClassicModeButton;

            SwitchStyle(_selectedButtons[typeof(GameSize)]);
            _selectedButtons.Remove(typeof(GameSize));
            MediumSizeButton.Style = (Style)FindResource("MediumSize2");
            _selectedButtons[typeof(GameSize)] = MediumSizeButton;

            SwitchStyle(_selectedButtons[typeof(GameSpeed)]);
            _selectedButtons.Remove(typeof(GameSpeed));
            MediumSpeedButton.Style = (Style)FindResource("MediumSpeed2");
            _selectedButtons[typeof(GameSpeed)] = MediumSpeedButton;

            SwitchStyle(_selectedButtons[typeof(FoodAmount)]);
            _selectedButtons.Remove(typeof(FoodAmount));
            OneFoodButton.Style = (Style)FindResource("One2");
            _selectedButtons[typeof(FoodAmount)] = OneFoodButton;

            SwitchStyle(_selectedButtons[typeof(FoodType)]);
            _selectedButtons.Remove(typeof(FoodType));
            AppleButton.Style = (Style)FindResource("Apple2");
            _selectedButtons[typeof(FoodType)] = AppleButton;

            SwitchStyle(_selectedButtons[typeof(SnakeColor)]);
            _selectedButtons.Remove(typeof(SnakeColor));
            BlueButton.Style = (Style)FindResource("Blue2");
            _selectedButtons[typeof(SnakeColor)] = BlueButton;

            gameInit.GameMode = GameMode.Classic;
            gameInit.GameSpeed = GameSpeed.Medium;
            gameInit.GameSize = GameSize.Medium;
            gameInit.FoodType = FoodType.Apple;
            gameInit.FoodAmount = FoodAmount.One;
            gameInit.SnakeColor = SnakeColor.Blue;
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