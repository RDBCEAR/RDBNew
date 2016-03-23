Public Class RandomUtils
    Public Shared Function sample(ByVal array As ArrayList, ByVal size As Integer, rnd As System.Random) As ArrayList
        Dim list As New ArrayList(array)
        Dim shuffleList As New ArrayList()
        'Dim rnd As New Random()
        'Randomize()
        Dim index As Integer
        Dim count As Integer = list.Count - 1
        If size < list.Count Then count = size - 1
        For c As Integer = 0 To count
            index = Rnd.Next(list.Count)
            shuffleList.Add(list.Item(index))
            list.RemoveAt(index)
        Next
        Return shuffleList
    End Function
    Public Shared Function shuffle(ByVal array As ArrayList, r As System.Random) As ArrayList
        Return sample(array, array.Count, r)
    End Function
End Class
