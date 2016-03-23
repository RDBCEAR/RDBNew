Public Interface DiscountingControlInterface
    'Inherits UserControl
    Sub Initialize(ByVal P As DiscountingParameters)
    Event DecisionMade(ByVal sender As DiscountingControlInterface, ByVal Decision As Single)
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
End Interface
