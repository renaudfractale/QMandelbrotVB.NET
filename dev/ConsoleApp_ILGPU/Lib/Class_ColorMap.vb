Imports System.Drawing
Public Class Class_ColorMap


    Public Shared Function GetColor(value As Byte, Histo As Class_Histo) As Color

        Dim len As Double = Histo.GetPourcentageCumul(value)
        Return GetColor(len)
    End Function

    Public Shared Function GetColor(value As Double) As Color
        Dim frequency As Double = 1.5 * Math.PI / 100.0


        Dim phase1 = 0.0 * 120.0 / 180.0 * Math.PI
        Dim phase2 = 1.0 * 120.0 / 180.0 * Math.PI
        Dim phase3 = 2.0 * 120.0 / 180.0 * Math.PI

        Dim center = 128.0
        Dim amplitute = 128.0


        If value = 0.0 Then
            Return Color.FromArgb(255, 255, 255)
        Else
            Dim red = Limite256(CInt(Math.Floor((Math.Sin(frequency * value + phase1) * amplitute * 1.0) + center * 1.0)))
            Dim grn = Limite256(CInt(Math.Floor((Math.Sin(frequency * value + phase2) * amplitute * 1.0) + center * 1.0)))
            Dim blu = Limite256(CInt(Math.Floor((Math.Sin(frequency * value + phase3) * amplitute * 1.0) + center * 1.0)))

            Return Color.FromArgb(red, grn, blu)
        End If


    End Function


    Private Shared Function Limite256(Value As Integer) As Integer
        Return Math.Min(Math.Max(0, Value), 255)
    End Function
End Class
