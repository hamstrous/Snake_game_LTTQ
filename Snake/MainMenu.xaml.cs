using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Snake
{
    public partial class MainMenu : Window
    {

        private Setting settingControl;
        public MainMenu()
        {
            InitializeComponent();

            this.Loaded += MainMenu_Loaded;
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            SetAllElementsFocusable(this, false);

        }

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
                SetAllElementsFocusable(child, focusable);
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
            SoundEffect.PlayOnOffSound();
            ChooseMode.Visibility = Visibility.Visible;
            playScreen = ChooseMode.playScreen;
            ChooseMode.Focus();
            Keyboard.Focus(ChooseMode);
        }

        private async void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            Leaderboard2.Visibility = Visibility.Visible;
            await Leaderboard2.RefreshDataAsync(); 
        }


        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            if (SoundEffect.CanPlayBGM)
            {
                SettingControl.BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-on.png", UriKind.Relative));
                
            }
            else
            {
                SettingControl.BGM_image.Source = new BitmapImage(new Uri("/Setting/SFX-off.png", UriKind.Relative));
            }

            if (SoundEffect.CanPlaySFX)
            {
                SettingControl.SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-on.png", UriKind.Relative));
            }
            else
            {
                SettingControl.SFX_image.Source = new BitmapImage(new Uri("/Setting/sound-off.png", UriKind.Relative));
            }
            SettingControl.Visibility = Visibility.Visible; 
        }

        private void Book_click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            Book.Visibility = Visibility.Visible;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect.PlayButtonSound();
            Exit.Visibility = Visibility.Visible;
        }
    }
}