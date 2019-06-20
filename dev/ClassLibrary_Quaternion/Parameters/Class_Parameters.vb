Imports ClassLibrary_Quaternion.Parameters
Public Class Class_Parameters
    Property Power As Double = 2.0
    Property Rmax As Double = 4.0
    Property AxeFixe As New Class_AxeFixe
    Property Limite As New Class_Limite


    Public Sub New()

    End Sub

    Public Sub New(Rmax As Double, Power As Double, AxeFixe As Quaternion.QAxe, AxeFixeValeur As Double,
                   AxeFixeNbPoint As Integer, NbPointLimite As Integer,
                   Limite As Double, LimiteType As Integer)
        Me.Power = Power
        Me.Rmax = Rmax
        Me.AxeFixe.Axe = AxeFixe
        Me.AxeFixe.Value = AxeFixeValeur
        Me.AxeFixe.NbPoint = AxeFixeNbPoint
        Me.Limite.Value = Limite
        Me.Limite.NbPoint = NbPointLimite
        Me.Limite.Index = LimiteType

    End Sub


    Public Sub New(Parameters As Class_Parameters)
        Me.Power = Parameters.Power
        Me.Rmax = Parameters.Rmax
        Me.AxeFixe.Axe = Parameters.AxeFixe.Axe
        Me.AxeFixe.Value = Parameters.AxeFixe.Value
        Me.AxeFixe.NbPoint = Parameters.AxeFixe.NbPoint
        Me.Limite.Value = Parameters.Limite.Value
        Me.Limite.NbPoint = Parameters.Limite.NbPoint
        Me.Limite.Index = Parameters.Limite.Index
    End Sub


    Public Function Key() As String
        'A finir faire la liste des Keys
        Return Newtonsoft.Json.JsonConvert.SerializeObject(Me)
    End Function
End Class
