'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class Common
	
	'Private  basicPitch As single = 0
	Private defSet As New Hashtable
	Private Wc As WordContainer
	'Public Sub New(newPitch As Single)
	'public Sub new(defSetAll As Hashtable)			2013/8/4 out 1 line mb
	Public sub new (wordCont As WordContainer)
	'END: コンストラクタ。ここにbasicPitchの定数を入れる basicXPitch basicYPitch DBより
		'basicPitch = newPitch
		'basicPitch = defSet(6)
		defSet = wordCont.DefSetAll.Clone
		Wc = wordCont
	End Sub

#Region "Word"
''''■WordPreparer
'<param name="optWord">Hashtable コンボの値</param>					'廃止（コンストラクタでWc取る為)　2013/8/4 mb
''' <summary>DB内のセンテンスを獲得し、単語に分割、フォントサイズと一緒に格納</summary>
''' <param name="fontSize">String フォントサイズ</param>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>	
	Public Function WordPreparer (fontSize As String, mainTxt As ArrayList) As Array
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim wordStorager(lineCounter) As Array
		Dim insWord As Array
		'Dim basicPoint As String = defSetAr(1) '2013/8/3 rep mb
		Dim basicPoint As String = fontSize
		
		For i As Integer = 0 To lineCounter Step 1
			
			Dim insPos() As String = {"", "", ""}									'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") IsNot "" Then							'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(","c)				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する
				insWord = CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
										mainTxt(i)("tbl_txt_targetword"), _
										mainTxt(i)("tbl_txt_targetpoint"), _
										i _
										)
				insFlg = True
			End If
			
			Dim loopCounter As Integer = CInt(CStr(mainTxt(i)("tbl_txt_txt")).Length)

			If insFlg = True Then													'挿入フラグが立っている時、挿入文字分をループカウンターに加算
				For j As Integer = 0 To 2 Step 1
					If insPos(j) <> "9999" Then
						loopCounter = loopCounter + CInt(insWord(j)(0))
					End If
				Next j
			End If
			
			Dim subStorager(loopCounter + 1) As String								'分割した単語（行単位）を一時保存する配列
			Dim wordInLine As String = CStr(mainTxt(i)("tbl_txt_txt")) 				'メインセンテンス
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim pointStorager As String = ""
			
			For j As Integer = 0 To loopCounter + 1 Step 1
				If j = 0 Then
					subStorager(0) = loopCounter.ToString()							'列の文字数（配列数）= 0 を格納
					Continue For
				End If
				
				If j = 1 Then
					Continue For 													'フォントサイズを格納の為
				End If
				
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If  IsArray(insWord(k)) = True AndAlso Val(insWord(k)(3)) + 2 =  j Then '絶対位置を確認
						For l As Integer = 4 To CInt(insWord(k)(0)) + 3				'2013/7/20 空配列対策(IsArray)
							subStorager(j) = insWord(k)(l)
							Call PointCollector(insWord(k)(1), pointStorager)
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（Nextで一つ増える為）
						k = k + 1
						Continue For
					Else
						subStorager(j) = wordInLine.Substring(m, 1)
						
						Dim tempBasicpoint As String = BasicPointChecker(mainTxt(i)).ToString()
						If  tempBasicpoint <> "0" Then
							basicPoint = tempBasicpoint
						End If
						Call PointCollector(basicPoint, pointStorager)
						
						m = m + 1
					End If
				Else
					subStorager(j) = wordInLine.Substring(j-2, 1)
					
					Dim tempBasipoint As String = BasicPointChecker(mainTxt(i)).ToString()
					If  tempBasipoint <> "0" Then
						basicPoint = tempBasipoint
					End If
					Call PointCollector(basicPoint, pointStorager)
				End If
			Next j
			
			If pointStorager = "" Then												'初期値に何も無い時はポイントをDB上にあてがっておく
				pointStorager = BasicPointChecker(mainTxt(i)).ToString()
			End If
			
			subStorager(1) = pointStorager											'フォントサイズを格納（コンマ文字列）

			wordStorager(i) = subStorager											'文字１つ１つを配列に格納
			insFlg = False
		Next i
		
		Return wordStorager
		
	End Function

''''■WordArranger
' <param name="defKeyWord">Hashtable 初期設定値</param> String() -> Hashtable 2013/8/3 mb -> 廃止 2013/8/4 mb
' <param name="optWord">Hashtable コンボの値</param>					廃止（コンストラクタでWcを取る為)
' <param name="font">フォント</param>									廃止 (コンストラクタWcを取る為)
' <param name="Wc">WordContainer.vb</param>							廃止　2013/8/4 mb
''' <summary>単語とフォントサイズの配列を適切に描画できるよう
''' 		設定を行って描画する</summary>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="wordStrager">Array 単語とそれぞれのフォントサイズ</param>
''' <param name="Frm">PrintReport.vb</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>
''' 'TODO: 文字が無い時改行だけするようにする
	Public Sub WordArranger(mainTxt As ArrayList, wordStorager As Array, Frm As PrintReport)
	
		Dim lineCounter As Integer = mainTxt.Count - 1
		
		If defset("curWriteWay") = "0" Then
			Dim startXPos As Single = CSng(defSet("curTopXPos"))	
			Dim startYPos As Single = CSng(defSet("curTopYPos"))
			Dim newStartYPos As Single = 0
			Dim insColCnt As Integer = 0
			
			For i As Integer = 0  To lineCounter Step 1
				Dim selector As Integer = CInt(mainTxt(i)("tbl_txt_ystyle"))
				Select Case selector
					Case 0	'上															'END: 上の場合の文字ピッチを計算
						If PointDiffChecker(wordStorager(i)(1)) = True Then				'全て同じフォントサイズの時
							Dim newXpitch As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXpitch <> 0 Then
								startXPos = startXPos - newXpitch						'x軸イレギュラースタート
							Else
								If CInt(wordStorager(i)(0)) <> 0 Then
									Dim pickPoint As Integer = OnePointPicker(wordStorager(i)(1), 0)
									'Dim fontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), pickPoint)
									Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"), wordStorager(i),,2)	'同一行内の最大幅に変更 2013/7/27 mb
									startXPos = startXPos - CSng(defSet("curBasicPitch")) - fontSize(1)	'END: 文字サイズ＋ピッチへ 2013/7/2
								Else														'END: 文字無しの時のエスケープ（改行だけする）
									Dim FontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSet("curFontSize")))
									startXPos = startXPos - CSng(defSet("curBasicPitch")) - FontSize(1)
									
										Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
										Dim wordInLine As New ArrayList 
										wordInLine.Add(wordDetail)
										Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
										wordDetail = {"", "", "", ""}
										Continue For
								End If
							End If
								
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos"))) 
							If newStartYPos <> 0 Then
								startYPos = newStartYPos									'y軸イレギュラースタート
							End If
							
							Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
							
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSet("curBotoomYPos")), _
																wordStorager(i), _
																Wc.optWord("Common_Font"), _
																splitPoint, _
																0, _
																Frm _
																)
							Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)
						Else															'END: フォントサイズが違う時の文字位置と改列ピッチを求める 2013/7/2
'******************************未使用↓******************************
							Dim maxWidth As Single										'END: イレギュラーサイズ時の描画方法を考える
							Dim irrXYPos As Array										'END: y軸位置の変更を組み込む
							
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If
							
							irrXYPos =  SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													Wc.optWord("Common_Font"), _
													startYPos, _
													CSng(defSet("curBotoomYPos")), _
													CSng(defSet("curBasicPitch")), _
													startXPos, _
													maxWidth, _
													Frm
													)
							Call Frm.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							startXPos = startXPos - maxWidth
'******************************未使用↑******************************
						End If
					Case 1	'下
						If PointDiffChecker(wordStorager(i)(1)) = True Then
								Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									startXPos = startXPos - newXPos
								Else
									If CInt(wordStorager(i)(0)) <> 0 Then
										Dim pickPoint As Integer = OnePointPicker(wordStorager(i)(1), 0)
										'Dim fontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), pickPoint)
										Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"), wordStorager(i),,2)	'同一行内の最大幅に変更 2013/7/27 mb
										startXPos = startXPos - CSng(defSet("curBasicPitch")) - fontSize(1)
									Else	
										Dim fontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSet("curFontSize")))
										startXPos = startXPos - CSng(defSet("curBasicPitch")) - fontSize(1)
										
										Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
										Dim wordInLine As New ArrayList 
										wordInLine.Add(wordDetail)
										Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
										wordDetail = {"", "", "", ""}
										Continue For
									End If 'END: 2013/7/9　下配置修正
								End If
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If

							Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
						
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSet("curBotoomYPos")), _
																wordStorager(i), _
																Wc.optWord("Common_Font"), _
																splitPoint, _
																1, _
																Frm _
																)
							'END: ピッチがマイナスでも強制的に下からスタートさせる(ピッチを小さくしたい時) -> OrElseを追加 2013/7/13 mb
							'If properPit > 0 OrElse selector = 3  暫定（よくわからん）out 2013/7/21 mb
							'If properPit < 0  2013/8/4 out 1 line mb
								Dim addHeight As Single = 0
								Dim totalHeight As single = 0
								For j As Integer = 2 To CInt(wordStorager(i)(0)) + 1 Step 1
									Dim tempHeight() As Single = Frm.FontSizeCal(wordStorager(i)(j), Wc.optWord("Common_Font"), CInt(splitPoint(j - 2)))
									addHeight = addHeight + tempHeight(0)	
								Next j
								totalHeight = Csng(defSet("curBotoomYPos")) - ( addHeight + (properPit * (CSng(wordStorager(i)(0)) - 1)))
								Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, totalHeight, properPit)
							'Else			2013/8/4 out 3 lines mb
							'	Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)　'CHK★一時的に変更
							'End If
						Else															'フォントサイズが異なる
'******************************未使用↓******************************
							Dim maxWidth As Single	
							Dim irrXYPos As Array
							
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If
							
							irrXYPos =  SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													Wc.optWord("Common_Font"), _
													startYPos, _
													CSng(defSet("curBotoomYPos")), _
													CSng(defSet("curBasicPitch")), _
													startXPos, _
													maxWidth, _
													Frm
													)
							Call Frm.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							
							startXPos = startXPos - maxWidth
'******************************未使用↑******************************
						End If	
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						'TODO: pointDiffCheckerをつける
						Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
						If newXPos <> 0 Then
							startXPos = startXPos - newXPos									'イレギュラー改行
						Else
							If Cint(wordStorager(i)(0)) <> 0 Then				'END: この辺に文字無しの時のエスケープを考える
								'Dim fontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), CInt(defSetAr(1)))
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"), wordStorager(i),,2)	'同一行内の最大幅に変更 2013/7/27 mb
								startXPos = startXPos - CSng(defSet("curBasicPitch")) - fontSize(1)
							Else	
								Dim fontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSet("curFontSize")))
								startXPos = startXPos - CSng(defSet("curBasicPitch")) - fontSize(1)

								Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
								Dim wordInLine As New ArrayList 
								wordInLine.Add(wordDetail)
								Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
								wordDetail = {"", "", "", ""}
								Continue For
							End If
						End If
						
						newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
						If newStartYPos <> 0 Then
							startYPos = newStartYPos
						End If
							
						Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
						Dim properPit As Single = PitchCal(startYPos, _
															CSng(defSet("curBotoomYPos")), _
															wordStorager(i), _
															Wc.optWord("Common_Font"), _
															splitPoint, _
															2, _
															Frm _
															)'						'TODO フォント
						Call Frm.createWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)
					End Select
			Next i
			
		Else
		'TODO: 横書きの時
		End If
	End Sub
	
	'データを置き換える
''' ■WordReplacer
' <param name="Wc">WordContainer.vb</param>					廃止 2013/8/4 mb
' <param name="yStyle">Integer 上、下、天地</param>			廃止 2013/8/4 mb
''' <summary>コンボ変更に対して文字挿入、y軸位置、x軸位置を決める</summary>
''' <param name="lineNo">Integer 行番号</param>
''' <param name="pr">Frm PrintReport.vb</param>
''' <param name="yStyle">Integer 上、下、天地</param>
''' <param name="newTargetCmb">Optional ComboBox 動かされるコンボ（Optionalどちらかを指定する）</param>
''' <param name="newTargetTxt">Optional Textbox 変更するテキストボックス</param>
''' <returns>Void CurWordの内容を変更する</returns>
	Public Sub WordReplacer(lineNo As Integer, Pr As PrintReport, yStyle As Integer, _
					Optional newTargetCmb As ComboBox = Nothing, _
					Optional newTargetTxt As TextBox = Nothing)
		'コンボの値を置き換え
		If newTargetCmb IsNot Nothing Then
			If newTargetCmb IsNot Pr.Cmb_Year And newTargetCmb IsNot Pr.Cmb_Month And newTargetCmb IsNot Pr.Cmb_day Then
				Wc.optWord(newTargetCmb.Name) = newTargetCmb.SelectedValue
			End If
		End If
		'テキストボックスの値を置き換え
		If newTargetTxt IsNot Nothing Then
			Wc.optWord(newTargetTxt.Name) = newTargetTxt.Text
		End if
		'フォントサイズが全て同じかどうか確認する
		'TODO:違う時どうするか？
		Dim fontSizeDif As Boolean = False
		Dim tempCurWord As New Hashtable
		
		Dim curFontSize As Integer = CInt(Wc.curWord(lineNo)(0)(1))
		
		For i As Integer = 0 To CInt(Wc.curWord(lineNo).Count) -1 Step 1
			If curFontSize <> CInt(Wc.curWord(lineNo)(i)(1)) Then
				fontSizeDif = True 
			End If
		Next i
		'ArrayListの値を移しておく
		tempCurWord("fontSize") = Wc.curWord(lineNo)(0)(1)			'フォントサイズ
		tempCurWord("topYPos") = Wc.curWord(lineNo)(0)(2)			'y軸位置（天）
		tempCurWord("xPos") = Wc.curWord(lineNo)(0)(3)				'x軸位置
		'curWordの任意の行のデータを削除しておく
		Dim wordCnt As Integer = Wc.curWord(lineNo).Count 
		Wc.curWord(lineNo).RemoveRange(0, wordCnt)

		Dim mainTxt As New Hashtable()
		Dim SctSql As New SelectSql()
		
'		Dim currentSize As Integer = Wc.CurSizeStorager						'2013/8/3 out 2 lines mb
'		Dim currentStyle As Integer = Wc.CurStyleStorager
		'再描画行の文字データを取得
		'mainTxt = SctSql.GetTbl_TxtRow(Wc.CurSizeSet, Wc.DefSet(7), lineNo) 2013/8/3 out 1 line mb
		mainTxt = SctSql.GetTbl_TxtRow(Wc.CurrentSet(0), Wc.CurrentSet(1), lineNo)
		'挿入位置を取得
		Dim insPos() As String
		insPos = CStr(mainTxt("tbl_txt_inspos")).Split(","c)
		'挿入文字配列を取得
		Dim insWord As array
		insWord = CheckInsWord(mainTxt("tbl_txt_inspos"), _
                               mainTxt("tbl_txt_targetword"), _
                               mainTxt("tbl_txt_targetpoint"), _
                               lineNo _
                               )
		
		Dim loopCounter As Integer = CInt(CStr(mainTxt("tbl_txt_txt")).Length)
		'挿入文字の字数をループカウンター（不変文字数）に加算する
		For i As Integer = 0 To 2 Step 1
			If CInt(insPos(i)) <> 9999 Then
				loopCounter = loopCounter + CInt(insWord(i)(0))
			End If
		Next i 
		'不変文字と挿入文字を一つの配列に格納していく
		Dim wordInLine As New ArrayList()
		Dim wordDetail(3) As String
		Dim k As Integer = 0
		Dim l As Integer = 0
		
		If fontSizeDif = False Then												'全て同じの時
			For i As Integer = 0 To loopCounter - 1 Step 1
				If  IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(3)) =  i Then	'END エラーをかわす（insWordに配列が1つしかなく文の先頭にある時など）WordPreparerも
					'Dim int As Integer = insWord(k)(0)
					For j As Integer = 4 To CInt(insWord(k)(0)) + 3  Step 1
						wordDetail(0) = insWord(k)(j)
						wordDetail(1) = tempCurWord("fontSize")
						wordDetail(3) = tempCurWord("xPos")						'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}							'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				Else
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(l, 1)
					wordDetail(1) = tempCurWord("fontSize")
					wordDetail(3) = tempCurWord("xPos")
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					l = l + 1
				End If
			Next i
			'END: y軸位置は後で決める
'			Dim defSetAr() As String								2013/8/3 out 2 lines mb
'			defSetAr = SctSql.GetDefaultVal(currentStyle)			'END: y軸のbottomを求める(4番目)

			Dim tempWordAr(loopCounter + 1) As String				'END: 文字(0 = 文字数, 1 = 空, 2～ = 文字）配列を作る
			Dim tempPointAr(loopCounter - 1) As String				'END: フォントサイズの配列を作る
			For i As Integer = 0 To loopCounter - 1 Step 1
				If i = 0 Then
					tempWordAr(i) = loopCounter
				End If
				
				tempWordAr(i + 2) = wordInLine(i)(0)
				
				If i <= loopCounter - 1 Then
					tempPointAr(i) = wordInLine(i)(1)
				End If	
			Next i
			'END: 適正なピッチを取る
			Dim properPit As Single = PitchCal(tempCurWord("topYPos"), _
												Wc.DefSet(4), _
												tempWordAr, _
												Wc.optWord("Common_Font"), _
												tempPointAr, _
												yStyle, _
												Pr _
												)
			'END: 適正なピッチを使ってy軸位置を決めていく
			'END: 上・下・天地
			Dim newYPos As Single = 0
			Select Case yStyle
				Case 0, 2
					Dim irrNewYPos As Single = CSng(mainTxt("tbl_txt_newypos"))
					newYPos = tempCurWord("topYpos")
					If irrNewYPos <> 9999 Then		'END: y軸位置が変わる -> 確認する
						newYPos = irrNewYPos
					End If
				Case 1
					Dim addHeight As Single = 0
					Dim totalHeight As single = 0
					For i As Integer = 2 To tempWordAr.Length - 1 Step 1
						Dim tempHeight() As Single = Pr.FontSizeCal(tempWordAr(i), Wc.optWord("Common_Font"), tempPointAr(i - 2))
						addHeight = addHeight + tempHeight(0)	
					Next i	
					newYPos = Csng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(tempWordAr(0)) - 1)))
			End Select
			
			For i As Integer = 0 To loopCounter - 1 Step 1
				wordInLine(i)(2) = newYPos
				Dim tempYPos() As Single = Pr.FontSizeCal(wordInLine(i)(2), Wc.optWord("Common_Font"), CInt(tempCurWord("fontSize")))
				newYPos = newYPos + tempYPos(0) + properPit
			Next i
			
			If wordInLine.Count = 0 Then						'END: 文字なしの時の処理（ダミーデータを入れる）を実装する
				wordDetail(0) = ""
				wordDetail(1) = tempCurWord("fontSize")
				wordDetail(2) = tempCurWord("topYPos")
				wordDetail(3) = tempCurWord("xPos")
				wordInLine.add(wordDetail)
			End If
			
			Wc.curWord(lineNo) = wordInLine								'2017/7/21 curWord(0) -> curWord(lineNo)へ mb
			
'		#If Debug then
'		Dim z As Integer = 0
'		Dim x As Integer = 0
'		Dim y As Integer = 0
'		Dim zcnt As Integer = Wc.curWord.Count
'		While x < Wc.curWord.Count
'			While z < Wc.curWord(x).count 
'				while y < 4
'					System.Diagnostics.Debug.WriteLine(Wc.curWord(x)(z)(y))
'					y += 1
'				End While
'				y = 0
'				z = z + 1	
'			End While
'			z = 0
'			x = x + 1
'		End while
'		#End If
			
		'TODO:　以下未確認、未完成
		Else																	'フォントサイズが違う時
			Dim wordStrager(loopCounter + 1) As String
			wordStrager(0) = loopCounter
			
			Dim collectPoint As String
			
			For i As Integer = 2 To loopCounter + 1 Step 1
				If CInt(insWord(3)) =  i Then 
					For j As Integer = 4 To CInt(insWord(0)) - 1 Step 1  'CHK
						'SetIrregXYPos用
						wordStrager(i) = insWord(i)(j)
						PointCollector(insWord(i)(1), collectPoint) 
						'描画用XY位置未確定
						'Dim wordDetail(3) As String
						wordDetail(0) = insWord(i)(j)
						wordDetail(1) = insWord(0)(1)
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", ""}
					next j
				Else
					'SetIrregXYPos用
					wordStrager(i) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					PointCollector(insWord(i)(1), collectPoint)
					'描画用XY位置未確定
					'Dim wordDetail(3) As String
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					wordDetail(1) = insWord(0)(1)
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					k = k + 1
				End If
			Next i
			'イレギュラー配置を計算する
			wordStrager(1) = collectPoint

			'Dim defSetAr() As String = SctSql.GetDefaultVal(currentStyle) out 2013/8/3 mb
			
			Dim eachPos(,) As Single
			Dim maxWidth As Single
			eachPos = SetIrregXYPos(yStyle, _
									wordStrager, _
									Wc.optWord("Common_Font"), _
									tempCurWord(0)(2), _
									Wc.DefSet(4), _
									Wc.DefSet(5), _
									Wc.curWord(lineNo - 1)(3), _
									maxWidth, _
									pr
									)
			For i As Integer = 0 To loopCounter - 1 Step 1
				wordInLine(i)(2) = eachPos(0, i)
				wordInLine(i)(3) = eachPos(1, i)
			Next i
			
			Wc.curWord(lineNo) = wordInLine
			'X軸をずらしていく
			Dim xPosDiff As Single = CSng(tempCurWord(lineNo)(0)(3)) - CSng(Wc.curWord(lineNo - 1)(0)(3)) - defSet(6)
			
			If xPosDiff <> 0 Then
				For i As Integer = 0 To Wc.curWord.Count -1 Step 1
					For j As Integer = 0 To Wc.curWord(i).Count -1 Step 1
						Wc.curWord(i)(j)(3) = CSng(Wc.curWord(i)(j)(3)) + xPosDiff
					Next j
				Next i
				
			End If
			
		End If
	End sub
	
'''■CheckInsWord
' <param name="optWord">Hashtable オプションのセンテンス</param>		<- 追加	2013/7/  廃止 2013/8/4（コンストラクタでWc取る為）mb
''' <summary>挿入文字を取り出し</summary>
''' <param name="insPos">String 挿入があるかどうか</param>
''' <param name="targetWord">String 挿入文字の値の入ったのHashTableのキー名</param>
''' <param name="targetPoint">String ポイントの値の入ったのHashTableのキー名</param>
''' <param name="insCol">Integer 挿入があった列番号</param>		<- 追加	2013/6/30
''' <returns>文字数 = 0, フォントサイズ = 1, 挿入列番号 = 2, 挿入位置 = 3 , 文字（任意の数）= 4～</returns>
	Public Function CheckInsWord(insPos As String, targetWord As String, _
								targetPoint As String, insCol As Integer _
								) As Array
    	'END: 文字数, フォント, フォントサイズを獲得する
    	'END: 挿入位置も格納しておく 2013/6/29
    	'END: 挿入列も格納しておく   2013/6/30
        Dim returnAr(2) As Array
        
'        #If Debug Then
'        For Each item  In optWord
'        	System.diagnostics.Debug.Writeline(item.key)
'        	System.Diagnostics.Debug.WriteLine(item.value)
'        Next
'        #End If
        
        Dim splitInsPos() As String
        Dim splitTargetWord() As String
        Dim splitTargetPoint() As String
        Dim newInsPos As Integer 
        splitInsPos = insPos.Split(",")												'挿入位置。2番目は1番の後から2番目までの間の不変文字の数（以降同じ）
        splitTargetWord = targetWord.Split(",")										'分割された挿入文字
        splitTargetPoint = targetPoint.Split(",")									'それぞれのフォントサイズ
        
        For i As Integer = 0 To 2 Step 1											'現状1行に3挿入までにする
        	If splitInsPos(i) <> "9999" Then
        		Dim word As String = Wc.optWord(splitTargetWord(i))
        		Dim wordPoint As String = Wc.optWord(splitTargetPoint(i))
        		Dim wordLength As Integer = CInt(word.Length)  						'文字数をフォントサイズを格納する分が２つ
        		Dim resultAr(wordLength + 3) As String			'■ 2
        		Dim k As Integer = 0
        		
        		For j As Integer = 0 To wordLength + 3 Step 1
        			If j = 0 Then
        				resultAr(j) = wordLength									'文字数 = 0
        			ElseIf j = 1 Then
        				resultAr(j) = wordPoint										'フォントサイズ = 1
        			ElseIf j = 2 Then
        				resultAr(j) = insCol										'挿入があった列番号
        			ElseIf j = 3 Then
        				If i = 0 Then
        					resultAr(j) = splitInsPos(i)							'挿入位置 = 3
        					newInsPos = CInt(splitInsPos(i)) + wordLength
        				Else
        					resultAr(j) =  newInsPos + CInt(splitInsPos(i)) 		'2番目以降の挿入の相対位置を絶対位置に確定する
        					newInsPos = CInt(resultAr(j)) + wordLength
        				End If
        			Else
        				resultAr(j) = word.Substring(k, 1)
        				k = k + 1
        			End If
        		Next j
        		
        		returnAr(i) = resultAr
        		
        	End If
        Next i
        
        Return returnAr

    End Function
'''■ChangeFontSize
Public Function ChangeFontSize(lineNo As Integer, targetPointCmb As ComboBox, Pr As PrintReport, _
								Optional targetCmb As ComboBox = Nothing) As ArrayList
		'TODO: 全体変更するのか、部分変更するのかを確認する
		'対応するコンボの値をとる 比較 -> 同じ文字　-> サイズを上書き
		'同じ文字無し -> 全体を変更
'		Dim SctSql As New SelectSql
'		Dim sqlText As String = " SELECT tbl_txt_ystyle FROM tbl_txt "
'					 sqlText &= " WHERE tbl_txt_sizeid = " & Wc.CurrentSet(0) & " AND tbl_txt_styleid = " & Wc.CurrentSet(1) & " AND tbl_txt_order = " & lineNo
'		Dim txtInspos As String = SctSql.GetOneSql(sqlText)

		Dim startYPos As Single

		If targetCmb Is Nothing Then	'★★全体変更
			'CHK: 一つ前の行のx位置(文字列中最大）を獲得する -> 基本列ピッチ + 新しいフォントサイズのx軸位置 = 新しいx軸位置
			Dim lastWordXPos() As Single = GetMaxWord(Wc.optWord("Common_Font"),,Wc.curWord(lineNo - 1), 0)
				
			'CHK: 配列に新しいフォントサイズを突っ込む
			Dim wordCnt As Integer = Wc.curWord(lineNo).Count
			For i As Integer = 0 To wordCnt - 1 Step 1
				Wc.curWord(lineNo)(i)(1) = targetCmb.SelectedValue.ToString()
			Next i
			'行内の文字の最大幅をとる
			Dim maxWordSize() As Single = GetMaxWord(Wc.optWord("Common_Font"),,Wc.curWord(lineNo), 0)
			'CHK: 新しいx軸位置の確定
			Dim newXpos As Single = lastWordXPos(1) + maxWordSize(1) + Wc.DefSet("curWordPitch")
			'CHK: y軸位置がイレギュラーでないか？
			Dim SctSql As New SelectSql
			Dim txtRow As New Hashtable 
			txtRow = SctSql.GetTbl_TxtRow(Wc.CurrentSet(0), Wc.CurrentSet(1), lineNo)
			If txtRow("tbl_txt_newypos") <> "9999" Then
				startYPos = txtRow("tbl_txt_newypos")
			Else
				startYPos = defSet(3)
			End If
			'Dim properPitch As Single = PitchCal(startYPos, defSet(4),) 
			'TODO: 上・下・天地	
			Select Case txtRow("tbl_txt_ystyle")
				Case "0"
					
				Case "1"
					
				Case "2"
					
			End Select
			'TODO: y軸位置を決めていく

		Else							'★★部分変更
			'TODO
		End If
		
		'Dim maxWidth() As Single = GetMaxWord(
		
		'TODO: 以降の列のx軸位置を変更して行く
		
		
	End Function
#End Region 

#Region "Pitch"

'TODO: 最後に確認する（引数変更の影響が非常に大きい）
'END: それぞれの文字のフォントサイズを考慮する
'END: フォントサイズの変更に伴いx軸の調整をする
'END: 大きさによってそれぞれの文字のX座標が変わる
'END: ピッチがビチビチの時も考慮
'''■SetIrregXYPos
''' <summary>フォントサイズが違う文字が混じった列の
''' 		1) それぞれのyPosを計算する
''' 		2) それぞれのxPosを計算する
''' </summary>
''' <param name="yStyle">上・下・天地</param>
''' <param name="wordStrager">文字配列(0 = 文字数, 1 = それぞれのフォントサイズ）</param>
''' <param name="font">フォント</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="bottomYPos">y軸最下位置</param>
''' <param name="curXPitch">x軸の改列ピッチ</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="maxWidth">最大のフォント幅（参照）</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>配列にてyPos = 0, xPos = 1を返す</returns>
Public Function SetIrregXYPos(yStyle As Integer, wordStrager As Array, font As String, _
								topYPos As Single, bottomYPos As Single, _
								curXPitch As Single, lastXPos As Single, _
								ByRef maxWidth As Single, _
								pr As PrintReport _
							) As Single(,)
		
		Dim eachPos(1, wordStrager(0) - 1) As Single										'y軸(0)/x軸(1)の文字位置データ
		Dim tempMaxWidth As Single = 0
		Dim eachXYSize(CInt(wordStrager(0)) - 1) As Array

		Dim splitPoint() As String = wordStrager(1).Split(",")
		Dim freeSpace As Single = bottomYPos - topYPos
		Dim onePitch As Single = 0
		
		For i As Integer = 2 To CInt(wordStrager(0)) + 1 Step 1
			eachXYSize(i - 2) = pr.FontSizeCal(wordStrager(i), font, CInt(splitPoint(i - 2)))	'それぞれの文字サイズを獲得する
			If (i - 2) = 0 Then
				tempMaxWidth = eachXYSize(i - 2)(1)
			End If
			If (i - 2) <> 0 Then
				If tempMaxWidth < eachXYSize(i -2)(1) Then
					tempMaxWidth = eachXYSize(i - 2)(1)
				End If
			End If
			freeSpace = freeSpace - Csng(eachXYSize(i -2)(0))								'ピッチに取れるスペースを獲得する
		Next i

		maxWidth = tempMaxWidth																'***END: 文字幅の最大値を渡す
		
		Select Case yStyle																'***文字ピッチを獲得する
			Case 0	'END: 上
				If freeSpace > 3 * (CInt(wordStrager(0) - 1))  Then							'ピッチ * ピッチスペース数
					onePitch = defSet(6)
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End If
			Case 1	'END: 下
				If freeSpace > 3 * (CInt(wordStrager(0) - 1))  Then
					onePitch = defSet(6)
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End If
			Case 2	'END: 天地
				If freeSpace > 0  Then
					onePitch = freeSpace / CSng(CInt(wordStrager(0) - 1))
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End if
		End Select

		For i As Integer = 0 To CInt(wordStrager(0)) + 1 Step 1								'***END: y軸上の文字位置を決めていく
			If i = 0 Or i = 1　Then
				Continue For
			End If
			'スペースが有る時
			If freeSpace > 3 * (CInt(wordStrager(0) - 1)) Then
				If yStyle = 1 Then
					If i = 2 Then
						For j As Integer = 0 To eachPos.GetLength(0) Step 1
							eachPos(0, 0) = eachPos(0, 0) + CSng(eachPos(0, j))
						Next j
					Else
						eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch 'フォントサイズ
					End If
				Else
					If i = 2 Then
						eachPos(0, 0) = topYPos
					Else
						eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch
					End If
				End If
			'スペースが無い時	
			Else
				If i = 2 Then
					eachPos(0, 0) = topYPos
				Else	
					eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch
				End if
			End If
		Next i
		
		Dim lastWordPoint As Single = splitPoint(0)
																							'***END: 一番大きいフォントの位置よりそれぞれのｘ軸位置を決める
		For i As Integer = 0 To CInt(wordStrager(0)) -1 Step 1								'END: x軸は右から左へマイナス
			If eachXYSize(i)(1) < tempMaxWidth Then											'END: 位置微調整が必要　-> 連続して同じサイズの時は同じx位置に 2013/7/13
				If lastWordPoint = splitPoint(i) And i <> 0 Then							'     ひらがなが微妙
					eachPos(1, i) = eachPos(1, i -1)
				Else
					eachPos(1, i) = (lastXPos - curXPitch - tempMaxWidth) + ((tempMaxWidth - CSng(eachXYSize(i)(1))) / 2)
					lastWordPoint = splitPoint(i)
				End If
			Else
				eachPos(1, i) = lastXPos - curXPitch - tempMaxWidth
			End If
		Next i
		
		Return eachPos
		
	End Function
'END:　改行ピッチ関数 
''''■CheckNewXPos
''' <summary>改行ピッチの変更があるかどうか確認</summary>
''' <param name="newPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列の改行ピッチが違うかどうかの判定に使用</remarks>
	Public Function CheckNewXPos(newXpos As Single) As Single
		Dim resultPos As Single = 0
		If newXpos <> 9999 Then
			resultPos = newXpos
			Return resultPos
		End If
			Return 0
	End Function
	
''''■CheckNewYPos
''' <summary>Y軸の開始位置の変更があるかどうか確認</summary>
''' <param name="newXPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列のy軸スタート位置が違うかどうかの判定に使用</remarks>

'END:　改行ピッチ関数 
	Public Function CheckNewYPos(newXpos As Single) As Single
		Dim resultPos As Single = 0
		If newXpos <> 9999 Then
			resultPos = newXpos
			Return resultPos
		End If
			Return 0
	End Function	
	
'END: 最後に確認する（引数変更の影響が非常に大きい） -> 変更無し
''''■PitchCal
''' <summary>天地の時のピッチを計算
''' 		（0, 1の列の設定データはかわしています）
''' </summary>
''' <param name="topYPos">Single 開始位置（位置変更される時があるので必要）</param>
''' <param name="bottomYPos">Single 修了位置</param>
''' <param name="word">Array 単語配列</param>
''' <param name="font">String フォント</param>		<- 追加　2013/06/23
''' <param name="point">Array フォントサイズ</param>	<- Arrayに変更 2013/7/4
''' <param name="yStyle">Integer 上・下・天地揃え</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
	Public Function PitchCal(topYPos As Single, bottomYPos As Single, _
							word As Array, font As String, point As Array, _
							yStyle As Integer, pr As PrintReport) As Single
	
		Dim resultPitch As Single = 0
		Dim arCounter As Single = CSng(word(0))									'文字数を取得
		Dim firstWord(1) As Single
		Dim lastWord(1) As Single
	
		'文字の長さの取得(最初と最後は決まっている為）
		Dim wordLength() As Single = {0, 0}
		Dim wordHeight As Single = 0
		Dim j As Integer = 0
		For i As Integer = 0 To CInt(arCounter) + 1				'★END Nothing
			Select Case i
			    Case 0
			    	Continue For
			    Case 1
			    	Continue For
			    Case 2
			    	firstWord = pr.FontSizeCal(CStr(word(i)), font, point(j))
			    Case CInt(arCounter) + 1
			    	lastWord = pr.FontSizeCal(CStr(word(i)), font, point(j))
			    Case Else
			    	wordLength = pr.FontSizeCal(CStr(word(i)), font, point(j))
					wordHeight = wordHeight + wordLength(0) 
			End Select

			j = j + 1
		Next i
	
		'最後の文字の位置を決める
		Dim lastWordPos As Single = bottomYPos - lastWord(0)

		'文字の長さの取得(最初と最後は決まっている為）										2013/06/23 out mb	
		'Dim arLength As  Single = (arCounter - 2) * wordPixSize

		'文字収納範囲
		Dim wordArea As Single = lastWordPos - firstWord(0)
		'文字の長さと収納範囲を検証
		If (wordArea - (wordHeight)) > 0 Then										'ピッチを取れる余裕がある時
			Select Case yStyle
				Case 0
					Return defSet("curBasicPitch")
				Case 1
					Return defSet("curBasicPitch")
				Case 2
					resultPitch = (wordArea - wordHeight) / (arCounter - 1)
					Return resultPitch
			End Select
		Else																		'余裕がない時（ビチビチの時　マイナスの値でピッチ幅を減らす）
			resultPitch = (System.Math.Abs(wordArea - wordHeight) / (arCounter - 1)) * -1
			Return resultPitch
		End If
	
	End Function

''' ■YPosCal
''' <summary>y軸方向の文字ピッチを再設定する（フォントサイズが全て同じ時）</summary>
''' <param name="word">ByRef Array 文字配列（文字、フォントサイズ、文字の高さ、文字の幅）</param>
''' <param name="topYPos">Single y軸の開始位置</param>
''' <param name="pr">Form PrintReport</param>
''' <returns>Void, wordを参照する</returns>
	Public Sub YPosCal(ByRef word As ArrayList, font As String, topYPos As Single, pr As PrintReport)
		
		Dim loopCounter As Integer = CInt(word.Count)
	
		For i As Integer = 1 To loopCounter -1 Step 1
				Dim fontSize() As Single = pr.FontSizeCal(word(i)(0), font, CInt(word(i)(1)))
				If i = 1 Then
					word(i)(2) = fontSize(0) + defSet("curBasicPitch")
				Else
					word(i)(2) = word(i - 1)(2) + fontSize(0) + defSet("curBasicPitch")
				End If
				'System.Diagnostics.Debug.WriteLine(word(i)(2))
		Next i

	End Sub
	
#End Region

#Region "FontSize"

'END: 文字と文字サイズがばらばらの時を考える（入れ物）
''' ■GetMaxWord
''' <summary>1行内にある文字の最大幅を返す</summary>
''' <param name="font">String フォント</param>
''' <param name="wordStrager">Optional String() 文字とまとめたサイズが一つの配列に入っている時に使用</param>
''' <param name="pairWord">Optional String() 全ての文字とフォントがペアになっているタイプ</param>
''' <param name="startCnt">Optional Integer ループ開始位置</param>
''' <returns>1行内にある文字の最大幅を返す</returns>
Public Function GetMaxWord(font As String, Optional wordStrager() As String = Nothing, _
							Optional pairWord() As String = Nothing, _
							Optional startCnt As Integer = 0 _
							) As Single()
	
	'y軸の最大値は今のところ必要ないので未実装 2013/7/27 mb
	Dim Pr As New PrintReport
	Dim wordSize() As Single = {0s, 0s}
	If wordStrager IsNot Nothing Then
		Dim splitPoint() As String = wordStrager(1).Split(","c)
		Dim j As Integer = 0
		For i As Integer = startCnt To wordStrager.Length - 1 Step 1
			Dim tempWordSize() As Single = Pr.FontSizeCal(wordStrager(i), font, splitPoint(j))
			If wordSize(1) < tempWordSize(1) Then
				wordSize(1) = tempWordSize(1)
			End If
			j = j + 1
		Next i
	ElseIf pairWord IsNot Nothing then
		'END: 同処理を実装する
		For i As Integer = startCnt To pairWord.Length -1 Step 1
			Dim tempWordSize() As Single = Pr.FontSizeCal(pairWord(i)(0), font, Val(pairWord(i)(1)))
			If wordSize(1) < tempWordSize(1) Then
				wordSize(1) = tempWordSize(1)
			End If
		Next i
	End if
	
	Pr.Dispose()
	Pr = Nothing
	
	Return wordSize
	
End Function

'''■BasicPointChecker
''' <summary>列単位のフォントサイズの変更を確認</summary>
''' <param name="mainTxt">ArrayList DB内の登録データ</param>
''' <returns>変更が無い時は0を返す、ある時は登録されたフォントサイズを返す</returns>
''' <remarks>列が変わった時に次の列内のフォントサイズが違うかどうかの判定に使用</remarks>
	Public Function BasicPointChecker(mainTxt As Hashtable) As Integer
		Dim resultInt As Integer
		If mainTxt("tbl_txt_newpoint") <> "9999" Then
			resultInt = mainTxt("tbl_txt_newpoint")
			Return resultInt
		End If
		
		Return 0
		
	End Function

'''■PointDiffChecker
''' <summary>コンマ区切りフォントサイズをバラして異なったフォントサイズがあるか確かめる</summary>
''' <param name="pointStrager">コンマ区切りフォントサイズ文字列</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function PointDiffChecker(pointStrager As String) As Boolean
		Dim splitPoint() As String = pointStrager.Split(",")
		Dim tempSplitPoint As String = splitPoint(0)
	
		For i As Integer = 0 To splitPoint.Length - 1 Step 1
			If tempSplitPoint <> splitPoint(i) Then
				Return False
			Else
				tempSplitPoint = splitPoint(i)
			End If
		Next i
	
		Return True
	
	End Function

'''■PointCollector
''' <summary>フォントサイズを変数にコンマ区切りでまとめる</summary>
''' <param name="point">String 格納したいフォントサイズ</param>
''' <param name="storager">String ByRef フォントを格納する変数</param>
''' <returns>Void</returns>
	Public Sub PointCollector(ByVal point As String, ByRef storager As String)
		If storager = "" Then 
			storager = point
		Else
			storager &= ","  & point
		End If

	End Sub
	
'''■OnePointPicker
''' <summary>フォントサイズをコンマ区切り文字列から１つ取り出す</summary>
''' <param name="pointStrager">String コンマ区切りフォントサイズ</param>
''' <param name="pickUpNo">Integer 取り出したいフォントサイズの位置</param>
''' <returns>フォントサイズ</returns>
	Public Function OnePointPicker(pointStrager As String, pickUpNo As Integer) As Integer
		Dim resultPoint As Integer
		Dim pointStr() As String = pointStrager.Split(",")
		
		resultPoint = pointStr(pickUpNo)
		Return resultPoint
		
	End Function
	
#End Region

End Class

'2013/8/4 out 1 sub mb
'''''■PointPitCal
'''' <summary>任意のポイントに対する必要なピッチ</summary>
'''' <param name="point">ポイント数</param>
'''' <returns>y軸の文字位置を決める定数を返す(任意のポイントの高さ+文字ピッチ。現在-3）</returns>
'	Public Function PointPitCal(point As Integer) As Integer
'		Dim resultPit As Integer = 0
'
'		Dim wordPix As Integer = CInt(point * (96 / 72))							'ポイント　-> ピクセル変換(任意のポイントの高さ）
'		resultPit = wordPix - 3														'文字間隔は4pxに（暫定）
'		Return resultPit
'	End Function

'	Public Readonly Property SetBasicPitch() As Single				'END: これ廃止にしたい 2013/8/4 out 5 lines mb
'		Get
'			Return basicPitch
'		End Get
'	End Property
