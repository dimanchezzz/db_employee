   M S B A M L   `   `   `  ����J  FCourse_kepeer_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Course_kepeer_1Course_kepeer_1  5   	   '    !Course_kepeer_1.Main_manager_wndw   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:Course_kepeer_1  5   	   H DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5        � Title$  Main_manager_wndw��5
   	   $	��600��6#   $	��600��63   $
��1150��6@   $	��900��6M   .��5      � .+�5   
   �� -   5        $	�� 40��5      $��get xml��6   $	��140��61   $��
10,125,0,0q�6R   $
��Left=�6f   $	��Top=�6�   �� 5   
   {�.  $��Right=�6(   $	��267��6D   $	��255��6P   $	��Top=�6]   .+�5      �� -   5         ��Name$ adress��5   7   $��0,0,0,0q�6    �� 	MaxLength$ 15��6(   $��3q�6H   $��Right=�6\   $	��250��6x   $��25(�6�   �� 5      -   5        $
 city��5   )   $��0,10,0,0q�6   $ 15��67   $��3q�6F   $��Right=�6Z   $	��250��6v   $��25(�6�   �� 5      -   5        $ phone_number��5   *   $��0,10,0,0q�6   $��3q�6A   $��Right=�6U   $	��250��6q   $��25(�6}   �� 5      -   5        $ email��5   *   $��0,10,0,0q�6   $��3q�69   $��Right=�6N   $	��250��6j   $��25(�6v   �� 5      -   5        $	 dep��5   *   $��0,10,0,0q�6   $��3q�67   $��Right=�6L   $	��250��6h   $��25(�6t   5      �� 5   
   -   5        $	��eml��5   >   $	�� 40��6   $��employee��6   $	��140��62   $��	210,0,0,0q�6`   $
��Left=�6s   $	��Top=�6�   �� 5   
   -   5        $��us��5   0   $	�� 40��6   $��users��6   $	��140��6:   $��
210,45,0,0q�6]   $
��Left=�6q   $	��Top=�6�   �� 5   
   -	   5        $��listview��5      $��	370,0,0,0q�6P   $
��Left=�6c   $	��290��6~   $	��191��6�   $	��Top=�6�   �� 5   
   $��10,196,567,10q�6   .+�5      �� -
   5         ��Name$
 term��5   $   $��35��6   $	��100��62   $��25(�6B   $��0,10,0,0q�6P   $
��Left=�6c   $	��300��6~   $	��Top=�6�   �� 5      -   5        $ percent��5   $   $��35��6   $	��100��65   $��20(�6E   $��0,10,0,0q�6U   $
��Left=�6g   $	��300��6�   $	��Top=�6�   �� 5      -   5        $ restrict��5   $   $��35��6   $	��100��66   $��20(�6F   $��0,10,0,0q�6U   $
��Left=�6g   $	��300��6�   $	��Top=�6�   �� 5      -   5        $ date_create��5   $   $��35��6   $	��100��69   $��20(�6I   $��0,10,0,0q�6Y   $
��Left=�6k   $	��331��6�   $	��Top=�6�   �� 5       -   5        $ comment��5    $   $��70��6   $	��100��65   $
��Wrap=�6D   $��0,10,0,0q�6Y   $��20(�6k   $
��Left=�6z   $	��300��6�   $	��Top=�6�   5"      �� 5#   
   $��325,196,0,0q�6   $
��Left=�6*   $	��335��6E   $	��373��6Q   $	��Top=�6^   .+�5$      �� -   5        $ 
date_start��5$   $   $��35��6   $	��100��68   $��25(�6H   $��0,15,0,0q�6V   $
��Left=�6h   $	��300��6�   $	��Top=�6�   �� 5%      -   5        $ date_end��5%   $   $��35��6   $	��100��66   $��20(�6F   $��0,15,0,0q�6T   $
��Left=�6f   $	��300��6�   $	��Top=�6�   �� 5&      -   5        $	 pay��5&   $   $��35��6   $	��100��61   $
��Wrap=�6@   $��20(�6U   $��0,15,0,0q�6c   $
��Left=�6u   $	��300��6�   $	��Top=�6�   �� 5'      -   5        $
 debt��5'   $   $��35��6   $	��100��62   $
��Wrap=�6A   $��20(�6V   $��0,15,0,0q�6d   $
��Left=�6v   $	��300��6�   $	��Top=�6�   �� 5(      -   5        $ status��5(   $   $��35��6   $	��100��65   $��20(�6E   $��0,15,0,0q�6S   $
��Left=�6e   $	��300��6�   $	��Top=�6�   5*      �� 5+   
   -   5        $��add_user_stack��5+   >   $	��314��6   $��Bottom=�6#   $��Right=�6T   $	��422��6p   .+�5,      �� $��0,0,0,0q�6    �� Orientation$ 
Horizontal=�6+   .+�5-      �� $��Name:��6   $��30(�6)   �� 5.      -   5        $
 name��5.   f   $��80,0,0,0q�6   $ 30��6,   $��Right=�6u   $��3q�6�   $	��250��6�   $��25(�6�   5/      �� 51      $��0,5,0,0q�6   $ 
Horizontal=�6+   .+�52      �� $��Term:��6   $��30(�6)   �� 53      -   5        $ termmm��53   �   $��94,0,0,0q�6   $ 3��6�   $��3q�6�   $��Right=�6�   $	��250��6�   $��25(�6�   54      �� 55      $��0,5,0,0q�6   $ 
Horizontal=�6+   .+�56      �� $��Percent:��6   $��30(�6,   �� 57      -   5        $ 	percenttt��57   �   $��60,0,0,0q�6   $ 3��6�   $��3q�6�   $��Right=�6�   $	��250��6�   $��25(�6�   58      �� 59      $��0,5,0,0q�6   $ 
Horizontal=�6+   .+�5:      �� $��Restriction:��6   $��30(�60   �� 5;      -   5        $
 rest��5;   �   $��19,0,0,0q�6   $ 10��6�   $��3q�6�   $��Right=�6�   $	��250��6�   $��25(�6�   5<      �� 5=      $��0,5,0,0q�6   $ 
Horizontal=�6+   .+�5>      �� $��Comment:��6   $��30(�6,   �� 5?      -   5        $ 	commenttt��5?   S    �� AcceptsReturn . $��28,0,0,0q�61   $	 100��6C   $��3q�6g   $��Right=�6{   $	��255��6�   $��25(�6�   $��41��6�   5@      �� 5A      -   5         ��Name$ departament��5A      $��17(�6-   $��35��6;   $	��Top=�6G   $	��250��6_   $	��295��6n   .@�5B      ��  �� 
IsSelected . .��61   Credit departament6E   �� 5C      .��6   Contribution departament69   5D      �� 5E      -   5        $	��add��5E   #   $	��add��6   $��40��6@   $	��150��6L   $��0,10,0,0q�6X   5G      �� 5H   
   -   5        $	�� 40��5H      $��import��65   $	��140��6G   $��
210,90,0,0q�6U   $
��Left=�6i   $	��Top=�6�   �� 5I   
   -   5         ��Name$ 	listView1��5I      $
��Left=�6&   $��65��6i   $��	10,10,0,0q�6u   $	��Top=�6�   $	��200��6�   5J      5K      5L      