Public Class AtemporalMPLparameters
    Implements System.IComparable


    Public ID As Integer
    Public LeftText As String = ""
    Public RightText As String = ""
    Public NumberOfRounds As Integer

    Public Sub New()

    End Sub

    Public Sub New(I As String, L As String, R As String, N As Integer)
        Me.ID = I
        Me.LeftText = L
        Me.RightText = R
        Me.NumberOfRounds = N
    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Return ID.CompareTo(obj.ID)
    End Function
End Class
