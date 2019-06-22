Imports System.IO
Imports System.IO.Compression
Public Module Module_3DMandelbrot
    Private Compute As Class_Compute3DMandelbrot
    Sub Main(Limite As Double, NbPoint As Integer, Optional PathDir As String = "D:\")

        Compute = New Class_Compute3DMandelbrot
        Compute.CompileKernel(True)

        For i As Integer = 0 To NbPoint - 1
            Log(i.ToString + " / " + (NbPoint - 1).ToString)
            Dim Contante = CDbl(i) / CDbl(NbPoint - 1) * Limite - Limite / 2.0
            GenerateDot(1000, CByte(5), Contante, i, PathDir)
        Next


    End Sub



    Sub Main(Contante As Double, Optional PathDir As String = "D:\")

        Compute = New Class_Compute3DMandelbrot
        Compute.CompileKernel(True)

        GenerateDot(1000, CByte(5), Contante, 0, PathDir)



    End Sub


    Private Sub GenerateDot(NbPoint As Integer, Seuil As Byte, Constante As Double, Id As Integer, PathDir As String)

        Dim Data(NbPoint * NbPoint * NbPoint + 1) As Byte

        Dim Datas = Data.ToArray
        Datas.SetValue(CByte(1), Datas.Length - 1)
        Dim Datas2 = Data.ToArray
        Datas2.SetValue(CByte(1), Datas2.Length - 1)

        ' Dim Compute = New Class_Compute
        Log("GetLimite Start")
        'Compute.CompileKernel(True)
        Dim Box As New Class_BOX(-10.0, 10.0, -10.0, 10.0, -10.0, 10.0)
        Compute.CalcGPU(Datas, NbPoint, Box, 4.0, Constante)
        Box = GetLimite(Datas, NbPoint, Box, Seuil)
        If Box.Size <= 0.5 Then
            Log("Vidage Memoire Start")
            Datas2 = Nothing
            Datas = Nothing
            Data = Nothing

            GC.Collect()
            Log("Vidage Memoire End")
            Exit Sub

        End If

        Box.Size *= 1.2

        Log("GetLimite End")
        Log("Compute Start")
        ' Compute.CompileKernel(True)
        Compute.CalcGPU(Datas, NbPoint, Box, 4.0, Constante)
        Log("Compute End")
        Dim nameDir = PathDir + "\" + Int2str(Id, 5)

        Module_Path.CreateDir(nameDir)
        Log("Save Plot + Filtrage Start")
        Using Toto As New StreamWriter(nameDir + "\plot.txt")
            For X As Integer = 1 To NbPoint - 2

                Dim Xvalue As Double = CDbl(X) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterX
                For Y As Integer = 1 To NbPoint - 2
                    Dim Yvalue As Double = CDbl(Y) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterY
                    For Z As Integer = 1 To NbPoint - 2
                        Dim Zvalue As Double = CDbl(Z) / CDbl(NbPoint - 1) * Box.Size - Box.Size / 2 + Box.CenterZ
                        Dim index As Integer = X * NbPoint * NbPoint + Y * NbPoint + Z
                        Dim Value = Datas(index)
                        If Value < Seuil Then Continue For
                        Dim FilterOK As Boolean = False
                        For XX As Integer = -1 To 1
                            For YY As Integer = -1 To 1
                                For ZZ As Integer = -1 To 1
                                    Dim index2 As Integer = (X + XX) * NbPoint * NbPoint + (Y + YY) * NbPoint + Z + ZZ
                                    FilterOK = Datas(index2) <> Value
                                    If FilterOK Then Exit For
                                Next
                                If FilterOK Then Exit For
                            Next
                            If FilterOK Then Exit For
                        Next

                        If FilterOK = False Then Continue For
                        Toto.WriteLine((Xvalue.ToString + ";" + Yvalue.ToString + ";" + Zvalue.ToString + ";" + Value.ToString).Replace(",", "."))
                        Datas2.SetValue(Value, index)
                    Next
                Next
            Next
        End Using
        Log("Save Plot + Filtrage End")
        Log("Save bin + Parameter Start")
        My.Computer.FileSystem.WriteAllBytes(nameDir + "\raw.bin", Datas, False)
        My.Computer.FileSystem.WriteAllBytes(nameDir + "\filtred.bin", Datas2, False)

        My.Computer.FileSystem.WriteAllText(nameDir + "\NPpoint.txt", NbPoint.ToString, False)
        Class_SerialisationAndUnSerialisation.Serialisation(Of Class_BOX)(Box, nameDir + "\Box.json")
        My.Computer.FileSystem.WriteAllText(nameDir + "\Constante.txt", Constante.ToString, False)
        My.Computer.FileSystem.WriteAllText(nameDir + "\Rmax.txt", (4.0).ToString, False)
        My.Computer.FileSystem.WriteAllText(nameDir + "\Seuil.txt", Seuil.ToString, False)
        Log("Save bin + Parameter End")

        Log("Vidage Memoire Start")
        Datas2 = Nothing
        Datas = Nothing
        Data = Nothing

        GC.Collect()
        Log("Vidage Memoire End")

        Log("ZIP Start")
        ZipFile.CreateFromDirectory(nameDir, nameDir + ".zip")

        Directory.Delete(nameDir, True)
        Log("ZIP End")
    End Sub

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
