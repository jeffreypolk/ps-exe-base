Public Class ProcessRunner

    Property FileName As String
    Property Arguments As String
    Property OutputWriter As Output.IOutputWriter = New Output.DummyOutputWriter
    Private _Output As String = String.Empty
    ReadOnly Property Output As String
        Get
            Return _Output
        End Get
    End Property

    Public Sub Run()
        Dim proc As New System.Diagnostics.Process
        Dim TempOutput As String
        Dim OutputBuilder As New System.Text.StringBuilder
        _Output = String.Empty

        With proc.StartInfo
            .FileName = FileName
            .Arguments = Arguments
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .UseShellExecute = False
            .CreateNoWindow = True
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        proc.Start()

        'standard output
        While proc.StandardOutput.EndOfStream = False
            TempOutput = proc.StandardOutput.ReadLine
            If String.IsNullOrEmpty(TempOutput) = False Then
                OutputBuilder.AppendLine(TempOutput)
                If OutputWriter IsNot Nothing Then
                    OutputWriter.WriteLine(TempOutput)
                End If
            End If
        End While

        'standard error
        While proc.StandardError.EndOfStream = False
            TempOutput = proc.StandardError.ReadLine
            If String.IsNullOrEmpty(TempOutput) = False Then
                OutputBuilder.AppendLine(TempOutput)
                If OutputWriter IsNot Nothing Then
                    OutputWriter.WriteLine(TempOutput)
                End If
            End If
        End While

        _Output = OutputBuilder.ToString
        proc.Dispose()
    End Sub

End Class
