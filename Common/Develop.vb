'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/10/27
' 時刻: 22:52
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'

Option Explicit On
Imports System.Diagnostics.Debug

Public Module Develop
	
#Region "開発用文字配列出力関数"
	
#If debug Then
''' <summary>ArrayList -> ArrayList -> String()</summary>
''' <param name="storageWord"></param>
''' <param name="fileName"></param>
''' <param name="CtrMessage"></param>
''' <param name="msg"></param>
	Public Sub	CheckErrSentence(ByVal storageWord As ArrayList, _
									ByVal fileName As String, _
									Optional CtrMessage As Boolean = True, 
									Optional ByVal msg As String = "フォントサイズ違い")
		Dim path As String = ""
		If CtrMessage = True Then
			MessageBox.Show(msg)
		End If
		
		path = "C:\Users\madman190382\Desktop\Debug\" & fileName & ".txt"
		
		Dim outputStr As String = ""
		
		Dim z As Integer = 0
		Do Until z = storageWord.Count
			Dim q As Integer = 0
			outputStr &= z & "行目" & vbCrLf
			Do Until q = DirectCast(storageWord(z), ArrayList).Count
				Dim o As Integer = 0
				Do Until o = DirectCast(DirectCast(storageWord(z), ArrayList)(q), String()).Length
					outputStr &= DirectCast(DirectCast(storageWord(z), ArrayList)(q), String())(o) & "★"
					o += 1	
				Loop
				outputStr &= vbCrLf
				q += 1
			Loop
			outputStr &= vbCrLf
			q = 0
			z += 1
		Loop
		Dim sw As System.IO.StreamWriter = Nothing
		Try
			sw = New System.IO.StreamWriter(path, False, System.Text.Encoding.GetEncoding("UTF-8"))
			sw.WriteLine(outputStr)
		Catch e As Exception
			MessageBox.Show(fileName & "ログの保存に失敗しました")
		Finally
			If sw IsNot Nothing Then
				sw.Close()
				sw.Dispose()
			End If
		End Try
		
	End Sub

''' <summary>ArrayLIst -> String()</summary>
''' <param name="storageWord"></param>
''' <param name="fileName"></param>
	Public Sub CheckErrSentence2(ByVal storageWord as Arraylist, ByVal fileName as string)
		Dim path As String = ""
		path = "C:\Users\madman190382\Desktop\Debug\" & fileName & ".txt"
		
		Dim outputStr As String = ""
		
		Dim z As Integer = 0
		Do Until z = storageWord.Count
			Dim q As Integer = 0
			Do Until q = DirectCast(storageWord(z), String()).Length
				outputStr &= DirectCast(storageWord(z), String())(q)
				outputStr  &= "★"
				q += 1
			Loop
			outputStr &= vbCrLf
			z += 1
		Loop
		Dim sw As System.IO.StreamWriter = Nothing
		Try
			sw = New System.IO.StreamWriter(path, False, System.Text.Encoding.GetEncoding("UTF-8"))
			sw.WriteLine(outputStr)
		Catch e As Exception
			MessageBox.Show(fileName & "ログの保存に失敗しました")
		Finally
			If sw IsNot Nothing Then
				sw.Close()
				sw.Dispose()
			End If
		End Try 
	End Sub
	
''' <summary>
''' 
''' </summary>
''' <param name="ot"></param>
	Public Sub CheckDefSet(ot As ArrayList)
		
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
			For j As Integer = 0 To CInt(DirectCast(ot(i), ArrayList).Count) - 1 Step 1
				outputStr &= j & ") " & DirectCast(ot(i), ArrayList)(j).ToString() & vbCrLf
			Next j
		Next i
		
		Dim sw As System.IO.StreamWriter = Nothing
		Try
			sw = New System.IO.StreamWriter("C:\Users\madman190382\Desktop\Debug\DEFINITIONSETTING.txt", _
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
	
	Public Sub ConsolePrint(list As ArrayList)
		
		For i As Integer = 0 To list.Count - 1 Step 1
			WriteLine(i.ToString() & ")" & list(i).ToString())
		Next i
		
	End Sub
	
	
#End If

#End Region
	
End Module
