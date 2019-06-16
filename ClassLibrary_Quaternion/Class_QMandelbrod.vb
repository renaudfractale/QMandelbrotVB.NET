Namespace QMandelbrod
    Public Class Class_QMandelbrod

        Shared Property _Power As Double = 2.0
        Shared Property _Itermin As Byte = CByte(0)
        Shared Property _Itermax As Byte = CByte(255)
        Shared Property _Rmax As Double

        Public Shared Sub Init(Power As Double, Optional Itermin As Byte = CByte(0),
                               Optional Itermax As Byte = CByte(255),
                               Optional Rmax As Double = 4.0)
            _Power = Power
            _Itermin = Itermin
            _Itermax = Itermax
            _Rmax = Rmax
        End Sub

        Public Shared Function ComputeIter(ByVal Quaternion As Quaternion.Class_Quaternion) As Byte
            Dim nb_iter As Byte = CByte(0)
            Dim QuaternionCompute = New Quaternion.Class_Quaternion(Quaternion)
            Do
                QuaternionCompute.Power(_Power)
                QuaternionCompute.Add(Quaternion)
                nb_iter += CByte(1)

                If nb_iter >= _Itermax Then Exit Do
            Loop Until QuaternionCompute.length > _Rmax

            If nb_iter >= _Itermin Then Return nb_iter
            Return 0

        End Function
    End Class
End Namespace