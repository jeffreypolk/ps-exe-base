Public Class Starter

    Public Shared Sub Start(Manager As IManager)
        Try
            If Args.ArgCount = 0 Then
                'load the form
                Application.EnableVisualStyles()
                Using frm As Form = Manager.GetStartupForm()
                    System.Windows.Forms.Application.Run(frm)
                End Using
            Else
                Manager.ExecuteCommandLine()
            End If
        Catch ex As ArgumentException
            'this is an expected error - just show the message
            Util.ShowException(ex.Message)
        Catch ex As Exception
            'this is an unexpected error - show the whole thing
            Util.ShowException(ex)
        End Try
    End Sub

End Class
