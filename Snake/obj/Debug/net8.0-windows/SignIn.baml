   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.SignIn   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:Snake  5   	     � Icon$  Assets/icon.ico��5   	    � Title$ Sign In��5
   	   $	��476��6   $	��650��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ resources/dic.xaml?�6%   %    5      .��5      � $
}�True��6   
���   �.+�5   
   ��  �� CornerRadius$ 40��6   ���#F6FCDF$��	0,13,0,10q�69   $
}�True��6L   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��345��6   $	��426��6)   .+�5      �� $ 40��6   $
}�True��6/   ._�5      �� $��Sigin-up/snake.jpg��6    $
��Fill=�6<   $	��426��6K   $	��350��6X   	 J� Clip	 5      �� 5   "   
 �� RadiusX$
 40Q�64    �� RadiusY$ 40Q�6A    �� Rect$ 0,0,330,426�6N   5      5      5      �� 5"      $	��306��6   $	��422��6)   .+�5#      �� $
��5 70q�6!   $	��230��6/   .+�5$      �� $��SIGN IN��6$   $��20,20,20,10q�63   ���#31511E �� TextAlignment$ Center=�6]   $��55(�6t   $#��Gloucester MT Extra Condensed)�6�   $��57��6�   �� 5&      -   5         ��Name$ txtErrorMessage��5&   $   $�� ��6=   
���  ��$��14(�6V   $��Center=�6d   $��0,0,0,10q�6�   $y�	Collapsed=�6�   �� 5(      $ 
Horizontal=�6%   $��10 0 0 0q�6>   .+�5)      �� -   5        $ textusername��5)   (   $��Username��6>      textHint#��[  6N   $��67��6p   �� 5*      -   5         ��Name$ txtusername��5*   &   $
��10 0q�6;   $	��132��6I   $��21��6U   5,      �� 5/      $ 
Horizontal=�6%   $��	10 10 0 0q�6>   .+�50      �� -   5        $ textpassword��50   (   $��Password��6>   #��[  6N   $��68��6p   G� 51      -   5         G�Name$ txtpassword��51   *   $
��10 0q�6?   $	��130��6M   $��21��6Y   $��0q�6e   52      �� 54      $��0 15 0 0q�6%   $��Center=�67   .+�55      �� -   5         ��Name$ 	btnSignIn��57   %     signinbutton#��[ 55   &   $��2q�56   %   $��Sign in��57   P   $	��112��6b   $��18(�6n   58      �� 5:      $��10q�6%   $��Center=�61   .+�5;      �� -   5        $ 	btnSignUp��5>   %    
 button#��[ 5;   %   $��2q�5<   %   $��Sign up��5>   P   $	��101��6b   $��53��6n   $��16(�6z   5?      5A      5B      5C      5D      5E      5F      