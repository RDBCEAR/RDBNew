<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRiskTimeServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dlgFont = New System.Windows.Forms.FontDialog()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.tabSubjectDisplay = New System.Windows.Forms.TabPage()
        Me.lblRound3 = New System.Windows.Forms.Label()
        Me.lblRound2 = New System.Windows.Forms.Label()
        Me.lblRound1 = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.btnBpreset5 = New System.Windows.Forms.Button()
        Me.btnBpreset4 = New System.Windows.Forms.Button()
        Me.btnBpreset3 = New System.Windows.Forms.Button()
        Me.btnBpreset2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rbBeliefPreset1 = New System.Windows.Forms.RadioButton()
        Me.btnBpreset1 = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnReview = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.lblPause = New System.Windows.Forms.Label()
        Me.lblCurrentPeriod = New System.Windows.Forms.Label()
        Me.btnStartPeriods = New System.Windows.Forms.Button()
        Me.lblLaterWeeks = New System.Windows.Forms.Label()
        Me.lblSoonerWeeks = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.lblLaterDate = New System.Windows.Forms.Label()
        Me.lblSoonerDate = New System.Windows.Forms.Label()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTest = New System.Windows.Forms.TextBox()
        Me.gbSettings = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.txtNoOfPeriod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStartSession = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoOfSub = New System.Windows.Forms.TextBox()
        Me.btnStartAccept = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.lblDiscountingFile = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabInputFile = New System.Windows.Forms.TabPage()
        Me.gbInputFile = New System.Windows.Forms.GroupBox()
        Me.txtInputFile = New System.Windows.Forms.TextBox()
        Me.gbEditFile = New System.Windows.Forms.GroupBox()
        Me.gbFont = New System.Windows.Forms.GroupBox()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.gbPeriods = New System.Windows.Forms.GroupBox()
        Me.btnPeriodsDown = New System.Windows.Forms.Button()
        Me.btnPeriodsUp = New System.Windows.Forms.Button()
        Me.dgvPeriods = New System.Windows.Forms.DataGridView()
        Me.txtDiscountingPeriods = New System.Windows.Forms.TextBox()
        Me.txtRiskPeriods = New System.Windows.Forms.TextBox()
        Me.cbRiskFirst = New System.Windows.Forms.CheckBox()
        Me.lblDiscountingPeriods = New System.Windows.Forms.Label()
        Me.lblRiskPeriods = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.gbDiscounting = New System.Windows.Forms.GroupBox()
        Me.cbCalendar = New System.Windows.Forms.CheckBox()
        Me.cbAEIR = New System.Windows.Forms.CheckBox()
        Me.gbFormat = New System.Windows.Forms.GroupBox()
        Me.gbOpen = New System.Windows.Forms.GroupBox()
        Me.rbOpenLater = New System.Windows.Forms.RadioButton()
        Me.rbOpenSooner = New System.Windows.Forms.RadioButton()
        Me.rbOpen = New System.Windows.Forms.RadioButton()
        Me.rbPortfolio = New System.Windows.Forms.RadioButton()
        Me.rbBinary = New System.Windows.Forms.RadioButton()
        Me.gbColors = New System.Windows.Forms.GroupBox()
        Me.btnLaterColor = New System.Windows.Forms.Button()
        Me.btnSoonerColor = New System.Windows.Forms.Button()
        Me.pnlColorLater = New System.Windows.Forms.Panel()
        Me.pnlColorSooner = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbRisk = New System.Windows.Forms.GroupBox()
        Me.chkText = New System.Windows.Forms.CheckBox()
        Me.chkGraph = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnColor4 = New System.Windows.Forms.Button()
        Me.btnColor3 = New System.Windows.Forms.Button()
        Me.btnColor2 = New System.Windows.Forms.Button()
        Me.pnlColor2 = New System.Windows.Forms.Panel()
        Me.pnlColor3 = New System.Windows.Forms.Panel()
        Me.pnlColor4 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlColor1 = New System.Windows.Forms.Panel()
        Me.lblColor1 = New System.Windows.Forms.Label()
        Me.btnColor1 = New System.Windows.Forms.Button()
        Me.tbDiameter = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tabSubjectDisplay.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabInputFile.SuspendLayout()
        Me.gbInputFile.SuspendLayout()
        Me.gbEditFile.SuspendLayout()
        Me.gbFont.SuspendLayout()
        Me.gbPeriods.SuspendLayout()
        CType(Me.dgvPeriods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDiscounting.SuspendLayout()
        Me.gbFormat.SuspendLayout()
        Me.gbOpen.SuspendLayout()
        Me.gbColors.SuspendLayout()
        Me.gbRisk.SuspendLayout()
        Me.SuspendLayout()
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "OpenFileDialog1"
        '
        'tabSubjectDisplay
        '
        Me.tabSubjectDisplay.Controls.Add(Me.lblRound3)
        Me.tabSubjectDisplay.Controls.Add(Me.lblRound2)
        Me.tabSubjectDisplay.Controls.Add(Me.lblRound1)
        Me.tabSubjectDisplay.Controls.Add(Me.lblSummary)
        Me.tabSubjectDisplay.Controls.Add(Me.lblRight)
        Me.tabSubjectDisplay.Controls.Add(Me.lblLeft)
        Me.tabSubjectDisplay.Controls.Add(Me.btnBpreset5)
        Me.tabSubjectDisplay.Controls.Add(Me.btnBpreset4)
        Me.tabSubjectDisplay.Controls.Add(Me.btnBpreset3)
        Me.tabSubjectDisplay.Controls.Add(Me.btnBpreset2)
        Me.tabSubjectDisplay.Controls.Add(Me.GroupBox1)
        Me.tabSubjectDisplay.Controls.Add(Me.btnBpreset1)
        Me.tabSubjectDisplay.Controls.Add(Me.lblTitle)
        Me.tabSubjectDisplay.Controls.Add(Me.btnReview)
        Me.tabSubjectDisplay.Controls.Add(Me.btnPause)
        Me.tabSubjectDisplay.Controls.Add(Me.lblPause)
        Me.tabSubjectDisplay.Controls.Add(Me.lblCurrentPeriod)
        Me.tabSubjectDisplay.Controls.Add(Me.btnStartPeriods)
        Me.tabSubjectDisplay.Controls.Add(Me.lblLaterWeeks)
        Me.tabSubjectDisplay.Controls.Add(Me.lblSoonerWeeks)
        Me.tabSubjectDisplay.Controls.Add(Me.btnCancel)
        Me.tabSubjectDisplay.Controls.Add(Me.btnConfirm)
        Me.tabSubjectDisplay.Controls.Add(Me.lblConfirm)
        Me.tabSubjectDisplay.Controls.Add(Me.lblLaterDate)
        Me.tabSubjectDisplay.Controls.Add(Me.lblSoonerDate)
        Me.tabSubjectDisplay.Location = New System.Drawing.Point(4, 22)
        Me.tabSubjectDisplay.Name = "tabSubjectDisplay"
        Me.tabSubjectDisplay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubjectDisplay.Size = New System.Drawing.Size(1568, 832)
        Me.tabSubjectDisplay.TabIndex = 0
        Me.tabSubjectDisplay.Text = "Subject display"
        Me.tabSubjectDisplay.UseVisualStyleBackColor = True
        '
        'lblRound3
        '
        Me.lblRound3.AutoSize = True
        Me.lblRound3.Location = New System.Drawing.Point(1209, 100)
        Me.lblRound3.Name = "lblRound3"
        Me.lblRound3.Size = New System.Drawing.Size(54, 15)
        Me.lblRound3.TabIndex = 29
        Me.lblRound3.Text = "Round 3"
        '
        'lblRound2
        '
        Me.lblRound2.AutoSize = True
        Me.lblRound2.Location = New System.Drawing.Point(1145, 100)
        Me.lblRound2.Name = "lblRound2"
        Me.lblRound2.Size = New System.Drawing.Size(54, 15)
        Me.lblRound2.TabIndex = 28
        Me.lblRound2.Text = "Round 2"
        '
        'lblRound1
        '
        Me.lblRound1.AutoSize = True
        Me.lblRound1.Location = New System.Drawing.Point(1073, 100)
        Me.lblRound1.Name = "lblRound1"
        Me.lblRound1.Size = New System.Drawing.Size(54, 15)
        Me.lblRound1.TabIndex = 27
        Me.lblRound1.Text = "Round 1"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(965, 110)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(60, 15)
        Me.lblSummary.TabIndex = 26
        Me.lblSummary.Text = "Summary"
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(722, 106)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(36, 15)
        Me.lblRight.TabIndex = 25
        Me.lblRight.Text = "Right"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(349, 106)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(27, 15)
        Me.lblLeft.TabIndex = 24
        Me.lblLeft.Text = "Left"
        '
        'btnBpreset5
        '
        Me.btnBpreset5.AutoSize = True
        Me.btnBpreset5.Location = New System.Drawing.Point(26, 320)
        Me.btnBpreset5.Name = "btnBpreset5"
        Me.btnBpreset5.Size = New System.Drawing.Size(109, 27)
        Me.btnBpreset5.TabIndex = 23
        Me.btnBpreset5.Text = "Belief preset 5"
        Me.btnBpreset5.UseVisualStyleBackColor = True
        Me.btnBpreset5.Visible = False
        '
        'btnBpreset4
        '
        Me.btnBpreset4.AutoSize = True
        Me.btnBpreset4.Location = New System.Drawing.Point(26, 270)
        Me.btnBpreset4.Name = "btnBpreset4"
        Me.btnBpreset4.Size = New System.Drawing.Size(109, 27)
        Me.btnBpreset4.TabIndex = 22
        Me.btnBpreset4.Text = "Belief preset 4"
        Me.btnBpreset4.UseVisualStyleBackColor = True
        Me.btnBpreset4.Visible = False
        '
        'btnBpreset3
        '
        Me.btnBpreset3.AutoSize = True
        Me.btnBpreset3.Location = New System.Drawing.Point(26, 220)
        Me.btnBpreset3.Name = "btnBpreset3"
        Me.btnBpreset3.Size = New System.Drawing.Size(109, 27)
        Me.btnBpreset3.TabIndex = 21
        Me.btnBpreset3.Text = "Belief preset 3"
        Me.btnBpreset3.UseVisualStyleBackColor = True
        Me.btnBpreset3.Visible = False
        '
        'btnBpreset2
        '
        Me.btnBpreset2.AutoSize = True
        Me.btnBpreset2.Location = New System.Drawing.Point(26, 170)
        Me.btnBpreset2.Name = "btnBpreset2"
        Me.btnBpreset2.Size = New System.Drawing.Size(109, 27)
        Me.btnBpreset2.TabIndex = 20
        Me.btnBpreset2.Text = "Belief preset 2"
        Me.btnBpreset2.UseVisualStyleBackColor = True
        Me.btnBpreset2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.rbBeliefPreset1)
        Me.GroupBox1.Location = New System.Drawing.Point(281, 443)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 206)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 49)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(100, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rbBeliefPreset1
        '
        Me.rbBeliefPreset1.AutoSize = True
        Me.rbBeliefPreset1.Location = New System.Drawing.Point(7, 25)
        Me.rbBeliefPreset1.Name = "rbBeliefPreset1"
        Me.rbBeliefPreset1.Size = New System.Drawing.Size(62, 19)
        Me.rbBeliefPreset1.TabIndex = 0
        Me.rbBeliefPreset1.TabStop = True
        Me.rbBeliefPreset1.Text = "belief1"
        Me.rbBeliefPreset1.UseVisualStyleBackColor = True
        '
        'btnBpreset1
        '
        Me.btnBpreset1.AutoSize = True
        Me.btnBpreset1.Location = New System.Drawing.Point(26, 120)
        Me.btnBpreset1.Name = "btnBpreset1"
        Me.btnBpreset1.Size = New System.Drawing.Size(109, 27)
        Me.btnBpreset1.TabIndex = 18
        Me.btnBpreset1.Text = "Belief preset 1"
        Me.btnBpreset1.UseVisualStyleBackColor = True
        Me.btnBpreset1.Visible = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(346, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(26, 15)
        Me.lblTitle.TabIndex = 17
        Me.lblTitle.Text = "title"
        '
        'btnReview
        '
        Me.btnReview.AutoSize = True
        Me.btnReview.Location = New System.Drawing.Point(108, 19)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(78, 27)
        Me.btnReview.TabIndex = 16
        Me.btnReview.Text = "Continue"
        Me.btnReview.UseVisualStyleBackColor = True
        Me.btnReview.Visible = False
        '
        'btnPause
        '
        Me.btnPause.AutoSize = True
        Me.btnPause.Location = New System.Drawing.Point(343, 310)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(119, 29)
        Me.btnPause.TabIndex = 15
        Me.btnPause.Text = "Continue"
        Me.btnPause.UseVisualStyleBackColor = True
        Me.btnPause.Visible = False
        '
        'lblPause
        '
        Me.lblPause.AutoSize = True
        Me.lblPause.Location = New System.Drawing.Point(343, 270)
        Me.lblPause.Name = "lblPause"
        Me.lblPause.Size = New System.Drawing.Size(73, 15)
        Me.lblPause.TabIndex = 14
        Me.lblPause.Text = "Please wait."
        Me.lblPause.Visible = False
        '
        'lblCurrentPeriod
        '
        Me.lblCurrentPeriod.AutoSize = True
        Me.lblCurrentPeriod.Location = New System.Drawing.Point(10, 10)
        Me.lblCurrentPeriod.Name = "lblCurrentPeriod"
        Me.lblCurrentPeriod.Size = New System.Drawing.Size(86, 15)
        Me.lblCurrentPeriod.TabIndex = 13
        Me.lblCurrentPeriod.Text = "Current Period"
        '
        'btnStartPeriods
        '
        Me.btnStartPeriods.Location = New System.Drawing.Point(22, 58)
        Me.btnStartPeriods.Name = "btnStartPeriods"
        Me.btnStartPeriods.Size = New System.Drawing.Size(93, 39)
        Me.btnStartPeriods.TabIndex = 12
        Me.btnStartPeriods.Text = "Test Periods"
        Me.btnStartPeriods.UseVisualStyleBackColor = True
        Me.btnStartPeriods.Visible = False
        '
        'lblLaterWeeks
        '
        Me.lblLaterWeeks.Location = New System.Drawing.Point(706, 169)
        Me.lblLaterWeeks.Name = "lblLaterWeeks"
        Me.lblLaterWeeks.Size = New System.Drawing.Size(111, 13)
        Me.lblLaterWeeks.TabIndex = 7
        Me.lblLaterWeeks.Text = "later number of weeks"
        Me.lblLaterWeeks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLaterWeeks.Visible = False
        '
        'lblSoonerWeeks
        '
        Me.lblSoonerWeeks.Location = New System.Drawing.Point(354, 169)
        Me.lblSoonerWeeks.Name = "lblSoonerWeeks"
        Me.lblSoonerWeeks.Size = New System.Drawing.Size(123, 13)
        Me.lblSoonerWeeks.TabIndex = 6
        Me.lblSoonerWeeks.Text = "sooner number of weeks"
        Me.lblSoonerWeeks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSoonerWeeks.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(635, 751)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 29)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(495, 751)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(121, 29)
        Me.btnConfirm.TabIndex = 4
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        Me.btnConfirm.Visible = False
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Location = New System.Drawing.Point(471, 721)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(364, 15)
        Me.lblConfirm.TabIndex = 3
        Me.lblConfirm.Text = "You must make your choices above before you are able to confirm"
        Me.lblConfirm.Visible = False
        '
        'lblLaterDate
        '
        Me.lblLaterDate.Location = New System.Drawing.Point(725, 150)
        Me.lblLaterDate.Name = "lblLaterDate"
        Me.lblLaterDate.Size = New System.Drawing.Size(55, 13)
        Me.lblLaterDate.TabIndex = 2
        Me.lblLaterDate.Text = "Later date"
        Me.lblLaterDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLaterDate.Visible = False
        '
        'lblSoonerDate
        '
        Me.lblSoonerDate.Location = New System.Drawing.Point(353, 150)
        Me.lblSoonerDate.Name = "lblSoonerDate"
        Me.lblSoonerDate.Size = New System.Drawing.Size(63, 13)
        Me.lblSoonerDate.TabIndex = 1
        Me.lblSoonerDate.Text = "sooner date"
        Me.lblSoonerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSoonerDate.Visible = False
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.txtInstructions)
        Me.tabSettings.Controls.Add(Me.Label3)
        Me.tabSettings.Controls.Add(Me.txtTest)
        Me.tabSettings.Controls.Add(Me.gbSettings)
        Me.tabSettings.Controls.Add(Me.GroupBox2)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(1372, 760)
        Me.tabSettings.TabIndex = 1
        Me.tabSettings.Text = "Startup"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'txtInstructions
        '
        Me.txtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructions.Location = New System.Drawing.Point(32, 47)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.ReadOnly = True
        Me.txtInstructions.Size = New System.Drawing.Size(628, 112)
        Me.txtInstructions.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 423)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Testing output"
        '
        'txtTest
        '
        Me.txtTest.Location = New System.Drawing.Point(22, 439)
        Me.txtTest.Multiline = True
        Me.txtTest.Name = "txtTest"
        Me.txtTest.ReadOnly = True
        Me.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTest.Size = New System.Drawing.Size(1280, 464)
        Me.txtTest.TabIndex = 15
        '
        'gbSettings
        '
        Me.gbSettings.Controls.Add(Me.RichTextBox1)
        Me.gbSettings.Controls.Add(Me.txtNoOfPeriod)
        Me.gbSettings.Controls.Add(Me.Label2)
        Me.gbSettings.Controls.Add(Me.btnStartSession)
        Me.gbSettings.Controls.Add(Me.Label1)
        Me.gbSettings.Controls.Add(Me.txtNoOfSub)
        Me.gbSettings.Controls.Add(Me.btnStartAccept)
        Me.gbSettings.Location = New System.Drawing.Point(701, 35)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Size = New System.Drawing.Size(456, 335)
        Me.gbSettings.TabIndex = 1
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "Communications stuff (disabled)"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(20, 191)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(419, 119)
        Me.RichTextBox1.TabIndex = 18
        Me.RichTextBox1.Text = ""
        '
        'txtNoOfPeriod
        '
        Me.txtNoOfPeriod.Location = New System.Drawing.Point(127, 65)
        Me.txtNoOfPeriod.Name = "txtNoOfPeriod"
        Me.txtNoOfPeriod.Size = New System.Drawing.Size(100, 20)
        Me.txtNoOfPeriod.TabIndex = 17
        Me.txtNoOfPeriod.Text = "30"
        Me.txtNoOfPeriod.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Number of Period"
        Me.Label2.Visible = False
        '
        'btnStartSession
        '
        Me.btnStartSession.Location = New System.Drawing.Point(20, 130)
        Me.btnStartSession.Name = "btnStartSession"
        Me.btnStartSession.Size = New System.Drawing.Size(121, 30)
        Me.btnStartSession.TabIndex = 15
        Me.btnStartSession.Text = "Start Session"
        Me.btnStartSession.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Number of subject"
        Me.Label1.Visible = False
        '
        'txtNoOfSub
        '
        Me.txtNoOfSub.Location = New System.Drawing.Point(127, 34)
        Me.txtNoOfSub.Name = "txtNoOfSub"
        Me.txtNoOfSub.Size = New System.Drawing.Size(101, 20)
        Me.txtNoOfSub.TabIndex = 13
        Me.txtNoOfSub.Text = "1"
        Me.txtNoOfSub.Visible = False
        '
        'btnStartAccept
        '
        Me.btnStartAccept.Location = New System.Drawing.Point(20, 93)
        Me.btnStartAccept.Name = "btnStartAccept"
        Me.btnStartAccept.Size = New System.Drawing.Size(121, 31)
        Me.btnStartAccept.TabIndex = 12
        Me.btnStartAccept.Text = "Start Accept"
        Me.btnStartAccept.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOpenFile)
        Me.GroupBox2.Controls.Add(Me.lblDiscountingFile)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 248)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(639, 97)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Input file"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(17, 53)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(57, 21)
        Me.btnOpenFile.TabIndex = 11
        Me.btnOpenFile.Text = "Open file"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'lblDiscountingFile
        '
        Me.lblDiscountingFile.AutoSize = True
        Me.lblDiscountingFile.Location = New System.Drawing.Point(16, 37)
        Me.lblDiscountingFile.Name = "lblDiscountingFile"
        Me.lblDiscountingFile.Size = New System.Drawing.Size(66, 15)
        Me.lblDiscountingFile.TabIndex = 10
        Me.lblDiscountingFile.Text = "File not set"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabSettings)
        Me.TabControl1.Controls.Add(Me.tabInputFile)
        Me.TabControl1.Controls.Add(Me.tabSubjectDisplay)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1380, 786)
        Me.TabControl1.TabIndex = 8
        '
        'tabInputFile
        '
        Me.tabInputFile.Controls.Add(Me.gbInputFile)
        Me.tabInputFile.Controls.Add(Me.gbEditFile)
        Me.tabInputFile.Location = New System.Drawing.Point(4, 22)
        Me.tabInputFile.Name = "tabInputFile"
        Me.tabInputFile.Size = New System.Drawing.Size(1568, 832)
        Me.tabInputFile.TabIndex = 2
        Me.tabInputFile.Text = "Input file settings"
        Me.tabInputFile.UseVisualStyleBackColor = True
        '
        'gbInputFile
        '
        Me.gbInputFile.Controls.Add(Me.txtInputFile)
        Me.gbInputFile.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbInputFile.Location = New System.Drawing.Point(0, 0)
        Me.gbInputFile.Name = "gbInputFile"
        Me.gbInputFile.Size = New System.Drawing.Size(562, 832)
        Me.gbInputFile.TabIndex = 14
        Me.gbInputFile.TabStop = False
        Me.gbInputFile.Text = "GroupBox1"
        '
        'txtInputFile
        '
        Me.txtInputFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputFile.Location = New System.Drawing.Point(8, 35)
        Me.txtInputFile.Multiline = True
        Me.txtInputFile.Name = "txtInputFile"
        Me.txtInputFile.ReadOnly = True
        Me.txtInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInputFile.Size = New System.Drawing.Size(548, 1615)
        Me.txtInputFile.TabIndex = 0
        '
        'gbEditFile
        '
        Me.gbEditFile.Controls.Add(Me.gbFont)
        Me.gbEditFile.Controls.Add(Me.gbPeriods)
        Me.gbEditFile.Controls.Add(Me.btnSaveSettings)
        Me.gbEditFile.Controls.Add(Me.gbDiscounting)
        Me.gbEditFile.Controls.Add(Me.gbRisk)
        Me.gbEditFile.Location = New System.Drawing.Point(613, 16)
        Me.gbEditFile.Name = "gbEditFile"
        Me.gbEditFile.Size = New System.Drawing.Size(656, 775)
        Me.gbEditFile.TabIndex = 13
        Me.gbEditFile.TabStop = False
        Me.gbEditFile.Text = "Edit file"
        Me.gbEditFile.Visible = False
        '
        'gbFont
        '
        Me.gbFont.Controls.Add(Me.btnFont)
        Me.gbFont.Controls.Add(Me.lblFont)
        Me.gbFont.Location = New System.Drawing.Point(313, 19)
        Me.gbFont.Name = "gbFont"
        Me.gbFont.Size = New System.Drawing.Size(256, 93)
        Me.gbFont.TabIndex = 17
        Me.gbFont.TabStop = False
        Me.gbFont.Text = "Subject font"
        '
        'btnFont
        '
        Me.btnFont.AutoSize = True
        Me.btnFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFont.Location = New System.Drawing.Point(9, 64)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(60, 25)
        Me.btnFont.TabIndex = 7
        Me.btnFont.Text = "Change"
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'lblFont
        '
        Me.lblFont.AutoSize = True
        Me.lblFont.Location = New System.Drawing.Point(12, 30)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(74, 15)
        Me.lblFont.TabIndex = 6
        Me.lblFont.Text = "Display Font"
        '
        'gbPeriods
        '
        Me.gbPeriods.Controls.Add(Me.btnPeriodsDown)
        Me.gbPeriods.Controls.Add(Me.btnPeriodsUp)
        Me.gbPeriods.Controls.Add(Me.dgvPeriods)
        Me.gbPeriods.Controls.Add(Me.txtDiscountingPeriods)
        Me.gbPeriods.Controls.Add(Me.txtRiskPeriods)
        Me.gbPeriods.Controls.Add(Me.cbRiskFirst)
        Me.gbPeriods.Controls.Add(Me.lblDiscountingPeriods)
        Me.gbPeriods.Controls.Add(Me.lblRiskPeriods)
        Me.gbPeriods.Location = New System.Drawing.Point(22, 19)
        Me.gbPeriods.Name = "gbPeriods"
        Me.gbPeriods.Size = New System.Drawing.Size(265, 239)
        Me.gbPeriods.TabIndex = 17
        Me.gbPeriods.TabStop = False
        Me.gbPeriods.Text = "Periods"
        '
        'btnPeriodsDown
        '
        Me.btnPeriodsDown.Location = New System.Drawing.Point(195, 95)
        Me.btnPeriodsDown.Name = "btnPeriodsDown"
        Me.btnPeriodsDown.Size = New System.Drawing.Size(44, 24)
        Me.btnPeriodsDown.TabIndex = 7
        Me.btnPeriodsDown.Text = "Down"
        Me.btnPeriodsDown.UseVisualStyleBackColor = True
        '
        'btnPeriodsUp
        '
        Me.btnPeriodsUp.Location = New System.Drawing.Point(195, 19)
        Me.btnPeriodsUp.Name = "btnPeriodsUp"
        Me.btnPeriodsUp.Size = New System.Drawing.Size(44, 24)
        Me.btnPeriodsUp.TabIndex = 6
        Me.btnPeriodsUp.Text = "Up"
        Me.btnPeriodsUp.UseVisualStyleBackColor = True
        '
        'dgvPeriods
        '
        Me.dgvPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeriods.Location = New System.Drawing.Point(8, 19)
        Me.dgvPeriods.Name = "dgvPeriods"
        Me.dgvPeriods.RowTemplate.Height = 24
        Me.dgvPeriods.Size = New System.Drawing.Size(181, 100)
        Me.dgvPeriods.TabIndex = 5
        '
        'txtDiscountingPeriods
        '
        Me.txtDiscountingPeriods.Location = New System.Drawing.Point(154, 170)
        Me.txtDiscountingPeriods.Name = "txtDiscountingPeriods"
        Me.txtDiscountingPeriods.Size = New System.Drawing.Size(35, 20)
        Me.txtDiscountingPeriods.TabIndex = 4
        Me.txtDiscountingPeriods.Text = "1"
        Me.txtDiscountingPeriods.Visible = False
        '
        'txtRiskPeriods
        '
        Me.txtRiskPeriods.Location = New System.Drawing.Point(156, 145)
        Me.txtRiskPeriods.Name = "txtRiskPeriods"
        Me.txtRiskPeriods.Size = New System.Drawing.Size(34, 20)
        Me.txtRiskPeriods.TabIndex = 3
        Me.txtRiskPeriods.Text = "1"
        Me.txtRiskPeriods.Visible = False
        '
        'cbRiskFirst
        '
        Me.cbRiskFirst.AutoSize = True
        Me.cbRiskFirst.Location = New System.Drawing.Point(41, 197)
        Me.cbRiskFirst.Name = "cbRiskFirst"
        Me.cbRiskFirst.Size = New System.Drawing.Size(116, 19)
        Me.cbRiskFirst.TabIndex = 2
        Me.cbRiskFirst.Text = "Risk periods first"
        Me.cbRiskFirst.UseVisualStyleBackColor = True
        Me.cbRiskFirst.Visible = False
        '
        'lblDiscountingPeriods
        '
        Me.lblDiscountingPeriods.AutoSize = True
        Me.lblDiscountingPeriods.Location = New System.Drawing.Point(38, 173)
        Me.lblDiscountingPeriods.Name = "lblDiscountingPeriods"
        Me.lblDiscountingPeriods.Size = New System.Drawing.Size(127, 15)
        Me.lblDiscountingPeriods.TabIndex = 1
        Me.lblDiscountingPeriods.Text = "# discounting periods:"
        Me.lblDiscountingPeriods.Visible = False
        '
        'lblRiskPeriods
        '
        Me.lblRiskPeriods.AutoSize = True
        Me.lblRiskPeriods.Location = New System.Drawing.Point(38, 148)
        Me.lblRiskPeriods.Name = "lblRiskPeriods"
        Me.lblRiskPeriods.Size = New System.Drawing.Size(83, 15)
        Me.lblRiskPeriods.TabIndex = 0
        Me.lblRiskPeriods.Text = "# risk periods:"
        Me.lblRiskPeriods.Visible = False
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(167, 520)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(256, 26)
        Me.btnSaveSettings.TabIndex = 16
        Me.btnSaveSettings.Text = "Save settings to file"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'gbDiscounting
        '
        Me.gbDiscounting.Controls.Add(Me.cbCalendar)
        Me.gbDiscounting.Controls.Add(Me.cbAEIR)
        Me.gbDiscounting.Controls.Add(Me.gbFormat)
        Me.gbDiscounting.Controls.Add(Me.gbColors)
        Me.gbDiscounting.Location = New System.Drawing.Point(313, 141)
        Me.gbDiscounting.Name = "gbDiscounting"
        Me.gbDiscounting.Size = New System.Drawing.Size(256, 334)
        Me.gbDiscounting.TabIndex = 2
        Me.gbDiscounting.TabStop = False
        Me.gbDiscounting.Text = "Discounting"
        '
        'cbCalendar
        '
        Me.cbCalendar.AutoSize = True
        Me.cbCalendar.Checked = True
        Me.cbCalendar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCalendar.Location = New System.Drawing.Point(9, 310)
        Me.cbCalendar.Name = "cbCalendar"
        Me.cbCalendar.Size = New System.Drawing.Size(76, 19)
        Me.cbCalendar.TabIndex = 17
        Me.cbCalendar.Text = "Calendar"
        Me.cbCalendar.UseVisualStyleBackColor = True
        '
        'cbAEIR
        '
        Me.cbAEIR.AutoSize = True
        Me.cbAEIR.Enabled = False
        Me.cbAEIR.Location = New System.Drawing.Point(9, 287)
        Me.cbAEIR.Name = "cbAEIR"
        Me.cbAEIR.Size = New System.Drawing.Size(53, 19)
        Me.cbAEIR.TabIndex = 16
        Me.cbAEIR.Text = "AEIR"
        Me.cbAEIR.UseVisualStyleBackColor = True
        Me.cbAEIR.Visible = False
        '
        'gbFormat
        '
        Me.gbFormat.Controls.Add(Me.gbOpen)
        Me.gbFormat.Controls.Add(Me.rbOpen)
        Me.gbFormat.Controls.Add(Me.rbPortfolio)
        Me.gbFormat.Controls.Add(Me.rbBinary)
        Me.gbFormat.Location = New System.Drawing.Point(6, 131)
        Me.gbFormat.Name = "gbFormat"
        Me.gbFormat.Size = New System.Drawing.Size(167, 150)
        Me.gbFormat.TabIndex = 13
        Me.gbFormat.TabStop = False
        Me.gbFormat.Text = "Response format"
        '
        'gbOpen
        '
        Me.gbOpen.Controls.Add(Me.rbOpenLater)
        Me.gbOpen.Controls.Add(Me.rbOpenSooner)
        Me.gbOpen.Location = New System.Drawing.Point(16, 79)
        Me.gbOpen.Name = "gbOpen"
        Me.gbOpen.Size = New System.Drawing.Size(140, 58)
        Me.gbOpen.TabIndex = 6
        Me.gbOpen.TabStop = False
        Me.gbOpen.Visible = False
        '
        'rbOpenLater
        '
        Me.rbOpenLater.AutoSize = True
        Me.rbOpenLater.Location = New System.Drawing.Point(11, 34)
        Me.rbOpenLater.Name = "rbOpenLater"
        Me.rbOpenLater.Size = New System.Drawing.Size(111, 19)
        Me.rbOpenLater.TabIndex = 1
        Me.rbOpenLater.TabStop = True
        Me.rbOpenLater.Text = "Later date open"
        Me.rbOpenLater.UseVisualStyleBackColor = True
        '
        'rbOpenSooner
        '
        Me.rbOpenSooner.AutoSize = True
        Me.rbOpenSooner.Checked = True
        Me.rbOpenSooner.Location = New System.Drawing.Point(11, 13)
        Me.rbOpenSooner.Name = "rbOpenSooner"
        Me.rbOpenSooner.Size = New System.Drawing.Size(123, 19)
        Me.rbOpenSooner.TabIndex = 0
        Me.rbOpenSooner.TabStop = True
        Me.rbOpenSooner.Text = "Sooner date open"
        Me.rbOpenSooner.UseVisualStyleBackColor = True
        '
        'rbOpen
        '
        Me.rbOpen.AutoSize = True
        Me.rbOpen.Location = New System.Drawing.Point(6, 65)
        Me.rbOpen.Name = "rbOpen"
        Me.rbOpen.Size = New System.Drawing.Size(94, 19)
        Me.rbOpen.TabIndex = 5
        Me.rbOpen.Text = "Open-ended"
        Me.rbOpen.UseVisualStyleBackColor = True
        '
        'rbPortfolio
        '
        Me.rbPortfolio.AutoSize = True
        Me.rbPortfolio.Location = New System.Drawing.Point(6, 42)
        Me.rbPortfolio.Name = "rbPortfolio"
        Me.rbPortfolio.Size = New System.Drawing.Size(109, 19)
        Me.rbPortfolio.TabIndex = 4
        Me.rbPortfolio.Text = "Portfolio choice"
        Me.rbPortfolio.UseVisualStyleBackColor = True
        '
        'rbBinary
        '
        Me.rbBinary.AutoSize = True
        Me.rbBinary.Checked = True
        Me.rbBinary.Location = New System.Drawing.Point(6, 19)
        Me.rbBinary.Name = "rbBinary"
        Me.rbBinary.Size = New System.Drawing.Size(98, 19)
        Me.rbBinary.TabIndex = 3
        Me.rbBinary.TabStop = True
        Me.rbBinary.Text = "Binary choice"
        Me.rbBinary.UseVisualStyleBackColor = True
        '
        'gbColors
        '
        Me.gbColors.Controls.Add(Me.btnLaterColor)
        Me.gbColors.Controls.Add(Me.btnSoonerColor)
        Me.gbColors.Controls.Add(Me.pnlColorLater)
        Me.gbColors.Controls.Add(Me.pnlColorSooner)
        Me.gbColors.Controls.Add(Me.Label7)
        Me.gbColors.Controls.Add(Me.Label8)
        Me.gbColors.Location = New System.Drawing.Point(6, 19)
        Me.gbColors.Name = "gbColors"
        Me.gbColors.Size = New System.Drawing.Size(167, 96)
        Me.gbColors.TabIndex = 11
        Me.gbColors.TabStop = False
        Me.gbColors.Text = "Colors"
        '
        'btnLaterColor
        '
        Me.btnLaterColor.Location = New System.Drawing.Point(82, 66)
        Me.btnLaterColor.Name = "btnLaterColor"
        Me.btnLaterColor.Size = New System.Drawing.Size(75, 20)
        Me.btnLaterColor.TabIndex = 15
        Me.btnLaterColor.Text = "Change"
        Me.btnLaterColor.UseVisualStyleBackColor = True
        '
        'btnSoonerColor
        '
        Me.btnSoonerColor.Location = New System.Drawing.Point(82, 25)
        Me.btnSoonerColor.Name = "btnSoonerColor"
        Me.btnSoonerColor.Size = New System.Drawing.Size(75, 20)
        Me.btnSoonerColor.TabIndex = 14
        Me.btnSoonerColor.Text = "Change"
        Me.btnSoonerColor.UseVisualStyleBackColor = True
        '
        'pnlColorLater
        '
        Me.pnlColorLater.Location = New System.Drawing.Point(46, 56)
        Me.pnlColorLater.Name = "pnlColorLater"
        Me.pnlColorLater.Size = New System.Drawing.Size(30, 30)
        Me.pnlColorLater.TabIndex = 13
        '
        'pnlColorSooner
        '
        Me.pnlColorSooner.Location = New System.Drawing.Point(46, 16)
        Me.pnlColorSooner.Name = "pnlColorSooner"
        Me.pnlColorSooner.Size = New System.Drawing.Size(30, 29)
        Me.pnlColorSooner.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Date 2:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Date 1:"
        '
        'gbRisk
        '
        Me.gbRisk.Controls.Add(Me.chkText)
        Me.gbRisk.Controls.Add(Me.chkGraph)
        Me.gbRisk.Controls.Add(Me.Label12)
        Me.gbRisk.Controls.Add(Me.btnColor4)
        Me.gbRisk.Controls.Add(Me.btnColor3)
        Me.gbRisk.Controls.Add(Me.btnColor2)
        Me.gbRisk.Controls.Add(Me.pnlColor2)
        Me.gbRisk.Controls.Add(Me.pnlColor3)
        Me.gbRisk.Controls.Add(Me.pnlColor4)
        Me.gbRisk.Controls.Add(Me.Label13)
        Me.gbRisk.Controls.Add(Me.Label14)
        Me.gbRisk.Controls.Add(Me.Label15)
        Me.gbRisk.Controls.Add(Me.pnlColor1)
        Me.gbRisk.Controls.Add(Me.lblColor1)
        Me.gbRisk.Controls.Add(Me.btnColor1)
        Me.gbRisk.Controls.Add(Me.tbDiameter)
        Me.gbRisk.Controls.Add(Me.Label16)
        Me.gbRisk.Location = New System.Drawing.Point(22, 264)
        Me.gbRisk.Name = "gbRisk"
        Me.gbRisk.Size = New System.Drawing.Size(265, 250)
        Me.gbRisk.TabIndex = 10
        Me.gbRisk.TabStop = False
        Me.gbRisk.Text = "Risk"
        '
        'chkText
        '
        Me.chkText.AutoSize = True
        Me.chkText.Checked = True
        Me.chkText.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkText.Location = New System.Drawing.Point(9, 223)
        Me.chkText.Name = "chkText"
        Me.chkText.Size = New System.Drawing.Size(79, 19)
        Me.chkText.TabIndex = 24
        Me.chkText.Text = "Show text"
        Me.chkText.UseVisualStyleBackColor = True
        '
        'chkGraph
        '
        Me.chkGraph.AutoSize = True
        Me.chkGraph.Checked = True
        Me.chkGraph.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGraph.Location = New System.Drawing.Point(9, 200)
        Me.chkGraph.Name = "chkGraph"
        Me.chkGraph.Size = New System.Drawing.Size(92, 19)
        Me.chkGraph.TabIndex = 23
        Me.chkGraph.Text = "Show graph"
        Me.chkGraph.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(128, 360)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 15)
        Me.Label12.TabIndex = 19
        '
        'btnColor4
        '
        Me.btnColor4.Location = New System.Drawing.Point(98, 174)
        Me.btnColor4.Name = "btnColor4"
        Me.btnColor4.Size = New System.Drawing.Size(75, 20)
        Me.btnColor4.TabIndex = 17
        Me.btnColor4.Text = "Change"
        Me.btnColor4.UseVisualStyleBackColor = True
        '
        'btnColor3
        '
        Me.btnColor3.Location = New System.Drawing.Point(98, 137)
        Me.btnColor3.Name = "btnColor3"
        Me.btnColor3.Size = New System.Drawing.Size(75, 20)
        Me.btnColor3.TabIndex = 16
        Me.btnColor3.Text = "Change"
        Me.btnColor3.UseVisualStyleBackColor = True
        '
        'btnColor2
        '
        Me.btnColor2.Location = New System.Drawing.Point(98, 100)
        Me.btnColor2.Name = "btnColor2"
        Me.btnColor2.Size = New System.Drawing.Size(75, 20)
        Me.btnColor2.TabIndex = 15
        Me.btnColor2.Text = "Change"
        Me.btnColor2.UseVisualStyleBackColor = True
        '
        'pnlColor2
        '
        Me.pnlColor2.Location = New System.Drawing.Point(55, 90)
        Me.pnlColor2.Name = "pnlColor2"
        Me.pnlColor2.Size = New System.Drawing.Size(30, 30)
        Me.pnlColor2.TabIndex = 12
        '
        'pnlColor3
        '
        Me.pnlColor3.Location = New System.Drawing.Point(55, 126)
        Me.pnlColor3.Name = "pnlColor3"
        Me.pnlColor3.Size = New System.Drawing.Size(30, 31)
        Me.pnlColor3.TabIndex = 12
        '
        'pnlColor4
        '
        Me.pnlColor4.Location = New System.Drawing.Point(55, 164)
        Me.pnlColor4.Name = "pnlColor4"
        Me.pnlColor4.Size = New System.Drawing.Size(30, 30)
        Me.pnlColor4.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 15)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Color 4:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 15)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Color 3:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Color 2:"
        '
        'pnlColor1
        '
        Me.pnlColor1.Location = New System.Drawing.Point(55, 53)
        Me.pnlColor1.Name = "pnlColor1"
        Me.pnlColor1.Size = New System.Drawing.Size(30, 31)
        Me.pnlColor1.TabIndex = 11
        '
        'lblColor1
        '
        Me.lblColor1.AutoSize = True
        Me.lblColor1.Location = New System.Drawing.Point(7, 65)
        Me.lblColor1.Name = "lblColor1"
        Me.lblColor1.Size = New System.Drawing.Size(49, 15)
        Me.lblColor1.TabIndex = 10
        Me.lblColor1.Text = "Color 1:"
        '
        'btnColor1
        '
        Me.btnColor1.Location = New System.Drawing.Point(98, 61)
        Me.btnColor1.Name = "btnColor1"
        Me.btnColor1.Size = New System.Drawing.Size(75, 20)
        Me.btnColor1.TabIndex = 9
        Me.btnColor1.Text = "Change"
        Me.btnColor1.UseVisualStyleBackColor = True
        '
        'tbDiameter
        '
        Me.tbDiameter.Location = New System.Drawing.Point(67, 23)
        Me.tbDiameter.Name = "tbDiameter"
        Me.tbDiameter.Size = New System.Drawing.Size(58, 20)
        Me.tbDiameter.TabIndex = 3
        Me.tbDiameter.Text = "250"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 15)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Diameter:"
        '
        'frmRiskTimeServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1378, 780)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmRiskTimeServer"
        Me.Text = "  Individual Decisions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabSubjectDisplay.ResumeLayout(False)
        Me.tabSubjectDisplay.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        Me.gbSettings.ResumeLayout(False)
        Me.gbSettings.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabInputFile.ResumeLayout(False)
        Me.gbInputFile.ResumeLayout(False)
        Me.gbInputFile.PerformLayout()
        Me.gbEditFile.ResumeLayout(False)
        Me.gbFont.ResumeLayout(False)
        Me.gbFont.PerformLayout()
        Me.gbPeriods.ResumeLayout(False)
        Me.gbPeriods.PerformLayout()
        CType(Me.dgvPeriods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDiscounting.ResumeLayout(False)
        Me.gbDiscounting.PerformLayout()
        Me.gbFormat.ResumeLayout(False)
        Me.gbFormat.PerformLayout()
        Me.gbOpen.ResumeLayout(False)
        Me.gbOpen.PerformLayout()
        Me.gbColors.ResumeLayout(False)
        Me.gbColors.PerformLayout()
        Me.gbRisk.ResumeLayout(False)
        Me.gbRisk.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabSubjectDisplay As System.Windows.Forms.TabPage
    Friend WithEvents lblLaterWeeks As System.Windows.Forms.Label
    Friend WithEvents lblSoonerWeeks As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents lblConfirm As System.Windows.Forms.Label
    Friend WithEvents lblLaterDate As System.Windows.Forms.Label
    Friend WithEvents lblSoonerDate As System.Windows.Forms.Label
    Friend WithEvents tabSettings As System.Windows.Forms.TabPage
    'Friend WithEvents MQmonitor1 As ExCEN_MQ.MQmonitor
    Friend WithEvents gbSettings As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtNoOfPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnStartSession As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNoOfSub As System.Windows.Forms.TextBox
    Friend WithEvents btnStartAccept As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTest As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents lblDiscountingFile As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnStartPeriods As System.Windows.Forms.Button
    Friend WithEvents tabInputFile As System.Windows.Forms.TabPage
    Friend WithEvents txtInputFile As System.Windows.Forms.TextBox
    Friend WithEvents gbEditFile As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
    Friend WithEvents gbDiscounting As System.Windows.Forms.GroupBox
    Friend WithEvents cbCalendar As System.Windows.Forms.CheckBox
    Friend WithEvents cbAEIR As System.Windows.Forms.CheckBox
    Friend WithEvents gbFormat As System.Windows.Forms.GroupBox
    Friend WithEvents gbOpen As System.Windows.Forms.GroupBox
    Friend WithEvents rbOpenLater As System.Windows.Forms.RadioButton
    Friend WithEvents rbOpenSooner As System.Windows.Forms.RadioButton
    Friend WithEvents rbOpen As System.Windows.Forms.RadioButton
    Friend WithEvents rbPortfolio As System.Windows.Forms.RadioButton
    Friend WithEvents rbBinary As System.Windows.Forms.RadioButton
    Friend WithEvents gbColors As System.Windows.Forms.GroupBox
    Friend WithEvents btnLaterColor As System.Windows.Forms.Button
    Friend WithEvents btnSoonerColor As System.Windows.Forms.Button
    Friend WithEvents pnlColorLater As System.Windows.Forms.Panel
    Friend WithEvents pnlColorSooner As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbRisk As System.Windows.Forms.GroupBox
    Friend WithEvents chkText As System.Windows.Forms.CheckBox
    Friend WithEvents chkGraph As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnColor4 As System.Windows.Forms.Button
    Friend WithEvents btnColor3 As System.Windows.Forms.Button
    Friend WithEvents btnColor2 As System.Windows.Forms.Button
    Friend WithEvents pnlColor2 As System.Windows.Forms.Panel
    Friend WithEvents pnlColor3 As System.Windows.Forms.Panel
    Friend WithEvents pnlColor4 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlColor1 As System.Windows.Forms.Panel
    Friend WithEvents lblColor1 As System.Windows.Forms.Label
    Friend WithEvents btnColor1 As System.Windows.Forms.Button
    Friend WithEvents tbDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents gbFont As System.Windows.Forms.GroupBox
    Friend WithEvents gbPeriods As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiscountingPeriods As System.Windows.Forms.TextBox
    Friend WithEvents txtRiskPeriods As System.Windows.Forms.TextBox
    Friend WithEvents cbRiskFirst As System.Windows.Forms.CheckBox
    Friend WithEvents lblDiscountingPeriods As System.Windows.Forms.Label
    Friend WithEvents lblRiskPeriods As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
    Friend WithEvents gbInputFile As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPeriods As System.Windows.Forms.DataGridView
    Friend WithEvents btnPeriodsDown As System.Windows.Forms.Button
    Friend WithEvents btnPeriodsUp As System.Windows.Forms.Button
    Friend WithEvents lblCurrentPeriod As System.Windows.Forms.Label
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents lblPause As System.Windows.Forms.Label
    Friend WithEvents btnReview As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnBpreset1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBeliefPreset1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnBpreset2 As System.Windows.Forms.Button
    Friend WithEvents btnBpreset5 As System.Windows.Forms.Button
    Friend WithEvents btnBpreset4 As System.Windows.Forms.Button
    Friend WithEvents btnBpreset3 As System.Windows.Forms.Button
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblRound3 As System.Windows.Forms.Label
    Friend WithEvents lblRound2 As System.Windows.Forms.Label
    Friend WithEvents lblRound1 As System.Windows.Forms.Label

End Class
