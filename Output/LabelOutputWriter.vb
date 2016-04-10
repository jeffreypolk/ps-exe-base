Namespace Output
    Public Class LabelOutputWriter
        Inherits UIOutputWriter(Of Label)

        Private _Control As Label

        Sub New(Control As Label)
            MyBase.New(Control)
            _Control = Control
        End Sub

        Friend Overrides Sub ClearData()
            _Control.Text = String.Empty
        End Sub

        Friend Overrides Sub WriteData(Data As String)
            _Control.Text = Data
        End Sub
    End Class
End Namespace