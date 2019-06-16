Imports System.IO
Imports System.Threading
Imports System.IO.Compression
Public Class Class_ControlRoom
    Property ListeSimulations As List(Of Class_Simulation)
    Property ListeThreads As List(Of Thread)
    Property ListeComputes As List(Of Class_Compute)
    Public Sub New()

    End Sub
    Public Sub New(NbPoint As Integer, Limite As Double, AxeFixe As Quaternion.QAxe, ValeurFixe As Double)
        If NbPoint > 1000 And NbPoint <= 1 Then
            Throw New System.Exception("NbPoint > 1000 Or NbPoint <=1")
        End If
        If NbPoint Mod 2 > 0 Then
            Throw New System.Exception("NbPoint is not multiple of 2")
        End If
        Me.ListeSimulations = New List(Of Class_Simulation)
        For i As Integer = 1 To 8
            Me.ListeSimulations.Add(New Class_Simulation(NbPoint, Limite, i, AxeFixe, ValeurFixe))
        Next
        Class_ArrayByte.Init(NbPoint, 3)

    End Sub

    Public Sub CalculLauch()
        ListeComputes = New List(Of Class_Compute)
        ListeThreads = New List(Of Thread)

        For i As Integer = 0 To 7
            ListeSimulations.Item(i).IsStop = False
            ListeComputes.Add(New Class_Compute(ListeSimulations.Item(i)))
            ListeThreads.Add(New Thread(New ThreadStart(AddressOf ListeComputes.Last.Compute)))
        Next
        For Each Thread In ListeThreads
            Thread.Start()
        Next

    End Sub
    Public Sub CalculStop()
        For Each Simulation In Me.ListeSimulations
            Simulation.IsStop = True
        Next
        For Each Thread In ListeThreads
            Thread.Join()
        Next

    End Sub
    Public Function CalculIsFinish() As Boolean
        For Each Thread In ListeThreads
            If Thread.ThreadState = ThreadState.Running Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Sub SaveAs(PathZipFile As String)

        If File.Exists(PathZipFile) Then File.Delete(PathZipFile)

        Dim pathTemp = Path.GetTempPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff")
        Directory.CreateDirectory(pathTemp)
        Dim pathTempDir = pathTemp + "\Data"
        Directory.CreateDirectory(pathTempDir)
        Dim pathTempData = pathTempDir + "\data.bin"
        Dim pathTempConfig = pathTempDir + "\Config.json"
        My.Computer.FileSystem.WriteAllBytes(pathTempData, Class_ArrayByte._memStream.ToArray, False)
        Class_ArrayByte.ClearMemory()
        Class_SerialisationAndUnSerialisation.Serialisation(Of List(Of Class_Simulation))(ListeSimulations, pathTempConfig)
        GC.Collect()

        ZipFile.CreateFromDirectory(pathTempDir, PathZipFile)

        Directory.Delete(pathTemp, True)


    End Sub


    Public Sub Open(PathZipFile As String)
        Dim pathTemp = Path.GetTempPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff")
        Directory.CreateDirectory(pathTemp)
        Dim pathTempDir = pathTemp + "\Data"
        Directory.CreateDirectory(pathTempDir)

        Dim pathTempData = pathTempDir + "\data.bin"
        Dim pathTempConfig = pathTempDir + "\Config.json"

        ZipFile.ExtractToDirectory(PathZipFile, pathTempDir)
        ListeSimulations = Class_SerialisationAndUnSerialisation.UnSerialisation(Of List(Of Class_Simulation))(pathTempConfig)
        Dim Datas = My.Computer.FileSystem.ReadAllBytes(pathTempData)
        Class_ArrayByte.Init(Datas, ListeSimulations.First)
        Datas = Nothing
        Directory.Delete(pathTemp, True)

        GC.Collect()
    End Sub
End Class
