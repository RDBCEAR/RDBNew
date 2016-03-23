<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRiskDecision
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLeftSelect = New System.Windows.Forms.Button()
        Me.btnRightSelect = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLeftCancel = New System.Windows.Forms.Button()
        Me.btnLeftConfirm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRightCancel = New System.Windows.Forms.Button()
        Me.btnRightConfirm = New System.Windows.Forms.Button()
        Me.MyGroupBoxLeft = New RiskTimeBeliefLibrary.myGroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLeftTitle = New System.Windows.Forms.Label()
        Me.picLeftLottery = New System.Windows.Forms.PictureBox()
        Me.lblLoutcome1 = New System.Windows.Forms.Label()
        Me.lblLoutcome2 = New System.Windows.Forms.Label()
        Me.lblLoutcome4 = New System.Windows.Forms.Label()
        Me.lblLoutcome3 = New System.Windows.Forms.Label()
        Me.MyGroupBoxRight = New RiskTimeBeliefLibrary.myGroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.picRightLottery = New System.Windows.Forms.PictureBox()
        Me.lblRightTItle = New System.Windows.Forms.Label()
        Me.lblRoutcome4 = New System.Windows.Forms.Label()
        Me.lblRoutcome3 = New System.Windows.Forms.Label()
        Me.lblRoutcome2 = New System.Windows.Forms.Label()
        Me.lblRoutcome1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.MyGroupBoxLeft.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.picLeftLottery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyGroupBoxRight.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.picRightLottery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnLeftSelect, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRightSelect, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MyGroupBoxLeft, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MyGroupBoxRight, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(928, 525)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnLeftSelect
        '
        Me.btnLeftSelect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLeftSelect.AutoSize = True
        Me.btnLeftSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLeftSelect.Location = New System.Drawing.Point(198, 445)
        Me.btnLeftSelect.Name = "btnLeftSelect"
        Me.btnLeftSelect.Size = New System.Drawing.Size(68, 23)
        Me.btnLeftSelect.TabIndex = 27
        Me.btnLeftSelect.Text = "Select Left"
        Me.btnLeftSelect.UseVisualStyleBackColor = True
        '
        'btnRightSelect
        '
        Me.btnRightSelect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRightSelect.AutoSize = True
        Me.btnRightSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRightSelect.Location = New System.Drawing.Point(658, 445)
        Me.btnRightSelect.Name = "btnRightSelect"
        Me.btnRightSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnRightSelect.TabIndex = 28
        Me.btnRightSelect.Text = "Select Right"
        Me.btnRightSelect.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnLeftCancel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnLeftConfirm, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 482)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(458, 40)
        Me.TableLayoutPanel2.TabIndex = 29
        '
        'btnLeftCancel
        '
        Me.btnLeftCancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnLeftCancel.AutoSize = True
        Me.btnLeftCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLeftCancel.Location = New System.Drawing.Point(249, 8)
        Me.btnLeftCancel.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.btnLeftCancel.Name = "btnLeftCancel"
        Me.btnLeftCancel.Size = New System.Drawing.Size(50, 23)
        Me.btnLeftCancel.TabIndex = 20
        Me.btnLeftCancel.Text = "Cancel"
        Me.btnLeftCancel.UseVisualStyleBackColor = True
        Me.btnLeftCancel.Visible = False
        '
        'btnLeftConfirm
        '
        Me.btnLeftConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnLeftConfirm.AutoSize = True
        Me.btnLeftConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLeftConfirm.Location = New System.Drawing.Point(157, 8)
        Me.btnLeftConfirm.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.btnLeftConfirm.Name = "btnLeftConfirm"
        Me.btnLeftConfirm.Size = New System.Drawing.Size(52, 23)
        Me.btnLeftConfirm.TabIndex = 19
        Me.btnLeftConfirm.Text = "Confirm"
        Me.btnLeftConfirm.UseVisualStyleBackColor = True
        Me.btnLeftConfirm.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnRightCancel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnRightConfirm, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(467, 482)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(458, 40)
        Me.TableLayoutPanel3.TabIndex = 30
        '
        'btnRightCancel
        '
        Me.btnRightCancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnRightCancel.AutoSize = True
        Me.btnRightCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRightCancel.Location = New System.Drawing.Point(249, 8)
        Me.btnRightCancel.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.btnRightCancel.Name = "btnRightCancel"
        Me.btnRightCancel.Size = New System.Drawing.Size(50, 23)
        Me.btnRightCancel.TabIndex = 22
        Me.btnRightCancel.Text = "Cancel"
        Me.btnRightCancel.UseVisualStyleBackColor = True
        Me.btnRightCancel.Visible = False
        '
        'btnRightConfirm
        '
        Me.btnRightConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRightConfirm.AutoSize = True
        Me.btnRightConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRightConfirm.Location = New System.Drawing.Point(157, 8)
        Me.btnRightConfirm.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.btnRightConfirm.Name = "btnRightConfirm"
        Me.btnRightConfirm.Size = New System.Drawing.Size(52, 23)
        Me.btnRightConfirm.TabIndex = 21
        Me.btnRightConfirm.Text = "Confirm"
        Me.btnRightConfirm.UseVisualStyleBackColor = True
        Me.btnRightConfirm.Visible = False
        '
        'MyGroupBoxLeft
        '
        Me.MyGroupBoxLeft.BorderColor = System.Drawing.Color.Black
        Me.MyGroupBoxLeft.BorderWidth = 1
        Me.MyGroupBoxLeft.Controls.Add(Me.TableLayoutPanel4)
        Me.MyGroupBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGroupBoxLeft.Location = New System.Drawing.Point(3, 3)
        Me.MyGroupBoxLeft.Name = "MyGroupBoxLeft"
        Me.MyGroupBoxLeft.ShowBorder = True
        Me.MyGroupBoxLeft.Size = New System.Drawing.Size(458, 429)
        Me.MyGroupBoxLeft.TabIndex = 31
        Me.MyGroupBoxLeft.TabStop = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lblLeftTitle, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.picLeftLottery, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLoutcome1, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLoutcome2, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLoutcome4, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.lblLoutcome3, 0, 4)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(10, 10, 10, 10)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 6
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(452, 410)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'lblLeftTitle
        '
        Me.lblLeftTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblLeftTitle.AutoSize = True
        Me.lblLeftTitle.Location = New System.Drawing.Point(213, 28)
        Me.lblLeftTitle.Name = "lblLeftTitle"
        Me.lblLeftTitle.Size = New System.Drawing.Size(25, 13)
        Me.lblLeftTitle.TabIndex = 15
        Me.lblLeftTitle.Text = "Left"
        Me.lblLeftTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'picLeftLottery
        '
        Me.picLeftLottery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLeftLottery.Location = New System.Drawing.Point(3, 44)
        Me.picLeftLottery.Name = "picLeftLottery"
        Me.picLeftLottery.Size = New System.Drawing.Size(446, 223)
        Me.picLeftLottery.TabIndex = 17
        Me.picLeftLottery.TabStop = False
        '
        'lblLoutcome1
        '
        Me.lblLoutcome1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoutcome1.AutoSize = True
        Me.lblLoutcome1.Location = New System.Drawing.Point(186, 280)
        Me.lblLoutcome1.Name = "lblLoutcome1"
        Me.lblLoutcome1.Size = New System.Drawing.Size(80, 13)
        Me.lblLoutcome1.TabIndex = 19
        Me.lblLoutcome1.Text = "Left Outcome 1"
        '
        'lblLoutcome2
        '
        Me.lblLoutcome2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoutcome2.AutoSize = True
        Me.lblLoutcome2.Location = New System.Drawing.Point(186, 314)
        Me.lblLoutcome2.Name = "lblLoutcome2"
        Me.lblLoutcome2.Size = New System.Drawing.Size(80, 13)
        Me.lblLoutcome2.TabIndex = 20
        Me.lblLoutcome2.Text = "Left Outcome 2"
        '
        'lblLoutcome4
        '
        Me.lblLoutcome4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoutcome4.AutoSize = True
        Me.lblLoutcome4.Location = New System.Drawing.Point(186, 384)
        Me.lblLoutcome4.Name = "lblLoutcome4"
        Me.lblLoutcome4.Size = New System.Drawing.Size(80, 13)
        Me.lblLoutcome4.TabIndex = 22
        Me.lblLoutcome4.Text = "Left Outcome 4"
        '
        'lblLoutcome3
        '
        Me.lblLoutcome3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoutcome3.AutoSize = True
        Me.lblLoutcome3.Location = New System.Drawing.Point(186, 348)
        Me.lblLoutcome3.Name = "lblLoutcome3"
        Me.lblLoutcome3.Size = New System.Drawing.Size(80, 13)
        Me.lblLoutcome3.TabIndex = 21
        Me.lblLoutcome3.Text = "Left Outcome 3"
        '
        'MyGroupBoxRight
        '
        Me.MyGroupBoxRight.BorderColor = System.Drawing.Color.Black
        Me.MyGroupBoxRight.BorderWidth = 1
        Me.MyGroupBoxRight.Controls.Add(Me.TableLayoutPanel5)
        Me.MyGroupBoxRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGroupBoxRight.Location = New System.Drawing.Point(467, 3)
        Me.MyGroupBoxRight.Name = "MyGroupBoxRight"
        Me.MyGroupBoxRight.ShowBorder = True
        Me.MyGroupBoxRight.Size = New System.Drawing.Size(458, 429)
        Me.MyGroupBoxRight.TabIndex = 32
        Me.MyGroupBoxRight.TabStop = False
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.picRightLottery, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRightTItle, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRoutcome4, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRoutcome3, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRoutcome2, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRoutcome1, 0, 2)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 6
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(452, 410)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'picRightLottery
        '
        Me.picRightLottery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picRightLottery.Location = New System.Drawing.Point(3, 44)
        Me.picRightLottery.Name = "picRightLottery"
        Me.picRightLottery.Size = New System.Drawing.Size(446, 223)
        Me.picRightLottery.TabIndex = 18
        Me.picRightLottery.TabStop = False
        '
        'lblRightTItle
        '
        Me.lblRightTItle.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblRightTItle.AutoSize = True
        Me.lblRightTItle.Location = New System.Drawing.Point(210, 28)
        Me.lblRightTItle.Name = "lblRightTItle"
        Me.lblRightTItle.Size = New System.Drawing.Size(32, 13)
        Me.lblRightTItle.TabIndex = 16
        Me.lblRightTItle.Text = "Right"
        Me.lblRightTItle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblRoutcome4
        '
        Me.lblRoutcome4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRoutcome4.AutoSize = True
        Me.lblRoutcome4.Location = New System.Drawing.Point(182, 384)
        Me.lblRoutcome4.Name = "lblRoutcome4"
        Me.lblRoutcome4.Size = New System.Drawing.Size(87, 13)
        Me.lblRoutcome4.TabIndex = 26
        Me.lblRoutcome4.Text = "Right Outcome 4"
        '
        'lblRoutcome3
        '
        Me.lblRoutcome3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRoutcome3.AutoSize = True
        Me.lblRoutcome3.Location = New System.Drawing.Point(182, 348)
        Me.lblRoutcome3.Name = "lblRoutcome3"
        Me.lblRoutcome3.Size = New System.Drawing.Size(87, 13)
        Me.lblRoutcome3.TabIndex = 25
        Me.lblRoutcome3.Text = "Right Outcome 3"
        '
        'lblRoutcome2
        '
        Me.lblRoutcome2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRoutcome2.AutoSize = True
        Me.lblRoutcome2.Location = New System.Drawing.Point(182, 314)
        Me.lblRoutcome2.Name = "lblRoutcome2"
        Me.lblRoutcome2.Size = New System.Drawing.Size(87, 13)
        Me.lblRoutcome2.TabIndex = 24
        Me.lblRoutcome2.Text = "Right Outcome 2"
        '
        'lblRoutcome1
        '
        Me.lblRoutcome1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRoutcome1.AutoSize = True
        Me.lblRoutcome1.Location = New System.Drawing.Point(182, 280)
        Me.lblRoutcome1.Name = "lblRoutcome1"
        Me.lblRoutcome1.Size = New System.Drawing.Size(87, 13)
        Me.lblRoutcome1.TabIndex = 23
        Me.lblRoutcome1.Text = "Right Outcome 1"
        '
        'ucRiskDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucRiskDecision"
        Me.Size = New System.Drawing.Size(928, 525)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.MyGroupBoxLeft.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.picLeftLottery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyGroupBoxRight.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.picRightLottery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLeftTitle As System.Windows.Forms.Label
    Friend WithEvents lblRightTItle As System.Windows.Forms.Label
    Friend WithEvents picLeftLottery As System.Windows.Forms.PictureBox
    Friend WithEvents picRightLottery As System.Windows.Forms.PictureBox
    Friend WithEvents lblLoutcome1 As System.Windows.Forms.Label
    Friend WithEvents lblLoutcome2 As System.Windows.Forms.Label
    Friend WithEvents lblLoutcome3 As System.Windows.Forms.Label
    Friend WithEvents lblLoutcome4 As System.Windows.Forms.Label
    Friend WithEvents lblRoutcome1 As System.Windows.Forms.Label
    Friend WithEvents lblRoutcome2 As System.Windows.Forms.Label
    Friend WithEvents lblRoutcome3 As System.Windows.Forms.Label
    Friend WithEvents lblRoutcome4 As System.Windows.Forms.Label
    Friend WithEvents btnLeftSelect As System.Windows.Forms.Button
    Friend WithEvents btnRightSelect As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnLeftConfirm As System.Windows.Forms.Button
    Friend WithEvents btnLeftCancel As System.Windows.Forms.Button
    Friend WithEvents btnRightConfirm As System.Windows.Forms.Button
    Friend WithEvents btnRightCancel As System.Windows.Forms.Button
    Friend WithEvents MyGroupBoxLeft As myGroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MyGroupBoxRight As myGroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel

End Class
