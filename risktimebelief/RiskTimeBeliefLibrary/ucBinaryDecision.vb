

Public Class ucBinaryDecision
    Implements DiscountingControlInterface

    Dim Decision As Single = -999
    Dim SoonerColor As Color
    Dim LaterColor As Color

    Dim Index As Integer = -1

    'This variable is to control the radiobutton checkchanged event activity.  
    'When the CancelChoices subroutine is called, it unchecks radiobuttons, which triggers the checkchanged event.
    'And we do not want the checkchanged functionality to occur when triggered by the CancelChoices subroutine.
    'Dim Cancel As Boolean = False


    Dim ManualChange As Boolean = False

    Private Sub rbLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLeft.CheckedChanged
        lblLeft.BackColor = SoonerColor
        lblRight.BackColor = Me.Parent.BackColor
        Decision = 0    '0 for left, 1 for right
        If ManualChange = False Then RaiseEvent DecisionMade(Me, Decision)
        ManualChange = False
    End Sub

    Private Sub rbRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRight.CheckedChanged
        lblRight.BackColor = LaterColor
        lblLeft.BackColor = Me.Parent.BackColor
        Decision = 1    '0 for left, 1 for right
        If ManualChange = False Then RaiseEvent DecisionMade(Me, Decision)
        ManualChange = False
    End Sub



    Public Function ValidateDecision() As Boolean Implements DiscountingControlInterface.ValidateDecision
        If rbLeft.Checked = True Or rbRight.Checked = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements DiscountingControlInterface.SetFont
        NewFont(Me, f)



        'rbLeft.Font = New Font(f.Name, f.Size - 2, f.Style)






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

    Public Sub SetVisible(ByVal b As Boolean) Implements DiscountingControlInterface.SetVisible
        Me.Visible = b
    End Sub

    Public Sub CancelChoices() Implements DiscountingControlInterface.CancelChoices
        'Cancel = True
        'unselect radio buttons
        Me.rbLeft.Checked = False
        Me.rbRight.Checked = False

        'unhighlight labels
        Me.lblLeft.BackColor = Me.BackColor
        Me.lblRight.BackColor = Me.BackColor
        'Cancel = False
    End Sub

    Public Sub Initialize(ByVal P As DiscountingParameters) Implements DiscountingControlInterface.Initialize
        Dim s As String

        s = Settings.FormatCurrency(P.Lamount)
        If P.Ldays = 0 Then
            s = s + " today"
        ElseIf P.Ldays = 1 Then
            s = s + " in 1 day"
        Else
            s = s + " in " + P.Ldays.ToString + " days"
        End If
        Me.lblLeft.Text = s

        s = Settings.FormatCurrency(P.Ramount)
        If P.Rdays = 0 Then
            s = s + " today"
        ElseIf P.Rdays = 1 Then
            s = s + " in 1 day"
        Else
            s = s + " in " + P.Rdays.ToString + " days"
        End If
        Me.lblRight.Text = s

    End Sub

    Public Sub OpenDecisionType(ByVal t As Integer) Implements DiscountingControlInterface.OpenDecisionType

    End Sub


    Public Function IsBlank() As Boolean Implements DiscountingControlInterface.IsBlank
        If rbLeft.Checked = False And rbRight.Checked = False Then
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
        Return Decision
    End Function

    Private Sub tlpMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tlpMain.Paint

    End Sub

    Public Sub SetDecision(ByVal d As Single) Implements DiscountingControlInterface.SetDecision
        rbLeft.Visible = False
        rbRight.Visible = False
        If d = 0 Then 'Left
            lblLeft.BackColor = SoonerColor
            lblRight.BackColor = Color.Transparent
        End If
        If d = 1 Then
            lblLeft.BackColor = Color.Transparent
            lblRight.BackColor = LaterColor
        End If
    End Sub

    Public Function GetIndex() As Integer Implements DiscountingControlInterface.GetIndex
        Return Index
    End Function

    Public Sub SetIndex(i As Integer) Implements DiscountingControlInterface.SetIndex
        Index = i
    End Sub



    Public Sub PerformChoice(d As Single) Implements DiscountingControlInterface.PerformChoice
        ManualChange = True
        If d = 0 Then rbLeft.PerformClick()
        If d = 1 Then rbRight.PerformClick()
    End Sub
End Class
