   M S B A M L   `   `   `  ����B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp4WpfApp4  5   	       WpfApp4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp4     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   ���	#FFCDC4E6.��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $ ��Входящий файл:��6   ���	#FFE9F0FF$��
0,34,0,-60q�6@   $��5��6T   �� 5   
   -   5         ��Name$ InputFileTextBox��5      $��5��6,   $��10,65,0,-83q�69   �� 5   
   $ ��Исходящи файл:��6   $��5��6)   $��0,83,0,-109q�66   ���	#FFA6E6DC6K   �� 5   
   -   5        $ OutputFileTextBox��5      $��5��6-   $��10,109,0,-127q�6:   �� 5   
   $3��-Минимальная длина слова:��6   $��5��63   $��5,132,-5,-158q�6@   ���	#FFDCF3D9 J� RenderTransformOrigin$ 0.473,0.346&�6n   �� 5   
   -   5        $ MinWordLengthTextBox��5      $��5��60   $��10,163,0,-181q�6=   �� 5   
   -   5         ��Name$ RemovePunctuationCheckBox��5      $)��#Убрать пунктуацияю��66   $��5��6S   $��570,245,46,-260q�6`   �� 5   
   -   5        $��ОБРАБОТАТЬ��5      $��5��6F   $��570,282,0,-337q�6S   $
��Left=�6k   $	��160��6�   ���	#FF8FF9806�   5       5!      