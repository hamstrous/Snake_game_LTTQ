   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5          Snake.Setting   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Snake     5      ��5	      �� 5
   
     �� ImageSource$#  Assets/MainMenuBackground.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      � .+�5   
   (� .��5      � .+�5      �� $��/Setting/board.png��6   $	��375��65   $��Center=�6C   $
��Fill=�6^   $��	98,0,98,0q�6m   �� 5      -   5         ��Name$
 Back��5         X#��[  6A   $��66��6\   $��59��6h   $��
519,10,0,0q�6s   �� 5      -   5        $��	SFX_image��5      $��/Setting/sound-on.png��5   	   $
��Fill=�6(   $
��Left=�5   	   $	��141��6$   $��	154,0,0,0q�61   $��Center=�6D   $	��123��6_    J� IsHitTestVisible$ False��5   	   �� 5      -   5        $ SFX_btn��5      $��	154,0,0,0q�5      $��Center=�5      $	��141��5       $	��123��5!      
������ 
������ $��2q�5$      $
��Left=�5%      $��Center=�5&      $��Center=�5'      ��5)      �� 5*       �� 
TargetType" ��6*   .R�5+      �� #��z��6%   #��z��5,      #��z��5-       �� CornerRadius$ 15��5.      ._�5/   "   ��  ��Name$ ContentPresenter��6k   $��Center=�63   $��Center=�6P   6k   50      	 �� Triggers	 51      P� 52   "   
 P� Property
 �@J�IsMouseOver P� Value$
 True��6A   . �53   &   ��  �� 
TargetName$ ContentPresenter��6-    �� Property � �� �� Value
 �����6m   54   #   56      58      �� 5;      -   5        $��	BGM_image��5;      $��/Setting/SFX-on.png��5<      $
��Fill=�6   $
��Left=�5=      $	��141��6   $��Center=�6)   $	��122��6D   $ False��5>      $��	295,0,0,0q�6   �� 5?      -   5        $ BGM_btn��5?      $��Center=�5@      $	��141��5A      $	��122��5B      
������ 
������ $��2q�5E      $
��Left=�5F      $��Center=�5G      $��Center=�5H       J� RenderTransformOrigin$ 	0.528,0.5&�5I      $��	295,0,0,0q�6:   ��5J      �� 5K      " ��6*   .R�5L      �� #��z��6%   #��z��5M      #��z��5N      $ 15��5O      ._�5P   "   �� $ ContentPresenter��6k   $��Center=�63   $��Center=�6P   6k   5Q      	 5R      P� 5S   "   
 �@J�IsMouseOver$
 True��6A   . �5T   &   �� $ ContentPresenter��6-    � ��
 �����6m   5U   #   5W      5Y      �� 5[      -   5         ��Name$ Window_image��5[      $��/Setting/Sizeup.png��5\      $
��Fill=�6"   $
��Left=�5]      $	��141��6    $��	433,0,0,0q�6-   $��Center=�6@   $	��124��6[   $ False��5^      �� 5_      -   5        $ 
Window_btn��5_      $��Center=�5`      $	��141��5a      $	��124��5b      
������ 
������ $��2q�5e      $
��Left=�5f      $��Center=�5g      $��Center=�5h      $��	433,0,0,0q�5i      ��5j      �� 5k      " ��6*   .R�5l      �� #��z��6%   #��z��5m      #��z��5n      $ 15��5o      ._�5p   "   �� $ ContentPresenter��6k   $��Center=�63   $��Center=�6P   6k   5q      	 5r      P� 5s   "   
 �@J�IsMouseOver$
 True��6A   . �5t   &   �� $ ContentPresenter��6-    � ��
 �����6m   5u   #   5w      5y      5z      5{      5|      5}      