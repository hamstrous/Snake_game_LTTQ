   M S B A M L   `   `   `  ���� @  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake      Snake.PlayScreen   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Snake     -   $	��800��$
��1000��$	��300��$	��300��   BackgroundColor#��[    	TextColor#��[   MainFont#��[ $
|�True��.��(� .���   � RowDefinitions  �� $	��80* ��� $	��19* ��� $	��61* �.+�� $��3��  �� $
��auto ��� $��* ��� $��15 �.+��� -    ��Name$ 	ScoreText��$
��Left=�$��Center=�$��SCORE 0��$��22(�$��10q��� -   $ HighScoreText��$��Right=�$��Center=�$��HIGHSCORE 0��$��22(�$��10q�A� -    A�Name$ BackGroundGrid��$	��400��$	��400��$��Center=�$��Center=� �� EdgeMode$ Aliased=�$��
20,0,20,20q�$��1��  GridBackgroundColor#��[  J� SnapsToDevicePixels$
 True�� �� BitmapScalingMode$ HighQuality=�A� -   $ GameGrid��$	��400��$	��400��$��Center=�$��Center=�$ Aliased=�$��
20,0,20,20q�$��1��$
 True��$ HighQuality=�$
|�True�� � FocusVisualStyle Z� �� -   $ OverlayText��$�� ��$��30(�$
��Bold"�$��Center=�$��Center=�$��
20,0,20,20q�$��1��$
��Wrap=��� -   $��Canva��$ HighQuality=�$��
20,0,20,20q�$��1��$
 True���� $��3��$��-30,0,-30,0q�.+�� ���� *ActualWidth+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Canvas���� *ActualHeight+ �� *FindAncestor+
 Canvas.+�   Snake.SettingGameOver  -   	  Name$	 GameOver��$y�	Collapsed=�
 K� ZIndex$
 1��$��Center=�$��Center=�   Snake.SettingGamePause  -	     Name$ 	GamePause��$y�	Collapsed=�$
 1��$��Center=�$��Center=�