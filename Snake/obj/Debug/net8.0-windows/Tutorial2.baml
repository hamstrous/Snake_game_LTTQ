   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5          Snake.Tutorial2   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Snake     5      ��5	      �� 5
   
     �� ImageSource$#  Assets/MainMenuBackground.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      (� .��5   
   � $	��800��6   $
��1000��6   .+�5      �� $��LeaderBoard/board.png��6   $
��Fill=�63   $��	82,0,82,0q�6B   �� 5      -   5           X#��[  5   (   $��Button��6C   $
��Left=�6T   $��
804,27,0,0q�6o   $	��Top=�6�   $��76��6�   $��68��6�   �� 5      -   5          
Left-Arrow#��[ 5      $��Button��69   $��10,0,0,0q�5      $��70��6(   $��72��64   $��Center=�6?   �� 5      $��Center=�6   
�������$��0,81,0,0q�5      $
��Wrap=�6   $	��Top=�62   $��65��6J   $	��209��6V   $��50(�5      $#��Gloucester MT Extra Condensed)�6   $
��Bold"�5      $��
GAME MODES��6   �� 5       $
��Left=�6   
�������$#��Gloucester MT Extra Condensed)�5!   %   $��286,159,0,0q�5"      $
��Wrap=�6&   $	��Top=�6:   $	��531��6R   $��35(�6^    �� TextAlignment$ Justify=�6m   �� 5#      $9�3Classic Mode: The snake eats food and grows longer.��6   5$      �� 5%      $��150,114,714,556q�6   $��/Choose/Classic.png��6-   $
��Fill=�6J   �� 5&      $
��Left=�6   
�������$#��Gloucester MT Extra Condensed)�5'   $   $��287,258,0,0q�5(      $
��Wrap=�6&   $	��Top=�6:   $	��547��6R   $��35(�6^   $ Justify=�6m   �� 6�   $D�>Box Mode: The snake pushes a box to the target to obtain food.��6�   6�   �� 5)      $��151,234,718,436q�6   $��/Choose/Box.png��6-   $
��Fill=�6F   �� 5*      $
��Left=�6   
�������$#��Gloucester MT Extra Condensed)�5+   $   $��291,369,0,0q�5,      $
��Wrap=�6&   $	��Top=�6:   $	��547��6R   $��35(�6^   $ Justify=�6m   �� 6�   $S�MWall Mode: When the snake eats food, random walls are generated as obstacles.��6�   6�   �� 5-      $��146,346,713,327q�6   $��/Choose/Wall.png��6-   $
��Fill=�6G   �� 5.      $
��Left=�6   
�������$#��Gloucester MT Extra Condensed)�5/   $   $��292,483,0,0q�50      $
��Wrap=�6&   $	��Top=�6:   $	��547��6R   $��35(�6^   $ Justify=�6m   �� 6�   $P�JReverse Mode: When the snake eats food, its direction of movement changes.��6�   6�   �� 51      $��150,461,709,214q�6   $��/Choose/Reverse.png��6-   $
��Fill=�6J   �� 52      $
��Left=�6   
�������$#��Gloucester MT Extra Condensed)�53   $   $��292,580,0,0q�54      $
��Wrap=�6&   $	��Top=�6:   $	��547��6R   $��35(�6^   $ Justify=�6m   �� 6�   $��}Direction Mode: At specific tiles, the snake changes direction, but when turning back, it must follow its previous direction.��6�   6  �� 55      $��141,569,718,98q�6   $��/Choose/Direction.png��6,   $
��Fill=�6K   �� 56      -   5          Right-Arrow#��[ 56      $��Button��6:   $��	904,0,0,0q�57      $��Center=�6$   $��70��6@   $��72��6L   58      5:      5;      