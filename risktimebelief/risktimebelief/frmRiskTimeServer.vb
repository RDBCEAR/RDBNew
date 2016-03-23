Imports RiskTimeBeliefLibrary
'Imports ExCEN_MQ
Imports Pabo.Calendar
Imports System.IO
Imports System.Globalization
Imports System.Threading

Public Class frmRiskTimeServer

    'Dim ID As String
    Dim SubjectID As String
    Dim MachineName As String
    Dim StartTime As String
    Private Subjects As New ArrayList
    Private SubjectMap As New Hashtable

    Private NoOfSub As Integer
    Private NoOfPeriod As Integer

    Dim MaxMonths As Integer = 3 'controls number of months displayed (0 based array)
    Dim DisplayFont As Font

    'Public DiscountingSoonerColor As Color
    'Public DiscountingLaterColor As Color
    'Dim RiskColor1 As Color
    'Dim RiskColor2 As Color
    'Dim RiskColor3 As Color
    'Dim RiskColor4 As Color

    Dim ParamsFile As String = ""

    Dim Center As Single

    Dim SoonerDate As DateTime
    Dim LaterDate As DateTime
    Dim SoonerDateB As DateTime
    Dim LaterDateB As DateTime
    Dim SoonerDateC As DateTime
    Dim LaterDateC As DateTime

    Dim cmCalendar(4) As Pabo.Calendar.MonthCalendar
    Dim List() As UserControl
    Dim InterfaceList() As DiscountingControlInterface
    Dim MPLlist() As UserControl
    Dim MPLinterfaceList() As AMPLControlInterface

    'constants used to define type of discounting elicitation
    Const BINARY As Integer = 1
    Const PORTFOLIO As Integer = 2
    Const OPEN As Integer = 3
    Const BUNDLING_K1_FREE_RANGE = 21
    Const BUNDLING_K1_FORCE_FED = 22
    Const BUNDLING_K2_FREE_RANGE = 31
    Const BUNDLING_K2_FORCE_FED = 32




    'Dim DiscountingChoiceItemWidth As Integer = 800
    'Dim DiscountingChoiceItemHeight As Integer = 85

    Const _LEFT As Integer = 1
    Const _RIGHT As Integer = 2

    Dim WithEvents RiskChoice As UserControl
    Dim WithEvents RiskInterface As RiskControlInterface
    Dim WithEvents risk2SimulInterface As ciRisk_2simul
    Dim RiskChoiceItemWidth As Integer = 990
    Dim RiskChoiceItemHeight As Integer = 735


    Dim WithEvents BeliefChoice As UserControl
    Dim WithEvents BeliefInterface As BeliefControlInterface
    Dim BeliefChoiceItemWidth As Integer = 990
    Dim BeliefChoiceItemHeight As Integer = 735
    'Dim BeliefChoiceItemHeight As Integer = 650

    Dim WithEvents Survey As UserControl
    Dim WithEvents SurveyInterface As WebSurveyControlInterface

    Dim Settings As Settings
    Dim Rquestions As ArrayList
    Dim DquestionsArray As ArrayList = New ArrayList
    Dim Bquestions As ArrayList
    'Dim WebSurvey As WebSurveyParameters
    Dim AMPLquestionsarray As ArrayList = New ArrayList

    Dim CurrentPeriod As Integer
    Dim LastPeriod As Integer
    Dim Periods() As Period

    Const RISK As Integer = 1
    Const DISCOUNTING As Integer = 2
    Const BELIEF As Integer = 3
    Const QUESTIONNAIRE As Integer = 4
    Const AMPL As Integer = 5

    Const BELIEF_10 As Integer = 10
    Const BELIEF_2 As Integer = 2

    Dim ResultsFile As String

    Dim Stage As Integer = 0 'this is used for pausing subject progress between different task stages 
    Dim Paused As Boolean = False  'this is used for controlling whether history window will appear
    Dim SessionOver As Boolean = False

    Dim PerSeqDetails As New PeriodSequenceDetails

    Dim rbDice() As RadioButton

    Dim ReviewType As Integer = -1

    Dim BeliefPresets As ArrayList
    Dim CurrentBeliefPreset1, CurrentBeliefPreset2, CurrentBeliefPreset3, CurrentBeliefPreset4, CurrentBeliefPreset5 As BeliefPreset


    Dim ResultsFileExists = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        StartTime = Now.ToString("yyyy-MM-dd HHmmss")
        MachineName = System.Net.Dns.GetHostName.ToString

        SubjectID = MachineName & "_" & StartTime

        txtInstructions.AppendText("Current steps for running this software:")

        txtInstructions.AppendText(vbCrLf & "1. Load an input file with the 'Open file' button;")
        txtInstructions.AppendText(vbCrLf & "2. Switch to the 'Subject display' tab and click the 'Test Periods' button;")

        'DisplayFont = New Font("comic Sans MS", 14, FontStyle.Regular)

        'lblFont.Font = DisplayFont

        'With TabControl1
        '    .Width = 1575
        '    .Height = 900
        'End With

        'Center = TabControl1.Width / 2

        tabSettings.BackColor = Me.BackColor
        tabInputFile.BackColor = Me.BackColor
        tabSubjectDisplay.BackColor = Me.BackColor

        'rbBinary.Checked = True

        'tbDiameter.Text = CStr(200)

        'TEMP -- remove late

        With dgvPeriods
            .Columns.Add("c1", "Order")
            .Columns.Add("c2", "Treatment")
            .Columns.Add("c3", "# Periods")
            .Rows.Add(New String() {"1", Nothing, Nothing})
            .Rows.Add(New String() {"2", Nothing, Nothing})
            .Rows.Add(New String() {"3", Nothing, Nothing})
            .Rows.Add(New String() {"4", Nothing, Nothing})
            'For i As Integer = 0 To 3
            '    .Rows(i).HeaderCell.Value = (i + 1).ToString
            'Next

            'PeriodsDataTable = GetTable()
            '.DataSource = PeriodsDataTable
            .AllowDrop = False
            .RowHeadersVisible = False
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnEnter
            .MultiSelect = False
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            'note: because container is invisible, the above line does not at the moment resize columns and thus the following lines have no effect
            '.Width = .Columns(0).Width + .Columns(1).Width + .Columns(2).Width + 2
            '.Height = .ColumnHeadersHeight + .Rows(0).Height + .Rows(1).Height + .Rows(2).Height + .Rows(3).Height + 3
        End With


        lblCurrentPeriod.Text = ""

        'temporary stuff to hardwire automatic display of subject choices

        'ParamsFile = Application.StartupPath & "\TestInputFile.txt"
        'ReadFile()


        lblCurrentPeriod.Font = DisplayFont

        'PasswordManager.CreatePasswordFile(New String() {"1", "2", "3"}, Application.StartupPath & "\" & "pw.txt")
        'PasswordManager.CreateAnswerFile("x", Application.StartupPath & "\" & "answer.txt")



        TabControl1.Location = New Point(0, -25)
        TabControl1.Height = TabControl1.Height + 25
        'TabControl1.Height = 925
        TabControl1.TabPages.RemoveAt(0)
        TabControl1.TabPages.RemoveAt(0)


        'parse the command line arguments
        Dim argc As Integer = My.Application.CommandLineArgs.Count
        Dim argv As String() = My.Application.CommandLineArgs.ToArray
        Dim LocalFile As String = "TestInputFile.txt"
        If argc > 0 Then
            For i As Integer = 0 To argc - 1
                If argv(i) = "-f" Then
                    Try
                        LocalFile = argv(i + 1)
                    Catch ex As Exception
                        MsgBox("Incorrect command line specification." & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.StackTrace, vbCritical)
                        Application.Exit()
                    End Try
                End If
                If argv(i) = "-i" Then
                    Try
                        SubjectID = argv(i + 1)
                    Catch ex As Exception
                        MsgBox("Incorrect command line specification." & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.StackTrace, vbCritical)
                        Application.Exit()
                    End Try
                End If
            Next
        End If
        ParamsFile = Application.StartupPath & "\" & LocalFile
        Try
            ReadFile()
        Catch ex As Exception
            MsgBox("Bad file name." & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.StackTrace, vbCritical)
            Application.Exit()
        End Try

        lblTitle.Font = DisplayFont

        lblCurrentPeriod.Font = DisplayFont

        btnStartPeriods_Click(Nothing, Nothing)



    End Sub

    Private Sub dgvPeriods_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvPeriods.ColumnWidthChanged
        With dgvPeriods
            .Width = .Columns(0).Width + .Columns(1).Width + .Columns(2).Width + 3
            .Height = .ColumnHeadersHeight + .Rows(0).Height + .Rows(1).Height + .Rows(2).Height + .Rows(3).Height + 2
        End With
        btnPeriodsUp.Location = New Point(dgvPeriods.Location.X + dgvPeriods.Width + 10, dgvPeriods.Location.Y)
        btnPeriodsDown.Location = New Point(dgvPeriods.Location.X + dgvPeriods.Width + 10, dgvPeriods.Location.Y + dgvPeriods.Height - btnPeriodsDown.Height)
    End Sub

    'Private Sub btnStartAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartAccept.Click

    '    NoOfSub = Integer.Parse(txtNoOfSub.Text)
    '    NoOfPeriod = Integer.Parse(txtNoOfPeriod.Text)
    '    For s As Integer = 1 To NoOfSub
    '        'Period.getRandomParameterPeriod(NoOfPeriod)
    '        'Subjects.Add(New Subject(Period.getRandomParameterPeriod(NoOfPeriod), Constants.TREAMENT1))
    '    Next
    '    Dim ex As Exception = Me.MQmonitor1.OpenQueues()
    '    If (ex Is Nothing) Then

    '        btnStartAccept.Enabled = False
    '        txtNoOfSub.Enabled = False
    '        Me.RichTextBox1.AppendText("Server started" + Environment.NewLine)
    '    Else
    '        Me.RichTextBox1.AppendText("Server cannot start: " + ex.Message + Environment.NewLine)
    '    End If
    'End Sub



    'Private Sub MQmonitor1_NewSubjectConnected(ByVal Subject As Integer, ByVal UserName As String) Handles MQmonitor1.NewSubjectConnected
    '    'This portion of code may look usual to you
    '    'All .net GUI or Control run on its on thread. If other thread manipulating the state of a control, 
    '    'it is possible to force the control into an inconsistent state.
    '    'Our socket runs on seperate thread, which could cause this problem.
    '    '
    '    'So what we need to do is to delegate all NewSubjectConnected Event to GUI thread to handle this event.
    '    'It is quite simple.  First create a Sub with the same signature as this one without Handles keyword
    '    'Then, call this two  lines.

    '    Dim d As New ExCEN_MQ.MQmonitor.NewSubjectConnectedCallBack(AddressOf NewSubjectConnectedCallBackHandler)

    '    Me.Invoke(d, Subject, UserName)
    'End Sub
    'Private Sub NewSubjectConnectedCallBackHandler(ByVal SubjectID As Integer, ByVal UserName As String)
    '    If (Not SubjectMap.ContainsKey(SubjectID)) Then
    '        'Period.getRandomParameterPeriod(NoOfPeriod)
    '        SubjectMap.Add(SubjectID, Subjects.Item(SubjectMap.Count))
    '    End If
    '    Me.RichTextBox1.AppendText("User " + UserName + " connected with ID: " + SubjectID.ToString + Environment.NewLine)
    '    'Dim msg As New MQMessage

    '    'MQmonitor1.SendMessage(msg, SubjectID)
    '    If (SubjectMap.Count = NoOfSub) Then
    '        Me.btnStartSession.Enabled = True
    '    End If
    'End Sub
    'Private Sub btnStartSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartSession.Click
    '    Dim msg As MQMessage
    '    btnStartSession.Enabled = False
    '    For Each i As Integer In SubjectMap.Keys
    '        msg = New MQMessage
    '        msg.Type = Constants.MESSAGE_TYPE_PARAMETER
    '        msg.Data = SubjectMap.Item(i)
    '        MQmonitor1.SendMessage(msg, i)
    '    Next
    'End Sub
    'Private Sub MQmonitor1_MessageArrived(ByVal Subject As Integer, ByVal message As ExCEN_MQ.MQMessage)
    '    'This portion of code may look usual to you
    '    'All .net GUI or Control run on its on thread. If other thread manipulating the state of a control, 
    '    'it is possible to force the control into an inconsistent state.
    '    'Our socket runs on seperate thread, which could cause this problem.
    '    '
    '    'So what we need to do is to delegate all MessageArrived Event to GUI thread to handle this event.
    '    'It is quite simple.  First create a Sub with the same signature as this one without Handles keyword
    '    'Then, call this two  lines.

    '    Dim d As New ExCEN_MQ.MQmonitor.MessageArrivedCallBack(AddressOf MessageArrivedCallBackHandler)
    '    Me.Invoke(d, Subject, message)

    'End Sub
    'Private Sub MessageArrivedCallBackHandler(ByVal SubjectID As Integer, ByVal message As ExCEN_MQ.MQMessage)
    '    Dim mySub As Subject = SubjectMap.Item(SubjectID)
    '    Dim periodNumber As Integer = Integer.Parse(message.Text)
    '    mySub.Periods(periodNumber - 1).Decision = message.Data
    '    mySub.Periods(periodNumber - 1).isDecisionMade = True
    '    Me.RichTextBox1.AppendText("Subject (" + SubjectID.ToString + ") submited period #" + periodNumber.ToString + " decision (" + message.Data.ToString + ")" + Environment.NewLine)
    'End Sub
    'Private Sub MQmonitor1_Socket_Error(ByVal e As System.Exception)
    '    MsgBox("Socket Error")
    'End Sub


    Public Sub CheckMPLChoices(ByVal sender As AMPLControlInterface, ByVal decision As Single)
        'on each choice selection, this routine checks to see if all selections are made, and enables confirm button if true
        'Note this sub needs to be public so the buttons in the user control can call it

        'create a routine here for bundled force-fed treatments that appropriately auto selects linked choices

        'Dim offset As Integer

        'If Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
        '    If sender.GetIndex < List.Count / 2 Then offset = List.Count / 2 Else offset = -List.Count / 2
        '    CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        'End If

        'If Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
        '    offset = List.Count / 3
        '    If sender.GetIndex < List.Count / 3 Then
        '        CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '        CType(List(sender.GetIndex + 2 * offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '    ElseIf sender.GetIndex < List.Count * 2 / 3 Then
        '        CType(List(sender.GetIndex - offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '        CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '    Else
        '        CType(List(sender.GetIndex - 2 * offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '        CType(List(sender.GetIndex - offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        '    End If
        'End If





        Dim AllValid As Boolean = True
        Dim AllBlank As Boolean = True

        For Each L As AMPLControlInterface In MPLlist
            If L.ValidateDecision = False Then
                AllValid = False
            End If
            If L.IsBlank = False Then
                AllBlank = False
            End If
        Next

        If AllValid = True Then
            lblConfirm.Visible = False
            btnConfirm.Enabled = True
        Else
            lblConfirm.Visible = True
            btnConfirm.Enabled = False
        End If
        btnCancel.Enabled = True
        If AllBlank = True Then
            btnCancel.Enabled = False
        Else
            btnCancel.Enabled = True
        End If
    End Sub

















    Public Sub CheckDiscountingChoices(ByVal sender As DiscountingControlInterface, ByVal Decision As Single)
        'on each choice selection, this routine checks to see if all selections are made, and enables confirm button if true
        'Note this sub needs to be public so the buttons in the user control can call it

        'create a routine here for bundled force-fed treatments that appropriately auto selects linked choices

        Dim offset As Integer
        If Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
            If sender.GetIndex < List.Count / 2 Then offset = List.Count / 2 Else offset = -List.Count / 2
            CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
        End If
        If Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
            offset = List.Count / 3
            If sender.GetIndex < List.Count / 3 Then
                CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
                CType(List(sender.GetIndex + 2 * offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
            ElseIf sender.GetIndex < List.Count * 2 / 3 Then
                CType(List(sender.GetIndex - offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
                CType(List(sender.GetIndex + offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
            Else
                CType(List(sender.GetIndex - 2 * offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)
                CType(List(sender.GetIndex - offset), DiscountingControlInterface).PerformChoice(CType(List(sender.GetIndex), DiscountingControlInterface).GetDecision)

            End If
        End If





        Dim AllValid As Boolean = True
        Dim AllBlank As Boolean = True

        For Each L As DiscountingControlInterface In List
            If L.ValidateDecision = False Then
                AllValid = False
            End If
            If L.IsBlank = False Then
                AllBlank = False
            End If
        Next

        If AllValid = True Then
            lblConfirm.Visible = False
            btnConfirm.Enabled = True
        Else
            lblConfirm.Visible = True
            btnConfirm.Enabled = False
        End If

        If AllBlank = True Then
            btnCancel.Enabled = False
        Else
            btnCancel.Enabled = True
        End If
    End Sub


    Private Sub CancelChoices()
        'this routine is used in two places: whenever the screen is redrawn, and whenever the cancel button is used

        If List(0) IsNot Nothing Then
            For Each L As DiscountingControlInterface In List
                L.CancelChoices()
            Next
        End If

        If MPLlist(0) IsNot Nothing Then
            For Each L As AMPLControlInterface In MPLlist
                L.CancelChoices()
            Next
        End If


        lblConfirm.Visible = True
        btnConfirm.Enabled = False
        btnCancel.Enabled = False
    End Sub


    Private Sub WaitingScreen()
        'this routine blanks the subject interface, and waits for user to redraw a screen
        Dim i As Integer
        For i = 0 To MaxMonths
            cmCalendar(i).Visible = False
            If i < 4 Then List(i).Visible = False
        Next
        lblSoonerDate.Visible = False
        lblSoonerWeeks.Visible = False
        lblLaterDate.Visible = False
        lblLaterWeeks.Visible = False
        lblConfirm.Visible = False
        btnConfirm.Visible = False
        btnCancel.Visible = False

        'With lblWait
        '    .Font = DisplayFont
        '    .Location = New Point(Center - .Width / 2, tabSubjectDisplay.Height / 2 - .Height / 2)
        '    .Visible = True
        'End With

    End Sub



    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        With dlgFont
            .Font = DisplayFont
            .ShowDialog()
            DisplayFont = .Font
            lblFont.Font = DisplayFont
            lblFont.Text = DisplayFont.FontFamily.Name + ", size " + Math.Round(DisplayFont.Size).ToString
        End With
        btnFont.Location = New Point(lblFont.Location.X, lblFont.Location.Y + lblFont.Height)
    End Sub


    Private Sub btnSoonerColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoonerColor.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
            .ShowDialog()
            Settings.DiscountingSoonerColor = ColorTranslator.ToHtml(.Color)
            pnlColorSooner.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        End With
    End Sub
    Private Sub btnLaterColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaterColor.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
            .ShowDialog()
            Settings.DiscountingLaterColor = ColorTranslator.ToHtml(.Color)
            pnlColorLater.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        End With
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CancelChoices()
        CancelChoices()
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        EndOfPeriod()
    End Sub

    Private Sub EndOfPeriod()
        Dim i As Integer

        If Periods(CurrentPeriod - 1).Type = BELIEF Then
            Dim d() As Single = CType(BeliefChoice, BeliefControlInterface).GetDecision
            Periods(CurrentPeriod - 1).Decision.Clear()
            For i = 0 To d.Length - 1
                Periods(CurrentPeriod - 1).Decision.Add(d(i))
            Next
        Else
            For i = 0 To Periods(CurrentPeriod - 1).Decision.Count - 1
                If Periods(CurrentPeriod - 1).Type = RISK Then
                    'Kevin's Comment add handle for Risk_BAR_SINGLE and Risk_BAR_2SIMUL
                    If Settings.RiskElicitation = Constants.RISK_SINGLE Or Settings.RiskElicitation = Constants.Risk_BAR_SINGLE Then
                        Periods(CurrentPeriod - 1).Decision.Item(i) = CType(RiskChoice, RiskControlInterface).GetDecision 'i only 0
                    ElseIf Settings.RiskElicitation = Constants.RISK_2SIMUL Or Settings.RiskElicitation = Constants.Risk_BAR_2SIMUL Then
                        Periods(CurrentPeriod - 1).Decision.Item(i) = CType(risk2SimulInterface, ciRisk_2simul).GetDecision.Item(i)
                    End If
                End If
                If Periods(CurrentPeriod - 1).Type = DISCOUNTING Then Periods(CurrentPeriod - 1).Decision.Item(i) = CType(List(i), DiscountingControlInterface).GetDecision
                'If Periods(CurrentPeriod - 1).Type = BELIEF Then Periods(CurrentPeriod - 1).Decision.Item(i) = CType(BeliefChoice, BeliefControlInterface).GetDecision
                If Periods(CurrentPeriod - 1).Type = QUESTIONNAIRE Then Periods(CurrentPeriod - 1).Decision.Item(i) = True 'i only 0
                If Periods(CurrentPeriod - 1).Type = AMPL Then Periods(CurrentPeriod - 1).Decision.Item(i) = CType(MPLlist(i), AMPLControlInterface).GetDecision
            Next
        End If

        Periods(CurrentPeriod - 1).isDecisionMade = True

        'save period results
        Dim FileWriter As New System.IO.StreamWriter(ResultsFile, True)
        FileWriter.WriteLine(Periods(CurrentPeriod - 1).ToString)
        FileWriter.Close()

        'update status file
        RecordSubjectProgress()


        'for testing
        txtTest.AppendText(vbCrLf & Periods(CurrentPeriod - 1).ToString)

        'move to next period, if not end of experiment
        If CurrentPeriod = LastPeriod Then
            SessionOver = True
            CurrentPeriod = CurrentPeriod + 1
            PerSeqDetails.CurrentPeriod = CurrentPeriod 'details is external object for history box to access
            EndOfSession()
        Else
            CurrentPeriod = CurrentPeriod + 1
            PerSeqDetails.CurrentPeriod = CurrentPeriod 'details is external object for history box to access
            'routine to pause progress if subject is at end of a phase
            If Periods(CurrentPeriod - 1).Type = Periods(CurrentPeriod - 2).Type Then 'note that the first time we are here is currentperiod=2 so no -1 out of bounds
                DrawPeriod(Periods(CurrentPeriod - 1))
            Else
                Stage = Stage + 1
                PauseProgress()
            End If
        End If



    End Sub


    Private Sub PauseProgress()
        btnReview.Visible = False
        Paused = True
        lblCurrentPeriod.Text = "PAUSED (" & (CurrentPeriod - 1).ToString & " of " & LastPeriod.ToString & " choices complete)"
        ClearScreen()
        With lblPause
            .Visible = True
            .Font = DisplayFont
            .Location = New Point(Center - .Width / 2, Me.Height / 2)
        End With
        With btnPause
            .Visible = True
            .Font = DisplayFont
            .Location = New Point(Center - .Width / 2, lblPause.Location.Y + lblPause.Height + 10)
        End With
        btnPause_Click(Nothing, Nothing)
    End Sub


    Private Sub RecordSubjectProgress()

        If (Not System.IO.Directory.Exists(Application.StartupPath & "\RDB status")) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\RDB status\")
        End If

        'subject progress is currently recorded by writing an empty file to the data directory, and the name of the file denotes subject progress
        Dim OldProgressFile As String = Application.StartupPath & "\RDB status\" & "RDB status_ " & MachineName & " completed " & (CurrentPeriod - 1).ToString
        'Dim NewProgressFile As String = Application.StartupPath & "\RDB status\" & "RDB status_ " & MachineName & " completed " & CurrentPeriod.ToString
        Dim NewProgressFile As String
        If ResultsFileExists = False Then
            NewProgressFile = Application.StartupPath & "\RDB status\" & "RDB status_ " & MachineName & " completed " & CurrentPeriod.ToString
        Else
            NewProgressFile = Application.StartupPath & "\RDB status\" & "APPENDED RDB status_ " & MachineName & " completed " & CurrentPeriod.ToString
        End If

        If File.Exists(OldProgressFile) = True And File.Exists(NewProgressFile) = False Then 'never enter this on period 1, because old period file references period 0
            File.Move(OldProgressFile, NewProgressFile)
        ElseIf CurrentPeriod = 1 Then
            For Each f As String In Directory.GetFiles(Application.StartupPath & "\RDB status", "*" & "RDB status_ " & MachineName & "*")
                File.Delete(f)
            Next
            Dim fs As FileStream = File.Create(NewProgressFile)
            fs.Close()
        End If

    End Sub



    Private Sub EndOfSession()
        Paused = True
        ClearScreen()
        lblCurrentPeriod.Text = vbCrLf & "The experiment is over.  Please wait quietly for further instructions."
        Me.Focus()
    End Sub

    Private Sub rbOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOpen.CheckedChanged
        If rbOpen.Checked = True Then
            gbOpen.Visible = True
        Else
            gbOpen.Visible = False
        End If
    End Sub

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        With dlgOpenFile
            .InitialDirectory = Application.StartupPath
            .ShowDialog()
            ParamsFile = .FileName
        End With

        lblDiscountingFile.Text = ParamsFile
        ReadFile()


        For i As Integer = 1 To 4
            If Settings.OrderRiskPeriods = i Then
                dgvPeriods.Rows(i - 1).Cells(0).Value = i.ToString
                dgvPeriods.Rows(i - 1).Cells(1).Value = "Risk"
                dgvPeriods.Rows(i - 1).Cells(2).Value = Settings.NumRiskPeriods.ToString
            ElseIf Settings.OrderDiscountingPeriods = i Then
                dgvPeriods.Rows(i - 1).Cells(0).Value = i.ToString
                dgvPeriods.Rows(i - 1).Cells(1).Value = "Discounting"
                dgvPeriods.Rows(i - 1).Cells(2).Value = Settings.NumDiscountingPeriods.ToString
            ElseIf Settings.OrderBeliefPeriods = i Then
                dgvPeriods.Rows(i - 1).Cells(0).Value = i.ToString
                dgvPeriods.Rows(i - 1).Cells(1).Value = "Belief"
                dgvPeriods.Rows(i - 1).Cells(2).Value = Settings.NumBeliefPeriods.ToString
            ElseIf Settings.OrderQuestionnairePeriods = i Then
                dgvPeriods.Rows(i - 1).Cells(0).Value = i.ToString
                dgvPeriods.Rows(i - 1).Cells(1).Value = "Questionnaire"
                dgvPeriods.Rows(i - 1).Cells(2).Value = Settings.NumQuestionnairePeriods.ToString
            End If
        Next


        txtRiskPeriods.Text = Settings.NumRiskPeriods.ToString
        txtDiscountingPeriods.Text = Settings.NumDiscountingPeriods.ToString
        'cbRiskFirst.Checked = Settings.RiskPeriodsFirst

        lblFont.Font = DisplayFont
        lblFont.Text = Settings.DisplayFontFamily + ", size " + Settings.DisplayFontSize.ToString

        pnlColorSooner.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        pnlColorLater.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        pnlColor1.BackColor = ColorTranslator.FromHtml(Settings.RiskColor1)
        pnlColor2.BackColor = ColorTranslator.FromHtml(Settings.RiskColor2)
        pnlColor3.BackColor = ColorTranslator.FromHtml(Settings.RiskColor3)
        pnlColor4.BackColor = ColorTranslator.FromHtml(Settings.RiskColor4)

        Select Case Settings.DiscountingElicitation
            Case BINARY
                rbBinary.Checked = True
            Case PORTFOLIO
                rbPortfolio.Checked = True
            Case OPEN
                rbOpen.Checked = True
                If Settings.DiscountingOpenDecisionSooner = True Then
                    rbOpenSooner.Checked = True
                Else
                    rbOpenLater.Checked = True
                End If
        End Select
        cbCalendar.Checked = Settings.DiscountingShowCalendar
        tbDiameter.Text = Settings.RiskDiameter.ToString
        chkGraph.Checked = Settings.RiskShowGraphs
        chkText.Checked = Settings.RiskShowText

        gbEditFile.Visible = True
        DisplayInputFile()

    End Sub



    Private Sub DisplayInputFile()
        Dim oRead As System.IO.StreamReader
        oRead = File.OpenText(ParamsFile)
        txtInputFile.Text = oRead.ReadToEnd
        'While oRead.Peek <> -1
        '    txtInputFile.Text = txtInputFile.Text & oRead.ReadLine & vbCrLf
        'End While
        oRead.Close()
        gbInputFile.Text = ParamsFile
    End Sub


    Private Sub btnColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor1.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.RiskColor1)
            .ShowDialog()
            Settings.RiskColor1 = ColorTranslator.ToHtml(.Color)
            pnlColor1.BackColor = ColorTranslator.FromHtml(Settings.RiskColor1)
        End With
    End Sub

    Private Sub btncolor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor2.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.RiskColor2)
            .ShowDialog()
            Settings.RiskColor2 = ColorTranslator.ToHtml(.Color)
            pnlColor2.BackColor = ColorTranslator.FromHtml(Settings.RiskColor2)
        End With
    End Sub

    Private Sub btncolor3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor3.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.RiskColor3)
            .ShowDialog()
            Settings.RiskColor3 = ColorTranslator.ToHtml(.Color)
            pnlColor3.BackColor = ColorTranslator.FromHtml(Settings.RiskColor3)
        End With
    End Sub

    Private Sub btncolor4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor4.Click
        With dlgColor
            .FullOpen = True
            .Color = ColorTranslator.FromHtml(Settings.RiskColor4)
            .ShowDialog()
            Settings.RiskColor4 = ColorTranslator.ToHtml(.Color)
            pnlColor4.BackColor = ColorTranslator.FromHtml(Settings.RiskColor4)
        End With
    End Sub




    Private Sub ReadFile()
        Settings = CType(FileUtils.ReadObjectFromFile("Settings", New Settings().GetType, ParamsFile), Settings)

        'Thread.CurrentThread.CurrentCulture = Settings.CurrentCulture
        'Settings.CurrentCulture = CultureInfo.CurrentCulture
        'Else

        'Settings.CurrentCulture = CultureInfo.CreateSpecificCulture(Settings.CurrencyFormat)
        'End If

        DisplayFont = New Font(Settings.DisplayFontFamily, Settings.DisplayFontSize)
        'DiscountingSoonerColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        'DiscountingLaterColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        'RiskColor1 = ColorTranslator.FromHtml(Settings.RiskColor1)
        'RiskColor2 = ColorTranslator.FromHtml(Settings.RiskColor2)
        'RiskColor3 = ColorTranslator.FromHtml(Settings.RiskColor3)
        'RiskColor4 = ColorTranslator.FromHtml(Settings.RiskColor4)


        Rquestions = FileUtils.ReadObjectArrayFromFile("Risk", New RiskParameters().GetType, ParamsFile)
        'if probs are initially between 0 and 1, then multiply by 100
        Dim i As Integer
        For i = 0 To Rquestions.Count - 1
            Dim o As RiskParameters = Rquestions.Item(i)
            o.Lp1 = o.Lp1 * 100
            o.Lp2 = o.Lp2 * 100
            o.Lp3 = o.Lp3 * 100
            o.Lp4 = o.Lp4 * 100
            o.Rp1 = o.Rp1 * 100
            o.Rp2 = o.Rp2 * 100
            o.Rp3 = o.Rp3 * 100
            o.Rp4 = o.Rp4 * 100
        Next

        Dim Dquestions As ArrayList
        Do
            Dquestions = FileUtils.ReadObjectArrayFromFile("Discounting_" + DquestionsArray.Count.ToString, New DiscountingParameters().GetType, ParamsFile)
            If Dquestions.Count <> 0 Then
                DquestionsArray.Add(Dquestions)
            End If
        Loop Until Dquestions.Count = 0


        Dim AMPLquestions As ArrayList
        Do
            AMPLquestions = FileUtils.ReadObjectArrayFromFile("MPL_" + AMPLquestionsarray.Count.ToString, New AtemporalMPLparameters().GetType, ParamsFile)
            If AMPLquestions.Count <> 0 Then
                AMPLquestionsarray.Add(AMPLquestions)
            End If
        Loop Until AMPLquestions.Count = 0


        Bquestions = FileUtils.ReadObjectArrayFromFile("Belief", New BeliefParameters().GetType, ParamsFile)

        'march 5: URL will remain hardwired until file utility is modified to allow = sign in URL (currently the symbol is treated only as a delimiter
        'march 10: adding URL to input file today
        'WebSurvey = CType(FileUtils.ReadObjectFromFile("Survey", New WebSurveyParameters().GetType, ParamsFile), WebSurveyParameters)

        BeliefPresets = FileUtils.ReadObjectArrayFromFile("BeliefPresets", New BeliefPreset().GetType, ParamsFile)

        If Settings.CurrencyFormat.Length <> 0 Then
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Settings.CurrencyFormat)
        Else
            Dim defaultCulture As CultureInfo = New CultureInfo("en-US", True)
            defaultCulture.NumberFormat.CurrencyNegativePattern = 1
            Threading.Thread.CurrentThread.CurrentCulture = defaultCulture
        End If
    End Sub




    Private Sub RiskDecisionMade(ByVal sender As RiskControlInterface, ByVal e As Single) Handles RiskInterface.DecisionMade
        EndOfPeriod()
    End Sub

    Private Sub BeliefDecisionMade(ByVal sender As BeliefControlInterface, ByVal e As Single()) Handles BeliefInterface.DecisionMade
        EndOfPeriod()
    End Sub

    Private Sub SurveyFinished(ByVal sender As WebSurveyControlInterface, ByVal e As Boolean) Handles SurveyInterface.Finished
        EndOfPeriod()
    End Sub

    Private Sub SaveSettings()
        Settings.NumRiskPeriods = CInt(txtRiskPeriods.Text)
        Settings.NumDiscountingPeriods = CInt(txtDiscountingPeriods.Text)
        'Settings.RiskPeriodsFirst = cbRiskFirst.Checked
        Settings.DisplayFontFamily = DisplayFont.FontFamily.Name
        Settings.DisplayFontSize = DisplayFont.Size
        Settings.DisplayFontStyle = DisplayFont.Style
        If rbBinary.Checked = True Then
            Settings.DiscountingElicitation = 1
        ElseIf rbPortfolio.Checked = True Then
            Settings.DiscountingElicitation = 2
        Else
            Settings.DiscountingElicitation = 3
        End If
        'Settings.DiscountingSoonerColor = ColorTranslator.ToHtml(DiscountingSoonerColor)
        'Settings.DiscountingLaterColor = ColorTranslator.ToHtml(DiscountingLaterColor)
        Settings.DiscountingOpenDecisionSooner = rbOpenSooner.Checked
        Settings.DiscountingShowCalendar = cbCalendar.Checked
        Settings.RiskDiameter = CSng(tbDiameter.Text)
        'Settings.RiskColor1 = ColorTranslator.ToHtml(RiskColor1)
        'Settings.RiskColor2 = ColorTranslator.ToHtml(RiskColor2)
        'Settings.RiskColor3 = ColorTranslator.ToHtml(RiskColor3)
        'Settings.RiskColor4 = ColorTranslator.ToHtml(RiskColor4)
        Settings.RiskShowGraphs = chkGraph.Checked
        Settings.RiskShowText = chkText.Checked

        For i As Integer = 0 To 3
            Select Case dgvPeriods.Rows(i).Cells(1).Value
                Case "Risk"
                    Settings.OrderRiskPeriods = i + 1
                    Settings.NumRiskPeriods = CInt(dgvPeriods.Rows(i).Cells(2).Value)
                Case "Discounting"
                    Settings.OrderDiscountingPeriods = i + 1
                    Settings.NumDiscountingPeriods = CInt(dgvPeriods.Rows(i).Cells(2).Value)
                Case "Belief"
                    Settings.OrderBeliefPeriods = i + 1
                    Settings.NumBeliefPeriods = CInt(dgvPeriods.Rows(i).Cells(2).Value)
                Case "Questionnaire"
                    Settings.OrderQuestionnairePeriods = i + 1
                    Settings.NumQuestionnairePeriods = CInt(dgvPeriods.Rows(i).Cells(2).Value)
            End Select

            'Select Case i
            '    Case 0
            '        Settings.Seq1NumberOfPeriod = CInt(dgvPeriods.Rows(i).Cells(2).Value)
            '    Case 1
            '        Settings.Seq2NumberOfPeriod = CInt(dgvPeriods.Rows(i).Cells(2).Value)
            '    Case 2
            '        Settings.Seq3NumberOfPeriod = CInt(dgvPeriods.Rows(i).Cells(2).Value)
            '    Case 3
            '        Settings.Seq4NumberOfPeriod = CInt(dgvPeriods.Rows(i).Cells(2).Value)
            'End Select
        Next

        FileUtils.WriteObjectToFile("Settings", Settings, ParamsFile)

    End Sub

    Private Sub btnSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettings.Click
        SaveSettings()
    End Sub

    Private Function CreatePeriodSequence() As Period()
        Dim i As Integer
        Dim j As Integer
        'Dim d As DiscountingParameters = New DiscountingParameters
        Dim NumR As Integer = Settings.NumRiskPeriods
        Dim NumD As Integer = Settings.NumDiscountingPeriods
        Dim NumB As Integer = Settings.NumBeliefPeriods
        Dim NumQ As Integer = Settings.NumQuestionnairePeriods
        Dim NumAMPL As Integer = Settings.NumAtemporalMPLPeriods
        Dim rndm As New System.Random

        LastPeriod = NumR + NumD + NumB + NumQ + NumAMPL
        Dim PeriodSequence(LastPeriod - 1) As Period

        'first, we will draw random samples of the discounting, risk, and belief questions (and now MPL questions)
        Dim NumLotteryPairs As Integer
        'Kevin's Comment add handle for Risk_BAR_SINGLE and Risk_BAR_2SIMUL
        If Settings.RiskElicitation = Constants.RISK_SINGLE Or Settings.RiskElicitation = Constants.Risk_BAR_SINGLE Then
            NumLotteryPairs = Settings.NumRiskPeriods
        ElseIf Settings.RiskElicitation = Constants.RISK_2SIMUL Or Settings.RiskElicitation = Constants.Risk_BAR_2SIMUL Then
            NumLotteryPairs = Settings.NumRiskPeriods * 2
        End If

        Dim RQ As ArrayList

        If Settings.RandomizeRiskPeriods = True Then
            RQ = RandomUtils.sample(Rquestions, NumLotteryPairs, rndm)
        Else
            RQ = Rquestions.GetRange(0, NumLotteryPairs)
        End If



        If Settings.RandomRiskOrder Then
            Dim La1Tem As Single
            Dim La2Tem As Single
            Dim La3Tem As Single
            Dim La4Tem As Single
            Dim Lp1Tem As Single
            Dim Lp2Tem As Single
            Dim Lp3Tem As Single
            Dim Lp4Tem As Single
            Dim random As Single
            For Each r As RiskParameters In RQ
                Randomize()
                random = Rnd()
                If (random >= 0.5) Then
                    La1Tem = r.La1
                    La2Tem = r.La2
                    La3Tem = r.La3
                    La4Tem = r.La4
                    Lp1Tem = r.Lp1
                    Lp2Tem = r.Lp2
                    Lp3Tem = r.Lp3
                    Lp4Tem = r.Lp4
                    r.La1 = r.Ra1
                    r.La2 = r.Ra2
                    r.La3 = r.Ra3
                    r.La4 = r.Ra4
                    r.Lp1 = r.Rp1
                    r.Lp2 = r.Rp2
                    r.Lp3 = r.Rp3
                    r.Lp4 = r.Rp4
                    r.Ra1 = La1Tem
                    r.Ra2 = La2Tem
                    r.Ra3 = La3Tem
                    r.Ra4 = La4Tem
                    r.Rp1 = Lp1Tem
                    r.Rp2 = Lp2Tem
                    r.Rp3 = Lp3Tem
                    r.Rp4 = Lp4Tem
                    r.isReverseOrder = True
                End If
            Next
        End If
        Dim DQblocks As ArrayList = RandomUtils.sample(DquestionsArray, Settings.NumDiscountingPeriods, rndm)

        Dim AMPLQblocks As ArrayList = RandomUtils.sample(AMPLquestionsarray, Settings.NumAtemporalMPLPeriods, rndm)

        Dim BQ As ArrayList

        If Settings.RandomizeBeliefPeriods = True Then
            BQ = RandomUtils.sample(Bquestions, Settings.NumBeliefPeriods, rndm)
        Else
            BQ = Bquestions.GetRange(0, Settings.NumBeliefPeriods)
        End If


        'Dim Seq1Type As Integer
        'Dim Seq1Length As Integer
        'Dim Seq2Type As Integer
        'Dim Seq2Length As Integer
        'Dim Seq3Type As Integer
        'Dim Seq3Length As Integer
        'Dim Seq4Type As Integer
        'Dim Seq4Length As Integer

        'determine sequence types and lenghths

        Select Case Settings.OrderRiskPeriods
            Case 1
                PerSeqDetails.Seq1Type = RISK
                PerSeqDetails.Seq1Length = Settings.NumRiskPeriods
            Case 2
                PerSeqDetails.Seq2Type = RISK
                PerSeqDetails.Seq2Length = Settings.NumRiskPeriods
            Case 3
                PerSeqDetails.Seq3Type = RISK
                PerSeqDetails.Seq3Length = Settings.NumRiskPeriods
            Case 4
                PerSeqDetails.Seq4Type = RISK
                PerSeqDetails.Seq4Length = Settings.NumRiskPeriods
            Case 5
                PerSeqDetails.Seq5Type = RISK
                PerSeqDetails.Seq5Length = Settings.NumRiskPeriods
        End Select

        Select Case Settings.OrderDiscountingPeriods
            Case 1
                PerSeqDetails.Seq1Type = DISCOUNTING
                PerSeqDetails.Seq1Length = Settings.NumDiscountingPeriods
            Case 2
                PerSeqDetails.Seq2Type = DISCOUNTING
                PerSeqDetails.Seq2Length = Settings.NumDiscountingPeriods
            Case 3
                PerSeqDetails.Seq3Type = DISCOUNTING
                PerSeqDetails.Seq3Length = Settings.NumDiscountingPeriods
            Case 4
                PerSeqDetails.Seq4Type = DISCOUNTING
                PerSeqDetails.Seq4Length = Settings.NumDiscountingPeriods
            Case 5
                PerSeqDetails.Seq5Type = DISCOUNTING
                PerSeqDetails.Seq5Length = Settings.NumDiscountingPeriods

        End Select

        Select Case Settings.OrderBeliefPeriods
            Case 1
                PerSeqDetails.Seq1Type = BELIEF
                PerSeqDetails.Seq1Length = Settings.NumBeliefPeriods
            Case 2
                PerSeqDetails.Seq2Type = BELIEF
                PerSeqDetails.Seq2Length = Settings.NumBeliefPeriods
            Case 3
                PerSeqDetails.Seq3Type = BELIEF
                PerSeqDetails.Seq3Length = Settings.NumBeliefPeriods
            Case 4
                PerSeqDetails.Seq4Type = BELIEF
                PerSeqDetails.Seq4Length = Settings.NumBeliefPeriods
            Case 5
                PerSeqDetails.Seq5Type = BELIEF
                PerSeqDetails.Seq5Length = Settings.NumBeliefPeriods
        End Select

        Select Case Settings.OrderQuestionnairePeriods
            Case 1
                PerSeqDetails.Seq1Type = QUESTIONNAIRE
                PerSeqDetails.Seq1Length = Settings.NumQuestionnairePeriods
            Case 2
                PerSeqDetails.Seq2Type = QUESTIONNAIRE
                PerSeqDetails.Seq2Length = Settings.NumQuestionnairePeriods
            Case 3
                PerSeqDetails.Seq3Type = QUESTIONNAIRE
                PerSeqDetails.Seq3Length = Settings.NumQuestionnairePeriods
            Case 4
                PerSeqDetails.Seq4Type = QUESTIONNAIRE
                PerSeqDetails.Seq4Length = Settings.NumQuestionnairePeriods
            Case 5
                PerSeqDetails.Seq5Type = QUESTIONNAIRE
                PerSeqDetails.Seq5Length = Settings.NumQuestionnairePeriods
        End Select

        Select Case Settings.OrderAtemporalMPLPeriods
            Case 1
                PerSeqDetails.Seq1Type = AMPL
                PerSeqDetails.Seq1Length = Settings.NumAtemporalMPLPeriods
            Case 2
                PerSeqDetails.Seq2Type = AMPL
                PerSeqDetails.Seq2Length = Settings.NumAtemporalMPLPeriods
            Case 3
                PerSeqDetails.Seq3Type = AMPL
                PerSeqDetails.Seq3Length = Settings.NumAtemporalMPLPeriods
            Case 4
                PerSeqDetails.Seq4Type = AMPL
                PerSeqDetails.Seq4Length = Settings.NumAtemporalMPLPeriods
            Case 5
                PerSeqDetails.Seq5Type = AMPL
                PerSeqDetails.Seq5Length = Settings.NumAtemporalMPLPeriods
        End Select

        'now we loop over all periods and assign initial values

        For i = 0 To PerSeqDetails.Seq1Length - 1
            PeriodSequence(i) = New Period
            PeriodSequence(i).PeriodNumber = i + 1
            PeriodSequence(i).Type = PerSeqDetails.Seq1Type
            PeriodSequence(i).IndexOffset = 0
        Next
        For i = PerSeqDetails.Seq1Length To PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length - 1
            PeriodSequence(i) = New Period
            PeriodSequence(i).PeriodNumber = i + 1
            PeriodSequence(i).Type = PerSeqDetails.Seq2Type
            PeriodSequence(i).IndexOffset = PerSeqDetails.Seq1Length
        Next
        For i = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length To PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length - 1
            PeriodSequence(i) = New Period
            PeriodSequence(i).PeriodNumber = i + 1
            PeriodSequence(i).Type = PerSeqDetails.Seq3Type
            PeriodSequence(i).IndexOffset = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length
        Next
        For i = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length To PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length + PerSeqDetails.Seq4Length - 1
            PeriodSequence(i) = New Period
            PeriodSequence(i).PeriodNumber = i + 1
            PeriodSequence(i).Type = PerSeqDetails.Seq4Type
            PeriodSequence(i).IndexOffset = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length
        Next
        For i = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length + PerSeqDetails.Seq4Length To PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length + PerSeqDetails.Seq4Length + PerSeqDetails.Seq5Length - 1
            PeriodSequence(i) = New Period
            PeriodSequence(i).PeriodNumber = i + 1
            PeriodSequence(i).Type = PerSeqDetails.Seq5Type
            PeriodSequence(i).IndexOffset = PerSeqDetails.Seq1Length + PerSeqDetails.Seq2Length + PerSeqDetails.Seq3Length + PerSeqDetails.Seq4Length
        Next

        For i = 0 To LastPeriod - 1
            Select Case PeriodSequence(i).Type
                Case RISK
                    'Kevin's Comment add handle for Risk_BAR_SINGLE and Risk_BAR_2SIMUL
                    If Settings.RiskElicitation = Constants.RISK_SINGLE Or Settings.RiskElicitation = Constants.Risk_BAR_SINGLE Then
                        PeriodSequence(i).Decision.Add(New Single)
                        PeriodSequence(i).RiskParas.Add(RQ.Item(i - PeriodSequence(i).IndexOffset))
                    ElseIf Settings.RiskElicitation = Constants.RISK_2SIMUL Or Settings.RiskElicitation = Constants.Risk_BAR_2SIMUL Then
                        PeriodSequence(i).Decision.Add(New Single)
                        PeriodSequence(i).Decision.Add(New Single)
                        PeriodSequence(i).RiskParas.Add(RQ.Item(2 * (i - PeriodSequence(i).IndexOffset)))
                        PeriodSequence(i).RiskParas.Add(RQ.Item(2 * (i - PeriodSequence(i).IndexOffset) + 1))
                    End If
                    PeriodSequence(i).DiscountingParas.Add(New DiscountingParameters) 'add blank objects for formatted results
                    PeriodSequence(i).BeliefParas = New BeliefParameters  'blank
                    PeriodSequence(i).AtemporalMPLParas.Add(New AtemporalMPLparameters) 'blank
                Case DISCOUNTING
                    For j = 1 To List.Count 'add one decision holder for each discounting question
                        PeriodSequence(i).Decision.Add(New Single)
                    Next
                    Dim x As Integer
                    If Settings.DiscountingElicitation = BINARY Or Settings.DiscountingElicitation = PORTFOLIO Or Settings.DiscountingElicitation = OPEN Then
                        x = List.Count
                    ElseIf Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Or Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                        x = Settings.DiscountingRows
                    End If
                    Dim DQ As ArrayList = RandomUtils.sample(DQblocks.Item(i - PeriodSequence(i).IndexOffset), x, rndm)
                    DQ.Sort()
                    If Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
                        For j = x To List.Count - 1
                            DQ.Add(New DiscountingParameters)
                            DirectCast(DQ(j), DiscountingParameters).ID = DirectCast(DQ(j - x), DiscountingParameters).ID & "B"
                            DirectCast(DQ(j), DiscountingParameters).Lamount = DirectCast(DQ(j - x), DiscountingParameters).B_Lamount
                            DirectCast(DQ(j), DiscountingParameters).Ldays = DirectCast(DQ(j - x), DiscountingParameters).B_Ldays
                            DirectCast(DQ(j), DiscountingParameters).Ramount = DirectCast(DQ(j - x), DiscountingParameters).B_Ramount
                            DirectCast(DQ(j), DiscountingParameters).Rdays = DirectCast(DQ(j - x), DiscountingParameters).B_Rdays
                        Next
                    End If
                    If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                        For j = x To (2 * x) - 1
                            DQ.Add(New DiscountingParameters)
                            DirectCast(DQ(j), DiscountingParameters).ID = DirectCast(DQ(j - x), DiscountingParameters).ID & "B"
                            DirectCast(DQ(j), DiscountingParameters).Lamount = DirectCast(DQ(j - x), DiscountingParameters).B_Lamount
                            DirectCast(DQ(j), DiscountingParameters).Ldays = DirectCast(DQ(j - x), DiscountingParameters).B_Ldays
                            DirectCast(DQ(j), DiscountingParameters).Ramount = DirectCast(DQ(j - x), DiscountingParameters).B_Ramount
                            DirectCast(DQ(j), DiscountingParameters).Rdays = DirectCast(DQ(j - x), DiscountingParameters).B_Rdays
                        Next
                        For j = (2 * x) To List.Count - 1
                            DQ.Add(New DiscountingParameters)
                            DirectCast(DQ(j), DiscountingParameters).ID = DirectCast(DQ(j - 2 * x), DiscountingParameters).ID & "C"
                            DirectCast(DQ(j), DiscountingParameters).Lamount = DirectCast(DQ(j - 2 * x), DiscountingParameters).C_Lamount
                            DirectCast(DQ(j), DiscountingParameters).Ldays = DirectCast(DQ(j - 2 * x), DiscountingParameters).C_Ldays
                            DirectCast(DQ(j), DiscountingParameters).Ramount = DirectCast(DQ(j - 2 * x), DiscountingParameters).C_Ramount
                            DirectCast(DQ(j), DiscountingParameters).Rdays = DirectCast(DQ(j - 2 * x), DiscountingParameters).C_Rdays
                        Next
                    End If

                    PeriodSequence(i).DiscountingParas = DQ
                    PeriodSequence(i).RiskParas.Add(New RiskParameters)    'add blank objects for formatted results
                    PeriodSequence(i).BeliefParas = New BeliefParameters  'blank
                    PeriodSequence(i).AtemporalMPLParas.Add(New AtemporalMPLparameters) 'blank
                Case BELIEF
                    For j = 1 To Settings.BeliefElicitation  'one for each BIN -- hardwired at 10 for now
                        PeriodSequence(i).Decision.Add(New Single)
                    Next
                    'PeriodSequence(i).Decision.Add(New Single()) 'this may have to be modified as belief decision can be more than single number
                    PeriodSequence(i).BeliefParas = BQ.Item(i - PeriodSequence(i).IndexOffset)
                    PeriodSequence(i).DiscountingParas.Add(New DiscountingParameters) 'add blank objects for formatted results
                    PeriodSequence(i).RiskParas.Add(New RiskParameters)    'add blank objects for formatted results
                    PeriodSequence(i).AtemporalMPLParas.Add(New AtemporalMPLparameters) 'blank
                Case QUESTIONNAIRE
                    PeriodSequence(i).Decision.Add(New Boolean)
                    PeriodSequence(i).DiscountingParas.Add(New DiscountingParameters) 'add blank objects for formatted results
                    PeriodSequence(i).RiskParas.Add(New RiskParameters)  'add blank objects for formatted results
                    PeriodSequence(i).BeliefParas = New BeliefParameters  'blank
                    PeriodSequence(i).AtemporalMPLParas.Add(New AtemporalMPLparameters) 'blank
                Case AMPL
                    For j = 1 To MPLlist.Count 'add one decision holder for each mpl question
                        PeriodSequence(i).Decision.Add(New Single)
                    Next
                    Dim x As Integer
                    'If Settings.DiscountingElicitation = BINARY Or Settings.DiscountingElicitation = PORTFOLIO Or Settings.DiscountingElicitation = OPEN Then
                    x = MPLlist.Count
                    'ElseIf Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Or Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                    'x = Settings.DiscountingRows
                    'End If
                    Dim MPLQ As ArrayList = RandomUtils.sample(AMPLQblocks.Item(i - PeriodSequence(i).IndexOffset), x, rndm)
                    MPLQ.Sort()

                    PeriodSequence(i).AtemporalMPLParas = MPLQ
                    PeriodSequence(i).RiskParas.Add(New RiskParameters)    'add blank objects for formatted results
                    PeriodSequence(i).BeliefParas = New BeliefParameters  'blank
                    PeriodSequence(i).DiscountingParas.Add(New DiscountingParameters) 'add blank objects for formatted results

            End Select
            PeriodSequence(i).ID = SubjectID
        Next

        Return PeriodSequence
    End Function




    Private Sub DrawPeriod(ByVal p As RiskTimeBeliefLibrary.Period)

        If Settings.LowResolution = True Then
            RiskChoiceItemHeight = 520
            'RiskChoiceItemWidth = 750
            Settings.DiscountingChoiceItemHeight = 50
            'DiscountingChoiceItemWidth = 750
            BeliefChoiceItemHeight = 500
            BeliefChoiceItemWidth = 900

            'btnBpreset1.AutoSize = False
            'btnBpreset1.Size = New Size(70, 25)
            'btnBpreset1.Font.SizeInPoints = 8
        End If

        ClearScreen()
        lblCurrentPeriod.Text = "Choice " & CurrentPeriod.ToString & " of " & LastPeriod.ToString
        If CurrentPeriod <= LastPeriod Then
            If p.Type = RISK Then
                DrawRisk(p)
            ElseIf p.Type = DISCOUNTING Then
                DrawDiscounting(p)
            ElseIf p.Type = AMPL Then
                DrawMPL(p)
            ElseIf p.Type = BELIEF Then
                DrawBelief(p)
            ElseIf p.Type = QUESTIONNAIRE Then
                'DrawSurvey("http://excen.gsu.edu/phpESP/public/survey.php?name=NewRDB" & "&username=" & MachineName & "_" & Now.ToString("yyyy-MM-dd HHmmss"))

                'DrawSurvey("http://www.excen.gsu.edu/phpESP/public/survey.php?name=MAR2011_RDB" & "&username=" & MachineName & "_" & Now.ToString("yyyy-MM-dd HHmmss"))




                'file reader utility must be modifed before the line below is valid.  Currently the file reader uses = symbol to delimit object property lines,
                'and the URL also has an = sign.  This causes URL to not read in.

                If Settings.AppendUserNameToSurveyURL = True Then
                    DrawSurvey(Settings.SurveyURL & "?username=" & Periods(0).ID)
                Else
                    DrawSurvey(Settings.SurveyURL)
                End If







            End If
        Else
            MsgBox("The End.")
        End If
    End Sub

    Private Sub DrawBelief(ByVal p As RiskTimeBeliefLibrary.Period)

        If Settings.BeliefElicitation = BELIEF_10 Then
            BeliefChoice = New ucBeliefDecision10
        ElseIf Settings.BeliefElicitation = BELIEF_2 Then
            BeliefChoice = New ucBeliefDecision2
        End If

        BeliefInterface = BeliefChoice
        With BeliefChoice
            .Visible = False
            .Height = BeliefChoiceItemHeight
            .Width = BeliefChoiceItemWidth
            'If Settings.LowResolution = True Then
            '    .Location = New Point(800 - BeliefChoiceItemWidth, 50)
            'Else
            '    .Location = New Point(Center - .Width / 2, 50)
            'End If
            .Location = New Point(Center - .Width / 2, 50)
            If Settings.LowResolution = True Then
                .Location = New Point(Me.Width - .Width - 10, 50)
            End If
            tabSubjectDisplay.Controls.Add(BeliefChoice)
        End With
        With CType(BeliefChoice, BeliefControlInterface)
            If Settings.LowResolution = True Then .SetLowRes()
            .SetFont(DisplayFont)
            .SetPrize(Settings.BeliefPrize)
            .Initialize(p.BeliefParas)
            '.setcolors
        End With
        If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
            CType(BeliefChoice, BeliefControlInterface).SetDecision(p.Decision.ToArray())
        End If
        BeliefChoice.Visible = True


        If p.isDecisionMade = False Then
            CurrentBeliefPreset1 = Nothing
            CurrentBeliefPreset2 = Nothing
            CurrentBeliefPreset3 = Nothing
            CurrentBeliefPreset4 = Nothing
            CurrentBeliefPreset5 = Nothing

            For Each preset As BeliefPreset In BeliefPresets
                If preset.ID = p.BeliefParas.ID Then
                    Select Case preset.Position
                        Case 1
                            CurrentBeliefPreset1 = preset
                            With btnBpreset1
                                .Font = DisplayFont
                                .Text = preset.ButtonLabel
                                If Settings.LowResolution = True Then
                                    .Font = New Font(DisplayFont.Name, DisplayFont.Size - 2, DisplayFont.Style)
                                    .AutoSize = False
                                    'btnBpreset1.Size = New Size(70, 25)
                                    .Location = New Point(10, .Location.Y)
                                End If
                                .Visible = True
                            End With
                        Case 2
                            CurrentBeliefPreset2 = preset
                            With btnBpreset2
                                .Font = DisplayFont
                                .Text = preset.ButtonLabel
                                If Settings.LowResolution = True Then
                                    .Font = New Font(DisplayFont.Name, DisplayFont.Size - 2, DisplayFont.Style)
                                    .AutoSize = False
                                    'btnBpreset1.Size = New Size(70, 25)
                                    .Location = New Point(10, btnBpreset1.Location.Y + 35)
                                End If
                                .Visible = True
                            End With
                        Case 3
                            CurrentBeliefPreset3 = preset
                            With btnBpreset3
                                .Font = DisplayFont
                                .Text = preset.ButtonLabel
                                If Settings.LowResolution = True Then
                                    .Font = New Font(DisplayFont.Name, DisplayFont.Size - 2, DisplayFont.Style)
                                    .AutoSize = False
                                    'btnBpreset1.Size = New Size(70, 25)
                                    .Location = New Point(10, btnBpreset1.Location.Y + 70)
                                End If
                                .Visible = True
                            End With
                        Case 4
                            CurrentBeliefPreset4 = preset
                            With btnBpreset4
                                .Font = DisplayFont
                                .Text = preset.ButtonLabel
                                If Settings.LowResolution = True Then
                                    .Font = New Font(DisplayFont.Name, DisplayFont.Size - 2, DisplayFont.Style)
                                    .AutoSize = False
                                    'btnBpreset1.Size = New Size(70, 25)
                                    .Location = New Point(10, btnBpreset1.Location.Y + 105)
                                End If
                                .Visible = True
                            End With
                        Case 5
                            CurrentBeliefPreset5 = preset
                            With btnBpreset5
                                .Font = DisplayFont
                                .Text = preset.ButtonLabel
                                If Settings.LowResolution = True Then
                                    .Font = New Font(DisplayFont.Name, DisplayFont.Size - 2, DisplayFont.Style)
                                    .AutoSize = False
                                    'btnBpreset1.Size = New Size(70, 25)
                                    .Location = New Point(10, btnBpreset1.Location.Y + 140)
                                End If
                                .Visible = True
                            End With
                    End Select
                End If
            Next
        End If







    End Sub


    Private Sub DrawDiscounting(ByVal p As RiskTimeBeliefLibrary.Period)
        Dim ts As TimeSpan
        'Dim MonthDif As Integer
        Dim i, j As Integer
        'Dim NumListItems As Integer
        'Dim tmp_dp As DiscountingParameters


        Dim d(5) As DateItem
        d(0) = New DateItem()
        d(1) = New DateItem()
        d(2) = New DateItem()
        d(3) = New DateItem()
        d(4) = New DateItem()
        d(5) = New DateItem()


        ''remove the previous list items
        'Dim ctrl As Control
        'For Each ctrl In tabSubjectDisplay.Controls
        '    If TypeOf (ctrl) Is ucBinaryDecision Then tabSubjectDisplay.Controls.Remove(ctrl)
        '    If TypeOf (ctrl) Is ucPortfolioDecision Then tabSubjectDisplay.Controls.Remove(ctrl)
        '    If TypeOf (ctrl) Is ucOpenDecision Then tabSubjectDisplay.Controls.Remove(ctrl)
        'Next

        'For i = 0 To List.GetUpperBound(0)
        '    tabSubjectDisplay.Controls.Remove(List(i))
        'Next
        '--------------------------


        'THE CODE BELOW WAS COMMENTED OUT WHEN DiscountingChoiceListOffset VARIABLE WAS ADDED TO SETTINGS
        'If Settings.LowResolution = True Then
        '    j = 270
        'Else
        '    j = 337
        '    j = 500
        'End If

        j = Settings.DiscountingChoiceListOffset

        ReDim InterfaceList(List.GetUpperBound(0))

        'instantiate the list items
        For i = 0 To List.GetUpperBound(0)
            Select Case Settings.DiscountingElicitation
                Case BINARY
                    List(i) = New ucBinaryDecision()
                Case PORTFOLIO
                    List(i) = New ucPortfolioDecision()
                Case OPEN
                    List(i) = New ucOpenDecision()
                Case BUNDLING_K1_FREE_RANGE
                    List(i) = New ucBinaryDecision()
                Case BUNDLING_K1_FORCE_FED
                    List(i) = New ucBinaryDecision()
                Case BUNDLING_K2_FREE_RANGE
                    List(i) = New ucBinaryDecision()
                Case BUNDLING_K2_FORCE_FED
                    List(i) = New ucBinaryDecision()

            End Select
            InterfaceList(i) = List(i)
            AddHandler InterfaceList(i).DecisionMade, AddressOf CheckDiscountingChoices
            With List(i)
                .Height = Settings.DiscountingChoiceItemHeight
                .Width = Settings.DiscountingChoiceItemWidth
                If Settings.DiscountingElicitation < BUNDLING_K1_FREE_RANGE Then
                    .Location = New Point(Center - .Width / 2, j + i * (.Height - 1))
                Else
                    Dim lblLine As Label = New Label
                    lblLine.Name = "lblLine"
                    lblLine.Height = 3
                    lblLine.BorderStyle = BorderStyle.Fixed3D
                    lblLine.Width = 2 * .Width + 150
                    If Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
                        lblLine.Location = New Point(Center - .Width - 75, j - 5)
                        If i < Settings.DiscountingRows Then
                            .Location = New Point(Center - .Width - 50, j + i * (.Height - 1 + 10))
                            lblLine.Location = New Point(Center - .Width - 75, j + i * (.Height - 1 + 10) + (.Height - 1) + 5)
                        Else
                            Dim lbl As Label = New Label
                            tabSubjectDisplay.Controls.Add(lbl)
                            lbl.Name = "lblAnd"
                            lbl.Text = "AND"
                            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                            lbl.AutoSize = True
                            'lbl.BorderStyle = BorderStyle.FixedSingle
                            lbl.Location = New Point(Center - lbl.Width / 2, j + .Height / 2 - lbl.Height / 2 + (i - List.Count / 2) * (.Height - 1 + 10))

                            .Location = New Point(Center + 50, j + (i - List.Count / 2) * (.Height - 1 + 10))
                        End If
                        tabSubjectDisplay.Controls.Add(lblLine)
                    End If
                    If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                        lblLine.Width = 3 * .Width + 250
                        lblLine.Location = New Point(Center - 1.5 * .Width - 125, j - 5)
                        If i < Settings.DiscountingRows Then
                            .Location = New Point(Center - 1.5 * .Width - 100, j + i * (.Height - 1 + 10))
                            lblLine.Location = New Point(Center - 1.5 * .Width - 125, j + i * (.Height - 1 + 10) + (.Height - 1) + 5)
                        ElseIf i < 2 * Settings.DiscountingRows Then
                            Dim lbl As Label = New Label
                            tabSubjectDisplay.Controls.Add(lbl)
                            lbl.Name = "lblAnd"
                            lbl.Text = "AND"
                            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                            lbl.AutoSize = True
                            'lbl.BorderStyle = BorderStyle.FixedSingle
                            lbl.Location = New Point(Center - 0.5 * .Width - 50 - lbl.Width / 2, j + .Height / 2 - lbl.Height / 2 + (i - List.Count / 3) * (.Height - 1 + 10))
                            .Location = New Point(Center - 0.5 * .Width, j + (i - List.Count / 3) * (.Height - 1 + 10))
                        Else
                            Dim lbl As Label = New Label
                            tabSubjectDisplay.Controls.Add(lbl)
                            lbl.Name = "lblAnd"
                            lbl.Text = "AND"
                            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                            lbl.AutoSize = True
                            'lbl.BorderStyle = BorderStyle.FixedSingle
                            lbl.Location = New Point(Center + 0.5 * .Width + 50 - lbl.Width / 2, j + .Height / 2 - lbl.Height / 2 + (i - List.Count * 2 / 3) * (.Height - 1 + 10))
                            .Location = New Point(Center + 0.5 * .Width + 100, j + (i - List.Count * 2 / 3) * (.Height - 1 + 10))

                        End If
                        tabSubjectDisplay.Controls.Add(lblLine)
                    End If
                End If

                .Visible = False
                tabSubjectDisplay.Controls.Add(List(i))
            End With
        Next

        'instantiate the calendar objects
        For i = 0 To MaxMonths
            cmCalendar(i) = New Pabo.Calendar.MonthCalendar()
            With cmCalendar(i)
                If Settings.LowResolution = True Then
                    .Height = 150
                    .Width = 200
                Else
                    .Height = 200
                    .Width = 260
                End If

                '.Width = 200
                .Location = New Point(Center - (2 * .Width) + (i * (.Width - 1)), 40)
                If Settings.DiscountingShowToday = True Then
                    .TodayColor = Color.Black
                    .ShowToday = True
                Else
                    .ShowToday = False
                End If
                '.ShowToday = False
                .ShowFooter = False
                .Header.MonthSelectors = False
                .Header.BackColor1 = Color.CornflowerBlue
                .Month.Transparency.Background = 255
                .Month.Transparency.Text = 255
                .Enabled = False
                .ActiveMonth.Year = Now.Year + Math.Ceiling((Now.Month + i) / 12) - 1
                If (Now.Month + i) Mod 12 = 0 Then
                    .ActiveMonth.Month = 12
                Else
                    .ActiveMonth.Month = (Now.Month + i) Mod 12
                End If
                .ShowTrailingDates = False
                .Visible = False
                .Weekdays.Format = mcDayFormat.Short
                '.Weekdays.Font = DisplayFont
                '.Header.Font = DisplayFont
                tabSubjectDisplay.Controls.Add(cmCalendar(i))
            End With
        Next

        'place confirm and cancel widgets underneath choices
        With lblConfirm
            If Settings.LowResolution = True Then
                j = 10
            Else
                j = 30
            End If
            .Font = DisplayFont
            .Location = New Point(Center - .Width / 2, List(List.Count - 1).Location.Y + List(List.Count - 1).Height + j)
            .Visible = False
        End With

        With btnConfirm
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Font = DisplayFont
            .Enabled = False
            .Location = New Point(Center - .Width - 10, lblConfirm.Location.Y + lblConfirm.Height + 10)
            .Visible = False
        End With

        With btnCancel
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Font = DisplayFont
            .Enabled = False
            .Location = New Point(Center + 10, lblConfirm.Location.Y + lblConfirm.Height + 10)
            .Visible = False
        End With

        'lblWait.Visible = False

        ts = New TimeSpan(24 * p.DiscountingParas.Item(0).Ldays, 0, 0)
        SoonerDate = Now + ts
        'Horizon = CInt(txtHorizon.Text) 'in weeks
        ts = New TimeSpan(24 * p.DiscountingParas.Item(0).Rdays, 0, 0)
        LaterDate = Now + ts

        d(0).Date = New DateTime(SoonerDate.Year, SoonerDate.Month, SoonerDate.Day)
        d(0).BoldedDate = True
        d(0).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)

        d(1).Date = New DateTime(LaterDate.Year, LaterDate.Month, LaterDate.Day)
        d(1).BoldedDate = True
        d(1).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)

        If Settings.DiscountingElicitation >= BUNDLING_K1_FREE_RANGE Then
            ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count / 2).Ldays, 0, 0)
            SoonerDateB = Now + ts
            ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count / 2).Rdays, 0, 0)
            LaterDateB = Now + ts

            d(2).Date = New DateTime(SoonerDateB.Year, SoonerDateB.Month, SoonerDateB.Day)
            d(2).BoldedDate = True
            d(2).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB)

            d(3).Date = New DateTime(LaterDateB.Year, LaterDateB.Month, LaterDateB.Day)
            d(3).BoldedDate = True
            d(3).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColorB)
        End If

        If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
            ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count * 2 / 3).Ldays, 0, 0)
            SoonerDateC = Now + ts
            ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count * 2 / 3).Rdays, 0, 0)
            LaterDateC = Now + ts

            d(4).Date = New DateTime(SoonerDateC.Year, SoonerDateC.Month, SoonerDateC.Day)
            d(4).BoldedDate = True
            d(4).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC)

            d(5).Date = New DateTime(LaterDateC.Year, LaterDateC.Month, LaterDateC.Day)
            d(5).BoldedDate = True
            d(5).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColorC)
        End If

        'highlight dates; each calendar is locked, so each date will show on only one calendar
        ' and determine which calendars will be visible
        For i = 0 To MaxMonths
            With cmCalendar(i)
                .ResetDateInfo()
                .AddDateInfo(d)
                If Settings.DiscountingShowCalendar = True Then 'And .ActiveMonth.Month <= LaterDate.Month Then
                    .Visible = True
                Else
                    .Visible = False
                End If

            End With
        Next

        'display date labels
        'position weeks first, because they are based off of list(0) below, and then date is relative to weeks placement
        'but then, we have to come back to weeks labels, a their width is determined by dates widths


        Dim o As DiscountingParameters = p.DiscountingParas.Item(0)
        With lblSoonerDate
            .Text = SoonerDate.ToString("D")
            If o.Ldays = 0 Then
                .Text = .Text & vbCrLf & "(Today)"
            Else
                .Text = .Text & vbCrLf & "(" & o.Ldays.ToString & " day"
                If o.Ldays > 1 Then .Text = .Text & "s"
                .Text = .Text & " from today)"
            End If

            .Font = DisplayFont

            .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
            '.Location = New Point(List(0).Location.X + 0.225 * List(0).Width - .Width / 2, cmCalendar(0).Location.Y + cmCalendar(0).Height + 30)
            If Settings.LowResolution = True Then
                i = 10
            Else
                i = 30
            End If

            .Location = New Point(List(0).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
            .Width = 0.45 * List(0).Width
            .Height = Settings.DiscountingChoiceItemHeight
            .TextAlign = ContentAlignment.MiddleCenter
            .Visible = True
        End With

        With lblLaterDate
            .Text = LaterDate.ToString("D")


            If o.Rdays = 0 Then
                .Text = .Text & vbCrLf & "(Today)"
            Else
                .Text = .Text & vbCrLf & "(" & o.Rdays.ToString & " day"
                If o.Rdays > 1 Then .Text = .Text & "s"
                .Text = .Text & " from today)"
            End If
            .Font = DisplayFont
            .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
            .Location = New Point(List(0).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
            .Width = 0.45 * List(0).Width
            .Height = Settings.DiscountingChoiceItemHeight
            .TextAlign = ContentAlignment.MiddleCenter
            .Visible = True
        End With



        If Settings.DiscountingElicitation >= BUNDLING_K1_FREE_RANGE Then
            Dim lbl As Label
            lbl = New Label
            o = New DiscountingParameters
            o = p.DiscountingParas.Item(List.Count / 2)
            With lbl
                .Name = "lblDate"
                .Text = SoonerDateB.ToString("D")
                .Font = DisplayFont
                .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB)
                .Location = New Point(List(List.Count / 2).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
                .Width = 0.45 * List(List.Count / 2).Width
                .Height = Settings.DiscountingChoiceItemHeight

                If o.Ldays = 0 Then
                    .Text = .Text & vbCrLf & "(Today)"
                Else
                    .Text = .Text & vbCrLf & "(" + o.Ldays.ToString + " day"
                    If o.Ldays > 1 Then .Text = .Text + "s"
                    .Text = .Text + " from today)"
                End If
                .Font = DisplayFont
                '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
                '.Location = New Point(lblSoonerDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
                '.Width = lblSoonerDate.Width
                '.Height = lblSoonerDate.Height + 4
                '.TextAlign = ContentAlignment.TopCenter

                .TextAlign = ContentAlignment.MiddleCenter
                tabSubjectDisplay.Controls.Add(lbl)
            End With

            lbl = New Label
            With lbl
                .Name = "lblDate"
                .Text = LaterDateB.ToString("D")
                .Font = DisplayFont
                .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColorB)
                .Location = New Point(List(List.Count / 2).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
                .Width = 0.45 * List(0).Width
                .Height = Settings.DiscountingChoiceItemHeight
                .TextAlign = ContentAlignment.TopCenter

                If o.Rdays = 0 Then
                    .Text = .Text & vbCrLf & "(Today)"
                Else
                    .Text = .Text & vbCrLf & "(" + o.Rdays.ToString + " day"
                    If o.Rdays > 1 Then .Text = .Text + "s"
                    .Text = .Text + " from today)"
                End If
                '.Text = "(" + CStr(Horizon) + " week"
                'If Horizon > 1 Then .Text = .Text + "s"
                '.Text = .Text + " from today)"
                '.Font = DisplayFont
                '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
                '.Location = New Point(lblLaterDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
                '.Width = lblLaterDate.Width
                '.Height = lblLaterDate.Height + 4
                .TextAlign = ContentAlignment.MiddleCenter
                tabSubjectDisplay.Controls.Add(lbl)
            End With

        End If


        If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
            Dim lbl As Label
            lbl = New Label
            o = New DiscountingParameters
            o = p.DiscountingParas.Item(List.Count * 2 / 3)
            With lbl
                .Name = "lblDate"
                .Text = SoonerDateC.ToString("D")
                .Font = DisplayFont
                .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC)
                .Location = New Point(List(List.Count * 2 / 3).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
                .Width = 0.45 * List(List.Count / 2).Width
                .Height = Settings.DiscountingChoiceItemHeight

                If o.Ldays = 0 Then
                    .Text = .Text & vbCrLf & "(Today)"
                Else
                    .Text = .Text & vbCrLf & "(" + o.Ldays.ToString + " day"
                    If o.Ldays > 1 Then .Text = .Text + "s"
                    .Text = .Text + " from today)"
                End If
                .Font = DisplayFont
                '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
                '.Location = New Point(lblSoonerDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
                '.Width = lblSoonerDate.Width
                '.Height = lblSoonerDate.Height + 4
                '.TextAlign = ContentAlignment.TopCenter

                .TextAlign = ContentAlignment.MiddleCenter
                tabSubjectDisplay.Controls.Add(lbl)
            End With

            lbl = New Label
            With lbl
                .Name = "lblDate"
                .Text = LaterDateC.ToString("D")
                .Font = DisplayFont
                .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColorC)
                .Location = New Point(List(List.Count * 2 / 3).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
                .Width = 0.45 * List(0).Width
                .Height = Settings.DiscountingChoiceItemHeight
                .TextAlign = ContentAlignment.TopCenter

                If o.Rdays = 0 Then
                    .Text = .Text & vbCrLf & "(Today)"
                Else
                    .Text = .Text & vbCrLf & "(" + o.Rdays.ToString + " day"
                    If o.Rdays > 1 Then .Text = .Text + "s"
                    .Text = .Text + " from today)"
                End If
                '.Text = "(" + CStr(Horizon) + " week"
                'If Horizon > 1 Then .Text = .Text + "s"
                '.Text = .Text + " from today)"
                '.Font = DisplayFont
                '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
                '.Location = New Point(lblLaterDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
                '.Width = lblLaterDate.Width
                '.Height = lblLaterDate.Height + 4
                .TextAlign = ContentAlignment.MiddleCenter
                tabSubjectDisplay.Controls.Add(lbl)
            End With

        End If





        'cancel previous choices
        CancelChoices()

        'show the list items
        i = 0
        For Each L As DiscountingControlInterface In List
            'Dim P As DiscountingParameters = DisplaySet.Item(i)
            'P.Lamount = CSng(txtSoonerAmount.Text)
            'P.Ramount = CSng(txtSoonerAmount.Text) + CSng(dgvFuture.Item(1, i).Value)
            'P.Ldays = 0
            'P.Rdays = ts.Days
            If Settings.DiscountingElicitation = OPEN Then  'I want to do this before initialize, because some of the initialization of open type depends on it
                If Settings.DiscountingOpenDecisionSooner = True Then
                    L.OpenDecisionType(1)
                Else
                    L.OpenDecisionType(2)
                End If
            End If
            'If Settings.DiscountingElicitation = BINARY Or Settings.DiscountingElicitation = PORTFOLIO Or Settings.DiscountingElicitation = OPEN Then
            L.Initialize(p.DiscountingParas.Item(i))
            'ElseIf Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Then
            'If i < 4 Then
            '    L.Initialize(p.DiscountingParas.Item(i))
            'Else
            '    tmp_dp = p.DiscountingParas.Item(i - 4)
            '    tmp_dp.Lamount = tmp_dp.B_Lamount
            '    tmp_dp.Ldays = tmp_dp.B_Ldays
            '    tmp_dp.Ramount = tmp_dp.B_Ramount
            '    tmp_dp.Rdays = tmp_dp.B_Rdays
            '    L.Initialize(tmp_dp)

            'End If
            'End If

            L.SetIndex(i)     'this value let's me know which List item raised the decisionMade event
            L.SetFont(DisplayFont)
            L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColor))
            L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColor))
            If (Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED) And i >= List.Count / 2 Then
                L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB))
                L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorB))
            End If

            If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                If i >= List.Count / 3 And i < List.Count * 2 / 3 Then
                    L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB))
                    L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorB))
                End If
                If i >= List.Count * 2 / 3 Then
                    L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC))
                    L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorC))
                End If
            End If


            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(List(i), DiscountingControlInterface).SetDecision(p.Decision.Item(i))
            End If

            i += 1

            L.SetVisible(True)
        Next

        CType(List(0), DiscountingControlInterface).ValidateDecision()


        'make the confirmation widets visible, as they were made invisible at form load... IF not an old decision...
        lblConfirm.Visible = Not (p.isDecisionMade)
        btnConfirm.Visible = Not (p.isDecisionMade)
        btnCancel.Visible = Not (p.isDecisionMade)

        'add buttons for dice roll next to each choice IF an old decision
        If Settings.DiscountingElicitation <> OPEN Then
            If p.isDecisionMade = True Then
                ReviewType = DISCOUNTING
                'ReDim rbDice(List.GetUpperBound(0))
                'For i = 0 To rbDice.GetUpperBound(0)
                ReDim rbDice(Settings.DiscountingRows - 1)
                For i = 0 To Settings.DiscountingRows - 1
                    rbDice(i) = New RadioButton
                    AddHandler rbDice(i).CheckedChanged, AddressOf rbDice_CheckedChanged
                    tabSubjectDisplay.Controls.Add(rbDice(i))
                    With rbDice(i)
                        .Appearance = Appearance.Button
                        .Font = DisplayFont
                        .AutoSize = True
                        .Text = "Roll " & (i + 1).ToString
                        '.Width = 50
                        '.Height = List(i).Height
                        .Location = New Point(List(i).Location.X - .Width - 0, List(i).Location.Y + (List(i).Height - .Height) / 2)

                    End With

                Next
            End If
        End If





    End Sub



    Private Sub DrawMPL(ByVal p As RiskTimeBeliefLibrary.Period)
        'Dim ts As TimeSpan
        'Dim MonthDif As Integer
        Dim i, j As Integer
        'Dim NumListItems As Integer
        'Dim tmp_dp As DiscountingParameters


        'Dim d(5) As DateItem
        'd(0) = New DateItem()
        'd(1) = New DateItem()
        'd(2) = New DateItem()
        'd(3) = New DateItem()
        'd(4) = New DateItem()
        'd(5) = New DateItem()



        'j = Settings.DiscountingChoiceListOffset

        ReDim MPLinterfaceList(MPLlist.GetUpperBound(0))

        'instantiate the list items
        For i = 0 To MPLlist.GetUpperBound(0)

            MPLlist(i) = New ucMPL()


            'Select Case Settings.DiscountingElicitation
            '    Case BINARY
            '        List(i) = New ucBinaryDecision()
            '    Case PORTFOLIO
            '        List(i) = New ucPortfolioDecision()
            '    Case OPEN
            '        List(i) = New ucOpenDecision()
            '    Case BUNDLING_K1_FREE_RANGE
            '        List(i) = New ucBinaryDecision()
            '    Case BUNDLING_K1_FORCE_FED
            '        List(i) = New ucBinaryDecision()
            '    Case BUNDLING_K2_FREE_RANGE
            '        List(i) = New ucBinaryDecision()
            '    Case BUNDLING_K2_FORCE_FED
            '        List(i) = New ucBinaryDecision()
            'End Select

            MPLinterfaceList(i) = MPLlist(i)
            AddHandler MPLinterfaceList(i).DecisionMade, AddressOf CheckMPLChoices
            With MPLlist(i)
                .Height = Settings.MPLChoiceItemHeight
                .Width = Settings.MPLChoiceItemWidth


                .Location = New Point(Center - .Width / 2, Settings.MPLChoiceListOffset + i * (.Height - 1))

                'If Settings.DiscountingElicitation < BUNDLING_K1_FREE_RANGE Then
                '    .Location = New Point(Center - .Width / 2, j + i * (.Height - 1))
                'Else
                '    Dim lblLine As Label = New Label
                '    lblLine.Name = "lblLine"
                '    lblLine.Height = 3
                '    lblLine.BorderStyle = BorderStyle.Fixed3D
                '    lblLine.Width = 2 * .Width + 150
                '    If Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
                '        lblLine.Location = New Point(Center - .Width - 75, j - 5)
                '        If i < Settings.DiscountingRows Then
                '            .Location = New Point(Center - .Width - 50, j + i * (.Height - 1 + 10))
                '            lblLine.Location = New Point(Center - .Width - 75, j + i * (.Height - 1 + 10) + (.Height - 1) + 5)
                '        Else
                '            Dim lbl As Label = New Label
                '            lbl.Name = "lblAnd"
                '            lbl.Text = "AND"
                '            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                '            lbl.AutoSize = True
                '            'lbl.BorderStyle = BorderStyle.FixedSingle
                '            lbl.Location = New Point(Center - lbl.Width / 3, j + .Height / 2 - lbl.Height / 2 + (i - List.Count / 2) * (.Height - 1 + 10))
                '            tabSubjectDisplay.Controls.Add(lbl)
                '            .Location = New Point(Center + 50, j + (i - List.Count / 2) * (.Height - 1 + 10))
                '        End If
                '        tabSubjectDisplay.Controls.Add(lblLine)
                '    End If
                '    If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
                '        lblLine.Width = 3 * .Width + 250
                '        lblLine.Location = New Point(Center - 1.5 * .Width - 125, j - 5)
                '        If i < Settings.DiscountingRows Then
                '            .Location = New Point(Center - 1.5 * .Width - 100, j + i * (.Height - 1 + 10))
                '            lblLine.Location = New Point(Center - 1.5 * .Width - 125, j + i * (.Height - 1 + 10) + (.Height - 1) + 5)
                '        ElseIf i < 2 * Settings.DiscountingRows Then
                '            Dim lbl As Label = New Label
                '            lbl.Name = "lblAnd"
                '            lbl.Text = "AND"
                '            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                '            lbl.AutoSize = True
                '            'lbl.BorderStyle = BorderStyle.FixedSingle
                '            lbl.Location = New Point(Center - 0.5 * .Width - 50 - lbl.Width / 4, j + .Height / 2 - lbl.Height / 2 + (i - List.Count / 3) * (.Height - 1 + 10))
                '            tabSubjectDisplay.Controls.Add(lbl)
                '            .Location = New Point(Center - 0.5 * .Width, j + (i - List.Count / 3) * (.Height - 1 + 10))
                '        Else
                '            Dim lbl As Label = New Label
                '            lbl.Name = "lblAnd"
                '            lbl.Text = "AND"
                '            lbl.Font = New Font(DisplayFont.Name, DisplayFont.Size, FontStyle.Bold)
                '            lbl.AutoSize = True
                '            'lbl.BorderStyle = BorderStyle.FixedSingle
                '            lbl.Location = New Point(Center + 0.5 * .Width + 50 - lbl.Width / 4, j + .Height / 2 - lbl.Height / 2 + (i - List.Count * 2 / 3) * (.Height - 1 + 10))
                '            tabSubjectDisplay.Controls.Add(lbl)
                '            .Location = New Point(Center + 0.5 * .Width + 100, j + (i - List.Count * 2 / 3) * (.Height - 1 + 10))

                '        End If
                '        tabSubjectDisplay.Controls.Add(lblLine)
                '    End If
                'End If

                .Visible = False
                tabSubjectDisplay.Controls.Add(MPLlist(i))
            End With
        Next

        'Next


        'place column headers


        lblLeft.Font = New Font(DisplayFont.Name, DisplayFont.Size + 4, DisplayFont.Style)
        lblLeft.Location = New Point(MPLlist(0).Location.X + (MPLlist(0).Width - 225) * (0.45 / 2) - lblLeft.Width / 2, MPLlist(0).Location.Y - 25)
        lblLeft.Visible = True


        lblRight.Font = New Font(DisplayFont.Name, DisplayFont.Size + 4, DisplayFont.Style)
        lblRight.Location = New Point(MPLlist(0).Location.X + (MPLlist(0).Width - 225) * 0.775 - lblRight.Width / 2, MPLlist(0).Location.Y - 25)
        lblRight.Visible = True

        lblRound1.Font = New Font(DisplayFont.Name, DisplayFont.Size + 2, DisplayFont.Style)
        lblRound1.Location = New Point(MPLlist(0).Location.X + MPLlist(0).Width - 187.5 - lblRound1.Width / 2, MPLlist(0).Location.Y - 25)
        If p.AtemporalMPLParas(0).numberofrounds < 1 Then lblRound1.Visible = False Else lblRound1.Visible = True

        lblRound2.Font = New Font(DisplayFont.Name, DisplayFont.Size + 2, DisplayFont.Style)
        lblRound2.Location = New Point(MPLlist(0).Location.X + MPLlist(0).Width - 112.5 - lblRound2.Width / 2, MPLlist(0).Location.Y - 25)
        If p.AtemporalMPLParas(0).numberofrounds < 2 Then lblRound2.Visible = False Else lblRound2.Visible = True

        lblRound3.Font = New Font(DisplayFont.Name, DisplayFont.Size + 2, DisplayFont.Style)
        lblRound3.Location = New Point(MPLlist(0).Location.X + MPLlist(0).Width - 37.5 - lblRound3.Width / 2, MPLlist(0).Location.Y - 25)
        If p.AtemporalMPLParas(0).numberofrounds < 3 Then lblRound3.Visible = False Else lblRound3.Visible = True

        'place confirm and cancel widgets underneath choices
        With lblConfirm
            If Settings.LowResolution = True Then
                j = 10
            Else
                j = 30
            End If
            .Font = DisplayFont
            .Location = New Point(Center - .Width / 2, MPLlist(MPLlist.Count - 1).Location.Y + MPLlist(MPLlist.Count - 1).Height + j)
            .Visible = False
        End With

        With btnConfirm
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Font = DisplayFont
            .Enabled = False
            .Location = New Point(Center - .Width - 10, lblConfirm.Location.Y + lblConfirm.Height + 1)
            .Visible = False
        End With

        With btnCancel
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Font = DisplayFont
            .Enabled = False
            .Location = New Point(Center + 10, lblConfirm.Location.Y + lblConfirm.Height + 1)
            .Visible = False
        End With

        'lblWait.Visible = False

        'ts = New TimeSpan(24 * p.DiscountingParas.Item(0).Ldays, 0, 0)
        'SoonerDate = Now + ts
        ''Horizon = CInt(txtHorizon.Text) 'in weeks
        'ts = New TimeSpan(24 * p.DiscountingParas.Item(0).Rdays, 0, 0)
        'LaterDate = Now + ts

        'd(0).Date = New DateTime(SoonerDate.Year, SoonerDate.Month, SoonerDate.Day)
        'd(0).BoldedDate = True
        'd(0).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)

        'd(1).Date = New DateTime(LaterDate.Year, LaterDate.Month, LaterDate.Day)
        'd(1).BoldedDate = True
        'd(1).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)

        'If Settings.DiscountingElicitation >= BUNDLING_K1_FREE_RANGE Then
        '    ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count / 2).Ldays, 0, 0)
        '    SoonerDateB = Now + ts
        '    ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count / 2).Rdays, 0, 0)
        '    LaterDateB = Now + ts

        '    d(2).Date = New DateTime(SoonerDateB.Year, SoonerDateB.Month, SoonerDateB.Day)
        '    d(2).BoldedDate = True
        '    d(2).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB)

        '    d(3).Date = New DateTime(LaterDateB.Year, LaterDateB.Month, LaterDateB.Day)
        '    d(3).BoldedDate = True
        '    d(3).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColorB)
        'End If

        'If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
        '    ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count * 2 / 3).Ldays, 0, 0)
        '    SoonerDateC = Now + ts
        '    ts = New TimeSpan(24 * p.DiscountingParas.Item(List.Count * 2 / 3).Rdays, 0, 0)
        '    LaterDateC = Now + ts

        '    d(4).Date = New DateTime(SoonerDateC.Year, SoonerDateC.Month, SoonerDateC.Day)
        '    d(4).BoldedDate = True
        '    d(4).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC)

        '    d(5).Date = New DateTime(LaterDateC.Year, LaterDateC.Month, LaterDateC.Day)
        '    d(5).BoldedDate = True
        '    d(5).BackColor1 = ColorTranslator.FromHtml(Settings.DiscountingLaterColorC)
        'End If

        ''highlight dates; each calendar is locked, so each date will show on only one calendar
        '' and determine which calendars will be visible
        'For i = 0 To MaxMonths
        '    With cmCalendar(i)
        '        .ResetDateInfo()
        '        .AddDateInfo(d)
        '        If Settings.DiscountingShowCalendar = True Then 'And .ActiveMonth.Month <= LaterDate.Month Then
        '            .Visible = True
        '        Else
        '            .Visible = False
        '        End If

        '    End With
        'Next

        'display date labels
        'position weeks first, because they are based off of list(0) below, and then date is relative to weeks placement
        'but then, we have to come back to weeks labels, a their width is determined by dates widths


        'Dim o As DiscountingParameters = p.DiscountingParas.Item(0)
        'With lblSoonerDate
        '    .Text = SoonerDate.ToString("D")
        '    If o.Ldays = 0 Then
        '        .Text = .Text & vbCrLf & "(Today)"
        '    Else
        '        .Text = .Text & vbCrLf & "(" & o.Ldays.ToString & " day"
        '        If o.Ldays > 1 Then .Text = .Text & "s"
        '        .Text = .Text & " from today)"
        '    End If

        '    .Font = DisplayFont

        '    .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        '    '.Location = New Point(List(0).Location.X + 0.225 * List(0).Width - .Width / 2, cmCalendar(0).Location.Y + cmCalendar(0).Height + 30)
        '    If Settings.LowResolution = True Then
        '        i = 10
        '    Else
        '        i = 30
        '    End If

        '    .Location = New Point(List(0).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '    .Width = 0.45 * List(0).Width
        '    .Height = Settings.DiscountingChoiceItemHeight
        '    .TextAlign = ContentAlignment.MiddleCenter
        '    .Visible = True
        'End With

        'With lblLaterDate
        '    .Text = LaterDate.ToString("D")


        '    If o.Rdays = 0 Then
        '        .Text = .Text & vbCrLf & "(Today)"
        '    Else
        '        .Text = .Text & vbCrLf & "(" & o.Rdays.ToString & " day"
        '        If o.Rdays > 1 Then .Text = .Text & "s"
        '        .Text = .Text & " from today)"
        '    End If
        '    .Font = DisplayFont
        '    .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        '    .Location = New Point(List(0).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '    .Width = 0.45 * List(0).Width
        '    .Height = Settings.DiscountingChoiceItemHeight
        '    .TextAlign = ContentAlignment.MiddleCenter
        '    .Visible = True
        'End With



        'If Settings.DiscountingElicitation >= BUNDLING_K1_FREE_RANGE Then
        '    Dim lbl As Label
        '    lbl = New Label
        '    o = New DiscountingParameters
        '    o = p.DiscountingParas.Item(List.Count / 2)
        '    With lbl
        '        .Name = "lblDate"
        '        .Text = SoonerDateB.ToString("D")
        '        .Font = DisplayFont
        '        .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB)
        '        .Location = New Point(List(List.Count / 2).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '        .Width = 0.45 * List(List.Count / 2).Width
        '        .Height = Settings.DiscountingChoiceItemHeight

        '        If o.Ldays = 0 Then
        '            .Text = .Text & vbCrLf & "(Today)"
        '        Else
        '            .Text = .Text & vbCrLf & "(" + o.Ldays.ToString + " day"
        '            If o.Ldays > 1 Then .Text = .Text + "s"
        '            .Text = .Text + " from today)"
        '        End If
        '        .Font = DisplayFont
        '        '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        '        '.Location = New Point(lblSoonerDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
        '        '.Width = lblSoonerDate.Width
        '        '.Height = lblSoonerDate.Height + 4
        '        '.TextAlign = ContentAlignment.TopCenter

        '        .TextAlign = ContentAlignment.MiddleCenter
        '        tabSubjectDisplay.Controls.Add(lbl)
        '    End With

        '    lbl = New Label
        '    With lbl
        '        .Name = "lblDate"
        '        .Text = LaterDateB.ToString("D")
        '        .Font = DisplayFont
        '        .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColorB)
        '        .Location = New Point(List(List.Count / 2).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '        .Width = 0.45 * List(0).Width
        '        .Height = Settings.DiscountingChoiceItemHeight
        '        .TextAlign = ContentAlignment.TopCenter

        '        If o.Rdays = 0 Then
        '            .Text = .Text & vbCrLf & "(Today)"
        '        Else
        '            .Text = .Text & vbCrLf & "(" + o.Rdays.ToString + " day"
        '            If o.Rdays > 1 Then .Text = .Text + "s"
        '            .Text = .Text + " from today)"
        '        End If
        '        '.Text = "(" + CStr(Horizon) + " week"
        '        'If Horizon > 1 Then .Text = .Text + "s"
        '        '.Text = .Text + " from today)"
        '        '.Font = DisplayFont
        '        '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        '        '.Location = New Point(lblLaterDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
        '        '.Width = lblLaterDate.Width
        '        '.Height = lblLaterDate.Height + 4
        '        .TextAlign = ContentAlignment.MiddleCenter
        '        tabSubjectDisplay.Controls.Add(lbl)
        '    End With

        'End If


        'If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
        '    Dim lbl As Label
        '    lbl = New Label
        '    o = New DiscountingParameters
        '    o = p.DiscountingParas.Item(List.Count * 2 / 3)
        '    With lbl
        '        .Name = "lblDate"
        '        .Text = SoonerDateC.ToString("D")
        '        .Font = DisplayFont
        '        .BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC)
        '        .Location = New Point(List(List.Count * 2 / 3).Location.X, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '        .Width = 0.45 * List(List.Count / 2).Width
        '        .Height = Settings.DiscountingChoiceItemHeight

        '        If o.Ldays = 0 Then
        '            .Text = .Text & vbCrLf & "(Today)"
        '        Else
        '            .Text = .Text & vbCrLf & "(" + o.Ldays.ToString + " day"
        '            If o.Ldays > 1 Then .Text = .Text + "s"
        '            .Text = .Text + " from today)"
        '        End If
        '        .Font = DisplayFont
        '        '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingSoonerColor)
        '        '.Location = New Point(lblSoonerDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
        '        '.Width = lblSoonerDate.Width
        '        '.Height = lblSoonerDate.Height + 4
        '        '.TextAlign = ContentAlignment.TopCenter

        '        .TextAlign = ContentAlignment.MiddleCenter
        '        tabSubjectDisplay.Controls.Add(lbl)
        '    End With

        '    lbl = New Label
        '    With lbl
        '        .Name = "lblDate"
        '        .Text = LaterDateC.ToString("D")
        '        .Font = DisplayFont
        '        .BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColorC)
        '        .Location = New Point(List(List.Count * 2 / 3).Location.X + 0.55 * List(0).Width, cmCalendar(0).Location.Y + cmCalendar(0).Height + i)
        '        .Width = 0.45 * List(0).Width
        '        .Height = Settings.DiscountingChoiceItemHeight
        '        .TextAlign = ContentAlignment.TopCenter

        '        If o.Rdays = 0 Then
        '            .Text = .Text & vbCrLf & "(Today)"
        '        Else
        '            .Text = .Text & vbCrLf & "(" + o.Rdays.ToString + " day"
        '            If o.Rdays > 1 Then .Text = .Text + "s"
        '            .Text = .Text + " from today)"
        '        End If
        '        '.Text = "(" + CStr(Horizon) + " week"
        '        'If Horizon > 1 Then .Text = .Text + "s"
        '        '.Text = .Text + " from today)"
        '        '.Font = DisplayFont
        '        '.BackColor = ColorTranslator.FromHtml(Settings.DiscountingLaterColor)
        '        '.Location = New Point(lblLaterDate.Location.X, lblSoonerDate.Location.Y + lblSoonerDate.Height)
        '        '.Width = lblLaterDate.Width
        '        '.Height = lblLaterDate.Height + 4
        '        .TextAlign = ContentAlignment.MiddleCenter
        '        tabSubjectDisplay.Controls.Add(lbl)
        '    End With

        'End If





        'cancel previous choices
        CancelChoices()

        'show the list items
        i = 0
        For Each L As AMPLControlInterface In MPLlist
            'If Settings.DiscountingElicitation = OPEN Then  'I want to do this before initialize, because some of the initialization of open type depends on it
            '    If Settings.DiscountingOpenDecisionSooner = True Then
            '        L.OpenDecisionType(1)
            '    Else
            '        L.OpenDecisionType(2)
            '    End If
            'End If
            L.Initialize(p.AtemporalMPLParas.Item(i))


            L.SetIndex(i)     'this value let's me know which List item raised the decisionMade event
            L.SetFont(DisplayFont)
            L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColor))
            L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColor))

            'If (Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED) And i >= List.Count / 2 Then
            '    L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB))
            '    L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorB))
            'End If

            'If Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
            '    If i >= List.Count / 3 And i < List.Count * 2 / 3 Then
            '        L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorB))
            '        L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorB))
            '    End If
            '    If i >= List.Count * 2 / 3 Then
            '        L.SetSoonerColor(ColorTranslator.FromHtml(Settings.DiscountingSoonerColorC))
            '        L.SetLaterColor(ColorTranslator.FromHtml(Settings.DiscountingLaterColorC))
            '    End If
            'End If


            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(MPLlist(i), AMPLControlInterface).SetDecision(p.Decision.Item(i))
            End If

            i += 1

            L.SetVisible(True)
        Next

        CType(MPLlist(0), AMPLControlInterface).ValidateDecision()


        'make the confirmation widets visible, as they were made invisible at form load... IF not an old decision...
        lblConfirm.Visible = Not (p.isDecisionMade)
        btnConfirm.Visible = Not (p.isDecisionMade)
        btnCancel.Visible = Not (p.isDecisionMade)

        'add buttons for dice roll next to each choice IF an old decision

        If p.isDecisionMade = True Then
            ReviewType = AMPL

            'ReDim rbDice(List.GetUpperBound(0))
            'For i = 0 To rbDice.GetUpperBound(0)
            ReDim rbDice(Settings.MPLRows - 1)
            For i = 0 To Settings.MPLRows - 1
                rbDice(i) = New RadioButton
                AddHandler rbDice(i).CheckedChanged, AddressOf rbDice_CheckedChanged
                tabSubjectDisplay.Controls.Add(rbDice(i))
                With rbDice(i)
                    .Appearance = Appearance.Button
                    .Font = DisplayFont
                    .AutoSize = True
                    .Text = "Roll " & (i + 1).ToString
                    '.Width = 50
                    '.Height = List(i).Height
                    .Location = New Point(MPLlist(i).Location.X - .Width - 0, MPLlist(i).Location.Y + (MPLlist(i).Height - .Height) / 2)

                End With

            Next
        End If





    End Sub




    Private Sub rbDice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ReviewType = DISCOUNTING Then
            For i = 0 To rbDice.Length - 1
                If sender.Equals(rbDice(i)) Then
                    List(i).BackColor = Color.SteelBlue
                    If Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Then
                        List(i + List.Count / 2).BackColor = Color.SteelBlue
                    End If
                Else
                    List(i).BackColor = Me.BackColor
                    If Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Then
                        List(i + List.Count / 2).BackColor = Me.BackColor
                    End If
                End If
            Next
        End If
        If ReviewType = AMPL Then
            For i = 0 To rbDice.Length - 1
                If sender.Equals(rbDice(i)) Then
                    MPLlist(i).BackColor = Color.DarkSeaGreen
                Else
                    MPLlist(i).BackColor = Me.BackColor
                End If

            Next
        End If

    End Sub



    Private Sub DrawRisk(ByVal p As RiskTimeBeliefLibrary.Period)

        If Settings.RiskElicitation = Constants.RISK_SINGLE Then
            RiskChoice = New ucRiskDecision()
            RiskInterface = RiskChoice      'what is purpose of this line?
            With RiskChoice
                .Visible = False
                .Height = RiskChoiceItemHeight
                .Width = RiskChoiceItemWidth
                .Location = New Point(Center - .Width / 2, 40)
                tabSubjectDisplay.Controls.Add(RiskChoice)
            End With
            With CType(RiskChoice, RiskControlInterface)
                .Initialize(p.RiskParas.Item(0))
                .SetPrize(Settings.RiskPrize)
                .SetFont(DisplayFont)
                .SetColors(ColorTranslator.FromHtml(Settings.RiskColor1), ColorTranslator.FromHtml(Settings.RiskColor2), ColorTranslator.FromHtml(Settings.RiskColor3), ColorTranslator.FromHtml(Settings.RiskColor4))
                .SetShowDiceInfo(Settings.RiskShowDiceInfoDuringDecision)
                If Settings.RiskShowGraphs = False Then 'is this ever used?
                    .DestroyPictures()
                Else
                    .CreatePictures(Settings.RiskDiameter)
                    .DisplayLotteries()
                End If
            End With
            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(RiskChoice, RiskControlInterface).SetDecision(p.Decision.Item(0))
            End If
            RiskChoice.Visible = True
            lblTitle.Visible = True
            lblTitle.Text = CType(p.RiskParas.Item(0), RiskParameters).Title
            lblTitle.Font = New Font(DisplayFont.Name, DisplayFont.Size + 6, DisplayFont.Style)
            lblTitle.Location = New Point(Center - lblTitle.Width / 2, lblCurrentPeriod.Location.Y)
            btnReview.Font = DisplayFont
        ElseIf Settings.RiskElicitation = Constants.RISK_2SIMUL Then

            'add logic here for new risk format...

            RiskChoice = New ucRiskDecision_2simul()
            risk2SimulInterface = RiskChoice
            AddHandler risk2SimulInterface.DecisionMade, AddressOf SimulRiskDecisionsMade
            With RiskChoice
                .Visible = False
                .Height = 900
                .Width = RiskChoiceItemWidth
                .Location = New Point(Center - .Width / 2, 5)
                tabSubjectDisplay.Controls.Add(RiskChoice)
            End With
            With CType(RiskChoice, ciRisk_2simul)
                .Initialize(p.RiskParas.Item(0), p.RiskParas.Item(1))
                .SetFont(DisplayFont)
                .SetColors(ColorTranslator.FromHtml(Settings.RiskColor1), ColorTranslator.FromHtml(Settings.RiskColor2), ColorTranslator.FromHtml(Settings.RiskColor3), ColorTranslator.FromHtml(Settings.RiskColor4))
                If Settings.RiskShowGraphs = False Then 'is this ever used?
                    .DestroyPictures()
                Else
                    '.CreatePictures(Settings.RiskDiameter)
                    .CreatePictures(Settings.RiskDiameter)
                    .DisplayLotteries()
                End If
            End With
            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(RiskChoice, ciRisk_2simul).SetDecision(p.Decision.Item(0), p.Decision.Item(1))
            End If
            RiskChoice.Visible = True

            'Kevin's Comment add handle for Risk_BAR_SINGLE and Risk_BAR_2SIMUL
        ElseIf Settings.RiskElicitation = Constants.Risk_BAR_SINGLE Then


            RiskChoice = New ucRiskDecisionBar()
            RiskInterface = RiskChoice      'what is purpose of this line?
            With RiskChoice
                .Visible = False
                .Height = RiskChoiceItemHeight
                .Width = RiskChoiceItemWidth
                .Location = New Point(Center - .Width / 2, 50)
                tabSubjectDisplay.Controls.Add(RiskChoice)
            End With
            With CType(RiskChoice, RiskControlInterface)
                .Initialize(p.RiskParas.Item(0))
                .SetFont(DisplayFont)
                .SetColors(ColorTranslator.FromHtml(Settings.RiskColor1), ColorTranslator.FromHtml(Settings.RiskColor2), ColorTranslator.FromHtml(Settings.RiskColor3), ColorTranslator.FromHtml(Settings.RiskColor4))
                If Settings.RiskShowGraphs = False Then 'is this ever used?
                    .DestroyPictures()
                Else
                    .CreatePictures(Settings.RiskDiameter)
                    .DisplayLotteries()
                End If
            End With
            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(RiskChoice, RiskControlInterface).SetDecision(p.Decision.Item(0))
            End If
            RiskChoice.Visible = True
            lblTitle.Visible = True
            lblTitle.Text = CType(p.RiskParas.Item(0), RiskParameters).Title
            lblTitle.Font = New Font(DisplayFont.Name, DisplayFont.Size + 6, DisplayFont.Style)
            lblTitle.Location = New Point(Center - lblTitle.Width / 2, lblCurrentPeriod.Location.Y)
            btnReview.Font = DisplayFont
        ElseIf Settings.RiskElicitation = Constants.Risk_BAR_2SIMUL Then


            'add logic here for new risk format...

            RiskChoice = New ucRiskDecisionBar_2simul()
            risk2SimulInterface = RiskChoice
            AddHandler risk2SimulInterface.DecisionMade, AddressOf SimulRiskDecisionsMade
            With RiskChoice
                .Visible = False
                .Height = 900
                .Width = RiskChoiceItemWidth
                .Location = New Point(Center - .Width / 2, 5)
                tabSubjectDisplay.Controls.Add(RiskChoice)
            End With
            With CType(RiskChoice, ciRisk_2simul)
                .Initialize(p.RiskParas.Item(0), p.RiskParas.Item(1))
                .SetFont(DisplayFont)
                .SetColors(ColorTranslator.FromHtml(Settings.RiskColor1), ColorTranslator.FromHtml(Settings.RiskColor2), ColorTranslator.FromHtml(Settings.RiskColor3), ColorTranslator.FromHtml(Settings.RiskColor4))
                If Settings.RiskShowGraphs = False Then 'is this ever used?
                    .DestroyPictures()
                Else
                    '.CreatePictures(Settings.RiskDiameter)
                    .CreatePictures(Settings.RiskDiameter)
                    .DisplayLotteries()
                End If
            End With
            If p.isDecisionMade = True Then 'this is an exisiting old decision to show, so do not allow subject input 
                CType(RiskChoice, ciRisk_2simul).SetDecision(p.Decision.Item(0), p.Decision.Item(1))
            End If
            RiskChoice.Visible = True
        End If
        ' End Kevin's modification


    End Sub

    Public Sub SimulRiskDecisionsMade()
        EndOfPeriod()
    End Sub

    Private Sub DrawSurvey(ByVal url As String)
        Survey = New ucWebSurvey()
        SurveyInterface = Survey
        With Survey
            '.Height = RiskChoiceItemHeight
            .Height = Me.Height - 125
            '.Width = RiskChoiceItemWidth
            .Width = Me.Width
            .Location = New Point(Center - .Width / 2, 50)
        End With
        tabSubjectDisplay.Controls.Add(Survey)
        With CType(Survey, WebSurveyControlInterface)
            .Initialize(url)
            .SetSurveyOverURLKeyword(Settings.SurveyOverURLKeyword)
        End With
    End Sub

    Private Sub ClearScreen()
        Dim i As Integer
        'tabSubjectDisplay.Controls.Remove(RiskChoice)
        Dim ctrl As Object
        For i = tabSubjectDisplay.Controls.Count - 1 To 0 Step -1
            ctrl = tabSubjectDisplay.Controls.Item(i)
            If TypeOf (ctrl) Is RiskControlInterface Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is ciRisk_2simul Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is DiscountingControlInterface Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is Pabo.Calendar.MonthCalendar Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is BeliefControlInterface Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is WebSurveyControlInterface Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is RadioButton Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is ucRiskPayAll Then tabSubjectDisplay.Controls.Remove(ctrl)
            If ctrl.name = "lblLine" Then tabSubjectDisplay.Controls.Remove(ctrl)
            If ctrl.name = "lblAnd" Then tabSubjectDisplay.Controls.Remove(ctrl)
            If ctrl.name = "lblDate" Then tabSubjectDisplay.Controls.Remove(ctrl)
            If TypeOf (ctrl) Is AMPLControlInterface Then tabSubjectDisplay.Controls.Remove(ctrl)
        Next
        'For Each L In List
        '    tabSubjectDisplay.Controls.Remove(L)
        'Next
        'For i = 0 To MaxMonths
        '    tabSubjectDisplay.Controls.Remove(cmCalendar(i))
        'Next
        lblSoonerDate.Visible = False
        lblSoonerWeeks.Visible = False
        lblLaterDate.Visible = False
        lblLaterWeeks.Visible = False
        lblConfirm.Visible = False
        btnConfirm.Visible = False
        btnCancel.Visible = False
        lblPause.Visible = False
        btnPause.Visible = False

        btnReview.Visible = False

        lblTitle.Visible = False

        btnBpreset1.Visible = False
        btnBpreset2.Visible = False
        btnBpreset3.Visible = False
        btnBpreset4.Visible = False
        btnBpreset5.Visible = False

        lblLeft.Visible = False
        lblRight.Visible = False
        lblSummary.Visible = False
        lblRound1.Visible = False
        lblRound2.Visible = False
        lblRound3.Visible = False

    End Sub


    Private Sub tabSubjectDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabSubjectDisplay.Click

    End Sub

    Private Sub btnStartPeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartPeriods.Click
        'Center = TabControl1.Width / 2
        Center = Me.Width / 2

        ReDim MPLlist(Settings.MPLrows - 1)

        'set number of discounting questions per screen
        ' do this here early, because the CreatePeriodSequence function needs to know...
        If Settings.DiscountingElicitation = BINARY Then
            ReDim List(Settings.DiscountingRows - 1)
            'NumListItems = 4
        ElseIf Settings.DiscountingElicitation = PORTFOLIO Then
            ReDim List(Settings.DiscountingRows - 1)
            'NumListItems = 4
        ElseIf Settings.DiscountingElicitation = OPEN Then
            ReDim List(0)
            'NumListItems = 1
        ElseIf Settings.DiscountingElicitation = BUNDLING_K1_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K1_FORCE_FED Then
            ReDim List(2 * Settings.DiscountingRows - 1)
        ElseIf Settings.DiscountingElicitation = BUNDLING_K2_FREE_RANGE Or Settings.DiscountingElicitation = BUNDLING_K2_FORCE_FED Then
            ReDim List(3 * Settings.DiscountingRows - 1)
        End If
        CurrentPeriod = 1
        Periods = CreatePeriodSequence()


        If (Not System.IO.Directory.Exists(Application.StartupPath & "\RDB data")) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\RDB data\")
        End If


        'create file (with header) for period results
        ResultsFile = Application.StartupPath & "\RDB data\" & "RiskTime results _ " & SubjectID & ".csv"


        If File.Exists(ResultsFile) Then ResultsFileExists = True

        'ResultsFile = Application.StartupPath & "\" & "aa.txt"
        Dim FileWriter As New System.IO.StreamWriter(ResultsFile, True)
        FileWriter.WriteLine(Periods(0).GetHeaders)
        FileWriter.Close()

        DrawPeriod(Periods(CurrentPeriod - 1))





        'for testing
        txtTest.Text = ""
    End Sub







    Private Sub btnPeriodsUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodsUp.Click
        Dim i As Integer = dgvPeriods.CurrentRow.Index
        If i > 0 Then
            Dim temp_c1 As String = dgvPeriods.Rows(i).Cells(1).Value
            Dim temp_c2 As String = dgvPeriods.Rows(i).Cells(2).Value
            dgvPeriods.Rows(i).Cells(1).Value = dgvPeriods.Rows(i - 1).Cells(1).Value
            dgvPeriods.Rows(i).Cells(2).Value = dgvPeriods.Rows(i - 1).Cells(2).Value
            dgvPeriods.Rows(i - 1).Cells(1).Value = temp_c1
            dgvPeriods.Rows(i - 1).Cells(2).Value = temp_c2

            dgvPeriods.ClearSelection()
            dgvPeriods.CurrentCell = dgvPeriods.Rows(i - 1).Cells(0)
            dgvPeriods.Rows(i - 1).Selected = True
        End If
    End Sub

    Private Sub btnPeriodsDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodsDown.Click
        Dim i As Integer = dgvPeriods.CurrentRow.Index
        If i < dgvPeriods.Rows.Count - 1 Then
            Dim temp_c1 As String = dgvPeriods.Rows(i).Cells(1).Value
            Dim temp_c2 As String = dgvPeriods.Rows(i).Cells(2).Value
            dgvPeriods.Rows(i).Cells(1).Value = dgvPeriods.Rows(i + 1).Cells(1).Value
            dgvPeriods.Rows(i).Cells(2).Value = dgvPeriods.Rows(i + 1).Cells(2).Value
            dgvPeriods.Rows(i + 1).Cells(1).Value = temp_c1
            dgvPeriods.Rows(i + 1).Cells(2).Value = temp_c2

            dgvPeriods.ClearSelection()
            dgvPeriods.CurrentCell = dgvPeriods.Rows(i + 1).Cells(0)
            dgvPeriods.Rows(i + 1).Selected = True
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        If PasswordManager.VerifyPasswordFromFile(Stage, Application.StartupPath & "\" & "pw.txt", Application.StartupPath & "\" & "answer.txt") = PasswordManager.VALIDATION_OK Then
            Paused = False
            DrawPeriod(Periods(CurrentPeriod - 1))
        End If
    End Sub


    Private Sub frmRiskTimeServer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.Alt = True And e.KeyCode = Keys.P And Paused = True Then
            'Dim p As String = InputBox("enter past period to view (1 to " & CurrentPeriod - 1 & ")")
            Dim HistoryForm As New MyCustomMessageBox

            Dim p As Integer = HistoryForm.ShowAsMessageBox(PerSeqDetails, DisplayFont)
            Try
                If p > 0 Then
                    ShowOldPeriod(Periods(CInt(p) - 1))
                ElseIf p = -1 Then
                    ShowPayAllRisk()
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Function getRiskPayAllHeader() As Integer()
        Dim p As Period
        Dim riskPara As RiskParameters
        Dim headers As New List(Of Integer)
        For i As Integer = 0 To PerSeqDetails.CurrentPeriod - 2
            p = Periods(i)
            If (p.Type = RISK) Then

                riskPara = p.RiskParas.Item(0)

                For h As Integer = 1 To riskPara.NumEvents
                    headers.Add(h)
                Next
                Exit For
            End If
        Next
        Return headers.ToArray

    End Function
    Private Sub ShowPayAllRisk()


        Dim p As Period
        Dim dec As Integer
        Dim check As Boolean = False
        Dim headersText As New List(Of String)
        Dim riskPara As RiskParameters
        Dim headers As Integer() = getRiskPayAllHeader()
        Dim rows As List(Of String)
        Dim data As New List(Of String())
        Dim sum(headers.Length) As Single
        Dim value As Single
        For i As Integer = 0 To PerSeqDetails.CurrentPeriod - 2
            p = Periods(i)
            If (p.Type = RISK And p.isDecisionMade) Then
                rows = New List(Of String)
                riskPara = p.RiskParas.Item(0)
                If (Not check) Then

                    headersText.Add("Period")
                    If headers(0) = 1 Then
                        headersText.Add(riskPara.RollPrefix + headers(0).ToString)
                    Else
                        headersText.Add(riskPara.RollPrefix + "1 to " + headers(0).ToString)
                    End If
                    For h As Integer = 1 To headers.Length - 1
                        If headers(h) <> headers(h - 1) Then
                            headersText.Add(riskPara.RollPrefix + headers(h).ToString)
                        Else
                            headersText.Add(riskPara.RollPrefix + headers(h - 1) + " to " + headers(0).ToString)
                        End If
                    Next
                    check = True
                End If

                dec = p.Decision.Item(0)
                rows.Add(data.Count + 1)
                For s As Integer = 0 To headers.Length - 1
                    If (dec = 0) Then
                        If headers(s) / riskPara.NumEvents * 100 <= riskPara.Lp1 Then
                            value = riskPara.La1
                        ElseIf headers(s) / riskPara.NumEvents * 100 <= riskPara.Lp1 + riskPara.Lp2 Then
                            value = riskPara.La2
                        ElseIf headers(s) / riskPara.NumEvents * 100 <= riskPara.Lp1 + riskPara.Lp2 + riskPara.Lp3 Then
                            value = riskPara.La3
                        Else
                            value = riskPara.La4
                        End If
                    ElseIf dec = 1 Then
                        If headers(s) / riskPara.NumEvents * 100 <= riskPara.Rp1 Then
                            value = riskPara.Ra1
                        ElseIf headers(s) / riskPara.NumEvents * 100 <= riskPara.Rp1 + riskPara.Rp2 Then
                            value = riskPara.Ra2
                        ElseIf headers(s) / riskPara.NumEvents * 100 <= riskPara.Rp1 + riskPara.Rp2 + riskPara.Rp3 Then
                            value = riskPara.Ra3
                        Else
                            value = riskPara.Ra4
                        End If
                    End If



                    'rows.Add(value.ToString)
                    rows.Add(Settings.FormatCurrency(value))
                    sum(s) = sum(s) + value
                Next
                data.Add(rows.ToArray)
            End If
        Next
        rows = New List(Of String)
        rows.Add("Your Earnings")

        For s As Integer = 0 To headers.Length - 1
            'rows.Add(Math.Round(sum(s) / data.Count, 2))
            rows.Add(FormatCurrency(sum(s) / data.Count))
        Next

        data.Insert(0, rows.ToArray)
        Dim payallScreen As New ucRiskPayAll()
        With payallScreen
            .Height = RiskChoiceItemHeight
            .Width = RiskChoiceItemWidth
            .Location = New Point(Center - .Width / 2, 50)
        End With
        payallScreen.setData(headersText.ToArray, data.ToArray)

        ClearScreen()
        lblCurrentPeriod.Text = ""
        tabSubjectDisplay.Controls.Add(payallScreen)
        lblCurrentPeriod.Text = "REVIEW ALL choices"
        With btnReview
            .Location = New Point(lblCurrentPeriod.Location.X, lblCurrentPeriod.Location.Y + lblCurrentPeriod.Height + 5)
            .Visible = True
        End With
    End Sub
    Private Sub ShowOldPeriod(ByVal p As RiskTimeBeliefLibrary.Period)
        ClearScreen()
        lblCurrentPeriod.Text = "REVIEW (choice " & p.PeriodNumber.ToString & ")"
        With btnReview
            .Location = New Point(lblCurrentPeriod.Location.X + lblCurrentPeriod.Width + 10, lblCurrentPeriod.Location.Y)
            .Visible = True
        End With
        If p.Type = RISK Then
            DrawRisk(p)
        ElseIf p.Type = DISCOUNTING Then
            DrawDiscounting(p)
        ElseIf p.Type = BELIEF Then
            DrawBelief(p)
        ElseIf p.Type = AMPL Then
            DrawMPL(p)
        End If




    End Sub




    Private Sub btnReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReview.Click
        If SessionOver = True Then
            EndOfSession()
        Else
            PauseProgress()
        End If
    End Sub

    Private Sub frmRiskTimeServer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus

    End Sub


    Private Sub txtTest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTest.TextChanged

    End Sub

    Private Sub btnBpreset1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBpreset1.Click
        CType(BeliefChoice, BeliefControlInterface).SetPreset(CurrentBeliefPreset1)
    End Sub



    Private Sub btnBpreset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBpreset2.Click
        CType(BeliefChoice, BeliefControlInterface).SetPreset(CurrentBeliefPreset2)
    End Sub

    Private Sub btnBpreset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBpreset3.Click
        CType(BeliefChoice, BeliefControlInterface).SetPreset(CurrentBeliefPreset3)
    End Sub

    Private Sub btnBpreset4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBpreset4.Click
        CType(BeliefChoice, BeliefControlInterface).SetPreset(CurrentBeliefPreset4)
    End Sub

    Private Sub btnBpreset5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBpreset5.Click
        CType(BeliefChoice, BeliefControlInterface).SetPreset(CurrentBeliefPreset5)
    End Sub

    Private Sub lblLeft_Click(sender As System.Object, e As System.EventArgs) Handles lblLeft.Click

    End Sub
End Class
























