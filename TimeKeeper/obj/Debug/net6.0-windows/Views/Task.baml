   M S B A M L   `   `   `  ����  
TaskKeeper    TimeKeeper.Views.Task   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5	      � .+�5
   
   � $��	50,10,0,0q�6   .+�5      �� $��0q�5      $��Add Task��5       � Cursor$
 Hand��5      $��
Montserrat)�5      $��12(�5      
���������5      �� *ViewAddTaskModalCommand+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �  ��67    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5   "   ��  � ��
 �<��6?   5      5      ��5      �� 5       �� 
TargetType" ��6&   .R�5       �� $��70��5!      $��25��5"      #��z��5#      	 �� CornerRadius$	 5��5$      ._�5%      �� $��Center=�6/   $��Center=�6L   5&      5'      5)      �� 5*      $��30,0,0,0q�5+      $��0q�5,      $��Delete Task��5.      $
 Hand��5/      $��
Montserrat)�50      $��12(�51      
���������5-      �� *RemoveCommand+
 �� UpdateSourceTrigger$
 PropertyChanged=���53      �� 54      " ��6   .�55      ��  � ��
 �  ��67    56      P� 57       �@J�IsMouseOver$
 True��6=   . �58   "   ��  � ��
 �<��6?   59      5;      ��5=      �� 5>      " ��6&   .R�5?      �� $��70��5@      $��25��5A      #��z��5B      $	 5��5C      ._�5D      �� $��Center=�6/   $��Center=�6L   5E      5F      5H      �� 5I      $��30,0,0,0q�5J      $��0q�5K      $��Update��5M      $
 Hand��5N      $��
Montserrat)�5O      $��12(�5P      
���������5L      �� *ViewUpdateTaskModalCommand+��5R      �� 5S      " ��6   .�5T      ��  � ��
 �  ��67    5U      P� 5V       �@J�IsMouseOver$
 True��6=   . �5W   "   ��  � ��
 �<��6?   5X      5Z      ��5\      �� 5]      " ��6&   .R�5^      �� $��70��5_      $��25��5`      #��z��5a      $	 5��5b      ._�5c      �� $��Center=�6/   $��Center=�6L   5d      5e      5g      �� 5h      $	��150��5i      $��25��5j      $��30,0,0,0q�5k      
�������
������ 
���  ����5o      �� *SearchKeyword+$
 PropertyChanged=�!  FontAwesome.WPF.FontAwesome  5p      $��5q�5q      $��20(�5r      
���  ��   Icon$ Search=�5t      5v      � 5y   
   $
��auto��5z      $��50q�5{       � Orientation$ 
Horizontal=�5|      .+�5~      �� 
������ $��0q�5�       �� SelectionMode$ Single=�5�      ��5�      �� *FilteredTask+$
 PropertyChanged=� �� SelectedItem 5�      �� *SelectedTask+��5�      �� 5�      .R�5�      � $
��1000��6$   $ 
Horizontal=�61   5�      ��5�      �� 5�      .R�5�      �� $	��302��5�      $
��auto��5�      $��10q�5�      $��Stretch=�5�      
����������#BE263B$��1q�5�      $	 5��5�      ._�5�      �  � RowDefinitions 5�   "   �� 5�   &   $
��Auto �64   �� 5�   &   �� 5�   &   $��* �64   .+�5�   "   � $��0��6,   $��Center=�69   .+�5�   &     $��30(�5�   )   
�������$ Tasks=�5�   )   �� 5�   &   $
��left=�5�   )   $��Center=�5�   )   $��Title:��5�   )   $��
Montserrat)�5�   )   $��20(�5�   )   $��Medium"�5�   )   ���#BE263B5�   )   �� 5�   &   $��5q�5�   )   $��
Montserrat)�5�   )   $��20(�5�   )   $��Medium"�5�   )   ���#BE263B$
��Wrap=�5�   )   ��5�   )   �� *
TaskName+5�   )   5�   #   �� 5�   "   $��1��5�   %   $��5,0,0,0q�5�   %   $
��Left=�5�   %   .+�5�   &   � .+�5�   *   �� $��Status: ��5�   -   $��
Montserrat)�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���iii�5�   -   �� 5�   *   $��Center=�5�   -   $��
Montserrat)�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���iii���5�   -   �� *Status+5�   '   � 5�   &   .+�5�   *   �� $��Updated On: ��5�   -   $��
Montserrat)�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���iii�5�   -   �� 5�   *   $��Center=�5�   -   $��
Montserrat)�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���iii���5�   -   �� *TaskUpdatedDate+5�   '   5�   #   �� 5�   "   $��2��5�   %   $��5q�5�   %   $��
Montserrat)�5�   %   $��16(�5�   %   $��Medium"�5�   %   $
��Wrap=�5�   %   ��5�   %   �� *Description+5�   %   5�      5�      5�      5�      5�      5�      5�      