Public Class ucWebSurvey
    Implements WebSurveyControlInterface

    Dim URL As String
    Dim SurveyOverKeyword

    Public Event Finished(ByVal sender As WebSurveyControlInterface, ByVal finished As Boolean) Implements WebSurveyControlInterface.Finished

    Public Sub Initialize(ByVal url As String) Implements WebSurveyControlInterface.Initialize
        Me.URL = url
        WebBrowser1.Navigate(url)
    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements WebSurveyControlInterface.SetFont

    End Sub

    Public Sub SetVisible(ByVal b As Boolean) Implements WebSurveyControlInterface.SetVisible

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        If WebBrowser1.Url.ToString.Contains(SurveyOverKeyword) Then
            WebBrowser1.Visible = False
            RaiseEvent Finished(Me, True)
        End If
    End Sub

    Public Sub SetSurveyOverURLKeyword(ByVal k As String) Implements WebSurveyControlInterface.SetSurveyOverURLKeyword
        SurveyOverKeyword = k
    End Sub
End Class
