   M S B A M L   `   `   `  ����J  FCourse_kepeer_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Course_kepeer_1Course_kepeer_1  5          Course_kepeer_1.register   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Course_kepeer_1     5      X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  register��5
       � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $	��Top=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   5   !   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   $   5      �� 5      
���  ��$��2,0,0,0q�62   ��5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      5      �� 5      $ ErrorAdorner��6,   6E   5      5      5      .��5      � .+�5   
   �� $��Register��6   $��30(�6%   $ Center=�63   $��0,10,0,0q�6K   $	��250��6^   $	��35 ��6m   $	��Top=�6}   $��Center=�6�   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5    
   -   5        $	��log��5    �    �� 	MaxLength$ 15��6H   $	��400��6{   	 =� ErrorTemplate#	 [  6�   
   	Watermark$

 Name��6�   $	��0.5q�6�   
���   �$��
60,70,60,0q�6  
������ $	��250��6B  $	��35 ��6Q  $	��Top=�6b  $��20(�6z   �� TextAlignment$ Center=�6�  .��6�  ��5!      �� 5"      $
 Name�6    �� Mode$ TwoWay=�6&    �� UpdateSourceTrigger$ 	LostFocus=�64    �� ValidationRules 5#      $   Course_kepeer_1.LoginValidator  5$      61   5&      .��5'   *   5(      ,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  5)   
   -   5        $	��pw1��5)   �  $ 15��6$   $
 Password��6[   $	��400��6r   #	 [  6�   $	��250��6�   $	��35 ��6�   $	��0.5q�6	  $	��Top=�6  
������ 
���   �$��60,120,60,0q�6d  $��20(�6y  $ Password��6�  .��6�  ��5*      �� 5+      $
 Name�6   $ TwoWay=�6&   $ 	LostFocus=�64    5,      '  !Course_kepeer_1.PasswordValidator  5-      64   5/      .��50   .   51      �� 52   
   -   5        $��	agreement��52   �   $��141,0,185,81q�6   $��Bottom=�6*   
������ $��	agreement��6^    � Cursor$
 Hand��6�     53   
   -   5        $
��city��53   �   $ 15��6    $
 City��6W   $

 City��6f   $	��400��6x   $	��250��6�   $	��35 ��6�   $	��0.5q�6�   #	 [  6�   
���   �$��60,170,60,0q�6   
������ $	��Top=�6P  $��20(�6h  $ Center=�6w  .��6�  54        55   
   -   5        $��email��55   �   $ 30��6    $
 Emal��6W   $
 Email��6f   $	��400��6y   $	��250��6�   $	��35 ��6�   $	��0.5q�6�   #	 [  6�   
���   �$��60,220,60,0q�6"  
������ $	��Top=�6R  $��20(�6j  $ Center=�6y  .��6�  56        57   
   -   5        $��phone��57   �  $ 15��6    $
 Phone number��6W   $	��400��6�   #	 [  6�   $	��250��6  $	��35 ��6#  $	��0.5q�63  $	��Top=�6I  
������ 
���   �$��60,270,60,0q�6�  $��20(�6�  $ Number��6�  .��6�  58      �� 5:   
   -   5        $��check��5:   �   $��Bottom=�6   $��55,0,234,79q�6c   $��1q�6x   $��4,-1,0,0q�6�   .��6�   I have read6�   �� 5;   
   -   5        $��	registers��5;   �   $��30��6   $	��100��6     �� 	IsDefault . {�.  $��Bottom=�6R   $	��300��6m   $��120,0,120,40q�6|   $��Register��6�   6�   �� 5<   
   -	   5         ��Name$ departament��5<      $��35��6*   $��60,320,60,0q�66   $	��Top=�6K   $	��250��6c   $	��295��6r   .@�5=      ��  �� 
IsSelected . .��6-   Credit departament6A   �� 5>      .��6   Contribution departament65   5?      5@      5A      