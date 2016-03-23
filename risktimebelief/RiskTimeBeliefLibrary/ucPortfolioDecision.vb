Public Class ucPortfolioDecision

    Implements DiscountingControlInterface

    Dim SoonerColor As Color
    Dim LaterColor As Color

    Dim Paras As DiscountingParameters
    Dim LeftText As String
    Dim RightText As String
    Dim LeftValue As Single
    Dim RightValue As Single


    Public Sub CancelChoices() Implements DiscountingControlInterface.CancelChoices
        Me.txtLeft.Text = ""
        Me.txtRight.Text = ""
        Me.lblLeftPayout.Text = ""
        Me.lblRightPayout.Text = ""
        lblLeftPayout.BackColor = Me.Parent.BackColor
        lblRightPayout.BackColor = Me.Parent.BackColor
    End Sub


    Public Sub Initialize(ByVal P As DiscountingParameters) Implements DiscountingControlInterface.Initialize
        Dim s As String

        Paras = P

        s = "% of " & Settings.FormatCurrency(Paras.Lamount)
        If Paras.Ldays = 0 Then
            s = s & " today"
        ElseIf Paras.Ldays = 1 Then
            s = s & " in 1 day"
        Else
            s = s & " in " + Paras.Ldays.ToString + " days"
        End If
        Me.lblLeft.Text = s

        s = "% of " & Settings.FormatCurrency(Paras.Ramount)
        If Paras.Rdays = 0 Then
            s = s & " today"
        ElseIf Paras.Rdays = 1 Then
            s = s & " in 1 day"
        Else
            s = s & " in " + Paras.Rdays.ToString + " days"
        End If
        Me.lblRight.Text = s

        lblLeftPayout.Text = ""
        lblRightPayout.Text = ""
    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements DiscountingControlInterface.SetFont
        NewFont(Me, f)
    End Sub

    Public Sub SetVisible(ByVal b As Boolean) Implements DiscountingControlInterface.SetVisible
        Me.Visible = b
    End Sub

    Public Function ValidateDecision() As Boolean Implements DiscountingControlInterface.ValidateDecision
        If Val(txtLeft.Text) + Val(txtRight.Text) = 100 Then
            Return True
        Else
            Return False
        End If
    End Function

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

    Private Sub txtLeft_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLeft.KeyPress
        LeftText = CType(sender, TextBox).Text
    End Sub

    Private Sub txtLeft_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeft.TextChanged
        Dim textbox As TextBox = CType(sender, TextBox)
        Dim num As Single
        If textbox.Text.Length > 0 AndAlso Not Single.TryParse(textbox.Text, num) OrElse num > 100 OrElse num < 0 Then
            textbox.Text = LeftText
            textbox.SelectAll()
            Exit Sub
        End If
        If textbox.Text = "" Then
            lblLeftPayout.Text = ""
            lblLeftPayout.BackColor = Me.Parent.BackColor
            'frmDiscountingTest.CheckChoices()
            RaiseEvent DecisionMade(Me, -999)
            Exit Sub
        End If

        LeftValue = Val(textbox.Text)
        RightValue = 100 - LeftValue
        RightText = RightValue.ToString
        txtRight.Text = RightText
        lblLeftPayout.Text = Settings.FormatCurrency(LeftValue * Paras.Lamount / 100)
        lblRightPayout.Text = Settings.FormatCurrency(RightValue * Paras.Ramount / 100)
        lblRightPayout.BackColor = LaterColor


        'add code later to validate active cancel button, as currently if all text is changed to "" cancel button is still active
        'frmDiscountingTest.btnCancel.Enabled = True
        'frmDiscountingTest.CheckChoices()
        RaiseEvent DecisionMade(Me, LeftValue)
    End Sub

    Private Sub txtRight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRight.TextChanged
        Dim textbox As TextBox = CType(sender, TextBox)
        Dim num As Single
        If textbox.Text.Length > 0 AndAlso Not Single.TryParse(textbox.Text, num) OrElse num > 100 OrElse num < 0 Then
            textbox.Text = RightText
            textbox.SelectAll()
            Exit Sub
        End If
        If textbox.Text = "" Then
            lblRightPayout.Text = ""
            lblRightPayout.BackColor = Me.Parent.BackColor
            RaiseEvent DecisionMade(Me, -999)
            Exit Sub
        End If
        RightValue = Val(textbox.Text)
        LeftValue = 100 - RightValue
        LeftText = LeftValue.ToString
        txtLeft.Text = LeftText
        lblLeftPayout.Text = Settings.FormatCurrency(LeftValue * Paras.Lamount / 100)
        lblRightPayout.Text = Settings.FormatCurrency(RightValue * Paras.Ramount / 100)
        lblLeftPayout.BackColor = SoonerColor
        lblRightPayout.BackColor = LaterColor

        'add code later to validate active cancel button, as currently if all text is changed to "" cancel button is still active
        'frmDiscountingTest.btnCancel.Enabled = True
        'frmDiscountingTest.CheckChoices()
        RaiseEvent DecisionMade(Me, LeftValue)
    End Sub




    Private Sub lblMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMiddle.Click

    End Sub

    Public Sub OpenDecisionType(ByVal t As Integer) Implements DiscountingControlInterface.OpenDecisionType

    End Sub

    Public Function IsBlank() As Boolean Implements DiscountingControlInterface.IsBlank
        If txtLeft.Text = "" And txtRight.Text = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SetLaterColor(ByVal c As System.Drawing.Color) Implements DiscountingControlInterface.SetLaterColor
        LaterColor = c
    End Sub

    Public Sub SetSoonerColor(ByVal c As System.Drawing.Color) Implements DiscountingControlInterface.SetSoonerColor
        SoonerColor = c
    End Sub

    Public Event DecisionMade(ByVal sender As DiscountingControlInterface, ByVal Decision As Single) Implements DiscountingControlInterface.DecisionMade

    Public Function GetDecision() As Single Implements DiscountingControlInterface.GetDecision
        Return LeftValue
    End Function

    Public Sub SetDecision(ByVal d As Single) Implements DiscountingControlInterface.SetDecision

        LeftValue = d
        RightValue = 100 - d

        txtLeft.Text = LeftValue.ToString
        txtRight.Text = RightValue.ToString

        txtLeft.ReadOnly = True
        txtRight.ReadOnly = True

        'transparent colors don't work by default
        'txtLeft.BackColor = Color.Transparent


        lblLeftPayout.Text = Settings.FormatCurrency(LeftValue * Paras.Lamount / 100)
        lblRightPayout.Text = Settings.FormatCurrency(RightValue * Paras.Ramount / 100)



        'rbLeft.Visible = False
        'rbRight.Visible = False
        'If d = 0 Then 'Left
        '    lblLeft.BackColor = SoonerColor
        '    lblRight.BackColor = Color.Transparent
        'End If
        'If d = 1 Then
        '    lblLeft.BackColor = Color.Transparent
        '    lblRight.BackColor = LaterColor
        'End If

    End Sub

    Private Sub tlpMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tlpMain.Paint

    End Sub

    Public Function GetIndex() As Integer Implements DiscountingControlInterface.GetIndex

    End Function

    Public Sub SetIndex(i As Integer) Implements DiscountingControlInterface.SetIndex

    End Sub



    Public Sub PerformChoice(d As Single) Implements DiscountingControlInterface.PerformChoice

    End Sub
End Class
