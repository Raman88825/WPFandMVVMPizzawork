   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Pizzawork.Views.PizzaTypePizzawork.Views.PizzaType  5   	   C&clr-namespace:Pizzawork.InfrastructurePizzawork.Infrastructure  5   	   1    +Pizzawork.Views.PizzaType.AddEditTypeDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Pizzawork.Views.PizzaType     5   	   6inf&clr-namespace:Pizzawork.Infrastructure     5   	   -   5          �Name$  AddDialogWindow��5	   E    � Title$7 1Введите информацию о пицце��6	   $	��300��6,   $	��300��69    � 	Resources 5
      3   -Pizzawork.Infrastructure.ImageSourceConverter   ImageConverter �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� RelativeSource
 �� Path��%,  &	        '��      '�� ~     '�� �     '�� �      5   
   6#   �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 80��6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   �� 5       �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   " ��6    5       P� 5!       �@=�HasError . . �5"      ��  � ��
 �����63   �� 5#       � ��
 �   �63   �� 5$       �@�ToolTip 5%      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5'      5)      5*      .��5,      �  � RowDefinitions 5-   
   �� 5.      $
��Auto �6   �� 5/      $
��Auto �6   �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6   �� 53      $��* �6   �� 54      $
��Auto �6    � ColumnDefinitions 56   
   �� 57      $
��auto �6   �� 58      $��* �6   .+�5:   
   �� -   5         ��Name$ label��5:      $��ID��6   �� 5;   
   -   5        $ label1��5;      $!��Торговая марка��6    $��1��69   �� 5<   
   -   5        $ label2��5<      $��Модель��6    $��2��61   �� 5=   
   -   5        $ label3��5=      $��Описание��6    $��3��63   �� 5>   
   -   5        $ label4��5>      $��Изображение��6    $��4��66   �� 5?   
   -   5         ��Name$ 	textBlock��5?   6   $��1��6I   ��6   �� *Type.PizzaTypeId+6I   �� 5@   
   -   5         ��Name$ listBox��5E       �� 
IsEditable .  �� 
IsReadOnly .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�5C      $��1��5E   $   $��1��64   ��5@      �� $
 
Trademarks� �� SelectedItem 5D      �� $
 SelectedTrademark� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  �� Text 5F      �� $
 TypedTrademark�$ TwoWay=�$ PropertyChanged=� . �� 5G   
   -	   5         ��Name$ textBox��5G   o   $��1��6�   $��2��6�   ��6   �� *
Type.Model+$ PropertyChanged=� . 6�   �� 5H   
   -
   5        $ textBox1��5H   u   $��1��6�   $��3��6�   ��6   �� *Type.Description+$ PropertyChanged=� . 6�   �� 5I   
   $��Выбрать��6   $��18��6O   $��Center=�6[   $��4��6v   $��1��6�   ��6#   �� $
 SelectImageCommand�6�   �� 5J   
   $	��300��6   $	��150��6   $��0��6/   $��5��6?   $��2��6L   ��5K      �� 5L      $
 Type.ImageLink�6    �� 	Converter# [  60    �� TargetNullValue 5M      ��5N      !/Icons/Default_Pizza_Icon.png��6E   5P      5R      �� 5S   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��4��6>   $��Right=�6K   5T      �� 5U   
   -   5         ��Name$ button��5U   m   $��OK��6}   $��6��6�   ��6   �� $
 	OkCommand���64   ��  �� ElementName$ AddDialogWindow��6�   �� 5V   
   -   5        $ button1��5V      $��Cancel��6"   $��1��63   $��6��6C    �� IsCancel . 6P   5W      5X      