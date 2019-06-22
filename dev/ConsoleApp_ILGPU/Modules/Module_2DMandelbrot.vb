Imports System.IO
Imports System.IO.Compression
Imports System.Drawing

Public Module Module_2DMandelbrot
    Private Compute2D As Class_Compute2DMandelbrot
    Private Compute3D As Class_Compute3DMandelbrot
    Private ColorMap As Class_ColorMap
    Sub Main(Limite As Double, NbPoint As Integer, Optional PathDir As String = "D:\")


        ColorMap = New Class_ColorMap

        Compute2D = New Class_Compute2DMandelbrot
        Compute2D.CompileKernel(True)


        Compute3D = New Class_Compute3DMandelbrot
        Compute3D.CompileKernel(True)

        For i As Integer = 0 To NbPoint - 1
            Log(i.ToString + " / " + (NbPoint - 1).ToString)
            Dim Contante = CDbl(i) / CDbl(NbPoint - 1) * Limite - Limite / 2.0
            Log("Contante = " + Contante.ToString)
            GeneratePicture(500, CByte(5), Contante, i, PathDir)
        Next


    End Sub


    Sub Main(Contante As Double, Optional PathDir As String = "D:\")


        ColorMap = New Class_ColorMap

        Compute2D = New Class_Compute2DMandelbrot
        Compute2D.CompileKernel(True)


        Compute3D = New Class_Compute3DMandelbrot
        Compute3D.CompileKernel(True)


        Log("Contante = " + Contante.ToString)
        GeneratePicture(10000, CByte(5), Contante, 0, PathDir)



    End Sub
    Private Function GetLimiteBox(Constante As Double, Seuil As Byte) As Class_BOX
        Log("GetLimite Start")
        Dim NbPoint As Integer = 1000
        Dim Limite As Double = 15.0
        Dim Data(NbPoint * NbPoint * NbPoint + 1) As Byte

        Dim Datas = Data.ToArray
        Datas.SetValue(CByte(1), Datas.Length - 1)

        Dim Box As New Class_BOX(-10.0, 10.0, -10.0, 10.0, -10.0, 10.0)

        Compute3D.CalcGPU(Datas, NbPoint, Box, 4.0, Constante)

        Dim Out = GetLimite(Datas, NbPoint, Box, Seuil)

        Log("Vidage Memoire Start")
        Datas = Nothing
        Data = Nothing

        GC.Collect()
        Log("Vidage Memoire End")


        Log("GetLimite Start")

        Return Out
    End Function
    Private Function Get3DHisto(Constante As Double, Seuil As Byte, Box As Class_BOX) As Class_Histo
        Log("GetLimite Start")
        Dim NbPoint As Integer = 1000

        Dim Data(NbPoint * NbPoint * NbPoint + 1) As Byte

        Dim Datas = Data.ToArray
        Datas.SetValue(CByte(1), Datas.Length - 1)


        Compute3D.CalcGPU(Datas, NbPoint, Box, 4.0, Constante)

        Dim Out = Get1DHisto(Datas, Seuil)
        Out.GeneratePourcentage()
        Log("Vidage Memoire Start")
        Datas = Nothing
        Data = Nothing

        GC.Collect()
        Log("Vidage Memoire End")


        Log("GetLimite Start")

        Return Out
    End Function

    Private Sub GeneratePicture(NbPoint As Integer, Seuil As Byte, Constante As Double, Id As Integer, PathDir As String)


        Dim Box = GetLimiteBox(Constante, Seuil)
        Log("Box.SizeX =" + Box.SizeX.ToString + " ; " + "Box.SizeY =" + Box.SizeY.ToString + " ; " + "Box.SizeZ =" + Box.SizeZ.ToString)
        If Box.Size <= 0.5 Then Exit Sub

        Box.Size *= 1.2

        Dim Histo = Get3DHisto(Constante, Seuil, Box)
        Log("Histo.GetEcart = " + Histo.GetEcart.ToString)
        If Histo.GetEcart <= 5 Or Histo.GetMax = 0 Then Exit Sub

        Dim nameDir = PathDir + Int2str(Id, 5)

        Module_Path.CreateDir(nameDir)


        Module_3DMandelbrot.Main(Constante, nameDir)


        For Axe As Integer = 0 To 2

            Dim AxeDir = nameDir + "\" + Axe.ToString

            Module_Path.CreateDir(AxeDir)

            Log("Compute Start : Axe = " + Axe.ToString)
            For index As Integer = 0 To NbPoint - 1 Step 5


                Log("   Create Data Array Start")
                Dim Data(NbPoint * NbPoint + 1) As Byte

                Dim Datas = Data.ToArray
                Datas.SetValue(CByte(1), Datas.Length - 1)
                Dim Datas2 = Data.ToArray
                Datas2.SetValue(CByte(1), Datas2.Length - 1)
                Log("   Create Data Array End")

                Log("   Compute Start")
                Compute2D.CalcGPU(Datas, NbPoint, Box, Constante, Axe, index)
                Log("   Compute End")
                Dim HistoPicture = Get1DHisto(Datas, Seuil)

                If HistoPicture.GetEcart = 0 Or HistoPicture.GetMax = 0 Then
                    Log("   Histo.GetMax = 0")
                    Log("   Vidage Memoire Start")
                    Datas2 = Nothing
                    Datas = Nothing
                    Data = Nothing

                    GC.Collect()
                    Log("   Vidage Memoire End")
                    Continue For

                End If

                Log("   Fitrade Start")

                Dim Raw As New Bitmap(NbPoint, NbPoint)

                For X As Integer = 1 To NbPoint - 2

                    For Y As Integer = 1 To NbPoint - 2


                        Dim indexOfArray As Integer = X * NbPoint + Y
                        Dim Value = Datas(indexOfArray)
                        Raw.SetPixel(X, Y, Class_ColorMap.GetColor(Value, Histo))
                        If Value < Seuil Then Continue For
                        Dim FilterOK As Boolean = False
                        For XX As Integer = -1 To 1
                            For YY As Integer = -1 To 1
                                Dim index2 As Integer = (X + XX) * NbPoint + (Y + YY)
                                FilterOK = Datas(index2) <> Value
                                If FilterOK Then Exit For
                            Next
                            If FilterOK Then Exit For
                        Next

                        If FilterOK = False Then Continue For
                        Datas2.SetValue(Value, indexOfArray)

                    Next
                Next
                Log("   Fitrage End")

                Dim IndexDir = AxeDir + "\" + Int2str(index, 7)

                Module_Path.CreateDir(IndexDir)

                Log("   Save bin + Parameter Start")
                My.Computer.FileSystem.WriteAllBytes(IndexDir + "\raw.bin", Datas, False)
                My.Computer.FileSystem.WriteAllBytes(IndexDir + "\filtred.bin", Datas2, False)

                Raw.Save(IndexDir + "\raw.png")


                My.Computer.FileSystem.WriteAllText(IndexDir + "\NPpoint.txt", NbPoint.ToString, False)
                Class_SerialisationAndUnSerialisation.Serialisation(Of Class_BOX)(Box, IndexDir + "\Box.json")
                Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Histo)(Histo, IndexDir + "\Histo.json")
                My.Computer.FileSystem.WriteAllText(IndexDir + "\Constante.txt", Constante.ToString, False)
                My.Computer.FileSystem.WriteAllText(IndexDir + "\Rmax.txt", (4.0).ToString, False)
                My.Computer.FileSystem.WriteAllText(IndexDir + "\Seuil.txt", Seuil.ToString, False)
                Log("   Save bin + Parameter End")


                Log("   Vidage Memoire Start")
                Datas2 = Nothing
                Datas = Nothing
                Data = Nothing

                GC.Collect()
                Log("   Vidage Memoire End")

                Log("   ZIP Start")
                ZipFile.CreateFromDirectory(IndexDir, IndexDir + ".zip")

                Directory.Delete(IndexDir, True)
                Log("   ZIP End")
            Next
            Log("Compute End : Axe = " + Axe.ToString)
        Next




        Log("Save Plot + Filtrage Start")


        Log("Save bin + Parameter End")



    End Sub

    Private Function Get1DHisto(Array As Byte(), Seuil As Byte) As Class_Histo
        Dim Histo As New Class_Histo
        For i As Integer = 0 To Array.Length - 2
            Dim value = Array(i)
            If value < Seuil Then Continue For
            Histo.Add(value)
        Next

        Return Histo
    End Function

    Private Function GetLimite(Datas As Byte(), NbPoint As Integer, Box As Class_BOX, Seuil As Byte) As Class_BOX

        Dim Xmin As New Class_Double
        Dim Xmax As New Class_Double

        Dim Ymin As New Class_Double
        Dim Ymax As New Class_Double

        Dim Zmin As New Class_Double
        Dim Zmax As New Class_Double



        For X As Integer = 1 To NbPoint - 2

            Dim Xvalue As Double = CDbl(X) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterX
            For Y As Integer = 1 To NbPoint - 2
                Dim Yvalue As Double = CDbl(Y) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterY
                For Z As Integer = 1 To NbPoint - 2
                    Dim Zvalue As Double = CDbl(Z) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterZ
                    Dim index As Integer = X * NbPoint * NbPoint + Y * NbPoint + Z
                    Dim Value = Datas(index)
                    If Value < Seuil Then Continue For

                    If Xmin.IsValide = False Then
                        Xmin.SetValue(Xvalue)
                    End If
                    If Ymin.IsValide = False Then
                        Ymin.SetValue(Yvalue)
                    End If
                    If Zmin.IsValide = False Then
                        Zmin.SetValue(Zvalue)
                    End If
                    If Xmax.IsValide = False Then
                        Xmax.SetValue(Xvalue)
                    End If
                    If Ymax.IsValide = False Then
                        Ymax.SetValue(Yvalue)
                    End If
                    If Zmax.IsValide = False Then
                        Zmax.SetValue(Zvalue)
                    End If

                    Xmax.Value = Math.Max(Xmax.Value, Xvalue)
                    Xmin.Value = Math.Min(Xmin.Value, Xvalue)

                    Ymax.Value = Math.Max(Ymax.Value, Yvalue)
                    Ymin.Value = Math.Min(Ymin.Value, Yvalue)

                    Zmax.Value = Math.Max(Zmax.Value, Zvalue)
                    Zmin.Value = Math.Min(Zmin.Value, Zvalue)
                Next
            Next
        Next

        Return New Class_BOX(Xmin.Value, Xmax.Value, Ymin.Value, Ymax.Value, Ymin.Value, Ymax.Value)

    End Function

    Private Function Int2str(Id As Integer, nb As Integer) As String
        Dim txt = Id.ToString

        Do While txt.Length < nb
            txt = "0" + txt
        Loop

        Return txt
    End Function
    Private Sub Log(txt As String)
        Console.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss ffff") + " : " + txt)
    End Sub


End Module
