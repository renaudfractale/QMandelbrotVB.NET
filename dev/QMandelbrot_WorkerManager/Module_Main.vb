﻿Imports System.IO
Imports System.IO.Compression
Imports System.Threading
Imports ClassLibrary_Quaternion
Module Module_Main
    Private NBthread As Integer = 4
    Sub Main()
        Dim Args = Environment.GetCommandLineArgs()
        Dim ID As Integer = 0
        If Args.Count = 2 Then ' Old simulation
            ID = CInt(Args(1).Replace(Chr(34), ""))
        Else
            Exit Sub
        End If

        Dim Pathzip = Path.GetTempFileName
        My.Computer.FileSystem.WriteAllBytes(Pathzip, My.Resources.Worker, False)
        Dim PathWorkerDir As String = Path.GetTempPath + "\" + Now.ToString("yyyy-MM-dd HH-mm-ss ffff")
        ZipFile.ExtractToDirectory(Pathzip, PathWorkerDir)
        Dim PathWorker = Directory.GetFiles(PathWorkerDir, "*.exe")(0)
        Log("Path Worker.exe : " + PathWorker)

        Dim toto As New Class_ListePath

        Dim ListeSimulations = Directory.GetFiles(Class_ListePath.GetPathProject(ID), "*.json")
        Dim Lp As New List(Of Process)
        Dim Lpi As New List(Of ProcessStartInfo)
        For Each SimulationFile In ListeSimulations
            Log("Lancer de " + SimulationFile)

            Lp.Add(New Process)
            Lpi.Add(New ProcessStartInfo)

            Dim arguments = " "
            arguments += GString(SimulationFile) + " "
            arguments += GString(SimulationFile + ".zip") + " "

            Dim P = Lp.Last
            Dim pi = Lpi.Last
            pi.Arguments = arguments
            pi.FileName = PathWorker
            pi.WorkingDirectory = PathWorkerDir
            pi.CreateNoWindow = True
            P.StartInfo = pi
            ' P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            P.Start()


            Dim localByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(PathWorker))
            If localByName.Length >= NBthread Then
                Do
                    Thread.Sleep(30000)
                Loop While Process.GetProcessesByName(Path.GetFileNameWithoutExtension(PathWorker)).Length >= NBthread
            End If
            Thread.Sleep(5000)
            'Stop
        Next




        Directory.Delete(PathWorkerDir, True)
    End Sub
    Private Sub Log(txt As String)
        Console.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss ffff") + " : " + txt)
    End Sub
    Private Function GString(txt As String) As String
        Return Chr(34) + txt + Chr(34)
    End Function

End Module
