   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	        SalesWPFApp.WindowProducts   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  WindowLogin��5   	   $	��600��6   $	��900��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��2��6   $��0��6   $��4 4 0 0q�6-   $
��Id: ��6>   $
��Bold"�6M   �� 5   
   -   5        $��txtId��5   S   $
��Bold"�6   $��2��6$   $��1��61   $��4 4 0 0q�6B   $	��200��6`   ��6m   �� *	ProductId+ �� Mode$ OneWay=� � DataContext 6�   �� *SelectedItem+ �� ElementName$ ListView���� 5    
   -   5         ��Name$ SearchId��5       $��2��6$   $��2��61   $��4 4 4 4q�6A   $
��Auto��6R   $��Search��6_   6�   �� 5!   
   $��2��6   $��3��6   $��4 4 0 0q�6-   $��Name: ��6>   $
��Bold"�6O   �� 5"   
   -   5        $��txtName��5"   S   $
��Bold"�6   $��2��6$   $��4��61   $��4 4 0 0q�6B   $	��200��6b   ��6o   �� *ProductName+$ OneWay=� 6�   �� *SelectedItem+$ ListView���� 5$   
   $��3��6   $��0��6   $��4 4 0 0q�6-   $��
Category: ��6>   $
��Bold"�6S   �� 5%   
   -   5        $��txtCategory��5%   S   $
��Bold"�6   $��3��6$   $��1��61   $��4 4 0 0q�6B   $	��200��6f   ��6s   �� *
CategoryId+$ OneWay=� 6�   �� *SelectedItem+$ ListView���� 5&   
   $��3��6   $��3��6   $��4 4 0 0q�6-   $��Weight: ��6>   $
��Bold"�6Q   �� 5'   
   -   5        $��	txtWeight��5'   S   $
��Bold"�6   $��3��6$   $��4��61   $��4 4 0 0q�6B   $	��200��6d   ��6q   �� *Weight+$ OneWay=� 6�   �� *SelectedItem+$ ListView���� 5)   
   $��4��6   $��0��6   $��4 4 0 0q�6-   $��Unit Price: ��6>   $
��Bold"�6U   �� 5*   
   -   5        $��txtPrice��5*   S   $
��Bold"�6   $��4��6$   $��1��61   $��4 4 0 0q�6B   $	��200��6c   ��6p   �� *	UnitPrice+$ OneWay=� 6�   �� *SelectedItem+$ ListView���� 5+   
   -   5        $ SearchPrice��5+      $��4��6'   $��2��64   $��4 4 4 4q�6D   $��70��6U   $��Search��6`   6�   �� 5,   
   $��4��6   $��3��6   $��4 4 0 0q�6-   $��Units In Stock: ��6>   $
��Bold"�6Y   �� 5-   
   -   5        $��txtUnit��5-   S   $
��Bold"�6   $��4��6$   $��4��61   $��4 4 0 0q�6B   $	��200��6b   ��6o   �� *UnitsInStock+$ OneWay=� 6�   �� *SelectedItem+$ ListView���� 5.   
   -	   5        $ 
SearchUnit��5.      $��4��6&   $��5��63   $��4 4 4 4q�6C   $��70��6T   $��Search��6_   6�   �� 51   
   $��5��6   $��0��6"   $��6��62    �� Orientation$ 
Horizontal=�6F   $��Stretch=�6_   .+�52      �� -
   5        $
��Auto��52      $
��Auto��6"   $��50 10 20 10q�60   $
��Load��6E   6T   �� 53      -   5        $
��Auto��53      $
��Auto��6"   $��50 10 20 10q�60   $��Insert��6E   6V   �� 54      -   5        $
��Auto��54      $
��Auto��6"   $��50 10 20 10q�60   $��Update��6E   6V   �� 55      -   5        $
��Auto��55      $
��Auto��6"   $��50 10 20 10q�60   $��Delete��6E   6V   �� 56      -   5        $
��Auto��56      $
��Auto��6"   $��50 10 20 10q�60   $��Clear��6E   6U   57      &   System.Windows.Controls.DataGrid  59   
   -   5        $��ListView��59   x   $��0��6   $��6��6    $	��780��64      AutoGenerateColumns$ False��6@   	   CanUserResizeColumns$
	 True��6\   
   Columns
 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6%      Header$ 	ProductId��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   ��  �� Path$ 	ProductId�  5<      $	 170 6%   $ ProductName��61    6F   �� $ ProductName�  5=      $	 100 6%   $ 
CategoryId��61    6E   �� $ 
CategoryId�  5>      $	 100 6%   $ Weight��61    6A   �� $ Weight�  5?      $	 150 6%   $ 	UnitPrice��61    6D   �� $ 	UnitPrice�  5@      $ * 6%   $ UnitInStock��6/    6D   �� $ UnitsInStock�5C      �� 5D   
   $��6��6   $��0��6"   $��6��62   $ 
Horizontal=�6F   $��Stretch=�6_   .+�5E      �� -   5        $
��Auto��5E      $
��Auto��6"   $��50 10 20 10q�60   $��Member��6E   6V   �� 5F      -   5        $
��Auto��5F      $
��Auto��6"   $��50 10 20 10q�60   $��Order��6E   6U   5G      5H      5I      