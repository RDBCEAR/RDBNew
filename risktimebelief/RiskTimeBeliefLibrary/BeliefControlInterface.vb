Public Interface BeliefControlInterface

    'Event DecisionMade(ByVal sender As BeliefControlInterface)

    'Inherits UserControl
    'Sub Initialize(ByVal P As RiskParameters)
    Sub Initialize(ByVal p As BeliefParameters)


    Event DecisionMade(ByVal sender As BeliefControlInterface, ByVal Decisions() As Single)

    Function GetDecision() As Single()
    Sub SetDecision(ByVal d As Object())
    Function ValidateDecision() As Boolean
    Function IsBlank() As Boolean
    Sub SetFont(ByVal f As Font)
    Sub SetVisible(ByVal b As Boolean)
    Sub CancelChoices()

    Sub SetPrize(ByVal p As Integer)

    Sub SetColors(ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c4 As Color)

    Sub SetPreset(ByVal p As BeliefPreset)

    Sub SetLowRes()

End Interface
