Public Class UserControl_Limite
    Property OldvalueLimite As String = "4"
    Property OldvalueRmax As String = "4"
    Property OldvaluePwer As String = "2"

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().


        ComboBox_TypeLimite.Items.Clear()
        ComboBox_TypeLimite.Items.Add("Manual")
        ComboBox_TypeLimite.Items.Add("Auto")
        ComboBox_TypeLimite.SelectedIndex = 1

        ComboBox_NbpointsLimite.Items.Clear()
        ComboBox_NbpointsLimite.Items.Add(2)
        ComboBox_NbpointsLimite.Items.Add(4)
        ComboBox_NbpointsLimite.Items.Add(8)
        ComboBox_NbpointsLimite.Items.Add(16)
        ComboBox_NbpointsLimite.Items.Add(32)
        ComboBox_NbpointsLimite.Items.Add(64)
        ComboBox_NbpointsLimite.Items.Add(128)
        ComboBox_NbpointsLimite.Items.Add(256)
        ComboBox_NbpointsLimite.Items.Add(512)
        ComboBox_NbpointsLimite.Items.Add(1000)
        ComboBox_NbpointsLimite.SelectedIndex = 9
    End Sub




    Private Sub ComboBox_TypeLimite_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If ComboBox_TypeLimite.SelectedIndex = 1 Then 'Auto
            TextBox_valueLimiteManual.IsEnabled = False
            ComboBox_NbpointsLimite_SelectionChanged(Nothing, Nothing)
        Else
            TextBox_valueLimiteManual.IsEnabled = True
            ComboBox_NbpointsLimite_SelectionChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub ComboBox_NbpointsLimite_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Try
            Dim NbpointsLimite As Double = CDbl(ComboBox_NbpointsLimite.SelectedItem.ToString)
            If ComboBox_TypeLimite.SelectedIndex = 1 Then 'Auto
                Dim stepMin As Double = (CDbl(TextBox_valueRmax.Text) * 2) / NbpointsLimite
                Dim stepMax As Double = 0.00001
                TextBlock_Step.Text = stepMin.ToString + "/" + stepMax.ToString

            Else
                Dim stepvalue As Double = (CDbl(TextBox_valueLimiteManual.Text) * 2) / NbpointsLimite
                TextBlock_Step.Text = stepvalue.ToString
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_valueLimiteManual_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)
        OldvalueLimite = TextBox_valueLimiteManual.Text
    End Sub

    Private Sub TextBox_valueLimiteManual_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim DD = CDbl(TextBox_valueLimiteManual.Text)
        Catch ex As Exception
            TextBox_valueLimiteManual.Text = OldvalueLimite
        End Try
        ComboBox_NbpointsLimite_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub TextBox_valueRmax_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim DD = CDbl(TextBox_valueRmax.Text)
        Catch ex As Exception
            TextBox_valueRmax.Text = OldvalueRmax
        End Try
        ComboBox_NbpointsLimite_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub TextBox_valueRmax_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)
        OldvalueRmax = TextBox_valueRmax.Text
    End Sub

    Private Sub TextBox_valuePower_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)
        OldvaluePwer = TextBox_valuePower.Text
    End Sub

    Private Sub TextBox_valuePower_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim DD = CDbl(TextBox_valuePower.Text)
        Catch ex As Exception
            TextBox_valuePower.Text = OldvaluePwer
        End Try
    End Sub
End Class
