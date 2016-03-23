Public Class ucMPL
    Implements AMPLControlInterface


    Dim Decision As Single = -999
    Dim LeftColor As Color
    Dim RightColor As Color
    Dim NumberOfRounds As Integer

    Dim Index As Integer = -1

    Dim ManualChange As Boolean = False


    Private Sub rbLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLeft.CheckedChanged
        lblLeft.BackColor = LeftColor
        lblRight.BackColor = Me.Parent.BackColor
        Decision = 0    '0 for left, 1 for right
        If ManualChange = False Then RaiseEvent DecisionMade(Me, Decision)
        ManualChange = False
        lblRound1.Text = "Left"
        lblRound1.BackColor = LeftColor
        lblRound2.Text = "Left"
        lblRound2.BackColor = LeftColor
        lblRound3.Text = "Left"
        lblRound3.BackColor = LeftColor
    End Sub

    Private Sub rbRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRight.CheckedChanged
        lblRight.BackColor = RightColor
        lblLeft.BackColor = Me.Parent.BackColor
        Decision = 1    '0 for left, 1 for right
        If ManualChange = False Then RaiseEvent DecisionMade(Me, Decision)
        ManualChange = False
        lblRound1.Text = "Right"
        lblRound1.BackColor = RightColor
        lblRound2.Text = "Right"
        lblRound2.BackColor = RightColor
        lblRound3.Text = "Right"
        lblRound3.BackColor = RightColor

    End Sub


    Public Sub CancelChoices() Implements AMPLControlInterface.CancelChoices
        'Cancel = True
        'unselect radio buttons

        If rbLeft.Checked = True Then
            Me.rbLeft.Checked = False
        End If

        If rbRight.Checked = True Then
            Me.rbRight.Checked = False
        End If


        'unhighlight labels
        Me.lblLeft.BackColor = Me.BackColor
        Me.lblRight.BackColor = Me.BackColor
        'Cancel = False

        lblRound1.Text = ""
        lblRound1.BackColor = Me.BackColor
        lblRound2.Text = ""
        lblRound2.BackColor = Me.BackColor
        lblRound3.Text = ""
        lblRound3.BackColor = Me.BackColor

    End Sub

    Public Event DecisionMade(sender As AMPLControlInterface, Decision As Single) Implements AMPLControlInterface.DecisionMade

    Public Function GetDecision() As Single Implements AMPLControlInterface.GetDecision
        Return Decision
    End Function

    Public Function GetIndex() As Integer Implements AMPLControlInterface.GetIndex
        Return Index
    End Function

    Public Sub Initialize(p As AtemporalMPLparameters) Implements AMPLControlInterface.Initialize
        lblLeft.Text = p.LeftText.Replace("\n", Environment.NewLine)
        lblRight.Text = p.RightText.Replace("\n", Environment.NewLine)
        NumberOfRounds = p.NumberOfRounds


        Select Case NumberOfRounds
            Case 0
                lblRound1.Visible = False
                lblRound2.Visible = False
                lblRound3.Visible = False
            Case 1
                lblRound2.Visible = False
                lblRound3.Visible = False
            Case 2
                lblRound3.Visible = False
        End Select



    End Sub

    Public Function IsBlank() As Boolean Implements AMPLControlInterface.IsBlank
        If rbLeft.Checked = False And rbRight.Checked = False Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub OpenDecisionType(t As Integer) Implements AMPLControlInterface.OpenDecisionType

    End Sub

    Public Sub PerformChoice(d As Single) Implements AMPLControlInterface.PerformChoice
        ManualChange = True
        If d = 0 Then rbLeft.PerformClick()
        If d = 1 Then rbRight.PerformClick()
    End Sub

    Public Sub SetDecision(d As Single) Implements AMPLControlInterface.SetDecision
        rbLeft.Visible = False
        rbRight.Visible = False
        If d = 0 Then 'Left
            lblLeft.BackColor = LeftColor
            lblRight.BackColor = Color.Transparent
            lblRound1.Text = "Left"
            lblRound1.BackColor = LeftColor
            lblRound2.Text = "Left"
            lblRound2.BackColor = LeftColor
            lblRound3.Text = "Left"
            lblRound3.BackColor = LeftColor

            'Select Case NumberOfRounds
            '    Case 0
            '        lblRound1.Visible = False
            '        lblRound2.Visible = False
            '        lblRound3.Visible = False
            '    Case 1
            '        lblRound2.Visible = False
            '        lblRound3.Visible = False
            '    Case 2
            '        lblRound3.Visible = False
            'End Select
        End If
        If d = 1 Then
            lblLeft.BackColor = Color.Transparent
            lblRight.BackColor = RightColor
            lblRound1.Text = "Right"
            lblRound1.BackColor = RightColor
            lblRound2.Text = "Right"
            lblRound2.BackColor = RightColor
            lblRound3.Text = "Right"
            lblRound3.BackColor = RightColor
        End If
    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements AMPLControlInterface.SetFont
        NewFont(Me, f)



        'rbLeft.Font = New Font(f.Name, f.Size - 2, f.Style)




        rbLeft.Font = New Font(rbLeft.Font.Name, rbLeft.Font.Size - 1, FontStyle.Regular)
        rbRight.Font = New Font(rbRight.Font.Name, rbRight.Font.Size - 1, FontStyle.Regular)
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

    Public Sub SetIndex(i As Integer) Implements AMPLControlInterface.SetIndex
        Index = i
    End Sub

    Public Sub SetLaterColor(c As System.Drawing.Color) Implements AMPLControlInterface.SetLaterColor
        RightColor = c
    End Sub

    Public Sub SetSoonerColor(c As System.Drawing.Color) Implements AMPLControlInterface.SetSoonerColor
        LeftColor = c
    End Sub

    Public Sub SetVisible(b As Boolean) Implements AMPLControlInterface.SetVisible
        Me.Visible = b
    End Sub

    Public Function ValidateDecision() As Boolean Implements AMPLControlInterface.ValidateDecision
        If rbLeft.Checked = True Or rbRight.Checked = True Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles lblRound3.Click

    End Sub

    Public Sub SetBackgroundColor(c As System.Drawing.Color) Implements AMPLControlInterface.SetBackgroundColor
        Me.BackColor = c
        lblRound1.BackColor = c
        lblRound2.BackColor = c
        lblRound3.BackColor = c
    End Sub
End Class
