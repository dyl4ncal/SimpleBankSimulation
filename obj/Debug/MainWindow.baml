   M S B A M L   `   `   `  ����D  @CPSC300A2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CPSC300A2	CPSC300A2  5   	       CPSC300A2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CPSC300A2     5   	     � Title$  Simple Bank Simulator��5   	   $��609.513��6'   $��1030.614��68    � 
ResizeMode$ NoResize=�6I   $��14(�6_   .��5	      � $��	0,0,-6,-6q�6   $	��587��6   $	��Top=�6+   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FF87BAD3��6   5      .+�5   
   �� -   5         ��Name$ 
LoadButton��5      $��Data File Search��6%   $
��Left=�6@   $��
728,31,0,0q�6[   $	��Top=�6o   $	��248��6�   ���	#FFBBBBBB$��24��6�   $��14(�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.432,1.583&�6�   �� 5   
   -   5         ��Name$ fileTextBox��5      $
��Left=�6'   $��184,31,0,532q�6B   	 �� TextWrapping$
	 Wrap=�6X   $	��539��6l   
����������	#FFE41818
 �� IsReadOnlyCaretVisible
 . $��16(�6�   �� 5   
   $��Selected Data File:��6   $
��Left=�6.   $��	22,24,0,0q�6I   $	��Top=�6\   $	��162��6t   $��33��6�   $��18(�6�   �� 5   
   -   5        $'��!Run Simulation With Selected Data��5      $
��Left=�6=   $��
184,71,0,0q�6X   $	��Top=�6l   $	��539��6�   $��31��6�   $��16(�6�   $
��Bold"�6�   ���	#FF33D3246�   �� 5   
   -   5        $��Export Results To Desktop��5      $
��Left=�65   $��588,524,0,0q�6P   $	��Top=�6e   $	��388��6}   ���	#FF8437E0$��36��6�   $ 0.535,1.167&�6�   $
��Bold"�6�   �� 5   
   -   5        $ outputTextBox��5      $
��Left=�6)   $	��359��6D   $��
36,150,0,0q�6Q   $
	 Wrap=�6e   $	��Top=�6y   $	��506��6�   ���	#FFEEEEEE6�   �� 5   
   -   5        $ analysisTextBox��5      $
��Left=�6+   $	��359��6F   $��588,150,0,0q�6S   $
	 Wrap=�6h   $	��Top=�6|   $	��388��6�   ���	#FFEEEEEE6�   �� 5   
   $��Simulation Output:��6   $
��Left=�6-   $��
36,121,0,0q�6H   $	��Top=�6\   �� 5   
   $��Simulation Analysis:��6   $
��Left=�6/   $��588,121,0,0q�6J   $	��Top=�6_   �� 5   
   $��Made by Dylan Calado��6   $
��Left=�6/   $��
36,531,0,0q�6J   $	��Top=�6^   ���	#FFE0E0E0$��29��6�   $	��150��6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ 	#FF23424D��6#   $ 1Q�65   5      5       5#      5$      