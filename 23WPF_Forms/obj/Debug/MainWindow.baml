   M S B A M L   `   `   `  ����F  B23WPF_Forms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_23WPF_Forms_23WPF_Forms  5   	       _23WPF_Forms.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_23WPF_Forms     5   	   -   5          � Title$  Saat Uygulaması��5   	   $��481.163��6!   $	��800��62   .��5	      � $��0,0,0,1q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ label1��5      $��Saat :��6    $
��Left=�61   $��	129,9,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ label2��5      $��Dakika :��6    $
��Left=�63   $��
128,35,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ label3��5      $��Saniye :��6    $
��Left=�63   $��
127,63,0,0q�6N   $	��Top=�6b    J� RenderTransformOrigin$ 0.571,0.288&�6z   � 5   
   -   5         �Name$ progressbar1��5      $
��Left=�6,   $��10��6G   $��	16,17,0,0q�6S   $	��Top=�6f   $	��100��6~   �� 5   
   -   5         ��Name$ slider1��5      $
��Left=�6"   $��
327,17,0,0q�6=   $	��Top=�6Q   $	��234��6i    � Maximum$ 24Q�6�    �� IsSnapToTickEnabled . 6�   �� 5   
   -   5        $ slider2��5      $
��Left=�6"   $��
327,55,0,0q�6=   $	��Top=�6Q   $	��234��6i   $ 59Q�6�    . 6�   �� 5   
   -   5         ��Name$ button1��5      $��Ertele��6"   $
��Left=�63   $��
657,19,0,0q�6N   $	��Top=�6b   $��75��6z   6�   �� 5   
   -	   5        $ button2��5      $��Durdur��6"   $
��Left=�63   $��
657,50,0,0q�6N   $	��Top=�6b   $��75��6z   6�   � 5   
   -
   5        $ progressbar2��5      $
��Left=�6,   $��10��6G   $��	16,43,0,0q�6S   $	��Top=�6f   $	��100��6~   � 5   
   -   5        $ progressbar3��5      $
��Left=�6,   $��10��6G   $��	16,71,0,0q�6S   $	��Top=�6f   $	��100��6~   �� 5   
   -   5        $ label7��5      $��Saat :��6    $
��Left=�61   $��
566,13,0,0q�6L   $	��Top=�6`   $ 2.214,-2.113&�6x   �� 5   
   -   5        $ label8��5      $��Dakika :��6    $
��Left=�63   $��
566,47,0,0q�6N   $	��Top=�6b   �� 5   
   $��Alarm Ayarla :��6   $
��Left=�6)   $��
235,31,0,0q�6D   $	��Top=�6X   �� 5   
   $6��0Listboxta bir metin belgesini açma ve gösterme��6   $
��Left=�6K   $	��308��6f   $��
16,105,0,0q�6s   $	��Top=�6�   $	��628��6�   .��5      �� -   5        $ acbutton��5      $	��Aç��6'   $
��Left=�64   $��535,130,0,0q�6O   $	��Top=�6d   $��75��6|   6�   5      �� 5   
   -   5        	 ��Name$	 listbox1��5      $
��Left=�6$   $	��261��6?   $��
36,138,0,0q�6L   $	��Top=�6`   $	��506��6x   5      5       