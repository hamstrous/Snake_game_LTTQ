   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.SignUp   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  Sign Up��5   	   $	��600��6   $	��450��6&    � 
ResizeMode$ NoResize=�5	   	    � Icon$ Assets/icon.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Sigin-up/background.jpg��6   	 j� Stretch$
	 Fill=�5      ._�5   
   �� 
 �� Orientation$
 Vertical=�6   $��70,103,70,55q�5      .+�5      �� $��84��6   $��CREATE ACCOUNT��5      $��Center=�5      $��Medium"�5      $��45(�5      $#��Gloucester MT Extra Condensed)�5       ���#31511E5"      �� 5$      -   5         ��Name$ txtErrorMessage��5$      $�� ��61   
���  ��$��25(�6J   $��Center=�6X   $��0,0,0,10q�6u   $y�	Collapsed=�6�   �� 5'      $��37��6   $��Username��5(      $��Center=�5)      $��Light"�5*      $��30(�5+      $#��Gloucester MT Extra Condensed)�5,      ���#54473F$	��286��5-   !   5.      �� 50      -   5         ��Name$ txtUser��50      $��20(�51      $��Medium"�52      
������  �� 
CaretBrush
 �   ����#54473F
���   �$��0,0,0,1q�57      $��0,5,0,0q�58      $	��285��6'   $��28��59      .��6"   5;      �� 5>      $��34��6   $��Password��5?      $��Center=�5@      $��Light"�5A      $��30(�5B      $#��Gloucester MT Extra Condensed)�5C      ���#54473F$	��286��5D   *   $��0,25,0,0q�5E      5F      �� 5H      -   5        $ txtPass��5H      $��20(�5I      $��Medium"�5J      
������ 
 �   ����#54473F
���   �$��0,0,0,1q�5O      $��0,5,0,40q�5P      $	��285��6   .��6)   5R      � 5T      $��61��6   $	��315��6    J� RenderTransformOrigin$ 0.513,0.521&�6+    � ColumnDefinitions 5U      �� 5V      $	��78* �6'   �� 5W      $	��77* �6'   .+�5Y      �� -   5         ��Name$ btnBack��5\      $��0��5Y       
  button#��[  5Z      $��2q�5[      $
��Back��5\   <   $	��120��6K   $��23(�6W   $��	10,0,29,0q�6e   5]      �� 5`      -   5        $ btnCreateAccount��5c      $��1��5`        signinbutton#��[ 5a      $��0q�5b      $��Create��5c   R   $	��112��6c   $��23(�6o   $��	22,0,22,0q�6}   5e      5g      5h      5i      5j      