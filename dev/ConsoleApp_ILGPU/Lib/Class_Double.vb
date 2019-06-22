Public Class Class_Double
    Property Value As Double = 0.0

    Property IsValide As Boolean = False


    Sub SetValue(v As Double)
        IsValide = True
        Value = v
    End Sub
End Class

