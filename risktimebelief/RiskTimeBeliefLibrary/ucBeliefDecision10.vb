Imports System.Windows.Forms.DataVisualization.Charting
Imports System.ComponentModel
Imports System.Threading

Public Class ucBeliefDecision10
    Implements BeliefControlInterface



    Dim P As BeliefParameters

    Dim DisplayFont As Font

    Dim Sliders(9) As System.Windows.Forms.TrackBar
    Dim SliderLabels(9) As System.Windows.Forms.Label

    Dim Decision(9) As Integer


    'maybe temporary stuff below
    Dim Chart2Size As Integer = 5
    Dim NumTokens As Integer = 100
    Dim AllocatedTokens As Integer = 0

    'scoring rule parameters
    Dim Alpha As Single '= 10
    Dim Beta As Single '= 10

    'constant to determine type of prize: 1=dollars, 2=points; this is passed in by the SetCurency public subroutine
    Dim Prize As Integer

    Dim Xvals(9) As String
    Dim Yvals(9) As Single

    Dim LowRes As Boolean = False

    Public Sub CancelChoices() Implements BeliefControlInterface.CancelChoices

    End Sub



    Public Function GetDecision() As Single() Implements BeliefControlInterface.GetDecision
        Dim d(9) As Single
        For i As Integer = 0 To 9
            d(i) = Decision(i) / NumTokens
        Next
        Return d
    End Function

    Public Sub Initialize(ByVal x As BeliefParameters) Implements BeliefControlInterface.Initialize




        Me.P = x

        Alpha = P.Alpha
        Beta = P.Beta

        Sliders(0) = TrackBar1
        Sliders(1) = TrackBar2
        Sliders(2) = TrackBar3
        Sliders(3) = TrackBar4
        Sliders(4) = TrackBar5
        Sliders(5) = TrackBar6
        Sliders(6) = TrackBar7
        Sliders(7) = TrackBar8
        Sliders(8) = TrackBar9
        Sliders(9) = TrackBar10

        SliderLabels(0) = Label1
        SliderLabels(1) = Label2
        SliderLabels(2) = Label3
        SliderLabels(3) = Label4
        SliderLabels(4) = Label5
        SliderLabels(5) = Label6
        SliderLabels(6) = Label7
        SliderLabels(7) = Label8
        SliderLabels(8) = Label9
        SliderLabels(9) = Label10

        For i As Integer = 0 To 9
            'Decision(i) = New Integer
            'Decision(i) = 10
            'Sliders(i).Value = 10
            AddHandler Sliders(i).ValueChanged, AddressOf Me.Sliders_ValueChanged
            Sliders(i).Tag = i
            Sliders(i).Minimum = 0
            Sliders(i).Maximum = NumTokens
            SliderLabels(i).Font = BarChart.ChartAreas(0).AxisX.LabelStyle.Font
        Next

        Decision(0) = P.Allocation1
        Decision(1) = P.Allocation2
        Decision(2) = P.Allocation3
        Decision(3) = P.Allocation4
        Decision(4) = P.Allocation5
        Decision(5) = P.Allocation6
        Decision(6) = P.Allocation7
        Decision(7) = P.Allocation8
        Decision(8) = P.Allocation9
        Decision(9) = P.Allocation10

        Sliders(0).Value = P.Allocation1
        Sliders(1).Value = P.Allocation2
        Sliders(2).Value = P.Allocation3
        Sliders(3).Value = P.Allocation4
        Sliders(4).Value = P.Allocation5
        Sliders(5).Value = P.Allocation6
        Sliders(6).Value = P.Allocation7
        Sliders(7).Value = P.Allocation8
        Sliders(8).Value = P.Allocation9
        Sliders(9).Value = P.Allocation10




        With BarChart

            .Series(0).ChartType = SeriesChartType.Column
            .Series(0)("PointWidth") = ".95"

            .Series(0)("BarLabelStyle") = "Center"
            .ChartAreas(0).AxisX.MajorGrid.Enabled = False
            .ChartAreas(0).AxisY.MajorGrid.Enabled = False
            .ChartAreas(0).AxisX.Minimum = 0
            .ChartAreas(0).AxisX.Maximum = 11
            .ChartAreas(0).AxisX.MinorGrid.Enabled = False
            .ChartAreas(0).AxisX.MinorTickMark.Enabled = False
            .ChartAreas(0).AxisX.MajorTickMark.Enabled = False
            .ChartAreas(0).AxisX.Interval = 1

            If Prize = 1 Then
                .ChartAreas(0).AxisY.Minimum = Alpha - Beta
                .ChartAreas(0).AxisY.Maximum = Alpha + Beta
                .Series(0).LabelFormat = "C2"

            ElseIf Prize = 2 Then
                .ChartAreas(0).AxisY.Minimum = (Alpha - Beta) * 100
                .ChartAreas(0).AxisY.Maximum = (Alpha + Beta) * 100
                '.Series(0).LabelFormat = "D"
                .Series(0).Label = "#VALY{D} points"
            End If
            .Series(0).IsVisibleInLegend = False
            .Series(0).IsValueShownAsLabel = True
            .ChartAreas(0).AxisX.LabelStyle.IsEndLabelVisible = False


            '.BackColor = Parent.BackColor
        End With

        DrawBarChart()

        lblDescription.Text = P.Text

        SetSliderColumnWidths()


    End Sub

    Private Sub SetSliderColumnWidths() 'in percentages
        Dim FirstColumnWidth As Single = 12   'change this value to fine tune the horizontal placement of sliders
        If LowRes = True Then FirstColumnWidth = 13.3
        Dim SliderColumnWidth As Single = 7.9
        If LowRes = True Then SliderColumnWidth = 7.72
        Dim FinalColumnWidth As Single = 100 'residual to be decremented each time we set another column width
        With tlpSliders
            For i = 0 To 10
                If i = 0 Then
                    .ColumnStyles(i).Width = FirstColumnWidth
                Else
                    .ColumnStyles(i).Width = SliderColumnWidth
                End If
                FinalColumnWidth = FinalColumnWidth - .ColumnStyles(i).Width
            Next i
            .ColumnStyles(11).Width = FinalColumnWidth
        End With
    End Sub

    Private Sub Sliders_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        'lblDescription.Text = sender.tag

        Dim SliderTotal As Integer = 0
        For i As Integer = 0 To 9
            SliderTotal = SliderTotal + Sliders(i).Value
        Next

        If SliderTotal > NumTokens And sender.Value > Decision(sender.tag) Then
            sender.Value = Decision(sender.tag)
        End If
        Decision(sender.tag) = sender.Value
        DrawBarChart()

    End Sub


    Private Sub DrawBarChart()


        Xvals(0) = P.Xlabel1
        Xvals(1) = P.Xlabel2
        Xvals(2) = P.Xlabel3
        Xvals(3) = P.Xlabel4
        Xvals(4) = P.Xlabel5
        Xvals(5) = P.Xlabel6
        Xvals(6) = P.Xlabel7
        Xvals(7) = P.Xlabel8
        Xvals(8) = P.Xlabel9
        Xvals(9) = P.Xlabel10

        AllocatedTokens = 0
        For i As Integer = 0 To 9
            'If i = 0 Then
            '    Xvals(i) = "0% to 9%"
            'ElseIf i = 9 Then
            '    Xvals(i) = "90% to 100%"
            'Else
            '    Xvals(i) = (i * 10).ToString & "% to " & ((i + 1) * 10 - 1).ToString & "%"
            'End If
            If Prize = 1 Then
                Yvals(i) = ScoringRule(i)
            ElseIf Prize = 2 Then
                Yvals(i) = Math.Round(ScoringRule(i) * 100)
            End If

            AllocatedTokens = AllocatedTokens + Decision(i)
            If Prize = 1 Then
                SliderLabels(i).Text = Decision(i) & " tokens" & vbCrLf & "pay " & Settings.FormatCurrency(Yvals(i))
            ElseIf Prize = 2 Then
                SliderLabels(i).Text = Decision(i) & " tokens" & vbCrLf & "pay " & Yvals(i).ToString("#") & " points"
            End If
        Next

        'BarChart.ChartAreas(0).AxisY.Maximum = 1
        BarChart.Series(0).Points.DataBindXY(Xvals, Yvals)
        'lblTokens.Text = "Unallocated tokens: " & (NumTokens - AllocatedTokens).ToString

        lblTokens.Text = "Unallocated tokens: " & (NumTokens - AllocatedTokens).ToString & vbCrLf
        'lblTokens.Text = lblTokens.Text & "Current token allocation implies:" & vbCrLf
        'lblTokens.Text = lblTokens.Text & "Average expected payout "
        'If Prize = 1 Then
        '    lblTokens.Text = lblTokens.Text & Settings.FormatCurrency(GetAverage) & vbCrLf
        'ElseIf Prize = 2 Then
        '    lblTokens.Text = lblTokens.Text & GetAverage.ToString("#") & " points" & vbCrLf
        'End If
        'lblTokens.Text = lblTokens.Text & "Maximum expected payout "
        'If Prize = 1 Then
        '    lblTokens.Text = lblTokens.Text & Settings.FormatCurrency(GetMaximum) & vbCrLf
        'ElseIf Prize = 2 Then
        '    lblTokens.Text = lblTokens.Text & GetMaximum.ToString("#") & " points" & vbCrLf
        'End If
        'lblTokens.Text = lblTokens.Text & "Minimum expected payout "
        'If Prize = 1 Then
        '    lblTokens.Text = lblTokens.Text & Settings.FormatCurrency(GetMinimum)
        'ElseIf Prize = 2 Then
        '    lblTokens.Text = lblTokens.Text & GetMinimum.ToString("0") & " points"
        'End If

        BarChart.Titles.Clear()
        BarChart.Titles.Add(lblTokens.Text)

        'The following line is to address the bug reported by Andre where the Y axis labels display with many decimal places
        BarChart.ChartAreas(0).AxisY.LabelStyle.Format = "#,###"

        If AllocatedTokens <> NumTokens Then
            'BarChart.Series(0).Color = Color.PowderBlue
            btnSubmit.Enabled = False
            btnConfirm.Visible = False
            btnCancel.Visible = False
            lblInstructions.Text = "You must allocate all tokens before you are able to submit"
        Else
            BarChart.Series(0).Color = Color.DodgerBlue
            btnSubmit.Enabled = True
            btnConfirm.Visible = False
            btnCancel.Visible = False
            lblInstructions.Text = "Submit your decision or continue making choices"
        End If

        'Label5.Location = New Point(15 + Chart2.Location.X + Chart2.Size.Width * Chart2.ChartAreas(0).InnerPlotPosition.X / 100, Label5.Location.Y)

    End Sub


    Private Function GetAverage() As Single
        'Dim Sum As Single = 0
        Dim Avg As Single = 0
        For i As Integer = 0 To 9
            'Avg = Avg + ScoringRule(i) * Decision(i) / AllocatedTokens
            'Avg = Avg + ScoringRule(i) * Decision(i)
            Avg = Avg + Yvals(i) * Decision(i) / AllocatedTokens
        Next
        Return Avg
    End Function

    Private Function GetMaximum() As Single
        'Dim Sum As Single = 0
        Dim Max As Single = Yvals(0)
        For i As Integer = 1 To 9
            If Yvals(i) > Max Then Max = Yvals(i)
        Next
        Return Max
    End Function

    Private Function GetMinimum() As Single
        'Dim Sum As Single = 0
        Dim Min As Single = Yvals(0)
        For i As Integer = 1 To 9
            If Yvals(i) < Min Then Min = Yvals(i)
        Next
        Return Min
    End Function

    Private Function ScoringRule(ByVal j As Integer) As Single
        Dim SS As Single = 0
        Dim Result As Single
        For i = 0 To 9
            SS = SS + (Decision(i) / NumTokens) ^ 2
        Next
        Result = Alpha + Beta * ((2 * Decision(j) / NumTokens) - SS)
        Return Result
    End Function




    Public Function IsBlank() As Boolean Implements BeliefControlInterface.IsBlank

    End Function

    Public Sub SetColors(ByVal c1 As System.Drawing.Color, ByVal c2 As System.Drawing.Color, ByVal c3 As System.Drawing.Color, ByVal c4 As System.Drawing.Color) Implements BeliefControlInterface.SetColors

    End Sub

    Public Sub SetFont(ByVal f As System.Drawing.Font) Implements BeliefControlInterface.SetFont
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

    Public Sub SetVisible(ByVal b As Boolean) Implements BeliefControlInterface.SetVisible

    End Sub

    Public Function ValidateDecision() As Boolean Implements BeliefControlInterface.ValidateDecision

    End Function


    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub


    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        btnSubmit.Enabled = False
        btnConfirm.Visible = True
        btnCancel.Visible = True
        lblInstructions.Text = "Confirm or cancel your decision"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DrawBarChart()
    End Sub

    Public Event DecisionMade(ByVal sender As BeliefControlInterface, ByVal Decisions() As Single) Implements BeliefControlInterface.DecisionMade


    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim d(9) As Single
        For i As Integer = 0 To 9
            d(i) = Decision(i) / NumTokens
        Next
        RaiseEvent DecisionMade(Me, d)
    End Sub


    Private Sub TableLayoutPanel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Public Sub SetDecision(ByVal d() As Object) Implements BeliefControlInterface.SetDecision






        For i As Integer = 0 To 9

            Decision(i) = d(i) * NumTokens
            Sliders(i).Visible = False


            'Sliders(i).Value = d(i) * NumTokens
            'AddHandler Sliders(i).ValueChanged, AddressOf Me.Sliders_ValueChanged
            'Sliders(i).Tag = i
            'Sliders(i).Minimum = 0
            'Sliders(i).Maximum = NumTokens
            'SliderLabels(i).Font = BarChart.ChartAreas(0).AxisX.LabelStyle.Font
        Next
        btnSubmit.Visible = False
        lblInstructions.Visible = False

        DrawBarChart()

    End Sub



    Public Sub SetPrize(ByVal p As Integer) Implements BeliefControlInterface.SetPrize
        Prize = p
    End Sub

    Public Sub SetPreset(ByVal p As BeliefPreset) Implements BeliefControlInterface.SetPreset

        Dim a(9) As Integer

        a(0) = p.X1
        a(1) = p.X2
        a(2) = p.X3
        a(3) = p.X4
        a(4) = p.X5
        a(5) = p.X6
        a(6) = p.X7
        a(7) = p.X8
        a(8) = p.X9
        a(9) = p.X10

        For i As Integer = 0 To 9
            Decision(i) = a(i)
            Sliders(i).Value = a(i)
        Next

        DrawBarChart()

    End Sub

    Public Sub SetLowRes() Implements BeliefControlInterface.SetLowRes
        LowRes = True
    End Sub
End Class
