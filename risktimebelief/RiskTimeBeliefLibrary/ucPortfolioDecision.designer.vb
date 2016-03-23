<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPortfolioDecision
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
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblLeftPayout = New System.Windows.Forms.Label()
        Me.lblRightPayout = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 5
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tlpMain.Controls.Add(Me.txtRight, 3, 0)
        Me.tlpMain.Controls.Add(Me.lblRight, 4, 0)
        Me.tlpMain.Controls.Add(Me.lblMiddle, 2, 0)
        Me.tlpMain.Controls.Add(Me.lblLeft, 1, 0)
        Me.tlpMain.Controls.Add(Me.txtLeft, 0, 0)
        Me.tlpMain.Controls.Add(Me.lblLeftPayout, 0, 1)
        Me.tlpMain.Controls.Add(Me.lblRightPayout, 3, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.TabIndex = 6
        '
        'txtRight
        '
        Me.txtRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRight.Location = New System.Drawing.Point(435, 76)
        Me.txtRight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(52, 20)
        Me.txtRight.TabIndex = 14
        Me.txtRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRight
        '
        Me.lblRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(487, 78)
        Me.lblRight.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lblRight.Size = New System.Drawing.Size(57, 18)
        Me.lblRight.TabIndex = 12
        Me.lblRight.Text = "Right label"
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
        Me.lblMiddle.Text = "AND"
        Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLeft
        '
        Me.lblLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(93, 78)
        Me.lblLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lblLeft.Size = New System.Drawing.Size(50, 18)
        Me.lblLeft.TabIndex = 13
        Me.lblLeft.Text = "Left label"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLeft
        '
        Me.txtLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLeft.Location = New System.Drawing.Point(41, 76)
        Me.txtLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(52, 20)
        Me.txtLeft.TabIndex = 7
        Me.txtLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLeftPayout
        '
        Me.lblLeftPayout.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLeftPayout.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.lblLeftPayout, 2)
        Me.lblLeftPayout.Location = New System.Drawing.Point(131, 96)
        Me.lblLeftPayout.Name = "lblLeftPayout"
        Me.lblLeftPayout.Size = New System.Drawing.Size(61, 13)
        Me.lblLeftPayout.TabIndex = 15
        Me.lblLeftPayout.Text = "Left Payout"
        Me.lblLeftPayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRightPayout
        '
        Me.lblRightPayout.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblRightPayout.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.lblRightPayout, 2)
        Me.lblRightPayout.Location = New System.Drawing.Point(522, 96)
        Me.lblRightPayout.Name = "lblRightPayout"
        Me.lblRightPayout.Size = New System.Drawing.Size(68, 13)
        Me.lblRightPayout.TabIndex = 16
        Me.lblRightPayout.Text = "Right Payout"
        Me.lblRightPayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucPortfolioDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucPortfolioDecision"
        Me.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents txtRight As System.Windows.Forms.TextBox
    Friend WithEvents lblLeftPayout As System.Windows.Forms.Label
    Friend WithEvents lblRightPayout As System.Windows.Forms.Label

End Class
