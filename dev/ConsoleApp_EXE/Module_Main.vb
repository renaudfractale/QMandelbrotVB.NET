Imports System.IO
Imports System.Threading
Imports ClassLibrary_Quaternion
Imports ClassLibrary_Quaternion.QMandelbrod

Module Module_Main

    Sub Main()
        Dim ArrayByte = New Class_ArrayByte
        ' Dim ControlRoom As New Class_ControlRoom(1000, 4.0, Quaternion.QAxe.X, 0.5)
        ' Log("CalculLauch 1")
        ' ControlRoom.CalculLauch()
        ' Thread.Sleep(10000)
        ' Log("CalculStop 1")
        ' ControlRoom.CalculStop()
        ' Log("SaveAs 1")
        ' ControlRoom.SaveAs("D:\Teste.zip")
        ' Thread.Sleep(5000)
        ' Log("Open 1")
        ' ControlRoom.Open("D:\Teste.zip")
        ' Thread.Sleep(5000)
        ' Log("CalculLauch 2")
        ' ControlRoom.CalculLauch()
        ' Thread.Sleep(20000)
        ' Log("CalculStop 2")
        ' ControlRoom.CalculStop()
        ' Log("SaveAs 2")
        ' ControlRoom.SaveAs("D:\Teste2.zip")




        'Class_ArrayByte.Init(1000, 3)
        'Class_ArrayByte.SetValue({0, 0, 0}, 250)
        'Class_ArrayByte.SetValue({500, 500, 500}, 250)
        'Class_ArrayByte.ClearMemory()
        Stop

    End Sub


    Private Sub Log(txt As String)
        Console.WriteLine(Now.ToString("HH:mm:ss ffff : ") + txt)
    End Sub
End Module
