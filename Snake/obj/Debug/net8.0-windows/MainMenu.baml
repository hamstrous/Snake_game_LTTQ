   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.MainMenu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  Snake��5   	   $	��800��6   $
��1000��6$    � WindowStartupLocation$ CenterScreen=�61    � 
ResizeMode$ NoResize=�6V   -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=�5
   	      ControlTabNavigation$
 None=�5   	      DirectionalNavigation$
 None=�5   	   $|�False��5   	    � Icon$ Assets/icon.ico��5   	    � WindowStyle$
 None=�5   	    � FocusVisualStyle 5	   	   Z� ��5      �� 5   
   	 �� ImageSource$#	 Assets/MainMenuBackground.jpg��6   
 j� Stretch$
 UniformToFill=�6A    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      � .+�5   
   (� .��5      � $
 None=�6   $
 None=�5      $
 None=�5       .+�5!      � $	��800��6   $
��1000��6$    � RowDefinitions 5"      �� 5#      $
��0.8* �6(   �� 5$      $��1* �6(   �� 5%      $��1* �6(   �� 5&      $��1* �6(   �� 5'      $��1* �6(   �� 5(      $
��0.8* �6(   .+�5+      �� -   5           Tutorial#��[  5+      $��0��6A   $��90��5,      $��80��6*   $��
897,10,0,0q�65   �� 51      $��/MainMenu/board.png��6   $
��Fill=�69   $��1��6H   $	��116��52      $	��248��6    J� IsHitTestVisible$ False��6*   $��Center=�6C   $��Center=�6`   �� 53      -   5        $
��PLAY��53      $��1��6,   $	��102��54      $	��224��55      $��50(�56      $#��Gloucester MT Extra Condensed)�57      
������ 
������ $��2q�5:      $��Center=�5;      $��Center=�5=      ��5>      �� 5?       �� 
TargetType" ��6.   .R�5@   "   �� #��z��6)   #��z��5A      #��z��5B       �� CornerRadius$ 15��5C      ._�5D   &   �� $��Center=�67   $��Center=�6T   5E   #    �� Triggers 5F   "   P� 5G   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5H   *   ��  �� Property � �� �� Value
 �����6G   5I   '   5K      5M      �� 5O      $��/MainMenu/board.png��6   $
��Fill=�69   $��2��6H   $	��116��6U   $	��248��6b   $ False��6n   $��Center=�6�   �� 5P      -   5        $��LEADERBOARD��5P      $��2��63   $	��102��5Q      $	��224��5R      $��43(�5S      $#��Gloucester MT Extra Condensed)�5T      
������ 
������ $��2q�5W      $��Center=�5X      ��5Z      �� 5[      " ��6.   .R�5\   "   �� #��z��6)   #��z��5]      #��z��5^      $ 15��5_      ._�5`   &   �� $��Center=�67   $��Center=�6T   5a   #    5b   "   P� 5c   &    �@J�IsMouseOver$
 True��6E   . �5d   *   ��  � ��
 �����6G   5e   '   5g      5i      �� 5k      $��/MainMenu/board.png��6   $
��Fill=�69   $��3��6H   $	��116��6U   $	��248��6b   $ False��6n   $��Center=�6�   $��Center=�6�   �� 5l      -   5        $��SETTING��5l      $��3��6/   $	��102��5m      $	��224��5n      $��50(�5o      $#��Gloucester MT Extra Condensed)�5p      
������ 
������ $��2q�5s      $��Center=�5t      $��Center=�5u      ��5w      �� 5x      " ��6.   .R�5y   "   �� #��z��6)   #��z��5z      #��z��5{      $ 15��5|      ._�5}   &   �� $��Center=�67   $��Center=�6T   5~   #    5   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � ��
 �����6G   5�   '   5�      5�      �� 5�      $��/MainMenu/board.png��6   $
��Fill=�69   $��4��6H   $	��116��6U   $	��248��6b   $ False��6n   $��Center=�6�   $��Center=�6�   �� 5�      -   5        $
��EXIT��5�      $��4��6,   $	��102��5�      $	��224��5�      $��50(�5�      $#��Gloucester MT Extra Condensed)�5�      
������ 
������ $��2q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� #��z��6)   #��z��5�      #��z��5�      $ 15��5�      ._�5�   &   �� $��Center=�67   $��Center=�6T   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � ��
 �����6G   5�   '   5�      5�      5�      5�      5�         Snake.SettingExit2  5�   
   -   5          Name$
 Exit��5�      $y�	Collapsed=�6+    K� ZIndex$ 1��6B      Snake.Setting  5�   
   -   5          Name$ SettingControl��5�      $y�	Collapsed=�60   $ 1��6G      Snake.UserControl1  5�   
   -   5          Name$ 
ChooseMode��5�      $y�	Collapsed=�62   $ 1��6I   $
 None=�5�      $
 None=�5�      $
 None=�5�      $|�False��5�         Snake.Leaderboard2  5�   
   -	   5          Name$ Leaderboard2��5�      $y�	Collapsed=�63   $ 1��6J      Snake.Tutorial  5�   
   -
   5          Name$
 Book��5�      $y�	Collapsed=�6'   $ 1��6>      Snake.Tutorial2  5�   
   -   5          Name$ Book2��5�      $y�	Collapsed=�6)   $ 1��6@      Snake.Tutorial3  5�   
   -   5          Name$ Book3��5�      $y�	Collapsed=�6)   $ 1��6@   5�      5�      