Imports System.Globalization

Public Class ucOpenDecision

    Implements DiscountingControlInterface




    Dim Decision As Single = -999
    Dim SoonerColor As Color
    Dim LaterColor As Color


    'Dim Paras As DiscountingParameters
    Dim LeftText As String
    Dim RightText As String
    Dim LeftValue As Single
    Dim RightValue As Single
    Dim DecisionType As Integer

    Dim MaxDecision As Single '= 500

    Const OPEN_SOONER As Integer = 1
    Const OPEN_LATER As Integer = 2


    Public Sub CancelChoices() Implements DiscountingControlInterface.CancelChoices
        Me.txtLeft.Text = ""
        Me.txtRight.Text = ""
        LeftText = ""
        RightText = ""
        Decision = -999
        Me.lblLeftPayout.Text = ""
        Me.lblRightPayout.Text = ""
        lblLeftPayout.BackColor = Me.Parent.BackColor
        lblRightPayout.BackColor = Me.Parent.BackColor
    End Sub


    Public Sub Initialize(ByVal P As DiscountingParameters) Implements DiscountingControlInterface.Initialize
        Dim s As String

        'Paras = P

        If DecisionType = OPEN_SOONER Then
            If Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 1 Or Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 3 Then
                s = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
            Else
                s = ""
            End If
        Else
            s = Settings.FormatCurrency(P.Lamount)
        End If
        If P.Ldays = 0 Then
            s = s + " today"
        ElseIf P.Ldays = 1 Then
            s = s + " in 1 day"
        Else
            s = s + " in " + P.Ldays.ToString + " days"
        End If
        Me.lblLeft.Text = s


        If DecisionType = OPEN_LATER Then
            If Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 1 Or Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 3 Then
                s = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
            Else
                s = ""
            End If
        Else
            s = Settings.FormatCurrency(P.Ramount)
        End If
        If P.Rdays = 0 Then
            s = s + " today"
        ElseIf P.Rdays = 1 Then
            s = s + " in 1 day"
        Else
            s = s + " in " + P.Rdays.ToString + " days"
        End If
        Me.lblRight.Text = s

        lblLeftPayout.Text = ""
        lblRightPayout.Text = ""

        lblMiddle.Text = "IS THE" & vbCrLf & "SAME AS"


        If DecisionType = OPEN_SOONER Then
            MaxDecision = P.Ramount
        ElseIf DecisionType = OPEN_LATER Then
            MaxDecision = 500
        End If

        lblLeftDollar.Text = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
        lblRightDollar.Text = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol

    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements DiscountingControlInterface.SetFont
        NewFont(Me, f)
    End Sub

    Public Sub SetVisible(ByVal b As Boolean) Implements DiscountingControlInterface.SetVisible
        Me.Visible = b
    End Sub

    Public Function ValidateDecision() As Boolean Implements DiscountingControlInterface.ValidateDecision
        Dim num As Single
        If DecisionType = OPEN_SOONER Then
            If txtLeft.Text.Length > 0 And Single.TryParse(txtLeft.Text, num) Then Return True
        End If

        If DecisionType = OPEN_LATER Then
            If txtRight.Text.Length > 0 And Single.TryParse(txtRight.Text, num) Then Return True
        End If

        Return False

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
        Dim t As String = textbox.Text
        If t.Length = 0 Then
            Exit Sub
        End If
        If Not Single.TryParse(t, num) OrElse num < 0 OrElse num > MaxDecision OrElse (InStr(t, ".") > 0 And t.Substring(t.IndexOf(".") + 1).Length > 2) Then
            textbox.Text = LeftText
            'textbox.SelectAll()
            Exit Sub
        End If
        Decision = CSng(t)
        RaiseEvent DecisionMade(Me, Decision)
    End Sub

    Private Sub txtRight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRight.TextChanged
        Dim textbox As TextBox = CType(sender, TextBox)
        Dim num As Single
        Dim t As String = textbox.Text
        If t.Length = 0 Then
            Exit Sub
        End If
        If Not Single.TryParse(textbox.Text, num) OrElse num < 0 OrElse num > MaxDecision OrElse (InStr(t, ".") > 0 And t.Substring(t.IndexOf(".") + 1).Length > 2) Then
            textbox.Text = RightText
            textbox.SelectAll()
            Exit Sub
        End If
        'textbox.Text = CSng(textbox.Text).ToString("0.##")
        Decision = CSng(t)
        RaiseEvent DecisionMade(Me, Decision)
    End Sub






    Public Sub OpenDecisionType(ByVal t As Integer) Implements DiscountingControlInterface.OpenDecisionType
        If t = 1 Then 'sooner date is open
            DecisionType = OPEN_SOONER
            txtLeft.Visible = True
            If Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 0 Or Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 2 Then
                lblLeftDollar.Visible = True
            Else
                lblLeftDollar.Visible = False
            End If
            txtRight.Visible = False
            lblRightDollar.Visible = False
        ElseIf t = 2 Then 'later date is open
            DecisionType = OPEN_LATER
            txtLeft.Visible = False
            lblLeftDollar.Visible = False
            txtRight.Visible = True
            If Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 0 Or Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyPositivePattern = 2 Then
                lblRightDollar.Visible = True
            Else
                lblRightDollar.Visible = False
            End If
        End If
    End Sub

    Public Function IsBlank() As Boolean Implements DiscountingControlInterface.IsBlank
        If DecisionType = OPEN_SOONER Then
            If txtLeft.Text = "" Then
                Return True
            Else
                Return False
            End If
        End If

        If DecisionType = OPEN_LATER Then
            If txtRight.Text = "" Then
                Return True
            Else
                Return False
            End If
        End If

        Return False 'will never get here, but needed for completeness

    End Function

    Public Sub SetLaterColor(ByVal c As System.Drawing.Color) Implements DiscountingControlInterface.SetLaterColor
        LaterColor = c
    End Sub

    Public Sub SetSoonerColor(ByVal c As System.Drawing.Color) Implements DiscountingControlInterface.SetSoonerColor
        SoonerColor = c
    End Sub

    Public Event DecisionMade(ByVal sender As DiscountingControlInterface, ByVal Decision As Single) Implements DiscountingControlInterface.DecisionMade

    Public Function GetDecision() As Single Implements DiscountingControlInterface.GetDecision
        Return Decision
    End Function

    Private Sub lblMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMiddle.Click

    End Sub

    Public Sub SetDecision(ByVal d As Single) Implements DiscountingControlInterface.SetDecision

        If DecisionType = OPEN_SOONER Then
            LeftValue = d
            txtLeft.Text = LeftValue.ToString("0.00")
            txtLeft.ReadOnly = True
        ElseIf DecisionType = OPEN_LATER Then
            RightValue = d
            txtRight.Text = RightValue.ToString("0.00")
            txtRight.ReadOnly = True
        End If





        'transparent colors don't work by default
        'txtLeft.BackColor = Color.Transparent




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
