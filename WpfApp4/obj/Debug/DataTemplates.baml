   M S B A M L   `   `   `  ����B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp4WpfApp4  5      -clr-namespace:WpfApp4.ModelWpfApp4.Model  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType    WpfApp4.Model.Student   studentDataTemplate � RowDefinitions � ColumnDefinitions �� TextWrapping(  "System.Windows.Controls.DatePicker   Text �� Mode �� SelectedItem �� Current �� Source	 �� Path   WpfApp4.Model.Group  groupDataTemplate�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:WpfApp4  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      *
localModelclr-namespace:WpfApp4.Model  5      %8  &	        &	 �    �� 5      "    6   .R�5	   
   �  5
      �� 5      �� 5      �� 5       5      �� 5      �� 5      $��3* �6#   .+�5      �� $
��Name��6   $��Stretch=�6#   $��0q�6A   $��Center=�6L   �� 5      $��1��6   $��Stretch=�6&   $��23��6D   $��0q�6P   $
 Wrap=�6[   $��Center=�6�   $
��Auto��6�   ��6o   �� *Name+6�   �� 5      $��	Admission��6   $��Stretch=�6(   $��0q�6F   $��1��6Q   $��Center=�6^     5      $
��Auto��6   $
��Auto��6'   $��1��64   $��1��6D   $��Center=�6y    6Q   �� *	Admission+$ TwoWay=�6y   �� 5      $��2��6   $��Group��6!   $
��Auto��61   $
��Auto��6?   $��Center=�6L   �� 5      $��2��6   $��1��6$   $
��Auto��64   $
��Auto��6B   $��Center=�6O    6j   �� *Group+��6�   �� # Z $ OneWay=�$	 db.Groups.Local�5      5      �� 5      "   6   .R�5   
   �  5      �� 5      �� 5      �� 5        5"      �� 5#      �� 5$      $��3* �6#   .+�5&      �� $��Course��6   $��Stretch=�6%   $��0q�6C   $��Center=�6N   �� 5'      $��1��6   $��Stretch=�6&   $��23��6D   $��0q�6P   $
 Wrap=�6[   $��Center=�6�   $
��Auto��6�   ��6o   �� *Course+6�   �� 5(      $��Number��6   $��Stretch=�6%   $��0q�6C   $��1��6N   $��Center=�6[   �� 5)      $��1��6   $��1��6#   $��Stretch=�63   $��23��6Q   $��0q�6]   $
 Wrap=�6h   $��Center=�6�   $
��Auto��6�   ��6|   �� *Number+6�   �� 5*      $��2��6   $��Track��6!   $
��Auto��61   $
��Auto��6?   $��Center=�6L   �� 5+      $��2��6   $��1��6#   $��Stretch=�63   $��23��6Q   $��0q�6]   $
 Wrap=�6h   $��Center=�6�   $
��Auto��6�   ��6|   �� *Track+6�   5,      5-      5.      