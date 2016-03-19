Usage...

Create Manager.vb.............................................................................................

	Imports PS.ExeBase

	Public Class Manager
		Implements PS.ExeBase.IManager

		Public Sub ExecuteCommandLine() Implements IManager.ExecuteCommandLine
			Throw New NotImplementedException()
		End Sub

		Public Function GetStartupForm() As Form Implements IManager.GetStartupForm
			Return New MainForm
		End Function
	End Class

Create StartUp.vb...............................................................................................

	Module StartUp
		Sub Main()
			PS.ExeBase.Starter.Start(New Manager)
		End Sub
	End Module



