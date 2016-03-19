Namespace Output

    Public Class ConsoleOutputWriter
        Implements IOutputWriter

        Public Sub Clear() Implements IOutputWriter.Clear
        End Sub

        Public Sub Write(Text As String) Implements IOutputWriter.Write
            Console.Write(Text)
        End Sub

        Public Sub WriteFormat(Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormat
            Console.Write(String.Format(Format, Text))
        End Sub

        Public Sub WriteFormatLine(Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormatLine
            Console.WriteLine(String.Format(Format, Text))
        End Sub

        Public Sub WriteLine(Text As String) Implements IOutputWriter.WriteLine
            Console.WriteLine(Text)
        End Sub
    End Class
End Namespace
