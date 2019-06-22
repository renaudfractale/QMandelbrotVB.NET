﻿Imports ILGPU
Imports ILGPU.Runtime
Imports ILGPU.Runtime.CPU
Imports ILGPU.Runtime.Cuda
Imports ILGPU.XMath
Public Class Class_Compute3DMandelbrot
    ' Private Sub MandelbrotKernel(Index As Index3, NbPoints As Integer, Limite As Double, Rmax As Double, Power As Double, ArrayDatas As Byte())



    Private Shared context As Context
    Private Shared accelerator As Accelerator
    Private Shared mandelbrot_kernel As System.Action(Of Index3, Integer, Double, Double, Double, Double, Double, Double, ArrayView(Of Byte))

    Public Sub CompileKernel(withCUDA As Boolean)
        context = New Context()
        If withCUDA Then
            accelerator = New CudaAccelerator(context)
        Else
            accelerator = New CPUAccelerator(context)
        End If
        mandelbrot_kernel = accelerator.LoadAutoGroupedStreamKernel(Of Index3, Integer, Double, Double, Double, Double, Double, Double, ArrayView(Of Byte))(New Action(Of Index3, Integer, Double, Double, Double, Double, Double, Double, ArrayView(Of Byte))(AddressOf Kenerl))


    End Sub

    Shared Sub Kenerl(Index As Index3, NbPoints As Integer, Cote As Double, CX As Double, CY As Double, CZ As Double, Rmax As Double, Constante As Double, ArrayDatas As ArrayView(Of Byte))


        If Index.X >= NbPoints Then Exit Sub
        If Index.Y >= NbPoints Then Exit Sub
        If Index.Z >= NbPoints Then Exit Sub

        Dim X As Double = Constante
        Dim W As Double = CDbl(Index.X) / CDbl(NbPoints) * Cote - Cote / 2.0 + CX
        Dim Y As Double = CDbl(Index.Y) / CDbl(NbPoints) * Cote - Cote / 2.0 + CY
        Dim Z As Double = CDbl(Index.Z) / CDbl(NbPoints) * Cote - Cote / 2.0 + CZ


        Dim X_ As Double = Constante '-0.5
        Dim W_ As Double = CDbl(Index.X) / CDbl(NbPoints) * Cote - Cote / 2.0 + CX
        Dim Y_ As Double = CDbl(Index.Z) / CDbl(NbPoints) * Cote - Cote / 2.0 + CZ
        Dim Z_ As Double = CDbl(Index.Z) / CDbl(NbPoints) * Cote - Cote / 2.0 + CZ


        Dim Iter As Byte = CByte(0)
        Do While W * W + X * X + Y * Y + Z * Z < Rmax * Rmax And Iter < CByte(255)



            Dim x1 = X
            Dim y1 = Y
            Dim z1 = Z
            Dim w1 = W

            X = x1 * w1 + y1 * z1 - z1 * y1 + w1 * x1
            Y = -x1 * z1 + y1 * w1 + z1 * x1 + w1 * y1
            Z = x1 * y1 - y1 * x1 + z1 * w1 + w1 * z1
            W = -x1 * x1 - y1 * y1 - z1 * z1 + w1 * w1





            W += W_
            X += X_
            Y += Y_
            Z += Z_
            Iter += CByte(1)
        Loop
        ArrayDatas(Index.X * NbPoints * NbPoints + Index.Y * NbPoints + Index.Z) = Iter

    End Sub
    Public Shared Sub Dispose()
        accelerator.Dispose()
        context.Dispose()
    End Sub



    Public Sub CalcGPU(buffer As Byte(), NbPoints As Integer, Box As Class_BOX, Rmax As Double, Constante As Double)

        Dim num_values = buffer.Length
        Dim dev_out = accelerator.Allocate(Of Byte)(num_values)

        Dim i3 = New Index3(NbPoints, NbPoints, NbPoints)

        ' Launch kernel
        mandelbrot_kernel(i3, NbPoints, Box.Size, Box.CenterX, Box.CenterY, Box.CenterZ, Rmax, Constante, dev_out.View)
        accelerator.Synchronize()
        dev_out.CopyTo(buffer, 0, 0, num_values)

        dev_out.Dispose()
    End Sub
End Class
