   M S B A M L   `   `   `  ����C  ?ToDoList, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToDoListAppToDoListApp  5   	       ToDoListApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *todoclr-namespace:ToDoListApp     5   	   -   5          � Title$  To Do:��5   	    � SizeToContent$ Width=�6   $	��400��6.    � 
ResizeMode$ CanMinimize=�6U    � WindowStyle$ 
ToolWindow=�6n    � Icon$" /ToDoList;component/todo.ico��6�    � 	Resources 5         itemMenu��%�   &	        �� 5   
   .@�5      m� -   5        $��_Edit��5      6&   m� 5	      -   5        $��_Mark as done��5	      6.   �� 5
      6   m� 5      -   5        $��_Delete��5      6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��1* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��lvToDo��5      $��Stretch=�6!   $��0��6>   $��3��6K    � ContextMenu# [  5   >   ��6f   �� 	 �� Path$	 Items�5      �� 5   
   -   5        $��label1��5   c   $��Item Description��6   $��1��6+   $
��Left=�68   $��0��6S   $��Center=�6q   �� 5   
   -   5        $��txtItemDesc��5      $��1��6%   $��1��62   �� 5   
   -   5        $��btnAdd��5   ]   $��Add Item��6   $��1��6$   $��right=�61   $��2��6M   6k   �� 5   
   -	   5        
 ��Name$
 chkShowDone��5      $��1��6(   $��2��69   $��2��6M   $��Show done items��6Z    d� 	IsChecked 6t   �� $	 ShowDoneItems� �� Mode$ TwoWay=�5       5!      