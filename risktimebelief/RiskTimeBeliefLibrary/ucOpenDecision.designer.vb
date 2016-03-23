<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOpenDecision
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
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblLeftPayout = New System.Windows.Forms.Label()
        Me.lblRightPayout = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRightDollar = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblLeftDollar = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 5
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.Controls.Add(Me.lblRight, 4, 0)
        Me.tlpMain.Controls.Add(Me.lblMiddle, 2, 0)
        Me.tlpMain.Controls.Add(Me.lblLeft, 1, 0)
        Me.tlpMain.Controls.Add(Me.lblLeftPayout, 0, 1)
        Me.tlpMain.Controls.Add(Me.lblRightPayout, 3, 1)
        Me.tlpMain.Controls.Add(Me.Panel1, 3, 0)
        Me.tlpMain.Controls.Add(Me.Panel2, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.TabIndex = 6
        '
        'lblRight
        '
        Me.lblRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(536, 83)
        Me.lblRight.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(57, 13)
        Me.lblRight.TabIndex = 12
        Me.lblRight.Text = "Right label"
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMiddle.Location = New System.Drawing.Point(286, 0)
        Me.lblMiddle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMiddle.Name = "lblMiddle"
        Me.tlpMain.SetRowSpan(Me.lblMiddle, 2)
        Me.lblMiddle.Size = New System.Drawing.Size(143, 193)
        Me.lblMiddle.TabIndex = 6
        Me.lblMiddle.Text = "IS THE SAME AS"
        Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLeft
        '
        Me.lblLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(107, 83)
        Me.lblLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(50, 13)
        Me.lblLeft.TabIndex = 13
        Me.lblLeft.Text = "Left label"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeftPayout
        '
        Me.lblLeftPayout.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLeftPayout.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.lblLeftPayout, 2)
        Me.lblLeftPayout.Location = New System.Drawing.Point(112, 96)
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
        Me.lblRightPayout.Location = New System.Drawing.Point(540, 96)
        Me.lblRightPayout.Name = "lblRightPayout"
        Me.lblRightPayout.Size = New System.Drawing.Size(68, 13)
        Me.lblRightPayout.TabIndex = 16
        Me.lblRightPayout.Text = "Right Payout"
        Me.lblRightPayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblRightDollar)
        Me.Panel1.Controls.Add(Me.txtRight)
        Me.Panel1.Location = New System.Drawing.Point(432, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(101, 90)
        Me.Panel1.TabIndex = 17
        '
        'lblRightDollar
        '
        Me.lblRightDollar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRightDollar.AutoSize = True
        Me.lblRightDollar.Location = New System.Drawing.Point(3, 72)
        Me.lblRightDollar.Name = "lblRightDollar"
        Me.lblRightDollar.Size = New System.Drawing.Size(13, 13)
        Me.lblRightDollar.TabIndex = 15
        Me.lblRightDollar.Text = "$"
        '
        'txtRight
        '
        Me.txtRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRight.Location = New System.Drawing.Point(19, 69)
        Me.txtRight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(82, 20)
        Me.txtRight.TabIndex = 14
        Me.txtRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtLeft)
        Me.Panel2.Controls.Add(Me.lblLeftDollar)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(101, 90)
        Me.Panel2.TabIndex = 18
        '
        'txtLeft
        '
        Me.txtLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLeft.Location = New System.Drawing.Point(20, 69)
        Me.txtLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(81, 20)
        Me.txtLeft.TabIndex = 7
        Me.txtLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLeftDollar
        '
        Me.lblLeftDollar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLeftDollar.AutoSize = True
        Me.lblLeftDollar.Location = New System.Drawing.Point(4, 72)
        Me.lblLeftDollar.Name = "lblLeftDollar"
        Me.lblLeftDollar.Size = New System.Drawing.Size(13, 13)
        Me.lblLeftDollar.TabIndex = 19
        Me.lblLeftDollar.Text = "$"
        '
        'ucOpenDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucOpenDecision"
        Me.Size = New System.Drawing.Size(719, 193)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblLeftDollar As System.Windows.Forms.Label
    Friend WithEvents lblRightDollar As System.Windows.Forms.Label

End Class
