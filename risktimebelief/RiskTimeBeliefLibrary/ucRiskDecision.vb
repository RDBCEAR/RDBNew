Public Class ucRiskDecision
    Implements RiskControlInterface


    Dim Decision As Single = -999
    Dim DisplayFont As Font
    Dim Color1
    Dim Color2
    Dim Color3
    Dim Color4

    Dim P As RiskParameters

    Dim Prize As Integer '1=$, 2=points
    'Dim LeftTitle As String
    'Dim RightTitle As String

    Dim HideConfirmButtons As Boolean = False
    Dim ShowDiceInfo As Boolean = False

    Public Sub CancelChoices() Implements RiskControlInterface.CancelChoices
        Decision = -999
        MyGroupBoxLeft.ShowBorder = False
        MyGroupBoxRight.ShowBorder = False
        RaiseEvent DecisionMade(Me, -999)
    End Sub



    Public Sub Initialize(ByVal P As RiskParameters) Implements RiskControlInterface.Initialize
        Me.P = P
        Dim c As Color = Color.Blue
        Dim w As Integer = 2
        With MyGroupBoxLeft
            .ShowBorder = False
            .BorderColor = c
            .BorderWidth = w
        End With
        With MyGroupBoxRight
            .ShowBorder = False
            .BorderColor = c
            .BorderWidth = w
        End With
    End Sub

    Public Function IsBlank() As Boolean Implements RiskControlInterface.IsBlank

    End Function



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

        Dim g As Graphics = Me.CreateGraphics

        Dim CurrentFontSize As Integer = f.Size + 6
        'Dim StringLength As Integer


        'check to see if label is too big to fit with default font size defined above
        If g.MeasureString(P.LeftTitle, New Font(f.Name, CurrentFontSize, f.Style)).Width > Me.Width / 2 Or g.MeasureString(P.RightTitle, New Font(f.Name, CurrentFontSize, f.Style)).Width > Me.Width / 2 Then
            CurrentFontSize = 14
        End If

        lblLeftTitle.Font = New Font(f.Name, CurrentFontSize, f.Style)
        lblRightTItle.Font = New Font(f.Name, CurrentFontSize, f.Style)

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

    Public Sub DestroyPictures() Implements RiskControlInterface.DestroyPictures
        picLeftLottery.Image = Nothing
        picRightLottery.Image = Nothing
    End Sub

    Public Sub CreatePictures(ByVal Diameter As Single) Implements RiskControlInterface.CreatePictures

        'copy bitmap to left picturebox
        'If Side = _LEFT Then
        '    picLeftLottery.Location = New Point(gbLotteries.Width / 4 - Radius - LabelPadding, 50)
        '    picLeftLottery.Image = tmpBitMap
        'Else
        '    picRightLottery.Location = New Point(gbLotteries.Width * 3 / 4 - Radius - LabelPadding, 50)
        '    picRightLottery.Image = tmpBitMap
        'End If

        lblLeftTitle.Text = P.LeftTitle
        lblRightTItle.Text = P.RightTitle

        picLeftLottery.Image = CreatePieChart(Diameter, P.Lp1, P.La1, P.Lp2, P.La2, P.Lp3, P.La3, P.Lp4, P.La4)
        picRightLottery.Image = CreatePieChart(Diameter, P.Rp1, P.Ra1, P.Rp2, P.Ra2, P.Rp3, P.Ra3, P.Rp4, P.Ra4)

        'display selection buttons
        With btnLeftSelect
            .Enabled = True
            '.Font = DisplayFont
            '.Location = New Point(gbLotteries.Width / 4 - .Width / 2, lblLoutcome4.Location.Y + lblLoutcome4.Height + LabelPadding)
            .Visible = True
        End With

        With btnRightSelect
            .Enabled = True
            '.Font = DisplayFont
            '.Location = New Point(gbLotteries.Width * 3 / 4 - .Width / 2, lblRoutcome4.Location.Y + lblRoutcome4.Height + LabelPadding)
            .Visible = True
        End With





    End Sub

    Private Function CreatePieChart(ByVal diameter As Single, ByVal p1 As Single, ByVal a1 As Single, ByVal p2 As Single, ByVal a2 As Single, ByVal p3 As Single, ByVal a3 As Single, ByVal p4 As Single, ByVal a4 As Single) As Bitmap
        Dim Radius As Single
        Dim xCenter As Single
        Dim yCenter As Single
        Dim LabelPadding As Single
        Dim TopPadding As Single = 50
        Dim xLabel As Single
        Dim yLabel As Single
        Dim DegToRad As Single = 2 * Math.PI / 360

        Dim myGraphics As Graphics
        Dim myRectangle As Rectangle

        Dim SweepAngle1 As Single
        Dim SweepAngle2 As Single
        Dim SweepAngle3 As Single
        Dim SweepAngle4 As Single

        Dim StartAngle1 As Single
        Dim StartAngle2 As Single
        Dim StartAngle3 As Single
        Dim StartAngle4 As Single

        SweepAngle1 = p1 * 3.6
        SweepAngle2 = p2 * 3.6
        SweepAngle3 = p3 * 3.6
        SweepAngle4 = p4 * 3.6

        'I am start at "3 o'clock" on the pie chart, and filling clockwise
        StartAngle1 = 0
        StartAngle2 = StartAngle1 + SweepAngle1
        StartAngle3 = StartAngle2 + SweepAngle2
        StartAngle4 = StartAngle3 + SweepAngle3

        Radius = diameter / 2
        LabelPadding = 100
        xCenter = picLeftLottery.Width / 2
        yCenter = picLeftLottery.Height / 2


        'strategy here is to initially create image as a bitmap, and then when finished copy it to a picturebox
        'this is to work around autorefresh issues
        'Dim tmpBitMap As New Bitmap(CInt(diameter + 2 * LabelPadding), CInt(diameter + 2 * LabelPadding))
        Dim tmpBitMap As New Bitmap(CInt(picLeftLottery.Width), CInt(picLeftLottery.Height))

        'return the current form as a drawing surface
        myGraphics = Graphics.FromImage(tmpBitMap)

        'The following lines are to fix the jagged text displayed around the edge of the pie chart
        ' the code snippet is from http://stackoverflow.com/questions/3418283/graphics-drawstring-looks-nice-in-picturebox-but-horrible-in-a-bitmap
        myGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        myGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias


        'myGraphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        'myGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        myGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

        'create a rectangle based on x,y coor. width & height
        myRectangle = New Rectangle(x:=xCenter - Radius, y:=yCenter - Radius, Width:=diameter - 1, Height:=diameter - 1)

        'draw outcome 1 section
        myGraphics.FillPie(New SolidBrush(Color1), rect:=myRectangle, startAngle:=StartAngle1, sweepAngle:=SweepAngle1)

        'draw outcome 2 section
        myGraphics.FillPie(New SolidBrush(Color2), rect:=myRectangle, startAngle:=StartAngle2, sweepAngle:=SweepAngle2)

        'draw outcome 3 section
        myGraphics.FillPie(New SolidBrush(Color3), rect:=myRectangle, startAngle:=StartAngle3, sweepAngle:=SweepAngle3)

        'draw outcome 4 section
        myGraphics.FillPie(New SolidBrush(Color4), rect:=myRectangle, startAngle:=StartAngle4, sweepAngle:=SweepAngle4)

        'Add graphics labels here

        'If Side = _LEFT Then
        'picLeftLottery.Width = diameter + 2 * LabelPadding
        'picLeftLottery.Height = diameter + 2 * LabelPadding
        'xCenter = picLeftLottery.Width / 2
        'yCenter = picLeftLottery.Height / 2
        'Else
        'picRightLottery.Width = diameter + 2 * LabelPadding
        'picRightLottery.Height = diameter + 2 * LabelPadding
        'xCenter = picRightLottery.Width / 2
        'yCenter = picRightLottery.Height / 2
        'End If


        Dim tmpAmount As String = ""
        Dim tmpStringSize As SizeF
        Dim tmpAngle As Single
        Dim Xadj As Single
        Dim Yadj As Single

        'outcome 1 label
        If p1 <> 0 Then
            tmpAngle = StartAngle1 + SweepAngle1 / 2
            xLabel = xCenter + Radius * Math.Cos(DegToRad * tmpAngle)
            yLabel = yCenter + Radius * Math.Sin(DegToRad * tmpAngle)
            If Prize = 1 Then 'dollars
                tmpAmount = Settings.FormatCurrency(a1)
            ElseIf Prize = 2 Then 'points
                tmpAmount = " " & FormatNumber(a1) & " points"
            End If
            'tmpAmount = a1.ToString("C")
            tmpStringSize = myGraphics.MeasureString(tmpAmount, DisplayFont)
            'Xadj = (1 - (xLabel - LabelPadding) / diameter) * tmpStringSize.Width
            'Yadj = (1 - (yLabel - LabelPadding) / diameter) * tmpStringSize.Height
            Xadj = (1 - (xLabel - xCenter + Radius) / diameter) * tmpStringSize.Width
            Yadj = (1 - (yLabel - yCenter + Radius) / diameter) * tmpStringSize.Height
            myGraphics.DrawString(tmpAmount, DisplayFont, New SolidBrush(Color1), xLabel - Xadj, yLabel - Yadj)
        End If

        'outcome 2 label
        If p2 <> 0 Then
            tmpAngle = StartAngle2 + SweepAngle2 / 2
            xLabel = xCenter + Radius * Math.Cos(DegToRad * tmpAngle)
            yLabel = yCenter + Radius * Math.Sin(DegToRad * tmpAngle)
            If Prize = 1 Then 'dollars
                tmpAmount = Settings.FormatCurrency(a2)
            ElseIf Prize = 2 Then 'points
                tmpAmount = "  " & FormatNumber(a2) & " points"
            End If
            'tmpAmount = a2.ToString("C")
            tmpStringSize = myGraphics.MeasureString(tmpAmount, DisplayFont)
            Xadj = (1 - (xLabel - xCenter + Radius) / diameter) * tmpStringSize.Width
            Yadj = (1 - (yLabel - yCenter + Radius) / diameter) * tmpStringSize.Height
            myGraphics.DrawString(tmpAmount, DisplayFont, New SolidBrush(Color2), xLabel - Xadj, yLabel - Yadj)
        End If

        'outcome 3 label
        If p3 <> 0 Then
            tmpAngle = StartAngle3 + SweepAngle3 / 2
            xLabel = xCenter + Radius * Math.Cos(DegToRad * tmpAngle)
            yLabel = yCenter + Radius * Math.Sin(DegToRad * tmpAngle)
            If Prize = 1 Then 'dollars
                tmpAmount = Settings.FormatCurrency(a3)
            ElseIf Prize = 2 Then 'points
                tmpAmount = "  " & FormatNumber(a3) & " points"
            End If
            'tmpAmount = a3.ToString("C")
            tmpStringSize = myGraphics.MeasureString(tmpAmount, DisplayFont)
            Xadj = (1 - (xLabel - xCenter + Radius) / diameter) * tmpStringSize.Width
            Yadj = (1 - (yLabel - yCenter + Radius) / diameter) * tmpStringSize.Height
            myGraphics.DrawString(tmpAmount, DisplayFont, New SolidBrush(Color3), xLabel - Xadj, yLabel - Yadj)
        End If

        'outcome 4 label
        If p4 <> 0 Then
            tmpAngle = StartAngle4 + SweepAngle4 / 2
            xLabel = xCenter + Radius * Math.Cos(DegToRad * tmpAngle)
            yLabel = yCenter + Radius * Math.Sin(DegToRad * tmpAngle)
            If Prize = 1 Then 'dollars
                tmpAmount = Settings.FormatCurrency(a4)
            ElseIf Prize = 2 Then 'points
                tmpAmount = "  " & FormatNumber(a4) & " points"
            End If
            'tmpAmount = a4.ToString("C")
            tmpStringSize = myGraphics.MeasureString(tmpAmount, DisplayFont)
            Xadj = (1 - (xLabel - xCenter + Radius) / diameter) * tmpStringSize.Width
            Yadj = (1 - (yLabel - yCenter + Radius) / diameter) * tmpStringSize.Height
            myGraphics.DrawString(tmpAmount, DisplayFont, New SolidBrush(Color4), xLabel - Xadj, yLabel - Yadj)
        End If



        Return tmpBitMap

        'copy bitmap to left picturebox
        'If Side = _LEFT Then
        '    picLeftLottery.Location = New Point(gbLotteries.Width / 4 - Radius - LabelPadding, 50)
        '    picLeftLottery.Image = tmpBitMap
        'Else
        '    picRightLottery.Location = New Point(gbLotteries.Width * 3 / 4 - Radius - LabelPadding, 50)
        '    picRightLottery.Image = tmpBitMap
        'End If

    End Function


    Public Sub SetColors(ByVal c1 As System.Drawing.Color, ByVal c2 As System.Drawing.Color, ByVal c3 As System.Drawing.Color, ByVal c4 As System.Drawing.Color) Implements RiskControlInterface.SetColors
        Color1 = c1
        Color2 = c2
        Color3 = c3
        Color4 = c4
    End Sub


    Private Function FormatNumber(ByVal n As Single) As String
        Dim result As String
        If n = CType(n, Integer) Then
            result = n.ToString
        Else
            result = n.ToString("#.00")
        End If
        Return result
    End Function


    Public Sub DisplayLotteries() Implements RiskControlInterface.DisplayLotteries

        With lblLoutcome1
            If P.Lp1 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color1
                '.Text = "Chance of winning $" + FormatNumber(P.La1) + " is " + CStr(P.Lp1) + "%"

                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.La1)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.La1) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Lp1) + "%"
            End If
        End With
        With lblLoutcome2
            If P.Lp2 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color2
                '.Text = "Chance of winning $" + FormatNumber(P.La2) + " is " + CStr(P.Lp2) + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.La2)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.La2) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Lp2) + "%"

            End If
        End With
        With lblLoutcome3
            If P.Lp3 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color3
                '.Text = "Chance of winning $" + FormatNumber(P.La3) + " is " + CStr(P.Lp3) + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.La3)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.La3) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Lp3) + "%"

            End If
        End With
        With lblLoutcome4
            If P.Lp4 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color4
                '.Text = "Chance of winning $" + FormatNumber(P.La4) + " is " + CStr(P.Lp4) + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.La4)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.La4) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Lp4) + "%"

            End If
        End With


        With lblRoutcome1
            If P.Rp1 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color1
                '.Text = "Chance of winning $" + FormatNumber(P.Ra1) + " is " + P.Rp1.ToString + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.Ra1)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.Ra1) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Rp1) + "%"
            End If
        End With
        With lblRoutcome2
            If P.Rp2 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color2
                '.Text = "Chance of winning $" + FormatNumber(P.Ra2) + " is " + P.Rp2.ToString + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.Ra2)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.Ra2) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Rp2) + "%"

            End If
        End With
        With lblRoutcome3
            If P.Rp3 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color3
                '.Text = "Chance of winning $" + FormatNumber(P.Ra3) + " is " + P.Rp3.ToString + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.Ra3)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.Ra3) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Rp3) + "%"

            End If
        End With
        With lblRoutcome4
            If P.Rp4 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color4
                '.Text = "Chance of winning $" + FormatNumber(P.Ra4) + " is " + P.Rp4.ToString + "%"
                .Text = "Chance of winning "
                If Prize = 1 Then
                    .Text = .Text & Settings.FormatCurrency(P.Ra4)
                ElseIf Prize = 2 Then
                    .Text = .Text & FormatNumber(P.Ra4) & " points"
                End If
                .Text = .Text & " is " + CStr(P.Rp4) + "%"

            End If
        End With

        'display selection buttons
        With btnLeftSelect
            .Enabled = True
            .Visible = True
        End With

        With btnRightSelect
            .Enabled = True
            .Visible = True
        End With



        If ShowDiceInfo = True Then
            If P.Lp1 > 0 Then lblLoutcome1.Text = lblLoutcome1.Text & " (" & P.RollPrefix & "1 to " & (Math.Round((P.Lp1) / 100 * P.NumEvents, 0)).ToString & ")"
            If P.Lp2 > 0 Then lblLoutcome2.Text = lblLoutcome2.Text & " (" & P.RollPrefix & (Math.Round((P.Lp1 + 1.01) / 100 * P.NumEvents, 0)).ToString & " to " & (Math.Round((P.Lp1 + P.Lp2) / 100 * P.NumEvents, 0)).ToString & ")"
            If P.Lp3 > 0 Then lblLoutcome3.Text = lblLoutcome3.Text & " (" & P.RollPrefix & (Math.Round((P.Lp1 + P.Lp2 + 1.01) / 100 * P.NumEvents, 0)).ToString & " to " & (Math.Round((P.Lp1 + P.Lp2 + P.Lp3) / 100 * P.NumEvents, 0)).ToString & ")"
            If P.Lp4 > 0 Then lblLoutcome4.Text = lblLoutcome4.Text & " (" & P.RollPrefix & (Math.Round((P.Lp1 + P.Lp2 + P.Lp3 + 1.01) / 100 * P.NumEvents, 0)).ToString & " to " & (Math.Round((P.Lp1 + P.Lp2 + P.Lp3 + P.Lp4) / 100 * P.NumEvents, 0)).ToString & ")"

            If P.Rp1 > 0 Then lblRoutcome1.Text = lblRoutcome1.Text & " (" & P.RollPrefix & "1 to " & P.Rp1.ToString & ")"
            If P.Rp2 > 0 Then lblRoutcome2.Text = lblRoutcome2.Text & " (" & P.RollPrefix & (P.Rp1 + 1).ToString & " to " & (P.Rp1 + P.Rp2).ToString & ")"
            If P.Rp3 > 0 Then lblRoutcome3.Text = lblRoutcome3.Text & " (" & P.RollPrefix & (P.Rp1 + P.Rp2 + 1).ToString & " to " & (P.Rp1 + P.Rp2 + P.Rp3).ToString & ")"
            If P.Rp4 > 0 Then lblRoutcome4.Text = lblRoutcome4.Text & " (" & P.RollPrefix & (P.Rp1 + P.Rp2 + P.Rp3 + 1).ToString & " to " & (P.Rp1 + P.Rp2 + P.Rp3 + P.Rp4).ToString & ")"
        End If






    End Sub

    Private Sub btnLeftSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftSelect.Click
        If HideConfirmButtons = True Then
            Decision = 0
            RaiseEvent DecisionMade(Me, 0)  '0 for left, 1 for right
        Else
            btnLeftSelect.Enabled = False
            btnRightSelect.Enabled = False
            btnLeftConfirm.Visible = True
            btnLeftCancel.Visible = True
        End If


        'think about doing something to visually highlight the selected loterry and/or deemphasize the unselected lottery
        MyGroupBoxLeft.ShowBorder = True
        MyGroupBoxRight.ShowBorder = False
    End Sub

    Private Sub btnRightSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightSelect.Click
        If HideConfirmButtons = True Then
            Decision = 1
            RaiseEvent DecisionMade(Me, 1) '0 for left, 1 for right
        Else
            btnLeftSelect.Enabled = False
            btnRightSelect.Enabled = False
            btnRightConfirm.Visible = True
            btnRightCancel.Visible = True
        End If

        'think about doing something to visually highlight the selected loterry and/or deemphasize the unselected lottery
        MyGroupBoxLeft.ShowBorder = False
        MyGroupBoxRight.ShowBorder = True
    End Sub

    Private Sub btnLeftCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftCancel.Click
        Decision = -999
        btnLeftConfirm.Visible = False
        btnLeftCancel.Visible = False
        btnLeftSelect.Enabled = True
        btnRightSelect.Enabled = True

        MyGroupBoxLeft.ShowBorder = False
    End Sub

    Private Sub btnRightCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightCancel.Click
        Decision = -999
        btnRightConfirm.Visible = False
        btnRightCancel.Visible = False
        btnLeftSelect.Enabled = True
        btnRightSelect.Enabled = True

        MyGroupBoxRight.ShowBorder = False
    End Sub

    Private Sub btnLeftConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftConfirm.Click
        Decision = 0
        RaiseEvent DecisionMade(Me, 0)  '0 for left, 1 for right
    End Sub



    Private Sub btnRightConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightConfirm.Click
        Decision = 1
        RaiseEvent DecisionMade(Me, 1) '0 for left, 1 for right
    End Sub





    Public Event DecisionMade(ByVal sender As RiskControlInterface, ByVal Decision As Single) Implements RiskControlInterface.DecisionMade

    Public Function GetDecision() As Single Implements RiskControlInterface.GetDecision
        Return Decision
    End Function

    Private Sub MyGroupBoxLeft_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyGroupBoxLeft.Enter

    End Sub

    Public Sub SetDecision(ByVal d As Single) Implements RiskControlInterface.SetDecision
        btnLeftSelect.Visible = False
        btnRightSelect.Visible = False
        btnLeftConfirm.Visible = False
        btnRightConfirm.Visible = False
        btnLeftCancel.Visible = False
        btnRightCancel.Visible = False
        Dim beginRoll As String
        Dim endRoll As String
        Dim curLabel As Label

        If P.Lp1 > 0 Then
            beginRoll = "1"
            endRoll = (Math.Round((P.Lp1) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblLoutcome1

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Lp2 > 0 Then
            beginRoll = (Math.Round((P.Lp1) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Lp1 + P.Lp2) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblLoutcome2

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Lp3 > 0 Then
            beginRoll = (Math.Round((P.Lp1 + P.Lp2) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Lp1 + P.Lp2 + P.Lp3) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblLoutcome3

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Lp4 > 0 Then
            beginRoll = (Math.Round((P.Lp1 + P.Lp2 + P.Lp3) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Lp1 + P.Lp2 + P.Lp3 + P.Lp4) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblLoutcome4

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If


        If P.Rp1 > 0 Then
            beginRoll = "1"
            endRoll = (Math.Round((P.Rp1) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblRoutcome1

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Rp2 > 0 Then
            beginRoll = (Math.Round((P.Rp1) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Rp1 + P.Rp2) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblRoutcome2

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Rp3 > 0 Then
            beginRoll = (Math.Round((P.Rp1 + P.Rp2) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Rp1 + P.Rp2 + P.Rp3) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblRoutcome3

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If
        If P.Rp4 > 0 Then
            beginRoll = (Math.Round((P.Rp1 + P.Rp2 + P.Rp3) / 100 * P.NumEvents, 0) + 1).ToString
            endRoll = (Math.Round((P.Rp1 + P.Rp2 + P.Rp3 + P.Rp4) / 100 * P.NumEvents, 0)).ToString
            curLabel = lblRoutcome4

            If beginRoll = endRoll Then
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & ")"
            Else
                curLabel.Text = curLabel.Text & " (" & P.RollPrefix & beginRoll & " to " & endRoll & ")"
            End If

        End If


        If d = 0 Then
            MyGroupBoxLeft.ShowBorder = True
        ElseIf d = 1 Then
            MyGroupBoxRight.ShowBorder = True
        End If

    End Sub

    Public Sub HideConfirm() Implements RiskControlInterface.HideConfirm
        HideConfirmButtons = True
        Me.TableLayoutPanel1.RowStyles.Item(2).Height = 0
        Me.TableLayoutPanel1.RowStyles.Item(1).Height = 10
        Me.TableLayoutPanel1.RowStyles.Item(0).Height = 90
        '.get(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.0!))
    End Sub


    Private Sub TableLayoutPanel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel5.Paint

    End Sub

    Private Sub TableLayoutPanel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel4.Paint

    End Sub

    Private Sub MyGroupBoxRight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyGroupBoxRight.Enter

    End Sub



    Public Sub SetPrize(ByVal p As Integer) Implements RiskControlInterface.SetPrize
        Prize = p
    End Sub

    Private Sub lblLeftTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeftTitle.Click

    End Sub

    Public Sub SetShowDiceInfo(ByVal b As Boolean) Implements RiskControlInterface.SetShowDiceInfo
        ShowDiceInfo = b
    End Sub
End Class
