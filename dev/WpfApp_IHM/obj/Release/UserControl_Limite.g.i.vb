﻿#ExternalChecksum("..\..\UserControl_Limite.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","E3B94420E78001B32D9C1C3639B9DB901B16ECEDB706C042149662E38273B874")
'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell
Imports WpfApp_IHM


'''<summary>
'''UserControl_Limite
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class UserControl_Limite
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",21)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ComboBox_TypeLimite As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",25)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextBox_valueLimiteManual As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",27)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextBox_valueRmax As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",29)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextBox_valuePower As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",39)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ComboBox_NbpointsLimite As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\UserControl_Limite.xaml",41)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextBlock_Step As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/WpfApp_IHM;component/usercontrol_limite.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\UserControl_Limite.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.ComboBox_TypeLimite = CType(target,System.Windows.Controls.ComboBox)
            
            #ExternalSource("..\..\UserControl_Limite.xaml",21)
            AddHandler Me.ComboBox_TypeLimite.SelectionChanged, New System.Windows.Controls.SelectionChangedEventHandler(AddressOf Me.ComboBox_TypeLimite_SelectionChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.TextBox_valueLimiteManual = CType(target,System.Windows.Controls.TextBox)
            
            #ExternalSource("..\..\UserControl_Limite.xaml",25)
            AddHandler Me.TextBox_valueLimiteManual.TextChanged, New System.Windows.Controls.TextChangedEventHandler(AddressOf Me.TextBox_valueLimiteManual_TextChanged)
            
            #End ExternalSource
            
            #ExternalSource("..\..\UserControl_Limite.xaml",25)
            AddHandler Me.TextBox_valueLimiteManual.PreviewTextInput, New System.Windows.Input.TextCompositionEventHandler(AddressOf Me.TextBox_valueLimiteManual_PreviewTextInput)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 3) Then
            Me.TextBox_valueRmax = CType(target,System.Windows.Controls.TextBox)
            
            #ExternalSource("..\..\UserControl_Limite.xaml",27)
            AddHandler Me.TextBox_valueRmax.TextChanged, New System.Windows.Controls.TextChangedEventHandler(AddressOf Me.TextBox_valueRmax_TextChanged)
            
            #End ExternalSource
            
            #ExternalSource("..\..\UserControl_Limite.xaml",27)
            AddHandler Me.TextBox_valueRmax.PreviewTextInput, New System.Windows.Input.TextCompositionEventHandler(AddressOf Me.TextBox_valueRmax_PreviewTextInput)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            Me.TextBox_valuePower = CType(target,System.Windows.Controls.TextBox)
            
            #ExternalSource("..\..\UserControl_Limite.xaml",29)
            AddHandler Me.TextBox_valuePower.TextChanged, New System.Windows.Controls.TextChangedEventHandler(AddressOf Me.TextBox_valuePower_TextChanged)
            
            #End ExternalSource
            
            #ExternalSource("..\..\UserControl_Limite.xaml",29)
            AddHandler Me.TextBox_valuePower.PreviewTextInput, New System.Windows.Input.TextCompositionEventHandler(AddressOf Me.TextBox_valuePower_PreviewTextInput)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            Me.ComboBox_NbpointsLimite = CType(target,System.Windows.Controls.ComboBox)
            
            #ExternalSource("..\..\UserControl_Limite.xaml",39)
            AddHandler Me.ComboBox_NbpointsLimite.SelectionChanged, New System.Windows.Controls.SelectionChangedEventHandler(AddressOf Me.ComboBox_NbpointsLimite_SelectionChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            Me.TextBlock_Step = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

