
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public NotInheritable Class NotepadHelper
    Private Sub New()
    End Sub
    <DllImport("user32.dll", EntryPoint:="SetWindowText")>
    Private Shared Function SetWindowText(hWnd As IntPtr, text As String) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="FindWindowEx")>
    Private Shared Function FindWindowEx(hwndParent As IntPtr, hwndChildAfter As IntPtr, lpszClass As String, lpszWindow As String) As IntPtr
    End Function

    <DllImport("User32.dll", EntryPoint:="SendMessage")>
    Private Shared Function SendMessage(hWnd As IntPtr, uMsg As Integer, wParam As Integer, lParam As String) As Integer
    End Function

    Public Shared Sub ShowMessage(Optional message As String = Nothing, Optional title As String = Nothing)
        Dim notepad As Process = Process.Start(New ProcessStartInfo("notepad.exe"))
        If notepad IsNot Nothing Then
            notepad.WaitForInputIdle()

            If Not String.IsNullOrEmpty(title) Then
                SetWindowText(notepad.MainWindowHandle, title)
            End If

            If Not String.IsNullOrEmpty(message) Then
                Dim child As IntPtr = FindWindowEx(notepad.MainWindowHandle, New IntPtr(0), "Edit", Nothing)
                SendMessage(child, &HC, 0, message)
            End If
        End If
    End Sub
End Class
