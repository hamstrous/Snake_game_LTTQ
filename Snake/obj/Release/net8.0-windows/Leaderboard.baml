   M S B A M L   `   `   `  ���� @  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake      Snake.Leaderboard2   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     %localclr-namespace:Snake       � 	Resources   �� MergedDictionaries �� Source��  �� $ resources/dic.xaml?�%    ����  �� ImageSource$! /LeaderBoard/lightbrown.jpg��.��(�  (� Stretch$ Uniform=�.��� $	��800��$
��1000�� � RowDefinitions �� $��2* ��� $��6* �.+��� $��2��
���   � �� CornerRadius$ 10��$��110,20,110,20q�._�� ���� $ /Leaderboard/board.png�� j� Stretch$
 Fill=� � ColumnDefinitions �� $��1* ��� $��2* ��� $��1* �.+��� -   	 ��Name$
	 stt1��$��Lobster)�$��Center=�$	��Top=�$��	40,90,0,0q�$��1.��$��50(�$��0��$y�Hidden=����#FFD700�� -   $
	 stt2��$��Lobster)�$��Center=�$	��Top=�$��
40,170,0,0q�$��2.��$��40(�$��0��$y�Hidden=����#FFD700�� -   $
	 stt3��$��Lobster)�$��Center=�$	��Top=�$��
40,250,0,0q�$��3.��$��35(�$��0��$y�Hidden=����#FFD700�� -   $
	 stt4��$��Lobster)�$��Center=�$	��Top=�$��
40,330,0,0q�$��4.��$��33(�$��0��$y�Hidden=����#F5F5DC�� -   $
	 stt5��$��Lobster)�$��Center=�$	��Top=�$��
40,410,0,0q�$��5.��$��33(�$��0��$y�Hidden=����#F5F5DC�� -   $	 name1��$#��Gloucester MT Extra Condensed)�$��Center=�$	��Top=�$��0,90,0,0q�$��	TextBlock��$��50(�$��1��$y�Hidden=����#FFD700�� -   $	 name2��$#��Gloucester MT Extra Condensed)�$��Center=�$	��Top=�$��	0,170,0,0q�$��	TextBlock��$��40(�$��1��$y�Hidden=����#FFD700�� -   $	 name3��$#��Gloucester MT Extra Condensed)�$��Center=�$	��Top=�$��	0,250,0,0q�$��	TextBlock��$��35(�$��1��$y�Hidden=����#FFD700�� -	   $	 name4��$#��Gloucester MT Extra Condensed)�$��Center=�$	��Top=�$��	0,330,0,0q�$��	TextBlock��$��33(�$��1��$y�Hidden=����#F5F5DC�� -
   $	 name5��$#��Gloucester MT Extra Condensed)�$��Center=�$	��Top=�$��	0,410,0,0q�$��	TextBlock��$��33(�$��1��$y�Hidden=����#F5F5DC�� -   $	 score1��$#��Gloucester MT Extra Condensed)�$
��Left=�$	��Top=�$��	15,90,0,0q�$��	TextBlock��$��50(�$��2��$y�Hidden=����#FFD700�� -   $	 score2��$#��Gloucester MT Extra Condensed)�$
��Left=�$	��Top=�$��
18,170,0,0q�$��	TextBlock��$��40(�$��2��$y�Hidden=����#FFD700�� -   $	 score3��$#��Gloucester MT Extra Condensed)�$
��Left=�$	��Top=�$��
20,250,0,0q�$��	TextBlock��$��35(�$��2��$y�Hidden=����#FFD700�� -   $	 score4��$#��Gloucester MT Extra Condensed)�$
��Left=�$	��Top=�$��
20,330,0,0q�$��	TextBlock��$��33(�$��2��$y�Hidden=����#F5F5DC�� -   $	 score5��$#��Gloucester MT Extra Condensed)�$
��Left=�$	��Top=�$��
20,410,0,0q�$��	TextBlock��$��33(�$��2��$y�Hidden=����#F5F5DC�� $��Center=�$	��185��$	��Top=�$	��414��$#��Leaderboard/choose-button.png��$
��Fill=�$��0,15,0,0q��� $��0��$��Center=�$��0,30,0,0q�$
��Wrap=�$��LEADERBOARD��$	��Top=�$#��Gloucester MT Extra Condensed)�$��50(����#DAA520�� -   $	 gamemode��$
��Left=�$��376,108,0,0q�$
��Wrap=�$��CLASSIC��$	��Top=�$#��Gloucester MT Extra Condensed)�$��50(��� -   
 ��Name$
 
Leftarrow2��   
Left-Arrow#��[  $��82��$��16,0,0,0q�$��2��$��88��$��Center=��� -   $
 Rightarrow2��  Right-Arrow#��[ $��82��$��	895,0,0,0q�$��2��$��88��$��Center=��� -   $
��BACK��$��35(�$��Comic Sans MS)�
������ 
������ $
��Left=�$��	16,10,0,0q�$	��Top=�$��50��$	��111������  �� 
TargetType" ��.R��� #��z��#��z��#��z��$ 15��._���  ��Name$ ContentPresenter��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ ContentPresenter�� �� Property � �� �� Value
 �����P�  � ��$
 True��. ��� $ ContentPresenter�� � ��
 �E���� -    ��Name$
 Mode��$��LeaderBoard/Classic.png��$
��Fill=�$
��Left=�$	��100��$��
537,79,0,0q�$	��Top=�$	��102��