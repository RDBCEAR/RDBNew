<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBinaryDecision
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.rbLeft = New System.Windows.Forms.RadioButton()
        Me.rbRight = New System.Windows.Forms.RadioButton()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpMain.Controls.Add(Me.lblLeft, 0, 0)
        Me.tlpMain.Controls.Add(Me.lblRight, 2, 0)
        Me.tlpMain.Controls.Add(Me.rbLeft, 0, 1)
        Me.tlpMain.Controls.Add(Me.rbRight, 2, 1)
        Me.tlpMain.Controls.Add(Me.lblMiddle, 1, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.TabIndex = 6
        '
        'lblLeft
        '
        Me.lblLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(136, 83)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(50, 13)
        Me.lblLeft.TabIndex = 8
        Me.lblLeft.Text = "Left label"
        '
        'lblRight
        '
        Me.lblRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(528, 83)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(57, 13)
        Me.lblRight.TabIndex = 7
        Me.lblRight.Text = "Right label"
        '
        'rbLeft
        '
        Me.rbLeft.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbLeft.AutoSize = True
        Me.rbLeft.Location = New System.Drawing.Point(138, 96)
        Me.rbLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.rbLeft.Name = "rbLeft"
        Me.rbLeft.Size = New System.Drawing.Size(47, 23)
        Me.rbLeft.TabIndex = 4
        Me.rbLeft.TabStop = True
        Me.rbLeft.Text = "Select"
        Me.rbLeft.UseVisualStyleBackColor = True
        '
        'rbRight
        '
        Me.rbRight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRight.AutoSize = True
        Me.rbRight.Location = New System.Drawing.Point(533, 96)
        Me.rbRight.Margin = New System.Windows.Forms.Padding(0)
        Me.rbRight.Name = "rbRight"
        Me.rbRight.Size = New System.Drawing.Size(47, 23)
        Me.rbRight.TabIndex = 5
        Me.rbRight.TabStop = True
        Me.rbRight.Text = "Select"
        Me.rbRight.UseVisualStyleBackColor = True
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMiddle.Location = New System.Drawing.Point(323, 0)
        Me.lblMiddle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMiddle.Name = "lblMiddle"
        Me.tlpMain.SetRowSpan(Me.lblMiddle, 2)
        Me.lblMiddle.Size = New System.Drawing.Size(71, 193)
        Me.lblMiddle.TabIndex = 6
        Me.lblMiddle.Text = "OR"
        Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucBinaryDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucBinaryDecision"
        Me.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents rbLeft As System.Windows.Forms.RadioButton
    Friend WithEvents rbRight As System.Windows.Forms.RadioButton
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label

End Class
