   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pizzawork.Views.OrderPizzawork.Views.Order  5   	   *    $Pizzawork.Views.Order.AddOrderDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Pizzawork.Views.Order     5   	   -   5          �Name$  AddDialogWindow��5	       � Title$! Добавить заказ��5   	   $	��150��6    $	��300��6-    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       '�� k     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 80��6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Клиент��6   �� 5   
   $��Адрес заказа��6   $��1��6'   �� 5    
   -   5        $ label1��5       $��
Пицца��6    $��2��60   �� 5!   
   	 �� DisplayMemberPath$	 LastName��5"      
 �� 
IsEditable
 .   �� 
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$
 TrueY�5%       �� SelectedValuePath$ ClientId��5&      $��1��5(      $��0��6#   ��5!      ��  �� Path$ Clients� �� SelectedValue 5'      �� *Order.ClientId+ �� Mode$ TwoWay=�5(   #   �� 5*   
   -   5         ��Name$ cb_spots��5+      $	 Address��5,      
 .   . $
 TrueY�5/      $ SpotId��50      $��1��52      $��1��6#   ��5*      �� $ Spots� 51      �� $ Order.StartSpotId�$ TwoWay=�52   #   �� 55   
   $	 SerialNumber��56      
 .   . $
 TrueY�59      $ PizzaId��5:      $��1��5<      $��2��6#   ��55      ��  �� ElementName$ cb_spots��$ SelectedItem.Pizzas� 5;      �� $ Order.PizzaId�$ TwoWay=�5<   #   �� 5>   
   -   5         ��Name$ button��5>   m   $��OK��6}   $��3��6�   ��6   �� $ 	OkCommand���64   �� $ AddDialogWindow��6�   �� 5?   
   -   5        $ button1��5?      $��Cancel��6"   $��1��63   $��3��6C    �� IsCancel . 6P   5@      5B      