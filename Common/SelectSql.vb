Imports System.Data.OleDb

' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 14:15
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class SelectSql
	
#Region "SQL本体"
	
''''■GetSqlList
''' <summary>ArrayListで1フィールド、多数の値を取得</summary>
''' <param name="sqlText">String Sql command</param>
''' <param name="keyColumn">String 取得したい値のフィールド名</param>
''' <returns>ArrayListを返す</returns>
	Public Function GetSqlList (sqltext As String, keyColumn As String) As ArrayList
		Dim listAl As New ArrayList
		
		Dim sqlCon As New OleDbConnection
		Dim sqlCommand As New OleDbCommand
		Dim sqlReader As OleDbDataReader

		sqlCon.ConnectionString = MainForm.dbSource
		sqlCommand.Connection = sqlCon
		sqlCommand.CommandText = sqltext
		
		sqlCon.Open()
		sqlReader = sqlCommand.ExecuteReader()
		
		If sqlReader.HasRows = True Then
			While sqlReader.Read()
				Dim getResult = "" & sqlReader(keyColumn).ToString()
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

	End Function
	
''''■GetSqlArray
''' <summary>Get data from multiple lines</summary>
''' <param name="sqlText">Sql command</param>
''' <returns>multiple db data from db as Arraylist</returns>
	Public Function GetSqlArray (sqltext As String) As ArrayList
		Dim listAl As New ArrayList
		
		Dim sqlCon As New OleDbConnection
		Dim sqlCommand As New OleDbCommand
		Dim sqlReader As OleDbDataReader

		sqlCon.ConnectionString = MainForm.dbSource
		sqlCommand.Connection = sqlCon
		sqlCommand.CommandText = sqltext
		
		sqlCon.Open()
		sqlReader = sqlCommand.ExecuteReader()
		
		If sqlReader.HasRows = True Then
			While sqlReader.Read()
				Dim getResult As New Hashtable
				For i As Integer = 0 To sqlReader.FieldCount -1 Step 1
					getResult(sqlReader.GetName(i)) = "" & sqlReader(i).ToString()
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

	End Function
	
''' ■GetOneLineSql
''' <summary> DBから値を取得します(1行のみ)</summary>
''' <param name="sqlText">SQL文</param>
''' <returns>取得した値のハッシュテーブル</returns>
''' <remarks></remarks>
	Public Function GetOneLineSql(ByVal sqlText As String) As Hashtable

        Dim returnHash As New Hashtable

        If sqlText <> "" Then

            Dim sqlCon As New OleDbConnection
            Dim sqlCommand As New OleDbCommand
            Dim sqlReader As OleDbDataReader

            sqlCon.ConnectionString = MainForm.dbSource
            sqlCommand.Connection = sqlCon
            sqlCommand.CommandText = sqlText

            sqlCon.Open()
            sqlReader = sqlCommand.ExecuteReader()

            If sqlReader.HasRows = True Then
                While sqlReader.Read()
                    For i = 0 To sqlReader.FieldCount - 1
                        returnHash(sqlReader.GetName(i)) = "" & sqlReader(i).ToString
                    Next
                End While
            End If

            sqlCommand.Dispose()
            sqlReader.Close()
            sqlCon.Close()

            sqlCommand = Nothing
            sqlReader = Nothing
            sqlCon = Nothing

        End If

        Return returnHash

        returnHash = Nothing

	End Function
	
''''■GetOneSql
''' <summary>Get data only from one field</summary>
''' <param name="sqlText">Sql command</param>
''' <returns>db data from specific one field of db as String</returns>
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
	
''' <summary>DBから値を取得します(取り出したい値のみ)</summary>
''' <param name="sqlText">SQL文</param>
''' <param name="keyColumn">HashTableのKey値</param>
''' <param name="valueColumn">取得したいカラム名</param>
''' <returns>取得した値のHashtable</returns>
''' <remarks></remarks>
    Public Function GetSqlHashRow(ByVal sqlText As String, ByVal keyColumn As String, ByVal valueColumn As String) As Hashtable
    	
    	Dim returnHash As New Hashtable

        Dim sqlCon As New OleDbConnection
        Dim sqlCommand As New OleDbCommand
        Dim sqlReader As OleDbDataReader

        sqlCon.ConnectionString = MainForm.dbSource
        sqlCommand.Connection = sqlCon
        sqlCommand.CommandText = sqlText

        sqlCon.Open()
        sqlReader = sqlCommand.ExecuteReader()

        If sqlReader.HasRows = True Then
            While sqlReader.Read()
                returnHash(sqlReader(keyColumn).ToString) = "" & sqlReader(valueColumn).ToString
            End While
        End If

        sqlCommand.Dispose()
        sqlReader.Close()
        sqlCon.Close()

        sqlCommand = Nothing
        sqlReader = Nothing
        sqlCon = Nothing

        Return returnHash

		returnHash = Nothing

	End Function
#End Region
	
#Region "SQLを使用したFunction"
'''■ GetSentence
''' <summary>描画用文字データを返す</summary>
''' <param name="sizeID">用紙サイズID</param>
''' <param name="sytleID">文例ID</param>
''' <returns>ArrayListで描画用文字データを返す</returns>

	Public Function GetSentence(sizeID As Integer, styleID As integer) As ArrayList 
		Dim sqlText as String = ""
		Dim resultTxt As New ArrayList　'CHK: 開放
		
		sqlText &= " SELECT "														'**参考　インチ = 0.0254m
		sqlText &= "  tbl_txt_txt "													'メインの文章 　
		sqlText &= " ,tbl_txt_newypos "												'開始位置の変更		ある時 = 値・無い時 = 9999
		sqlText &= " ,tbl_txt_ystyle "												'列スタイル 			上から並べる = 0・下から並べる  = 1・天地を合わせる = 2
		sqlText &= " ,tbl_txt_inspos "												'挿入文字の有無		ある時 = 値(コンマで区切る）無い時 9999, 9999, 9999
		sqlText &= " ,tbl_txt_targetword "											'挿入文字				文字コンボの値を格納したHashTableのキー名
		sqlText &= " ,tbl_txt_targetpoint "											'挿入文字				フォントサイズの値を格納したHashTableのキー名
		sqlText &= " ,tbl_txt_newxpos "												'新行ピッチ			ある時 = 値・ない時 = 9999
		sqlText &= " ,tbl_txt_newpoint "											'新フォントサイズ	
		sqlText &= "  FROM tbl_txt "
		sqlText &= "  WHERE "
		sqlText &= "  tbl_txt_sizeid = " & sizeID 
		sqlText &= "  AND tbl_txt_styleid = " & styleID										'TODO: パラメーターで選択 = Cmbで
		sqlText &= "  ORDER BY "
		sqlText &= "  tbl_txt_order "
	
		resultTxt = GetSqlArray(sqlText)
		
		Return resultTxt
		
	End Function
'''■ SetDefaultVal
''' <summary>初期設定値を設定する</summary>
''' <param name="sizeID">tbl_defsetのID</param>
''' <returns>WordContainer.vbに値を保存する</returns>	'2013/8/3 Function　-> Subへ全てまとめて処理するように変更 mb
	Public Sub SetDefaultVal(sizeID As Integer, Wc As WordContainer)
		
		Dim sqlText As String= ""
		Dim defset As String = ""
		Dim resultDefset() As String 
		
		sqlText =  " SELECT "														'初期設定
		sqlText &= " tbl_defset"													'(0) 縦 = 0・横 = 1, (1) ポイント (2) x座標（幅), 
		sqlText &= " FROM tbl_defset"												'(3) y座標上,　(4) y座標下, (5) 基本の改行ピッチ
		sqlText &= " WHERE tbl_defset_id = " & sizeID								'MEMO: tbl_defset_idは上と連動させる
		
		defset = GetOneSql(sqlText)
		resultDefset = defSet.Split(","c)
		
		For i As Integer = 0 To resultDefset.Length -1 Step 1
			Wc.DefSet(i) = resultDefset(i)
		Next i
		
	End Sub
	
'''■ GetTbl_TxtRow
''' <summary>tbl_txtの任意の1行の全ての値を返す</summary>
''' <param name="sizeID">Integer 用紙サイズID</param>
''' <param name="sytleID">Integer 文例ID</param>
''' <param name="orderNo">Integer 行番号</param>
''' <returns>Tbl_txtの任意の1行の全ての値をHashtableで返す</returns>
	Public Function GetTbl_TxtRow(sizeID As Integer, styleID As integer, orderNo As Integer) As Hashtable
		Dim sqlText as String = ""
		Dim resultTxt As New Hashtable
		
		sqlText &= " SELECT * FROM tbl_txt "
		sqlText &= " WHERE tbl_txt_sizeid = " & sizeID
		sqlText &= " AND tbl_txt_styleid = " & styleID
		sqlText &= " AND tbl_txt_order = " & orderNo
		
		resultTxt = GetOneLineSql(sqlText)
		
		Return resultTxt
	End Function
	#End Region	
	
End Class
