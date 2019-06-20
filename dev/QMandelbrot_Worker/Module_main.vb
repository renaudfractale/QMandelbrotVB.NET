Imports ClassLibrary_Quaternion
Imports System.IO
Imports System.Threading

Module Module_main

    Sub Main()
        Dim Args = Environment.GetCommandLineArgs()
        Dim PathControlRooms As String = ""
        Dim PathDatas As String = ""
        If Args.Count = 3 Then ' Old simulation
            PathControlRooms = Args(1).Replace(Chr(34), "")
            PathDatas = Args(2).Replace(Chr(34), "")
        Else
            Exit Sub
        End If
        If PathDatas = "" Then
            Exit Sub
        End If
        If PathControlRooms <> "" AndAlso File.Exists(PathControlRooms) Then

        Else
            Exit Sub
        End If
        Dim ControlRoom = Class_SerialisationAndUnSerialisation.UnSerialisation(Of Class_ControlRoom)(PathControlRooms)

        If File.Exists(PathDatas) Then
            ControlRoom.Open(PathDatas)
        End If

        ControlRoom.CalculLauch()

        Do
            Thread.Sleep(30000)

            If ControlRoom.CalculIsFinish Then Exit Do

        Loop Until File.Exists("Stop.txt")

        ControlRoom.SaveAs(PathDatas)
    End Sub



End Module
