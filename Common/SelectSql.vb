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
		Dim resultTxt As New ArrayList
		
		sqlText &= " SELECT "														'**参考　インチ = 0.0254m
		sqlText &= "  tbl_txt_order "
		sqlText &= " ,tbl_txt_txt "													'メインの文章 　
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
		sqlText &= "  AND tbl_txt_styleid = " & styleID										'END: パラメーターで選択 = Cmbで
		sqlText &= "  ORDER BY "
		sqlText &= "  tbl_txt_order "
	
		resultTxt = GetSqlArray(sqlText)
		
		Return resultTxt
		
	End Function
'''■ SetDefaultVal
''' <summary>初期設定値を設定する</summary>
''' <param name="sizeID">用紙サイズID</param>
''' <param name="styleID">文例ID</param>
''' <returns>WordContainer.vbに値を保存する</returns>	'2013/8/3 Function　-> Subへ全てまとめて処理するように変更 mb
	Public Sub SetDefaultVal(sizeID As Integer, styleID As Integer, Wc As WordContainer)
		'配列の初期化
		Wc.TempCurrentWord.Clear()
		Wc.curWord.Clear()
		Wc.mainTxt.Clear()
		Wc.TxtMultiLine.Clear()
		Wc.CmbTxtPntEnabled.Clear()

		Wc.ComboTextPos.Clear()
		Wc.ComboTextStr.Clear()
		Wc.ComboTextPoint.Clear()
		
		'現在の用紙サイズID															'2013/10/6 PrintReportより移動
		Wc.CurrentSet("curSize") = sizeID
		Wc.CurrentSet("curStyle") = styleID
		
		Dim sqlText As String= ""
		Dim getList As New Hashtable
		
		Dim splitList0() As String
		Dim splitList1() As String
		Dim splitList2() As String
		Dim splitList3() As String
		Dim splitList4() As String
		Dim splitLIst5() As String
		
		Dim getListAr1 As New ArrayList
		Dim getListAr2 As New ArrayList
		Dim getListAr3 As New ArrayList
		Dim getListAr4 As New ArrayList
		Dim getListAr5 As New ArrayList
		
		sqlText =  "  SELECT "
		sqlText &= "  tbl_defset_base AS base "
		sqlText &= " ,tbl_defset_line as line "
		sqlText &= " ,tbl_defset_str as str "
		sqlText &= " ,tbl_defset_point as point "
		sqlText &= " ,tbl_defset_multi as multi "
		sqlText &= " ,tbl_defset_enabled as ebl"
		sqlText &= "  FROM tbl_defset "
		sqlText &= "  WHERE tbl_defset.tbl_defset_id = " & sizeID
		sqlText &= "  AND tbl_defset.tbl_defset_style_id = " & styleID
		
		getList = GetOneLineSql(sqlText)
		
		'用紙の初期設定
		splitList0 = getList("base").ToString().Split(","c)
		For i As Integer = 0 To splitList0.Length -1 Step 1
			Wc.DefSet(i) = splitList0(i)
		Next i
		
		'可変文字列の行番号
		splitList1 = getList("line").ToString().Split(","c)
		For i As Integer = 0 To splitList1.Length - 1 Step 1
			getListAr1.Add(splitList1(i))
		Next i
		Wc.ComboTextPos = getListAr1
		
		'可変文字列の初期値
		splitList2 = getList("str").ToString().Split(","c)
		For i As Integer = 0 To splitList2.Length - 1 Step 1
			getListAr2.Add(splitList2(i))
		Next i
		Wc.ComboTextStr = getListAr2
		
		'フォントサイズの初期値
		splitList3 = getList("point").ToString().Split(","c)
		For i As Integer = 0 To splitList3.Length - 1 Step 1
			getListAr3.Add(CInt(splitList3(i)))
		Next i
		Wc.ComboTextPoint = getListAr3
		
		'複数行のフォントサイズ変更時の行数				追加 2013/10/16
		splitList4 = getList("multi").ToString.Split(","c)
		For i As Integer = 0 To splitList4.Length -1 Step 1
			getListAr4.Add(CInt(splitList4(i)))
		Next i
		Wc.TxtMultiLine = getListAr4

		'コンボ・テキストボックス可視性の初期値
		splitList5 = getList("ebl").ToString().Split(","c)
		For i As Integer = 0 To splitList5.Length - 1 Step 1
			getListAr5.Add(CInt(splitList5(i)))
		Next i
		Wc.CmbTxtPntEnabled = getListAr5
		
		getListAr1 = Nothing
		getListAr2 = Nothing
		getListAr3 = Nothing
		getListAr4 = Nothing
		getListAr5 = Nothing
		
		Dim ot As New ArrayList
		ot.Add(Wc.ComboTextPos)
		ot.Add(Wc.ComboTextStr)
		ot.Add(Wc.ComboTextPoint)
		ot.Add(Wc.TxtMultiLine)
		ot.Add(Wc.CmbTxtPntEnabled)
		
		Dim outputStr As String = ""
		
		For i As Integer = 0 To ot.Count -1 Step 1
			Select Case i
				Case 0
					outputStr &= "★コンボの値を入れる行番★" & vbCrLf
				Case 1
					outputStr &= "★コンボ（テキスト）の値★" & vbCrLf
				Case 2
					outputStr &= "★コンボ（フォントサイズ）の★" & vbCrLf
				Case 3
					outputStr &= "★コンボマルチ行の行数★" & vbCrLf
				Case 4
					outputStr &= "★コンボの可視性★" & vbCrLf
			End Select
			For j As Integer = 0 To ot(i).Count -1 Step 1
				outputStr &= j & ") " & ot(i)(j) & vbCrLf
			Next j
		Next i
		
		Dim sw As System.IO.StreamWriter = Nothing
		Try
			sw = New System.IO.StreamWriter("C:\Users\madman190382\Desktop\DefinitionSetting.txt", _
											 False,
											 System.Text.Encoding.GetEncoding("UTF-8")
										   )
			sw.WriteLine(outputStr)
		Catch e As Exception
			MessageBox.Show("初期設定ログの保存に失敗しました")
		Finally
			If sw IsNot Nothing Then
				sw.Close()
				sw.Dispose()
			End If
		End Try
		
		
	End Sub
	
	#End Region	
	
End Class
