   M S B A M L   `   `   `  ����  
TaskKeeper&     TimeKeeper.Views.UpdateTaskModal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      $	��300��5      $	��400��5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5
       � 	Resources 5         ComboBoxStyle �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Offset
 � Color  PasswordBoxStyle  TextBoxStyle  TextBlockStyle��%�  &	        &	 �    &	 �    &	 �    �� 5   
   " ��6&   .�5      ��  � ��$	 120��6&   �� 5       � ��$ 28��6'   �� 5       � ��$ 0,5,0,0q�6'   �� 5       � ��$ 10,0,0,0q�6(   �� 5       � ��$ Center=�62   �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $	 0Q�6'   $
 Green��62   � 5      $
	 0.75Q�6'   $
 #DA34AE��65   � 5      $	 1Q�6'   $
 #8A16C1��62   5      5      �� 5       � ��$ 0,0,0,2q�60   �� 5       � ��$ 
Montserrat)�6+   �� 5       � ��$ 13(�6)   �� 5       � ��$ Medium"�6+   �� 5        � ��
 �   �6+   �� 5!       � ��
 ���� 6+   5"      �� 5$   
   " G�6)   .�5%      ��  � ��$ 28��6'   �� 5&       � ��$ 0,5,0,0q�6'   �� 5'       � ��$ 10,0,0,0q�6(   �� 5(       � ��$ Center=�62   �� 5)       � �� �#BE263B6,   �� 5*       � ��$ 0,0,0,2q�60   �� 5+       �@G�
CaretBrush
 �����6+   �� 5,       � ��$ 
Montserrat)�6+   �� 5-       � ��$ 13(�6)   �� 5.       � ��$ Medium"�6+   �� 5/       � ��
 �   �6+   50      �� 52   
   " ��6%   .�53      ��  � ��$ 28��6'   �� 54       � ��$ 0,5,0,0q�6'   �� 55       � ��$ 10,0,0,0q�6(   �� 56       � ��$ Center=�62   �� 57       � �� �#BE263B6,   �� 58       � ��$ 0,0,0,2q�60   �� 59       �@��
CaretBrush
 �����6+   �� 5:       � ��$ 
Montserrat)�6+   �� 5;       � ��$ 13(�6)   �� 5<       � ��$ Medium"�6+   �� 5=       � ��
 �   �6+   5>      �� 5@   
   " ��6'   .�5A      ��  � ��$ 0,15,0,0q�6'   �� 5B       � ��$ 
Montserrat)�6+   �� 5C       � ��$ 12(�6)   �� 5D       � ��$ Medium"�6+   �� 5E       � �� �#BE263B6+   5F      5G      .��5H      � .+�5I   
   ��   CustomBorderStyle#��[ 6   �� 5J   
   $��1��5K      $	��220��5L      $��0,35,0,0q�5M      $��Center=�5N       �� Orientation$ Vertical=�5O      .+�5P      �� $��Center=�5Q      $��
Montserrat)�5R      $��25(�5S      $
��Bold"�5T      
�������$��Task Details��5V      �� 5X      #��[ 6   $��Title��6@   �� 5Y      -   5         ��Name$ TaskNameBox��5Z      ${�False��5[      #��[ 5\      ��5]      �� *Task.TaskName+.��60   ��5^      �� 5_       j� 
AlignmentX$
 Left=�6!    j� Stretch$
 None=�63   .��5`   &   5a      �� 5b      #��[ 6   $��Description��6@   �� 5c      -   5        $ UsernameBox��5d      ${�False��5e      #��[ 5f      ��5g      �� *Task.Description+.��63   ��5h      �� 5i      $
 Left=�6!   $
 None=�63   .��5j   &   5k      �� 5l      #��[ 6   $��Status��6@   �� 5m      $	��120��5n      $��20��5o      $
��Left=�5p      
������ #��[  5t      ��5r      �� *
StatusList+ �� SelectedItem 5s      �� *Task.Status+5t      � 5u      $��Center=�6   .+�5v      �� $��0,50,0,0q�5w      $��Center=�5x      $��0q�5y      $��Update��5|      $��
Montserrat)�5}      $��12(�5~      
���������5z      �� *UpdateCommand+ �� UpdateSourceTrigger$ PropertyChanged=���5{      �� ��5�      �� 5�      " ��6    .�5�      ��  � �� �#BE263B6;    �� Triggers 5�      P� 5�   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5�   &   ��  � ��
 �<��6C   5�   #   5�      ��5�      �� 5�       �� 
TargetType" ��6*   .R�5�      �� $��70��5�   !   $��20��5�   !   #��z��5�   !    �� CornerRadius$ 5��5�   !   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      5�      5�      5�      5�      5�      