Public Class ucRiskDecisionBar
    Implements RiskControlInterface


    Dim Decision As Single = -999
    Dim DisplayFont As Font
    Dim Color1 As Color = Color.Blue
    Dim Color2 As Color = Color.Blue
    Dim Color3 As Color = Color.Red
    Dim Color4 As Color = Color.Orange
    Dim list As ArrayList = New ArrayList()
    Dim P As RiskParameters
    'Dim LeftTitle As String
    'Dim RightTitle As String

    Dim HideConfirmButtons As Boolean = False
    Public Event DecisionMade(ByVal sender As RiskControlInterface, ByVal Decision As Single) Implements RiskControlInterface.DecisionMade

    Public Sub CancelChoices() Implements RiskControlInterface.CancelChoices
        btnCancel_Click(Nothing, Nothing)
    End Sub

    Public Sub CreatePictures(ByVal Diameter As Single) Implements RiskControlInterface.CreatePictures

    End Sub


    Public Sub DestroyPictures() Implements RiskControlInterface.DestroyPictures

    End Sub

    Public Sub DisplayLotteries() Implements RiskControlInterface.DisplayLotteries
        HeaderTableLayoutPanel.ColumnStyles.Clear()
        Me.HeaderTableLayoutPanel.Controls.Clear()
        Header2TableLayoutPanel.ColumnStyles.Clear()
        Me.Header2TableLayoutPanel.Controls.Clear()
        Dim l As Label
        Dim c As Integer = P.NumEvents
        HeaderTableLayoutPanel.ColumnCount = c
        Header2TableLayoutPanel.ColumnCount = c
        For i = 0 To c - 1

            Me.HeaderTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1))
            l = New Label()
            l.Text = P.RollPrefix & (i + 1).ToString
            l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            l.TextAlign = ContentAlignment.MiddleCenter
            l.Margin = New System.Windows.Forms.Padding(0)
            l.Dock = System.Windows.Forms.DockStyle.Fill
            Me.HeaderTableLayoutPanel.Controls.Add(l, i, 0)

        Next
        For i = 0 To c - 1

            Me.Header2TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1))
            l = New Label()
            l.Text = P.RollPrefix & (i + 1).ToString

            l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            l.TextAlign = ContentAlignment.MiddleCenter
            l.Margin = New System.Windows.Forms.Padding(0)
            l.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Header2TableLayoutPanel.Controls.Add(l, i, 0)

        Next
        OptionATableLayoutPanel.ColumnStyles.Item(0).Width = P.Lp1
        OptionATableLayoutPanel.ColumnStyles.Item(1).Width = P.Lp2
        OptionATableLayoutPanel.ColumnStyles.Item(2).Width = P.Lp3
        OptionATableLayoutPanel.ColumnStyles.Item(3).Width = P.Lp4
        OptionBTableLayoutPanel.ColumnStyles.Item(0).Width = P.Rp1
        OptionBTableLayoutPanel.ColumnStyles.Item(1).Width = P.Rp2
        OptionBTableLayoutPanel.ColumnStyles.Item(2).Width = P.Rp3
        OptionBTableLayoutPanel.ColumnStyles.Item(3).Width = P.Rp4
        Me.optALabel1.Text = Settings.FormatCurrency(P.La1)
        Me.optALabel2.Text = Settings.FormatCurrency(P.La2)
        Me.optALabel3.Text = Settings.FormatCurrency(P.La3)
        Me.optALabel4.Text = Settings.FormatCurrency(P.La4)
        Me.optBLabel1.Text = Settings.FormatCurrency(P.Ra1)
        Me.optBLabel2.Text = Settings.FormatCurrency(P.Ra2)
        Me.optBLabel3.Text = Settings.FormatCurrency(P.Ra3)
        Me.optBLabel4.Text = Settings.FormatCurrency(P.Ra4)
        Me.btnOptionA.Text = P.LeftTitle
        Me.btnOptionB.Text = P.RightTitle
        'Me.lblTitle.Text = P.Title
        Me.Refresh()
    End Sub

    Public Function GetDecision() As Single Implements RiskControlInterface.GetDecision
        Return Decision
    End Function

    Public Sub HideConfirm() Implements RiskControlInterface.HideConfirm
        HideConfirmButtons = True
        Me.TableLayoutPanel1.RowStyles.Item(4).Height = 0

    End Sub

    Public Sub Initialize(ByVal P As RiskParameters) Implements RiskControlInterface.Initialize
        Me.P = P
        btnCancel.Visible = False
        btnConfirm.Visible = False

    End Sub

    Public Function IsBlank() As Boolean Implements RiskControlInterface.IsBlank

    End Function

    Public Sub SetColors(ByVal c1 As System.Drawing.Color, ByVal c2 As System.Drawing.Color, ByVal c3 As System.Drawing.Color, ByVal c4 As System.Drawing.Color) Implements RiskControlInterface.SetColors
        Color1 = c1
        Color2 = c2
        Color3 = c3
        Color4 = c4
        optALabel1.BackColor = Color1
        optALabel2.BackColor = Color2
        optALabel3.BackColor = Color3
        optALabel4.BackColor = Color4
        optBLabel1.BackColor = Color1
        optBLabel2.BackColor = Color2
        optBLabel3.BackColor = Color3
        optBLabel4.BackColor = Color4
    End Sub

    Public Sub SetDecision(ByVal d As Single) Implements RiskControlInterface.SetDecision
        Decision = d
        'btnOptionA.Enabled = False
        'btnOptionB.Enabled = False
        If Decision = 0 Then
            Me.btnOptionA.BackColor = Color.LimeGreen

            Me.btnOptionB.UseVisualStyleBackColor = True

        ElseIf Decision = 1 Then
            Me.btnOptionA.UseVisualStyleBackColor = True
            Me.btnOptionB.BackColor = Color.LimeGreen

        Else
            Me.btnOptionA.BackColor = SystemColors.Control
            Me.btnOptionB.BackColor = SystemColors.Control
            Me.btnOptionA.UseVisualStyleBackColor = True
            Me.btnOptionB.UseVisualStyleBackColor = True

        End If

    End Sub
    Private Sub showconfirm(ByVal value As Boolean)
        'btnOptionA.Enabled = Not value
        'btnOptionB.Enabled = Not value
        Me.btnConfirm.Enabled = value
        Me.btnCancel.Enabled = value
        Me.btnConfirm.Visible = value
        Me.btnCancel.Visible = value
    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements RiskControlInterface.SetFont
        DisplayFont = f 'because i need to assign font to new objects in later routines, so persisting...
        NewFont(Me, f)
    End Sub
    Private Sub NewFont(ByRef c As Control, ByRef f As Font)
        'iterate over all controls in the top container
        Dim ctrl As Control
        For Each ctrl In c.Controls
            ctrl.Font = f
            If (ctrl.Controls.Count > 0) Then
                NewFont(ctrl, f)
            End If
        Next



    End Sub
    Public Sub SetVisible(ByVal b As Boolean) Implements RiskControlInterface.SetVisible

    End Sub

    Public Function ValidateDecision() As Boolean Implements RiskControlInterface.ValidateDecision
        If Decision = -999 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        RaiseEvent DecisionMade(Me, Decision) '0 for Top, 1 for Bottom
    End Sub

    Private Sub btnOptionA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionA.Click
        SetDecision(0)
        If (HideConfirmButtons) Then
            RaiseEvent DecisionMade(Me, Decision) '0 for Top, 1 for Bottom
        Else
            showconfirm(True)
        End If

    End Sub

    Private Sub btnOptionB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionB.Click
        SetDecision(1)
        If (HideConfirmButtons) Then
            RaiseEvent DecisionMade(Me, Decision) '0 for Top, 1 for Bottom
        Else
            showconfirm(True)
        End If
        showconfirm(True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        SetDecision(-999)

        showconfirm(False)
    End Sub

    Public Sub SetPrize(ByVal p As Integer) Implements RiskControlInterface.SetPrize

    End Sub

    Public Sub SetShowDiceInfo(ByVal b As Boolean) Implements RiskControlInterface.SetShowDiceInfo

    End Sub
End Class
