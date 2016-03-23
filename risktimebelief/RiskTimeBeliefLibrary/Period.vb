<Serializable()> Public Class Period

    Public PeriodNumber As Integer
    Public ID As String 'subject ID
    Public qID As String 'question ID
    Public Type As Integer
    Public IndexOffset As Integer
    Public RiskParas As New ArrayList
    Public DiscountingParas As New ArrayList
    Public BeliefParas As BeliefParameters
    Public AtemporalMPLParas As New ArrayList
    Public Decision As New ArrayList
    Public isDecisionMade As Boolean = False

    Const RISK As Integer = 1
    Const DISCOUNTING As Integer = 2
    Const BELIEF As Integer = 3
    Const QUESTIONNAIRE As Integer = 4
    Const ATEMPORALMPL As Integer = 5



    Public Overrides Function ToString() As String
        Dim i As Integer
        Dim s As String = ""
        For i = 0 To Decision.Count - 1
            Dim dp As DiscountingParameters
            If DiscountingParas.Count = Decision.Count Then
                dp = DiscountingParas.Item(i)
            Else
                dp = DiscountingParas.Item(0)
            End If



            Dim mplP As AtemporalMPLparameters
            If AtemporalMPLParas.Count = Decision.Count Then
                mplP = AtemporalMPLParas.Item(i)
            Else
                mplP = AtemporalMPLParas.Item(0)
            End If



            Dim rp As RiskParameters
            If RiskParas.Count = Decision.Count Then
                rp = RiskParas.Item(i)
            Else
                rp = RiskParas.Item(0)
            End If

            If i > 0 Then s = s & vbCrLf
            s = s & ID & ","
            s = s & PeriodNumber.ToString & ","
            s = s & Type.ToString & ","
            Select Case Type
                Case RISK
                    s = s & rp.ID & ","
                Case DISCOUNTING
                    s = s & dp.ID & ","
                Case BELIEF
                    s = s & BeliefParas.ID & ","
                Case QUESTIONNAIRE
                    s = s & "q1" & ","
                Case ATEMPORALMPL
                    s = s & mplP.ID & ","
            End Select

            's = s & ID & ","
            s = s & isDecisionMade.ToString & ","
            s = s & Decision.Item(i).ToString & ","
            s = s & rp.La1.ToString & "," & CStr(rp.Lp1 / 100) & ","
            s = s & rp.La2.ToString & "," & CStr(rp.Lp2 / 100) & ","
            s = s & rp.La3.ToString & "," & CStr(rp.Lp3 / 100) & ","
            s = s & rp.La4.ToString & "," & CStr(rp.Lp4 / 100) & ","
            s = s & rp.Ra1.ToString & "," & CStr(rp.Rp1 / 100) & ","
            s = s & rp.Ra2.ToString & "," & CStr(rp.Rp2 / 100) & ","
            s = s & rp.Ra3.ToString & "," & CStr(rp.Rp3 / 100) & ","
            s = s & rp.Ra4.ToString & "," & CStr(rp.Rp4 / 100) & ","
            s = s & rp.NumEvents.ToString & ","
            s = s & rp.RollPrefix.ToString & ","
            s = s & rp.isReverseOrder.ToString & ","
            s = s & dp.Lamount.ToString & ","
            s = s & dp.Ldays.ToString & ","
            s = s & dp.Ramount.ToString & ","
            s = s & dp.Rdays.ToString & ","

            s = s & (i + 1).ToString & ","
            s = s & """" & BeliefParas.Text & """" & ","

            s = s & """" & mplP.LeftText.ToString & """" & ","
            s = s & """" & mplP.RightText.ToString & """" & ","
            s = s & mplP.NumberOfRounds.ToString
        Next

        Return s

    End Function


    Public Function GetHeaders() As String
        Dim s As String = ""
        s = s & "ID,"
        s = s & "Period,"
        s = s & "Type,"
        s = s & "qID,"
        s = s & "IsDecisionMade,"
        s = s & "Decision,"
        s = s & "R.La1,R.Lp1,"
        s = s & "R.La2,R.Lp2,"
        s = s & "R.La3,R.Lp3,"
        s = s & "R.La4,R.Lp4,"
        s = s & "R.Ra1,R.Rp1,"
        s = s & "R.Ra2,R.Rp2,"
        s = s & "R.Ra3,R.Rp3,"
        s = s & "R.Ra4,R.Rp4,"
        s = s & "R.NumEvents,"
        s = s & "R.RollPrefix,"
        s = s & "R.isReverseOrder,"
        s = s & "D.Lamount,"
        s = s & "D.Ldays,"
        s = s & "D.Ramount,"
        s = s & "D.Rdays,"
        s = s & "B.Bin,"
        s = s & "B.Question,"
        s = s & "MPL.LeftText,"
        s = s & "MPL.RightText,"
        s = s & "MPL.NumberOfDraws"
        Return s

    End Function



    Public Sub New()

    End Sub

    'Public Shared Function getRandomParameterPeriod(ByVal count As Integer) As Period()
    '    Dim Periods(count - 1) As Period
    '    Dim paras As RiskParameters() = RiskParameters.getRandomParameter(count)

    '    For c As Integer = 0 To count - 1

    '        Periods(c) = New Period()
    '        Periods(c).Para = paras(c)
    '        Periods(c).PeriodNumber = c + 1
    '    Next

    '    Return Periods
    'End Function
End Class
