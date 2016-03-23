Public Class MyCustomMessageBox
    Private index As Integer = -1

    Const RISK As Integer = 1
    Const DISCOUNTING As Integer = 2
    Const BELIEF As Integer = 3
    Const QUESTIONNAIRE As Integer = 4
    Const MPL As Integer = 5

    'Dim NumCompletedPeriods As Integer

    Dim details As PeriodSequenceDetails

    Public Function ShowAsMessageBox(ByVal d As PeriodSequenceDetails, ByVal f As Font) As Integer

        details = d

        Dim CompletedRisk As Integer = 0
        Dim CompletedDiscounting As Integer = 0
        Dim CompletedBelief As Integer = 0
        Dim CompletedMPL As Integer = 0
        Dim NumCompletedPeriods As Integer = details.CurrentPeriod - 1
        Dim CompletedPeriodType(NumCompletedPeriods - 1) As Integer

        For i = 0 To CompletedPeriodType.Count - 1
            If i < details.Seq1Length Then
                CompletedPeriodType(i) = details.Seq1Type
            Else
                If i < details.Seq1Length + details.Seq2Length Then
                    CompletedPeriodType(i) = details.Seq2Type
                Else
                    If i < details.Seq1Length + details.Seq2Length + details.Seq3Length Then
                        CompletedPeriodType(i) = details.Seq3Type
                    Else
                        If i < details.Seq1Length + details.Seq2Length + details.Seq3Length + details.Seq4Length Then
                            CompletedPeriodType(i) = details.Seq4Type
                        Else
                            If i < details.Seq1Length + details.Seq2Length + details.Seq3Length + details.Seq4Length + details.Seq5Length Then
                                CompletedPeriodType(i) = details.Seq5Type
                            End If
                        End If
                    End If
                End If
            End If
        Next

        For i = 0 To CompletedPeriodType.Count - 1
            Select Case CompletedPeriodType(i)
                Case RISK
                    CompletedRisk = CompletedRisk + 1
                Case DISCOUNTING
                    CompletedDiscounting = CompletedDiscounting + 1
                Case BELIEF
                    CompletedBelief = CompletedBelief + 1
                Case MPL
                    CompletedMPL = CompletedMPL + 1

            End Select
        Next

        lblRisk.Text = "Risk (" & CompletedRisk.ToString & " completed)"
        lblDiscounting.Text = "Discounting (" & CompletedDiscounting.ToString & " completed)"
        lblBelief.Text = "Belief (" & CompletedBelief.ToString & " completed)"
        lblMPL.Text = "MPL (" & CompletedMPL.ToString & " completed)"

        For i = 1 To CompletedRisk
            cbRisk.Items.Add(i)
        Next
        btnPayAll.Enabled = CompletedRisk > 0
        For i = 1 To CompletedDiscounting
            cbDiscounting.Items.Add(i)
        Next

        For i = 1 To CompletedBelief
            cbBelief.Items.Add(i)
        Next

        For i = 1 To CompletedMPL
            cbMPL.Items.Add(i)
        Next


        SetFont(Me, f)

        Me.ShowDialog()
        Return index

    End Function



    Private Sub SetFont(ByRef c As Control, ByRef f As Font)
        'iterate over all controls in the top container
        Dim ctrl As Control
        For Each ctrl In c.Controls
            ctrl.Font = f
            If (ctrl.Controls.Count > 0) Then
                SetFont(ctrl, f)
            End If
        Next
        'lblLeftTitle.Font = New Font(f.Name, f.Size + 6, f.Style)
        'lblRightTItle.Font = New Font(f.Name, f.Size + 6, f.Style)

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If cbRisk.SelectedIndex > -1 Then
            index = GetGlobalPeriod(cbRisk.SelectedIndex + 1, RISK)
        End If
        If cbDiscounting.SelectedIndex > -1 Then
            index = GetGlobalPeriod(cbDiscounting.SelectedIndex + 1, DISCOUNTING)
        End If
        If cbBelief.SelectedIndex > -1 Then
            index = GetGlobalPeriod(cbBelief.SelectedIndex + 1, BELIEF)
        End If
        If cbMPL.SelectedIndex > -1 Then
            index = GetGlobalPeriod(cbMPL.SelectedIndex + 1, MPL)
        End If


        Me.Dispose()






        'lblTest.Text = index.ToString

    End Sub

    Private Function GetGlobalPeriod(ByVal p As Integer, ByVal t As Integer) As Integer
        Dim GlobalPeriod As Integer = 0
        If t = details.Seq1Type Then
            GlobalPeriod = p
        End If
        If t = details.Seq2Type Then
            GlobalPeriod = details.Seq1Length + p
        End If
        If t = details.Seq3Type Then
            GlobalPeriod = details.Seq1Length + details.Seq2Length + p
        End If
        If t = details.Seq4Type Then
            GlobalPeriod = details.Seq1Length + details.Seq2Length + details.Seq3Length + p
        End If
        If t = details.Seq5Type Then
            GlobalPeriod = details.Seq1Length + details.Seq2Length + details.Seq3Length + details.Seq4Length + p
        End If
        Return GlobalPeriod
    End Function

    Private Sub MyCustomMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set font and layout details

        lblDiscounting.Location = New Point(lblDiscounting.Location.X, lblRisk.Location.Y + lblRisk.Height + 20)
        lblBelief.Location = New Point(lblBelief.Location.X, lblDiscounting.Location.Y + lblDiscounting.Height + 20)
        lblMPL.Location = New Point(lblMPL.Location.X, lblBelief.Location.Y + lblBelief.Height + 20)
        Dim maxWidth As Integer = Math.Max(lblRisk.Width, Math.Max(lblDiscounting.Width, Math.Max(lblBelief.Width, lblMPL.Width)))
        cbRisk.Location = New Point(lblRisk.Location.X + maxWidth + 20, lblRisk.Location.Y - (cbRisk.Height - lblRisk.Height) / 2)
        cbDiscounting.Location = New Point(lblDiscounting.Location.X + maxWidth + 20, lblDiscounting.Location.Y - (cbDiscounting.Height - lblDiscounting.Height) / 2)
        cbBelief.Location = New Point(lblBelief.Location.X + maxWidth + 20, lblBelief.Location.Y - (cbBelief.Height - lblBelief.Height) / 2)
        cbMPL.Location = New Point(lblMPL.Location.X + maxWidth + 20, lblMPL.Location.Y - (cbMPL.Height - lblMPL.Height) / 2)
        btnPayAll.Location = New Point(cbRisk.Location.X + cbRisk.Width + 50, cbRisk.Location.Y)
        Me.Width = btnPayAll.Location.X + btnPayAll.Width + 20
        btnOk.Location = New Point((Me.Width - btnOk.Width) / 2, cbMPL.Location.Y + cbMPL.Height + 20)
        Me.Height = btnOk.Location.Y + btnOk.Height + 50

        'testing
        'lblTest.Visible = True
        'lblTest.Text = "lblrisk.height=" & lblRisk.Height.ToString & " lblrisk.Y=" & lblRisk.Location.Y.ToString & " cbrisk.height=" & cbRisk.Height.ToString & " cbrisk.Y=" & cbRisk.Location.Y.ToString

    End Sub




    Private Sub cbRisk_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRisk.SelectedIndexChanged, cbDiscounting.SelectedIndexChanged, cbBelief.SelectedIndexChanged, cbMPL.SelectedIndexChanged

        If sender.Equals(cbRisk) Then
            cbDiscounting.SelectedIndex = -1
            cbBelief.SelectedIndex = -1
            cbMPL.SelectedIndex = -1
        End If

        If sender.Equals(cbDiscounting) Then
            cbRisk.SelectedIndex = -1
            cbBelief.SelectedIndex = -1
            cbMPL.SelectedIndex = -1
        End If

        If sender.Equals(cbBelief) Then
            cbRisk.SelectedIndex = -1
            cbDiscounting.SelectedIndex = -1
            cbMPL.SelectedIndex = -1
        End If

        If sender.Equals(cbMPL) Then
            cbRisk.SelectedIndex = -1
            cbDiscounting.SelectedIndex = -1
            cbBelief.SelectedIndex = -1
        End If

        If cbRisk.SelectedIndex > -1 Or cbDiscounting.SelectedIndex > -1 Or cbBelief.SelectedIndex > -1 Or cbMPL.SelectedIndex > -1 Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If

    End Sub

    Private Sub btnPayAll_Click(sender As System.Object, e As System.EventArgs) Handles btnPayAll.Click

        index = -1

        Me.Dispose()
    End Sub
End Class