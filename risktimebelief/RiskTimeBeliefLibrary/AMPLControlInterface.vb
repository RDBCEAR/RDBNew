Public Interface AMPLControlInterface
    Sub Initialize(ByVal p As AtemporalMPLparameters)
    Event DecisionMade(ByVal sender As AMPLControlInterface, ByVal Decision As Single)
    Function GetDecision() As Single
    Function ValidateDecision() As Boolean
    Function IsBlank() As Boolean
    Sub SetFont(ByVal f As Font)
    Sub SetVisible(ByVal b As Boolean)
    Sub CancelChoices()

    Sub PerformChoice(d As Single)


    Sub SetSoonerColor(ByVal c As Color)
    Sub SetLaterColor(ByVal c As Color)

    Sub OpenDecisionType(ByVal t As Integer)

    Sub SetDecision(ByVal d As Single)

    Sub SetIndex(ByVal i As Integer)
    Function GetIndex() As Integer

    Sub SetBackgroundColor(ByVal c As Color)

End Interface

