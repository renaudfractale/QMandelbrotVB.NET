Imports System.IO
Imports System.IO.Compression
Module Module1
    Private Compute As Class_Compute
    Sub Main()
        Dim NbPoint = 500
        Dim Limite As Double = 8
        Compute = New Class_Compute
        Compute.CompileKernel(True)

        For i As Integer = 0 To NbPoint - 1
            Log(i.ToString + " / " + (NbPoint - 1).ToString)
            Dim Contante = CDbl(i) / CDbl(NbPoint - 1) * Limite - Limite / 2.0
            GenerateDot(1000, CByte(5), Contante, i)
        Next


    End Sub


    Private Sub GenerateDot(NbPoint As Integer, Seuil As Byte, Constante As Double, Id As Integer)

        Dim Limite As Double = 8
        Dim Data(NbPoint * NbPoint * NbPoint + 1) As Byte

        Dim Datas = Data.ToArray
        Datas.SetValue(CByte(1), Datas.Length - 1)
        Dim Datas2 = Data.ToArray
        Datas2.SetValue(CByte(1), Datas2.Length - 1)

        ' Dim Compute = New Class_Compute
        Log("GetLimite Start")
        'Compute.CompileKernel(True)
        Compute.CalcGPU(Datas, NbPoint, Limite, 4.0, Constante)
        Limite = GetLimite(Datas, NbPoint, Limite, Seuil)
        If Limite <= 1.0 Then
            Log("Vidage Memoire Start")
            Datas2 = Nothing
            Datas = Nothing
            Data = Nothing

            GC.Collect()
            Log("Vidage Memoire End")
            Exit Sub

        End If
        Log("GetLimite End")
        Log("Compute Start")
        ' Compute.CompileKernel(True)
        Compute.CalcGPU(Datas, NbPoint, Limite, 4.0, Constante)
        Log("Compute End")
        Dim nameDir = "D:\" + Int2str(Id, 5)
        Directory.CreateDirectory(nameDir)
        Log("Save Plot + Filtrage Start")
        Using Toto As New StreamWriter(nameDir + "\plot.txt")
            For X As Integer = 1 To NbPoint - 2

                Dim Xvalue As Double = CDbl(X) / CDbl(NbPoint - 1) * Limite - Limite / 2
                For Y As Integer = 1 To NbPoint - 2
                    Dim Yvalue As Double = CDbl(Y) / CDbl(NbPoint - 1) * Limite - Limite / 2
                    For Z As Integer = 1 To NbPoint - 2
                        Dim Zvalue As Double = CDbl(Z) / CDbl(NbPoint - 1) * Limite - Limite / 2
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
        My.Computer.FileSystem.WriteAllText(nameDir + "\Limite.txt", Limite.ToString, False)
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

    Private Function GetLimite(Datas As Byte(), NbPoint As Integer, Limite As Double, Seuil As Byte) As Double

        Dim DimMax As Double = 0.5
        For X As Integer = 1 To NbPoint - 2

            Dim Xvalue As Double = CDbl(X) / CDbl(NbPoint - 1) * Limite - Limite / 2
            For Y As Integer = 1 To NbPoint - 2
                Dim Yvalue As Double = CDbl(Y) / CDbl(NbPoint - 1) * Limite - Limite / 2
                For Z As Integer = 1 To NbPoint - 2
                    Dim Zvalue As Double = CDbl(Z) / CDbl(NbPoint - 1) * Limite - Limite / 2
                    Dim index As Integer = X * NbPoint * NbPoint + Y * NbPoint + Z
                    Dim Value = Datas(index)
                    If Value < Seuil Then Continue For

                    DimMax = Math.Max(DimMax, Math.Abs(Xvalue))
                    DimMax = Math.Max(DimMax, Math.Abs(Yvalue))
                    DimMax = Math.Max(DimMax, Math.Abs(Zvalue))

                Next
            Next
        Next

        Return DimMax * 2

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
