Public Class Class_Projects
    Inherits Dictionary(Of Integer, Class_Project)


    Public Overloads Sub Add()
        Dim Project As New Class_Project
        Project.SetID(MyBase.Count)
        MyBase.Add(MyBase.Count, Project)
    End Sub

    Public Overloads Sub Add(Project As Class_Project)
        Project.SetID(MyBase.Count)
        MyBase.Add(MyBase.Count, Project)
    End Sub
End Class
