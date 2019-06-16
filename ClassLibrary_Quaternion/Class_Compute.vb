Public Class Class_Compute
    Property Simulation As Class_Simulation
    Public Sub New(Simulation As Class_Simulation)
        Me.Simulation = Simulation
    End Sub
    Public Sub Compute()
        Dim Amin As Integer
        Dim Amax As Integer
        Dim Bmin As Integer
        Dim Bmax As Integer
        Dim Cmin As Integer
        Dim Cmax As Integer



        If Simulation.Type >= 5 Then
            Amin = Simulation.StartB
            Amax = Simulation.EndB
        Else
            Amin = Simulation.StartA
            Amax = Simulation.EndA
        End If

        If Simulation.Type <= 2 Or Simulation.Type >= 7 Then
            Bmin = Simulation.StartB
            Bmax = Simulation.EndB
        Else
            Bmin = Simulation.StartA
            Bmax = Simulation.EndA
        End If

        If Simulation.Type Mod 2 = 1 Then
            Cmin = Simulation.StartB
            Cmax = Simulation.EndB
        Else
            Cmin = Simulation.StartA
            Cmax = Simulation.EndA
        End If

        Dim Wmin As Integer
        Dim Wmax As Integer
        Dim Xmin As Integer
        Dim Xmax As Integer
        Dim Ymin As Integer
        Dim Ymax As Integer
        Dim Zmin As Integer
        Dim Zmax As Integer

        Dim WStart As Double
        Dim XStart As Double
        Dim YStart As Double
        Dim ZStart As Double
        ' -------- W Fixe ----------
        If Simulation.AxeFixe = Quaternion.QAxe.W Then
            Wmin = 0
            Wmax = 0
            WStart = Simulation.ValeurFixe

            'Pour le reste
            Xmin = Amin
            Ymin = Bmin
            Zmin = Cmin
            Xmax = Amax
            Ymax = Bmax
            Zmax = Cmax

            XStart = -Simulation.Limite / 2
            YStart = -Simulation.Limite / 2
            ZStart = -Simulation.Limite / 2
        ElseIf Simulation.AxeFixe = Quaternion.QAxe.X Then
            Xmin = 0
            Xmax = 0
            XStart = Simulation.ValeurFixe

            'Pour le reste
            Wmin = Amin
            Ymin = Bmin
            Zmin = Cmin
            Wmax = Amax
            Ymax = Bmax
            Zmax = Cmax

            WStart = -Simulation.Limite / 2
            YStart = -Simulation.Limite / 2
            ZStart = -Simulation.Limite / 2
        ElseIf Simulation.AxeFixe = Quaternion.QAxe.Y Then
            Ymin = 0
            Ymax = 0
            YStart = Simulation.ValeurFixe

            'Pour le reste
            Wmin = Amin
            Xmin = Bmin
            Zmin = Cmin
            Wmax = Amax
            Xmax = Bmax
            Zmax = Cmax

            WStart = -Simulation.Limite / 2
            XStart = -Simulation.Limite / 2
            ZStart = -Simulation.Limite / 2

        ElseIf Simulation.AxeFixe = Quaternion.QAxe.Z Then
            Zmin = 0
            Zmax = 0
            ZStart = Simulation.ValeurFixe

            'Pour le reste
            Wmin = Amin
            Xmin = Bmin
            Ymin = Cmin
            Wmax = Amax
            Xmax = Bmax
            Ymax = Cmax

            WStart = -Simulation.Limite / 2
            XStart = -Simulation.Limite / 2
            YStart = -Simulation.Limite / 2
        Else
            Throw New System.Exception("Simulation.AxeFixe have not valide value")
        End If


        Dim Wvalue As Double
        Dim Xvalue As Double
        Dim Yvalue As Double
        Dim Zvalue As Double

        Dim NbBoucle As Integer = 0
        Dim NbAvancement As Double = 0
        For W As Integer = Wmin To Wmax
            Wvalue = WStart + (CDbl(W) / CDbl(Simulation.NbPoint - 1)) * Simulation.Limite
            If Simulation.AxeFixe <> Quaternion.QAxe.W Then
                NbAvancement = CDbl(W) / CDbl(Simulation.NbPoint - 1)
                If Simulation.Avancement <= NbAvancement Then
                    SyncLock Simulation
                        Simulation.Avancement = NbAvancement
                    End SyncLock
                End If
            End If

            For X As Integer = Xmin To Xmax
                Xvalue = XStart + (CDbl(X) / CDbl(Simulation.NbPoint - 1)) * Simulation.Limite
                If Simulation.AxeFixe <> Quaternion.QAxe.X Then
                    NbAvancement = CDbl(W) / CDbl(Simulation.NbPoint - 1)
                    If Simulation.Avancement <= NbAvancement Then
                        SyncLock Simulation
                            Simulation.Avancement = NbAvancement
                        End SyncLock
                    End If
                End If
                For Y As Integer = Ymin To Ymax
                    Yvalue = YStart + (CDbl(Y) / CDbl(Simulation.NbPoint - 1)) * Simulation.Limite
                    For Z As Integer = Zmin To Zmax
                        Zvalue = ZStart + (CDbl(Z) / CDbl(Simulation.NbPoint - 1)) * Simulation.Limite


                        If Simulation.NoBoucle > NbBoucle Then
                            NbBoucle += 1
                            Continue For
                        End If

                        Dim Iter = QMandelbrod.Class_QMandelbrod.ComputeIter(New Quaternion.Class_Quaternion(Wvalue, Xvalue, Yvalue, Zvalue))
                        If Simulation.AxeFixe = Quaternion.QAxe.W Then
                            Class_ArrayByte.SetValue({X, Y, Z}, Iter)
                        ElseIf Simulation.AxeFixe = Quaternion.QAxe.X Then
                            Class_ArrayByte.SetValue({W, Y, Z}, Iter)
                        ElseIf Simulation.AxeFixe = Quaternion.QAxe.Y Then
                            Class_ArrayByte.SetValue({W, X, Z}, Iter)
                        ElseIf Simulation.AxeFixe = Quaternion.QAxe.Z Then
                            Class_ArrayByte.SetValue({W, X, Y}, Iter)
                        End If
                        NbBoucle += 1
                        If Simulation.IsStop Then
                            Simulation.NoBoucle = NbBoucle
                            Exit Sub
                        End If
                    Next
                Next
            Next
        Next





    End Sub

End Class
