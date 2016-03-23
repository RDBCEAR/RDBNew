<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBeliefDecision10
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BarChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tlpSliders = New System.Windows.Forms.TableLayoutPanel()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.TrackBar4 = New System.Windows.Forms.TrackBar()
        Me.TrackBar5 = New System.Windows.Forms.TrackBar()
        Me.TrackBar6 = New System.Windows.Forms.TrackBar()
        Me.TrackBar7 = New System.Windows.Forms.TrackBar()
        Me.TrackBar8 = New System.Windows.Forms.TrackBar()
        Me.TrackBar9 = New System.Windows.Forms.TrackBar()
        Me.TrackBar10 = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTokens = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.BarChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSliders.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BarChart, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tlpSliders, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDescription, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(828, 515)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'BarChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.BarChart.ChartAreas.Add(ChartArea1)
        Me.BarChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.BarChart.Legends.Add(Legend1)
        Me.BarChart.Location = New System.Drawing.Point(3, 44)
        Me.BarChart.Name = "BarChart"
        Series1.ChartArea = "ChartArea1"
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.BarChart.Series.Add(Series1)
        Me.BarChart.Size = New System.Drawing.Size(822, 225)
        Me.BarChart.TabIndex = 0
        Me.BarChart.Text = "Chart1"
        '
        'tlpSliders
        '
        Me.tlpSliders.ColumnCount = 12
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlpSliders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.tlpSliders.Controls.Add(Me.TrackBar1, 1, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar2, 2, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar3, 3, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar4, 4, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar5, 5, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar6, 6, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar7, 7, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar8, 8, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar9, 9, 1)
        Me.tlpSliders.Controls.Add(Me.TrackBar10, 10, 1)
        Me.tlpSliders.Controls.Add(Me.Label1, 1, 0)
        Me.tlpSliders.Controls.Add(Me.Label2, 2, 0)
        Me.tlpSliders.Controls.Add(Me.Label3, 3, 0)
        Me.tlpSliders.Controls.Add(Me.Label4, 4, 0)
        Me.tlpSliders.Controls.Add(Me.Label5, 5, 0)
        Me.tlpSliders.Controls.Add(Me.Label6, 6, 0)
        Me.tlpSliders.Controls.Add(Me.Label7, 7, 0)
        Me.tlpSliders.Controls.Add(Me.Label8, 8, 0)
        Me.tlpSliders.Controls.Add(Me.Label9, 9, 0)
        Me.tlpSliders.Controls.Add(Me.Label10, 10, 0)
        Me.tlpSliders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSliders.Location = New System.Drawing.Point(3, 275)
        Me.tlpSliders.Name = "tlpSliders"
        Me.tlpSliders.RowCount = 2
        Me.tlpSliders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpSliders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpSliders.Size = New System.Drawing.Size(822, 158)
        Me.tlpSliders.TabIndex = 1
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(55, 50)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar1.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TickFrequency = 0
        '
        'TrackBar2
        '
        Me.TrackBar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar2.LargeChange = 1
        Me.TrackBar2.Location = New System.Drawing.Point(128, 50)
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar2.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar2.TabIndex = 1
        Me.TrackBar2.TickFrequency = 0
        '
        'TrackBar3
        '
        Me.TrackBar3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar3.LargeChange = 1
        Me.TrackBar3.Location = New System.Drawing.Point(201, 50)
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar3.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar3.TabIndex = 2
        Me.TrackBar3.TickFrequency = 0
        '
        'TrackBar4
        '
        Me.TrackBar4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar4.LargeChange = 1
        Me.TrackBar4.Location = New System.Drawing.Point(274, 50)
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar4.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar4.TabIndex = 3
        Me.TrackBar4.TickFrequency = 0
        '
        'TrackBar5
        '
        Me.TrackBar5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar5.LargeChange = 1
        Me.TrackBar5.Location = New System.Drawing.Point(347, 50)
        Me.TrackBar5.Name = "TrackBar5"
        Me.TrackBar5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar5.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar5.TabIndex = 4
        Me.TrackBar5.TickFrequency = 0
        '
        'TrackBar6
        '
        Me.TrackBar6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar6.LargeChange = 1
        Me.TrackBar6.Location = New System.Drawing.Point(420, 50)
        Me.TrackBar6.Name = "TrackBar6"
        Me.TrackBar6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar6.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar6.TabIndex = 5
        Me.TrackBar6.TickFrequency = 0
        '
        'TrackBar7
        '
        Me.TrackBar7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar7.LargeChange = 1
        Me.TrackBar7.Location = New System.Drawing.Point(493, 50)
        Me.TrackBar7.Name = "TrackBar7"
        Me.TrackBar7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar7.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar7.TabIndex = 6
        Me.TrackBar7.TickFrequency = 0
        '
        'TrackBar8
        '
        Me.TrackBar8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar8.LargeChange = 1
        Me.TrackBar8.Location = New System.Drawing.Point(566, 50)
        Me.TrackBar8.Name = "TrackBar8"
        Me.TrackBar8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar8.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar8.TabIndex = 7
        Me.TrackBar8.TickFrequency = 0
        '
        'TrackBar9
        '
        Me.TrackBar9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar9.LargeChange = 1
        Me.TrackBar9.Location = New System.Drawing.Point(639, 50)
        Me.TrackBar9.Name = "TrackBar9"
        Me.TrackBar9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar9.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar9.TabIndex = 8
        Me.TrackBar9.TickFrequency = 0
        '
        'TrackBar10
        '
        Me.TrackBar10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TrackBar10.LargeChange = 1
        Me.TrackBar10.Location = New System.Drawing.Point(712, 50)
        Me.TrackBar10.Name = "TrackBar10"
        Me.TrackBar10.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar10.Size = New System.Drawing.Size(45, 105)
        Me.TrackBar10.TabIndex = 9
        Me.TrackBar10.TickFrequency = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(336, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(409, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(482, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(555, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(628, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(701, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Label10"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(384, 14)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Description"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblTokens, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSubmit, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnConfirm, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblInstructions, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 439)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(822, 73)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'lblTokens
        '
        Me.lblTokens.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTokens.AutoSize = True
        Me.lblTokens.Location = New System.Drawing.Point(3, 30)
        Me.lblTokens.Name = "lblTokens"
        Me.lblTokens.Size = New System.Drawing.Size(39, 13)
        Me.lblTokens.TabIndex = 0
        Me.lblTokens.Text = "tokens"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSubmit.AutoSize = True
        Me.btnSubmit.Location = New System.Drawing.Point(290, 25)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(76, 23)
        Me.btnSubmit.TabIndex = 1
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.AutoSize = True
        Me.btnConfirm.Location = New System.Drawing.Point(413, 25)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(76, 23)
        Me.btnConfirm.TabIndex = 2
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(495, 25)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblInstructions
        '
        Me.lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblInstructions.Location = New System.Drawing.Point(588, 7)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(231, 58)
        Me.lblInstructions.TabIndex = 3
        Me.lblInstructions.Text = "instructions"
        '
        'ucBeliefDecision10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucBeliefDecision10"
        Me.Size = New System.Drawing.Size(828, 515)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.BarChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSliders.ResumeLayout(False)
        Me.tlpSliders.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BarChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents tlpSliders As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar4 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar5 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar6 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar7 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar8 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar9 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar10 As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTokens As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
