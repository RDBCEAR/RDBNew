
Public Interface RiskControlInterface
    'Inherits UserControl
    Sub Initialize(ByVal P As RiskParameters)
    Event DecisionMade(ByVal sender As RiskControlInterface, ByVal Decision As Single)
    Function GetDecision() As Single
    Function ValidateDecision() As Boolean
    Function IsBlank() As Boolean
    Sub SetFont(ByVal f As Font)
    Sub SetVisible(ByVal b As Boolean)
    Sub CancelChoices()
    Sub SetShowDiceInfo(ByVal b As Boolean)

    Sub DestroyPictures()
    Sub CreatePictures(ByVal Diameter As Single)
    Sub DisplayLotteries()
    Sub SetDecision(ByVal d As Single)

    Sub HideConfirm()

    Sub SetColors(ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c4 As Color)

    Sub SetPrize(ByVal p As Integer)

    'Sub SetSoonerColor(ByVal c As Color)
    'Sub SetLaterColor(ByVal c As Color)
    'Sub OpenDecisionType(ByVal t As Integer)
End Interface

