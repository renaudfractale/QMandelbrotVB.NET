   M S B A M L   `   `   `  ���� E  AWpfApp_IHM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfApp_IHM
WpfApp_IHM      WpfApp_IHM.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:WpfApp_IHM     -     � Title$  
MainWindow��$	��460��$	��500��$	��500��$	��500��$	��460��$	��460��.����  �� Orientation$ Vertical=�.+��� -   $��
Image_Logo��$��0��$��0��$��2���� -   $��TextBox_PathMain��.���� -   $��ComboBox_ListeProject���� -   $��Button_Edit��$��0��.��Edit Project�� -   $��Border_Tilte��
�������$��10q�._��  � ColumnDefinitions �� $��1* ��� $��5* �.+��� -   $��TextBlock_ID��$��0��	ID : XXXX�� -   $��TextBox_NameProject��$��1��.��	Project�� -	   $��Border_AxeFixe��
����� �$��10q�._�$   WpfApp_IHM.UserControl_AxeFixe  -
     Name$ UCtrl_AxeFixe���� -   $��Border_Limite��
�������$��10q�._�#   WpfApp_IHM.UserControl_Limite  -     Name$ UCtrl_Limite���� -   $��Border_Button��
�������$��10q�._��  �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $��Button_Save��$��0��.��Save�� -   $��Button_Duplique��$��1��.��
Duplique�� -   $��
Button_Del��$��2��.��Del Project�� -   $��Button_QuitteWithOutSave��$��3��.��Quit WithOut Save�� -   $��Border_Statut��
�������$��10q�._��  �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� $��0��$��Right=�
Statut :�� -   $��TextBlock_Statut��$��1��	Stopped�� $��2��$��Right=�Completion :�� -   $��TextBlock_Completation��$��3��50 %�� -   $��Button_Generate��.��
Generate