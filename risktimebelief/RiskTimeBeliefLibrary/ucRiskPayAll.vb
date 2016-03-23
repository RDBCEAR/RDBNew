Public Class ucRiskPayAll

    Public Sub setData(ByVal headers As String(), ByVal periods As String()())
        Dim d As DataGridViewTextBoxColumn


        'd.SortMode = DataGridViewColumnSortMode.NotSortable
        For i As Integer = 0 To headers.Length - 1
            d = New DataGridViewTextBoxColumn
            d.SortMode = DataGridViewColumnSortMode.NotSortable

            d.Name = i.ToString
            d.HeaderText = headers(i)

            payallDataGridView.Columns.Add(d)

        Next
        payallDataGridView.RowTemplate.Height = 30
        For i As Integer = 0 To periods.Length - 1
            payallDataGridView.Rows.Add(periods(i))

        Next
        For c As Integer = 0 To payallDataGridView.Rows(0).Cells.Count - 1
            payallDataGridView.Rows(0).Cells(c).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            payallDataGridView.Rows(0).Cells(c).Style.ForeColor = Color.Navy
            payallDataGridView.Rows(0).Cells(c).Style.BackColor = Color.LightBlue
        Next
        'Dim a As String() = New String() {"1", "2", "3", "4", "5"}
        'Dim b As String() = New String() {"4", "3", "2", "1", "5"}
        'payallDataGridView.Rows.Add(a)
        'payallDataGridView.Rows.Add(b)
        'payallDataGridView.Rows.Add(a)
        'payallDataGridView.Rows.Add(b)
        'payallDataGridView.Rows.Add(a)
        'payallDataGridView.Rows.Add(b)

    End Sub



End Class
