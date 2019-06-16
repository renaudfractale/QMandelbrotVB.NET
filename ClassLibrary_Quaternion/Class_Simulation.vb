Imports System.IO
Public Class Class_Simulation
    Property AxeFixe As Quaternion.QAxe
    Property NbPoint As Integer
    Property Limite As Double
    Property Type As Integer
    Property NoBoucle As Integer
    Property ValeurFixe As Double
    Property StartA As Integer
    Property EndA As Integer
    Property StartB As Integer
    Property EndB As Integer
    Property IsStop As Boolean
    Property Avancement As Double
    Public Sub New()

    End Sub

    Public Sub New(NbPoint As Integer, Limite As Double, Type As Integer, AxeFixe As Quaternion.QAxe, ValeurFixe As Double, Optional NoBoucle As Integer = -1)
        Me.NbPoint = NbPoint
        Me.Limite = Limite
        Me.Type = Type
        Me.NoBoucle = NoBoucle
        Me.AxeFixe = AxeFixe
        Me.ValeurFixe = ValeurFixe
        Me.Avancement = 0.0


        StartA = 0
        EndA = CInt(CDbl(NbPoint) / 2.0) - 1
        StartB = EndA + 1
        EndB = NbPoint - 1
        IsStop = False
    End Sub

    Public Sub SetValue(XNoPoint As Integer, YNoPoint As Integer, ZNoPoint As Integer, value As Byte)
        Class_ArrayByte.SetValue({XNoPoint, YNoPoint, ZNoPoint}, value)
    End Sub

    Public Function GetValue(XNoPoint As Integer, YNoPoint As Integer, ZNoPoint As Integer) As Byte
        Return Class_ArrayByte.GetValue({XNoPoint, YNoPoint, ZNoPoint})
    End Function



End Class
Namespace Quaternion
    Public Enum QAxe
        W
        X
        Y
        Z
    End Enum
End Namespace
