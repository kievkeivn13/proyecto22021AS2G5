   M S B A M L   `   `   `  ����O  KPrototipoLaboratorio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PrototipoLaboratorioPrototipoLaboratorio  5   	   &     PrototipoLaboratorio.rptPaciente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PrototipoLaboratorio     5   	     � Title$  rptPaciente��5   	   $	��450��6   $	��976��6*   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5
      $��Center=�6#   $��	0,34,0,60q�6@   $	��956��6S      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6_      
IsReadOnly$
 True��6k      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+   ClipboardContentBinding 6<   Z� 6}     5      $	 CUI��6`   $
 True��6m   $	 100 6    6%   �� *cui+ 6=   Z� 6     5      $	 NIT��6`   $
 True��6m   $ 90 6    6%   �� *nit+ 6=   Z� 6     5      $ Nombre��6c   $
 True��6s   $ 90 6�    6%   �� *nombre+ 6@   Z� 6�     5      $ Apellido��6e   $
 True��6w   $ 90 6�    6%   �� *
apellido+ 6B   Z� 6�     5      $ Genero��6c   $
 True��6s   $ 50 6�    6%   �� *genero+ 6@   Z� 6�     5      $
 Edad��6a   $
 True��6o   $ 40 6�    6%   �� *edad+ 6>   Z� 6�     5      $ Telefono��6e   $
 True��6w   $ 60 6�    6%   �� *
telefono+ 6B   Z� 6�     5      $ 	Direccion��6f   $
 True��6y   $	 100 6�    6%   �� *	direccion+ 6C   Z� 6�     5      $ Email��6b   $
 True��6q   $ 80 6�    6%   �� *email+ 6?   Z� 6�     5      $ Status��6c   $
 True��6s   $ 45 6�    6%   �� *status+ 6@   Z� 6�     5      $ Seguro��6c   $
 True��6s   $ * 6�    6%   �� *seguro+ 6@   Z� 6�   5      5      5      