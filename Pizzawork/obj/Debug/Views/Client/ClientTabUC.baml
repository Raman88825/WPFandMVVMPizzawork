   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Pizzawork.Views.ClientPizzawork.Views.Client  5      (    "Pizzawork.Views.Client.ClientTabUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Pizzawork.Views.Client     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $#��Список клиентов��6   $��Center=�6*   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ClientDtgrd��5      $��2��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�5      ��5      ��  �� Path$ ClientVM.Clients� �� SelectedItem 5      �� $ ClientVM.SelectedClient�	 �� UpdateSourceTrigger$	 PropertyChanged=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
ClientId+  5       $ Фамилия��6%    66   �� *
LastName+  5!      $ Имя��6%    62   �� *	FirstName+  5"      $! Номер паспорта��6%    6=   �� *PassportNumber+  5#      $% Дата регистрации��6%    6?   �� *RegistrationDate+  5$      $ Email��6%    64   �� *Email+  5%      $ Телефон��6%    66   �� *Phone+5'      �� 5(   
   $��Заказы��6   $��1��6!   $��Center=�61   �� 5)   
   $��2��5*      $��1��6   ��5)      ��  �� ElementName$ ClientDtgrd��$ SelectedItem.Orders���5+      �� 5,      .R�5-      �� .+�5.      �� ��6$   �� $ OrderId� �� StringFormat$ Id заказа: {0}���� 5/      ��6$   �� $ PizzaId�$ Id пиццы: {0}���� 50      ��6$   �� $ StartSpot.Address�$( "Начальная точка: {0}���� 51      ��6$   �� $ EndSpot.Address�$&  Конечная точка: {0}�� �� TargetNullValue$$ Конечная точка: -���� 52      ��6$   �� $ StartDateTime�$ Начало: {0}���� 53      ��6$   �� $ EndDateTime�$ Конец: {0}��$ Конец: -���� 54      
����ح�6$   55      56      58      �� 5:   
   $��1��6    �� Orientation$ 
Horizontal=�6"    � DataContext 6;   �� $ ClientVM�.+�5;      ��  � ToolTip$% Добавить клиента��6   ��61   �� *
AddCommand+.��5<      �� $��..\..\Icons\Add_Icon.png��6   $��35��6:   5=      �� 5>      $# Удалить клиента��6   ��60   �� *DeleteCommand+.��5?      �� $!��..\..\Icons\Delete_Icon.png��6   $��30��6=   5@      5D      5E      5F      