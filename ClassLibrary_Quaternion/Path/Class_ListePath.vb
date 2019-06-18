Imports System.IO
Public Class Class_ListePath
    Shared Property PathMyDocument As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "QMandelbrod"
    Shared Property PathMyProjects As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + "QMandelbrod" + "\Projects.json"
    Public Shared Function GetPathProject(ID As Integer) As String
        Dim PathDir = PathMyDocument + "\" + ID.ToString
        If Not Directory.Exists(PathDir) Then Directory.CreateDirectory(PathDir)
        Return PathDir
    End Function




    Public Shared Function GetControlRooms(ID As Integer) As List(Of ClassLibrary_Quaternion.Class_ControlRoom)
        Dim Liste As New List(Of ClassLibrary_Quaternion.Class_ControlRoom)

        For i As Integer = 0 To 10000000
            Dim PathFile = GetPathControlRooms(ID, i)
            If File.Exists(PathFile) Then
                Liste.Add(ClassLibrary_Quaternion.Class_SerialisationAndUnSerialisation.UnSerialisation(Of ClassLibrary_Quaternion.Class_ControlRoom)(PathFile))
            Else
                Exit For
            End If
        Next


        Return Liste
    End Function
    Public Shared Sub SetControlRooms(ID As Integer, Liste As List(Of ClassLibrary_Quaternion.Class_ControlRoom))

        Directory.Delete(GetPathProject(ID), True)
        Directory.CreateDirectory(GetPathProject(ID))

        For i As Integer = 0 To Liste.Count - 1
            Dim PathFile = GetPathControlRooms(ID, i)
            Dim ControlRoom = Liste.Item(i)

            ClassLibrary_Quaternion.Class_SerialisationAndUnSerialisation.Serialisation(Of ClassLibrary_Quaternion.Class_ControlRoom)(ControlRoom, PathFile)


        Next
    End Sub

    Public Shared Function GetPathControlRooms(ID As Integer, No As Integer) As String
        Dim PathDir = PathMyDocument + "\" + ID.ToString + "\Simulation_" + No.ToString + ".json"
        Return PathDir
    End Function

End Class
