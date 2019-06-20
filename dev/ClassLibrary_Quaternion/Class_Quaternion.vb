Namespace Quaternion
    Public Class Class_Quaternion
        Property w As Double = 0.0
        Property x As Double = 0.0
        Property y As Double = 0.0
        Property z As Double = 0.0

        Public Sub New()

        End Sub

        Public Sub New(Quaternion As Class_Quaternion)
            Me.w = Quaternion.w
            Me.x = Quaternion.x
            Me.y = Quaternion.y
            Me.z = Quaternion.z
        End Sub


        Public Sub New(w As Double, x As Double, y As Double, z As Double)
            Me.w = w
            Me.x = x
            Me.y = y
            Me.z = z
        End Sub

#Region "Operation"
        Public Sub Normalise()
            Dim n = Me.length
            Me.x /= n
            Me.y /= n
            Me.z /= n
            Me.w /= n
        End Sub

        Public Sub Add(s As Double)
            Me.x += s
            Me.y += s
            Me.z += s
            Me.w += s
        End Sub
        Public Sub Add(Quaternion As Class_Quaternion)
            Me.Add(Quaternion.x, Quaternion.y, Quaternion.z, Quaternion.w)
        End Sub

        Public Sub Add(x As Double, y As Double, z As Double, w As Double)
            Me.x += x
            Me.y += y
            Me.z += z
            Me.w += w
        End Sub
        Public Sub Multiplication(Quaternion As Class_Quaternion)
            Me.Multiplication(Quaternion.x, Quaternion.y, Quaternion.z, Quaternion.w)
        End Sub
        Public Sub Multiplication(x2 As Double, y2 As Double, z2 As Double, w2 As Double)
            Dim x1 = x
            Dim y1 = y
            Dim z1 = z
            Dim w1 = w

            Me.x = x1 * w2 + y1 * z2 - z1 * y2 + w1 * x2
            Me.y = -x1 * z2 + y1 * w2 + z1 * x2 + w1 * y2
            Me.z = x1 * y2 - y1 * x2 + z1 * w2 + w1 * z2
            Me.w = -x1 * x2 - y1 * y2 - z1 * z2 + w1 * w2
        End Sub
        Public Sub Power(n As Integer)
            Dim a1 = Me.x
            Dim a2 = Me.y
            Dim a3 = Me.z
            Dim a4 = Me.w



            For i As Integer = 1 To (n - 1)
                Me.Multiplication(a1, a2, a3, a4)
            Next


        End Sub
        Public Sub Power(pow As Double)
            Dim a1 = Me.x
            Dim a2 = Me.y
            Dim a3 = Me.z
            Dim a4 = Me.w

            Dim A As Double = length()
            Dim coef As Double = 1.0
            If A > 1 Then
                coef = 1.0
            ElseIf A <> 0 Then
                coef = 1 / A
            End If


            Me.x = Me.x * coef
            Me.y = Me.y * coef
            Me.z = Me.z * coef
            Me.w = Me.w * coef

            A = length()


            Dim theta As Double = Math.Acos(Me.w)
            Dim B As Double = Math.Sqrt(A * A - Me.w * Me.w)
            Dim phi_x As Double = Math.Acos(Me.x / B)
            Dim phi_y As Double = Math.Acos(Me.y / B)
            Dim phi_z As Double = Math.Acos(Me.z / B)

            Me.x = Math.Exp(pow * Math.Log(A / coef)) * Math.Sin(theta * pow) * Math.Cos(phi_x)
            Me.y = Math.Exp(pow * Math.Log(A / coef)) * Math.Sin(theta * pow) * Math.Cos(phi_y)
            Me.z = Math.Exp(pow * Math.Log(A / coef)) * Math.Sin(theta * pow) * Math.Cos(phi_z)
            Me.w = Math.Exp(pow * Math.Log(A / coef)) * Math.Cos(theta * pow)

        End Sub
#End Region

#Region "Function"
        Public Function length() As Double
            Return Math.Sqrt(x * x + y * y + z * z + w * w)
        End Function

        Public Function print() As String
            Return "[" + Math.Round(Me.length, 2).ToString + "] i*" +
            Math.Round(x, 2).ToString + " + j*" +
            Math.Round(y, 2).ToString + " + k*" +
            Math.Round(z, 2).ToString + " + " +
            Math.Round(w, 2).ToString
        End Function

#End Region


    End Class
End Namespace