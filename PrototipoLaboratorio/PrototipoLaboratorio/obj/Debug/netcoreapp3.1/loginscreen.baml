   M S B A M L   `   `   `  ����O  KPrototipoLaboratorio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PrototipoLaboratorioPrototipoLaboratorio  5   	   &     PrototipoLaboratorio.loginscreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PrototipoLaboratorio     5   	     � Title$
  ASII��5   	   $	��750��6   $
��1315��6#    � WindowStartupLocation$ CenterScreen=�60    � Icon$ 
/icono.png��6U   .��5	      � ��5
      �� 5       �� ImageSource$ Fondologin.jpg��6    j� Stretch$ UniformToFill=�6-    � ColumnDefinitions 5      �� 5      $	��47* �6   �� 5      $	��69* �6   �� 5      $
��147* �6   .+�5      �� $
��Left=�6   $	��558��6)   $��Center=�66   $	��438��6Q   $��1��6]   $��	203,0,0,0q�6m   $��2��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6+    �� Opacity$	 0.5Q�6>   .��5      � 	 � Color$	 Black��6   
 � Offset$
 1Q�6"   � 5      $	 White��6   $
 0Q�6"   5      5      A� 5      $��9,24,589,572q�6   $��2��6"   ��5      �� 5       �� Color$ White��6   $	 0.4Q�6$   5      �� 5      $
��Left=�6
   $	��100��6%   $��	16,36,0,0q�62   $	��Top=�6E   $	��100��6]   $��
/icono.png��6i   $��2��6}    J� OpacityMask 5       �� 5!      $ 
/icono.png��6   $	 0.7Q�6*   5#      �� 5$      -   5         ��Name$ 
txtUsuario��5$      $
��Left=�6    $��	9,376,0,0q�6;    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��218��6z   $��38��6�   $��Center=�6�   $��Century Gothic)�6�   $��16(�6�   $��2��6�   ��6�   Z� .��6#  ��5%      �� 5&      $ White��6   $	 0.6Q�6$   .��5'      5(      G� 5)      -   5         G�Name$ txtContraseña��5)      $
��Left=�6'   $��	9,448,0,0q�6B   $	��Top=�6U   $	��218��6m   $��36��6y   $��Center=�6�   $��Century Gothic)�6�   $��16(�6�   $��2��6�   ��6�   Z� ��5*      �� 5+      $ White��6   $	 0.6Q�6$   5-      �� 5.      $
��Left=�6
   $��76��6%   $��275,363,0,0q�61   $	��Top=�6F   $��64��6^   $��user.png��6i   $��1��6{   �� 5/      $
��Left=�6
   $��70��6%   $��275,434,0,0q�61   $	��Top=�6F   $��64��6^   $��key.png��6i   $��1��6z   �� 50      $��Laboratorio 
       ASII��6
   $
��Left=�66   $��275,196,0,0q�6Q   $	��Top=�6f   $	��128��6~   $	��294��6�   $��Century Gothic)�6�   $��48(�6�   $��Center=�6�   $��Center=�6�    J� Opacity$	 0.8Q�6  $��Italic$�6  $
��Bold"�6(  $��1��6:  $��2��6J  ��51      �� 52      $ White��6   $
 0.85Q�6$   54      �� 55      -   5         ��Name$ 	btnSignIn��55      $�� ��6   $
��Left=�6)   $��218,565,0,0q�6D   $	��Top=�6Y   $��64��6q   $��64��6}   $��2��6�   ��56      �� 57      $ loginbtn.png��6   $ Uniform=�6,   59      5;      5<      