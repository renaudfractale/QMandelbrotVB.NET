Imports System.IO
Imports ClassLibrary_Quaternion
Class MainWindow
    Private ListePath As Class_ListePath


    Property Project As Class_Project
    Property Projects As New Class_Projects
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Me.ListePath = New Class_ListePath

        If Not Directory.Exists(Class_ListePath.PathMyDocument) Then
            Directory.CreateDirectory(Class_ListePath.PathMyDocument)
        End If
        Class_ListePath.PathMyDocument = Class_ListePath.PathMyDocument
        TextBox_PathMain.Text = Class_ListePath.PathMyDocument
        TextBox_PathMain.IsReadOnly = True



        If File.Exists(Class_ListePath.PathMyProjects) Then
            Projects = Class_SerialisationAndUnSerialisation.UnSerialisation(Of Class_Projects)(Class_ListePath.PathMyProjects)
        Else
            Projects = New Class_Projects
            Projects.Add()
            Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Projects)(Projects, Class_ListePath.PathMyProjects)
        End If

        ComboBox_ListeProjectUpdate()

        Dim PathTemp = Path.GetTempFileName
        My.Resources.Logo.Save(PathTemp)

        Dim myBitmapImage = New BitmapImage()

        ' BitmapImage.UriSource must be in a BeginInit/EndInit block
        myBitmapImage.BeginInit()
        myBitmapImage.UriSource = New Uri(PathTemp)
        myBitmapImage.DecodePixelWidth = 200
        myBitmapImage.EndInit()

        Image_Logo.Width = 200
        Image_Logo.Source = myBitmapImage


        IsDisplayEdit(True)
    End Sub
    Private Sub OpenProject(Project As Class_Project)
        TextBox_NameProject.Text = String.Copy(Project.Name_Project)
        TextBlock_ID.Text = Project.ID_Project.ToString

        UCtrl_AxeFixe.TextBox_AxeFixeStart.Text = Project.AxeFixeValeurStart.ToString
        UCtrl_AxeFixe.TextBox_AxeFixeEnd.Text = Project.AxeFixeValeurEnd.ToString
        UCtrl_AxeFixe.ComboBox_NBPointAxeFixe.SelectedItem = Project.AxeFixeNbPoint.ToString
        If Project.AxeFixe = Quaternion.QAxe.W Then
            UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem = "W"
        ElseIf Project.AxeFixe = Quaternion.QAxe.X Then
            UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem = "X"
        ElseIf Project.AxeFixe = Quaternion.QAxe.Y Then
            UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem = "Y"
        ElseIf Project.AxeFixe = Quaternion.QAxe.Z Then
            UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem = "Z"
        End If
        UCtrl_Limite.ComboBox_TypeLimite.SelectedIndex = 0
        UCtrl_Limite.TextBox_valueLimiteManual.Text = Project.Limite.ToString

        UCtrl_Limite.ComboBox_TypeLimite.SelectedIndex = Project.LimiteType
        UCtrl_Limite.ComboBox_NbpointsLimite.SelectedItem = Project.NbPointLimite.ToString
        UCtrl_Limite.TextBox_valueRmax.Text = Project.Rmax.ToString
        UCtrl_Limite.TextBox_valuePower.Text = Project.Power.ToString

        ComboBox_ListeProject.IsEnabled = False
    End Sub

    Private Function SaveProject() As Class_Project
        Dim Project As New Class_Project
        Project.Name_Project = String.Copy(TextBox_NameProject.Text)
        Project.ID_Project = Me.Project.ID_Project

        Project.AxeFixeValeurStart = CDbl(UCtrl_AxeFixe.TextBox_AxeFixeStart.Text)
        Project.AxeFixeValeurEnd = CDbl(UCtrl_AxeFixe.TextBox_AxeFixeEnd.Text)
        Project.AxeFixeNbPoint = CInt(UCtrl_AxeFixe.ComboBox_NBPointAxeFixe.SelectedItem.ToString)



        If UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem.ToString = "W" Then
            Project.AxeFixe = Quaternion.QAxe.W
        ElseIf UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem.ToString = "X" Then
            Project.AxeFixe = Quaternion.QAxe.X
        ElseIf UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem.ToString = "Y" Then
            Project.AxeFixe = Quaternion.QAxe.Y
        ElseIf UCtrl_AxeFixe.ComboBox_AxeFixe.SelectedItem.ToString = "Z" Then
            Project.AxeFixe = Quaternion.QAxe.Z
        End If
        Project.LimiteType = CInt(UCtrl_Limite.ComboBox_TypeLimite.SelectedIndex.ToString)
        UCtrl_Limite.ComboBox_TypeLimite.SelectedIndex = 0
        Project.Limite = CDbl(UCtrl_Limite.TextBox_valueLimiteManual.Text)

        Project.NbPointLimite = CInt(UCtrl_Limite.ComboBox_NbpointsLimite.SelectedItem.ToString)
        Project.Rmax = CDbl(UCtrl_Limite.TextBox_valueRmax.Text)
        Project.Power = CDbl(UCtrl_Limite.TextBox_valuePower.Text)
        Return Project
    End Function
    Private Sub Button_Edit_Click(sender As Object, e As RoutedEventArgs)
        If ComboBox_ListeProject.SelectedItem IsNot Nothing Then
            Dim NoIndex As Integer = ComboBox_ListeProject.SelectedItem.ToString.Split("|"c)(0)
            OpenProject(Projects.Item(NoIndex))
            Project = Projects.Item(NoIndex)
            IsDisplayEdit(False)
        End If
    End Sub

    Private Sub Button_Del_Click(sender As Object, e As RoutedEventArgs)
        Project.IsVisible = False
    End Sub

    Private Sub Button_QuitteWithOutSave_Click(sender As Object, e As RoutedEventArgs)
        IsDisplayEdit(True)
        ComboBox_ListeProject.IsEnabled = True
    End Sub

    Private Sub Button_Duplique_Click(sender As Object, e As RoutedEventArgs)
        Dim ProjectSaved = SaveProject()
        Projects.Add(ProjectSaved)
        ComboBox_ListeProject.IsEnabled = True
        ComboBox_ListeProjectUpdate()
        ComboBox_ListeProject.SelectedIndex = Projects.Count - 1
        ComboBox_ListeProject.IsEnabled = False
        'ProjectSaved.GenerateControlsRooms()
        Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Projects)(Projects, Class_ListePath.PathMyProjects)
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As RoutedEventArgs)
        Dim ProjectSaved = SaveProject()
        If ProjectSaved.Key <> Project.Key Then
            If MessageBox.Show("Save Changement ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) = MessageBoxResult.Yes Then
                Projects.Item(ProjectSaved.ID_Project) = ProjectSaved
                ComboBox_ListeProject.IsEnabled = True
                IsDisplayEdit(True)
                ComboBox_ListeProjectUpdate()
                ' ProjectSaved.GenerateControlsRooms()
                Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Projects)(Projects, Class_ListePath.PathMyProjects)
            End If
        Else
            Projects.Item(ProjectSaved.ID_Project) = ProjectSaved
            ComboBox_ListeProject.IsEnabled = True
            IsDisplayEdit(True)
            ComboBox_ListeProjectUpdate()
            ' ProjectSaved.GenerateControlsRooms()
            Class_SerialisationAndUnSerialisation.Serialisation(Of Class_Projects)(Projects, Class_ListePath.PathMyProjects)
        End If
    End Sub

    Private Sub IsDisplayEdit(value As Boolean)
        If value Then
            Border_AxeFixe.Visibility = Visibility.Collapsed
            Border_Limite.Visibility = Visibility.Collapsed
            Border_Button.Visibility = Visibility.Collapsed
            Border_Tilte.Visibility = Visibility.Collapsed
            Border_Statut.Visibility = Visibility.Collapsed
            Button_Generate.Visibility = Visibility.Visible
        Else
            Border_AxeFixe.Visibility = Visibility.Visible
            Border_Limite.Visibility = Visibility.Visible
            Border_Button.Visibility = Visibility.Visible
            Border_Tilte.Visibility = Visibility.Visible
            Border_Statut.Visibility = Visibility.Collapsed
            Button_Generate.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub ComboBox_ListeProjectUpdate()

        ComboBox_ListeProject.Items.Clear()
        For Each KV In Projects
            ComboBox_ListeProject.Items.Add(KV.Key.ToString + "| " + KV.Value.Name_Project)
        Next
        ComboBox_ListeProject.SelectedIndex = 0
    End Sub

    Private Sub Button_Generate_Click(sender As Object, e As RoutedEventArgs)
        If ComboBox_ListeProject.SelectedItem IsNot Nothing Then
            Dim NoIndex As Integer = ComboBox_ListeProject.SelectedItem.ToString.Split("|"c)(0)
            Projects.Item(NoIndex).GenerateControlsRooms()
        End If
    End Sub
End Class
