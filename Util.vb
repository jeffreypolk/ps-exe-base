Public Class Util

    Private Shared _AppPath As String

#Region " Fonts"

    Public Shared Sub InitializeFonts(ByVal f As Control)
        f.Font = SystemFonts.MessageBoxFont
        For Each c As Control In f.Controls
            ChangeFont(c)
        Next
    End Sub

    Private Shared Sub ChangeFont(ByVal c As Control)
         'maintain configured size
        Dim Size As Single = c.Font.Size
        'set font
        c.Font = New Font(SystemFonts.MessageBoxFont.Name, Size)
        For Each c2 As Control In c.Controls
            ChangeFont(c2)
        Next
    End Sub

#End Region

    Public Shared ReadOnly Property AppPath() As String
        Get
            If String.IsNullOrEmpty(_AppPath) Then
                _AppPath = System.AppDomain.CurrentDomain.BaseDirectory().TrimEnd(New Char() {"\"})
            End If
            Return _AppPath
        End Get
    End Property

#Region " Messages"

    Public Shared Sub ShowMessage(Message As String, Optional Title As String = "Information")
        MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub ShowException(Message As String)
        MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub ShowException(Ex As Exception)
        MessageBox.Show(Ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Function ShowConfirm(Message As String) As Boolean
        Dim Ret As Boolean = False
        If MessageBox.Show(Message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Ret = True
        End If
        Return Ret
    End Function

#End Region


End Class
