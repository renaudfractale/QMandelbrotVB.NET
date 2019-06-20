Imports ClassLibrary_Quaternion
Imports System.IO
Public Class Class_Project
    Property ID_Project As Integer
    Property Name_Project As String = "New Project " + ID_Project.ToString


    Property NbPointLimite As Integer = 1000
    Property Limite As Double = 4.0
    Property LimiteType As Integer = 1

    Property AxeFixe As Quaternion.QAxe = Quaternion.QAxe.W
    Property AxeFixeValeurStart As Double = -4.0
    Property AxeFixeValeurEnd As Double = 4.0
    Property AxeFixeNbPoint As Integer = 1000

    Property Rmax As Double = 4.0
    Property Power As Double = 2.0


    Property IsVisible As Boolean = True
    Public Function Key() As String
        Return Newtonsoft.Json.JsonConvert.SerializeObject(Me)
    End Function

    Public Sub SetID(ID As Integer)
        Me.ID_Project = ID
    End Sub

    Public Sub New()

    End Sub

    Public Sub GenerateControlsRooms()
        Dim ListeCtrlRooms As New List(Of Class_ControlRoom)
        If AxeFixeValeurEnd = AxeFixeValeurStart Then
            Dim Parameters As New Class_Parameters(Rmax, Power, AxeFixe, AxeFixeValeurStart, AxeFixeNbPoint, NbPointLimite, Limite, LimiteType)

            For i As Integer = 1 To 8
                ListeCtrlRooms.Add(New Class_ControlRoom(Parameters, i))
            Next
        Else
            For i As Integer = 0 To AxeFixeNbPoint - 1
                Dim Value = (CDbl(i) / CDbl(AxeFixeNbPoint - 1) * (Math.Abs(AxeFixeValeurEnd - AxeFixeValeurStart))) + AxeFixeValeurStart
                Dim Parameters As New Class_Parameters(Rmax, Power, AxeFixe, Value, AxeFixeNbPoint, NbPointLimite, Limite, LimiteType)
                For j As Integer = 1 To 8
                    ListeCtrlRooms.Add(New Class_ControlRoom(Parameters, j))
                Next
            Next
        End If


        Dim ListeCtrlRoomsSource = Class_ListePath.GetControlRooms(ID_Project)

        If ListeCtrlRoomsSource.Count <> ListeCtrlRooms.Count Then
            Class_ListePath.SetControlRooms(ID_Project, ListeCtrlRooms)
        Else
            Dim A = ListeCtrlRoomsSource.First.Parameters.Key
            Dim B = ListeCtrlRooms.First.Parameters.Key
            If A <> B Then
                Class_ListePath.SetControlRooms(ID_Project, ListeCtrlRooms)
            End If
        End If
    End Sub


End Class
