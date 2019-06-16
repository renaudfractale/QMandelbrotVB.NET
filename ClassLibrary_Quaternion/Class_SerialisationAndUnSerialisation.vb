Imports System.IO

Public Class Class_SerialisationAndUnSerialisation
    Public Shared Sub Serialisation(Of T)(Objet As T, pathFile As String)
        Using FileJson As New StreamWriter(pathFile)
            FileJson.Write(Newtonsoft.Json.JsonConvert.SerializeObject(Objet))
        End Using
    End Sub


    Public Shared Function UnSerialisation(Of T)(pathFile As String) As T
        Dim Datas As T = Nothing
        Using FileJson As New StreamReader(pathFile)
            Datas = Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)(FileJson.ReadToEnd())
        End Using
        Return Datas
    End Function
End Class
