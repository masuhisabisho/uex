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
		Dim curFontSize As Integer = CInt(curWord(lineNo)(0)(1))
		Dim fontSizeDif As Boolean = False
		For i As Integer = 0 To CInt(curWord(lineNo).Count) -1 Step 1
			If curFontSize <> CInt(curWord(lineNo)(i)(1)) Then
				fontSizeDif = True 
			End If
		Next i
		'ArrayListの値を移しておく
		Dim tempCurWord As New Hashtable
		tempCurWord("fontSize") = curWord(lineNo)(0)(1)
		tempCurWord("topYPos") = curWord(lineNo)(0)(2)
		tempCurWord("xPos") = curWord(lineNo)(0)(3)
		
		
		'curWordの任意の行のデータを削除しておく
		Dim wordCnt As Integer = curWord(lineNo).Count 
		curWord(lineNo).RemoveRange(0, wordCnt)
		
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
		
		Dim newYPos As Single = tempCurWord("topYpos")
		Dim basicPitch As Single = Cmn.SetBasicPitch
		'不変文字と挿入文字を一つの配列に格納していく
		Dim wordInLine As New ArrayList()
		Dim k As Integer = 0
		Dim l As Integer = 0
		If fontSizeDif = False Then												'全て同じの時
			For i As Integer = 0 To loopCounter - 1 Step 1
				If  IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(3)) =  i Then	'END エラーをかわす（insWordに配列が1つしかなく文の先頭にある時など）WordPreparerも
					Dim int As Integer = insWord(k)(0)
					For j As Integer = 4 To CInt(insWord(k)(0)) + 3  Step 1
						Dim wordDetail(3) As String
						wordDetail(0) = insWord(k)(j)
						wordDetail(1) = tempCurWord("fontSize")
						wordDetail(2) = newYPos
						wordDetail(3) = tempCurWord("xPos")
						wordInLine.Add(wordDetail)
						Dim tempYPos() As Single = pr.FontSizeCal(insWord(k)(j), "MS P明朝", tempCurWord("fontSize"))
						newYPos = newYPos + tempYPos(0) + basicPitch
						
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				Else
					Dim wordDetail(3) As String
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(l, 1)
					wordDetail(1) = tempCurWord("fontSize")
					wordDetail(2) = newYPos
					wordDetail(3) = tempCurWord("xPos")
					wordInLine.add(wordDetail)
					Dim tempYPos() As Single = pr.FontSizeCal(wordDetail(0), "MS P明朝", CInt(tempCurWord("fontSize")))
					newYPos = newYPos + tempYPos(0) + basicPitch
					l = l + 1
				End If
			Next i
			curWord(lineNo) = wordInLine						'2017/7/21 curWord(0) -> curWord(lineNo)へ mb
			
'		#If Debug then
'		Dim z As Integer = 0
'		Dim x As Integer = 0
'		Dim y As Integer = 0
'		Dim zcnt As Integer = curWord.Count
'		While x < curWord.Count
'			While z < curWord(x).count 
'				while y < 4
'					System.Diagnostics.Debug.WriteLine(curWord(x)(z)(y))
'					y += 1
'				End While
'				y = 0
'				z = z + 1	
'			End While
'			z = 0
'			x = x + 1
'		End while
'		#End If
			
			
			
		Else																	'フォントサイズが違う時
			Dim wordStrager(loopCounter + 1) As String
			wordStrager(0) = loopCounter
			
			Dim collectPoint As String
			
			For i As Integer = 2 To loopCounter + 1 Step 1
				If CInt(insWord(3)) =  i Then 
					For j As Integer = 4 To CInt(insWord(0)) - 1 Step 1  'CHK
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
										"MS P明朝", _
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
			optWord("Cmb_Year") = .Cmb_Year.SelectedIndex
			optWord("Cmb_Month") = .Cmb_Month.SelectedIndex
			optWord("Cmb_Day") = .Cmb_Day.SelectedIndex
			
			Dim SctSql As New SelectSql()
			Dim resultWareki As String = ""
			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & frm.Cmb_Year.SelectedValue)
			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & frm.Cmb_Month.SelectedValue)
			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & frm.Cmb_Day.SelectedValue)
			SctSql = Nothing
			optWord("Txt_CeremonyDate") = resultWareki

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

			optWord("Common_Point") = defSetAr(1)									'共通フォントサイズ
			optWord("Common_Font") = .Cmb_Font.text									'CHK: SelectedValue, SelectedIndex, Textの違い
			optWord("Cmb_PointTitle") = .Cmb_PointTitle.SelectedIndex
			optWord("Cmb_PointName") = .Cmb_PointName.SelectedIndex
			optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.SelectedValue
			optWord("Cmb_PointImibi") = .Cmb_PointImibi.SelectedIndex
			optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.SelectedValue
			optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.SelectedIndex
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
