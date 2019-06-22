Imports System.IO
Imports System.IO.Compression
Imports System.Drawing
Module Module_Main
    Sub Main()
        Module_2DMandelbrot.Main(2.2, 100)

        'Dim ColorMap As New Class_ColorMap
        'Dim NbPoint = 1000
        'Dim Raw As New Bitmap(NbPoint, NbPoint)

        'For X As Integer = 0 To NbPoint - 1
        '    Console.WriteLine(X.ToString)
        '    For Y As Integer = 0 To NbPoint - 1
        '        Dim Z = Math.Max(X, Y)
        '        Dim ColorDouble = (CDbl(Z) / CDbl(NbPoint)) * 100.0
        '        Raw.SetPixel(X, Y, Class_ColorMap.GetColor(ColorDouble))
        '    Next
        'Next

        'Raw.Save("image.png")
    End Sub


End Module
