   M S B A M L   `   `   `  ����  
TaskKeeper     TimeKeeper.Views.Dashboard   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [Syncfusion.SfChart.WPF, Version=22.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89-chart!http://schemas.syncfusion.com/wpf  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 	Resources 5	         BoxStyle �� 
TargetType �� Property �� Value��%n  &	        �� 5
   
   " ��6!   .�5      ��  � ��$	 250��6&   �� 5       � ��$ Center=�64   �� 5       � ��$	 250��6'   �� 5       � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � �� �#BE263B6,   �� 5       � ��$ 1q�60   �� 5       �@��CornerRadius$ 50,0,0,0��6-   5      5      .��5      �� .+�5   
   � .+�5      �� #��[  6   ._�5      �� .+�5      !  FontAwesome.WPF.FontAwesome  $��5q�5      $��70(�5      
���  ��   Icon$ Tasks=�5      �� 5      $��Center=�5      $��
Total Task��5       $��
Montserrat)�5!      $��35(�5"      $
��Bold"�5#      �� 5$      $��65��5%      $��65��5&      ���#84858D �� CornerRadius$ 5��5(      ._�5)      �� $��Center=�5*      $��Center=�5+      $��
Montserrat)�5,      $��35(�5-      $
��Bold"�5.      ��5/      �� *	TotalTask+ �� Mode$ TwoWay=�50      51      52      �� 53      #��[  6   ._�54      �� .+�55        $��5q�56      $��70(�57      
���  ��$ StarOutline=�59      �� 5:      $��Center=�5;      $��Pending��5<      $��
Montserrat)�5=      $��35(�5>      $
��Bold"�5?      �� 5@      $��65��5A      $��65��5B      ���#84858D$ 5��5D      ._�5E      �� $��Center=�5F      $��Center=�5G      $��
Montserrat)�5H      $��35(�5I      $
��Bold"�5J      ��5K      �� *PendingTask+$ TwoWay=�5L      5M      5N      �� 5O      #��[  6   ._�5P      �� .+�5Q        $��5q�5R      $��70(�5S      
���  ��$ StarHalfFull=�5U      �� 5V      $��Center=�5W      $��In Progress��5X      $��
Montserrat)�5Y      $��35(�5Z      $
��Bold"�5[      �� 5\      $��65��5]      $��65��5^      ���#84858D$ 5��5`      ._�5a      �� $��Center=�5b      $��Center=�5c      $��
Montserrat)�5d      $��35(�5e      $
��Bold"�5f      ��5g      �� *InprogressTask+$ TwoWay=�5h      5i      5j      �� 5k      #��[  6   ._�5l      �� .+�5m        $��5q�5n      $��70(�5o      
���  ��$
 Star=�5q      �� 5r      $��Center=�5s      $
��Done��5t      $��
Montserrat)�5u      $��35(�5v      $
��Bold"�5w      �� 5x      $��65��5y      $��65��5z      ���#84858D$ 5��5|      ._�5}      �� $��Center=�5~      $��Center=�5      $��
Montserrat)�5�      $��35(�5�      $
��Bold"�5�      ��5�      �� *
DoneTask+$ TwoWay=�5�      5�      5�      5�      � 5�   
   $	��500��6   $	��450��6   .+�5�      '  !Syncfusion.UI.Xaml.Charts.SfChart  )  #Syncfusion.UI.Xaml.Charts.ChartBase   Legend 5�      +  %Syncfusion.UI.Xaml.Charts.ChartLegend  5�      $��20q�5�      
������ $��
Montserrat)�5�      $��20(�5�      $
��Bold"�5�      	   
IconHeight$	 20Q�5�      
   	IconWidth$
 20Q�5�         Series. 5�      )  #Syncfusion.UI.Xaml.Charts.PieSeries  2  ,Syncfusion.UI.Xaml.Charts.CircularSeriesBase   EnableSmartLabels$
 True��5�      /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase   XBindingPath$
 Name��5�      6	  0Syncfusion.UI.Xaml.Charts.AccumulationSeriesBase 	  YBindingPath$ Value��5�         ItemsSource 5�      �� *Counts+/
  )Syncfusion.UI.Xaml.Charts.AdornmentSeries 
  AdornmentsInfo 5�      2  ,Syncfusion.UI.Xaml.Charts.ChartAdornmentInfo  5�      6  0Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase   FontSize$ 20Q�5�         
Foreground
 �����   	ShowLabel$
 True��5�      5�      5�      5�      5�      5�      