   M S B A M L   `   `   `  ���� 	  Snake    Snake.SettingGameOver   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     
������ $	��250��$	��300��.��(� .��� $	��250��$	��300��  � RowDefinitions  �� $��4* ��� $��1* �.+�� $��0��
����·�.+��� $��	Game Over��$#��Gloucester MT Extra Condensed)�$��50(�$
��Bold"�
�������$
��Left=�$	��Top=�$��2��$��	48,24,0,0q��� -    ��Name$ NameFood��$��Choose/apple.png��$��32,87,158,83q��� -    ��Name$ Score��$��0��$��30(�$
��Bold"�
������� �� TextAlignment$ Center=�$��42,151,168,51q��� -   $ NameMode��$��Choose/classic.png��$��150,92,35,84q��� -   $ 	Highscore��$��0��$��30(�$
��Bold"�
�������$ Center=�$��164,151,49,50q��� $��Setting/Snake_end.png��$��Center=�$��38��$��	0,202,0,0q�$	��Top=�$	��154��� $��1�����#6B4F4F.+��� -   $
��BACK��$��70��$��40(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$
��Left=�$��Center=����#EED6C4$��39,9,0,8q�����  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 15��._���  ��Name$ ContentPresenter��$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver	 P� Value$
	 True��. ��� 
 �� 
TargetName$
 ContentPresenter�� �� Property � �� �� Value �#FFF3E4P�  � ��$
	 True��. ��� $
 ContentPresenter�� � �� �#E8E1D9�� -   $��RETRY��$��85��$��40(�$#��Gloucester MT Extra Condensed)�
������ 
������ $��2q�$
��Left=�$��Center=����#EED6C4$��	137,9,0,8q����� " ��.R��� #��z��#��z��#��z��$ 15��._��� $ ContentPresenter��$��Center=�$��Center=� P�  �@J�IsMouseOver$
	 True��. ��� $
 ContentPresenter�� � �� �#FFF3E4P�  � ��$
	 True��. ��� $
 ContentPresenter�� � �� �#E8E1D9