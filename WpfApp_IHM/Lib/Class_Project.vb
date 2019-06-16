Imports ClassLibrary_Quaternion

Public Class Class_Project
    Property ID_Project As Integer
    Property Name_Project As String = "New Project " + ID_Project.ToString

    Property AxeFixe As Quaternion.QAxe = Quaternion.QAxe.W
    Property NbPointLimite As Integer = 1000
    Property Limite As Double = 4.0
    Property LimiteType As Integer = 1

    Property AxeFixeValeurStart As Double = -4.0
    Property AxeFixeValeurEnd As Double = 4.0
    Property AxeFixeNbPoint As Integer = 1000

    Property Rmax As Double = 4.0

    Property IsVisible As Boolean = True
    Public Function Key() As String
        Dim arrayStr = {Name_Project, AxeFixe.ToString,
        NbPointLimite.ToString, Limite.ToString, LimiteType.ToString,
        AxeFixeValeurStart.ToString, AxeFixeValeurEnd.ToString, AxeFixeNbPoint.ToString,
        Rmax.ToString}

        Return Join(arrayStr, "|"c)
    End Function

    Public Sub SetID(ID As Integer)
        Me.ID_Project = ID
    End Sub

    Public Sub New()

    End Sub

End Class
