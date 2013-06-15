'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 14:15
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Data.OleDb

Public Class SelectSql
	'****************************************************************************************************
	'
	'	Aquire data from mdb (multiple line)
	'	sqlText = Sql command
	'	dbSource = Database information
	'
	'****************************************************************************************************
	
	Public Function SelectSql (dbSource As String, sqltext As String) As ArrayList
		Dim listAl As New ArrayList
		
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
				Dim getResult As New Hashtable
				For i As Integer = 0 To sqlReader.FieldCount -1 Step 1
					getResult(sqlReader.GetName(i)) = sqlReader(i).ToString()
				Next i
				listAl.Add(getResult)
				getResult = Nothing
			End While
			
			sqlCommand.Dispose()
			sqlReader.Close()
			sqlcon.close()
		
			sqlCommand = Nothing
			sqlReader = Nothing
			sqlCon = Nothing
		End If
		
		Return listAl

		listAl = Nothing
		

#If Not Debug Then
Try			
Catch ex As Exception
MessageBox.Show (ex.Message)	
End Try
#End If 
				
	End Function
	
End Class
