   M S B A M L   `   `   `  ����D  @Pizzawork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Pizzawork.Views.SpotPizzawork.Views.Spot  5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5   	   C&clr-namespace:Pizzawork.InfrastructurePizzawork.Infrastructure  5   	   (    "Pizzawork.Views.Spot.AddSpotDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Pizzawork.Views.Spot     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   6inf&clr-namespace:Pizzawork.Infrastructure     5   	   -   5          �Name$  AddSpotDialogWindow��5   	    � Title$! Добавить заказ��5
   	   $	��400��6    $	��720��6-    � 	Resources 5      5   /Pizzawork.Infrastructure.AddressStringConverter   AddressConverter �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� RelativeSource
 �� Path��%e  &	        '��      '�� ~     '�� �      5   
   6%   �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 80��6)   5      �� 5   
   " ��6   �5      �� 5       � ��$	 150��6-    5      P� 5       �@=�HasError . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   �� 5       �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5      5      �� 5    
   " ��6   .�5!      ��  � ��$ Center=�62   �� 5"       � ��$ 0,5,0,5q�6'   5#      5$      .��5%      �  � RowDefinitions 5&   
   �� 5'      $��* �6   �� 5(      $��* �6   �� 5)      $��* �6   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6    � ColumnDefinitions 50   
   �� 51      $
��Auto �6   �� 52      $��* �6   �� 53      $��* �6   .+�55   
   �� -   5         ��Name$ label��55      $��Страна��6   �� 56   
   -   5        $ label1��56      $��
Город��6    $��1��60   �� 57   
   -   5        $ label2��57      $��
Адрес��6    $��2��60   �� 58   
   -   5        $ label3��58      $��Широта��6    $��3��61   �� 59   
   -   5        $ label4��59      $��Долгота��6    $��4��62   �� 5:   
   -   5        $ label5��5:      $��Вместимость��6    $��5��66   �� 5;   
   $'��!Результаты поиска��6   $��6��6,   '  !Microsoft.Maps.MapControl.WPF.Map  5<   
   -   5          Name$	 Map��5<   N     
BingMapKey+  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProvider# [ 6   $��2��5=      $��8��5>         Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 53.883146, 27.568331 5?         	ZoomLevel$ 10Q�5@         Children. 5A      3  -Microsoft.Maps.MapControl.WPF.MapItemsControl  ��6    �� $
 FindedLocations���5B      �� 5C      .R�5D      +  %Microsoft.Maps.MapControl.WPF.Pushpin     Location 6$   �� $
 Location�5E      5G      5H      �� 5I   
    J� Opacity$ 80Q�6    �� Orientation$ 
Horizontal=�6"   $��3��5J      $	��Top=�5K      $��5q�5L      .+�5M      �� $��1q�6   
����ح�._�5N      �� 
������ $	��200��5P      ��5N      �� *SearchRequest+ �� UpdateSourceTrigger$ PropertyChanged=�5P      5R      �� 5S      
������ $��0q�6P   ��6   �� *SearchCommand+.��5T      �� $!��..\..\Icons\Search_Icon.png��6   $��25��6=   $��25��6H   5U      5V      �� 5W   
   -	   5         ��Name$ textBox��5W   �   $��1��6�   ��6   �� $
 Spot.Country� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors . $ PropertyChanged=�6�   �� 5X   
   -
   5        $ textBox1��5X   �   $��1��6�   $��1��6�   ��6   �� $
 	Spot.City� .  . $ PropertyChanged=�6�   �� 5Y   
   -   5        $ textBox2��5Y   �   $��1��6�   $��2��6�   ��6   �� $
 Spot.Address� .  . $ PropertyChanged=�6�   �� 5Z   
   -   5        $ textBox3��5Z   �   $��1��6�   $��3��6�   ��6   �� $
 SelectedLocation.Latitude� .  . $ PropertyChanged=�6�   �� 5[   
   -   5        $ textBox4��5[   �   $��1��6�   $��4��6�   ��6   �� $ 
 SelectedLocation.Longitude� .  . $ PropertyChanged=�6�   �� 5\   
   -   5        $ textBox5��5\   �   $��1��6�   $��5��6�   ��6   �� $
 Spot.Capacity� .  .  �� NotifyOnValidationError . $ PropertyChanged=�6�   �� 5]   
   $��6��6@   $��1��6M   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5_      ��5]      �� $
 FindedAddresses� �� SelectedIndex 5^      �� *SelectedAddressIndex+ �� Mode$ TwoWay=� �� DisplayMemberPath 6N   �� *FormattedAddress+5`      �� 5a   
   -   5         ��Name$ button��5a   r   $��OK��6�   $��7��6�   ��6   �� $
 	OKCommand���64   ��   �� ElementName$  AddSpotDialogWindow��6�   �� 5b   
   -   5        $ button1��5b      $��Cancel��6"   ! �� IsCancel! . $��1��6C   $��7��6S   5c      5d      