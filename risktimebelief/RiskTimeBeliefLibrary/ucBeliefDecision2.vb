
Imports System.Windows.Forms.DataVisualization.Charting
Public Class ucBeliefDecision2
    Implements BeliefControlInterface




    Dim P As BeliefParameters

    Dim DisplayFont As Font

    Dim Sliders(1) As System.Windows.Forms.TrackBar
    Dim SliderLabels(1) As System.Windows.Forms.Label

    Dim Decision(1) As Integer


    'maybe temporary stuff below
    Dim Chart2Size As Integer = 5
    Dim NumTokens As Integer = 100
    Dim AllocatedTokens As Integer = 0

    'scoring rule parameters
    Dim Alpha As Single '= 0.5
    Dim Beta As Single '= 0.5

    'constant to determine type of prize: 1=dollars, 2=points; this is passed in by the SetCurency public subroutine
    Dim Prize As Integer

    Dim Xvals(1) As String
    Dim Yvals(1) As Single

    Dim LowRes As Boolean = False

    Public Sub CancelChoices() Implements BeliefControlInterface.CancelChoices

    End Sub



    Public Function GetDecision() As Single() Implements BeliefControlInterface.GetDecision
        Dim d(1) As Single
        For i As Integer = 0 To 1
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

        SliderLabels(0) = Label1
        SliderLabels(1) = Label2



        For i As Integer = 0 To 1
            'Decision(i) = New Integer
            'Decision(i) = 50
            Sliders(i).Minimum = 0
            Sliders(i).Maximum = NumTokens
            'Sliders(i).Value = 50
            AddHandler Sliders(i).ValueChanged, AddressOf Me.Sliders_ValueChanged
            Sliders(i).Tag = i
            SliderLabels(i).Font = BarChart.ChartAreas(0).AxisX.LabelStyle.Font
        Next

        Decision(0) = P.Allocation1
        Decision(1) = P.Allocation2

        Sliders(0).Value = P.Allocation1
        Sliders(1).Value = P.Allocation2

        With BarChart
            .Series(0).ChartType = SeriesChartType.Column
            .Series(0)("PointWidth") = ".3"

            .Series(0)("BarLabelStyle") = "Center"
            .ChartAreas(0).AxisX.MajorGrid.Enabled = False
            .ChartAreas(0).AxisY.MajorGrid.Enabled = False
            .ChartAreas(0).AxisX.Minimum = 0
            .ChartAreas(0).AxisX.Maximum = 3
            .ChartAreas(0).AxisX.MinorGrid.Enabled = False
            .ChartAreas(0).AxisX.MinorTickMark.Enabled = False
            .ChartAreas(0).AxisX.MajorTickMark.Enabled = False
            .ChartAreas(0).AxisX.Interval = 1

            '.ChartAreas(0).AxisY.Minimum = Alpha - Beta
            '.ChartAreas(0).AxisY.Maximum = Alpha + Beta
            '.Series(0).LabelFormat = "C2"

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
        Dim FirstColumnWidth As Single = 23.5  'change this value to fine tune the horizontal placement of sliders
        Dim SliderColumnWidth As Single = 28.25
        Dim FinalColumnWidth As Single = 100 'residual to be decremented each time we set another column width
        With tlpSliders
            For i = 0 To 2
                If i = 0 Then
                    .ColumnStyles(i).Width = FirstColumnWidth
                Else
                    .ColumnStyles(i).Width = SliderColumnWidth
                End If
                FinalColumnWidth = FinalColumnWidth - .ColumnStyles(i).Width
            Next i
            .ColumnStyles(3).Width = FinalColumnWidth
        End With
    End Sub

    Private Sub Sliders_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        'lblDescription.Text = sender.tag

        'Dim SliderTotal As Integer = 0
        'For i As Integer = 0 To 1
        '    SliderTotal = SliderTotal + Sliders(i).Value
        'Next

        If sender.value > NumTokens Then
            sender.Value = Decision(sender.tag)
        End If
        Decision(sender.tag) = sender.Value
        'now update the other bar...
        If sender.tag = 0 Then
            Sliders(1).Value = NumTokens - sender.value
            Decision(1) = NumTokens - sender.value
        ElseIf sender.tag = 1 Then
            Sliders(0).Value = NumTokens - sender.value
            Decision(0) = NumTokens - sender.value
        End If

        DrawBarChart()

    End Sub


    Private Sub DrawBarChart()


        AllocatedTokens = 0

        Xvals(0) = P.LeftLabel
        Xvals(1) = P.RightLabel


        For i As Integer = 0 To 1
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

        'lblTokens.Text = "Unallocated tokens: " & (NumTokens - AllocatedTokens).ToString & vbCrLf & "Average payout: " & GetAverage.ToString("$#.00")
        'lblTokens.Text = "Average payout: " & GetAverage.ToString("$#.00")


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
        For i As Integer = 0 To 1
            'Avg = Avg + ScoringRule(i) * Decision(i) / AllocatedTokens
            Avg = Avg + Yvals(i) * Decision(i) / AllocatedTokens
        Next
        Return Avg
    End Function

    Private Function GetMaximum() As Single
        'Dim Sum As Single = 0
        'Dim Max As Single = ScoringRule(0)
        'If ScoringRule(1) > Max Then Max = ScoringRule(1)
        Dim Max As Single = Yvals(0)
        If Yvals(1) > Max Then Max = Yvals(1)
        Return Max
    End Function

    Private Function GetMinimum() As Single
        'Dim Sum As Single = 0
        Dim Min As Single = Yvals(0)
        If Yvals(1) < Min Then Min = Yvals(1)
        Return Min
    End Function

    Private Function ScoringRule(ByVal j As Integer) As Single
        Dim SS As Single = 0
        Dim Result As Single
        For i = 0 To 1
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
        Dim d(1) As Single
        For i As Integer = 0 To 1
            d(i) = Decision(i) / NumTokens
        Next
        RaiseEvent DecisionMade(Me, d)
    End Sub

    Public Sub SetDecision(ByVal d() As Object) Implements BeliefControlInterface.SetDecision
        For i As Integer = 0 To 1

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

    Public Sub SetPrize(ByVal c As Integer) Implements BeliefControlInterface.SetPrize
        Prize = c
    End Sub

    Private Sub lblTokens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTokens.Click

    End Sub

    Public Sub SetPreset(ByVal p As BeliefPreset) Implements BeliefControlInterface.SetPreset

    End Sub

    Public Sub SetLowRes() Implements BeliefControlInterface.SetLowRes
        LowRes = True
    End Sub
End Class
