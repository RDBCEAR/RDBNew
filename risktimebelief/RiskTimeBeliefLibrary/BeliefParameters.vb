Public Class BeliefParameters
    'Implements System.IComparable

    Public ID As String
    Public Text As String
    Public LeftLabel As String = ""
    Public RightLabel As String = ""
    Public Xlabel1 As String = "0% to 9%"
    Public Xlabel2 As String = "10% to 19%"
    Public Xlabel3 As String = "20% to 29%"
    Public Xlabel4 As String = "30% to 39%"
    Public Xlabel5 As String = "40% to 49%"
    Public Xlabel6 As String = "50% to 59%"
    Public Xlabel7 As String = "60% to 69%"
    Public Xlabel8 As String = "70% to 79%"
    Public Xlabel9 As String = "80% to 89%"
    Public Xlabel10 As String = "90% to 100%"
    Public Alpha As Single = 10
    Public Beta As Single = 10
    Public altXlabel1 As String = ""
    Public altXlabel2 As String = ""
    Public altXlabel3 As String = ""
    Public altXlabel4 As String = ""
    Public altXlabel5 As String = ""
    Public altXlabel6 As String = ""
    Public altXlabel7 As String = ""
    Public altXlabel8 As String = ""
    Public altXlabel9 As String = ""
    Public altXlabel10 As String = ""
    Public XbuttonLabel As String = ""
    Public altXbuttonLabel As String = ""
    Public Allocation1 As Integer = 0
    Public Allocation2 As Integer = 0
    Public Allocation3 As Integer = 0
    Public Allocation4 As Integer = 0
    Public Allocation5 As Integer = 0
    Public Allocation6 As Integer = 0
    Public Allocation7 As Integer = 0
    Public Allocation8 As Integer = 0
    Public Allocation9 As Integer = 0
    Public Allocation10 As Integer = 0




    'Public Sub New(ByVal Lamount As Single, ByVal Ramount As Single, ByVal Ldays As Integer, ByVal Rdays As Integer)
    '    'Me.Lamount = Lamount
    '    'Me.Ramount = Ramount
    '    'Me.Ldays = Ldays
    '    'Me.Rdays = Rdays
    'End Sub

    Public Sub New(ByVal id As String, ByVal t As String)
        Me.ID = id
        Me.Text = t
    End Sub


    Public Sub New()

    End Sub

    'Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
    '    Return Ramount.CompareTo(obj.Ramount)
    'End Function
End Class
