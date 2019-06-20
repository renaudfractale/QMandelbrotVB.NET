Public Class UserControl_AxeFixe
    Property OldValueStart As String = "0,0"
    Property OldValueEnd As String = "0,0"

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        ComboBox_AxeFixe.Items.Clear()
        ComboBox_AxeFixe.Items.Add("W")
        ComboBox_AxeFixe.Items.Add("X")
        ComboBox_AxeFixe.Items.Add("Y")
        ComboBox_AxeFixe.Items.Add("Z")
        ComboBox_AxeFixe.SelectedIndex = 0


        ComboBox_NBPointAxeFixe.Items.Clear()
        ComboBox_NBPointAxeFixe.Items.Add(2)
        ComboBox_NBPointAxeFixe.Items.Add(4)
        ComboBox_NBPointAxeFixe.Items.Add(8)
        ComboBox_NBPointAxeFixe.Items.Add(16)
        ComboBox_NBPointAxeFixe.Items.Add(32)
        ComboBox_NBPointAxeFixe.Items.Add(64)
        ComboBox_NBPointAxeFixe.Items.Add(128)
        ComboBox_NBPointAxeFixe.Items.Add(256)
        ComboBox_NBPointAxeFixe.Items.Add(512)
        ComboBox_NBPointAxeFixe.Items.Add(1000)
        ComboBox_NBPointAxeFixe.SelectedIndex = 9
        ComputeStep()
    End Sub

    Private Sub TextBox_AxeFixeStart_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)
        OldValueStart = TextBox_AxeFixeStart.Text
    End Sub

    Private Sub TextBox_AxeFixeStart_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim VStart = CDbl(TextBox_AxeFixeStart.Text)
            Dim VEnd = CDbl(TextBox_AxeFixeEnd.Text)
            If VStart > VEnd Then
                TextBox_AxeFixeStart.Text = OldValueStart
            End If
        Catch ex As Exception
            TextBox_AxeFixeStart.Text = OldValueStart
        End Try
        ComputeStep()
    End Sub

    Private Sub TextBox_AxeFixeEnd_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)
        OldValueEnd = TextBox_AxeFixeEnd.Text
    End Sub

    Private Sub TextBox_AxeFixeEnd_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim VEnd = CDbl(TextBox_AxeFixeEnd.Text)
            Dim VStart = CDbl(TextBox_AxeFixeStart.Text)
            If VStart > VEnd Then
                TextBox_AxeFixeEnd.Text = OldValueEnd
            End If
        Catch ex As Exception
            TextBox_AxeFixeEnd.Text = OldValueEnd
        End Try
        ComputeStep()
    End Sub

    Private Sub ComputeStep()


        Try

            If ComboBox_NBPointAxeFixe.SelectedItem IsNot Nothing Then

                Dim NbPoint = CDbl(ComboBox_NBPointAxeFixe.SelectedItem.ToString)
                Dim VStart = CDbl(TextBox_AxeFixeStart.Text)
                Dim VEnd = CDbl(TextBox_AxeFixeEnd.Text)
                Dim Espace As Double = VEnd - VStart

                Dim StepV = Espace / NbPoint
                TextBlock_StepAxe.Text = StepV.ToString
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox_NBPointAxeFixe_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ComputeStep()
    End Sub
End Class
