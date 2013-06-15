Imports System.Data.OleDb
'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 18:09
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class SetEnvList
	Public shared envList As New Hashtable
	
	'****************************************************************************************************
	'
	'	Arrange evviroment data from mdb (multiple line)
	'	sqlText = Sql command
	'	dbSource = Database connect information
	'
	'****************************************************************************************************
	
	Public sub SelectEnvSql (dbSource As String, sqltext As String)
		Dim envListArl As New ArrayList
		Dim tempID As String = ""
		
		Dim sqlCon As New OleDbConnection
		Dim sqlCommand As New OleDbCommand
		Dim sqlReader As OleDbDataReader

		sqlCon.ConnectionString = dbSource
		sqlCommand.Connection = sqlCon
		sqlCommand.CommandText = sqltext
		
		sqlCon.Open()
		sqlReader = sqlCommand.ExecuteReader()
		
		If sqlReader.HasRows = True Then
			While sqlReader.Read()
				If tempID = "" Then
					tempID = sqlReader("tbl_env_grid").ToString
				End If
				
				If tempID <> sqlReader("tbl_env_grid").ToString() Then
					envList.Add(String.Format("{0:000}", Val(tempID)), envListArl)
					tempID = sqlReader("tbl_env_grid").ToString()
					envListArl = New ArrayList
				End If
				
				envListArl.Add(New DictionaryEntry(sqlReader("tbl_env_label").ToString(), sqlReader("tbl_env_value").ToString()))
				
			End While
			
			sqlCommand.Dispose()
			sqlReader.Close()
			sqlcon.close()
		
			sqlCommand = Nothing
			sqlReader = Nothing
			sqlCon = Nothing
		End If
		
		envListArl = Nothing

#If Not Debug Then
Try			
Catch ex As Exception
MessageBox.Show (ex.Message)	
End Try
#End If 
				
	End sub
End Class
