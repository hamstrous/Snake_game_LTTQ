   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.PlayScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	   -   5        $	��800��5   	   $
��1000��6   $	��300��5	   	   $	��300��6      BackgroundColor#��[  5
   	     	TextColor#��[ 5   	     MainFont#��[ 5   	   $
|�True��5   	   .��5      (� .��5   
   �   � RowDefinitions  5      �� 5      $	��80* �6    �� 5      $	��19* �6    �� 5      $	��61* �6    .+�5      � $��3��6     5      �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $��15 �6$   .+�5      �� -   5         ��Name$ 	ScoreText��5      $
��Left=�5      $��Center=�5       $��SCORE 0��5!      $��22(�5"      $��10q�5#      �� 5%      -   5        $ HighScoreText��5%      $��Right=�5&      $��Center=�5'      $��HIGHSCORE 0��5(      $��22(�5)      $��10q�5*      A� 5,      -   5         A�Name$ BackGroundGrid��5,      $	��400��5-      $	��400��5.      $��Center=�5/      $��Center=�50       �� EdgeMode$ Aliased=�51      $��
20,0,20,20q�52      $��1��53        GridBackgroundColor#��[ 54       J� SnapsToDevicePixels$
 True��55       �� BitmapScalingMode$ HighQuality=�56      57      A� 59      -   5        $ GameGrid��59      $	��400��5:      $	��400��5;      $��Center=�5<      $��Center=�5=      $ Aliased=�5>      $��
20,0,20,20q�5?      $��1��5@      $
 True��5A      $ HighQuality=�5B      $
|�True��5C       � FocusVisualStyle 59   0   Z� 5D      �� 5E      -   5        $ OverlayText��5E      $�� ��5F      $��30(�5G      $
��Bold"�5H      $��Center=�5I      $��Center=�5J      $��
20,0,20,20q�5K      $��1��5L      $
��Wrap=�5M      �� 5N      -   5        $��Canva��5N   G   $ HighQuality=�6   $��
20,0,20,20q�6T   $��1��6h   $
 True��6u   5P      �� 5Q      $��3��6   $��-30,0,-30,0q�6&   .+�5R      � ��6   �� *ActualWidth+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Canvas��5S      �� *ActualHeight+ �� *FindAncestor+
 Canvas.+�5U         Snake.SettingGameOver  -   5        	  Name$	 GameOver��5U   ,   $y�	Collapsed=�5V      
 K� ZIndex$
 1��5W      $��Center=�5X      $��Center=�5Y         Snake.SettingGamePause  5[      -	   5          Name$ 	GamePause��5[   -   $y�	Collapsed=�5\      $
 1��5]      $��Center=�5^      $��Center=�5_      5`      5a      5b      5d      5e      