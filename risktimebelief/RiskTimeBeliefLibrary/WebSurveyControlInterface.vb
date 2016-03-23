Public Interface WebSurveyControlInterface
    'Inherits UserControl
    Sub Initialize(ByVal url As String)
    Event Finished(ByVal sender As WebSurveyControlInterface, ByVal finished As Boolean)
    Sub SetFont(ByVal f As Font)
    Sub SetVisible(ByVal b As Boolean)
    Sub SetSurveyOverURLKeyword(ByVal k As String)
End Interface
