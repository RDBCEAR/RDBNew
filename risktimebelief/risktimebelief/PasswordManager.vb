Imports System.IO

Public Class PasswordManager
    Public Const SECTION_STRING_PASSWORD As String = "[PASSWORD]"
    Public Const SECTION_STRING_ANSWER As String = "[ANSWER]"
    Public Const VALIDATION_OK As Integer = 0
    Public Const VALIDATION_WRONG_PASSWORD As Integer = -1
    Public Const VALIDATION_ANSWER_FILE_NOT_FOUND As Integer = -2
    Public Const VALIDATION_INVALID_STAGE As Integer = -3
    Public Const VALIDATION_PASSWORD_FILE_NOT_FOUND As Integer = -4
    Public Shared Function VerifyPasswordFromInput(ByVal Stage As Integer, ByVal PasswordFileName As String) As Integer
        ReadPasswordFile(PasswordFileName)
        If Not File.Exists(PasswordFileName) Then Return VALIDATION_PASSWORD_FILE_NOT_FOUND
        Dim passwords As String() = ReadPasswordFile(PasswordFileName)
        If passwords Is Nothing OrElse passwords.Length <= Stage Then Return VALIDATION_INVALID_STAGE
        Dim str As String = InputBox("Please enter password", "Password")
        If (str.Trim() = passwords(Stage - 1)) Then Return True
        Return VALIDATION_WRONG_PASSWORD
    End Function

    Public Shared Function VerifyPasswordFromFile(ByVal Stage As String, ByVal PasswordFileName As String, ByVal AnswerFileName As String) As Integer

        If Not File.Exists(AnswerFileName) Then Return VALIDATION_ANSWER_FILE_NOT_FOUND
        If Not File.Exists(PasswordFileName) Then Return VALIDATION_PASSWORD_FILE_NOT_FOUND
        Dim passwords As String() = ReadPasswordFile(PasswordFileName)
        If passwords Is Nothing OrElse passwords.Length <= Stage Then Return VALIDATION_INVALID_STAGE
        Dim str As String = ReadAnswerFile(AnswerFileName)
        If (str.Trim() = passwords(Stage - 1)) Then Return True
        Return False
    End Function
    Public Shared Function VerifyPasswordFromBoth(ByVal Stage As String, ByVal PasswordFileName As String, ByVal AnswerFileName As String) As Integer
        If Not VerifyPasswordFromFile(Stage, PasswordFileName, AnswerFileName) Then
            Return VerifyPasswordFromInput(Stage, PasswordFileName)
        End If

        Return VALIDATION_WRONG_PASSWORD
    End Function

    Public Shared Function CreatePasswordFile(ByVal Stages As String(), ByVal FileName As String) As Boolean
        Dim IsOveride As Boolean = False
        Try
            If File.Exists(FileName) Then
                IsOveride = True
            End If

            Dim i As Integer = 0
            Dim objwriter As StreamWriter
            objwriter = New StreamWriter(FileName, False)
            objwriter.WriteLine(SECTION_STRING_PASSWORD)
            For Each str As String In Stages
                objwriter.WriteLine(str)

            Next

            objwriter.Close()

        Catch Ex As Exception

            Throw Ex
        End Try
        Return IsOveride
    End Function

    Public Shared Function CreateAnswerFile(ByVal Password As String, ByVal AnswerFileName As String) As Boolean
        Dim IsOveride As Boolean = False
        Try
            If File.Exists(AnswerFileName) Then
                IsOveride = True
            End If

            Dim objwriter As StreamWriter
            objwriter = New StreamWriter(AnswerFileName, False)
            objwriter.WriteLine(SECTION_STRING_PASSWORD)
            objwriter.WriteLine(Password)

            objwriter.Close()
            objwriter.Dispose()

        Catch Ex As Exception

            Throw Ex
        End Try
        Return IsOveride
    End Function
    Private Shared Function ReadPasswordFile(ByVal PasswordFileName As String) As String()

        Dim reader As TextReader = New StreamReader(PasswordFileName)
        Dim str As String
        Dim check As Boolean = True

        str = reader.ReadLine
        If str.ToUpper <> SECTION_STRING_PASSWORD Then
            Return New String() {}
        End If
        Dim arr As New List(Of String)


        While True
            str = reader.ReadLine
            If str Is Nothing Then
                reader.Close()
                reader.Dispose()
                Exit While
            ElseIf str.Length > 0 Then
                arr.Add(str)
            End If
        End While

        Return arr.ToArray
    End Function

    Private Shared Function ReadAnswerFile(ByVal AnswerFileName As String) As String

        Dim reader As TextReader = New StreamReader(AnswerFileName)
        Dim str As String
        Dim check As Boolean = True

        str = reader.ReadLine
        If str.ToUpper <> SECTION_STRING_PASSWORD Then
            Return Nothing
        End If
        str = reader.ReadLine
        reader.Close()
        reader.Dispose()
        Return str


    End Function
End Class
