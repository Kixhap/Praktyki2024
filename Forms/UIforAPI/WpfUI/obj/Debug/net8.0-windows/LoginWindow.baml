   M S B A M L   `   `   `  ����	  WpfUI    WpfUI.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��150��6   $	��300��6$   $	��150��5   	   $	��300��6   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��	Username:��6   $��Center=�6%   $��0��6@   $��0��6M   $��0,0,10,0q�6]   �� 5   
   -   5         ��Name$ UsernameTextBox��5      $��0��6+   $��1��68   �� 5   
   $��	Password:��6   $��Center=�6%   $��1��6@   $��0��6M   $��	0,10,10,0q�6]   G� 5   
   -   5         G�Name$ PasswordBox��5      $��1��6+   $��1��68   $��0,10,0,0q�6H   �� 5   
   -   5         ��Name$ button��5      $��Login��6!   $��2��61   $��2��6>   $��0,10,0,0q�6R   $��Center=�6d    �� 	IsDefault$
 True��6�   5      5      