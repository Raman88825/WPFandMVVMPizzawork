   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pizzawork.Views.OrderPizzawork.Views.Order  5      &     Pizzawork.Views.Order.OrderTabUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Pizzawork.Views.Order     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
OrderDtgrd��5      $��2��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .  �� SelectedValuePath$ OrderId��5         SelectionMode$ Single=�5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      ��5      �� 	 �� Path$	 OrderVM.Orders�
 �� SelectedValue
 5      �� $	 OrderVM.SelectedOrderId� �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	OrderId+  5       $ ID клиента��6%    69   �� *
ClientId+  5!      $ ID пиццы��6%    67   �� *	PizzaId+  5"      $# Начальная точка��6%    6>   �� *StartSpot.Address+  5#      $! Конечная точка��6%    6=   �� *EndSpot.Address+  5$      $ Время начала��6%    6;   �� *StartDateTime+  5%      $# Время окончания��6%    6>   �� *EndDateTime+ �� TargetNullValue$ -��  5&      $( "Продолжительность��6%    6@   �� *
Duration+5(      �� 5)   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��2��6;    � DataContext 5*      �� $	 OrderVM�.+�5+      ��  � ToolTip$ Открыть заказ��6   ��6.   �� *
AddCommand+.��5,      �� $��..\..\Icons\Add_Icon.png��6   $��35��6:   5-      �� 5.      $' !Подтвердить заказ��6   ��62   �� *StopCommand+.��5/      �� $��..\..\Icons\Stop_Icon.png��6   $��29��6;   50      51      52      53      