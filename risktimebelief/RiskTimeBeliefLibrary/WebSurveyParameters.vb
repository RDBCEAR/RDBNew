Public Class WebSurveyParameters

    Public URL As String
    Public AppendUserNameToURL As Boolean

    Public Sub New()

    End Sub

    Public Sub New(ByVal url As String, ByVal AppendUser As Boolean)
        Me.URL = url
        Me.AppendUserNameToURL = AppendUser
    End Sub

End Class
