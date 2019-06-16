Imports System.IO

Public Class Class_ArrayByte

    Shared Property _lenght As Integer = 1

    Shared Property _NbPointByDimension As Integer = 1
    Shared Property _NbDimension As Integer = 1

    Shared Property _memStream As MemoryStream

    Public Shared Sub Init(NbPointByDimension As Integer, NbDimension As Integer)
        _NbPointByDimension = NbPointByDimension
        _NbDimension = NbDimension
        _lenght = _NbPointByDimension

        For i As Integer = 1 To _NbDimension - 1
            _lenght *= _NbPointByDimension
        Next
        'ClearMemory()

        _memStream = New MemoryStream(_lenght)
        _memStream.Position = _memStream.Capacity - 1
        _memStream.WriteByte(CByte(1))
    End Sub

    Public Shared Sub SetValue(ArrayDimPose As Integer(), value As Byte)
        Dim Pose As Integer = 0
        Dim Power = 0
        For Each PoseDim In ArrayDimPose
            If PoseDim >= _NbPointByDimension Then
                Throw New System.Exception("NoPoint >= _NbPointByDimension")
            End If
            Pose += PoseDim * Pow(_NbPointByDimension, Power)
            Power += 1
        Next
        SyncLock _memStream
            _memStream.Position = Pose
            _memStream.WriteByte(value)
        End SyncLock

    End Sub


    Public Shared Function GetValue(ArrayDimPose As Integer()) As Byte
        Dim Pose As Integer = 0
        Dim Power = 0
        For Each PoseDim In ArrayDimPose
            If PoseDim >= _NbPointByDimension Then
                Throw New System.Exception("NoPoint >= _NbPointByDimension")
            End If
            Pose += PoseDim * Pow(_NbPointByDimension, Power)
            Power += 1
        Next
        Dim value As Byte = CByte(0)
        SyncLock _memStream
            _memStream.Position = Pose
            value = CByte(_memStream.ReadByte())
        End SyncLock

        Return value
    End Function

    Public Shared Sub ClearMemory()
        _memStream.Close()
        _memStream = Nothing
    End Sub

    Public Shared Sub Init(Datas As Byte(), Simulation As Class_Simulation)
        _NbPointByDimension = Simulation.NbPoint
        _NbDimension = 3
        _lenght = _NbPointByDimension

        For i As Integer = 1 To _NbDimension - 1
            _lenght *= _NbPointByDimension
        Next
        'ClearMemory()
        _memStream = New MemoryStream(Datas)
    End Sub
    Private Shared Function Pow(a As Integer, Power As Integer) As Integer
        Dim value As Integer = 1

        For i As Integer = 1 To Power - 1
            value *= a
        Next

        Return value
    End Function


End Class
