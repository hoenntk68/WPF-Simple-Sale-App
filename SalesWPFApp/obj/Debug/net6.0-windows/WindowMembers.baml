   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	       SalesWPFApp.WindowMembers   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  WindowLogin��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
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
��Auto �6   6,   .+�59   
   &   System.Windows.Controls.DataGrid  -   5        $��ListView��59   x   $��0��6   $��6��6    $	��780��64      AutoGenerateColumns$ False��6@      CanUserResizeColumns$
 True��6\      Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6%      Header$ Email��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� 	 �� Path$	 Email�  5<      $	 170 6%   $ Company Name��61    6G   �� $	 CompanyName�  5=      $	 100 6%   $
 City��61    6?   �� $
	 City�  5>      $	 100 6%   $ Country��61    6B   �� $	 Country�5@      �� 5A   
   $��6��6   $��0��6"   $��6��62   
 �� Orientation$
 
Horizontal=�6F   $��Stretch=�6_   .+�5B      �� -   5        $
��Auto��5B      $
��Auto��6"   $��50 10 20 10q�60   $��Product��6E   6W   �� 5C      -   5        $
��Auto��5C      $
��Auto��6"   $��50 10 20 10q�60   $��Order��6E   6U   5D      5E      5G      