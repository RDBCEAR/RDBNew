<Serializable()> Public Class Subject

    Public Settings As Settings
    Public Periods As Period()

    'do i need this?  I don't think so; removing for now
    'Public Treatment As Integer



    Public Sub New()

    End Sub


    'Public Sub New(ByVal Periods As Period(), ByVal Treatment As Integer)
    Public Sub New(ByVal Periods As Period())
        Me.Periods = Periods
        'Me.Treatment = Treatment
    End Sub
End Class
