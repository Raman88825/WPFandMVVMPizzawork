   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Pizzawork.Views.ClientPizzawork.Views.Client  5   	   ,    &Pizzawork.Views.Client.AddClientDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Pizzawork.Views.Client     5   	   -   5          �Name$  AddClientDlg��5	   	    � Title$) #Добавление клиента��5   	   $	��300��6$   $	��300��61    � 	Resources 5
       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� RelativeSource
 �� Path��%�  '��       '�� k     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 80��6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   5      �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   �� 5       �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   �� 5(      $
��Auto �6    � ColumnDefinitions 5*   
   �� 5+      $
��auto �6   �� 5,      $��* �6   .+�5.   
   �� -   5         ��Name$ label1��5.      $��Фамилия��6    $��0��62   �� 5/   
   -   5        $ label2��5/      $��Имя��6    $��1��6.   �� 50   
   -   5        $ label3��50      $��Отчество��6    $��2��63   �� 51   
   -   5        $ label4��51      $!��Номер паспорта��6    $��3��69   �� 52   
   $��Email��6   $��4��6    �� 53   
   $��Телефон��6   $��5��6"   �� 55   
   $��1��6t   ��6   �� *Client.LastName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6t   �� 56   
   $��1��6v   $��1��6�   $��1,0,-1,0q�6�   ��6   �� *Client.FirstName+$ PropertyChanged=� . 6�   �� 57   
   $��1��6v   $��2��6�   ��6   �� *Client.Patronymic+$ PropertyChanged=� . 6�   �� 58   
   $��1��6{   $��3��6�   ��6   �� *Client.PassportNumber+$ PropertyChanged=� . 6�   �� 59   
   $��1��6r   $��4��6�   ��6   �� *Client.Email+$ PropertyChanged=� . 6�   �� 5:   
   $��1��6r   $��5��6�   ��6   �� *Client.Phone+$ PropertyChanged=� . 6�   �� 5<   
   -   5         ��Name$ button��5<   j   $��OK��6z   $��6��6�   ��6   �� $
 	OkCommand���64   ��  �� ElementName$ AddClientDlg��6�   �� 5=   
   -   5        $ button1��5=      $��Cancel��6"   $��1��63   $��6��6C    �� IsCancel . 6P   5>      5?      