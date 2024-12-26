using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Snake
{
    public partial class MainMenu : Window
    {

        private Setting settingControl;
        public MainMenu()
        {
            InitializeComponent();
            SoundEffect.PlayBGM();
            this.Loaded += MainMenu_Loaded;
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            // Call the method to set Focusable to false for all elements
            SetAllElementsFocusable(this, false);
        }

        // Method to set Focusable property for all elements in the visual tree
        private void SetAllElementsFocusable(DependencyObject parent, bool focusable)
        {
            if (parent == null) return;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is UIElement uiElement)
                {
                    uiElement.Focusable = focusable;
                }

                // Recursively set Focusable for child elements
                SetAllElementsFocusable(child, focusable);

                // Handle ContentControl and ItemsControl separately
                if (child is ContentControl contentControl && contentControl.Content is DependencyObject content)
                {
                    SetAllElementsFocusable(content, focusable);
                }
                else if (child is ItemsControl itemsControl)
                {
                    foreach (var item in itemsControl.Items)
                    {
                        if (item is DependencyObject itemContent)
                        {
                            SetAllElementsFocusable(itemContent, focusable);
                        }
                    }
                }
            }
        }
        public PlayScreen playScreen;

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            /*
                        ChooseScreen chooseScreen = new ChooseScreen();
                        chooseScreen.Show();

                        this.Close();*/
            SoundEffect.PlayOnOffSound();
            ChooseMode.Visibility = Visibility.Visible;
            playScreen = ChooseMode.playScreen;
            ChooseMode.Focus();
            Keyboard.Focus(ChooseMode);
        }

        private void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            /*Leaderboard leaderboard = new Leaderboard();
            leaderboard.Show();
            this.Close();*/


            Leaderboard2.Visibility = Visibility.Visible;
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            SettingControl.Visibility = Visibility.Visible; // Sửa Setting thành SettingControl
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            SoundEffect.PlayButtonSound();
            Exit.Visibility = Visibility.Visible;
        }
    }
}