<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMPL
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
        Me.lblRound3 = New System.Windows.Forms.Label()
        Me.lblRound2 = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.rbLeft = New System.Windows.Forms.RadioButton()
        Me.rbRight = New System.Windows.Forms.RadioButton()
        Me.lblRound1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblRound3, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRound2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLeft, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRight, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMiddle, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbLeft, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbRight, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRound1, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(589, 203)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lblRound3
        '
        Me.lblRound3.AutoSize = True
        Me.lblRound3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRound3.Location = New System.Drawing.Point(520, 10)
        Me.lblRound3.Margin = New System.Windows.Forms.Padding(10)
        Me.lblRound3.Name = "lblRound3"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblRound3, 2)
        Me.lblRound3.Size = New System.Drawing.Size(59, 183)
        Me.lblRound3.TabIndex = 7
        Me.lblRound3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRound2
        '
        Me.lblRound2.AutoSize = True
        Me.lblRound2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRound2.Location = New System.Drawing.Point(445, 10)
        Me.lblRound2.Margin = New System.Windows.Forms.Padding(10)
        Me.lblRound2.Name = "lblRound2"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblRound2, 2)
        Me.lblRound2.Size = New System.Drawing.Size(55, 183)
        Me.lblRound2.TabIndex = 6
        Me.lblRound2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLeft
        '
        Me.lblLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(61, 160)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(39, 13)
        Me.lblLeft.TabIndex = 0
        Me.lblLeft.Text = "Label1"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRight
        '
        Me.lblRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(259, 160)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(39, 13)
        Me.lblRight.TabIndex = 1
        Me.lblRight.Text = "Label1"
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMiddle.Location = New System.Drawing.Point(162, 0)
        Me.lblMiddle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMiddle.Name = "lblMiddle"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblMiddle, 2)
        Me.lblMiddle.Size = New System.Drawing.Size(36, 203)
        Me.lblMiddle.TabIndex = 2
        Me.lblMiddle.Text = "OR"
        Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbLeft
        '
        Me.rbLeft.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbLeft.AutoSize = True
        Me.rbLeft.Location = New System.Drawing.Point(57, 176)
        Me.rbLeft.Name = "rbLeft"
        Me.rbLeft.Size = New System.Drawing.Size(47, 23)
        Me.rbLeft.TabIndex = 3
        Me.rbLeft.TabStop = True
        Me.rbLeft.Text = "Select"
        Me.rbLeft.UseVisualStyleBackColor = True
        '
        'rbRight
        '
        Me.rbRight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRight.AutoSize = True
        Me.rbRight.Location = New System.Drawing.Point(255, 176)
        Me.rbRight.Name = "rbRight"
        Me.rbRight.Size = New System.Drawing.Size(47, 23)
        Me.rbRight.TabIndex = 4
        Me.rbRight.TabStop = True
        Me.rbRight.Text = "Select"
        Me.rbRight.UseVisualStyleBackColor = True
        '
        'lblRound1
        '
        Me.lblRound1.AutoSize = True
        Me.lblRound1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRound1.Location = New System.Drawing.Point(370, 10)
        Me.lblRound1.Margin = New System.Windows.Forms.Padding(10)
        Me.lblRound1.Name = "lblRound1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblRound1, 2)
        Me.lblRound1.Size = New System.Drawing.Size(55, 183)
        Me.lblRound1.TabIndex = 5
        Me.lblRound1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucMPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ucMPL"
        Me.Size = New System.Drawing.Size(589, 203)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents rbLeft As System.Windows.Forms.RadioButton
    Friend WithEvents rbRight As System.Windows.Forms.RadioButton
    Friend WithEvents lblRound1 As System.Windows.Forms.Label
    Friend WithEvents lblRound3 As System.Windows.Forms.Label
    Friend WithEvents lblRound2 As System.Windows.Forms.Label

End Class
