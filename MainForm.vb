'
' Created by SharpDevelop.
' User: madman190382
' Date: 2013/06/14
' Time: 23:08
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Public Partial Class MainForm
	Public shared dbSource As String = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\madman190382\Documents\SharpDevelop Projects\uex\DataBase\uexdb.mdb"
	
	Dim Wc As New WordContainer
	Public Sub New()
		'TODO:サイズをDisplayに依存しない
		Me.InitializeComponent()
		Dim El As New SetEnvList(Wc)
		El.SelectEnvSql()
		El = Nothing
		Using g As Graphics = Me.CreateGraphics()
			Wc.inchSize(1) = g.DpiX
			Wc.inchSize(0) = g.DpiY
		End Using
	End Sub
	
	Sub MainFormLoad(sender As Object, e As EventArgs)

		
	End Sub
	
	
	Sub Btn_HostRegister_Click(sender As Object, e As EventArgs)
		'TODO

		
	End Sub
	
	Public Sub Btn_Print_Click(sender As Object, e As EventArgs)
		Dim Pr As New PrintReport(Wc)
		Pr.Showdialog()
		Pr.Dispose()
		Pr = Nothing
	End Sub
	
End Class
