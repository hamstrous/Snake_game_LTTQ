   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.SignUp   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  Sign Up��5   	   $	��800��6   $
��1000��6&    � 
ResizeMode$ NoResize=�5	   	    � Icon$ Assets/icon.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� ImageSource$ Sigin-up\background.jpg��6   6=    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      (� .��5   
   � .+�5      �� -   5         ��Name$ btnBack��5       
  button#��[  5      $��2q�5      $
��Back��5   4   $	��100��6C   $	��200��6P   $��45(�6\   $��0,531,551,0q�6j   $	��Top=�5      $��Right=�6%   �� 5      -   5        $ btnCreateAccount��5"        signinbutton#��[ 5       $��0q�5!      $��Create��5"   F   $	��100��6W   $	��200��6d   $��45(�6p   $��0,531,262,0q�6~   $	��Top=�5#      $��Right=�6%   �� 5$      $��84��6   $��CREATE ACCOUNT��5%      $��Center=�5&      $��Medium"�5'      $��80(�5(      $#��Gloucester MT Extra Condensed)�5)      ���#31511E$��0,149,0,551q�5*   #   5+      �� 5-      -   5        	 ��Name$	 txtErrorMessage��5-      $�� ��61   
���  ��$��25(�6J   $��Center=�6X   $
��Wrap=�6v   
 �� TextAlignment$
 Center=�6�   $��0,234,0,495q�6�   $
��1000��6�   �� 50      $��Username��51      $
��Left=�52      $��Light"�53      $��50(�54      $#��Gloucester MT Extra Condensed)�55      $	��Top=�56      ���#54473F$	��288��57   #   $��69��6/   $��343,264,0,0q�6<   �� 59      -   5         ��Name$ txtUser��59      $��40(�5:      $��Medium"�5;      
������  �� 
CaretBrush
 �   ����#54473F
���   �$��0,0,0,1q�5@      $��347,315,368,420q�5A      $	��285��6%   �� 5D      $��Password��5E      $
��Left=�5F      $��Light"�5G      $��50(�5H      $#��Gloucester MT Extra Condensed)�5I      $	��Top=�5J      ���#54473F$	��288��5K      $��69��6#   $��343,400,0,0q�60   �� 5M      -   5        $ txtPass��5M      $��40(�5N      $��Medium"�5O      
������ 
 �   ����#54473F
���   �$��0,0,0,1q�5T      $��345,449,370,290q�5U      $	��285��6&   .��62   5W      5X      5Y      5Z      