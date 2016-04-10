Namespace Output

    Public Class DummyOutputWriter
        Implements IOutputWriter

        Public Sub Clear() Implements IOutputWriter.Clear

        End Sub

        Public Sub Write(Text As String) Implements IOutputWriter.Write

        End Sub

        Public Sub WriteFormat(Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormat

        End Sub

        Public Sub WriteFormatLine(Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormatLine

        End Sub

        Public Sub WriteLine(Text As String) Implements IOutputWriter.WriteLine

        End Sub
    End Class
End Namespace
