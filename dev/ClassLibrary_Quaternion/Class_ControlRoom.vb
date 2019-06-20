Imports System.IO
Imports System.Threading
Imports System.IO.Compression
Imports ClassLibrary_Quaternion.QMandelbrod

Public Class Class_ControlRoom
    Property Simulation As Class_Simulation
    Property Thread As Thread
    Property Compute As Class_Compute
    Property Parameters As Class_Parameters
    Property ID As Integer
    Public Sub New()

    End Sub
    Public Sub New(Parameters As Class_Parameters, ID As Integer)
        Me.Parameters = Parameters
        If Parameters.Limite.NbPoint > 1000 And Parameters.Limite.NbPoint <= 1 Then
            Throw New System.Exception("NbPoint > 1000 Or NbPoint <=1")
        End If
        If Parameters.Limite.NbPoint Mod 2 > 0 Then
            Throw New System.Exception("NbPoint is not multiple of 2")
        End If
        Dim CQMandelbrod As New Class_QMandelbrod
        Class_QMandelbrod.Init(Parameters.Power)


        Me.Simulation = New Class_Simulation(Parameters, ID)



    End Sub

    Public Sub CalculLauch()
        Me.Simulation.IsStop = False
        Compute = New Class_Compute(Me.Simulation)
        Thread = New Thread(New ThreadStart(AddressOf Compute.Compute))
        Class_ArrayByte.Init(Parameters.Limite.NbPoint, 3)
        Thread.Start()


    End Sub
    Private Sub CalculStop()

        Simulation.IsStop = True
        Thread.Join()


    End Sub
    Public Function CalculIsFinish() As Boolean

        If Thread.ThreadState = ThreadState.Running Then
            Return False
        End If

        Return True
    End Function
    Public Sub SaveAs(PathZipFile As String)
        CalculStop()
        If File.Exists(PathZipFile) Then File.Delete(PathZipFile)

        Dim pathTemp = Path.GetTempPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss_ffff")
        Directory.CreateDirectory(pathTemp)
        Dim pathTempDir = pathTemp + "\Data"
        Directory.CreateDirectory(pathTempDir)
        Dim pathTempData = pathTempDir + "\data.bin"
        Dim pathTempConfig = pathTempDir + "\Config.json"
        My.Computer.FileSystem.WriteAllBytes(pathTempData, Class_ArrayByte._memStream.ToArray, False)
        Class_ArrayByte.ClearMemory()
        Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Simulation)(Simulation, pathTempConfig)
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
        Simulation = Class_SerialisationAndUnSerialisation.UnSerialisation(Of Class_Simulation)(pathTempConfig)
        Dim Datas = My.Computer.FileSystem.ReadAllBytes(pathTempData)
        Class_ArrayByte.Init(Datas, Simulation)
        Datas = Nothing
        Directory.Delete(pathTemp, True)

        GC.Collect()
    End Sub
End Class
