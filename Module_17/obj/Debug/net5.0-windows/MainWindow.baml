   M S B A M L   `   `   `  ����D  @Module_17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Module_17.ViewModelsModule_17.ViewModels  5   	       Module_17.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1vm"clr-namespace:Module_17.ViewModels     5   	   $	��800��5	   	   $
��1000��5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title 5   	   �� *Title+ � DataContext 5      .  (Module_17.ViewModels.ViewModelMainWindow  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $	��57* �6   �� 5      $
��211* �6    � ColumnDefinitions 5   
   �� 5      $
��156* �6   �� 5      $
��156* �6   �� 5       $
��156* �6   �� 5!      $	��53* �6   �� 5"      $
��160* �6   �� 5#      $
��160* �6   �� 5$      $
��160* �6   .+�5'   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridMSSql��5'      $��5q�5(      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5)         SelectionMode$ Single=�5*         AutoGenerateColumns$ False��5+      	   
IsReadOnly$	 False��5.      
   CanUserDeleteRows$

 True��5/      $��4��50      $��7��51      ��5,      �� *SqlDataTableClient+ �� SelectedItem 5-      �� *
CurrentRow+   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      -   5        id��,  &System.Windows.Controls.DataGridColumn   Header$ Id��55   %      
IsReadOnly$
 True��56   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 54   %   �� *Id+57        59      -   5        SurnameClient��$ Фамилия��5;   %   $ False��5<   %    5:   %   �� *SurnameClient+5=        5?      -   5        
NameClient��$ Имя��5A   %   $ False��5B   %    5@   %   �� *
NameClient+5C        5E      -   5        PatronymicClient��$ Отчество��5G   %   $ False��5H   %    5F   %   �� *PatronymicClient+5I        5K      -   5        NumberPhoneClient��$! Номер телефона��5M   %   $ False��5N   %    5L   %   �� *NumberPhoneClient+5O        5Q      -   5        EmailClient��$ 
Почта��5S   %   $ False��5T   %    5R   %   �� *EmailClient+5U      5W      �� 5Y   
   $��5q�5Z      $��7��5[      $��4��5\      $��3��5]      ��5Y      �� *GroupboxTitleClient+5^      �� 5`   
   $��Center=�5a      $��Center=�5b      $��10,5,5,5q�5c      $��4��5d      $��1��5e      ��5`      �� *	Surname+5f      �� 5g   
   $��Center=�5h      $��Center=�5i      $��5��5j      $��5q�5k       �� TextWrapping$
 Wrap=�5l      $��1��5m      ��5g      �� *TextboxSurname+ �� Mode$ TwoWay=�.��5m      5n      �� 5p   
   $��Center=�5q      $��Center=�5r      $��10,5,5,5q�5s      $��4��5t      $��2��5u      ��5p      �� *Name+5v      �� 5w   
   $��Center=�5x      $��Center=�5y      $��5��5z      $��5,5,5,5q�5{      $
 Wrap=�5|      $��2��5}      ��5w      �� *TextboxName+$ TwoWay=�.��5}      5~      �� 5�   
   $��Center=�5�      $��Center=�5�      $��10,5,5,5q�5�      $��4��5�      $��3��5�      ��5�      �� *
Patronymic+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��5��5�      $��5,5,5,5q�5�      $
 Wrap=�5�      $��3��5�      ��5�      �� *TextboxPatronymic+$ TwoWay=�.��5�      5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��10,5,5,5q�5�      $��4��5�      $��4��5�      ��5�      �� *NumberPhone+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��5��5�      $��5,5,5,5q�5�      $
 Wrap=�5�      $��4��5�      ��5�      �� *TextboxPhoneNumber+$ TwoWay=�.��5�      5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��10,5,5,5q�5�      $��4��5�      $��5��5�      ��5�      �� *Email+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��5��5�      $��5,5,5,5q�5�      $
 Wrap=�5�      $��5��5�      ��5�      �� *TextboxEmail+$ TwoWay=�.��5�      5�      �� 5�   
   $��6��6   $%��Добавить клиента��5�      $��5,5,10,5q�5�      $��1��6#   ��5�      �� *CommandAddClient+5�      �� 5�   
   $��6��6   $#��Удалить клиента��5�      $��5,5,10,5q�5�      $��2��5�      ��5�      �� *CommandDeleteClient+5�      �� 5�   
   $��6��6   $%��Показать покупки��5�      $��5,5,10,5q�5�      $��3��5�      ��5�      �� *CommandLoadPurchaseClient+5�      �� 5�   
   $��6��6   $#��Обновить данные��5�      $��5,5,10,5q�5�      $��4��5�      ��5�      �� *CommandUpdateClient+5�        5�   
   $��7��6   $��4��5�      $��5q�5�      $��4��5�      $
 TrueY�5�      $ Single=�5�      $ False��5�      $	 False��5�      $

 True��5�       5�      �� *
CurrentRow+��5�      �� *SqlDataTablePurchaseClient+ 5�        5�      $ Id��5�   %   $
 True��5�   %    5�   %   �� *Id+5�        5�      $ Почта клиента��5�   %   $
 True��5�   %    5�   %   �� *
EmailBuyer+5�        5�      $ Код продукта��5�   %   $
 True��5�   %    5�   %   �� *CodeProduct+5�        5�      $' !Название продукта��5�   %   $
 True��5�   %    5�   %   �� *NameProduct+5�      5�      �� 5�   
   $��4��6   $��3��5�      $��5q�5�      $��4��5�      $��7��5�      ��5�      �� *GroupboxTitleBuyer+5�      �� 5�   
   $%��Добавить покупку��6   $��5,5,10,5q�5�      $��8��5�      $��6��5�      ��5�      �� *CommandAddBuyer+5�      �� 5�   
   $��Center=�5�      $��Center=�5�      $��5��5�      $��5q�5�      $
 Wrap=�5�      $��8��5�      ��5�      �� *TextboxCodeProduct+.��5�      5      �� 5  
   $��Center=�5     $��Center=�5     $��5��5     $��5q�5     $
 Wrap=�5     $��9��5     ��5     �� *TextboxNameProduct+.��5     5	     �� 5
  
   $��Center=�5     $��Center=�5     $��10,5,5,5q�5     $��4��5     $��8��5     ��5
     �� *CodeProduct+5     �� 5  
   $��Center=�5     $��Center=�5     $��10,5,5,5q�5     $��4��5     $��9��5     ��5     �� *NameProduct+5     5     5     