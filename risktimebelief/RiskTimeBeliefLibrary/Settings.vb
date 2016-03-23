Imports System.Globalization

Public Class Settings
    Public RandomizeRiskPeriods As Boolean = True
    Public RandomizeBeliefPeriods As Boolean = True
    Public NumRiskPeriods As Integer
    Public OrderRiskPeriods As Integer
    Public NumDiscountingPeriods As Integer
    Public OrderDiscountingPeriods As Integer
    Public NumBeliefPeriods As Integer
    Public OrderBeliefPeriods As Integer
    Public NumAtemporalMPLPeriods As Integer = 0
    Public OrderAtemporalMPLPeriods As Integer = 5
    Public NumQuestionnairePeriods As Integer
    Public OrderQuestionnairePeriods As Integer
    Public DisplayFontFamily As String
    Public DisplayFontSize As Single
    Public DisplayFontStyle As Integer
    Public AtemporalMPLLeftColor As String
    Public AtemporalMPLRightColor As String

    Public DiscountingElicitation As Integer
    Public DiscountingRows As Integer = 4
    Public DiscountingChoiceItemWidth As Integer = 800
    Public DiscountingChoiceItemHeight As Integer = 85
    Public DiscountingChoiceListOffset As Integer = 337

    Public MPLChoiceItemWidth As Integer = 800
    Public MPLChoiceItemHeight As Integer = 75
    Public MPLChoiceListOffset As Integer = 50

    Public MPLRows As Integer = 5

    Public DiscountingShowToday As Boolean = False
    Public DiscountingSoonerColor As String
    Public DiscountingLaterColor As String
    Public DiscountingSoonerColorB As String
    Public DiscountingLaterColorB As String
    Public DiscountingSoonerColorC As String
    Public DiscountingLaterColorC As String
    Public DiscountingOpenDecisionSooner As Boolean
    Public DiscountingShowCalendar As Boolean
    Public RiskElicitation As Integer = 1 '1 is standard, 2 is 2simul
    Public RiskDiameter As Single
    Public RiskColor1 As String
    Public RiskColor2 As String
    Public RiskColor3 As String
    Public RiskColor4 As String
    Public RiskShowGraphs As Boolean
    Public RiskShowText As Boolean
    Public RiskShowDiceInfoDuringDecision As Boolean = False
    Public BeliefElicitation As Integer = 10 '10 is ten bins, 2 is two bins
    Public SurveyURL As String
    Public AppendUserNameToSurveyURL As Boolean
    Public SurveyOverURLKeyword As String
    Public RandomRiskOrder As Boolean = False 'randomly switches left/right positioning within a lottery pair
    Public RiskPrize As Integer = 1 '1 is cash, 2 is points
    Public TimePrize As Integer = 1 '1 is cash, 2 is points
    Public BeliefPrize As Integer = 1 '1 is cash, 2 is points
    Public CurrencyFormat As String = ""
    Public LowResolution As Boolean = False
    Public Shared MoneyDecimalPlaces As Integer = 2



    Public Shared Function FormatCurrency(ByVal x As Single) As String
        Dim result As String
        If MoneyDecimalPlaces = 0 Then
            'result = x.ToString("C0", CurrentCulture)
            result = x.ToString("C0")
        Else
            'result = x.ToString("C", CurrentCulture)
            result = x.ToString("C")
        End If
        Return result
    End Function


End Class
