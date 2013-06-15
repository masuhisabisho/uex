'
' Created by SharpDevelop.
' User: madman190382
' Date: 2013/06/14
' Time: 23:08
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class MainForm
	Public Const dbSource As String = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\madman190382\Documents\SharpDevelop Projects\uex\DataBase\uexdb.mdb"
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		' TODO : Add constructor code after InitializeComponents
	End Sub
	
	Sub MainFormLoad(sender As Object, e As EventArgs)
		Dim envListHt As ArrayList
		Dim f As New SelectSql
		envListHt = f.SelectSql(dbSource," SELECT tbl_env_grid,  tbl_env_labelFROM tbl_env, tbl_env_value ORDER BY tbl_env_grid, tbl_env_id ")
		
	End Sub
	
End Class
