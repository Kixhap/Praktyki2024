   M S B A M L   `   `   `  ����	  WpfUI    WpfUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Main Window��5   	   $	��500��6   $	��800��6*   $	��220��5   	   $	��556��6   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��2��6;   $��0,0,0,10q�6O   .+�5      �� -   5         ��Name$ idBox��5      $��50��6%   $��0,0,10,0q�60    �� 
IsReadOnly$
 True��6B   �� 5      -   5        $ nameBox��5      $	��150��6'   $��0,0,10,0q�63   �� 5      -   5        $ priceBox��5      $	��100��6(   $��0,0,10,0q�64   �� 5      -   5        $	��Add��5      $��0,0,10,0q�6;    �� 	IsDefault$
 True��6M   �� 5      -   5        $��Update��5      $��0,0,10,0q�6A   �� 5      -   5        $��Delete��5      $��0,0,10,0q�6A   �� 5      -   5        $��Refresh��5      6'   5      �� 5   
   -	   5         ��Name$ itemsListView��5      $��1��6*   $��2��67    �� View 5      �� 5      .P�5      �� $��ID��6%   	 �� Width$	 50��6U   
 �� DisplayMemberBinding
 61   �� *Id+6U   �� 5       $
��Name��6%   $		 150��6Y   
 63   �� *Name+6Y   �� 5!      $��Price��6%   $		 100��6[   
 64   �� *Price+6[   5"      5$      5%      5&      