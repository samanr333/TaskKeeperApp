   M S B A M L   `   `   `  ����E  ATaskKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TimeKeeper.ServicesTimeKeeper.Services  5          TimeKeeper.Views.Login   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7	passwords!clr-namespace:TimeKeeper.Services     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      $	��350��5      $	��400��5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	      
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         PasswordBoxStyle �� 
TargetType �� Property �� Value  TextBoxStyle  TextBlockStyle��%�  &	        &	     &	 �    �� 5   
   " G�6)   .�5      ��  � ��$ 28��6'   �� 5       � ��$ 0,5,0,0q�6'   �� 5       � ��$ 10,0,0,0q�6(   �� 5       � ��$ Center=�62   �� 5       � �� �#BE263B6,   �� 5       � ��$ 0,0,0,2q�60   �� 5       �@G�
CaretBrush
 �����6+   �� 5       � ��
 ���� 6+   �� 5       � ��$ 
Montserrat)�6+   �� 5       � ��$ 13(�6)   �� 5       � ��$ Medium"�6+   �� 5       � ��
 �   �6+   5      �� 5   
   " ��6%   .�5      ��  � ��$ 28��6'   �� 5        � ��$ 0,5,0,0q�6'   �� 5!       � ��$ 10,0,0,0q�6(   �� 5"       � ��$ Center=�62   �� 5#       � �� �#BE263B6,   �� 5$       � ��$ 0,0,0,2q�60   �� 5%       �@��
CaretBrush
 �����6+   �� 5&       � ��$ 
Montserrat)�6+   �� 5'       � ��$ 13(�6)   �� 5(       � ��$ Medium"�6+   �� 5)       � ��
 �   �6+   5*      �� 5,   
   " ��6'   .�5-      ��  � ��$ 0,15,0,0q�6'   �� 5.       � ��$ 
Montserrat)�6+   �� 5/       � ��$ 12(�6)   �� 50       � ��$ Medium"�6+   �� 51       � �� �#BE263B6+   52      53      .��54      � .+�55   
   ��   CustomBorderStyle#��[ 6   �� 56   
   $��1��57      $	��220��58      $��0,35,0,0q�59      $��Center=�5:       �� Orientation$ Vertical=�5;      .+�5<      �� $��Center=�5=      $��
Montserrat)�5>      $��25(�5?      $
��Bold"�5@      
�������$��Login��5B      �� 5D      #��[ 6   $��Username��6@   �� 5E      -   5         ��Name$ UsernameBox��5F      #��[ 5G      ��5H      �� *User.Username+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�.��6q   ��5I      �� 5J       j� 
AlignmentX$
 Left=�6!    j� Stretch$
 None=�63   .��5K   &   5L      �� 5M      #��[ 6   $��Password��6@   G� 5S      #��[  6�   .   (TimeKeeper.Services.PasswordBoxAssistant   BoundPassword 6   �� *User.Password+ �� Mode$ TwoWay=�$
 PropertyChanged=�6�   �� 5T      $��0,50,0,0q�5U      $��0q�5V      $�� Login��5X      $��
Montserrat)�5Y      $��12(�5Z      
���������5W      �� *LoginCommand+��5\      �� 5]      " ��6   .�5^      ��  � �� �#BE263B67    �� Triggers 5_      P� 5`       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5a   "   ��  � ��
 �<��6?   5b      5d      ��5f      �� 5g       �� 
TargetType" ��6&   .R�5h      �� $	��150��5i      $��40��5j      #��z��5k       �� CornerRadius$ 20��5l      ._�5m      �� $��Center=�6/   $��Center=�6L   5n      5o      5q      �� 5r      $	��220��5s      $��0,15,0,0q�5t      $��Center=�5u      $ 
Horizontal=�5v      .+�5w      �� $��
Montserrat)�5x      $��12(�5y      $��Medium"�5z      ���#BE263B$��Don't have an account?��5|      �� 5~      $��8,0,0,0q�5      ���#BE263B$��0q�5�      $��Sign Up��5�      $��
Montserrat)�5�      $��10(�5�      $��Medium"�5�      
������� J� Opacity$	 .98Q�5�       J� OpacityMask
 �� ����5�      �� *SignupCommand+��5�      �� 5�      " ��6*   .R�5�      �� $��45��5�   !   $��15��5�   !   #��z��5�   !   $ 5��5�   !   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      5�      5�      5�      5�      5�      