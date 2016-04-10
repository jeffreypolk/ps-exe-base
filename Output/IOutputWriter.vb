Namespace Output
    Public Interface IOutputWriter

        Sub Write(ByVal Text As String)

        Sub WriteLine(ByVal Text As String)

        Sub WriteFormat(ByVal Format As String, ParamArray Text() As String)

        Sub WriteFormatLine(ByVal Format As String, ParamArray Text() As String)

        Sub Clear()

    End Interface

End Namespace