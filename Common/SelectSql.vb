Imports System.Data.OleDb

' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 14:15
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'


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
	
''''■GetOneSql
''' <summary>Get data only from one field</summary>
''' <param name="sqlText">Sql command</param>
''' <returns>db data from specific one field of db by String</returns>
	Public function GetOneSql(sqltext As string) As String
		
		Dim result As String = ""
		
		If sqltext <> "" Then
			
			Dim sqlCon As New OleDbConnection
			Dim sqlCommand As New OleDbCommand
			Dim sqlreader As OleDbDataReader
			
			sqlCon.ConnectionString = MainForm.dbSource
			sqlCommand.Connection = sqlCon
			sqlCommand.CommandText = sqltext
			
			sqlCon.Open()
			sqlreader = sqlCommand.ExecuteReader()
			
			If sqlreader.HasRows = True Then
				While sqlreader.Read()
						result = sqlreader(0).ToString()
				End While
			End If
			
			sqlCommand.Dispose()
			sqlreader.Close()
			sqlCon.Close()
			
			sqlCommand = Nothing
			sqlreader = Nothing
			sqlCon = Nothing
			
		End If
		
		Return result
		
	End Function
	
End Class
