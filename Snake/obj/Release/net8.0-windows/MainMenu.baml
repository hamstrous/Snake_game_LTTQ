   M S B A M L   `   `   `  ���� @  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake      Snake.MainMenu   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Snake       � Title$  Snake��$	��800��$
��1000�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�-  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=�   ControlTabNavigation$
 None=�   DirectionalNavigation$
 None=�$|�False�� � Icon$ Assets/icon.ico�� � WindowStyle$
 None=� � FocusVisualStyle Z� ���� 	 �� ImageSource$#	 Assets/MainMenuBackground.jpg��
 j� Stretch$
 UniformToFill=� � 	Resources  �� MergedDictionaries �� Source��  �� $ resources/dic.xaml?�%    .��� .+�(� .��� $
 None=�$
 None=�$
 None=�.+�� $	��800��$
��1000�� � RowDefinitions �� $
��0.8* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $
��0.8* �.+��� -      Tutorial#��[  $��0��$��90��$��80��$��
897,10,0,0q��� $��/MainMenu/board.png��$
��Fill=�$��1��$	��116��$	��248�� J� IsHitTestVisible$ False��$��Center=�$��Center=��� -   $
��PLAY��$��1��$	��102��$	��224��$��50(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$��Center=�$��Center=�����  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 15��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property � �� �� Value
 ������� $��/MainMenu/board.png��$
��Fill=�$��2��$	��116��$	��248��$ False��$��Center=��� -   $��LEADERBOARD��$��2��$	��102��$	��224��$��43(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$��Center=����� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ������� $��/MainMenu/board.png��$
��Fill=�$��3��$	��116��$	��248��$ False��$��Center=�$��Center=��� -   $��SETTING��$��3��$	��102��$	��224��$��50(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$��Center=�$��Center=����� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ������� $��/MainMenu/board.png��$
��Fill=�$��4��$	��116��$	��248��$ False��$��Center=�$��Center=��� -   $
��EXIT��$��4��$	��102��$	��224��$��50(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$��Center=�$��Center=����� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �����   Snake.SettingExit2  -     Name$
 Exit��$y�	Collapsed=� K� ZIndex$ 1��   Snake.Setting  -     Name$ SettingControl��$y�	Collapsed=�$ 1��   Snake.UserControl1  -     Name$ 
ChooseMode��$y�	Collapsed=�$ 1��$
 None=�$
 None=�$
 None=�$|�False��   Snake.Leaderboard2  -	     Name$ Leaderboard2��$y�	Collapsed=�$ 1��   Snake.Tutorial  -
     Name$
 Book��$y�	Collapsed=�$ 1��   Snake.Tutorial2  -     Name$ Book2��$y�	Collapsed=�$ 1��   Snake.Tutorial3  -     Name$ Book3��$y�	Collapsed=�$ 1��