Imports System.Reflection
Imports System.IO

Public Class FileUtils
    Public Const TAG_HEADER As String = "HEADER"
    Public Const TAG_CLASSNAME As String = "ClassName"
    Public Const TAG_DATAARRAY As String = "DataArray"

    Public Shared Sub WriteObjectToFile(ByVal Section As String, ByVal obj As Object, ByVal FileName As String)
        Try

            Dim all As String() = New String() {}
            If File.Exists(FileName) Then
                all = File.ReadAllLines(FileName)
            End If

            Dim i As Integer = 0
            Dim sectionString As String = "[" & Section.ToUpper & "]"
            For Each str As String In all

                If str.Trim.ToUpper = sectionString Then
                    Exit For
                End If
                i += 1
            Next
            Dim objwriter As StreamWriter
            If i >= all.Length Then
                objwriter = New StreamWriter(FileName, True)
                objwriter.WriteLine(sectionString)
                WriteObjectToTextWriter(objwriter, obj)
                objwriter.WriteLine("")
                objwriter.Close()
                objwriter.Dispose()
            Else
                objwriter = New StreamWriter(FileName, False)
                Dim c As Integer
                For c = 0 To i
                    objwriter.WriteLine(all(c))
                Next
                WriteObjectToTextWriter(objwriter, obj)
                Dim check As Boolean = True
                For c = i To all.Length - 1

                    If check AndAlso all(c).Length = 0 Then
                        check = False
                    End If
                    If Not check Then
                        objwriter.WriteLine(all(c))
                    End If
                Next
            End If
            objwriter.Close()

        Catch Ex As Exception

            Throw Ex
        End Try
    End Sub
    Public Shared Sub WriteObjectArrayToFile(ByVal Section As String, ByVal t As Type, ByVal objs() As Object, ByVal FileName As String)
        Try

            Dim all As String() = File.ReadAllLines(FileName)
            Dim i As Integer = 0
            Dim sectionString As String = "[" & Section.ToUpper & "]"
            For Each str As String In all

                If str.Trim.ToUpper = sectionString Then
                    Exit For
                End If
                i += 1
            Next
            Dim objwriter As StreamWriter
            If i >= all.Length Then
                objwriter = New StreamWriter(FileName, True)
                objwriter.WriteLine(sectionString)
                WriteObjectArrayToTextWriter(objwriter, t, objs)
                objwriter.WriteLine("")
                objwriter.Close()
                objwriter.Dispose()
            Else
                objwriter = New StreamWriter(FileName, False)
                Dim c As Integer
                For c = 0 To i
                    objwriter.WriteLine(all(c))
                Next
                WriteObjectArrayToTextWriter(objwriter, t, objs)
                Dim check As Boolean = True
                For c = i To all.Length - 1

                    If check AndAlso all(c).Length = 0 Then
                        check = False
                    End If
                    If Not check Then
                        objwriter.WriteLine(all(c))
                    End If
                Next
            End If
            objwriter.Close()

        Catch Ex As Exception

            Throw Ex
        End Try
    End Sub

    Public Shared Sub WriteObjectToTextWriter(ByVal writer As TextWriter, ByVal obj As Object)

        Dim objField() As FieldInfo = obj.GetType.GetFields
        writer.WriteLine(TAG_CLASSNAME & "=" & obj.GetType.FullName)
        For Each p As FieldInfo In objField
            If p.FieldType.FullName = "System.String" Then
                writer.WriteLine(p.Name & "=""" & p.GetValue(obj) & """")
            Else
                writer.WriteLine(p.Name & "=" & p.GetValue(obj))
            End If


        Next
        Dim ObjectProperties() As PropertyInfo = obj.GetType.GetProperties()
        For Each p As PropertyInfo In ObjectProperties
            If p.PropertyType.FullName = "System.String" Then
                writer.WriteLine(p.Name & "=""" & p.GetValue(obj, New Object() {}) & """")
            Else
                writer.WriteLine(p.Name & "=" & p.GetValue(obj, New Object() {}))
            End If

        Next

    End Sub

    Public Shared Sub WriteObjectArrayToTextWriter(ByVal writer As TextWriter, ByVal t As Type, ByVal objs() As Object)

        If objs Is Nothing OrElse objs.Length = 0 Then Return
        writer.WriteLine(TAG_CLASSNAME & "=" & t.FullName)
        writer.WriteLine(GetObjectHeaderDelimitedString(t))
        writer.WriteLine(TAG_DATAARRAY & "=")
        For Each o As Object In objs
            If o.GetType Is t Then
                writer.WriteLine(GetObjectDelimitedString(o))
            End If

        Next
    End Sub

    Public Shared Function ReadObjectFromTextReader(ByVal reader As TextReader, ByVal t As Type) As Object
        Dim obj As Object = Activator.CreateInstance(t)
        Dim str As String = reader.ReadLine()
        str = str.Trim
        Dim p() As String = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_CLASSNAME.ToLower Then
            Return Nothing
        ElseIf p(1).Trim <> t.FullName.Trim Then
            Return Nothing
        End If

        Dim check As Boolean = True
        Dim field As FieldInfo
        Dim prop As PropertyInfo
        While check
            str = reader.ReadLine()
            If Not str Is Nothing AndAlso str.Trim.Length > 0 Then
                str = str.Trim
                p = SplitByEqualSign(str)
                If Not p Is Nothing AndAlso p.Length = 2 Then
                    field = t.GetField(p(0))
                    If field Is Nothing Then
                        prop = t.GetProperty(p(0))

                        If Not prop Is Nothing Then
                            If prop.PropertyType.FullName = "System.String" Then
                                p(1) = p(1).Replace("""", "")
                            End If
                            setProperty(obj, p(1), prop)
                        End If
                    Else
                        If field.FieldType.FullName = "System.String" Then
                            p(1) = p(1).Replace("""", "")
                        End If
                        setField(obj, p(1), field)
                    End If
                Else
                    check = False
                End If
            Else
                check = False
            End If


        End While

        Return obj
    End Function

    Public Shared Function ReadObjectArrayFromTextReader(ByVal reader As TextReader, ByVal t As Type) As ArrayList

        Dim obj As Object
        Dim ObjectProperties() As PropertyInfo = t.GetProperties()
        Dim str As String = reader.ReadLine()
        str = str.Trim
        Dim p() As String = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_CLASSNAME.ToLower Then
            Return New ArrayList()
        ElseIf p(1).Trim <> t.FullName.Trim Then
            Return New ArrayList()
        End If
        str = reader.ReadLine()
        str = str.Trim
        p = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_HEADER.ToLower Then
            Return New ArrayList()
        End If
        Dim name() As String = p(1).Split(",")
        str = reader.ReadLine()
        str = str.Trim
        p = SplitByEqualSign(str)
        If name.Length <= 0 OrElse p.Length <> 2 OrElse p(0).ToLower <> TAG_DATAARRAY.ToLower Then
            Return New ArrayList()

        End If

        Dim array As ArrayList = New ArrayList
        Dim field As FieldInfo
        Dim prop As PropertyInfo
        Dim check As Boolean = True
        Dim data() As String
        Dim strArray() As String
        Dim strtem As String
        Dim list As New List(Of String)
        Dim i As Integer = 0
        Dim pos As Integer = 0
        Dim begin As Integer = 0
        Dim checkQ As Boolean = True
        While check
            str = reader.ReadLine()

            If Not str Is Nothing AndAlso str.Trim().Length > 0 Then
                str = str.Trim
                strArray = str.Split(",")
                For i = 0 To strArray.Length - 1


                    pos = strArray(i).IndexOf(""""c)
                    If (pos >= 0) Then
                        strtem = strArray(i)
                        If (strArray(i).IndexOf(""""c, pos + 1) < 0) Then
                            pos = -1
                            While pos < 0
                                i += 1
                                pos = strArray(i).IndexOf(""""c)
                                strtem = strtem & "," & strArray(i)
                            End While
                        End If

                        strtem = strtem.Replace(""""c, "")
                        list.Add(strtem)
                    Else
                        list.Add(strArray(i))
                    End If




                Next
                data = list.ToArray()
                list = New List(Of String)
                If data.Length = name.Length Then


                    obj = Activator.CreateInstance(t)
                    array.Add(obj)


                    p = SplitByEqualSign(str)
                    For i = 0 To name.Length - 1
                        field = t.GetField(name(i))
                        If field Is Nothing Then
                            prop = t.GetProperty(name(i))

                            If Not prop Is Nothing Then
                                setProperty(obj, data(i), prop)
                            End If
                        Else
                            setField(obj, data(i), field)
                        End If

                    Next


                End If
            Else
                check = False
            End If

        End While


        Return array
    End Function

    Public Shared Function ReadObjectArrayFromFile(ByVal section As String, ByVal t As Type, ByVal FileName As String) As ArrayList
        Dim sectionString As String = "[" & section.ToUpper & "]"
        Dim reader As TextReader = New StreamReader(FileName, System.Text.Encoding.Default)
        Dim check As Boolean = True
        Dim str As String
        While check
            str = reader.ReadLine

            If str Is Nothing Then

                reader.Close()
                reader.Dispose()
                Return New ArrayList()
            ElseIf str.ToUpper.Trim = sectionString.Trim Then
                str = str.Trim
                Exit While
            End If
        End While

        Dim obj As Object
        Dim ObjectProperties() As PropertyInfo = t.GetProperties()
        str = reader.ReadLine()
        str = str.Trim
        Dim p() As String = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_CLASSNAME.ToLower Then
            Return New ArrayList()
        ElseIf p(1).Trim <> t.FullName.Trim Then
            Return New ArrayList()
        End If
        str = reader.ReadLine()
        str = str.Trim
        p = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_HEADER.ToLower Then
            Return New ArrayList()
        End If
        Dim name() As String = p(1).Split(",")
        str = reader.ReadLine()
        str = str.Trim
        p = SplitByEqualSign(str)
        If name.Length <= 0 OrElse p.Length <> 2 OrElse p(0).ToLower <> TAG_DATAARRAY.ToLower Then
            Return New ArrayList()
        End If

        Dim array As ArrayList = New ArrayList
        Dim field As FieldInfo
        Dim prop As PropertyInfo
        check = True
        Dim data() As String
        Dim strArray() As String
        Dim strtem As String = ""

        Dim list As New List(Of String)
        Dim i As Integer = 0
        Dim pos As Integer = 0
        Dim begin As Integer = 0
        Dim checkQ As Boolean = False
        While check
            str = reader.ReadLine()

            If Not str Is Nothing AndAlso str.Trim().Length > 0 Then
                str = str.Trim
                strArray = str.Split(",")
                For i = 0 To strArray.Length - 1


                    pos = strArray(i).IndexOf(""""c)
                    If (pos >= 0) Then
                        strtem = strArray(i)
                        If (strArray(i).IndexOf(""""c, pos + 1) < 0) Then
                            pos = -1
                            While pos < 0
                                i += 1
                                pos = strArray(i).IndexOf(""""c)
                                strtem = strtem & "," & strArray(i)
                            End While
                        End If

                        strtem = strtem.Replace(""""c, "")
                        list.Add(strtem)
                    Else
                        list.Add(strArray(i))
                    End If




                Next

                data = list.ToArray()
                list = New List(Of String)
                If data.Length = name.Length Then


                    obj = Activator.CreateInstance(t)
                    array.Add(obj)


                    p = SplitByEqualSign(str)
                    For i = 0 To name.Length - 1
                        field = t.GetField(name(i))
                        If field Is Nothing Then
                            prop = t.GetProperty(name(i))

                            If Not prop Is Nothing Then
                                setProperty(obj, data(i), prop)
                            End If
                        Else
                            setField(obj, data(i), field)
                        End If

                    Next


                End If
            Else
                check = False
            End If

        End While

        reader.Close()
        reader.Dispose()
        Return array
    End Function

    Public Shared Function ReadObjectFromFile(ByVal section As String, ByVal t As Type, ByVal FileName As String) As Object
        Dim sectionString As String = "[" & section.ToUpper & "]"
        Dim reader As TextReader = New StreamReader(FileName, System.Text.Encoding.Default)
        Dim obj As Object = Activator.CreateInstance(t)
        Dim str As String
        Dim check As Boolean = True

        While check
            str = reader.ReadLine

            If str Is Nothing Then

                reader.Close()
                reader.Dispose()
                Return Nothing
            ElseIf str.ToUpper = sectionString Then
                str = str.Trim
                Exit While
            End If
        End While

        str = reader.ReadLine
        str = str.Trim
        Dim p() As String = SplitByEqualSign(str)
        If p.Length <> 2 OrElse p(0).ToLower <> TAG_CLASSNAME.ToLower Then
            Return Nothing
        ElseIf p(1).Trim <> t.FullName.Trim Then
            Return Nothing
        End If

        check = True
        Dim field As FieldInfo
        Dim prop As PropertyInfo
        While check
            str = reader.ReadLine()

            If Not str Is Nothing AndAlso str.Trim.Length > 0 Then
                str = str.Trim
                p = SplitByEqualSign(str)
                If Not p Is Nothing AndAlso p.Length = 2 Then
                    field = t.GetField(p(0))
                    If field Is Nothing Then
                        prop = t.GetProperty(p(0))

                        If Not prop Is Nothing Then
                            If prop.PropertyType.FullName = "System.String" Then
                                p(1) = p(1).Replace("""", "")
                            End If
                            setProperty(obj, p(1), prop)
                        End If
                    Else
                        If field.FieldType.FullName = "System.String" Then
                            p(1) = p(1).Replace("""", "")
                        End If
                        setField(obj, p(1), field)
                    End If
                Else
                    check = False
                End If
            Else
                check = False
            End If


        End While
        reader.Close()
        reader.Dispose()
        Return obj
    End Function


    Private Shared Sub setProperty(ByVal obj As Object, ByVal value As String, ByVal prop As PropertyInfo)

        Select Case prop.PropertyType.FullName
            Case "System.String"
                prop.SetValue(obj, value, Nothing)
            Case "System.Single"
                prop.SetValue(obj, Single.Parse(value), Nothing)
            Case "System.Double"
                prop.SetValue(obj, Double.Parse(value), Nothing)
            Case "System.Int64"
                prop.SetValue(obj, Int64.Parse(value), Nothing)
            Case "System.Int32"
                prop.SetValue(obj, Int32.Parse(value), Nothing)
            Case "System.Int16"
                prop.SetValue(obj, Int16.Parse(value), Nothing)
            Case "System.Boolean"
                prop.SetValue(obj, Boolean.Parse(value), Nothing)
        End Select
    End Sub

    Private Shared Sub setField(ByVal obj As Object, ByVal value As String, ByVal field As FieldInfo)
        Select Case field.FieldType.FullName
            Case "System.String"
                field.SetValue(obj, value)
            Case "System.Single"
                field.SetValue(obj, Single.Parse(value))
            Case "System.Double"
                field.SetValue(obj, Double.Parse(value))
            Case "System.Int64"
                field.SetValue(obj, Int64.Parse(value))
            Case "System.Int32"
                field.SetValue(obj, Int32.Parse(value))
            Case "System.Int16"
                field.SetValue(obj, Int16.Parse(value))
            Case "System.Boolean"
                field.SetValue(obj, Boolean.Parse(value))
        End Select
    End Sub

    Private Shared Function GetObjectHeaderDelimitedString(ByVal t As Type) As String
        Dim str As String = TAG_HEADER & "="
        Dim header As String = ""
        Dim objField() As FieldInfo = t.GetFields
        For Each p As FieldInfo In objField
            If (header.Length > 0) Then header += ","
            header += p.Name
        Next
        Dim ObjectProperties() As PropertyInfo = t.GetProperties()
        For Each p As PropertyInfo In ObjectProperties
            If p.GetIndexParameters.Length = 0 AndAlso p.CanRead AndAlso p.CanWrite Then
                If (header.Length > 0) Then header += ","
                header += p.Name
            End If
        Next
        Return str & header
    End Function

    Private Shared Function GetObjectDelimitedString(ByVal obj As Object) As String
        Dim str As String = ""
        Dim objField() As FieldInfo = obj.GetType.GetFields
        For Each p As FieldInfo In objField
            If (str.Length > 0) Then str += ","
            If p.FieldType.FullName = "System.String" Then
                str += """" & p.GetValue(obj).ToString & """"
            Else
                str += p.GetValue(obj).ToString
            End If

        Next
        Dim ObjectProperties() As PropertyInfo = obj.GetType.GetProperties()
        Dim indexArgs() As Object = {6}

        For Each p As PropertyInfo In ObjectProperties

            If p.GetIndexParameters.Length = 0 AndAlso p.CanRead AndAlso p.CanWrite Then
                If (str.Length > 0) Then str += ","
                If p.PropertyType.FullName = "System.String" Then
                    str += """" & p.GetValue(obj, Nothing).ToString & """"
                Else
                    str += p.GetValue(obj, Nothing).ToString
                End If

            End If

        Next
        Return str
    End Function

    Private Shared Function SplitByEqualSign(ByVal str As String) As String()
        Dim p(1) As String
        Dim t() As String = str.Split("=")
        If (t.Length <= 2) Then
            Return t
        ElseIf (t.Length > 2) Then
            p(0) = t(0)
            Dim strtem As String = t(1)
            For i = 2 To t.Length - 1
                strtem = strtem & "=" & t(i)
            Next
            p(1) = strtem
            Return p
        End If
        Return New String() {}
    End Function

End Class
