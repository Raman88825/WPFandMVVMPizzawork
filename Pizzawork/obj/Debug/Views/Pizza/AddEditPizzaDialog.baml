   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pizzawork.Views.PizzaPizzawork.Views.Pizza  5   	   .    (Pizzawork.Views.Pizza.AddEditPizzaDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Pizzawork.Views.Pizza     5   	   -   5          �Name$  AddEditDialogWindow��5	       � Title$( "Информация о пицце��5   	   $	��185��6$   $	��300��61    � 	Resources 5
       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� RelativeSource
 �� Path��%�  '��       '�� k     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 80��6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   �� 5       �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6    � ColumnDefinitions 5&   
   �� 5'      �� 5(      .+�5*   
   �� -   5         ��Name$ label1��5*      $��
Пицца��6    $��0��60   �� 5+   
   -   5        $ label2��5+      $��
Номер��6    $��1��60   �� 5,   
   -   5        $ label3��5,      $��Размер��6    $��2��61   �� 5-   
   -   5        $ label4��5-      $��Адрес заказа��6    $��3��67   �� 5.   
   -   5         ��Name$ comboBox��51       �� DisplayMemberPath$ FullModelName��5.   7   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5/      $��1��51   %   $��0��65   ��5.      �� $
 Models� �� SelectedItem 50      �� $
 SelectedPizzaType� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� Text 51   B   �� $
 PizzaTypeText�$ OneTime=��� 52   
   -   5         ��Name$ textBox��52   w   $��1��6�   $��1��6�   ��6   �� *Pizza.SerialNumber+$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   �� 53   
   -   5        $ textBox1��53   o   $��1��6�   $��2��6�   ��6   �� *
Pizza.Size+$ PropertyChanged=� . 6�   �� 54   
   -	   5        $ 	comboBox1��57      $ Address��54   6   $
 TrueY�55      $��1��57   &   $��3��66   ��54      �� $
 Spots� 56      �� $
 SelectedSpot�$ TwoWay=�$ PropertyChanged=� 58      �� $
 SpotText�$ OneTime=��� 59   
   -
   5         ��Name$ button��59   q   $��OK��6�   $��4��6�   ��6   �� $
 	OkCommand���64   ��  �� ElementName$ AddEditDialogWindow��6�   �� 5:   
   -   5        $ button1��5:      $��Cancel��6"   $��1��63   $��4��6C    �� IsCancel . 6P   5;      5<      