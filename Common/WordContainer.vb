'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/13
' 時刻: 10:19
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class WordContainer
	
	Private curSize As Integer
	Private curStyle As Integer 
	
	Public optWord As New Hashtable()
	Public curWord As New ArrayList()
	
	'データを置き換える
''' ■WordReplacer
''' <summary>コンボ変更に対して文字挿入、y軸位置、x軸位置を決める</summary>
''' <param name="lineNo">Integer 行番号</param>
''' <param name="newTargetCmb">ComboBox 動かされるコンボ</param>
''' <param name="pr">Frm PrintReport.vb</param>
''' <param name="Cmn">Frm Common.vb</param>
''' <param name="yPos">Optional Integer 上、下、天地</param>
	Sub WordReplacer(lineNo As Integer, newTargetCmb As ComboBox, _
					pr As PrintReport, Cmn As Common, 
		Optional yPos As Integer = 0)
		'コンボの値を置き換え
		optWord(newTargetCmb.Name) = newTargetCmb.SelectedValue
		'フォントサイズが全て同じかどうか確認する
		Dim curFontSize As Integer = CInt(curWord(0)(1))
		Dim fontSizeDif As Boolean = False
		For i As Integer = 0 To CInt(curWord.Count) -1 Step 1
			If curFontSize <> CInt(curWord(i)(1)) Then
				fontSizeDif = True 
			End If
		Next i
		'ArrayListの値を移しておく
		Dim tempCurWord As New ArrayList()
		tempCurWord = curWord(lineNo)		
		
		'curWordの任意の行のデータを削除しておく
		curWord(lineNo).Remove()
		
		Dim mainTxt As New Hashtable()
		Dim SctSql As New SelectSql()
		
		mainTxt = SctSql.GetTbl_TxtRow(curSize, curSize, lineNo)
		
		Dim insPos() As String
		insPos = CStr(mainTxt("tbl_txt_inspos")).Split(","c)
		
		Dim insWord As array
		insWord = Cmn.CheckInsWord(mainTxt("tbl_txt_inspos"), _
                                   mainTxt("tbl_txt_targetword"), _
                                   mainTxt("tbl_txt_targetpoint"), _
                                   lineNo, _
                                   optWord _
                                   )
		
		Dim loopCounter As Integer = CInt(CStr(mainTxt("tbl_txt_txt")).Length)
		'挿入文字の字数をループカウンターに入れる
		For i As Integer = 0 To 2 Step 1
        	If CInt(insPos(i)) <> 9999 Then
        		loopCounter = loopCounter + CInt(insWord(i)(0))
        	End If
        Next i 
		'不変文字と挿入文字を一つの配列に格納していく
		Dim wordInLine As New ArrayList()
		Dim k As Integer = 0
		If fontSizeDif = False Then												'全て同じの時
			For i As Integer = 0 To loopCounter - 1 Step 1
				If CInt(insWord(i)(3)) =  i Then 
					For j As Integer = 4 To CInt(insWord(i)(0)) + 3 Step 1
						Dim wordDetail(3) As String
						wordDetail(0) = insWord(i)(j)
						wordDetail(1) = tempCurWord(0)(1)
						worddetail(3) = tempCurWord(0)(3)
						wordInLine.Add(wordDetail)
					next j
				Else
					Dim wordDetail(3) As String
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					wordDetail(1) = tempCurWord(0)(1)
					worddetail(3) = tempCurWord(0)(3)
					wordInLine.add(wordDetail)
					k = k + 1
				End If
			Next i
		Else																	'フォントサイズが違う時
			Dim wordStrager(loopCounter + 1) As String
			wordStrager(0) = loopCounter
			
			Dim collectPoint As String
			
			For i As Integer = 2 To loopCounter + 1 Step 1
				If CInt(insWord(i)(3)) =  i Then 
					For j As Integer = 4 To CInt(insWord(i)(0)) + 3 Step 1
						'SetIrregXYPos用
						wordStrager(i) = insWord(i)(j)
						Cmn.PointCollector(insWord(i)(1), collectPoint) 
						'描画用XY位置未確定
						Dim wordDetail(3) As String
						wordDetail(0) = insWord(i)(j)
						wordDetail(1) = insWord(0)(1)
						wordInLine.Add(wordDetail)
					next j
				Else
					'SetIrregXYPos用
					wordStrager(i) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					Cmn.PointCollector(insWord(i)(1), collectPoint)
					'描画用XY位置未確定
					Dim wordDetail(3) As String
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					wordDetail(1) = insWord(0)(1)
					wordInLine.add(wordDetail)
					k = k + 1
				End If
			Next i
			'イレギュラー配置を計算する
			wordStrager(1) = collectPoint

			Dim defSetAr() As String = SctSql.GetDefaultVal(curStyle)
			
			Dim eachPos(,) As Single
			Dim maxWidth As Single
			eachPos = Cmn.SetIrregXYPos(yPos, _
										wordStrager, _
										"MS Pゴシック", _
										tempCurWord(0)(2), _
										defSetAr(4), _
										defSetAr(5), _
										curWord(lineNo - 1)(3), _
										maxWidth, _
										pr
										)
			For i As Integer = 0 To loopCounter - 1 Step 1
				wordInLine(i)(2) = eachPos(0, i)
				wordInLine(i)(3) = eachPos(1, i)
			Next i
			
			curWord(lineNo) = wordInLine
			'X軸をずらしていく
			Dim basicPitch As Single = Cmn.SetBasicPitch
			Dim xPosDiff As Single = CSng(tempCurWord(lineNo)(0)(3)) - CSng(curWord(lineNo - 1)(0)(3)) - basicPitch
			
			If xPosDiff <> 0 Then
				For i As Integer = 0 To curWord.Count -1 Step 1
					For j As Integer = 0 To curWord(i).Count -1 Step 1
						curWord(i)(j)(3) = CSng(curWord(i)(j)(3)) + xPosDiff
					Next j
				Next i
				
			End If
			
		End If
	
	End Sub

'''■CurSizeStorager
''' <summary>現在表示している内容の用紙IDを保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurSizeStorager() As Integer
		Get
			Return curSize
		End Get
		Set(ByVal val As Integer)
			curSize = val
		End Set
	End Property
	
'''■CurStyleStorager
''' <summary>現在表示している内容の文例IDを保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurStyleStorager() As Integer
		Get
			Return curStyle
		End Get
		Set(ByVal val As Integer)
			curStyle = val
		End Set
	End Property
	
''''■CurrentWord
''' <summary>描画した文字情報を保管しておく
''' 1) 行
''' 2) 文字（それぞれの文字の情報を格納した配列を格納する配列）
''' 3) 文字の詳細 0 = 文字, 1 = フォントサイズ, 2 = y軸位置, 3 = x軸位置
''' </summary>
''' <param name="wordInLine">Array 文字情報</param>
''' <returns>Void</returns>
	Public Sub CurrentWord(wordInLine As ArrayList)
		curWord.Add(wordInLine)
	End Sub
	
''''■OptionaWord
''' <summary>挿入文字を保管しておく</summary>
''' <param name="defSetAr">String() 文字</param>
''' <returns>Void</returns>
	Public sub OptionalWord(defsetAr As String(), frm As PrintReport)
		With frm
		'挿入等に使う
			'Specific Part（HashTableに格納）
			optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue
			optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue
			optWord("Cmb_Title") = .Cmb_Title.SelectedValue
			optWord("Txt_Name") = .Txt_Name.Text
			optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue
			optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue
			optWord("Txt_DeadName") = .Txt_DeadName.Text
			optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue
			optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue
			optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue
			optWord("Cmb_Year") = .Cmb_Year.SelectedValue
			optWord("Cmb_Month") = .Cmb_Month.SelectedValue
			optWord("Cmb_Day") = .Cmb_Day.SelectedValue
			optWord("Txt_Add1") = .Txt_Add1.Text
			optWord("Txt_Add2") = .Txt_Add2.Text
			optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue
			optWord("Txt_HostName1") = .Txt_HostName1.Text
			optWord("Txt_HostName2") = .Txt_HostName2.Text
			optWord("Txt_HostName3") = .Txt_HostName3.Text
			optWord("Txt_HostName4") = .Txt_HostName4.Text
			optWord("Txt_PS1") = .Txt_PS1.Text
			optWord("Txt_PS2") = .Txt_PS2.Text
			optWord("Txt_PS3") = .Txt_PS3.Text
			optWord("Txt_PS4") = .Txt_PS4.Text
			optWord("Txt_PS5") = .Txt_PS5.Text
			optWord("Txt_PS6") = .Txt_PS6.Text

			'Font Size（HashTableに格納）
			optWord("Common_Point") = defSetAr(1)									'共通フォントサイズ
			optWord("Cmb_PointTitle") = .Cmb_PointTitle.SelectedItem
			optWord("Cmb_PointName") = .Cmb_PointName.SelectedValue
			optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.SelectedValue
			optWord("Cmb_PointImibi") = .Cmb_PointImibi.SelectedIndex
			optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.SelectedValue
			optWord("Cmb_PointDeremonyDate") = .Cmb_PointCeremonyDate.SelectedIndex
			optWord("Cmb_PointAdd1") = .Cmb_PointAdd1
			optWord("Cmb_PointHostType") = .Cmb_PointHostType
			optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.SelectedValue
			optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.SelectedValue	
			optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.SelectedValue
			optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.SelectedValue
			optWord("Cmb_PointPS1") = .Cmb_PointPS1.SelectedValue
			End With
	End Sub
	
End Class

'#If Debug then
'	Dim j As Integer = 0
'For i As Integer = 0 To wordInLine.Length - 1 Step 1
'			For j As Integer = 0 To 2 step 1
'				System.Diagnostics.Debug.WriteLine(wordInLine(i)(j))
'			Next j
'		Next i
'#End If 
'
'Public Function KeywordController (oneOrWhole As Boolean, getOrSet As Boolean, _ 
'									setHt As Hashtable, targetHT As Hashtable, _
'									Optional htKey As String = "" _
'									) As Hashtable
'		'TODO: ハッシュテーブル全体・単体どちらかを返す
'		If oneOrWhole = True Then
'			If getOrSet = True Then
'				
'			Else
'				
'			End If
'			
'		Else
'			
'		End If
'		
'	End Function
