Imports System.IO

Public Module Module_Path
    Sub CreateDir(PathDir As String)
        If Directory.Exists(PathDir) Then Directory.Delete(PathDir, True)
        Directory.CreateDirectory(PathDir)
    End Sub
End Module
