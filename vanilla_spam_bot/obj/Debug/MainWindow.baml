   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	        WpfApplication2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$!  Spam Bot by Roman Dehtiarov��5   	   $��394.5��6-   $	��755��6<   .��5	      � $��0,0,0,12q�6    � ColumnDefinitions 5
   
   �� 5      $
��104* �6   �� 5      $
��273* �6   �� 5      $
��370* �6   .+�5   
   �� -   5         ��Name$ button1��5      $��Начать спам��6"   $��43.144��68   $��10,279.9,0,0q�6H   $	��Top=�6^   ���	#FF5BBF9F���	#FF8B6E6E$��2��6�   $
��Left=�6�   $��168.393��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataGrid1��5      $��0,34.517,10,0q�6&   $��2��6=   $��118.5��6M   $	��Top=�6\      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� 	 �� Path$	 Test1�6r     5      $ Id��6%    . $	 130 6c    6D   �� $	 Test2�6q   5      �� 5   
   -   5        
 ��Name$
 textBox1��5       �� TextWrapping$
 Wrap=�6$   $K��Ewant to buy cheap g o l d ? Visit   M O N E Y F O R G A M E S . N E T��68   $��2��6�   $��10,166.966,16.5,0q�6�   $��55.517��6�   $	��Top=�6�     5   
   -   5        $ 	dataGrid2��5      $��10,34.517,24.393,0q�6&   $��260.5��6B   $	��Top=�6Q   $��2��6i    5        5      $
 Rank��6%    . $ 40 6c    6E   �� $
	 Rank�6p     5      $
 Name��6%    . $	 140 6c    6E   �� $
	 Name�6q     5      $ Guild��6%    . $	 100 6e    6F   �� $	 Guild�6s     5      $ Level��6%    . $ 50 6f    6G   �� $	 Level�6s   5      �� 5   
   -   5         ��Name$ label��5      $
��Left=�6   $��23.517��6:   $��	10,10,0,0q�6J   $	��Top=�6]   $��158.5��6u   $��WoW Processes��6�    J� RenderTransformOrigin$ 0.509,0.082&�6�   $��2��6�   �� 5    
   -   5        $ label1��5       $��User nicknames��6    $��24.517��69   $��
-94,10,0,0q�6I   $	��Top=�6]   $ 0.503,-0.693&�6u   $��1��6�   $
��Left=�6�   $	��195��6�   	� 5!   
   -   5         	�Name$ 
radioHorde��5!      $��Horde��6*   $��10,313.475,41.933,0q�6:   $	��Top=�6W    d� 	IsChecked$
 TrueY�6�   	� 5"   
   -   5        $ radioAlliance��5"      $��Alliance��6-   $��1��6@   $��-21,313.475,0,0q�6P   $	��Top=�6i   $
��Left=�6�   �� 5#   
   -	   5        $ button��5#      $��Получить ники��6!   $��1��69   $��28.026��6I   $��92,0,24.393,17.032q�6Y   $��Bottom=�6u   6�   �� 5$   
   -
   5        $ button2��5$      $#��Остановить спам��6"   $��2��6<   $��196.333,279.9,0,0q�6L   $	��Top=�6g   $��43.144��6   ���	#FFB83131$
��Left=�6�   $��157.167��6�   �� 5%   
   -   5        $
 pauseBox��5%      $��2��6$   $��17.517��64   $��107,0,0,102.5q�6D   $
 Wrap=�6[   $��5��6o   $��Bottom=�6x   $
��Left=�6�   $��71.393��6�   $ 0.504,2.827&�6�   �� 5&   
   -   5        $ label2��5&      $��
Пауза��6    $��2��60   $
��Left=�6@   $��31.517��6[   $��10,0,0,92.5q�6k   $��Bottom=�6�   $��92��6�   5(      5)      