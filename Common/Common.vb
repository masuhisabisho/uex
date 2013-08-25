'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Diagnostics.Debug		'開発用

Public Class Common
	
	Private defSet As New Hashtable
	Private Wc As WordContainer
	
	Public sub new (wordCont As WordContainer)
		defSet = wordCont.DefSetAll.Clone
		Wc = wordCont
	End Sub

#Region "Word"
'2013/8/4　に　文字・フォント・y軸位置・x軸位置 スタイルに変更
''''■WordPreparer
''' <summary>DB内のセンテンスを獲得し、単語に分割、フォントサイズと一緒に格納</summary>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="fontSize">String フォントサイズ</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>	
	Public function WordPreparer(mainTxt As ArrayList, fontSize As String) As ArrayList
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim insWord As Array
		Dim storageWord As New ArrayList
		Dim registerChkFlg As Boolean = False

		Dim basicPoint As String = fontSize
		
		For i As Integer = 0 To lineCounter Step 1
			Dim insPos() As String = {"", "", ""}									'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") IsNot "" Then							'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(","c)				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する ↓
				insWord = CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
										mainTxt(i)("tbl_txt_targetword"), _
										mainTxt(i)("tbl_txt_targetpoint"), _
										i _
										)											'フォントサイズ = 0, 挿入位置 = 1 文字（任意の数）= 2～ を獲得するに変更 2013/8/4 mb
				insFlg = True
			End If
			
			Dim loopCounter As Integer = CInt(CStr(mainTxt(i)("tbl_txt_txt")).Length)

			If insFlg = True Then													'挿入フラグが立っている時、挿入文字分をループカウンターに加算
				For j As Integer = 0 To 2 Step 1
					If insPos(j) <> "9999" Then
						'loopCounter = loopCounter + CInt(insWord(j)(0))
						loopCounter = loopCounter + CInt(insWord(j).Length - 2)
					End If
				Next j
			End If
			
			Dim wordInLine As New ArrayList
			Dim fixedWord As String = CStr(mainTxt(i)("tbl_txt_txt"))
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim wordDetail() As String = {"", "", "", ""}

			For j As Integer = 0 To loopCounter - 1 Step 1
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If IsArray(insWord(k)) = True AndAlso Val(insWord(k)(1)) = j
						For l As Integer = 2 To CInt(insWord(k).Length -1)
							wordDetail(0) = insWord(k)(l)
							wordDetail(1) = insWord(k)(0)
							wordInLine.Add(wordDetail)
							wordDetail = {"", "", "", ""}
							registerChkFlg  = True

							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（最後の文字ので余分に増える為）
						k = k + 1
						Continue For
					Else
						wordDetail(0) = fixedWord.Substring(m, 1)					'固定文字を格納
						
						Dim tempBasicpoint As String = BasicPointChecker(mainTxt(i)) '行単位のフォントサイズの変更がないか確認
						If  tempBasicpoint <> "0" Then
							basicPoint = tempBasicpoint
						End If
						
						wordDetail(1) = basicPoint
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						registerChkFlg  = True
						
						m = m + 1
					End If
				Else
					wordDetail(0) = fixedWord.Substring(m, 1)
					
					Dim tempBasipoint As String = BasicPointChecker(mainTxt(i))
					If  tempBasipoint <> "0" Then
						basicPoint = tempBasipoint
					End If
					wordDetail(1) = basicPoint
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
					registerChkFlg  = True
					
					m = m + 1
				End If
			Next j
			If registerChkFlg  = False Then
				wordDetail(1) = insWord(0)(0)
				wordInLine.Add(wordDetail)
				wordDetail = {"", "", "", ""}
			End If
			
			storageWord.Add(wordInLine)
			
			registerChkFlg  = False
			insFlg = False
		Next i
		
'		'2013/8/20 不具合発生。再度確認
'		Dim z As Integer = 0
'		Do Until z = storageWord.Count
'			Dim q As Integer = 0
'			WriteLine(z & "行目")
'			Do Until q = storageWord(z).Count
'				Write(storageWord(z)(q)(0) & "★")
'				Write(storageWord(z)(q)(1) & "★")
'				Write(storageWord(z)(q)(2) & "★")
'				Writeline(storageWord(z)(q)(3))
'				q += 1
'			Loop
'			WriteLine("")
'			z += 1
'		Loop
		
		Return storageWord
	End Function

''''■WordArranger
''' <summary>文字のx軸位置、y軸位置を情報に基づき設定</summary>
''' <param name="mainText">ArrayList 文字の位置情報・フォントサイズ</param>
''' <param name ="storageWord">ArrayList 取得した文字・フォントサイズ</param>
''' <param name="Frm">PrintReport.vb</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>
	Public Sub WordArranger(mainTxt As ArrayList, storageWord As ArrayList, Pr As PrintReport)
		'TODO: 文字が無い時改行だけするようにする
		Dim wordStorager As Array '<- SetIrrXYPos の修正がまだの為、放置
		
		
		
		Dim lineCounter As Integer = mainTxt.Count - 1
		
		If defset("curWriteWay") = "0" Then
			Dim startXPos As Single = CSng(defSet("curTopXPos"))	
			Dim startYPos As Single = CSng(defSet("curTopYPos"))
			Dim newStartYPos As Single = 0
			Dim insColCnt As Integer = 0
			
			For i As Integer = 0  To lineCounter Step 1
				Dim selector As Integer = CInt(mainTxt(i)("tbl_txt_ystyle"))
				Select Case selector
					Case 0	'上																'END: 上の場合の文字ピッチを計算
						If FontSizeDifChecker(storageWord(i)) = True Then					'★★全て同じフォントサイズの時★★
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos"))) 
							If newStartYPos <> 0 Then
								startYPos = newStartYPos									'y軸イレギュラースタートの確認
							End If
																							'文字ピッチの取得
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSet("curBottomYPos")), _
																storageWord(i), _
																Wc.optWord("Common_Font"), _
																0, _
																Pr _
																)
							
							Dim newXpitch As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXpitch <> 0 Then
								startXPos = startXPos + newXpitch							'x軸イレギュラースタートの確認
							End If
							If storageWord(i)(0)(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"),storageWord(i), Pr)
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + fontSize(1))	'END: 文字サイズ＋ピッチへ 2013/7/2

								For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
									storageWord(i)(j)(2) = startYPos
									storageWord(i)(j)(3) = startXPos
									
									Dim fontSizeY() As Single = Pr.FontSizeCal(storageWord(i)(j)(0), Wc.optWord("Common_Font"), storageWord(i)(j)(1))
									startYPos = startYPos + (fontSizeY(0) + properPit)
								Next j
							Else														'文字無し
								Dim fontSize() As Single = Pr.FontSizeCal("口", CStr(Wc.optWord("Common_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + FontSize(1))
									
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.CurrentWord(wordInLine)
								wordDetail = {"", "", "", ""}
								Continue For
							End If
							
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Common_Font"))
						Else															'END: ★★フォントサイズが違う時★★ 2013/7/2


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
													CSng(defSet("curBottomYPos")), _
													CSng(defSet("curBasicPitch")), _
													startXPos, _
													maxWidth, _
													Pr
													)
							Call Pr.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							startXPos = startXPos - maxWidth
'******************************未使用↑******************************


						End If
					Case 1	'下
						If FontSizeDifChecker(storageWord(i)) = True Then						'★★全て同じフォントサイズの時★★
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXPos <> 0 Then
								startXPos = startXPos + newXPos
							End If
							If storageWord(i)(0)(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"),storageWord(i), Pr)
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + fontSize(1))
								
								For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
									storageWord(i)(j)(3) = startXPos
								Next j
							Else														'文字なし
								Dim fontSize() As Single = Pr.FontSizeCal("口", CStr(Wc.optWord("Common_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + FontSize(1))
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.CurrentWord(wordInLine)
								wordDetail = {"", "", "", ""}
								Continue For
							End If 'END: 2013/7/9　下配置修正
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If

							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSet("curBottomYPos")), _
																storageWord(i), _
																Wc.optWord("Common_Font"), _
																0, _
																Pr _
																)
							Dim addHeight As single = CheckLineLength(storageWord(i), Wc.optWord("Common_Font"), Pr)
							'Dim addHeight As Single = 0							'2013/8/25 out mb
							'Dim totalHeight As single = 0				
'							For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
'								Dim tempHeight () As Single = Pr.FontSizeCal(storageWord(i)(j)(0),  Wc.optWord("Common_Font"), storageWord(i)(j)(1))
'								addHeight = addHeight + tempHeight(0)
'							Next j
							
							'totalHeight = Csng(defSet("curBottomYPos")) - (addHeight + (properPit * (CSng(storageWord(i).Count) - 1)))
							startYPos = Csng(defSet("curBottomYPos")) - (addHeight + (properPit * (CSng(storageWord(i).Count) - 1)))
							
							If startYPos <= CSng(Wc.DefSet(3)) Then						'2013/8/25 add 3 lines mb
								startYPos = CSng(Wc.DefSet(3))
							End If
							
							'Call YPosCal(storageWord(i), Wc.optWord("Common_Font"), totalHeight, properPit, Pr)
							Call YPosCal(storageWord(i), Wc.optWord("Common_Font"), startYPos, properPit, Pr)
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Common_Font"))
						Else															'★★フォントサイズが違う時★★
							
							
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
													CSng(defSet("curBottomYPos")), _
													CSng(defSet("curBasicPitch")), _
													startXPos, _
													maxWidth, _
													Pr
													)
							Call Pr.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							
							startXPos = startXPos - maxWidth
'******************************未使用↑******************************
						End If
						
						
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						'END: pointDiffCheckerをつける
						If FontSizeDifChecker(storageWord(i)) = True Then							'★★全て同じフォントサイズの時★★
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos'										y軸イレギュラースタートの確認
							End If
						
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSet("curBottomYPos")), _
																storageWord(i), _
																Wc.optWord("Common_Font"), _
																2, _
																Pr _
																)
						
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXPos <> 0 Then
								startXPos = startXPos + newXPos									'x軸イレギュラースタートの確認
							End If	
							
							If storageWord(i)(0)(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Common_Font"),storageWord(i), Pr)
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + fontSize(1))
								
								For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
									storageWord(i)(j)(2) = startYPos
									storageWord(i)(j)(3) = startXPos
									
									Dim fontSizeY() As Single = Pr.FontSizeCal(storageWord(i)(j)(0), Wc.optWord("Common_Font"), storageWord(i)(j)(1))
									startYPos = startYPos + (fontSizeY(0) + properPit)
								Next j
							Else
								Dim fontSize() As Single = Pr.FontSizeCal("口", CStr(Wc.optWord("Common_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(defSet("curBasicPitch")) + fontSize(1))
								
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.CurrentWord(wordInLine)
								wordDetail = {"", "", "", ""}
								Continue For
							End If
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Common_Font"))
						Else															'フォントサイズが異なる
							'TODO: ★★フォントサイズが違う時★★
						end If	
					End Select

					startYPos = 0

				Next i
		Else
		'TODO: 横書きの時
		End If
	End Sub
	
'データを置き換える
''' ■WordReplacer
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
		
'		2013/8/19　修正内容確認
'		Dim z As Integer = 0
'		Do Until z = Wc.curWord.Count
'			Dim q As Integer = 0
'			WriteLine(z & "行目")
'			Do Until q = Wc.curWord(z).Count
'				Write(Wc.curWord(z)(q)(0) & "★")
'				Write(Wc.curWord(z)(q)(1) & "★")
'				Write(Wc.curWord(z)(q)(2) & "★")
'				Writeline(Wc.curWord(z)(q)(3))
'				q += 1
'			Loop
'			WriteLine("")
'			z += 1
'		Loop
		
		
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

		Dim fontSizeDif As Boolean = FontSizeDifChecker(Wc.curWord(lineNo))
		Dim tempCurWord As New Hashtable
		
		'ArrayListの値を移しておく
		tempCurWord("fontSize") = Wc.curWord(lineNo)(0)(1)					'フォントサイズ
		tempCurWord("topYPos") = Wc.curWord(lineNo)(0)(2)					'y軸位置（天）
		tempCurWord("xPos") = Wc.curWord(lineNo)(0)(3)						'x軸位置
		'curWordの任意の行のデータを削除しておく
		Dim wordCnt As Integer = Wc.curWord(lineNo).Count 
		Wc.curWord(lineNo).RemoveRange(0, wordCnt)

		Dim mainTxt As New Hashtable()
		Dim SctSql As New SelectSql()
		
		'再描画行の文字データを取得
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
				loopCounter = loopCounter + CInt(insWord(i).Length -2)	
			End If
		Next i 
		'不変文字と挿入文字を一つの配列に格納していく
		Dim wordInLine As New ArrayList()
		Dim wordDetail(3) As String
		Dim k As Integer = 0
		Dim l As Integer = 0
		
		If fontSizeDif = True then											'★★全て同じの時★★
			For i As Integer = 0 To loopCounter - 1 Step 1					'END エラーをかわす（insWordに配列が1つしかなく文の先頭にある時など）WordPreparerも
				If IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(1)) = i Then
					For j As Integer = 2 To CInt(insWord(k).Length - 1) Step 1
						wordDetail(0) = insWord(k)(j)
						wordDetail(1) = tempCurWord("fontSize")
						wordDetail(3) = tempCurWord("xPos")					'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}						'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
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
'			Dim tempWordAr(loopCounter + 1) As String						'END: 文字(0 = 文字数, 1 = 空, 2～ = 文字）配列を作る
'			Dim tempFontSizeAr(loopCounter - 1) As String					'END: フォントサイズの配列を作る
'			For i As Integer = 0 To loopCounter - 1 Step 1					2013/8/25 out mb
'				If i = 0 Then
'					tempWordAr(i) = loopCounter
'				End If
'				
'				tempWordAr(i + 2) = wordInLine(i)(0)
'				
'				If i <= loopCounter - 1 Then
'					tempFontSizeAr(i) = wordInLine(i)(1)
'				End If	
'			Next i

			'END: 適正なピッチを取る
			'END: 適正なピッチを使ってy軸位置を決めていく
			'END: 上・下・天地
			Dim properPit As Single
			Dim startYPos As Single = 0
			Select Case yStyle
				Case 0, 2
					Dim irrStartYPos As Single = CSng(mainTxt("tbl_txt_newypos"))
					startYPos = tempCurWord("topYpos")
					If irrStartYPos <> 9999 Then							'END: y軸位置が変わる -> 確認する
						startYPos = irrStartYPos
					End If
					'porperPit = PitchCal(tempCurWord("topYpos"),		2013/8/25 out mb
			 		properPit = PitchCal(startYPos, _
										Wc.DefSet(4), _
										wordInLine, _
										Wc.optWord("Common_Font"), _
										yStyle, _
										Pr _
										)
				Case 1
					Dim addHeight As Single = CheckLineLength(wordInLine, Wc.optWord("Common_Font"), Pr)
					'Dim addHeight As Single = 0									2013/8/25 out mb
					'Dim totalHeight As single = 0
'					For i As Integer = 2 To tempWordAr.Length - 1 Step 1			2013/8/25 out mb
'						Dim tempHeight() As Single = Pr.FontSizeCal(tempWordAr(i), Wc.optWord("Common_Font"), tempFontSizeAr(i - 2))
'						addHeight = addHeight + tempHeight(0)	
'					Next i

'					For i As Integer = 0 To wordInLine.Count - 1 Step 1				2013/8/25 out mb
'						Dim tempHeight() As Single = Pr.FontSizeCal(wordInLine(i)(0), Wc.optWord("Common_Font"), wordInLine(i)(1))
'						addHeight = addHeight + tempHeight(0)
'					Next i
					'newYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(tempWordAr(0)) - 1)))		2013/8/25 out mb
					startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(wordInLine.Count) - 1)))
					
					If startYPos <= CSng(Wc.DefSet(3)) Then
						startYPos = CSng(Wc.DefSet(3))
					End If
					
			 		properPit = PitchCal(startYPos, _
										Wc.DefSet(4), _
										wordInLine, _
										Wc.optWord("Common_Font"), _
										yStyle, _
										Pr _
										)
			End Select
			
			For i As Integer = 0 To loopCounter - 1 Step 1
				wordInLine(i)(2) = startYPos
				Dim tempYPos() As Single = Pr.FontSizeCal(wordInLine(i)(2), Wc.optWord("Common_Font"), CInt(tempCurWord("fontSize")))
				startYPos = startYPos + tempYPos(0) + properPit
			Next i
			
			If wordInLine.Count = 0 Then								'END: 文字なしの時の処理（ダミーデータを入れる）を実装する
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

		'★★★全体的に修正したので大幅に修正が必要
		'TODO:違う時どうするか？
		'TODO:　以下未確認、未完成
		Else																	'★★フォントサイズが違う時★★
			Dim wordStrager(loopCounter + 1) As String
			wordStrager(0) = loopCounter
			
			Dim collectPoint As String
			
			For i As Integer = 2 To loopCounter + 1 Step 1
				If CInt(insWord(1)) =  i Then 
					For j As Integer = 2 To CInt(insWord(k).Length - 1) Step 1  'CHK
						'SetIrregXYPos用
						wordStrager(i) = insWord(i)(j)
						PointCollector(insWord(i)(1), collectPoint) 
						'描画用XY位置未確定
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
					wordDetail(0) = CStr(mainTxt("tbl_txt_txt")).Substring(k, 1)
					wordDetail(1) = insWord(0)(1)
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					k = k + 1
				End If
			Next i
			'イレギュラー配置を計算する
			wordStrager(1) = collectPoint
			
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
        		Dim resultAr(wordLength + 1) As String
        		Dim k As Integer = 0
        		
        		For j As Integer = 0 To wordLength + 1 Step 1
        			If j = 0 Then
        				resultAr(j) = wordPoint										'フォントサイズ = 1 -> 0 に
        			ElseIf j = 1 Then
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
	
'フォントサイズを変更する
'''■ChangeFontSize
''' <summary>フォントサイズを変更して新しい位置を求める</summary>
''' <param name="changeType">Integer 0 = 全体変更　1 = 部分変更か</param>
''' <param name="curWord">ArrayList ByRef 文字配列</param>
''' <param name="lineNo">Integer 変更する行番号</param>
''' <param name="targetPointCmb">Combo 変更するフォントサイズコンボ</param>
''' <param name="Pr">PrintReport</param>
''' <param name="targetCmb">Optional Combo 部分変更時のターゲットコンボ</param>
''' <param name="multiNum">Optional Integer 複数行変更の際の行数</param>
''' <returns>Void 文字配列を参照して変更する</returns>
	Public Sub ChangeFontSize(changeType As Integer, ByRef curWord As ArrayList, lineNo As Integer, _
							  targetPointCmb As ComboBox, Pr As PrintReport, _
							  Optional targetCmb As ComboBox = Nothing, Optional MultiNum As Integer = 0)
		'chnageType 0 = 全体、1 = 部分	2 = マルチ（複数行を全体変更）
		'END: 全体変更するのか、部分変更するのかを確認する -> パラメーターで制御
		'TODO: 文字が無い時の対応が必要
		
		Dim startYPos As Single
		'END: y軸位置がイレギュラーでないか？
		Dim SctSql As New SelectSql
		Dim txtRow As New Hashtable 
				
		Select Case changeType								'★★全体変更
			Case 0
				'END: 一つ前の行のx位置(文字列中最大）を獲得する -> 基本列ピッチ + 新しいフォントサイズのx軸位置 = 新しいx軸位置
				Dim lastWordXPos As Single

				If lineNo <> 0 Then
					lastWordXPos = Wc.curWord(lineNo - 1)(0)(3)
				Else
					lastWordXPos = 0
				End If
				'新しいフォントサイズを突っ込む
				For i As Integer = 0 To curWord(lineNo).Count - 1 Step 1
					curWord(lineNo)(i)(1) = targetPointCmb.SelectedIndex.ToString()
				Next i
				'行内の文字の最大幅をとる
				'END: 文字が無い時ダミーで文字サイズを計測する
				Dim maxWordSize() As Single
				If curWord(lineNo)(0)(0) <> "" Then
					maxWordSize = GetMaxWord(Wc.optWord("Common_Font"), curWord(lineNo), Pr)
				Else
					Dim tempWordDetail() As String = {"口", curWord(lineNo)(0)(1), "", ""}
					Dim tempWordInLine As New ArrayList
					tempWordInLine.Add(tempWordDetail)
					Dim tempCurWord As New ArrayList
					tempCurWord.Add(tempWordInLine)
				
					maxWordSize = GetMaxWord(Wc.optWord("Common_Font"), tempCurWord(0), Pr)
				
					tempWordDetail = Nothing
					tempWordInLine = Nothing
					tempCurWord = Nothing
				End If
				
				'END: 新しいx軸位置の確定
				Dim startNewXPos As Single 
				startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(DefSet("curBasicPitch")))
				'END: 配列に新しいフォントサイズ・x軸位置を突っ込む
				For i As Integer = 0 To curWord(lineNo).Count - 1 Step 1
					'curWord(lineNo)(i)(1) = targetPointCmb.SelectedIndex.ToString()
					curWord(lineNo)(i)(3) = startNewXPos
				Next i
				
				txtRow = SctSql.GetTbl_TxtRow(Wc.CurrentSet(0), Wc.CurrentSet(1), lineNo)
				
				If txtRow("tbl_txt_newypos") <> "9999" Then
					startYPos = txtRow("tbl_txt_newypos")
				Else
					startYPos = defSet(3)
				End If

				Dim properPit As Single = PitchCal(startYPos, _
													CSng(defSet("curBottomYPos")), _
													curWord(lineNo), _
													Wc.optWord("Common_Font"), _
													CInt(txtRow("tbl_txt_ystyle")), _
													Pr _
													)
				'END: y軸位置を決めていく
				Select Case txtRow("tbl_txt_ystyle")
					Case "0", "2"
						Call YPosCal(curWord(lineNo), Wc.optWord("Common_Font"), startYPos, properPit, Pr)
					Case "1"
						Dim addHeight As Single = CheckLineLength(curWord(lineNo), Wc.optWord("Common_Font"), Pr）
						If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
							startYPos = addHeight
						Else
							startYPos = CSng(defSet("curBottomYPos")) - (addHeight + (properPit * (curWord(lineNo).Count -1)))　
						End If
						Call YPosCal(curWord(lineNo), Wc.optWord("Common_Font"), startYPos, properPit, Pr)
				End Select
				'END: 以降の列のx軸位置を変更して行く
				Call ShiftXPos(lineNo, curWord, startNewXPos, Pr)

			Case 1												'★★部分変更
				'TODO:
				
			Case 2
				'END lastWordXPos 要再考
				Dim lastWordXPos As Single
				Dim startNewXPos As Single
				
				If lineNo <> 0 Then
					lastWordXPos = Wc.curWord(lineNo - 1)(0)(3)
				Else
					lastWordXPos = 0
				End If

				For i As Integer = lineNo To　(lineNo + MultiNum) - 1 Step 1
					'新しいフォントサイズを突っ込む
					For j As Integer = 0 To curWord(i).Count -1 Step 1		'GetMaxWordを使うため
						curWord(i)(j)(1) = targetPointCmb.SelectedIndex.ToString()
					Next j
					
					Dim maxWordSize() As Single
					If curWord(i)(0)(0) <> "" Then
						maxWordSize = GetMaxWord(Wc.optWord("Common_Font"), curWord(i), Pr)
					Else
						Dim tempWordDetail() As String = {"口", curWord(i)(0)(1), "", ""}
							Dim tempWordInLine As New ArrayList
							tempWordInLine.Add(tempWordDetail)
							Dim tempCurWord As New ArrayList
							tempCurWord.Add(tempWordInLine)
				
							maxWordSize = GetMaxWord(Wc.optWord("Common_Font"), tempCurWord(0), Pr)
				
							tempWordDetail = Nothing
							tempWordInLine = Nothing
							tempCurWord = Nothing
					End If
					
					If i = lineNo Then
						startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(DefSet("curBasicPitch")))
					Else
						startNewXPos = startNewXPos - (maxWordSize(1) + Csng(DefSet("curBasicPitch")))
					End If
					'x軸位置を突っ込む
					For j As Integer = 0 To curWord(i).Count - 1 Step 1
						curWord(i)(j)(3) = startNewXPos
					Next j
				
					txtRow = SctSql.GetTbl_TxtRow(Wc.CurrentSet(0), Wc.CurrentSet(1), lineNo)
				
					If txtRow("tbl_txt_newypos") <> "9999" Then
						startYPos = txtRow("tbl_txt_newypos")
					Else
						startYPos = defSet(3)
					End If

					Dim properPit As Single = PitchCal(startYPos, _
														CSng(defSet("curBottomYPos")), _
														curWord(i), _
														Wc.optWord("Common_Font"), _
														CInt(txtRow("tbl_txt_ystyle")), _
														Pr _
														)
					'y軸位置を決めていく
					Select Case txtRow("tbl_txt_ystyle")
						Case "0", "2"
							Call YPosCal(curWord(i), Wc.optWord("Common_Font"), startYPos, properPit, Pr)
						Case "1"
							Dim addHeight As Single = CheckLineLength(curWord(i), Wc.optWord("Common_Font"), Pr）
							If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
								startYPos = addHeight
							Else
								startYPos = CSng(defSet("curBottomYPos")) - (addHeight + (properPit * (curWord(i).Count -1)))　
							End If
							Call YPosCal(curWord(i), Wc.optWord("Common_Font"), startYPos, properPit, Pr)
					End Select
				Next i
				'END: 以降の列のx軸位置を変更して行く
				If (lineNo + MultiNum) - 1 <> curWord.Count - 1 Then
					Call ShiftXPos((lineNo + MultiNum) - 1, curWord, startNewXPos, Pr)
				End If
		End Select
		
		SctSql = Nothing
		txtRow = Nothing
		
	End Sub
	
#End Region

#Region "Position"

'''■ShiftXpos
''' <summary>フォントサイズを変更した時の残りの行のx軸位置を増えた分だけずらす</summary>
''' <param name="lineNo">Integer 変更のあった行</param>
''' <param name="word">ArrayList 文字配列</param>
''' <param name="startNewXPos">Single x軸位置の再開始位置</param>
''' <param name="Pr">PrintReport</param>
''' <returns>Void wordに計算値を当て込んでいく</returns>
	Public Sub ShiftXPos(ByVal lineNo As Integer, ByRef word As ArrayList, ByVal startNewXPos As Single, Pr As PrintReport)
		For i As Integer = lineNo + 1 To word.Count - 1 Step 1
			Dim MaxWidth() As Single 
			If word(i)(0)(0) <> "" Then				'空白行の時ダミーデータを差し込む
				MaxWidth = GetMaxWord(Wc.optWord("Common_Font"), word(i), Pr)
			Else
				Dim tempWordDetail() As String = {"口", word(i)(0)(1), "", ""}
				Dim tempWordInLine As New ArrayList
				tempWordInLine.Add(tempWordDetail)
				Dim tempCurWord As New ArrayList
				tempCurWord.Add(tempWordInLine)
				
				MaxWidth = GetMaxWord(Wc.optWord("Common_Font"), tempCurWord(0), Pr)
				
				tempWordDetail = Nothing
				tempWordInLine = Nothing
				tempCurWord = Nothing
			End If
			
			startNewXPos = startNewXPos - (MaxWidth(1) + DefSet("curBasicPitch"))
			
			For j As Integer = 0 To word(i).Count - 1 Step 1
				word(i)(j)(3) = startNewXPos
			Next j
		Next i
		
	End Sub


''' ■YPosCal
''' <summary>y軸方向の文字ピッチを再設定する（フォントサイズが全て同じ時）</summary>
''' <param name="word">ByRef ArrayList 文字配列（文字、フォントサイズ、文字の高さ、文字の幅）</param>
''' <param name="font">String フォント</param>
''' <param name="topYPos">Single y軸の開始位置</param>
''' <param name="pitch">Single 文字ピッチ</param>
''' <param name="pr">Form PrintReport</param>
''' <returns>Void, wordを参照する</returns>
	Public Sub YPosCal(ByRef word As ArrayList, font As String, topYPos As Single, pitch As Single, pr As PrintReport)
		
		Dim loopCounter As Integer = CInt(word.Count)
	
		For i As Integer = 1 To loopCounter Step 1
			Dim fontSize() As Single = pr.FontSizeCal(word(i - 1)(0), font, CInt(word(i - 1)(1)))
			If i = 1 Then
				word(i - 1)(2) = topYPos
			Else
				'word(i - 1)(2) = word(i - 2)(2) + fontSize(0) + defSet("curBasicPitch")		'2013/8/24 out mb
				word(i - 1)(2) = word(i - 2)(2) + fontSize(0) + pitch
			End If
		Next i

	End Sub
	
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
	
#End Region 

#Region "Pitch"

''' ■CheckLineLength
''' <summary>1行の文字を並べた時の長さを測る(文字間のスペースは除く）</summary>
''' <param name="word">ArrayList 文字配列</param>
''' <param name="font">String フォント</param>
''' <param name="Pr">PrintReport</param>
''' <returns>文字の長さを返す</returns>
Public Function CheckLineLength(word As ArrayList, font As String, Pr As PrintReport) As Single
		
		Dim addHeight As Single = 0
		For i As Integer = 0 To word.Count - 1 Step 1
			Dim tempHeight() As Single = Pr.FontSizeCal(word(i)(0), Wc.optWord("Common_Font"), word(i)(1))
				addHeight = addHeight + tempHeight(0)
		Next i
		Return addHeight
	
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
	
'END:　改行ピッチ関数
''''■CheckNewYPos
''' <summary>Y軸の開始位置の変更があるかどうか確認</summary>
''' <param name="newXPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列のy軸スタート位置が違うかどうかの判定に使用</remarks>
 
	Public Function CheckNewYPos(newXpos As Single) As Single
		Dim resultPos As Single = 0
		If newXpos <> 9999 Then
			resultPos = newXpos
			Return resultPos
		End If
			Return 0
	End Function	
	
''''■PitchCal
''' <summary>ピッチを計算</summary>
''' <param name="topYPos">Single 開始位置（位置変更される時があるので必要）</param>
''' <param name="bottomYPos">Single 修了位置</param>
''' <param name="word">ArrayList 単語・フォントサイズ・x・y軸位置の配列</param>
''' <param name="font">String フォント</param>		<- 追加　2013/06/23
''' <param name="yStyle">Integer 上・下・天地揃え</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
	Public Function PitchCal(topYPos As Single, bottomYPos As Single, _
							word As ArrayList, font As String, _
							yStyle As Integer, pr As PrintReport) As Single
							
		Dim resultPitch As Single = 0
		Dim arCounter As Single = word.Count
		Dim firstWord(1) As Single
		Dim lastWord(1) As Single
	
		'文字の長さの取得(最初と最後は決まっている為）
		Dim wordLength() As Single = {0, 0}
		Dim wordHeight As Single = 0
		Dim j As Integer = 0
		For i As Integer = 0 To CInt(arCounter) - 1 Step 1
			Select Case i
			    Case 0
			    	firstWord = pr.FontSizeCal(CStr(word(i)(0)), font, CInt(word(i)(1)))
			    	firstWord(0) = firstWord(0)
			    Case CInt(arCounter) - 1
			    	lastWord = pr.FontSizeCal(CStr(word(i)(0)), font, CInt(word(i)(1)))
			    Case Else
			    	wordLength = pr.FontSizeCal(CStr(word(i)(0)), font, CInt(word(i)(1)))
			    	wordHeight = wordHeight + wordLength(0)
			End Select
			
			j = j + 1
			
		Next i
		'最後の文字の位置を決める
		Dim lastWordPos As Single = bottomYPos - lastWord(0)

		'文字収納範囲
		'Dim wordArea As Single = lastWordPos - firstWord(0)						'2013/8/24 rep mb
		Dim wordArea As Single = lastWordPos  - (topYPos + firstWord(0))
		'文字の長さと収納範囲を検証
		If (wordArea - (wordHeight)) > 0 Then										'ピッチを取れる余裕がある時
			Select Case yStyle
				Case 0
					'Return defSet("curBasicPitch")
					Return defSet("curWordPitch")
				Case 1
					'Return defSet("curBasicPitch")
					Return defSet("curWordPitch")
				Case 2
					resultPitch = (wordArea - wordHeight) / (arCounter - 1)
					Return resultPitch
			End Select
		Else																		'余裕がない時（ビチビチの時　マイナスの値でピッチ幅を減らす）
			resultPitch = (System.Math.Abs(wordArea - wordHeight) / (arCounter - 1)) * -1
			Return resultPitch
		End If
	
	End Function

#End Region

#Region "FontSize"

'END: 文字と文字サイズがばらばらの時を考える（入れ物）
''' ■GetMaxWord
''' <summary>1行内にある文字の最大幅を返す</summary>
''' <param name="font">String フォント</param>
''' <param name="pairWord">ArrayList 文字情報配列</param>
''' <param name= "Pr">PrintReport.vb</param>
''' <returns>1行内にある文字の最大幅を返す</returns> 
Public function GetMaxWord(font As String, storageWord As arraylist, Pr As PrintReport) As Single()
	
	'y軸の最大値は今のところ必要ないので未実装 2013/7/27 mb
	Dim wordSize() As Single = {0s, 0s}	
	
	For i As Integer = 0 To storageWord.Count - 1 Step 1
		Dim tempWordSize() As Single = Pr.FontSizeCal(storageWord(i)(0), font, Val(storageWord(i)(1)))
		If wordSize(1) < tempWordSize(1) Then
			wordSize(1) = tempWordSize(1)
		End If
	Next i
	
	Return wordSize
	
End Function

'''■BasicPointChecker
''' <summary>列単位のフォントサイズの変更を確認</summary>
''' <param name="mainTxt">ArrayList DB内の登録データ</param>
''' <returns>変更が無い時は0を返す、ある時は登録されたフォントサイズを返す</returns>
''' <remarks>列が変わった時に次の列内のフォントサイズが違うかどうかの判定に使用</remarks>
	Public Function BasicPointChecker(mainTxt As Hashtable) As String
		Dim resultStr As String
		If mainTxt("tbl_txt_newpoint") <> "9999" Then
			resultStr = mainTxt("tbl_txt_newpoint")
			Return resultStr
		End If
		
		Return "0"
		
	End Function
	
'''■FontSizeDifChecker
''' <summary>異なったフォントサイズがあるか確かめる</summary>
''' <param name="word">ArrayList 文字+フォント配列のArrayList</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function FontSizeDifChecker(word As ArrayList) As Boolean
		Dim tempFontSize As String = word(0)(1)
		For i As Integer = 0 To word.Count -1 Step 1
			If tempFontSize <> word(i)(1) Then
				Return False
			End If
		Next i
	
		Return True
	
	End Function
	
	
	
	
	'以下廃止予定
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

