   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.MainMenu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  MainMenu��5   	   $	��800��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y   ��5
      �� 5   
    �� ImageSource$# Assets/MainMenuBackground.jpg��6    j� Stretch$ UniformToFill=�6A   .��5      � .+�5   
      Snake.Setting  -   5          Name$ Setting��5      $��Center=�6)   $��Center=�6F   $y�	Collapsed=�6a    K� ZIndex$ 1��6x      Snake.UserControl1  5   
   -   5          Name$ 
ChooseMode��5      $y�	Collapsed=�62   $ 1��6I   �� 5   
   $��/MainMenu/board.png��6   $
��Fill=�6-   $��Center=�5      $	��116��6)   $��0,91,0,0q�66   $	��Top=�6H   $	��248��6`    J� IsHitTestVisible$ False��5      �� 5   
   -   5        $
��PLAY��5      $��0,98,0,0q�5      $	��Top=�5      $	��102��5      $	��224��5      $��50(�5      $#��Gloucester MT Extra Condensed)�5      
������ 
������ $��2q�5      $��Center=�5      $��Center=�5      $��Center=�5       ��5"      �� 5#      	 �� 
TargetType"	 ��6"   .R�5$      �� #��z��6   #��z��5%      #��z��5&      
 �� CornerRadius$
 15��5'      ._�5(      ��  ��Name$ ContentPresenter��6c   $��Center=�6+   $��Center=�6H   6c   5)       �� Triggers 5*      P� 5+       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5,      ��  �� 
TargetName$ ContentPresenter��6%    �� Property � �� �� Value
 �����6e   5-      5/      51      �� 53   
   $��/MainMenu/board.png��6   $
��Fill=�6-   $��Center=�54      $	��116��6.   $��	0,234,0,0q�6;   $	��Top=�6N   $	��248��6f   $ False��55      �� 56   
   -   5        $��LEADERBOARD��56      $��	0,241,0,0q�57      $	��Top=�58      $	��102��59      $	��224��5:      $��43(�5;      $#��Gloucester MT Extra Condensed)�5<      
������ 
������ $��2q�5?      $��Center=�5@      $��Center=�5A      $��Center=�5B      ��5D      �� 5E      "	 ��6"   .R�5F      �� #��z��6   #��z��5G      #��z��5H      $
 15��5I      ._�5J      �� $ ContentPresenter��6c   $��Center=�6+   $��Center=�6H   6c   5K       5L      P� 5M       �@J�IsMouseOver$
 True��69   . �5N      �� $ ContentPresenter��6%    � ��
 �����6e   5O      5Q      5S      �� 5W   
   $��/MainMenu/board.png��6   $
��Fill=�6-   $��Center=�5X      $	��116��6-   $��	0,383,0,0q�6:   $	��Top=�6M   $	��248��6e   $ False��5Y      �� 5Z   
   -   5        $��SETTING��5Z      $��	0,390,0,0q�5[      $	��Top=�5\      $	��102��5]      $	��224��5^      $��50(�5_      $#��Gloucester MT Extra Condensed)�5`      
������ 
������ $��2q�5c      $��Center=�5d      $��Center=�5e      $��Center=�5f      ��5h      �� 5i      "	 ��6"   .R�5j      �� #��z��6   #��z��5k      #��z��5l      $
 15��5m      ._�5n      �� $ ContentPresenter��6c   $��Center=�6+   $��Center=�6H   6c   5o       5p      P� 5q       �@J�IsMouseOver$
 True��69   . �5r      �� $ ContentPresenter��6%    � ��
 �����6e   5s      5u      5w      �� 5|   
   $��/MainMenu/board.png��6   $
��Fill=�6-   $��Center=�5}      $	��116��6*   $��	0,529,0,0q�67   $	��Top=�6J   $	��248��6b   $ False��5~      �� 5�   
   -   5        $
��EXIT��5�      $��	0,536,0,0q�5�      $	��Top=�5�      $	��102��5�      $	��224��5�      $��50(�5�      $#��Gloucester MT Extra Condensed)�5�      
������ 
������ $��2q�5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      ��5�      �� 5�      "	 ��6"   .R�5�      �� #��z��6   #��z��5�      #��z��5�      $
 15��5�      ._�5�      �� $ ContentPresenter��6c   $��Center=�6+   $��Center=�6H   6c   5�       5�      P� 5�       �@J�IsMouseOver$
 True��69   . �5�      �� $ ContentPresenter��6%    � ��
 �����6e   5�      5�      5�      5�      5�      