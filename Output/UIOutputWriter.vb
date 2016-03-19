Namespace Output
    Public MustInherit Class UIOutputWriter(Of T As System.Windows.Forms.Control)
        Implements IOutputWriter

        Private _OutputControl As T
        Private Delegate Sub WriteOutputBufferDelegate()
        Private _WriteOutputBuffer As New WriteOutputBufferDelegate(AddressOf WriteOutputBuffer)
        Private Delegate Sub ClearOutputDelegate()
        Private _ClearOutput As New ClearOutputDelegate(AddressOf ClearOutput)

        Private _OutputBufferLock As New Object
        Private _OutputBuffer As New System.Text.StringBuilder

        Sub New(OutputControl As T)
            _OutputControl = OutputControl
        End Sub

        Public Sub Write(ByVal Text As String) Implements IOutputWriter.Write
            SyncLock (_OutputBufferLock)
                _OutputBuffer.Append(Text)
            End SyncLock
            _OutputControl.Parent.Invoke(_WriteOutputBuffer)
        End Sub
        Public Sub WriteLine(ByVal Text As String) Implements IOutputWriter.WriteLine
            SyncLock (_OutputBufferLock)
                _OutputBuffer.AppendLine(Text)
            End SyncLock
            _OutputControl.Parent.Invoke(_WriteOutputBuffer)
        End Sub

        Public Sub WriteFormat(ByVal Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormat
            Write(String.Format(Format, Text))
        End Sub

        Public Sub WriteFormatLine(ByVal Format As String, ParamArray Text() As String) Implements IOutputWriter.WriteFormatLine
            WriteLine(String.Format(Format, Text))
        End Sub

        Public Sub Clear() Implements IOutputWriter.Clear
            _OutputControl.Parent.Invoke(_ClearOutput)
        End Sub

        Private Sub WriteOutputBuffer()
            SyncLock (_OutputBufferLock)
                WriteData(_OutputBuffer.ToString)
                '_OutputControl.AppendText(_OutputBuffer.ToString)
                '_OutputControl.SelectionStart = _OutputControl.Text.Length
                _OutputBuffer.Clear()
            End SyncLock
        End Sub

        Private Sub ClearOutput()
            ClearData()
            '_OutputControl.Clear()
        End Sub

        Friend MustOverride Sub WriteData(Data As String)
        Friend MustOverride Sub ClearData()

    End Class
End Namespace