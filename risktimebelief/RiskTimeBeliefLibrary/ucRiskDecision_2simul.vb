Public Class ucRiskDecision_2simul
    Implements ciRisk_2simul




    Dim WithEvents ucTopPair As UserControl
    Dim WithEvents ciTopPair As RiskControlInterface
    Dim WithEvents ucBottomPair As UserControl
    Dim WithEvents ciBottomPair As RiskControlInterface

    Dim PairHeight As Integer = 380
    Dim PairWidth As Integer = 800
    'Dim Center As Single

    Dim DisplayFont As Font
    'Dim Color1
    'Dim Color2
    'Dim Color3
    'Dim Color4

    Dim TopDecision As Single
    Dim BottomDecision As Single

    Dim Ptop As RiskParameters
    Dim Pbottom As RiskParameters

    Public Event DecisionMade(ByVal sender As ciRisk_2simul, ByVal Decision As System.Collections.ArrayList) Implements ciRisk_2simul.DecisionMade

    Public Sub CancelChoices() Implements ciRisk_2simul.CancelChoices

    End Sub

    Public Sub CreatePictures(ByVal Diameter As Single) Implements ciRisk_2simul.CreatePictures
        CType(ucTopPair, RiskControlInterface).CreatePictures(Diameter)
        CType(ucBottomPair, RiskControlInterface).CreatePictures(Diameter)

    End Sub


    Public Sub DestroyPictures() Implements ciRisk_2simul.DestroyPictures
        CType(ucTopPair, RiskControlInterface).DestroyPictures()
        CType(ucBottomPair, RiskControlInterface).DestroyPictures()

    End Sub


    Public Sub Initialize(ByVal P1 As RiskParameters, ByVal P2 As RiskParameters) Implements ciRisk_2simul.Initialize
        'Center = c


        'InterfaceList(i) = List(i)
        'AddHandler InterfaceList(i).DecisionMade, AddressOf CheckDiscountingChoices


        ucTopPair = New ucRiskDecision()
        ciTopPair = ucTopPair      'what is purpose of this line?
        AddHandler ciTopPair.DecisionMade, AddressOf CheckChoices
        With ucTopPair
            .Visible = True
            .Height = PairHeight
            .Width = PairWidth
            .Location = New Point(Me.Width / 2 - .Width / 2, 5)
            '.Location = New Point(0, 0)
            .BorderStyle = BorderStyle.FixedSingle
            Me.Controls.Add(ucTopPair)
        End With
        CType(ucTopPair, RiskControlInterface).Initialize(P1)
        CType(ucTopPair, RiskControlInterface).HideConfirm()

        ucBottomPair = New ucRiskDecision()
        ciBottomPair = ucBottomPair       'what is purpose of this line?
        AddHandler ciBottomPair.DecisionMade, AddressOf CheckChoices
        With ucBottomPair
            .Visible = True
            .Height = PairHeight
            .Width = PairWidth
            .Location = New Point(Me.Width / 2 - .Width / 2, ucTopPair.Location.Y + ucTopPair.Height - 1)
            '.Location = New Point(0, 0)
            .BorderStyle = BorderStyle.FixedSingle
            Me.Controls.Add(ucBottomPair)
        End With
        CType(ucBottomPair, RiskControlInterface).Initialize(P2)
        CType(ucBottomPair, RiskControlInterface).HideConfirm()
        '.SetFont(DisplayFont)
        '.SetColors(ColorTranslator.FromHtml(Settings.RiskColor1), ColorTranslator.FromHtml(Settings.RiskColor2), ColorTranslator.FromHtml(Settings.RiskColor3), ColorTranslator.FromHtml(Settings.RiskColor4))

        With lblConfirm
            .Text = "You must make your choices above before you are able to confirm."
            '.Location = New Point((Me.Width - .Width) / 2, 2 * PairHeight + 20)
            .Visible = True
        End With
        With btnConfirm
            '.Location = New Point(Me.Width / 2 - 100, lblConfirm.Location.Y + lblConfirm.Height + 10)
            .Enabled = False
        End With
        With btnCancel
            '.Location = New Point(Me.Width / 2 + 100, btnConfirm.Location.Y)
            .Enabled = False
        End With

    End Sub

    'Public Sub DisplayLotteries()
    '    With CType(ucTopPair, RiskControlInterface)
    '        If ShowGraph = False Then 'is this ever used?
    '            .DestroyPictures()
    '        Else
    '            .CreatePictures(Diameter)
    '            .DisplayLotteries()
    '        End If
    '    End With


    '    If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
    '        CType(ucTopPair, RiskControlInterface).SetDecision(p.Decision.Item(0))
    '    End If
    '    ucTopPair.Visible = True
    'End Sub



    Public Function IsBlank() As Boolean Implements ciRisk_2simul.IsBlank

    End Function

    Public Sub SetColors(ByVal c1 As System.Drawing.Color, ByVal c2 As System.Drawing.Color, ByVal c3 As System.Drawing.Color, ByVal c4 As System.Drawing.Color) Implements ciRisk_2simul.SetColors
        CType(ucTopPair, RiskControlInterface).SetColors(c1, c2, c3, c4)
        CType(ucBottomPair, RiskControlInterface).SetColors(c1, c2, c3, c4)

        'Color1 = c1
        'Color2 = c2
        'Color3 = c3
        'Color4 = c4
    End Sub



    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements ciRisk_2simul.SetFont
        CType(ucTopPair, RiskControlInterface).SetFont(f)
        CType(ucBottomPair, RiskControlInterface).SetFont(f)
        lblConfirm.Font = f
        btnConfirm.Font = f
        btnCancel.Font = f

        lblConfirm.Location = New Point((Me.Width - lblConfirm.Width) / 2, 2 * PairHeight + 20)
        btnConfirm.Location = New Point(Me.Width / 2 - btnConfirm.Width - 10, lblConfirm.Location.Y + lblConfirm.Height + 10)
        btnCancel.Location = New Point(Me.Width / 2 + 10, btnConfirm.Location.Y)

    End Sub




    Public Sub SetVisible(ByVal b As Boolean) Implements ciRisk_2simul.SetVisible

    End Sub

    Public Function ValidateDecision() As Boolean Implements ciRisk_2simul.ValidateDecision

    End Function





    Public Sub DisplayLotteries() Implements ciRisk_2simul.DisplayLotteries
        CType(ucTopPair, RiskControlInterface).DisplayLotteries()
        CType(ucBottomPair, RiskControlInterface).DisplayLotteries()
    End Sub

    Public Sub SetDecision(ByVal dTop As Single, ByVal dBottom As Single) Implements ciRisk_2simul.SetDecision
        CType(ucTopPair, RiskControlInterface).SetDecision(dTop)
        CType(ucBottomPair, RiskControlInterface).SetDecision(dBottom)
        lblConfirm.Visible = False
        btnConfirm.Visible = False
        btnCancel.Visible = False
    End Sub



    Public Sub CheckChoices()

        'this is used for simultaneous decisions, and mimics the checkdiscountingchoices routine in the main form

        'on each choice selection, this routine is triggered by the madedecision event and checks to see if all selections are made, and enables confirm button if true
        'Note this sub needs to be public so the buttons in the child user controls can call it

        TopDecision = CType(ucTopPair, RiskControlInterface).GetDecision
        BottomDecision = CType(ucBottomPair, RiskControlInterface).GetDecision


        Dim AllValid As Boolean = True
        Dim AllBlank As Boolean = True

        If ciTopPair.ValidateDecision = False Then
            AllValid = False
        Else
            AllBlank = False
        End If

        If ciBottomPair.ValidateDecision = False Then
            AllValid = False
        Else
            AllBlank = False
        End If




        'For Each L As DiscountingControlInterface In List
        '    If L.ValidateDecision = False Then
        '        AllValid = False
        '    End If
        '    If L.IsBlank = False Then
        '        AllBlank = False
        '    End If
        'Next

        If AllValid = True Then
            lblConfirm.Visible = False
            btnConfirm.Enabled = True
        Else
            lblConfirm.Visible = True
            btnConfirm.Enabled = False
        End If

        If AllBlank = True Then
            btnCancel.Enabled = False
        Else
            btnCancel.Enabled = True
        End If
    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CType(ucTopPair, RiskControlInterface).CancelChoices()
        CType(ucBottomPair, RiskControlInterface).CancelChoices()
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim Decisions As ArrayList = New ArrayList

        Decisions.Add(TopDecision)
        Decisions.Add(BottomDecision)

        RaiseEvent DecisionMade(Me, Decisions)
    End Sub

    Public Function GetDecision() As System.Collections.ArrayList Implements ciRisk_2simul.GetDecision
        Dim Decisions As ArrayList = New ArrayList
        Decisions.Add(TopDecision)
        Decisions.Add(BottomDecision)
        Return Decisions
    End Function
End Class
