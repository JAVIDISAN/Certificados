   M S B A M L   `   `   `  ����C  ?AccesoBD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AccesoBDAccesoBD  5   	       AccesoBD.SearchingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:AccesoBD     5   	     � Title$  	Búsqueda��5   	   $	��300��6   $	��450��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��30* �6   6+   �� 5      $	��60* �6   6+   �� 5      $	��10* �6   6+   .+�5   
   �� $��Nombre:��6   $
��Left=�6"   $��	10,10,0,0q�6=   $	��Top=�6P   �� 5   
   -   5         ��Name$ txtPorNombre��5      $
��Left=�6(   $��
137,13,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��155��6�   $��13(�6�   �� 5   
   $��Apellido Paterno:��6   $
��Left=�6,   $��	10,34,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5        $ txtPorApePaterno��5      $
��Left=�6,   $��
137,37,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��155��6�   $��13(�6�   �� 5   
   $��Apellido Materno:��6   $
��Left=�6,   $��	11,61,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5        $ txtPorApeMaterno��5      $
��Left=�6,   $��
137,61,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��155��6�   $��13(�6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Realizar Búsqueda��6$   $
��Left=�6@   $��
297,37,0,0q�6[   $	��Top=�6o   $	��143��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgAlumnos��5      $��1��6Q   6^   �� 5   
   -   5        $ btnClose��5      $�� Cerrar Consulta ��6#   $��2��6?   $��Right=�6L   6�   5      5      