﻿#ExternalChecksum("..\..\Application.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","AF72C5AB58CFAE2DE32B640C7ED0B0BD60DEBD8F90A02A722A920564AF8320BD")
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
'''Application
'''</summary>
Partial Public Class Application
    Inherits System.Windows.Application
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent()
        
        #ExternalSource("..\..\Application.xaml",5)
        Me.StartupUri = New System.Uri("MainWindow.xaml", System.UriKind.Relative)
        
        #End ExternalSource
    End Sub
    
    '''<summary>
    '''Application Entry Point.
    '''</summary>
    <System.STAThreadAttribute(),  _
     System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Shared Sub Main()
        Dim app As Application = New Application()
        app.InitializeComponent
        app.Run
    End Sub
End Class

