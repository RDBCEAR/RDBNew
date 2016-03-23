<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyCustomMessageBox
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblRisk = New System.Windows.Forms.Label()
        Me.lblDiscounting = New System.Windows.Forms.Label()
        Me.lblBelief = New System.Windows.Forms.Label()
        Me.cbRisk = New System.Windows.Forms.ComboBox()
        Me.cbDiscounting = New System.Windows.Forms.ComboBox()
        Me.cbBelief = New System.Windows.Forms.ComboBox()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.btnPayAll = New System.Windows.Forms.Button()
        Me.lblMPL = New System.Windows.Forms.Label()
        Me.cbMPL = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.AutoSize = True
        Me.btnOk.Enabled = False
        Me.btnOk.Location = New System.Drawing.Point(152, 199)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblRisk
        '
        Me.lblRisk.AutoSize = True
        Me.lblRisk.Location = New System.Drawing.Point(30, 30)
        Me.lblRisk.Name = "lblRisk"
        Me.lblRisk.Size = New System.Drawing.Size(28, 13)
        Me.lblRisk.TabIndex = 1
        Me.lblRisk.Text = "Risk"
        '
        'lblDiscounting
        '
        Me.lblDiscounting.AutoSize = True
        Me.lblDiscounting.Location = New System.Drawing.Point(30, 64)
        Me.lblDiscounting.Name = "lblDiscounting"
        Me.lblDiscounting.Size = New System.Drawing.Size(63, 13)
        Me.lblDiscounting.TabIndex = 2
        Me.lblDiscounting.Text = "Discounting"
        '
        'lblBelief
        '
        Me.lblBelief.AutoSize = True
        Me.lblBelief.Location = New System.Drawing.Point(30, 102)
        Me.lblBelief.Name = "lblBelief"
        Me.lblBelief.Size = New System.Drawing.Size(33, 13)
        Me.lblBelief.TabIndex = 3
        Me.lblBelief.Text = "Belief"
        '
        'cbRisk
        '
        Me.cbRisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRisk.FormattingEnabled = True
        Me.cbRisk.Location = New System.Drawing.Point(334, 31)
        Me.cbRisk.Name = "cbRisk"
        Me.cbRisk.Size = New System.Drawing.Size(63, 21)
        Me.cbRisk.TabIndex = 4
        '
        'cbDiscounting
        '
        Me.cbDiscounting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDiscounting.FormattingEnabled = True
        Me.cbDiscounting.Location = New System.Drawing.Point(334, 83)
        Me.cbDiscounting.Name = "cbDiscounting"
        Me.cbDiscounting.Size = New System.Drawing.Size(63, 21)
        Me.cbDiscounting.TabIndex = 5
        '
        'cbBelief
        '
        Me.cbBelief.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBelief.FormattingEnabled = True
        Me.cbBelief.Location = New System.Drawing.Point(334, 130)
        Me.cbBelief.Name = "cbBelief"
        Me.cbBelief.Size = New System.Drawing.Size(63, 21)
        Me.cbBelief.TabIndex = 6
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(81, 240)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(28, 13)
        Me.lblTest.TabIndex = 7
        Me.lblTest.Text = "Test"
        Me.lblTest.Visible = False
        '
        'btnPayAll
        '
        Me.btnPayAll.Location = New System.Drawing.Point(451, 31)
        Me.btnPayAll.Name = "btnPayAll"
        Me.btnPayAll.Size = New System.Drawing.Size(63, 30)
        Me.btnPayAll.TabIndex = 8
        Me.btnPayAll.Text = "Pay All"
        Me.btnPayAll.UseVisualStyleBackColor = True
        '
        'lblMPL
        '
        Me.lblMPL.AutoSize = True
        Me.lblMPL.Location = New System.Drawing.Point(33, 151)
        Me.lblMPL.Name = "lblMPL"
        Me.lblMPL.Size = New System.Drawing.Size(29, 13)
        Me.lblMPL.TabIndex = 9
        Me.lblMPL.Text = "MPL"
        '
        'cbMPL
        '
        Me.cbMPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMPL.FormattingEnabled = True
        Me.cbMPL.Location = New System.Drawing.Point(334, 167)
        Me.cbMPL.Name = "cbMPL"
        Me.cbMPL.Size = New System.Drawing.Size(63, 21)
        Me.cbMPL.TabIndex = 10
        '
        'MyCustomMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 358)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbMPL)
        Me.Controls.Add(Me.lblMPL)
        Me.Controls.Add(Me.btnPayAll)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.cbBelief)
        Me.Controls.Add(Me.cbDiscounting)
        Me.Controls.Add(Me.cbRisk)
        Me.Controls.Add(Me.lblBelief)
        Me.Controls.Add(Me.lblDiscounting)
        Me.Controls.Add(Me.lblRisk)
        Me.Controls.Add(Me.btnOk)
        Me.Name = "MyCustomMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Previous Decisions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblRisk As System.Windows.Forms.Label
    Friend WithEvents lblDiscounting As System.Windows.Forms.Label
    Friend WithEvents lblBelief As System.Windows.Forms.Label
    Friend WithEvents cbRisk As System.Windows.Forms.ComboBox
    Friend WithEvents cbDiscounting As System.Windows.Forms.ComboBox
    Friend WithEvents cbBelief As System.Windows.Forms.ComboBox
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents btnPayAll As System.Windows.Forms.Button
    Friend WithEvents lblMPL As System.Windows.Forms.Label
    Friend WithEvents cbMPL As System.Windows.Forms.ComboBox
End Class
