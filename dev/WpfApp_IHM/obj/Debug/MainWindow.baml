   M S B A M L   `   `   `  ����E  AWpfApp_IHM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfApp_IHM
WpfApp_IHM  5   	       WpfApp_IHM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfApp_IHM     5   	   -   5          � Title$  
MainWindow��5   	   $	��460��6   $	��500��6)   $	��500��6L   $	��500��6[   $	��460��6j   $	��460��6z   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
   
   �� -   5        $��
Image_Logo��5
      $��0��6"   $��0��62   $��2��6?   6R   �� 5   
   -   5        $��TextBox_PathMain��5      .��6*   6-   �� 5   
   -   5        $��ComboBox_ListeProject��5      62   �� 5      -   5        $��Button_Edit��5      $��0��6,   .��6V   Edit Project6d   �� 5   
   -   5        $��Border_Tilte��5   :   
�������$��10q�6%   ._�5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��5* �6'   .+�5      �� -   5        $��TextBlock_ID��5      $��0��60   	ID : XXXX6K   �� 5      -   5        $��TextBox_NameProject��5      $��1��65   .��6E   	Project6N   5      5      �� 5   
   -	   5        $��Border_AxeFixe��5   9   
����� �$��10q�6$   ._�5      $   WpfApp_IHM.UserControl_AxeFixe  -
   5          Name$ UCtrl_AxeFixe��5   (   6A   5      �� 5   
   -   5        $��Border_Limite��5   :   
�������$��10q�6%   ._�5       #   WpfApp_IHM.UserControl_Limite  -   5          Name$ UCtrl_Limite��5    '   6?   5!      �� 5"   
   -   5        $��Border_Button��5"   >   
�������$��10q�6)   ._�5#      �  5$      �� 5%      $��1* �6'   �� 5&      $��1* �6'   �� 5'      $��1* �6'   �� 5(      $��1* �6'   .+�5*      �� -   5        $��Button_Save��5*      $��0��6,   .��6V   Save6\   �� 5+      -   5        $��Button_Duplique��5+      $��1��60   .��6^   
Duplique6h   �� 5,      -   5        $��
Button_Del��5,      $��2��6+   .��6T   Del Project6a   �� 5-      -   5        $��Button_QuitteWithOutSave��5-      $��3��69   .��6p   Quit WithOut Save6�   5/      50      �� 51   
   -   5        $��Border_Statut��51   >   
�������$��10q�6)   ._�52      �  53      �� 54      $��1* �6'   �� 55      $��1* �6'   �� 56      $��1* �6'   �� 57      $��1* �6'   .+�59      �� $��0��6   $��Right=�6,   
Statut :6R   �� 5:      -   5        $��TextBlock_Statut��5:      $��1��64   	Stopped6M   �� 5;      $��2��6   $��Right=�6,   Completion :6V   �� 5<      -   5        $��TextBlock_Completation��5<      $��3��6:   50 %6Q   5=      5>      �� 5?   
   -   5        $��Button_Generate��5?      .��6F   
Generate6Q   5A      5B      