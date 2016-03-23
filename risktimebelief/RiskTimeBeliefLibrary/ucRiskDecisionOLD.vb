Public Class ucRiskDecision
    Implements RiskControlInterface


    Dim Decision As Single = -999
    Dim DisplayFont As Font
    Dim Color1
    Dim Color2
    Dim Color3
    Dim Color4

    Dim P As RiskParameters

    Public Sub CancelChoices() Implements RiskControlInterface.CancelChoices

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
        lblLeftTitle.Font = New Font(f.Name, f.Size + 6, f.Style)
        lblRightTItle.Font = New Font(f.Name, f.Size + 6, f.Style)

    End Sub

    Public Sub SetVisible(ByVal b As Boolean) Implements RiskControlInterface.SetVisible

    End Sub

    Public Function ValidateDecision() As Boolean Implements RiskControlInterface.ValidateDecision

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


        Dim tmpAmount As String
        Dim tmpStringSize As SizeF
        Dim tmpAngle As Single
        Dim Xadj As Single
        Dim Yadj As Single

        'outcome 1 label
        If p1 <> 0 Then
            tmpAngle = StartAngle1 + SweepAngle1 / 2
            xLabel = xCenter + Radius * Math.Cos(DegToRad * tmpAngle)
            yLabel = yCenter + Radius * Math.Sin(DegToRad * tmpAngle)
            tmpAmount = "$" + CStr(a1)
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
            tmpAmount = "$" + CStr(a2)
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
            tmpAmount = "$" + CStr(a3)
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
            tmpAmount = "$" + CStr(a4)
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

    Public Sub DisplayLotteries() Implements RiskControlInterface.DisplayLotteries

        With lblLoutcome1
            If P.Lp1 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color1
                .Text = "Chance of winning $" + CStr(P.La1) + " is " + CStr(P.Lp1) + "%"
            End If
        End With
        With lblLoutcome2
            If P.Lp2 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color2
                .Text = "Chance of winning $" + CStr(P.La2) + " is " + CStr(P.Lp2) + "%"
            End If
        End With
        With lblLoutcome3
            If P.Lp3 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color3
                .Text = "Chance of winning $" + CStr(P.La3) + " is " + CStr(P.Lp3) + "%"
            End If
        End With
        With lblLoutcome4
            If P.Lp4 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color4
                .Text = "Chance of winning $" + CStr(P.La4) + " is " + CStr(P.Lp4) + "%"
            End If
        End With


        With lblRoutcome1
            If P.Rp1 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color1
                .Text = "Chance of winning $" + CStr(P.Ra1) + " is " + P.Rp1.ToString + "%"
            End If
        End With
        With lblRoutcome2
            If P.Rp2 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color2
                .Text = "Chance of winning $" + CStr(P.Ra2) + " is " + P.Rp2.ToString + "%"
            End If
        End With
        With lblRoutcome3
            If P.Rp3 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color3
                .Text = "Chance of winning $" + CStr(P.Ra3) + " is " + P.Rp3.ToString + "%"
            End If
        End With
        With lblRoutcome4
            If P.Rp4 = 0 Then
                .Text = ""
            Else
                .ForeColor = Color4
                .Text = "Chance of winning $" + CStr(P.Ra4) + " is " + P.Rp4.ToString + "%"
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


    End Sub

    Private Sub btnLeftSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftSelect.Click
        btnLeftSelect.Enabled = False
        btnRightSelect.Enabled = False
        btnLeftConfirm.Visible = True
        btnLeftCancel.Visible = True

        'think about doing something to visually highlight the selected loterry and/or deemphasize the unselected lottery
        MyGroupBoxLeft.ShowBorder = True
    End Sub

    Private Sub btnRightSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightSelect.Click
        btnLeftSelect.Enabled = False
        btnRightSelect.Enabled = False
        btnRightConfirm.Visible = True
        btnRightCancel.Visible = True

        'think about doing something to visually highlight the selected loterry and/or deemphasize the unselected lottery
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

        If d = 0 Then
            If P.Lp1 > 0 Then lblLoutcome1.Text = lblLoutcome1.Text & " (roll 1 to " & P.Lp1.ToString & ")"
            If P.Lp2 > 0 Then lblLoutcome2.Text = lblLoutcome2.Text & " (roll " & (P.Lp1 + 1).ToString & " to " & (P.Lp1 + P.Lp2).ToString & ")"
            If P.Lp3 > 0 Then lblLoutcome3.Text = lblLoutcome3.Text & " (roll " & (P.Lp1 + P.Lp2 + 1).ToString & " to " & (P.Lp1 + P.Lp2 + P.Lp3).ToString & ")"
            If P.Lp4 > 0 Then lblLoutcome4.Text = lblLoutcome4.Text & " (roll " & (P.Lp1 + P.Lp2 + P.Lp3 + 1).ToString & " to " & (P.Lp1 + P.Lp2 + P.Lp3 + P.Lp4).ToString & ")"
            MyGroupBoxLeft.ShowBorder = True
        End If

        If d = 1 Then
            If P.Rp1 > 0 Then lblRoutcome1.Text = lblRoutcome1.Text & " (roll 1 to " & P.Rp1.ToString & ")"
            If P.Rp2 > 0 Then lblRoutcome2.Text = lblRoutcome2.Text & " (roll " & (P.Rp1 + 1).ToString & " to " & (P.Rp1 + P.Rp2).ToString & ")"
            If P.Rp3 > 0 Then lblRoutcome3.Text = lblRoutcome3.Text & " (roll " & (P.Rp1 + P.Rp2 + 1).ToString & " to " & (P.Rp1 + P.Rp2 + P.Rp3).ToString & ")"
            If P.Rp4 > 0 Then lblRoutcome4.Text = lblRoutcome4.Text & " (roll " & (P.Rp1 + P.Rp2 + P.Rp3 + 1).ToString & " to " & (P.Rp1 + P.Rp2 + P.Rp3 + P.Rp4).ToString & ")"
            MyGroupBoxRight.ShowBorder = True
        End If

    End Sub

    Private Sub TableLayoutPanel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub lblLoutcome4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MyGroupBoxRight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
