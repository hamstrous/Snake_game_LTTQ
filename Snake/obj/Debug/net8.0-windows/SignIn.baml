   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.SignIn   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:Snake  5   	     � Icon$  Assets/icon.ico��5   	   ���#F6FCDF � Title$ Sign In��5   	   $	��800��6   $
��1000��6&    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      � ���#F6FCDF.+�5   
   �� 
���   �$��2q�6%    �� CornerRadius$ 10��69   $��20,22,476,29q�6K   ._�5      �� $��Sigin-up/snake.jpg��6   $
��Fill=�60   5      �� 5   
   -   5         ��Name$ textusername��5      $��Username��6*      textHint#��[  6:   $��565,227,243,491q�6\   $��40(�6u   � 5   
   .+�5      �� -   5        	 ��Name$	 txtusername��5      $��40��6+   $	��200��67   $	��Top=�5      $��Right=�6&   $��
0,242,36,0q�6B   $��30(�6V   5      �� 5   
   $��SIGN IN��6   $��638,96,107,576q�6#   ���#31511E
 �� TextAlignment$
 Center=�6P   $��80(�6g   $#��Gloucester MT Extra Condensed)�6u   �� 5   
   -   5        $ txtErrorMessage��5      $�� ��6-   $
��Wrap=�65   $
 Center=�6I   
���  ��$
��Left=�6q   $	��Top=�6�   $��534,178,0,0q�6�   $y�Visible=�6�   $	��462��6�   $��30(�6�   $��52��6�   �� 5    
   -   5        $ textpassword��5       $��Password��6*   #��[  6:   $��565,299,243,400q�6\   $��40(�6u   � 5!   
   .+�5"      G� -   5         G�Name$ txtpassword��5"      $��0q�6/   $��40��6C   $	��200��6O   $	��Top=�5#      $��Right=�62   $��
0,306,36,0q�6N   $��30(�6b   5$      � 5%   
   .+�5&      �� -   5         ��Name$ 	btnSignIn��5(        signinbutton#��[ 5&      $��2q�5'      $��Sign in��5(   <   $��35(�6N   $��0,393,140,0q�6\   $	��Top=�5)      $��Right=�6)   $	��100��5*      $	��180��6#   5+      � 5,   
   $��	-4,-2,4,2q�6   .+�5-      �� -   5        $ 	btnSignUp��5/       
 button#��[ 5-      $��2q�5.      $��Sign up��5/   <   $��35(�6N   $��0,513,135,0q�6\   $	��Top=�50      $��Right=�6)   $	��100��6E   $	��180��6R   51      52      53      