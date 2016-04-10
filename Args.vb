Public Class Args

    Private Shared _ArgDict As Dictionary(Of String, String)

    Private Shared ReadOnly Property ArgDict As Dictionary(Of String, String)
        Get
            If _ArgDict Is Nothing Then
                _ArgDict = New Dictionary(Of String, String)

                'capture args
                Dim ArgList As New List(Of String)
                ArgList = Environment.GetCommandLineArgs.ToList

                'the first argument is the exe itself.  remove it
                ArgList.RemoveAt(0)

                'build the dictionary
                If ArgList.Count = 1 Then
                    'no "/name value" arguments are used
                    'the entire string is a single argument
                    _ArgDict.Add(String.Empty, ArgList(0))
                Else
                    'convert all argument names to lower case for easier comparison
                    For i As Integer = 0 To ArgList.Count - 1
                        If ArgList(i).StartsWith("/") Then
                            ArgList(i) = ArgList(i).ToLower.Substring(1)

                            If _ArgDict.ContainsKey(ArgList(i)) = False Then
                                _ArgDict.Add(ArgList(i), ArgList(i + 1))
                            End If
                            'advance to the next arg
                            i += 1
                        End If
                    Next
                End If
            End If

            Return _ArgDict
        End Get
    End Property

    Public Shared Function GetArg(ByVal Name As String, Optional ByVal DefaultValue As String = "") As String

        Dim Ret As String

        If ArgDict.ContainsKey(Name.ToLower) = False OrElse String.IsNullOrEmpty(ArgDict(Name.ToLower)) Then
            Ret = DefaultValue
        Else
            Ret = ArgDict(Name.ToLower)
        End If
        Return Ret
    End Function

    Public Shared Function ArgCount() As Integer
        Return ArgDict.Count
    End Function

    Public Shared Function ArgExists(Name As String) As Boolean
        Return ArgDict.ContainsKey(Name.ToLower)
    End Function

    Public Shared ReadOnly Property ArgString As String
        Get
            If Environment.CommandLine.Contains("/") Then
                Return Environment.CommandLine.Substring(Environment.CommandLine.IndexOf("/"))
            Else
                Return String.Empty
            End If
        End Get
    End Property
End Class
