
Public Class Class_Histo
    Property data As Integer()
    Property Pourcentage As Double()
    Property CountTotal As Integer = 0
    Public Sub New()
        Dim A(256) As Integer
        data = A.ToArray
        Dim B(256) As Double
        Pourcentage = B.ToArray
    End Sub

    Sub Add(val As Byte)
        Dim index = CInt(val)
        Dim value As Integer = CInt(data.GetValue(index))
        data.SetValue(value + 1, index)
        CountTotal += 1
    End Sub

    Public Function GetMin() As Integer
        For i As Integer = 0 To data.Length - 1
            If data(i) > 0 Then Return i
        Next
        Return data.Length - 1
    End Function

    Public Function GetMax() As Integer
        For i As Integer = data.Length - 1 To 0 Step -1
            If data(i) > 0 Then Return i
        Next
        Return 0
    End Function

    Public Function GetEcart() As Integer
        Return GetMax() - GetMin()
    End Function

    Public Sub GeneratePourcentage()
        Dim Total As Double = CDbl(Me.CountTotal)
        Dim cumul As Double = 0.0
        For i As Integer = 0 To data.Length - 1
            cumul += CDbl(data(i))
            Dim P = cumul / Total * 100.0
            Me.Pourcentage.SetValue(P, i)
        Next
    End Sub

    Public Function GetPourcentageCumul(value As Byte) As Double
        Return Pourcentage(CInt(value))
    End Function
End Class