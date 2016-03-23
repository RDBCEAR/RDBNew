Public Interface ciRisk_2simul

    'Inherits UserControl
    Sub Initialize(ByVal P1 As RiskParameters, ByVal P2 As RiskParameters)
    Event DecisionMade(ByVal sender As ciRisk_2simul, ByVal Decision As ArrayList)
    Function GetDecision() As ArrayList
    Function ValidateDecision() As Boolean
    Function IsBlank() As Boolean
    Sub SetFont(ByVal f As Font)
    Sub SetVisible(ByVal b As Boolean)
    Sub CancelChoices()

    Sub DestroyPictures()
    Sub CreatePictures(ByVal Diameter As Single)
    Sub DisplayLotteries()
    Sub SetDecision(ByVal dTop As Single, ByVal dBottom As Single)

    Sub SetColors(ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c4 As Color)

    'Sub SetSoonerColor(ByVal c As Color)
    'Sub SetLaterColor(ByVal c As Color)
    'Sub OpenDecisionType(ByVal t As Integer)


End Interface
