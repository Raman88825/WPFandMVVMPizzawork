   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pizzawork.Views.PizzaPizzawork.Views.Pizza  5      &     Pizzawork.Views.Pizza.PizzaTabUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Pizzawork.Views.Pizza     5        � 	Resources  5	      ��%    5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��0* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
PizzaDtgrd��5      $��1��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�5      ��5      ��  �� Path$ PizzasVM.Pizzas�	 �� SelectedItem	 5      �� $ PizzasVM.SelectedPizza�
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	PizzaId+  5       $ Состояние��6%    68   �� *State+  5!      $ 
Адрес��6%    64   �� *Spot.Address+   RowStyle 5#      �� 5$       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5%      �� 5&       �� Binding 6&   �� *State+ �� Value	 Ready6@   .a�5'      ��  �� Property � �� �� Value
 ��ح�6O   5(      �� 5)       6&   �� *State+ Ordered6@   .a�5*      ��  � ��
 �����6Q   5+      5-      5/      � 50   
   $��1��6   $��1��51       � DataContext 52      ��  �� ElementName$ 
PizzaDtgrd��$ SelectedItem� 54      �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6    �� 5;      $
��Auto �6     5=      �� 5>      $
��Auto �6#   �� 5?      .+�5A      �� $��Id��6   $��0��6!   �� 5B      $��1��61   ��6   �� *	PizzaId+61   �� 5C      $��
Номер��6   $��1��6$   �� 5D      $��1��66   $��1��6C   ��6   �� *SerialNumber+6C   �� 5E      $��Размер��6   $��2��6%   �� 5F      $��2��6.   $��1��6;   ��6   �� *Size+6;   �� 5G      $��Код доступа��6   $��3��6*   �� 5H      $��3��64   $��1��6A   ��6   �� *
AccessCode+6A   �� 5I      $��Состояние��6   $��4��6(   �� 5J      $��4��6/   $��1��6<   ��6   �� *State+6<   �� 5K      $��Модель��6   $��5��6%   �� 5L      $��5��6A   $��1��6N   ��6   �� *PizzaType.FullModelName+6N   �� 5M      $��
Адрес��6   $��6��6$   �� 5N      $��6��66   $��1��6C   ��6   �� *Spot.Address+6C   5O      �� 5P   
    �� Orientation$ 
Horizontal=�6    6.   �� $ PizzasVM�.+�5Q      ��  � ToolTip$! Добавить пиццу��6   ��6/   �� *AddPizzaCommand+.��5R      �� $��..\..\Icons\Add_Icon.png��6   $��35��6:   5S      �� 5T      $ Удалить пиццу��6   ��6.   �� *DeletePizzaCommand+.��5U      �� $!��..\..\Icons\Delete_Icon.png��6   $��30��6=   5V      �� 5W      $! Изменить пиццу��6   ��6.   �� *EditCommand+.��5X      �� $!��..\..\Icons\Change_Icon.png��6   $��30��6=   5Y      �� 5Z      $ Экспорт��6   ��6'   �� *ExportCommand+.��5[      �� $!��..\..\Icons\Export_Icon.png��6   $��30��6=   5\      �� 5]      $ Импорт��6   ��6&   �� *ImportCommand+.��5^      �� $!��..\..\Icons\Import_Icon.png��6   $��30��6=   5_      5`      5a      5c      