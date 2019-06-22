Public Class Class_BOX
    Property valMin As Byte
    Property valNax As Byte
    Property CenterX As Double
    Property CenterY As Double
    Property CenterZ As Double

    Property Size As Double
    Property Min As Double
    Property Max As Double

    Property SizeX As Double
    Property SizeY As Double
    Property SizeZ As Double

    Public Sub New()

    End Sub

    Public Sub New(Xmin As Double, Xmax As Double, Ymin As Double, Ymax As Double, Zmin As Double, Zmax As Double)
        SizeX = Xmax - Xmin
        SizeY = Ymax - Ymin
        SizeZ = Zmax - Zmin

        Me.CenterX = SizeX / 2.0 + Xmin
        Me.CenterY = SizeY / 2.0 + Ymin
        Me.CenterZ = SizeZ / 2.0 + Zmin


        Max = Math.Max(SizeX, SizeY)
        Max = Math.Max(Max, SizeZ)

        Min = Math.Min(SizeX, SizeY)
        Max = Math.Min(Max, SizeZ)

        Size = Max

    End Sub
End Class


