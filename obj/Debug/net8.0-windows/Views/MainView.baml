   M S B A M L   `   `   `  ����O  KNavegacionLateralWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NavegacionLateralWPF.ViewsNavegacionLateralWPF.Views  5   	   Q-clr-namespace:NavegacionLateralWPF.PropertiesNavegacionLateralWPF.Properties  5   	   Q-clr-namespace:NavegacionLateralWPF.ViewModelsNavegacionLateralWPF.ViewModels  5   	   )    #NavegacionLateralWPF.Views.MainView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:NavegacionLateralWPF.Views     5   	   ;p-clr-namespace:NavegacionLateralWPF.Properties     5   	   <vm-clr-namespace:NavegacionLateralWPF.ViewModels     5   	   /   )NavegacionLateralWPF.Properties.Resources    Título � Title# Z  5
   	   $	��450��6/   $	��800��6<    � WindowStyle$
 None=�6H    � DataContext 5   
   3  -NavegacionLateralWPF.ViewModels.MainViewModel  5       � 	Resources 5       �� Source�� 5   
   $ /Resources/Resources.xaml?�6   %    ��5      �� 5   
    �� Color$ #000000��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��190 �6   �� 5      $��* �6   .+�5   
   ��  �� CornerRadius$ 10��6   ���#333333$��5q�68   ._�5      ]� .+�5      �� $	��120��6   $	��120��5      $ 8��5      ���#444444$��Center=�5!      $��0, 10, 0, 0q�5"      $	��Top=�5#      	� 5%         
MenuButton#��[  6   	 d� 	IsChecked$
	 TrueY�5&   J   
 	� 	GroupName$
 SideMenu��6[   $��10, 15, 10, 0q�5'      $	��Top=�5(         Inicio#��Z 5)      
 � Tag$  /Resources/Images/home.png��5*      ��5&      �� *ActivateHomeViewCommand+5+      	� 5-      #��[  6   $
 SideMenu��5.   N   $��10, 10, 10, 0q�5/      $	��Top=�50         	Empleados#��Z 51      $$ /Resources/Images/empleado.png��52      ��5.      �� *ActivateEmpleadoViewCommand+53      	� 55      #��[  6   $
 SideMenu��56   R   $��10, 10, 10, 0q�57      $	��Top=�58         Departamentos#��Z 59      $( "/Resources/Images/departamento.png��5:      ��56      �� *!ActivateDepartamentoViewCommand+5;      	� 5=      #��[  6   $
 SideMenu��5>   M   $��10, 10, 10, 0q�5?      $	��Top=�5@         Graficas#��Z 5A      $# /Resources/Images/grafica.png��5B      ��5>      �� *ActivateGraficaViewCommand+5C      	� 5E      #��[  6   $
 SideMenu��5F   N   $��10, 10, 10, 0q�5G      $	��Top=�5H         Ajustes#��Z 5I      $$ /Resources/Images/settings.png��5J      ��5F      �� *ActivateSettingsViewCommand+5K      �� 5M        MyButton#��[ 6   $��15, 0, 15, 30q�5N      $��Bottom=�5O         Salir#��Z 5Q      $  /Resources/Images/exit.png��5R      ��5P      �� *SalirButtonCommand+5S      5U      5V      �� 5W   
   $ 10��6   ���#F5F5F5$��
0, 5, 5, 5q�68   $��1��6L   ._�5X      �� ��6   �� *
ActiveView+5Y      5Z      5[      