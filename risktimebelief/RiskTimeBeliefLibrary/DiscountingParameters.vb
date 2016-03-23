Public Class DiscountingParameters
    Implements System.IComparable

    Public ID As String
    Public Lamount As Single = -1
    Public Ldays As Integer = -1
    Public Ramount As Single = -1
    Public Rdays As Integer = -1
    Public B_Lamount As Single = 0
    Public B_Ldays As Integer = 0
    Public B_Ramount As Single = 0
    Public B_Rdays As Integer = 0
    Public C_Lamount As Single = 0
    Public C_Ldays As Integer = 0
    Public C_Ramount As Single = 0
    Public C_Rdays As Integer = 0


    Public Sub New(ByVal ID As String, ByVal Lamount As Single, ByVal Ramount As Single, ByVal Ldays As Integer, ByVal Rdays As Integer)
        Me.ID = ID
        Me.Lamount = Lamount
        Me.Ramount = Ramount
        Me.Ldays = Ldays
        Me.Rdays = Rdays
    End Sub

    Public Sub New()

    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Return Ramount.CompareTo(obj.Ramount)
    End Function
End Class
