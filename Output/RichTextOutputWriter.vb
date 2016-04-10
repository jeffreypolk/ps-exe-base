Namespace Output
    Public Class RichTextOutputWriter
        Inherits UIOutputWriter(Of RichTextBox)

        Private _Control As RichTextBox

        Sub New(Control As RichTextBox)
            MyBase.New(Control)
            _Control = Control
        End Sub

        Friend Overrides Sub ClearData()
            _Control.Text = String.Empty
        End Sub

        Friend Overrides Sub WriteData(Data As String)
            _Control.AppendText(Data)
            _Control.SelectionStart = _Control.Text.Length
        End Sub
    End Class
End Namespace